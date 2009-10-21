/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 * 
 */

using System;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace BUtil.Localization
{
	/// <summary>
	/// Class loads options and creates
	/// </summary>
	public class BULanguagesManager
	{
		// GUI
		System.Windows.Forms.ToolStripMenuItem[] mi;
		int curlangIndex = -1;
		bool AllowLanguageChange = false;
		
		// DELEGATES
		public delegate void OnApplyLanguage(BUtil.Localization.BUTranslation butransl);
		public delegate void OnSaveLanguageOptions(string NewLanguageOption);
		public delegate string OnLoadLanguageOptions();
		
		// EVENTS
		OnApplyLanguage onApplyLanguage;
		OnSaveLanguageOptions onSaveLanguageOptions;
		OnLoadLanguageOptions onLoadLanguageOptions;
		
		// Languages settings
		public string LanguageName = "default";
		string ProjectName = "";// used when loading localization project
		string LanguageProjectFile = "";
		string LanguageOptionsName = "";
		string pathToLocals = "";
		string[] Namespaces;
		
		// CONFIGURATION FILE
		bool UseExternalOptionsFile = false;
		
		// consts
		const string ProjectLanguageSettings = "LanguageOptions.xml";
		
		
		bool LanguagesListAvailable = false;//! do not change

			
		BUtil.Localization.BULanguages bulanguages;
		
		/// <param name="projectName"></param>
		/// <param name="pathToLocals">c:\locals\. Last \ is required</param>
		public BULanguagesManager(string[] namespaces, string projectName, string PathToLocals, OnApplyLanguage onApplyLanguageEventHandler)
		{
			this.Namespaces = namespaces;
			ProjectName = projectName;
			pathToLocals = PathToLocals;
			
			LanguageProjectFile = PathToLocals + ProjectName + ".xml";
			LanguageOptionsName = PathToLocals + ProjectLanguageSettings;
			
			onApplyLanguage = onApplyLanguageEventHandler;
			
			// loading available languages
			bulanguages = new BUtil.Localization.BULanguages();
			try
			{
				bulanguages.LoadLocalizationDataFromFile(LanguageProjectFile);
			}
			catch (Exception e)
			{
				throw new Exception("Could not open localization project file - " + LanguageProjectFile + " due to: " + e.Message + Environment.NewLine + "Available languages list didn't loaded");
			}
			LanguagesListAvailable = true;
		}
		
		/// <summary>
		/// Disables own config file
		/// </summary>
		/// <param name="ChangeLanguageOptions"></param>
		/// <param name="GettingLanguageOption"></param>
		public void UseOwnConfigurationFile(OnSaveLanguageOptions SaveLanguageOptions, 
			OnLoadLanguageOptions LoadLanguageOptions)
		{
			onSaveLanguageOptions = SaveLanguageOptions;
			onLoadLanguageOptions = LoadLanguageOptions;
			
			UseExternalOptionsFile = true;
		}
		
		/// <summary>
		/// Loads languages lists, if errors-throws exceptions
		/// </summary>
		/// <param name="path">path to directory Local. For example f:\pipeline\local\. Last "\" required.</param>
		public void LoadLanguageSettings()
		{
			if (!UseExternalOptionsFile)
			{
				// Service check
				if (File.Exists(LanguageOptionsName))
				{
					// preparation for reading options xml file
					XmlReader reader;
					XmlReaderSettings Loadsettings = new XmlReaderSettings();
					Loadsettings.ConformanceLevel = ConformanceLevel.Auto;
					Loadsettings.IgnoreComments = true;
					Loadsettings.IgnoreWhitespace = true;
			
					try
					{
						reader = XmlReader.Create(LanguageOptionsName, Loadsettings);
					}
					catch (Exception e)
					{
						throw new Exception("Could not open file for reading localization options - " + LanguageProjectFile + " due to: " + e.Message + Environment.NewLine + "Localization file didn't loaded");
					}
			
					// reading information
					try
					{
						reader.ReadStartElement("Language");
						LanguageName = reader.ReadElementString("Name");
						reader.ReadEndElement();
						reader.Close();
					}
					catch (Exception e)
					{
						// protecting resources
						reader.Close();
				
						throw new Exception("Could not open file for reading localization options - " + LanguageProjectFile + " due to: " + e.Message + Environment.NewLine + "Localization file didn't loaded");
					}
				}
				else ShowSelectlanguageDialog(false);
			}
			// External configuration file
			else
			{
				LanguageName = onLoadLanguageOptions();
				if (LanguageName.Length == 0) ShowSelectlanguageDialog(false);
			}
		}
		
		/// <summary>
		/// Shows select language dialog to user
		/// </summary>
		/// <param name="CanCancel">if true - user can close dialog without making choice</param>
		public void ShowSelectlanguageDialog(bool CanCancel)
		{
			ChooseLanguages chl = new ChooseLanguages(ref bulanguages, CanCancel);
			
			if (chl.ShowDialog() == DialogResult.OK) LanguageName = chl.SelectedLanguageName;
		}
		
		/// <summary>
		/// Applies language
		/// </summary>
		public void ApplyLanguage()
		{
			try
			{
				onApplyLanguage(LoadLocalization());
			}
			catch (Exception er)
			{
				MessageBox.Show("Applying language error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/// <summary>
		/// Adds necessary toolstripmenuitems
		/// </summary>
		public void GenerateMenuWithLanguages(ref System.Windows.Forms.ToolStripMenuItem LanguageMenuItem)
		{
			if (!LanguagesListAvailable) throw new Exception("Trying to use list of languages, which is not loaded");
			
			mi = new ToolStripMenuItem[bulanguages.Count];
			
			BULanguages.Language langitem;
			
			int defaultCode = -1;
			for (int i = 0; i < bulanguages.Count; i++)
			{
				langitem = bulanguages.GetLanguage(i);
				mi[i] = new ToolStripMenuItem(langitem.SpecificName);
				mi[i].CheckOnClick = true;
				mi[i].CheckedChanged += LanguageChangeEventHandler;
				
				
				if (LanguageName == langitem.Name) 
				{
					curlangIndex = i;
					mi[i].Checked = true;
				}
				
				if (langitem.Name == "default") defaultCode = i;
				
			}
			
			// silent protection from erroneous options
			if (curlangIndex < 0) mi[defaultCode].Checked = true;
			
			
			LanguageMenuItem.DropDown.Items.AddRange(mi);

			AllowLanguageChange = true;
		}
		
		
		void LanguageChangeEventHandler (Object sender, EventArgs e)
		{
			if (!AllowLanguageChange) return;
			// Critical section
			AllowLanguageChange = false;
			
			if (curlangIndex >= 0) mi[curlangIndex].Checked = false;
			
			bool found = false;
			for (int i = 0; i < mi.Length; i++)
			{
				if (mi[i].Checked)
				{
					curlangIndex = i;
					LanguageName = bulanguages.GetLanguage(curlangIndex).Name;
					this.ApplyLanguage();
					
					found = true;
					break;
				}
			}
			
			if (found == false)
				if (curlangIndex >= 0) mi[curlangIndex].Checked = true;
			
			AllowLanguageChange = true;			
		}
		
		/// <summary>
		/// Loads localization items into memory
		/// </summary>
		/// <returns>Opened localization</returns>
		public BUTranslation LoadLocalization()
		{
			if (Namespaces.Length > 0)	return LoadThisLocalization();
			else return LoadAllLocalization();
		}
		
		/// <summary>
		/// Loads localization when empty namespace
		/// </summary>
		BUTranslation LoadAllLocalization()
		{
			BUtil.Localization.BUTranslation butranslation = new BUtil.Localization.BUTranslation();
			try
			{
				butranslation.LoadFromFile(pathToLocals + LanguageName + ".Language");
			}
			catch (Exception e)
			{
				throw new Exception("Could not open localization file with " + LanguageName + " language due to: " + e.Message);
			}
			return butranslation;
		}
		
		
		/// <summary>
		/// Loads localization with some predefined namespaces, actual for projects with more than one program entity
		/// </summary>
		/// <param name="LanguageName">for example Russian</param>
		BUTranslation LoadThisLocalization()
		{
			BUtil.Localization.BUTranslation butranslation = new BUtil.Localization.BUTranslation();
			try
			{
				butranslation.LoadNamespacesFromFile(pathToLocals + LanguageName + ".Language", Namespaces);
			}
			catch (Exception e)
			{
				throw new Exception("Could not open localization file with " + LanguageName + " language due to: " + e.Message);
			}
			
			return butranslation;
		}
		
		
		void SaveLanguageSettingsInOwnConfigurationFile()
		{
			//preparation
			// xml options
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = ("    ");
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			XmlWriter writer = null;
			
			try
			{
				try
				{
					writer = XmlWriter.Create(LanguageOptionsName, settings);
				}
				catch (Exception e)
				{
					throw new Exception("Cannot save language options because: " + e.Message);
				}
			
				if (writer == null) throw new Exception("Cannot save language options");
				
				try
				{
					writer.WriteStartElement("Language");
					writer.WriteElementString("Name", LanguageName);
					writer.WriteEndElement();
					writer.Close();
				}
				catch (Exception e)
				{
					throw new Exception("Cannot save language options because: " + e.Message);
				}
			}
			catch (Exception e)
			{
				writer.Close();
				throw e;
			}
		
		}
		
		/// <summary>
		/// Saves messages silently without showing any messages
		/// </summary>
		/// <returns></returns>
		public bool SilentSavingSettings()
		{
			if (!UseExternalOptionsFile)
			{
				try
				{
					SaveLanguageSettingsInOwnConfigurationFile();
				}
				catch
				{
					return false;
				}
			}
			else// EXTERNAL CONFIG FILE
			{
				try
				{
					onSaveLanguageOptions(this.LanguageName);
				}
				catch
				{
					return false;
				}
			
			}
			
			return true;
		}
		
		/// <summary>
		/// Saves chosen language.
		/// Do not throws exception
		/// </summary>
		public bool SaveSettings()
		{
			if (!UseExternalOptionsFile)
			{
				try
				{
					SaveLanguageSettingsInOwnConfigurationFile();
				}
				catch(Exception e)
				{
					MessageBox.Show("Saving language options error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			else// EXTERNAL CONFIG FILE
			{
				try
				{
					onSaveLanguageOptions(this.LanguageName);
				}
				catch(Exception e)
				{
					MessageBox.Show("Saving language options error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
		
			return true;
		}
	}
}
