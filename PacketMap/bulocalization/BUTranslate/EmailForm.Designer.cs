/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * www.DoctorWeb.Zoo.by
 * 
 * Developed in #Develop IDE
 */
namespace BUTranslate
{
	partial class EmailForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
			this.Fromlabel = new System.Windows.Forms.Label();
			this.Tolabel = new System.Windows.Forms.Label();
			this.Subjectlabel = new System.Windows.Forms.Label();
			this.Textlabel = new System.Windows.Forms.Label();
			this.Attachmentlabel = new System.Windows.Forms.Label();
			this.Infolabel = new System.Windows.Forms.Label();
			this.FromtextBox = new System.Windows.Forms.TextBox();
			this.TotextBox = new System.Windows.Forms.TextBox();
			this.SubjecttextBox = new System.Windows.Forms.TextBox();
			this.TexttextBox = new System.Windows.Forms.TextBox();
			this.AttachmenttextBox = new System.Windows.Forms.TextBox();
			this.Sendbutton = new System.Windows.Forms.Button();
			this.Closebutton = new System.Windows.Forms.Button();
			this.SMPTgroupBox = new System.Windows.Forms.GroupBox();
			this.PorttextBox = new System.Windows.Forms.TextBox();
			this.HosttextBox = new System.Windows.Forms.TextBox();
			this.Portlabel = new System.Windows.Forms.Label();
			this.Hostlabel = new System.Windows.Forms.Label();
			this.e_mailgroupBox = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SMPTgroupBox.SuspendLayout();
			this.e_mailgroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Fromlabel
			// 
			this.Fromlabel.Location = new System.Drawing.Point(6, 23);
			this.Fromlabel.Name = "Fromlabel";
			this.Fromlabel.Size = new System.Drawing.Size(100, 17);
			this.Fromlabel.TabIndex = 0;
			this.Fromlabel.Text = "From:";
			// 
			// Tolabel
			// 
			this.Tolabel.Location = new System.Drawing.Point(6, 46);
			this.Tolabel.Name = "Tolabel";
			this.Tolabel.Size = new System.Drawing.Size(100, 17);
			this.Tolabel.TabIndex = 1;
			this.Tolabel.Text = "To:";
			// 
			// Subjectlabel
			// 
			this.Subjectlabel.Location = new System.Drawing.Point(6, 69);
			this.Subjectlabel.Name = "Subjectlabel";
			this.Subjectlabel.Size = new System.Drawing.Size(100, 17);
			this.Subjectlabel.TabIndex = 2;
			this.Subjectlabel.Text = "Subject";
			// 
			// Textlabel
			// 
			this.Textlabel.Location = new System.Drawing.Point(6, 95);
			this.Textlabel.Name = "Textlabel";
			this.Textlabel.Size = new System.Drawing.Size(100, 19);
			this.Textlabel.TabIndex = 3;
			this.Textlabel.Text = "Body:";
			// 
			// Attachmentlabel
			// 
			this.Attachmentlabel.Location = new System.Drawing.Point(6, 177);
			this.Attachmentlabel.Name = "Attachmentlabel";
			this.Attachmentlabel.Size = new System.Drawing.Size(100, 23);
			this.Attachmentlabel.TabIndex = 4;
			this.Attachmentlabel.Text = "Attachment file:";
			// 
			// Infolabel
			// 
			this.Infolabel.Location = new System.Drawing.Point(15, 244);
			this.Infolabel.Name = "Infolabel";
			this.Infolabel.Size = new System.Drawing.Size(455, 37);
			this.Infolabel.TabIndex = 5;
			this.Infolabel.Text = "Now you can just copy-paste this information to your e-mail client or send it dir" +
			"ectly through program!!!";
			// 
			// FromtextBox
			// 
			this.FromtextBox.Location = new System.Drawing.Point(117, 20);
			this.FromtextBox.Name = "FromtextBox";
			this.FromtextBox.ReadOnly = true;
			this.FromtextBox.Size = new System.Drawing.Size(232, 20);
			this.FromtextBox.TabIndex = 6;
			// 
			// TotextBox
			// 
			this.TotextBox.Location = new System.Drawing.Point(117, 43);
			this.TotextBox.Name = "TotextBox";
			this.TotextBox.ReadOnly = true;
			this.TotextBox.Size = new System.Drawing.Size(232, 20);
			this.TotextBox.TabIndex = 7;
			// 
			// SubjecttextBox
			// 
			this.SubjecttextBox.Location = new System.Drawing.Point(117, 66);
			this.SubjecttextBox.Name = "SubjecttextBox";
			this.SubjecttextBox.Size = new System.Drawing.Size(308, 20);
			this.SubjecttextBox.TabIndex = 8;
			this.SubjecttextBox.Text = "Translation into <> language";
			// 
			// TexttextBox
			// 
			this.TexttextBox.Location = new System.Drawing.Point(22, 117);
			this.TexttextBox.Multiline = true;
			this.TexttextBox.Name = "TexttextBox";
			this.TexttextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TexttextBox.Size = new System.Drawing.Size(427, 57);
			this.TexttextBox.TabIndex = 9;
			this.TexttextBox.TextChanged += new System.EventHandler(this.TexttextBoxTextChanged);
			// 
			// AttachmenttextBox
			// 
			this.AttachmenttextBox.Location = new System.Drawing.Point(15, 193);
			this.AttachmenttextBox.Name = "AttachmenttextBox";
			this.AttachmenttextBox.ReadOnly = true;
			this.AttachmenttextBox.Size = new System.Drawing.Size(434, 20);
			this.AttachmenttextBox.TabIndex = 10;
			// 
			// Sendbutton
			// 
			this.Sendbutton.Location = new System.Drawing.Point(371, 368);
			this.Sendbutton.Name = "Sendbutton";
			this.Sendbutton.Size = new System.Drawing.Size(99, 32);
			this.Sendbutton.TabIndex = 11;
			this.Sendbutton.Text = "Send";
			this.Sendbutton.UseVisualStyleBackColor = true;
			this.Sendbutton.Click += new System.EventHandler(this.SendbuttonClick);
			// 
			// Closebutton
			// 
			this.Closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Closebutton.Location = new System.Drawing.Point(262, 368);
			this.Closebutton.Name = "Closebutton";
			this.Closebutton.Size = new System.Drawing.Size(103, 32);
			this.Closebutton.TabIndex = 12;
			this.Closebutton.Text = "Close";
			this.Closebutton.UseVisualStyleBackColor = true;
			// 
			// SMPTgroupBox
			// 
			this.SMPTgroupBox.Controls.Add(this.PorttextBox);
			this.SMPTgroupBox.Controls.Add(this.HosttextBox);
			this.SMPTgroupBox.Controls.Add(this.Portlabel);
			this.SMPTgroupBox.Controls.Add(this.Hostlabel);
			this.SMPTgroupBox.Location = new System.Drawing.Point(16, 284);
			this.SMPTgroupBox.Name = "SMPTgroupBox";
			this.SMPTgroupBox.Size = new System.Drawing.Size(454, 54);
			this.SMPTgroupBox.TabIndex = 13;
			this.SMPTgroupBox.TabStop = false;
			this.SMPTgroupBox.Text = "SMPT options for sending e-mails from program";
			// 
			// PorttextBox
			// 
			this.PorttextBox.Location = new System.Drawing.Point(344, 19);
			this.PorttextBox.Name = "PorttextBox";
			this.PorttextBox.Size = new System.Drawing.Size(93, 20);
			this.PorttextBox.TabIndex = 3;
			this.PorttextBox.Text = "25";
			// 
			// HosttextBox
			// 
			this.HosttextBox.Location = new System.Drawing.Point(67, 19);
			this.HosttextBox.Name = "HosttextBox";
			this.HosttextBox.Size = new System.Drawing.Size(143, 20);
			this.HosttextBox.TabIndex = 2;
			this.HosttextBox.Text = "127.0.0.1";
			// 
			// Portlabel
			// 
			this.Portlabel.Location = new System.Drawing.Point(275, 22);
			this.Portlabel.Name = "Portlabel";
			this.Portlabel.Size = new System.Drawing.Size(63, 20);
			this.Portlabel.TabIndex = 1;
			this.Portlabel.Text = "Port:";
			// 
			// Hostlabel
			// 
			this.Hostlabel.Location = new System.Drawing.Point(15, 22);
			this.Hostlabel.Name = "Hostlabel";
			this.Hostlabel.Size = new System.Drawing.Size(46, 17);
			this.Hostlabel.TabIndex = 0;
			this.Hostlabel.Text = "Host:";
			// 
			// e_mailgroupBox
			// 
			this.e_mailgroupBox.Controls.Add(this.pictureBox1);
			this.e_mailgroupBox.Controls.Add(this.Fromlabel);
			this.e_mailgroupBox.Controls.Add(this.Tolabel);
			this.e_mailgroupBox.Controls.Add(this.Subjectlabel);
			this.e_mailgroupBox.Controls.Add(this.FromtextBox);
			this.e_mailgroupBox.Controls.Add(this.AttachmenttextBox);
			this.e_mailgroupBox.Controls.Add(this.TotextBox);
			this.e_mailgroupBox.Controls.Add(this.TexttextBox);
			this.e_mailgroupBox.Controls.Add(this.Attachmentlabel);
			this.e_mailgroupBox.Controls.Add(this.SubjecttextBox);
			this.e_mailgroupBox.Controls.Add(this.Textlabel);
			this.e_mailgroupBox.Location = new System.Drawing.Point(16, 16);
			this.e_mailgroupBox.Name = "e_mailgroupBox";
			this.e_mailgroupBox.Size = new System.Drawing.Size(455, 225);
			this.e_mailgroupBox.TabIndex = 14;
			this.e_mailgroupBox.TabStop = false;
			this.e_mailgroupBox.Text = "E-mail";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(360, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(89, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// EmailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 412);
			this.Controls.Add(this.e_mailgroupBox);
			this.Controls.Add(this.SMPTgroupBox);
			this.Controls.Add(this.Closebutton);
			this.Controls.Add(this.Sendbutton);
			this.Controls.Add(this.Infolabel);
			this.MaximumSize = new System.Drawing.Size(491, 446);
			this.MinimumSize = new System.Drawing.Size(491, 446);
			this.Name = "EmailForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delivering E-mail service";
			this.Load += new System.EventHandler(this.EmailFormLoad);
			this.SMPTgroupBox.ResumeLayout(false);
			this.SMPTgroupBox.PerformLayout();
			this.e_mailgroupBox.ResumeLayout(false);
			this.e_mailgroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox e_mailgroupBox;
		private System.Windows.Forms.TextBox PorttextBox;
		private System.Windows.Forms.Label Hostlabel;
		private System.Windows.Forms.Label Portlabel;
		private System.Windows.Forms.TextBox HosttextBox;
		private System.Windows.Forms.GroupBox SMPTgroupBox;
		private System.Windows.Forms.Button Closebutton;
		private System.Windows.Forms.Button Sendbutton;
		private System.Windows.Forms.TextBox AttachmenttextBox;
		private System.Windows.Forms.TextBox TexttextBox;
		private System.Windows.Forms.TextBox SubjecttextBox;
		private System.Windows.Forms.TextBox TotextBox;
		private System.Windows.Forms.TextBox FromtextBox;
		private System.Windows.Forms.Label Infolabel;
		private System.Windows.Forms.Label Attachmentlabel;
		private System.Windows.Forms.Label Textlabel;
		private System.Windows.Forms.Label Subjectlabel;
		private System.Windows.Forms.Label Tolabel;
		private System.Windows.Forms.Label Fromlabel;
	}
}
