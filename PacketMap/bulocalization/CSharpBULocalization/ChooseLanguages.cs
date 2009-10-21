/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BUtil.Localization
{
	/// <summary>
	/// Description of ChooseLanguages.
	/// </summary>
	public partial class ChooseLanguages : Form
	{
		public string SelectedLanguageName = "default";
		bool allowCancel;
		BULanguages bulanguages;
			
		public ChooseLanguages(ref BULanguages languages, bool AllowCancel)
		{
			InitializeComponent();
			
			allowCancel = AllowCancel;
			Cancelbutton.Visible = allowCancel;
			bulanguages = languages;
			
			for (int i = 0; i < bulanguages.Count; i++)
				LanguagelistBox.Items.Add(bulanguages.GetLanguage(i).SpecificName);
		}
		
		
		
		void ChooseLanguagesFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!allowCancel) e.Cancel = true;
		}
		
		
		
		void SelectbuttonClick(object sender, EventArgs e)
		{
			if (LanguagelistBox.SelectedIndex >= 0)
			{
				SelectedLanguageName = bulanguages.GetLanguage(LanguagelistBox.SelectedIndex).Name;
				allowCancel = true;
				DialogResult = DialogResult.OK;
			}
		}
	}
}
