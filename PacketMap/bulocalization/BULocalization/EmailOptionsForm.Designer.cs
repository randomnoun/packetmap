/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BULocalization
{
	partial class EmailOptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailOptionsForm));
			this.Okbutton = new System.Windows.Forms.Button();
			this.Cancelbutton = new System.Windows.Forms.Button();
			this.SMPTgroupBox = new System.Windows.Forms.GroupBox();
			this.PorttextBox = new System.Windows.Forms.TextBox();
			this.HosttextBox = new System.Windows.Forms.TextBox();
			this.Portlabel = new System.Windows.Forms.Label();
			this.SMPTlabel = new System.Windows.Forms.Label();
			this.emailtemplategroupBox = new System.Windows.Forms.GroupBox();
			this.FromtextBox = new System.Windows.Forms.TextBox();
			this.Fromlabel = new System.Windows.Forms.Label();
			this.BodytextBox = new System.Windows.Forms.TextBox();
			this.bodylabel = new System.Windows.Forms.Label();
			this.SubjecttextBox = new System.Windows.Forms.TextBox();
			this.Subjectlabel = new System.Windows.Forms.Label();
			this.templateSignsgroupBox = new System.Windows.Forms.GroupBox();
			this.Infolabel = new System.Windows.Forms.Label();
			this.SMPTgroupBox.SuspendLayout();
			this.emailtemplategroupBox.SuspendLayout();
			this.templateSignsgroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// Okbutton
			// 
			this.Okbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Okbutton.Location = new System.Drawing.Point(530, 299);
			this.Okbutton.Name = "Okbutton";
			this.Okbutton.Size = new System.Drawing.Size(103, 29);
			this.Okbutton.TabIndex = 0;
			this.Okbutton.Text = "Ok";
			this.Okbutton.UseVisualStyleBackColor = true;
			this.Okbutton.Click += new System.EventHandler(this.OkbuttonClick);
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancelbutton.Location = new System.Drawing.Point(429, 299);
			this.Cancelbutton.Name = "Cancelbutton";
			this.Cancelbutton.Size = new System.Drawing.Size(95, 29);
			this.Cancelbutton.TabIndex = 1;
			this.Cancelbutton.Text = "Cancel";
			this.Cancelbutton.UseVisualStyleBackColor = true;
			// 
			// SMPTgroupBox
			// 
			this.SMPTgroupBox.Controls.Add(this.PorttextBox);
			this.SMPTgroupBox.Controls.Add(this.HosttextBox);
			this.SMPTgroupBox.Controls.Add(this.Portlabel);
			this.SMPTgroupBox.Controls.Add(this.SMPTlabel);
			this.SMPTgroupBox.Location = new System.Drawing.Point(321, 196);
			this.SMPTgroupBox.Name = "SMPTgroupBox";
			this.SMPTgroupBox.Size = new System.Drawing.Size(312, 81);
			this.SMPTgroupBox.TabIndex = 2;
			this.SMPTgroupBox.TabStop = false;
			this.SMPTgroupBox.Text = "SMPT options";
			// 
			// PorttextBox
			// 
			this.PorttextBox.Location = new System.Drawing.Point(112, 46);
			this.PorttextBox.Name = "PorttextBox";
			this.PorttextBox.Size = new System.Drawing.Size(84, 20);
			this.PorttextBox.TabIndex = 3;
			this.PorttextBox.Text = "25";
			// 
			// HosttextBox
			// 
			this.HosttextBox.Location = new System.Drawing.Point(112, 20);
			this.HosttextBox.Name = "HosttextBox";
			this.HosttextBox.Size = new System.Drawing.Size(169, 20);
			this.HosttextBox.TabIndex = 2;
			this.HosttextBox.Text = "127.0.0.1";
			// 
			// Portlabel
			// 
			this.Portlabel.Location = new System.Drawing.Point(6, 49);
			this.Portlabel.Name = "Portlabel";
			this.Portlabel.Size = new System.Drawing.Size(100, 16);
			this.Portlabel.TabIndex = 1;
			this.Portlabel.Text = "Port:";
			// 
			// SMPTlabel
			// 
			this.SMPTlabel.Location = new System.Drawing.Point(6, 23);
			this.SMPTlabel.Name = "SMPTlabel";
			this.SMPTlabel.Size = new System.Drawing.Size(100, 18);
			this.SMPTlabel.TabIndex = 0;
			this.SMPTlabel.Text = "SMPT host:";
			// 
			// emailtemplategroupBox
			// 
			this.emailtemplategroupBox.Controls.Add(this.FromtextBox);
			this.emailtemplategroupBox.Controls.Add(this.Fromlabel);
			this.emailtemplategroupBox.Controls.Add(this.BodytextBox);
			this.emailtemplategroupBox.Controls.Add(this.bodylabel);
			this.emailtemplategroupBox.Controls.Add(this.SubjecttextBox);
			this.emailtemplategroupBox.Controls.Add(this.Subjectlabel);
			this.emailtemplategroupBox.Location = new System.Drawing.Point(12, 12);
			this.emailtemplategroupBox.Name = "emailtemplategroupBox";
			this.emailtemplategroupBox.Size = new System.Drawing.Size(303, 316);
			this.emailtemplategroupBox.TabIndex = 3;
			this.emailtemplategroupBox.TabStop = false;
			this.emailtemplategroupBox.Text = "E-mail template";
			// 
			// FromtextBox
			// 
			this.FromtextBox.Location = new System.Drawing.Point(18, 39);
			this.FromtextBox.Name = "FromtextBox";
			this.FromtextBox.Size = new System.Drawing.Size(267, 20);
			this.FromtextBox.TabIndex = 5;
			this.FromtextBox.Text = "someemail@somesite.com";
			// 
			// Fromlabel
			// 
			this.Fromlabel.Location = new System.Drawing.Point(7, 18);
			this.Fromlabel.Name = "Fromlabel";
			this.Fromlabel.Size = new System.Drawing.Size(100, 18);
			this.Fromlabel.TabIndex = 4;
			this.Fromlabel.Text = "From:";
			// 
			// BodytextBox
			// 
			this.BodytextBox.Location = new System.Drawing.Point(18, 130);
			this.BodytextBox.Multiline = true;
			this.BodytextBox.Name = "BodytextBox";
			this.BodytextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.BodytextBox.Size = new System.Drawing.Size(267, 162);
			this.BodytextBox.TabIndex = 3;
			this.BodytextBox.Text = resources.GetString("BodytextBox.Text");
			// 
			// bodylabel
			// 
			this.bodylabel.Location = new System.Drawing.Point(7, 109);
			this.bodylabel.Name = "bodylabel";
			this.bodylabel.Size = new System.Drawing.Size(100, 18);
			this.bodylabel.TabIndex = 2;
			this.bodylabel.Text = "Body:";
			// 
			// SubjecttextBox
			// 
			this.SubjecttextBox.Location = new System.Drawing.Point(18, 86);
			this.SubjecttextBox.Name = "SubjecttextBox";
			this.SubjecttextBox.Size = new System.Drawing.Size(267, 20);
			this.SubjecttextBox.TabIndex = 1;
			this.SubjecttextBox.Text = "Please update translation!!!";
			// 
			// Subjectlabel
			// 
			this.Subjectlabel.Location = new System.Drawing.Point(7, 65);
			this.Subjectlabel.Name = "Subjectlabel";
			this.Subjectlabel.Size = new System.Drawing.Size(100, 18);
			this.Subjectlabel.TabIndex = 0;
			this.Subjectlabel.Text = "Subject:";
			// 
			// templateSignsgroupBox
			// 
			this.templateSignsgroupBox.Controls.Add(this.Infolabel);
			this.templateSignsgroupBox.Location = new System.Drawing.Point(321, 12);
			this.templateSignsgroupBox.Name = "templateSignsgroupBox";
			this.templateSignsgroupBox.Size = new System.Drawing.Size(312, 178);
			this.templateSignsgroupBox.TabIndex = 4;
			this.templateSignsgroupBox.TabStop = false;
			this.templateSignsgroupBox.Text = "Exchange abbreviations";
			// 
			// Infolabel
			// 
			this.Infolabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Infolabel.Location = new System.Drawing.Point(6, 16);
			this.Infolabel.Name = "Infolabel";
			this.Infolabel.Size = new System.Drawing.Size(300, 145);
			this.Infolabel.TabIndex = 0;
			this.Infolabel.Text = "$translator - exchanges on the name of translator";
			// 
			// EmailOptionsForm
			// 
			this.AcceptButton = this.Okbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancelbutton;
			this.ClientSize = new System.Drawing.Size(645, 340);
			this.Controls.Add(this.templateSignsgroupBox);
			this.Controls.Add(this.emailtemplategroupBox);
			this.Controls.Add(this.SMPTgroupBox);
			this.Controls.Add(this.Cancelbutton);
			this.Controls.Add(this.Okbutton);
			this.MaximumSize = new System.Drawing.Size(653, 374);
			this.MinimumSize = new System.Drawing.Size(653, 374);
			this.Name = "EmailOptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Email options";
			this.SMPTgroupBox.ResumeLayout(false);
			this.SMPTgroupBox.PerformLayout();
			this.emailtemplategroupBox.ResumeLayout(false);
			this.emailtemplategroupBox.PerformLayout();
			this.templateSignsgroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox BodytextBox;
		private System.Windows.Forms.Label Infolabel;
		private System.Windows.Forms.GroupBox templateSignsgroupBox;
		private System.Windows.Forms.Label Subjectlabel;
		private System.Windows.Forms.TextBox SubjecttextBox;
		private System.Windows.Forms.Label bodylabel;
		private System.Windows.Forms.Label Fromlabel;
		private System.Windows.Forms.TextBox FromtextBox;
		private System.Windows.Forms.GroupBox emailtemplategroupBox;
		private System.Windows.Forms.Label SMPTlabel;
		private System.Windows.Forms.Label Portlabel;
		private System.Windows.Forms.TextBox HosttextBox;
		private System.Windows.Forms.TextBox PorttextBox;
		private System.Windows.Forms.GroupBox SMPTgroupBox;
		private System.Windows.Forms.Button Cancelbutton;
		private System.Windows.Forms.Button Okbutton;
	}
}
