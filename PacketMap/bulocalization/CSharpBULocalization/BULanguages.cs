/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Collections;
using System.Xml;
using System.Text;

namespace BUtil.Localization
{
	/// <summary>
	/// Description of BULanguages.
	/// </summary>
	public class BULanguages
	{
		// Version. Required for modifications creating ans supporting format
		const int Version = 3;
		
		
		public struct Language
		{
			public string Name;
			/// <summary>
			/// Natural name of language
			/// </summary>
			public string SpecificName;
		}
		
		
		Language[] Languages;
		
		/// <summary>
		/// Returns readonly languages
		/// </summary>
		public Language[] languages
		{get {return Languages;}
		
		}
		
		/// <summary>
		/// Checks whether name of specific name of language are unique
		/// </summary>
		/// <param name="item">Language item</param>
		/// <returns>true - if unique</returns>
		public bool CheckUnique(Language item)
		{
			if (Languages.Length != 0)
			for (int i = 0; i < Languages.Length; i++)
			{
				// debug
				//if (Languages[i].LanguageFile == item.LanguageFile) return false;
				if (Languages[i].Name == item.Name) return false;
				if (Languages[i].SpecificName == item.SpecificName) return false;
			}
			return true;
		
		
		}
		
		/// <summary>
		/// Updates all translations on the base of default translation
		/// </summary>
		/// <param name="Path">path to default translation like: c:\local\</param>
		public void UpdateAllTranslations(string Path)
		{
			BUTranslation but = new BUTranslation();
			but.LoadFromFile(Path + "default.Language");
			BUTranslation upt;
			BUTranslation.Item item;
			BUTranslation.Item olditem;
				
			for (int i = 0; i < Languages.Length; i++)
			{
				if (Languages[i].Name == "default") continue;
				upt = new BUTranslation();
				upt.LoadFromFile(Path + Languages[i].Name + ".Language");
				
				but.AuthorCopyright = upt.AuthorCopyright;
				but.AuthorEmail = upt.AuthorEmail;
				but.AuthorFullName = upt.AuthorFullName;
				
				for (int l = 0; l < but.Count(); l++)
				{
					item = but.GetItem(l);
					try
					{
						olditem = upt.GetItemByID(item.id);
					}
					catch
					{
						item.State = "1";
						but.UpdateItem(item, l);
						continue;
					}
					
					item.Translation = olditem.Translation;
					
					if (item.Source == olditem.Source) item.State = olditem.State;
					else item.State = "1";
					
					but.UpdateItem(item, l);
				
				}
				
				but.SaveToFile(Path + Languages[i].Name + ".Language");
				
				
			
			}
			
			
			
			
		
		
		}
		
		/// <summary>
		/// Returns number of languages
		/// </summary>
		public int Count
		{
			get {return Languages.Length;}
		}
		
		/// <summary>
		/// Check whether translation is unique without paying attention to translation with specified array index
		/// </summary>
		/// <param name="item">Language item</param>
		/// <param name="ItemNumber">Index in array</param>
		/// <returns></returns>
		public bool CheckUniqueWithoutNextItem(Language item, int ItemNumber)
		{
			if (Languages.Length != 0)
			for (int i = 0; i < Languages.Length; i++)
			{
				if (i == ItemNumber) continue;
				// debug
				//if (Languages[i].LanguageFile == item.LanguageFile) return false;
				if (Languages[i].Name == item.Name) return false;
				if (Languages[i].SpecificName == item.SpecificName) return false;
			}
			return true;
		
		}
		
		/// <summary>
		/// Updates item
		/// </summary>
		/// <param name="item">Language item</param>
		/// <param name="ItemNumber">Index of item in array</param>
		public void UpdateItem(Language item, int ItemNumber)
		{
			if (ItemNumber > Languages.Length) throw new Exception("Index out of bounds");
			if (!CheckUniqueWithoutNextItem(item, ItemNumber)) throw new Exception("Not unique");
			
			Languages[ItemNumber] = item;
		}
		
		/// <summary>
		/// Deletes language item
		/// </summary>
		/// <param name="index">Index of item in array</param>
		public void DeleteItem(int index)
		{
			if (index > Languages.Length) throw new Exception("Index out of bounds");
			
			if (Languages.Length != index)
			for (int i = index + 1; i < Languages.Length; i++)
			{
				Languages[i - 1] = Languages[i];
			}
			
			Array.Resize(ref Languages, Languages.Length - 1);
			
		}
		
		/// <summary>
		/// Gets language item by its index in array
		/// </summary>
		/// <param name="index">index in array</param>
		/// <returns>Language item</returns>
		public Language GetLanguage(int index)
		{
			if ((index < 0) || (index > Languages.Length)) throw new Exception("Index out of bounds");
			return Languages[index];
		}
		
		/// <summary>
		/// Adds new unique language item
		/// </summary>
		/// <param name="Item">Language item</param>
		public void AddNewItem(Language Item)
		{
			if (!CheckUnique(Item)) throw new Exception("Not unique item");
			Array.Resize(ref Languages, Languages.Length + 1);
			Languages[Languages.Length - 1] = Item;
		}
		
		/// <summary>
		/// Saves localization project to file
		/// </summary>
		/// <param name="FileName">Name of file</param>
		public void SaveLocalizationDataToFile(string FileName)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = Encoding.Unicode;
			settings.IndentChars = ("    ");
			XmlWriter writer = null;
			
			if (FileName.Length == 0) throw new Exception("Empty name");
			
			try
			{
				writer = XmlWriter.Create(FileName, settings);
				if (writer == null) throw new Exception("Could not open file for writing: " + FileName);
				writer.WriteStartElement("XML");
				writer.WriteElementString("Version", Version.ToString());
				
				writer.WriteStartElement("Languages");
				writer.WriteElementString("Length", Languages.Length.ToString());
					
				if (Languages.Length != 0)
				for (int i = 0; i < Languages.Length; i++)
				{
					writer.WriteStartElement("Language");
						writer.WriteElementString("Name", Languages[i].Name);
						writer.WriteElementString("SpecificName", Languages[i].SpecificName);
					writer.WriteEndElement();
				}
				else
				{
					throw new Exception("Empty language list");
				}
			
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
		/// Loads localization project from file
		/// </summary>
		/// <param name="FileName">Name of file</param>
		public void LoadLocalizationDataFromFile(string FileName)
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
				
				reader.ReadStartElement("XML");
				
				// Version control(required)
				int version = Convert.ToInt32(reader.ReadElementString("Version"));
				if (version != Version) throw new Exception("Versions does not match: " + version.ToString() + " - document version; " + Version.ToString() + " - viewer version");
				
				reader.ReadStartElement("Languages");
				int count = Convert.ToInt32(reader.ReadElementString("Length"));
				Languages = new Language[count];
			
				if (count != 0)
				for (int i = 0; i < count; i++)
				{
					reader.ReadStartElement("Language");
						Languages[i].Name = reader.ReadElementString("Name");
						Languages[i].SpecificName = reader.ReadElementString("SpecificName");
					reader.ReadEndElement();
				}
				else
				{
					throw new Exception("Empty language list");
				}
			
				reader.ReadEndElement();
				reader.ReadEndElement();
				reader.Close();
			}
			catch (Exception e)
			{
				reader.Close();
				throw e;
			}
		}
		
		public BULanguages()
		{
			Languages = new Language[0];
			
		}
	}
}
