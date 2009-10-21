/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace BULocalization
{
	/// <summary>
	/// Description of SenderForm.
	/// </summary>
	public partial class SenderForm : Form
	{
		private string SMPThost;
		private string SMPTport;
		
		public SenderForm(string From, string To, string Subj, string Body, string Attach, string SMPTHost, string SMPTPort)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			FromtextBox.Text = From;
			TotextBox.Text = To;
			SubjecttextBox.Text = Subj;
			BodytextBox.Text = Body;
			AttachtextBox.Text = Attach;
			
			SMPThost = SMPTHost;
			SMPTport = SMPTPort;
			
			Send();
		}
		
		
		void Send()
		{
			try
			{
				MailAddress from = new MailAddress(FromtextBox.Text);
				MailAddress to = new MailAddress(TotextBox.Text);
				MailMessage message = new MailMessage(from, to);
				Attachment file = new Attachment(AttachtextBox.Text);
			
				message.Subject = SubjecttextBox.Text;
				message.Body = BodytextBox.Text;
				message.Attachments.Add(file);
			
				SmtpClient client;
			
			
				if (SMPTport.Length != 0) client = new SmtpClient(SMPThost, Convert.ToInt32(SMPTport));
				else client = new SmtpClient(SMPThost);
				
				client.Send(message);
			}
			catch(Exception ee)
			{
				MessageBox.Show("Error occured: " + ee.Message + "\n\nYou can copy information from this form to your e-mail client try to send it or try to send again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Retrybutton.Enabled = true;
				return;
			}
			
				MessageBox.Show("Sended succesfully!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				DialogResult = DialogResult.OK;

		
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			
		}
		
		void RetrybuttonClick(object sender, EventArgs e)
		{
			Send();
		}
	}
}
