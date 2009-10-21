/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Xml;
using System.Text;


namespace BUtil.Localization
{
	/// <summary>
	/// Description of BUTranslation.
	/// </summary>
	public class BUTranslation
	{
		const int Version = 3;
		
		public const string DefaultNamespaceName = "Undefined namespace";
		public int TranslationModeIsDebug = 0;//adding ID's
		
		public string AuthorCopyright = "";
		public string AuthorEmail = "";
		public string AuthorFullName = "";
		
		public struct Namespace
		{
			/// <summary>
			/// Name of namespace
			/// </summary>
			public string Name;
			/// <summary>
			/// Unique id of namespace
			/// </summary>
			public int N_ID;
		}
		
		public struct Item
		{
			public int id;
			public string Source;
			public string Translation;
			public int N_ID;
			/// <summary>
			/// State = "0" means all's OK
			/// State = "1" means item translation require update
			/// State = "2" means item translation contains error that could bring damage to progran. NOT IMPLEMENTED
			/// </summary>
			public string State;//0-ok, 1-rq update, 2- errors
		}
		
		/// <summary>
		/// Get namespace by its ID
		/// </summary>
		/// <param name="N_ID">Unique id of naespace</param>
		/// <returns></returns>
		public string GetNamespaceByN_ID(int N_ID)
		{
			if (N_ID == -1) return DefaultNamespaceName;
			for(int i = 0; i < namespaces.Length; i++)
				if (namespaces[i].N_ID == N_ID) return namespaces[i].Name;
			
			return DefaultNamespaceName;
		}
		
		/// <summary>
		/// Returns namespace ID by its name
		/// </summary>
		/// <param name="NamespaceName">name</param>
		/// <returns></returns>
		public int GetN_IDByName(string NamespaceName)
		{
			if (NamespaceName == DefaultNamespaceName) return -1;
			for(int i = 0; i < namespaces.Length; i++)
				if (namespaces[i].Name == NamespaceName) return namespaces[i].N_ID;
			
			return -1;
		}
		
		
		/// <summary>
		/// Converts text from form like "a\nbcd" to
		/// [0]->a
		/// [1]->bcd
		/// </summary>
		/// <param name="FormattedText">Formatted text</param>
		/// <returns>Formatted text</returns>
		public static string[] CreateEditableText(string FormattedText)
		{
			string[] sometext = new string[1];
			if (FormattedText.Length > 1)
			{
				int count = 1;
				for (int i = 0; i < FormattedText.Length - 1; i++)
				{
					if ((FormattedText[i] == '\\') && (FormattedText[i + 1] == 'n'))
						count++;
				}
				sometext = new string[count];
				
				for (int i = 0; i < count - 1; i++)
				{
					sometext[i] = FormattedText.Substring(0, FormattedText.IndexOf("\\n"));
					FormattedText = FormattedText.Remove(0, FormattedText.IndexOf("\\n") + 2);
				}				
				sometext[count - 1] = FormattedText;
			}
			else
			{
				sometext[0] = FormattedText;
			}
			
			return sometext;
		}
		
		
		/// <summary>
		/// Restores line breakes:
		/// converts "a\nbcd" -> "a" + Environment.NewLine + "bcd"
		/// </summary>
		/// <param name="source">Text in the form "a\nbcd"</param>
		/// <returns>"a" + Environment.NewLine + "bcd"</returns>
		public static string RestoreLineBreakes(string source)
		{
			string[] Editable = CreateEditableText(source);
			string sometext = "";
			
			for (int i = 0; i < Editable.Length - 1; i++)
				sometext += Editable[i] + Environment.NewLine;
			
			sometext += Editable[Editable.Length - 1];
			
			return sometext;
		
		}
		
		/// <summary>
		/// Creates formatted text
		/// </summary>
		/// <param name="source">text in the form [0]->"abcd", [1]-> "efg"</param>
		/// <returns>"abcd\nefg"</returns>
		public static string CreateFormattedText(string[] source)
		{
			int count = source.Length;
			string result;
			if (source.Length == 0) return "";
			
			if (count == 1) result = source[0];
			else
			{
				result = "";
				for (int i = 0; i < count - 1; i++) result += source[i] + "\\n";
				result += source[count - 1];
			}
			
			return result;
		}
		
		
		/// <summary>
		/// Producer e-mail
		/// </summary>
		public string eMail;
		
		/// <summary>
		/// Producer web-link
		/// </summary>
		public string eWWW;
		
		/// <summary>
		/// ID_END is a number of last used ID
		/// </summary>
		private int ID_END;
		
		
		Item[] items;
		Namespace[] namespaces;
		
		/// <summary>
		/// Checks whether the localization item is unique
		/// </summary>
		/// <param name="item">Translation item</param>
		/// <returns>true - if unique</returns>
		public bool CheckUnique(Item item)
		{
			if (items.Length != 0)
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].id == item.id) return false;
			}
			return true;
		
		
		}
		
		
		/// <summary>
		/// Returns number of loaded localization items
		/// </summary>
		public int Count()
		{
			return items.Length;
		}
		
		/// <summary>
		/// Checks whether the item is unique without checking item with ItemNumber in array
		/// </summary>
		/// <param name="item">Item to check</param>
		/// <param name="ItemNumber">Index of item in array</param>
		/// <returns>true if unique</returns>
		public bool CheckUniqueWithoutNextItem(Item item, int ItemNumber)
		{
			if (items.Length != 0)
			for (int i = 0; i < items.Length; i++)
			{
				if (i == ItemNumber) continue;
				if (items[i].id == item.id) return false;
			}
			return true;
		
		}
		
		/// <summary>
		/// Updates item in array
		/// </summary>
		/// <param name="item">Item</param>
		/// <param name="ItemNumber">Index in array</param>
		public void UpdateItem(Item item, int ItemNumber)
		{
			if (ItemNumber > items.Length) throw new Exception("Index out of bounds");
			if (!CheckUniqueWithoutNextItem(item, ItemNumber)) throw new Exception("Not unique");
			
			items[ItemNumber] = item;
		}
		
		/// <summary>
		/// Deletes item from array
		/// </summary>
		/// <param name="index">index in array</param>
		public void DeleteItem(int index)
		{
			if (index > items.Length) throw new Exception("Index out of bounds");
			
			if (items.Length != index)
			for (int i = index + 1; i < items.Length; i++)
			{
				items[i - 1] = items[i];
			}
			
			Array.Resize(ref items, items.Length - 1);
			
		}
		
		/// <summary>
		/// Gets localization item from array
		/// </summary>
		/// <param name="index">index in array</param>
		/// <returns>localization item</returns>
		public Item GetItem(int index)
		{
			if (index > items.Length) throw new Exception("Index out of bounds");
			
			return items[index];
		}
		
		/// <summary>
		/// Adds item
		/// </summary>
		/// <param name="Item">Unique new item</param>
		public void AddNewItem(Item Item)
		{
			if (!CheckUnique(Item)) throw new Exception("Not unique item");
			Array.Resize(ref items, items.Length + 1);
			items[items.Length - 1] = Item;
		}
		
		/// <summary>
		/// Checks whether namespace with this name already exists
		/// </summary>
		/// <param name="Name">Namespace name</param>
		/// <returns>true - if exists</returns>
		public bool IsNamespace(string Name)
		{
			int count = namespaces.Length;
			
			if (count == 0) return false;
			else
				for (int i = 0; i < count; i++)
				if (namespaces[i].Name == Name)
				return true;
			
			return false;
			
		}
		
		/// <summary>
		/// Adds a new namespace
		/// </summary>
		/// <param name="Name">Unique namespace</param>
		public void AddNamespace(string Name)
		{
			if (IsNamespace(Name)) throw new Exception("This namespace is already exists!!!");
			Array.Resize(ref namespaces, namespaces.Length + 1);
			namespaces[namespaces.Length - 1].Name = Name;
			namespaces[namespaces.Length - 1].N_ID = this.GetUniqueN_ID();
		}
		
		/// <summary>
		/// Deletes namespace
		/// </summary>
		/// <param name="Name">Name of namespace</param>
		public void DeleteNamespace(string Name)
		{
			if (!IsNamespace(Name)) throw new Exception("This namespace does not exists!!!");
			

			// deleting references on this namespace in items of this namespace
			int N_ID = this.GetN_IDByName(Name);
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].N_ID == N_ID) items[i].N_ID = -1;
			}
			
			
			// deleting namespace
			int count = namespaces.Length;
			
			for (int i = 0; i < count; i++)
			if (namespaces[i].N_ID == N_ID)
			{
				for (int j = i + 1; j < count; j++)
				{
					namespaces[j - 1] = namespaces[j];
				}
				
				break;
			}
			
			Array.Resize(ref namespaces, namespaces.Length - 1);
			
		}
		
		/// <summary>
		/// Renames namespace
		/// </summary>
		/// <param name="OldName">Old name</param>
		/// <param name="NewName">New unique name</param>
		public void RenameNamespace(string OldName, string NewName)
		{
			if (OldName == NewName) return;
			
			if (!IsNamespace(OldName)) throw new Exception("This namespace does not exists!!!");
			if (IsNamespace(NewName)) throw new Exception("Namespace with new name is already exists!!!");

			int count = namespaces.Length;
			
			for (int i = 0; i < count; i++)
				if (namespaces[i].Name == OldName)
				{
					namespaces[i].Name = NewName;
					break;
				}

		}
		
		public BUTranslation()
		{
			items = new Item[0];
			namespaces = new Namespace[0];
			
			TranslationModeIsDebug = 0;
		}
		
		/// <summary>
		/// Gets namespaces array
		/// </summary>
		/// <returns>namespaces array</returns>
		public string[] GetNameSpaces()
		{
			string[] rez = new string[namespaces.Length];
			for (int i = 0; i < namespaces.Length; i++) rez[i] = namespaces[i].Name;
			return rez;
		}
		
		/// <summary>
		/// Writing specific information about email, www, mode, translator's information to file
		/// </summary>
		/// <param name="writer">opened xml writer</param>
		private void WriteHat(ref XmlWriter writer)
		{
			// send
			writer.WriteElementString("eMail", this.eMail);
			writer.WriteElementString("WWW", this.eWWW);
			//debug
			writer.WriteElementString("Debug_Mode", this.TranslationModeIsDebug.ToString());
			// author
			writer.WriteElementString("Author", this.AuthorCopyright);
			
			writer.WriteElementString("AuthorEmail", this.AuthorEmail);
			writer.WriteElementString("AuthorFullName", this.AuthorFullName);
		}
		
		/// <summary>
		/// Reading specific information about email, www, mode, translator's information to file
		/// </summary>
		/// <param name="reader">opened xml reader</param>
		void ReadHat(ref XmlReader reader)
		{
				eMail = reader.ReadElementString("eMail");
				eWWW = reader.ReadElementString("WWW");
				TranslationModeIsDebug = Convert.ToInt32(reader.ReadElementString("Debug_Mode"));
				// author
				AuthorCopyright = reader.ReadElementString("Author");
				
				AuthorEmail = reader.ReadElementString("AuthorEmail");
				AuthorFullName = reader.ReadElementString("AuthorFullName");

		}
		
		/// <summary>
		/// Saves translation to file
		/// </summary>
		/// <param name="FileName">Name of file</param>
		public void SaveToFile(string FileName)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = Encoding.Unicode;
			settings.IndentChars = ("    ");
			XmlWriter writer = null;
			

			if (this.eMail.Length == 0) throw new Exception("Empty localization producer e-mail");
			if (this.eWWW.Length == 0) throw new Exception("Empty localization producer web-link");

			if (FileName.Length == 0) throw new Exception("Empty name");
			if (namespaces.Length == 0) throw new Exception("Empty namespaces");
			
			try
			{
				writer = XmlWriter.Create(FileName, settings);
				if (writer == null) throw new Exception("Could not open file for writing: " + FileName);
				writer.WriteStartElement("XML");
				
				// required for version control
				writer.WriteElementString("Version", Version.ToString());
				writer.WriteStartElement("Language");
				
				WriteHat(ref writer);
				
				writer.WriteStartElement("Namespaces");
					writer.WriteElementString("Namespaces_Count", namespaces.Length.ToString());
					if (namespaces.Length != 0)
					for (int i = 0; i < namespaces.Length; i++)
					{
						writer.WriteStartElement("Namespace");
						writer.WriteElementString("Name", namespaces[i].Name);
						writer.WriteElementString("N_ID", namespaces[i].N_ID.ToString());
						writer.WriteEndElement();
					}
					else
					{
						throw new Exception("Empty namespaces list");
					}
					
				writer.WriteEndElement();
				
				writer.WriteStartElement("Items");
				
				writer.WriteElementString("Records_Count", items.Length.ToString());
				writer.WriteElementString("ID_END", ID_END.ToString());

				
				
				if (items.Length != 0)
				for (int i = 0; i < items.Length; i++)
				{
					writer.WriteStartElement("Item");
						writer.WriteElementString("ID", items[i].id.ToString());
						writer.WriteElementString("Source", items[i].Source);
						writer.WriteElementString("Translation", items[i].Translation);
						writer.WriteElementString("N_ID", items[i].N_ID.ToString());
						writer.WriteElementString("State", items[i].State);
					writer.WriteEndElement();
				}
				else
				{
					throw new Exception("Empty language list");
				}
			
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.Flush();
				writer.Close();
			}
			catch (Exception e)
			{
				writer.Close();
				throw e;
			}
		}
		
		/// <summary>
		/// Get: returns number of loaded namespaces
		/// </summary>
		public int NamespacesCount
		{
			get {return namespaces.Length;}
		}
		
		/// <summary>
		/// Load from file ALL namespaces and ALL items into memory
		/// </summary>
		/// <param name="FileName">Name of file</param>
		public void LoadFromFile(string FileName)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			XmlReader reader = null;

			if (FileName.Length == 0) throw new Exception("Empty name");
			
			try
			{
				reader = XmlReader.Create(FileName, settings);
				if (reader == null) throw new Exception("Could not open file for reading: " + FileName);
				
				// required for version control
				reader.ReadStartElement("XML");
				int version = Convert.ToInt32(reader.ReadElementString("Version"));
				if (Version != version) throw new Exception("Wrong localization version: " + version.ToString() + " required: " + Version.ToString());
				
				reader.ReadStartElement("Language");
				ReadHat(ref reader);
				reader.ReadStartElement("Namespaces");
				int countnm = Convert.ToInt32(reader.ReadElementString("Namespaces_Count"));
				namespaces = new Namespace[countnm];
				if (countnm != 0)
				for (int i = 0; i < countnm; i++)
				{
					reader.ReadStartElement("Namespace");
						namespaces[i].Name = reader.ReadElementString("Name");
						namespaces[i].N_ID = Convert.ToInt32(reader.ReadElementString("N_ID"));
					reader.ReadEndElement();
				}
				else
				{
					throw new Exception("Empty namespaces list");
				}
				
				reader.ReadEndElement();

				reader.ReadStartElement("Items");
				int count = Convert.ToInt32(reader.ReadElementString("Records_Count"));
				ID_END = Convert.ToInt32(reader.ReadElementString("ID_END"));
				items = new Item[count];
			
				if (count != 0)
				for (int i = 0; i < count; i++)
				{
					reader.ReadStartElement("Item");
						items[i].id = Convert.ToInt32(reader.ReadElementString("ID"));
						items[i].Source = reader.ReadElementString("Source");
						items[i].Translation = reader.ReadElementString("Translation");
						items[i].N_ID = Convert.ToInt32(reader.ReadElementString("N_ID"));
						items[i].State = reader.ReadElementString("State");
					reader.ReadEndElement();
				}
				else
				{
					throw new Exception("Empty language list");
				}
			
				reader.ReadEndElement();
				reader.ReadEndElement();
				reader.ReadEndElement();
				reader.Close();
			}
			catch (Exception e)
			{
				if (reader != null) reader.Close();
				throw e;
			}
		}
		
		/// <summary>
		/// Gets translation string by its unique id
		/// </summary>
		/// <param name="ID">unique id item</param>
		/// <returns>translation - if state is OK, otherwise returns SOURCE, if no ID - throws exception</returns>
		public string GetTranslationByID(int ID)
		{
			string idmessage;
			
			if (TranslationModeIsDebug == 1) idmessage = "ID_" + ID.ToString() + ":";
			else idmessage = "";
				
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].id == ID)
				{
					if (items[i].State == "0") return idmessage + RestoreLineBreakes(items[i].Translation);
					else return idmessage + RestoreLineBreakes(items[i].Source);
				}
			
			}
			
			throw new Exception("Localization: ID " + ID.ToString() + " absent");
		
		}
		
		/// <summary>
		/// Returns item by ID
		/// </summary>
		/// <param name="ID">Unique id</param>
		/// <returns>localziation item</returns>
		public Item GetItemByID(int ID)
		{
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].id == ID)
					return items[i];
			}
			
			throw new Exception("Localization: ID " + ID.ToString() + " absent");
		
		}
		
		/// <summary>
		/// Loads items that belongs to LoadNamespaces from file
		/// </summary>
		/// <param name="FileName">name of file</param>
		/// <param name="LoadNamespaces">set of namespaces</param>
		public void LoadNamespacesFromFile(string FileName, string[] LoadNamespaces)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			XmlReader reader = null;

			namespaces = new Namespace[LoadNamespaces.Length];
			for (int i = 0; i < LoadNamespaces.Length; i++)
				namespaces[i].Name = LoadNamespaces[i];
				
			if (FileName.Length == 0) throw new Exception("Empty name");
			int pos = 0;
			
			try
			{
				reader = XmlReader.Create(FileName, settings);
				if (reader == null) throw new Exception("Could not open file for reading: " + FileName);
				
				// required for version control
				reader.ReadStartElement("XML");
				int version = Convert.ToInt32(reader.ReadElementString("Version"));
				if (Version != version) throw new Exception("Wrong localization version: " + version.ToString() + " required: " + Version.ToString());

				
				reader.ReadStartElement("Language");
				ReadHat(ref reader);
				reader.ReadStartElement("Namespaces");
				int countnm = Convert.ToInt32(reader.ReadElementString("Namespaces_Count"));
				
				Namespace temp;
				
				if (countnm != 0)
				for (int i = 0; i < countnm; i++)
				{
					reader.ReadStartElement("Namespace");
						temp.Name = reader.ReadElementString("Name");
						temp.N_ID = Convert.ToInt32(reader.ReadElementString("N_ID"));
					reader.ReadEndElement();
						
					// if we're searching for it - adding N_ID
					for (int z = 0; z < namespaces.Length; z++)
						if (temp.Name == namespaces[z].Name)
						{
							namespaces[z].N_ID = temp.N_ID;
							break;
						}
					
				}
				else
				{
					throw new Exception("Empty namespaces list");
				}
				
				reader.ReadEndElement();

				reader.ReadStartElement("Items");
				int count = Convert.ToInt32(reader.ReadElementString("Records_Count"));
				ID_END = Convert.ToInt32(reader.ReadElementString("ID_END"));
				items = new Item[count];
				
				
				Item currItem;
			
				if (count != 0)
				for (int i = 0; i < count; i++)
				{
					reader.ReadStartElement("Item");
						currItem.id = Convert.ToInt32(reader.ReadElementString("ID"));
						currItem.Source = reader.ReadElementString("Source");
						currItem.Translation = reader.ReadElementString("Translation");
						currItem.N_ID = Convert.ToInt32(reader.ReadElementString("N_ID"));
						currItem.State = reader.ReadElementString("State");
						if (!this.N_IDisUnique(currItem.N_ID))
						{
							items[pos] = currItem;
							pos++;
						}
					reader.ReadEndElement();
				}
				else
				{
					throw new Exception("Empty language list");
				}
			
				reader.ReadEndElement();
				reader.ReadEndElement();
				reader.ReadEndElement();
				reader.Close();
			}
			catch (Exception e)
			{
				reader.Close();
				throw e;
			}
			
			Array.Resize(ref items, pos);
		}
		
		bool N_IDisUnique(int N_ID)
		{
			for (int i = 0; i < namespaces.Length; i++)
				if (namespaces[i].N_ID == N_ID) return false;
			
			return true;
		
		}
		
		int GetUniqueN_ID()
		{
			// dull
			for (int i = 0; i < 100000; i++)
				if (N_IDisUnique(i)) return i;
			
			return -1;
		
		}
		
		/// <summary>
		/// Returns new unique item ID
		/// </summary>
		/// <returns>new unique item ID</returns>
		public int GetNewID()
		{
			// dull algorithm!!!
			ID_END++;
			return ID_END;
		}
	}
}
