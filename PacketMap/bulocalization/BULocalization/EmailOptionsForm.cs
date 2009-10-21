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
using BUtil.Localization;

namespace BULocalization
{
	/// <summary>
	/// Description of EmailOptionsForm.
	/// </summary>
	public partial class EmailOptionsForm : Form
	{
		private EmailClass EmailRef;
		public EmailOptionsForm(ref EmailClass email)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			FromtextBox.Text = email.FromEmail;
			SubjecttextBox.Text = email.SubjectTemplate;
			BodytextBox.Lines = BUTranslation.CreateEditableText(email.BodyTemplate);
			HosttextBox.Text = email.SMPTHost;
			PorttextBox.Text = email.SMPTPort;
			
			EmailRef = email;
		}
		
		void OkbuttonClick(object sender, EventArgs e)
		{
			EmailRef.FromEmail = FromtextBox.Text;
			EmailRef.SubjectTemplate = SubjecttextBox.Text;
			EmailRef.BodyTemplate = BUTranslation.CreateFormattedText(BodytextBox.Lines);
			EmailRef.SMPTHost = HosttextBox.Text;
			EmailRef.SMPTPort = PorttextBox.Text;
			
			//save
			string filename = Application.StartupPath + "\\Bulocalization.Options";
			try
			{
				EmailRef.Save(filename);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Could not save BULocalization options to: " + filename + "due to:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}
	}
}
