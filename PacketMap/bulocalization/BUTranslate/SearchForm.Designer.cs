/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BUTranslate
{
	partial class SearchForm
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
			this.Searchbutton = new System.Windows.Forms.Button();
			this.Enterlabel = new System.Windows.Forms.Label();
			this.SearchtextBox = new System.Windows.Forms.TextBox();
			this.Closebutton = new System.Windows.Forms.Button();
			this.Resultslabel = new System.Windows.Forms.Label();
			this.RezultstextBox = new System.Windows.Forms.TextBox();
			this.Helplabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Searchbutton
			// 
			this.Searchbutton.Location = new System.Drawing.Point(300, 46);
			this.Searchbutton.Name = "Searchbutton";
			this.Searchbutton.Size = new System.Drawing.Size(79, 20);
			this.Searchbutton.TabIndex = 1;
			this.Searchbutton.Text = "Search...";
			this.Searchbutton.UseVisualStyleBackColor = true;
			this.Searchbutton.Click += new System.EventHandler(this.SearchbuttonClick);
			// 
			// Enterlabel
			// 
			this.Enterlabel.Location = new System.Drawing.Point(12, 20);
			this.Enterlabel.Name = "Enterlabel";
			this.Enterlabel.Size = new System.Drawing.Size(209, 23);
			this.Enterlabel.TabIndex = 1;
			this.Enterlabel.Text = "Enter text fragment you want to search:";
			// 
			// SearchtextBox
			// 
			this.SearchtextBox.Location = new System.Drawing.Point(28, 46);
			this.SearchtextBox.Name = "SearchtextBox";
			this.SearchtextBox.Size = new System.Drawing.Size(252, 20);
			this.SearchtextBox.TabIndex = 0;
			// 
			// Closebutton
			// 
			this.Closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Closebutton.Location = new System.Drawing.Point(304, 192);
			this.Closebutton.Name = "Closebutton";
			this.Closebutton.Size = new System.Drawing.Size(75, 23);
			this.Closebutton.TabIndex = 3;
			this.Closebutton.Text = "Close";
			this.Closebutton.UseVisualStyleBackColor = true;
			this.Closebutton.Click += new System.EventHandler(this.ClosebuttonClick);
			// 
			// Resultslabel
			// 
			this.Resultslabel.Location = new System.Drawing.Point(10, 82);
			this.Resultslabel.Name = "Resultslabel";
			this.Resultslabel.Size = new System.Drawing.Size(135, 23);
			this.Resultslabel.TabIndex = 4;
			this.Resultslabel.Text = "Search results(IDes only):";
			// 
			// RezultstextBox
			// 
			this.RezultstextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RezultstextBox.Location = new System.Drawing.Point(28, 108);
			this.RezultstextBox.Multiline = true;
			this.RezultstextBox.Name = "RezultstextBox";
			this.RezultstextBox.ReadOnly = true;
			this.RezultstextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RezultstextBox.Size = new System.Drawing.Size(351, 55);
			this.RezultstextBox.TabIndex = 5;
			// 
			// Helplabel
			// 
			this.Helplabel.Location = new System.Drawing.Point(12, 166);
			this.Helplabel.Name = "Helplabel";
			this.Helplabel.Size = new System.Drawing.Size(367, 23);
			this.Helplabel.TabIndex = 6;
			this.Helplabel.Text = "To view id\'s in the main window please set translation mode to test";
			// 
			// SearchForm
			// 
			this.AcceptButton = this.Searchbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Closebutton;
			this.ClientSize = new System.Drawing.Size(391, 220);
			this.Controls.Add(this.Helplabel);
			this.Controls.Add(this.RezultstextBox);
			this.Controls.Add(this.Resultslabel);
			this.Controls.Add(this.Closebutton);
			this.Controls.Add(this.SearchtextBox);
			this.Controls.Add(this.Enterlabel);
			this.Controls.Add(this.Searchbutton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(399, 254);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(399, 254);
			this.Name = "SearchForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchFormFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label Helplabel;
		private System.Windows.Forms.TextBox SearchtextBox;
		private System.Windows.Forms.TextBox RezultstextBox;
		private System.Windows.Forms.Label Resultslabel;
		private System.Windows.Forms.Button Closebutton;
		private System.Windows.Forms.Label Enterlabel;
		private System.Windows.Forms.Button Searchbutton;
	}
}
