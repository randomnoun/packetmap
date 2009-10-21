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
	partial class TranslatorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslatorForm));
			this.FullNamelabel = new System.Windows.Forms.Label();
			this.emailLabel = new System.Windows.Forms.Label();
			this.Web_sitelabel = new System.Windows.Forms.Label();
			this.OtherInfolabel = new System.Windows.Forms.Label();
			this.FullNametextBox = new System.Windows.Forms.TextBox();
			this.emailtextBox = new System.Windows.Forms.TextBox();
			this.Web_sitetextBox = new System.Windows.Forms.TextBox();
			this.InfotextBox = new System.Windows.Forms.TextBox();
			this.Info2label = new System.Windows.Forms.Label();
			this.OKbutton = new System.Windows.Forms.Button();
			this.Bottomlabel = new System.Windows.Forms.Label();
			this.RQlabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// FullNamelabel
			// 
			this.FullNamelabel.Location = new System.Drawing.Point(29, 22);
			this.FullNamelabel.Name = "FullNamelabel";
			this.FullNamelabel.Size = new System.Drawing.Size(100, 17);
			this.FullNamelabel.TabIndex = 0;
			this.FullNamelabel.Text = "Full name:";
			// 
			// emailLabel
			// 
			this.emailLabel.Location = new System.Drawing.Point(29, 58);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(100, 17);
			this.emailLabel.TabIndex = 1;
			this.emailLabel.Text = "e-Mail:";
			// 
			// Web_sitelabel
			// 
			this.Web_sitelabel.Location = new System.Drawing.Point(29, 84);
			this.Web_sitelabel.Name = "Web_sitelabel";
			this.Web_sitelabel.Size = new System.Drawing.Size(100, 17);
			this.Web_sitelabel.TabIndex = 2;
			this.Web_sitelabel.Text = "Web-site:";
			// 
			// OtherInfolabel
			// 
			this.OtherInfolabel.Location = new System.Drawing.Point(24, 116);
			this.OtherInfolabel.Name = "OtherInfolabel";
			this.OtherInfolabel.Size = new System.Drawing.Size(100, 23);
			this.OtherInfolabel.TabIndex = 3;
			this.OtherInfolabel.Text = "Other information:";
			// 
			// FullNametextBox
			// 
			this.FullNametextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.FullNametextBox.Location = new System.Drawing.Point(135, 19);
			this.FullNametextBox.Name = "FullNametextBox";
			this.FullNametextBox.Size = new System.Drawing.Size(388, 20);
			this.FullNametextBox.TabIndex = 4;
			// 
			// emailtextBox
			// 
			this.emailtextBox.BackColor = System.Drawing.Color.Yellow;
			this.emailtextBox.Location = new System.Drawing.Point(135, 55);
			this.emailtextBox.Name = "emailtextBox";
			this.emailtextBox.Size = new System.Drawing.Size(334, 20);
			this.emailtextBox.TabIndex = 5;
			// 
			// Web_sitetextBox
			// 
			this.Web_sitetextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.Web_sitetextBox.Location = new System.Drawing.Point(135, 81);
			this.Web_sitetextBox.Name = "Web_sitetextBox";
			this.Web_sitetextBox.Size = new System.Drawing.Size(334, 20);
			this.Web_sitetextBox.TabIndex = 6;
			// 
			// InfotextBox
			// 
			this.InfotextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.InfotextBox.Location = new System.Drawing.Point(41, 135);
			this.InfotextBox.Multiline = true;
			this.InfotextBox.Name = "InfotextBox";
			this.InfotextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.InfotextBox.Size = new System.Drawing.Size(588, 73);
			this.InfotextBox.TabIndex = 7;
			// 
			// Info2label
			// 
			this.Info2label.Location = new System.Drawing.Point(24, 211);
			this.Info2label.Name = "Info2label";
			this.Info2label.Size = new System.Drawing.Size(605, 47);
			this.Info2label.TabIndex = 8;
			this.Info2label.Text = resources.GetString("Info2label.Text");
			// 
			// OKbutton
			// 
			this.OKbutton.Location = new System.Drawing.Point(534, 282);
			this.OKbutton.Name = "OKbutton";
			this.OKbutton.Size = new System.Drawing.Size(115, 31);
			this.OKbutton.TabIndex = 9;
			this.OKbutton.Text = "OK";
			this.OKbutton.UseVisualStyleBackColor = true;
			this.OKbutton.Click += new System.EventHandler(this.OKbuttonClick);
			// 
			// Bottomlabel
			// 
			this.Bottomlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Bottomlabel.Enabled = false;
			this.Bottomlabel.Location = new System.Drawing.Point(-2, 256);
			this.Bottomlabel.Name = "Bottomlabel";
			this.Bottomlabel.Size = new System.Drawing.Size(665, 23);
			this.Bottomlabel.TabIndex = 10;
			this.Bottomlabel.Text = "_________________________________________________________________________________" +
			"_________________________________";
			// 
			// RQlabel
			// 
			this.RQlabel.Location = new System.Drawing.Point(529, 22);
			this.RQlabel.Name = "RQlabel";
			this.RQlabel.Size = new System.Drawing.Size(100, 17);
			this.RQlabel.TabIndex = 11;
			this.RQlabel.Text = "(Required)";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(475, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "(Required)";
			// 
			// TranslatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 325);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RQlabel);
			this.Controls.Add(this.Bottomlabel);
			this.Controls.Add(this.OKbutton);
			this.Controls.Add(this.Info2label);
			this.Controls.Add(this.InfotextBox);
			this.Controls.Add(this.Web_sitetextBox);
			this.Controls.Add(this.emailtextBox);
			this.Controls.Add(this.FullNametextBox);
			this.Controls.Add(this.OtherInfolabel);
			this.Controls.Add(this.Web_sitelabel);
			this.Controls.Add(this.emailLabel);
			this.Controls.Add(this.FullNamelabel);
			this.MaximumSize = new System.Drawing.Size(669, 359);
			this.MinimumSize = new System.Drawing.Size(669, 359);
			this.Name = "TranslatorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Translator information";
			this.Load += new System.EventHandler(this.TranslatorFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label RQlabel;
		private System.Windows.Forms.Label Bottomlabel;
		private System.Windows.Forms.Button OKbutton;
		private System.Windows.Forms.Label Info2label;
		private System.Windows.Forms.TextBox InfotextBox;
		private System.Windows.Forms.TextBox Web_sitetextBox;
		private System.Windows.Forms.TextBox emailtextBox;
		private System.Windows.Forms.TextBox FullNametextBox;
		private System.Windows.Forms.Label OtherInfolabel;
		private System.Windows.Forms.Label Web_sitelabel;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.Label FullNamelabel;
	}
}
