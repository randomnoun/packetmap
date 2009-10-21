/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BULocalization
{
	partial class AddModifyLanguage
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
			this.LanguagegroupBox = new System.Windows.Forms.GroupBox();
			this.NamecomboBox = new System.Windows.Forms.ComboBox();
			this.Helplabel = new System.Windows.Forms.Label();
			this.SpecificNametextBox = new System.Windows.Forms.TextBox();
			this.LanguageLanguageNamelabel = new System.Windows.Forms.Label();
			this.Namelabel = new System.Windows.Forms.Label();
			this.Closebutton = new System.Windows.Forms.Button();
			this.AddModifybutton = new System.Windows.Forms.Button();
			this.DownDelimiterlabel = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.LanguagegroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// LanguagegroupBox
			// 
			this.LanguagegroupBox.Controls.Add(this.NamecomboBox);
			this.LanguagegroupBox.Controls.Add(this.Helplabel);
			this.LanguagegroupBox.Controls.Add(this.SpecificNametextBox);
			this.LanguagegroupBox.Controls.Add(this.LanguageLanguageNamelabel);
			this.LanguagegroupBox.Controls.Add(this.Namelabel);
			this.LanguagegroupBox.Location = new System.Drawing.Point(12, 12);
			this.LanguagegroupBox.Name = "LanguagegroupBox";
			this.LanguagegroupBox.Size = new System.Drawing.Size(487, 155);
			this.LanguagegroupBox.TabIndex = 0;
			this.LanguagegroupBox.TabStop = false;
			this.LanguagegroupBox.Text = "Language settings";
			// 
			// NamecomboBox
			// 
			this.NamecomboBox.AllowDrop = true;
			this.NamecomboBox.AutoCompleteCustomSource.AddRange(new string[] {
									"default",
									"Afrikaans",
									"Albanian",
									"Arabic",
									"Belarusian",
									"Bengali",
									"Bosnian",
									"Brazilian Portuguese",
									"Bulgarian",
									"Catalan",
									"Chinese Simplified",
									"Chinese Traditional",
									"Croatian",
									"Czech",
									"Danish",
									"Dutch",
									"English",
									"Esperanto",
									"Estonian",
									"Finnish",
									"French",
									"Galician",
									"German",
									"Greek",
									"Hebrew",
									"Hindi",
									"Hungarian",
									"Icelandic",
									"Indonesian",
									"Irish Gaelic",
									"Italian",
									"Japanese",
									"Javanese",
									"Kirghiz",
									"Korean",
									"Latin",
									"Latvian",
									"Lithuanian",
									"Macedonian",
									"Malagasy",
									"Malay",
									"Maltese",
									"Marathi",
									"Mongolian",
									"Norwegian",
									"Panjabi",
									"Persian",
									"Polish",
									"Portuguese",
									"Romanian",
									"Russian",
									"Serbian",
									"Slovak",
									"Slovene",
									"Spanish",
									"Swahili",
									"Swedish",
									"Tamil",
									"Telugu",
									"Thai",
									"Turkish",
									"Ukrainian",
									"Urdu",
									"Vietnamese"});
			this.NamecomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.NamecomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.NamecomboBox.FormattingEnabled = true;
			this.NamecomboBox.Items.AddRange(new object[] {
									"default",
									"Afrikaans",
									"Albanian",
									"Arabic",
									"Belarusian",
									"Bengali",
									"Bosnian",
									"Brazilian Portuguese",
									"Bulgarian",
									"Catalan",
									"Chinese Simplified",
									"Chinese Traditional",
									"Croatian",
									"Czech",
									"Danish",
									"Dutch",
									"English",
									"Esperanto",
									"Estonian",
									"Finnish",
									"French",
									"Galician",
									"German",
									"Greek",
									"Hebrew",
									"Hindi",
									"Hungarian",
									"Icelandic",
									"Indonesian",
									"Irish Gaelic",
									"Italian",
									"Japanese",
									"Javanese",
									"Kirghiz",
									"Korean",
									"Latin",
									"Latvian",
									"Lithuanian",
									"Macedonian",
									"Malagasy",
									"Malay",
									"Maltese",
									"Marathi",
									"Mongolian",
									"Norwegian",
									"Panjabi",
									"Persian",
									"Polish",
									"Portuguese",
									"Romanian",
									"Russian",
									"Serbian",
									"Slovak",
									"Slovene",
									"Spanish",
									"Swahili",
									"Swedish",
									"Tamil",
									"Telugu",
									"Thai",
									"Turkish",
									"Ukrainian",
									"Urdu",
									"Vietnamese"});
			this.NamecomboBox.Location = new System.Drawing.Point(222, 29);
			this.NamecomboBox.Name = "NamecomboBox";
			this.NamecomboBox.Size = new System.Drawing.Size(248, 21);
			this.NamecomboBox.TabIndex = 6;
			this.NamecomboBox.Text = "default";
			// 
			// Helplabel
			// 
			this.Helplabel.Location = new System.Drawing.Point(15, 92);
			this.Helplabel.Name = "Helplabel";
			this.Helplabel.Size = new System.Drawing.Size(466, 51);
			this.Helplabel.TabIndex = 5;
			this.Helplabel.Text = "Both fields are required to be filled with information. \r\nFor example: \r\ndefault " +
			" / English or Russian  /  Русский";
			// 
			// SpecificNametextBox
			// 
			this.SpecificNametextBox.Location = new System.Drawing.Point(222, 65);
			this.SpecificNametextBox.Name = "SpecificNametextBox";
			this.SpecificNametextBox.Size = new System.Drawing.Size(248, 20);
			this.SpecificNametextBox.TabIndex = 4;
			this.SpecificNametextBox.Text = "English";
			// 
			// LanguageLanguageNamelabel
			// 
			this.LanguageLanguageNamelabel.Location = new System.Drawing.Point(15, 68);
			this.LanguageLanguageNamelabel.Name = "LanguageLanguageNamelabel";
			this.LanguageLanguageNamelabel.Size = new System.Drawing.Size(201, 24);
			this.LanguageLanguageNamelabel.TabIndex = 1;
			this.LanguageLanguageNamelabel.Text = "Name of language on this language:";
			// 
			// Namelabel
			// 
			this.Namelabel.Location = new System.Drawing.Point(15, 32);
			this.Namelabel.Name = "Namelabel";
			this.Namelabel.Size = new System.Drawing.Size(201, 24);
			this.Namelabel.TabIndex = 0;
			this.Namelabel.Text = "English name of language:";
			// 
			// Closebutton
			// 
			this.Closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Closebutton.Location = new System.Drawing.Point(394, 194);
			this.Closebutton.Name = "Closebutton";
			this.Closebutton.Size = new System.Drawing.Size(105, 30);
			this.Closebutton.TabIndex = 1;
			this.Closebutton.Text = "Close";
			this.Closebutton.UseVisualStyleBackColor = true;
			this.Closebutton.Click += new System.EventHandler(this.ClosebuttonClick);
			// 
			// AddModifybutton
			// 
			this.AddModifybutton.Location = new System.Drawing.Point(283, 194);
			this.AddModifybutton.Name = "AddModifybutton";
			this.AddModifybutton.Size = new System.Drawing.Size(105, 30);
			this.AddModifybutton.TabIndex = 2;
			this.AddModifybutton.Text = "OK";
			this.AddModifybutton.UseVisualStyleBackColor = true;
			this.AddModifybutton.Click += new System.EventHandler(this.AddModifybuttonClick);
			// 
			// DownDelimiterlabel
			// 
			this.DownDelimiterlabel.Enabled = false;
			this.DownDelimiterlabel.Location = new System.Drawing.Point(-1, 170);
			this.DownDelimiterlabel.Name = "DownDelimiterlabel";
			this.DownDelimiterlabel.Size = new System.Drawing.Size(514, 21);
			this.DownDelimiterlabel.TabIndex = 3;
			this.DownDelimiterlabel.Text = "_________________________________________________________________________________" +
			"_________________________________";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Language file|*.Language";
			// 
			// AddModifyLanguage
			// 
			this.AcceptButton = this.AddModifybutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 236);
			this.Controls.Add(this.DownDelimiterlabel);
			this.Controls.Add(this.AddModifybutton);
			this.Controls.Add(this.Closebutton);
			this.Controls.Add(this.LanguagegroupBox);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(519, 270);
			this.MinimumSize = new System.Drawing.Size(519, 270);
			this.Name = "AddModifyLanguage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Language";
			this.Shown += new System.EventHandler(this.AddModifyLanguageShown);
			this.LanguagegroupBox.ResumeLayout(false);
			this.LanguagegroupBox.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox NamecomboBox;
		private System.Windows.Forms.Label Helplabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label DownDelimiterlabel;
		private System.Windows.Forms.Button AddModifybutton;
		private System.Windows.Forms.Button Closebutton;
		private System.Windows.Forms.Label Namelabel;
		private System.Windows.Forms.Label LanguageLanguageNamelabel;
		private System.Windows.Forms.TextBox SpecificNametextBox;
		private System.Windows.Forms.GroupBox LanguagegroupBox;
	}
}
