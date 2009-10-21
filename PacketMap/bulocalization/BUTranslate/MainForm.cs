/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * www.DoctorWeb.Zoo.by
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using BUtil.Localization;

namespace BUTranslate
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string OpenedFile = "";
		BUTranslation buTranslation;
		BUTranslation.Item current_item;
		bool FirstTime;// Shows wheather to store previous editing item or not
		int PreviousIndex;
		SearchForm sf = new SearchForm();
			
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args != null) 
			{
				if (args.Length < 1) Application.Run(new MainForm());
					else Application.Run(new MainForm(args[0]));
			}
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			SetDefOptions();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		string Search(string pattern)
		{
			if (buTranslation.Count()<=0) return "";
			string rez = "";
			BUTranslation.Item item;
			
			for (int i = 0; i < buTranslation.Count();i++)
			{
				item = buTranslation.GetItem(i);
				
				if ((item.Source.Contains(pattern)) ||(item.Translation.Contains(pattern)))
				{
					rez += item.id.ToString() + "; ";
				}
			}
			return rez;
		}
		void SetDefOptions()
		{
			InitializeComponent();
			OpenedFile = "";
			FirstTime = true;
			buTranslation = new BUTranslation();
			PreviousIndex = -1;		
			
			SearchForm.srchDelegate = Search;
		}
		
		public MainForm(string FileName)
		{

			SetDefOptions();
			
			LoadFromFile(FileName);

		}		
		
		
		void LoadFromFile(string FileName)
		{
				try
				{
					buTranslation.LoadFromFile(FileName);
				}
				catch(Exception ee)
				{
					MessageBox.Show(ee.Message + Environment.NewLine + FileName, "BUTranslate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				
				// Changes in interface
				itemslistBox.Items.Clear();
				
				for (int i = 0; i < buTranslation.Count(); i++)
				{
					itemslistBox.Items.Add(MakeViewLine(buTranslation.GetItem(i)));
				}
				OpenedFile = FileName;
				saveToolStripMenuItem.Enabled = true;
				saveToFileToolStripMenuItem.Enabled = true;
				prepareLetterForSendingToolStripMenuItem.Enabled = true;
				translationModeToolStripMenuItem.Enabled = true;
				openTranslationURLToolStripMenuItem.Enabled = true;
				translationModeToolStripMenuItem.Enabled = true;
				validationToolStripMenuItem.Enabled = true;
				debugToolStripMenuItem.Checked = buTranslation.TranslationModeIsDebug == 1;
				releaseToolStripMenuItem.Checked = !debugToolStripMenuItem.Checked;
				
				itemslistBox.Enabled = true;
				
				//MainForm.Text
				Text = OpenedFile + "  " + buTranslation.eWWW + "  BUTranslation";
				
				// Positioning on first element
				itemslistBox.SelectedIndex = 0;
				FirstTime = true;

		
		}
		
		string MakeViewLine(BUTranslation.Item item)
		{
			string state = "";
			switch (item.State)
			{
				case "0": 
					state += "Ok";
					break;
				case "1": 
					state += "Require update"; 
					break;
				default: 
					state += "Erroneous";
					break;			}
			if (buTranslation.TranslationModeIsDebug == 1) state += "  ID_" + item.id.ToString();
			return (state + "   " + item.Source);
		}
		
		void LoadFromFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				LoadFromFile(openFileDialog.FileName);
			}
		}
		
		bool Save(string Name)
		{
			if (Name.Length == 0) return false;
			if (!TranslatorClass.IsReady()) 
			{
				MessageBox.Show("Could not save translation because translator's fields:\n-Full name\n-E-mail\n\ndoes not contain information\n\nPlease go Menu\\Settings\\Translator info and set them", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
			if (debugToolStripMenuItem.Checked) buTranslation.TranslationModeIsDebug = 1;
			else buTranslation.TranslationModeIsDebug = 0;
			
			try
			{
				buTranslation.AuthorCopyright = TranslatorClass.MakeCopyright();
				
				buTranslation.AuthorEmail = TranslatorClass.eMail;
				buTranslation.AuthorFullName = TranslatorClass.FullName;
				
				buTranslation.SaveToFile(OpenedFile);
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}	
			MessageBox.Show("Saved succesfully", "Translation", MessageBoxButtons.OK, MessageBoxIcon.Information);

			OpenedFile = Name;
			Text = OpenedFile + "  BUTranslation";
			return true;
		}
		
		void SaveToFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			saveFileDialog.FileName = OpenedFile;
			
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Save(saveFileDialog.FileName);
			}

		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			Save(OpenedFile);
		}
		
		/// <summary>
		/// Verify translation and corrects state of translation
		/// Dull now
		/// </summary>
		/// <param name="item"></param>
		void VerifyTranslation(ref BUTranslation.Item item)
		{
			if (!turnOnAutovalidationToolStripMenuItem.Checked) return;
			
			if (item.Translation.Length != 0) item.State = "0";
		}
		
		void ItemslistBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			
			if ((itemslistBox.Items.Count < 1)||(itemslistBox.SelectedIndex < 0)) return;
			if (PreviousIndex == itemslistBox.SelectedIndex) return;
			itemslistBox.Enabled = false;
			if (!FirstTime)
			{
				// saving item and validating it
				current_item.Translation = BUTranslation.CreateFormattedText(translationtextBox.Lines);
				VerifyTranslation(ref current_item);
				buTranslation.UpdateItem(current_item, PreviousIndex);
				
				itemslistBox.Items[PreviousIndex] = MakeViewLine(current_item);
			}

			// Loading new item
			current_item = buTranslation.GetItem(itemslistBox.SelectedIndex);
			string[] srce = BUTranslation.CreateEditableText(current_item.Source);
			string[] translation = BUTranslation.CreateEditableText(current_item.Translation);
			srce[srce.Length - 1] += "<<";
			sourcetextBox.Lines = srce;
			translationtextBox.Lines = translation;
			Namespacelabel.Text = buTranslation.GetNamespaceByN_ID(current_item.N_ID);
			PreviousIndex = itemslistBox.SelectedIndex;
			if (current_item.State == "0") translationtextBox.BackColor = Color.LightGreen;
			if (current_item.State == "1") translationtextBox.BackColor = Color.Orange;
			if (current_item.State == "2") translationtextBox.BackColor = Color.Tomato;
			FirstTime = false;
			itemslistBox.Enabled = true;
			Thread.Sleep(500);
		}
		
		void TranslatorInfoToolStripMenuItemClick(object sender, EventArgs e)
		{
			TranslatorForm tf = new TranslatorForm();
			tf.ShowDialog();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
			try
			{
				TranslatorClass.LoadFromFile(Application.StartupPath + "\\");
			}
			catch(Exception ee)
			{
				MessageBox.Show("Cannot load profile options from file profile.xml\n" + ee.Message + "\n\nPlease edit your options and save this information to profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TranslatorForm tf = new TranslatorForm();
				if (tf.ShowDialog() != DialogResult.OK) Application.Exit();
				return;
			}	

		}
		
		void PrepareLetterForSendingToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!TranslatorClass.IsReady()) 
			{
				MessageBox.Show("Could not prepare letter because translator's fields:\n-Full name\n-E-mail\n\ndoes not contain information\n\nPlease go Menu\\Settings\\Translator info and set them", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			EmailForm ef = new EmailForm(buTranslation.eMail, OpenedFile);
			ef.ShowDialog();
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void MainmenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Making programs closer to user\n\nBULocalization Version 1.6\n(c) Cuchuk Sergey Alexandrovich, Cuchuk.Sergey@gmail.com\nFor licenses see Licenses.rtf", "About program", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		void TranslationtextBoxKeyUp(object sender, KeyEventArgs e)
		{
			KeysUp(e);

		}
		
		void HelpToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Translation mode create translation files with special flags.\nWhen 'debug' flag setted: you can save your translation and after that\ntest it in real program you create translation for\nIn this case to every translation string will be added its translation id(so you easily can fix it). And also a new column - id will appear here\nRelease mode - is mode in which program shows only translation string without their id's\n\nIt is required that you'll test your translation in program", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		void DebugToolStripMenuItemClick(object sender, EventArgs e)
		{
			releaseToolStripMenuItem.Checked = false;
			debugToolStripMenuItem.Checked = true;
			buTranslation.TranslationModeIsDebug = 1;
			// Changes in interface
			itemslistBox.Items.Clear();
			
			for (int i = 0; i < buTranslation.Count(); i++)
			{
				itemslistBox.Items.Add(MakeViewLine(buTranslation.GetItem(i)));
			}
		}
		
		void ReleaseToolStripMenuItemClick(object sender, EventArgs e)
		{
			debugToolStripMenuItem.Checked = false;
			releaseToolStripMenuItem.Checked = true;
			buTranslation.TranslationModeIsDebug = 0;
			// Changes in interface
			itemslistBox.Items.Clear();
			
			for (int i = 0; i < buTranslation.Count(); i++)
			{
				itemslistBox.Items.Add(MakeViewLine(buTranslation.GetItem(i)));
			}			
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel=false;
			
			if (OpenedFile.Length == 0) return;
			
			switch (MessageBox.Show("Would you like to save your translation?", "Exiting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case DialogResult.No: sf.AllowClose = true; break;
				case DialogResult.Cancel: e.Cancel = true; break;
				case DialogResult.Yes: e.Cancel = !Save(OpenedFile); sf.AllowClose = !e.Cancel; break;
			}
		}
		
		
		void KeysUp(KeyEventArgs e)
		{
			if (e.Shift)
			{
				if (e.KeyCode == Keys.Up) 
				{
					if (itemslistBox.SelectedIndex > 0) itemslistBox.SelectedIndex--;
				}
				
				if (e.KeyCode == Keys.Down)
				{
					if (itemslistBox.SelectedIndex + 1 < itemslistBox.Items.Count) itemslistBox.SelectedIndex++;
				}

			
			}
		}
		
		void SourcetextBoxKeyUp(object sender, KeyEventArgs e)
		{
			KeysUp(e);
		}
		
		void ItemslistBoxKeyUp(object sender, KeyEventArgs e)
		{
			KeysUp(e);
		}
		
		void OpenTranslationURLToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (buTranslation.eWWW.Length == 0)
			{
				MessageBox.Show("There is no web-link specified in translation\n\nThis translation may be corruped", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Process www = new Process();
			www.StartInfo.UseShellExecute = true;
			www.StartInfo.FileName = buTranslation.eWWW;
			try
			{
				www.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		
		void VisitHomepageToolStripMenuItemClick(object sender, EventArgs e)
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
		
		void CopybuttonClick(object sender, EventArgs e)
		{
			translationtextBox.SelectAll();
			translationtextBox.Copy();
			translationtextBox.Select(0,0);
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
		
		void FindReferencesToolStripMenuItemClick(object sender, EventArgs e)
		{
			sf.Show();
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
