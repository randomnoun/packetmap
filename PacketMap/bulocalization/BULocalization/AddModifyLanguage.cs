/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * www.DoctorWeb.Zoo.by
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using BUtil.Localization;

namespace BULocalization
{
	/// <summary>
	/// Description of AddModifyLanguage.
	/// </summary>
	public partial class AddModifyLanguage : Form
	{
		public BULanguages.Language language;
		
		public AddModifyLanguage(BULanguages.Language ThisLanguage)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			// adding list of available languages
		
			language = ThisLanguage;

			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void AddModifyLanguageShown(object sender, EventArgs e)
		{
			NamecomboBox.Text = language.Name;
			SpecificNametextBox.Text = language.SpecificName;
		}
		
	
		void AddModifybuttonClick(object sender, EventArgs e)
		{
			if (NamecomboBox.Text.Length == 0) return;
			if (SpecificNametextBox.Text.Length == 0) return;
			// debug
			//if (LocationtextBox.Text.Length == 0) return;
			
			language.Name = NamecomboBox.Text;
			language.SpecificName = SpecificNametextBox.Text;
			
			DialogResult = DialogResult.OK;
			
			
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			
		}
	}
}
