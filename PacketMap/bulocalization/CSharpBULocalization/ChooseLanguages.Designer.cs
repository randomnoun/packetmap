/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BUtil.Localization
{
	partial class ChooseLanguages
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
			this.LanguagelistBox = new System.Windows.Forms.ListBox();
			this.ChooseLanguagelabel = new System.Windows.Forms.Label();
			this.Selectbutton = new System.Windows.Forms.Button();
			this.Cancelbutton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LanguagelistBox
			// 
			this.LanguagelistBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LanguagelistBox.FormattingEnabled = true;
			this.LanguagelistBox.Location = new System.Drawing.Point(12, 56);
			this.LanguagelistBox.Name = "LanguagelistBox";
			this.LanguagelistBox.ScrollAlwaysVisible = true;
			this.LanguagelistBox.Size = new System.Drawing.Size(279, 160);
			this.LanguagelistBox.TabIndex = 0;
			// 
			// ChooseLanguagelabel
			// 
			this.ChooseLanguagelabel.Location = new System.Drawing.Point(12, 21);
			this.ChooseLanguagelabel.Name = "ChooseLanguagelabel";
			this.ChooseLanguagelabel.Size = new System.Drawing.Size(279, 32);
			this.ChooseLanguagelabel.TabIndex = 1;
            this.ChooseLanguagelabel.Text = "Please select your preferred language:";
			this.ChooseLanguagelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Selectbutton
			// 
			this.Selectbutton.Location = new System.Drawing.Point(216, 231);
			this.Selectbutton.Name = "Selectbutton";
			this.Selectbutton.Size = new System.Drawing.Size(75, 23);
			this.Selectbutton.TabIndex = 2;
			this.Selectbutton.Text = "Select";
			this.Selectbutton.UseVisualStyleBackColor = true;
			this.Selectbutton.Click += new System.EventHandler(this.SelectbuttonClick);
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancelbutton.Location = new System.Drawing.Point(118, 231);
			this.Cancelbutton.Name = "Cancelbutton";
			this.Cancelbutton.Size = new System.Drawing.Size(92, 23);
			this.Cancelbutton.TabIndex = 3;
			this.Cancelbutton.Text = "Cancel";
			this.Cancelbutton.UseVisualStyleBackColor = true;
			// 
			// ChooseLanguages
			// 
			this.AcceptButton = this.Selectbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancelbutton;
			this.ClientSize = new System.Drawing.Size(303, 266);
			this.ControlBox = false;
			this.Controls.Add(this.Cancelbutton);
			this.Controls.Add(this.Selectbutton);
			this.Controls.Add(this.ChooseLanguagelabel);
			this.Controls.Add(this.LanguagelistBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChooseLanguages";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Choose language";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseLanguagesFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button Cancelbutton;
		private System.Windows.Forms.Button Selectbutton;
		private System.Windows.Forms.Label ChooseLanguagelabel;
		private System.Windows.Forms.ListBox LanguagelistBox;
	}
}
