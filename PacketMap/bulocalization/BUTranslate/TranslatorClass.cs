/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * www.DoctorWeb.Zoo.by
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Xml;
using System.Text;

namespace BUTranslate
{
	/// <summary>
	/// Description of TranslatorClass.
	/// </summary>
	public static class TranslatorClass
	{
		public static string FullName = "";
		public static string eMail = "";
		public static string WebSite = "";
		
		public static string SMPTPort = "25";
		public static string SMPTHost = "127.0.0.1";
		
		public static string ProfileName = "profile.xml";
		
		public static string[] OtherContactInformation = new string[0];
		
		public static bool IsReady()
		{
			if (FullName.Length == 0) return false;
			if (eMail.Length == 0) return false;
			
			return true;
		
		}
		
		public static string MakeCopyright()
		{
			if (!IsReady()) throw new Exception("Not enough information to generate copyright");
			
			return ("Copyright (c) " + DateTime.Now.Year.ToString() + " " + FullName + ", " + eMail);
		}
		
		public static void SaveInformation(string onlypath)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = Encoding.Unicode;
			settings.IndentChars = ("    ");
			XmlWriter writer = null;
			
			if (FullName.Length == 0) throw new Exception("Empty name");
			if (eMail.Length == 0) throw new Exception("Empty e-mail field");
			
			try
			{
				writer = XmlWriter.Create(onlypath + ProfileName, settings);
				if (writer == null) throw new Exception("Could not for writing file: " + onlypath + ProfileName);
				writer.WriteStartElement("TranslatorOptions");
				writer.WriteStartElement("Translator");
					writer.WriteElementString("FullName", FullName);
					writer.WriteElementString("eMail", eMail);
					writer.WriteElementString("WebSite", WebSite);
					writer.WriteElementString("Count", OtherContactInformation.Length.ToString());
				
				for (int i = 0; i < OtherContactInformation.Length; i++)
				{
					writer.WriteElementString("Info" + i.ToString(), OtherContactInformation[i]);
				}
				writer.WriteEndElement();
				
				//SMPT options
				writer.WriteStartElement("SMPT");
					writer.WriteElementString("SMPTPort", SMPTPort);
					writer.WriteElementString("SMPTHost", SMPTHost);
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
		
		public static void LoadFromFile(string onlypath)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			XmlReader reader = null;

			if (ProfileName.Length == 0) throw new Exception("Empty name");
			try
			{
				reader = XmlReader.Create(onlypath + ProfileName, settings);
				if (reader == null) throw new Exception("Could not for reading file: " + onlypath + ProfileName);
				reader.ReadStartElement("TranslatorOptions");
				reader.ReadStartElement("Translator");
					FullName = reader.ReadElementString("FullName");
					eMail = reader.ReadElementString("eMail");
					WebSite = reader.ReadElementString("WebSite");
					int count = Convert.ToInt32(reader.ReadElementString("Count"));
				OtherContactInformation = new string[count];
				if (count != 0)
				for (int i = 0; i < count; i++)
				{
					OtherContactInformation[i] = reader.ReadElementString("Info" + i.ToString());
				}
				reader.ReadEndElement();
				
				reader.ReadStartElement("SMPT");
					SMPTPort = reader.ReadElementString("SMPTPort");
					SMPTHost = reader.ReadElementString("SMPTHost");
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
	}
	
	
	
}
