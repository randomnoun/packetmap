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

namespace BUTranslate
{
	/// <summary>
	/// Description of TranslatorForm.
	/// </summary>
	public partial class TranslatorForm : Form
	{
		public TranslatorForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TranslatorFormLoad(object sender, EventArgs e)
		{
			FullNametextBox.Text = TranslatorClass.FullName;
			emailtextBox.Text = TranslatorClass.eMail;
			Web_sitetextBox.Text = TranslatorClass.WebSite;
			InfotextBox.Lines = TranslatorClass.OtherContactInformation;
			
		}
		
		void OKbuttonClick(object sender, EventArgs e)
		{
			string PrevFullName = TranslatorClass.FullName;
			string PreveMail = TranslatorClass.eMail;
			string PrevWebSite = TranslatorClass.WebSite;
			string[] PrevOtherContactInformation = TranslatorClass.OtherContactInformation;
			
			TranslatorClass.FullName = FullNametextBox.Text;
			TranslatorClass.eMail = emailtextBox.Text;
			TranslatorClass.WebSite = Web_sitetextBox.Text;
			TranslatorClass.OtherContactInformation = InfotextBox.Lines;
			
			try
			{
				TranslatorClass.SaveInformation(Application.StartupPath + "\\");
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
				// protecting resources
				TranslatorClass.FullName = PrevFullName;
				TranslatorClass.eMail = PreveMail;
				TranslatorClass.WebSite = PrevWebSite;
				TranslatorClass.OtherContactInformation = PrevOtherContactInformation;

				return;
			}
			DialogResult = DialogResult.OK;
		}
	}
}
