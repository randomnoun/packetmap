/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BULocalization
{
	partial class WizardForm
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
			this.Nextbutton = new System.Windows.Forms.Button();
			this.Previousbutton = new System.Windows.Forms.Button();
			this.Closebutton = new System.Windows.Forms.Button();
			this.Helplabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Nextbutton
			// 
			this.Nextbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Nextbutton.Location = new System.Drawing.Point(554, 101);
			this.Nextbutton.Name = "Nextbutton";
			this.Nextbutton.Size = new System.Drawing.Size(75, 23);
			this.Nextbutton.TabIndex = 0;
			this.Nextbutton.Text = "Next >";
			this.Nextbutton.UseVisualStyleBackColor = true;
			this.Nextbutton.Click += new System.EventHandler(this.NextbuttonClick);
			// 
			// Previousbutton
			// 
			this.Previousbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Previousbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Previousbutton.Enabled = false;
			this.Previousbutton.Location = new System.Drawing.Point(473, 101);
			this.Previousbutton.Name = "Previousbutton";
			this.Previousbutton.Size = new System.Drawing.Size(75, 23);
			this.Previousbutton.TabIndex = 1;
			this.Previousbutton.Text = "< Back";
			this.Previousbutton.UseVisualStyleBackColor = true;
			this.Previousbutton.Click += new System.EventHandler(this.PreviousbuttonClick);
			// 
			// Closebutton
			// 
			this.Closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Closebutton.Location = new System.Drawing.Point(387, 101);
			this.Closebutton.Name = "Closebutton";
			this.Closebutton.Size = new System.Drawing.Size(80, 23);
			this.Closebutton.TabIndex = 2;
			this.Closebutton.Text = "Close";
			this.Closebutton.UseVisualStyleBackColor = true;
			this.Closebutton.Click += new System.EventHandler(this.ClosebuttonClick);
			// 
			// Helplabel
			// 
			this.Helplabel.BackColor = System.Drawing.Color.SeaShell;
			this.Helplabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Helplabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Helplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Helplabel.Location = new System.Drawing.Point(12, 20);
			this.Helplabel.Name = "Helplabel";
			this.Helplabel.Size = new System.Drawing.Size(617, 69);
			this.Helplabel.TabIndex = 3;
			this.Helplabel.Text = "<HELP>";
			this.Helplabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WizardForm
			// 
			this.AcceptButton = this.Nextbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Previousbutton;
			this.ClientSize = new System.Drawing.Size(641, 136);
			this.Controls.Add(this.Helplabel);
			this.Controls.Add(this.Closebutton);
			this.Controls.Add(this.Previousbutton);
			this.Controls.Add(this.Nextbutton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(649, 170);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(649, 170);
			this.Name = "WizardForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "Wizard";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label Helplabel;
		private System.Windows.Forms.Button Closebutton;
		private System.Windows.Forms.Button Previousbutton;
		private System.Windows.Forms.Button Nextbutton;
	}
}
