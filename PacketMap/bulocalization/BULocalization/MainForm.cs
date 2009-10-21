/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Data;
using BUtil.Localization;

namespace BULocalization
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		BULanguages buLanguages;
		string path = "";
		string ProjectFile = "";
		EmailClass emailclass = new EmailClass();
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			buLanguages = new BULanguages();
		}
		
		void AddNewLanguage()
		{
			BULanguages.Language lang;
			
			lang.Name = "";
			lang.SpecificName = "";
			
			AddModifyLanguage aml = new AddModifyLanguage(lang);
			
			if (aml.ShowDialog() == DialogResult.OK)
			{
				lang = aml.language;
					
				if (!buLanguages.CheckUnique(lang))
				{
					MessageBox.Show("Not unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				buLanguages.AddNewItem(lang);
				
				string[] row = new string[2];
				row[0] = lang.Name;
				row[1] = lang.SpecificName;

				LangdataGridView.Rows.Add(row);
			}
			
		}
		
		void DeleteItem()
		{
			
			if (LangdataGridView.SelectedRows.Count == 0) return;
			
			int index = LangdataGridView.SelectedRows[0].Index;
			if (MessageBox.Show("Are you sure you want delete this item?\n\nName: " 
			                    + (string)LangdataGridView.Rows[index].Cells[0].Value 
			                    + "\nSpecific name: " 
			                    + (string)LangdataGridView.Rows[index].Cells[1].Value , 
			                    "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				LangdataGridView.Rows.RemoveAt(index);
				buLanguages.DeleteItem(index);
			}
		
		}
		
		void ModifyLanguage()
		{
			BULanguages.Language lang;
			
			if (LangdataGridView.SelectedRows.Count == 0) return;
			
			int index = LangdataGridView.Rows.IndexOf(LangdataGridView.SelectedRows[0]);
			
			lang = buLanguages.GetLanguage(index);
			
			
			AddModifyLanguage aml = new AddModifyLanguage(lang);
			
			if (aml.ShowDialog() == DialogResult.OK)
			{
				lang = aml.language;
					
				if (!buLanguages.CheckUniqueWithoutNextItem(lang, index))
				{
					MessageBox.Show("Not unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				buLanguages.UpdateItem(lang, index);
				LangdataGridView.Rows[index].Cells[0].Value = lang.Name;
				LangdataGridView.Rows[index].Cells[1].Value = lang.SpecificName;
			
			}
			
		}
		
		
		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Save(saveFileDialog.FileName);
			}
		}
		
		void AdLangdataGridViewoolStripMenuItemClick(object sender, EventArgs e)
		{
			AddNewLanguage();
		}
		
		
		void ModifyToolStripMenuItemClick(object sender, EventArgs e)
		{
			ModifyLanguage();
		}
		
		void ModifyLanguagebuttonClick(object sender, EventArgs e)
		{
			ModifyLanguage();
		}
		
		void RemoveToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteItem();
		}
		

		
		void LocaleFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void LoadLangdataGridViewoolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					buLanguages.LoadLocalizationDataFromFile(openFileDialog.FileName);
					// business
					path = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf("\\") + 1);
					ProjectFile = openFileDialog.FileName;
					// interface
					this.Text = ProjectFile + " BULocalization";
				}
				catch(Exception ee)
				{
					MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				LangdataGridView.Rows.Clear();
				foreach (BULanguages.Language lang in buLanguages.languages)
				{
					string[] dr = new string[2];
					dr[0] = lang.Name;
					dr[1] = lang.SpecificName;
					
					LangdataGridView.Rows.Add(dr);
				}
				
				//buLanguages.languages;
				/*for (int i = 0; i < buLanguages.Count; i++)
					LanguageslistBox.Items.Add(buLanguages.GetLanguage(i).Name);*/
			}
		}
		
		void ChangeDefaultTranslation()
		{
			if (path.Length == 0) 
			{
				MessageBox.Show("Before editing default translation please save project file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			BULanguages.Language temp;
			temp.Name = "default";
			temp.SpecificName = "default";
			if (buLanguages.CheckUnique(temp))
			{
				MessageBox.Show("Before editing default translation please add it to list: default / default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.Hide();
			ChangeDefaultLanguage cdl = new ChangeDefaultLanguage(path);
			cdl.ShowDialog();
			
			// Now upgrading localizations
			if (MessageBox.Show("Would you like to upgrade all existing translations?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				UpdateAllTranslations();
				
				if (MessageBox.Show("Would you like to send letters to all translators?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SendLetters();
				}
			}
			
			this.Show();
		}
		
		void DefaultTranslationToolStripMenuItemClick(object sender, EventArgs e)
		{
			ChangeDefaultTranslation();
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Making programs closer to user\n\nBULocalization Version: 1.6\nCopyright (c)2007 Cuchuk Sergey Alexandrovich\nCuchuk.Sergey@gmail.com\nFor licenses see Licenses.rtf", "About program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		
		void UpdatebuttonClick(object sender, EventArgs e)
		{
			
		}
		
		void UpdateAllTranslations()
		{
			if (path.Length == 0) return;
			try
			{
				buLanguages.UpdateAllTranslations(path);
			}
			catch (Exception e)
			{
				MessageBox.Show("During updating translations error occured:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		}
		
		void UpdateAllTranslationsToolStripMenuItemClick(object sender, EventArgs e)
		{
			UpdateAllTranslations();
		}
		
		void ModifyTranslation()
		{
			if (LangdataGridView.SelectedRows.Count == 0) return;
			int index = LangdataGridView.Rows.IndexOf(LangdataGridView.SelectedRows[0]);

			if (path.Length == 0)
			{
				MessageBox.Show("Before modifying translations please save your project file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			BULanguages.Language temp;
			temp.Name = "default";
			temp.SpecificName = "default";
			if (buLanguages.CheckUnique(temp))
			{
				MessageBox.Show("Before modifying translations please add and modify default trabslation: default / default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if ((string)LangdataGridView.Rows[index].Cells[0].Value == "default") return;
			
			string UnquotedFileName = path + buLanguages.GetLanguage(index).Name + ".Language";
			string PathName = "\"" + UnquotedFileName + "\"";
			
			if (!File.Exists(UnquotedFileName))
			{
				MessageBox.Show("File with this translation does not exists. Creating...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				
				try
				{
					File.Copy(path + "default.Language", UnquotedFileName);
				}
				catch (Exception exc)
				{
					MessageBox.Show("Could not create localization file: " + UnquotedFileName + " on base of default translation due to: " + exc.Message + "\n\nPlease verify that you:\n- created default localization\n- modified this default localization first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			
			Process pg = new Process();
			pg.StartInfo.FileName = Application.StartupPath + "\\BUTranslate.exe";
			pg.StartInfo.Arguments = PathName;
			
			this.Hide();

			try
            {
                pg.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Could not start BUTranslate.exe because : " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
                return;
            }
            pg.WaitForExit();
            this.Show();
            
            
		}
		
		void CurrentTranslationToolStripMenuItemClick(object sender, EventArgs e)
		{
			ModifyTranslation();
		}
		
		
		
		void LanguageslistBoxClick(object sender, EventArgs e)
		{
			if (LangdataGridView.SelectedRows.Count == 0) return;
			
			if ((string)LangdataGridView.SelectedRows[0].Cells[0].Value != "default") ModifyTranslation();
			else ChangeDefaultTranslation();
		}
		
		

		
		void EmailToolStripMenuItemClick(object sender, EventArgs e)
		{
			EmailOptionsForm eof = new EmailOptionsForm(ref emailclass);
			eof.ShowDialog();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string filename = Application.StartupPath + "\\Bulocalization.Options";
			try
			{
				emailclass.Load(filename);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Could not load BULocalization options in\n" + filename + "\ndue to:\n" + exc.Message + "\n\nPlease change options and save them", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			
						

		}
		
		bool Save(string FileName)
		{
			try
			{
				// Errors
				if (FileName.Length == 0) throw new Exception("Empty project name");
				if (LangdataGridView.Rows.Count < 1) throw new Exception("No localizations in list to save.\n\nPlease add at least \"default\" localization(even it is empty)");
				
				buLanguages.SaveLocalizationDataToFile(FileName);
				// !order is significant
				// business
				path = FileName.Substring(0, saveFileDialog.FileName.LastIndexOf("\\") + 1);
				ProjectFile = FileName;
				// interface
				this.Text = ProjectFile + " BULocalization";
				
			}
			catch (Exception exc)
			{
				MessageBox.Show("Could not save BULocalization options due to:\n\n" + FileName + "due to:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
            }
			return true;
			
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ProjectFile.Length == 0) SaveAsToolStripMenuItemClick(sender, e);
			else Save(ProjectFile);
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (ProjectFile.Length != 0)
			switch (MessageBox.Show("Would you like to save localization project file?", "Exiting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					if (!Save(ProjectFile))
					{
						e.Cancel = true;
						return;
					}
					
					DialogResult = DialogResult.OK;
					break;
				case DialogResult.No:
					DialogResult = DialogResult.Cancel;
					break;
					
				default: 
					e.Cancel = true;
					break;
					
			}

		}
		
		void OpenWeblinkToolStripMenuItemClick(object sender, EventArgs e)
		{
			SupportClass.VisitHomePage();
		}
		
		void SupportRequestToolStripMenuItemClick(object sender, EventArgs e)
		{
			SupportClass.SupportRequest();
		}
		
		void FeatureRequestToolStripMenuItemClick(object sender, EventArgs e)
		{
			SupportClass.FeatureRequest();
		}
		
		void ReportABugToolStripMenuItemClick(object sender, EventArgs e)
		{
			SupportClass.ReportABug();
		}
		
		void MakeADonationToolStripMenuItemClick(object sender, EventArgs e)
		{
			SupportClass.MakeADonation();
		}
		
		
		
		
		void UpgradetoolStripButtonClick(object sender, EventArgs e)
		{
			UpdateAllTranslations();
			
		}
		
		void SendLetters()
		{
			if (LangdataGridView.Rows.Count <= 1) return;

			if (MessageBox.Show("Did you upgrade all translations?", "Preparation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;			
			if (MessageBox.Show("Are you sure you want to send them all e-mails?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;
			
			BULanguages.Language currentlang;
			SenderForm sf;
			BUTranslation buTranslation = new BUTranslation();
			for (int i = 0; i < buLanguages.Count; i++)
			{
				currentlang = buLanguages.GetLanguage(i);
				
				if (currentlang.Name == "default") continue;
				
				// Opening translation
				buTranslation.LoadFromFile(path + currentlang.Name + ".Language");
				

				//$translator
				string subject = emailclass.SubjectTemplate;
				string body = BUTranslation.RestoreLineBreakes(emailclass.BodyTemplate);
				
				//replacing all data
				//$translator
				subject = subject.Replace("$translator", buTranslation.AuthorFullName);
				body = body.Replace("$translator", buTranslation.AuthorFullName);
					
				sf = new SenderForm(buTranslation.AuthorEmail, buTranslation.eMail, subject, body, path + currentlang.Name + ".Language", emailclass.SMPTHost, emailclass.SMPTPort);
				
				sf.ShowDialog();
			
			
			}		
		
		}
		
		void LetterSenLangdataGridViewoolStripButtonClick(object sender, EventArgs e)
		{//(string)LangdataGridView.Rows[index].Cells[0].Value 
			SendLetters();
		}
		
		void AddNewtoolStripButtonClick(object sender, EventArgs e)
		{
			AddNewLanguage();
		}
		
		void DeltoolStripButtonClick(object sender, EventArgs e)
		{
			DeleteItem();
		}
		
		void ModifytoolStripButtonClick(object sender, EventArgs e)
		{
			ModifyLanguage();
		}
		
		void UpdateDefaulttoolStripButtonClick(object sender, EventArgs e)
		{
			ChangeDefaultTranslation(); 
		}
		
		void UpdateSimpleLanguagetoolStripButton1Click(object sender, EventArgs e)
		{
			ModifyTranslation();
		}
		
		void LangdataGridViewCellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			ModifyTranslation();
		}
		
		void LetterSendtoolStripButtonClick(object sender, EventArgs e)
		{
			SendLetters();
		}
		

		
		
		void AddToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddNewLanguage();
		}
		
		void AskTranslatorsToUpgradeTheirTranslationsToolStripMenuItemClick(object sender, EventArgs e)
		{
			SendLetters();
		}
		
		void NewProjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			//CreateNewProject
			WizardForm wf = new WizardForm(HelpClass.CreateNewProject);
			wf.Show(null);
		}
		
		void DocumentationToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process helpprocess = new Process();
			// !!!
			helpprocess.StartInfo.FileName = Directory.GetParent(Application.StartupPath) + "\\end-user-docs\\manual.pdf";
			helpprocess.StartInfo.UseShellExecute = true;
			try
			{
				helpprocess.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Cannot open help file:" + Environment.NewLine + helpprocess.StartInfo.FileName + Environment.NewLine + "due to: \n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
	/// <summary>
	/// Description of SupportClass.
	/// </summary>
	public static class SupportClass
	{ 
		const string SupportRequestURL = "https://sourceforge.net/tracker/?func=add&group_id=195114&atid=952142";
		const string FeatureRequestURL = "https://sourceforge.net/tracker/?func=add&group_id=195114&atid=952144";
		const string ReportABugURL = "https://sourceforge.net/tracker/?func=add&group_id=195114&atid=952141";
		const string VisitHomePageURL = "https://sourceforge.net/projects/bulocalization/";
		const string DonationURL = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=cuchuk.sergey%40gmail%2ecom&item_name=Butil&no_shipping=2&no_note=1&tax=0&currency_code=GBP&bn=PP%2dDonationsBF&charset=UTF%2d8";
		
		// For supporting localization
		public static string GUIError = "Error";
		
		static private void OpenWebLink(string Link)
		{
			Process webbrowser = new Process();
			
			webbrowser.StartInfo.UseShellExecute = true;
			webbrowser.StartInfo.FileName = Link;
			
			try
			{
				webbrowser.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show(Link + Environment.NewLine + exc.Message, GUIError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}
		
		static public void SupportRequest()
		{
			OpenWebLink(SupportRequestURL);
		}
		
		static public void FeatureRequest()
		{
			OpenWebLink(FeatureRequestURL);
		}
		
		static public void ReportABug()
		{
			OpenWebLink(ReportABugURL);
		}
		
		static public void VisitHomePage()
		{
			OpenWebLink(VisitHomePageURL);
		}
		static public void MakeADonation()
		{
			OpenWebLink(DonationURL);
		}
	}
}
