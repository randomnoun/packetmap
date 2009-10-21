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
using System.Net.Mail;

namespace BUTranslate
{
	/// <summary>
	/// Description of EmailForm.
	/// </summary>
	public partial class EmailForm : Form
	{
		
		public EmailForm(string To, string attach)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			TotextBox.Text = To;
			AttachmenttextBox.Text = attach;
			
			HosttextBox.Text = TranslatorClass.SMPTHost;
			PorttextBox.Text = TranslatorClass.SMPTPort;

			// improvements(e-mail)
			if (To.Length == 0) 
			{
				MessageBox.Show("There's no e-mail to whom translation should be send\n\nThis translation is corrupted!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Sendbutton.Enabled = false;
			}
			
			if (TranslatorClass.eMail.Length == 0)
			{
				MessageBox.Show("You haven't specified your e-mail\n\nPlease specify it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Sendbutton.Enabled = false;
			}
			
		}
		
		void EmailFormLoad(object sender, EventArgs e)
		{
			FromtextBox.Text = TranslatorClass.eMail;
			SubjecttextBox.Text = "Translation created : " + DateTime.Now.ToLongDateString();
			TexttextBox.Text = TranslatorClass.FullName + Environment.NewLine + 
								TranslatorClass.WebSite + Environment.NewLine + 
								"English name of language: " + Environment.NewLine + 
								"Native name on this language: " + Environment.NewLine + 
								"I would like to support my translation: Yes" + Environment.NewLine;
			for (int i = 0; i < TranslatorClass.OtherContactInformation.Length; i++)
				TexttextBox.Text +=	TranslatorClass.OtherContactInformation[i] + Environment.NewLine;
				
		}
		
		void SendbuttonClick(object sender, EventArgs e)
		{
			TranslatorClass.SMPTHost = HosttextBox.Text;
			TranslatorClass.SMPTPort = PorttextBox.Text;
			try
			{
				TranslatorClass.SaveInformation(Application.StartupPath + "\\");
			}
			catch(Exception ee)
			{
				MessageBox.Show("Could not save to your profile SMPT options: \n" + ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			MailAddress from;
			MailAddress to;
			MailMessage message;
			Attachment file;
			SmtpClient client;
			
			try
			{
				// bug with bad creation e-mail form fixed
				from = new MailAddress(FromtextBox.Text);
				to = new MailAddress(TotextBox.Text);
				message = new MailMessage(from, to);
				file = new Attachment(AttachmenttextBox.Text);
			
				message.Subject = SubjecttextBox.Text;
				message.Body = TexttextBox.Text;
				message.Attachments.Add(file);
			
				
			
				if (PorttextBox.Text.Length != 0) client = new SmtpClient(HosttextBox.Text, Convert.ToInt32(PorttextBox.Text));
				else client = new SmtpClient(HosttextBox.Text);
			}
			catch(Exception ee)
			{
				MessageBox.Show("Error occured: " + ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			
			MessageBox.Show("Sending an e-mail message:\nTo: " + to.ToString() + 
			                "\nSMTP host and port: " + client.Host + "  " + client.Port.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			try
			{
				client.Send(message);
			}
			catch(Exception ee)
			{
				MessageBox.Show("Error occured: " + ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			MessageBox.Show("Sended succesfully!!!","Sended", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			
			

			
		}
		
		void TexttextBoxTextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
