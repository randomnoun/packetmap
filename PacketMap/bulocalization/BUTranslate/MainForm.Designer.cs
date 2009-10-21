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
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainmenuStrip = new System.Windows.Forms.MenuStrip();
			this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.prepareLetterForSendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openTranslationURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.validationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.turnOnAutovalidationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.translationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.translatorInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.visitHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.supportRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.featureRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.makeADonationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Listlabel = new System.Windows.Forms.Label();
			this.itemslistBox = new System.Windows.Forms.ListBox();
			this.translategroupBox = new System.Windows.Forms.GroupBox();
			this.Copybutton = new System.Windows.Forms.Button();
			this.translationtextBox = new System.Windows.Forms.TextBox();
			this.sourcegroupBox = new System.Windows.Forms.GroupBox();
			this.Namespacelabel = new System.Windows.Forms.Label();
			this.sourcetextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Infolabel = new System.Windows.Forms.Label();
			this.MainmenuStrip.SuspendLayout();
			this.translategroupBox.SuspendLayout();
			this.sourcegroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainmenuStrip
			// 
			this.MainmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.translationToolStripMenuItem,
									this.validationToolStripMenuItem,
									this.translationModeToolStripMenuItem,
									this.searchToolStripMenuItem,
									this.settingsToolStripMenuItem,
									this.aboutToolStripMenuItem,
									this.helpToolStripMenuItem1});
			this.MainmenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainmenuStrip.Name = "MainmenuStrip";
			this.MainmenuStrip.Size = new System.Drawing.Size(684, 24);
			this.MainmenuStrip.TabIndex = 0;
			this.MainmenuStrip.Text = "menuStrip1";
			this.MainmenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainmenuStripItemClicked);
			// 
			// translationToolStripMenuItem
			// 
			this.translationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadFromFileToolStripMenuItem,
									this.saveToFileToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.toolStripSeparator2,
									this.prepareLetterForSendingToolStripMenuItem,
									this.openTranslationURLToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
			this.translationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
			this.translationToolStripMenuItem.Text = "Translation";
			// 
			// loadFromFileToolStripMenuItem
			// 
			this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
			this.loadFromFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.loadFromFileToolStripMenuItem.Text = "Load from file...";
			this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFileToolStripMenuItemClick);
			// 
			// saveToFileToolStripMenuItem
			// 
			this.saveToFileToolStripMenuItem.Enabled = false;
			this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
			this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.saveToFileToolStripMenuItem.Text = "Save to file...";
			this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.SaveToFileToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(249, 6);
			// 
			// prepareLetterForSendingToolStripMenuItem
			// 
			this.prepareLetterForSendingToolStripMenuItem.Enabled = false;
			this.prepareLetterForSendingToolStripMenuItem.Name = "prepareLetterForSendingToolStripMenuItem";
			this.prepareLetterForSendingToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.prepareLetterForSendingToolStripMenuItem.Text = "Prepare letter for sending translation";
			this.prepareLetterForSendingToolStripMenuItem.Click += new System.EventHandler(this.PrepareLetterForSendingToolStripMenuItemClick);
			// 
			// openTranslationURLToolStripMenuItem
			// 
			this.openTranslationURLToolStripMenuItem.Enabled = false;
			this.openTranslationURLToolStripMenuItem.Name = "openTranslationURLToolStripMenuItem";
			this.openTranslationURLToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.openTranslationURLToolStripMenuItem.Text = "Open translation URL";
			this.openTranslationURLToolStripMenuItem.Click += new System.EventHandler(this.OpenTranslationURLToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(249, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// validationToolStripMenuItem
			// 
			this.validationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.turnOnAutovalidationToolStripMenuItem});
			this.validationToolStripMenuItem.Enabled = false;
			this.validationToolStripMenuItem.Name = "validationToolStripMenuItem";
			this.validationToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.validationToolStripMenuItem.Text = "Validation";
			// 
			// turnOnAutovalidationToolStripMenuItem
			// 
			this.turnOnAutovalidationToolStripMenuItem.Checked = true;
			this.turnOnAutovalidationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.turnOnAutovalidationToolStripMenuItem.Name = "turnOnAutovalidationToolStripMenuItem";
			this.turnOnAutovalidationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.turnOnAutovalidationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.turnOnAutovalidationToolStripMenuItem.Text = "Turn on autovalidation";
			// 
			// translationModeToolStripMenuItem
			// 
			this.translationModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.helpToolStripMenuItem,
									this.toolStripSeparator3,
									this.debugToolStripMenuItem,
									this.releaseToolStripMenuItem});
			this.translationModeToolStripMenuItem.Enabled = false;
			this.translationModeToolStripMenuItem.Name = "translationModeToolStripMenuItem";
			this.translationModeToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
			this.translationModeToolStripMenuItem.Text = "Translation mode";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.helpToolStripMenuItem.Text = "What is it?";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.debugToolStripMenuItem.Text = "Test";
			this.debugToolStripMenuItem.Click += new System.EventHandler(this.DebugToolStripMenuItemClick);
			// 
			// releaseToolStripMenuItem
			// 
			this.releaseToolStripMenuItem.Checked = true;
			this.releaseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
			this.releaseToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.releaseToolStripMenuItem.Text = "Release";
			this.releaseToolStripMenuItem.Click += new System.EventHandler(this.ReleaseToolStripMenuItemClick);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findReferencesToolStripMenuItem});
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// findReferencesToolStripMenuItem
			// 
			this.findReferencesToolStripMenuItem.Name = "findReferencesToolStripMenuItem";
			this.findReferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.findReferencesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.findReferencesToolStripMenuItem.Text = "Find references";
			this.findReferencesToolStripMenuItem.Click += new System.EventHandler(this.FindReferencesToolStripMenuItemClick);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.translatorInfoToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// translatorInfoToolStripMenuItem
			// 
			this.translatorInfoToolStripMenuItem.Name = "translatorInfoToolStripMenuItem";
			this.translatorInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.translatorInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.translatorInfoToolStripMenuItem.Text = "Translator info";
			this.translatorInfoToolStripMenuItem.Click += new System.EventHandler(this.TranslatorInfoToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem1
			// 
			this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.documentationToolStripMenuItem,
									this.visitHomepageToolStripMenuItem,
									this.toolStripSeparator4,
									this.supportRequestToolStripMenuItem,
									this.featureRequestToolStripMenuItem,
									this.reportABugToolStripMenuItem,
									this.toolStripSeparator5,
									this.makeADonationToolStripMenuItem});
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem1.Text = "Help";
			// 
			// documentationToolStripMenuItem
			// 
			this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
			this.documentationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.documentationToolStripMenuItem.Text = "Documentation";
			this.documentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItemClick);
			// 
			// visitHomepageToolStripMenuItem
			// 
			this.visitHomepageToolStripMenuItem.Name = "visitHomepageToolStripMenuItem";
			this.visitHomepageToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.visitHomepageToolStripMenuItem.Text = "Visit homepage";
			this.visitHomepageToolStripMenuItem.Click += new System.EventHandler(this.VisitHomepageToolStripMenuItemClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
			// 
			// supportRequestToolStripMenuItem
			// 
			this.supportRequestToolStripMenuItem.Name = "supportRequestToolStripMenuItem";
			this.supportRequestToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.supportRequestToolStripMenuItem.Text = "Support request";
			this.supportRequestToolStripMenuItem.Click += new System.EventHandler(this.SupportRequestToolStripMenuItemClick);
			// 
			// featureRequestToolStripMenuItem
			// 
			this.featureRequestToolStripMenuItem.Name = "featureRequestToolStripMenuItem";
			this.featureRequestToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.featureRequestToolStripMenuItem.Text = "Feature request";
			this.featureRequestToolStripMenuItem.Click += new System.EventHandler(this.FeatureRequestToolStripMenuItemClick);
			// 
			// reportABugToolStripMenuItem
			// 
			this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
			this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.reportABugToolStripMenuItem.Text = "Report a bug";
			this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.ReportABugToolStripMenuItemClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(150, 6);
			// 
			// makeADonationToolStripMenuItem
			// 
			this.makeADonationToolStripMenuItem.Name = "makeADonationToolStripMenuItem";
			this.makeADonationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.makeADonationToolStripMenuItem.Text = "Make a donation";
			this.makeADonationToolStripMenuItem.Click += new System.EventHandler(this.MakeADonationToolStripMenuItemClick);
			// 
			// Listlabel
			// 
			this.Listlabel.Location = new System.Drawing.Point(12, 36);
			this.Listlabel.Name = "Listlabel";
			this.Listlabel.Size = new System.Drawing.Size(100, 17);
			this.Listlabel.TabIndex = 1;
			this.Listlabel.Text = "List of items:";
			// 
			// itemslistBox
			// 
			this.itemslistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.itemslistBox.Enabled = false;
			this.itemslistBox.FormattingEnabled = true;
			this.itemslistBox.Location = new System.Drawing.Point(12, 56);
			this.itemslistBox.Name = "itemslistBox";
			this.itemslistBox.ScrollAlwaysVisible = true;
			this.itemslistBox.Size = new System.Drawing.Size(660, 173);
			this.itemslistBox.TabIndex = 2;
			this.itemslistBox.SelectedIndexChanged += new System.EventHandler(this.ItemslistBoxSelectedIndexChanged);
			this.itemslistBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ItemslistBoxKeyUp);
			// 
			// translategroupBox
			// 
			this.translategroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.translategroupBox.Controls.Add(this.Copybutton);
			this.translategroupBox.Controls.Add(this.translationtextBox);
			this.translategroupBox.Location = new System.Drawing.Point(12, 328);
			this.translategroupBox.Name = "translategroupBox";
			this.translategroupBox.Size = new System.Drawing.Size(660, 98);
			this.translategroupBox.TabIndex = 3;
			this.translategroupBox.TabStop = false;
			this.translategroupBox.Text = "Translation";
			// 
			// Copybutton
			// 
			this.Copybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Copybutton.BackColor = System.Drawing.Color.White;
			this.Copybutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Copybutton.BackgroundImage")));
			this.Copybutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Copybutton.Location = new System.Drawing.Point(619, 19);
			this.Copybutton.Name = "Copybutton";
			this.Copybutton.Size = new System.Drawing.Size(35, 37);
			this.Copybutton.TabIndex = 1;
			this.Copybutton.UseVisualStyleBackColor = false;
			this.Copybutton.Click += new System.EventHandler(this.CopybuttonClick);
			// 
			// translationtextBox
			// 
			this.translationtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.translationtextBox.Font = new System.Drawing.Font("Courier New", 11.25F);
			this.translationtextBox.Location = new System.Drawing.Point(6, 19);
			this.translationtextBox.Multiline = true;
			this.translationtextBox.Name = "translationtextBox";
			this.translationtextBox.Size = new System.Drawing.Size(607, 73);
			this.translationtextBox.TabIndex = 0;
			this.translationtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TranslationtextBoxKeyUp);
			// 
			// sourcegroupBox
			// 
			this.sourcegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.sourcegroupBox.Controls.Add(this.Namespacelabel);
			this.sourcegroupBox.Controls.Add(this.sourcetextBox);
			this.sourcegroupBox.Location = new System.Drawing.Point(12, 235);
			this.sourcegroupBox.Name = "sourcegroupBox";
			this.sourcegroupBox.Size = new System.Drawing.Size(660, 87);
			this.sourcegroupBox.TabIndex = 4;
			this.sourcegroupBox.TabStop = false;
			this.sourcegroupBox.Text = "Text to translate";
			// 
			// Namespacelabel
			// 
			this.Namespacelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Namespacelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.Namespacelabel.Location = new System.Drawing.Point(309, 13);
			this.Namespacelabel.Name = "Namespacelabel";
			this.Namespacelabel.Size = new System.Drawing.Size(345, 17);
			this.Namespacelabel.TabIndex = 1;
			this.Namespacelabel.Text = "<Namespace>";
			// 
			// sourcetextBox
			// 
			this.sourcetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.sourcetextBox.BackColor = System.Drawing.Color.Khaki;
			this.sourcetextBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sourcetextBox.Location = new System.Drawing.Point(6, 33);
			this.sourcetextBox.Multiline = true;
			this.sourcetextBox.Name = "sourcetextBox";
			this.sourcetextBox.ReadOnly = true;
			this.sourcetextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.sourcetextBox.Size = new System.Drawing.Size(648, 48);
			this.sourcetextBox.TabIndex = 0;
			this.sourcetextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SourcetextBoxKeyUp);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			this.openFileDialog.Filter = "Language file|*.Language";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "Language";
			this.saveFileDialog.Filter = "Language file|*.Language";
			// 
			// Infolabel
			// 
			this.Infolabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Infolabel.Location = new System.Drawing.Point(12, 434);
			this.Infolabel.Name = "Infolabel";
			this.Infolabel.Size = new System.Drawing.Size(660, 24);
			this.Infolabel.TabIndex = 5;
			this.Infolabel.Text = resources.GetString("Infolabel.Text");
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 467);
			this.Controls.Add(this.Infolabel);
			this.Controls.Add(this.sourcegroupBox);
			this.Controls.Add(this.translategroupBox);
			this.Controls.Add(this.itemslistBox);
			this.Controls.Add(this.Listlabel);
			this.Controls.Add(this.MainmenuStrip);
			this.MainMenuStrip = this.MainmenuStrip;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BUTranslate";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.MainmenuStrip.ResumeLayout(false);
			this.MainmenuStrip.PerformLayout();
			this.translategroupBox.ResumeLayout(false);
			this.translategroupBox.PerformLayout();
			this.sourcegroupBox.ResumeLayout(false);
			this.sourcegroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem findReferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
		private System.Windows.Forms.Button Copybutton;
		private System.Windows.Forms.ToolStripMenuItem makeADonationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem visitHomepageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem featureRequestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supportRequestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openTranslationURLToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem translationModeToolStripMenuItem;
		private System.Windows.Forms.Label Infolabel;
		private System.Windows.Forms.MenuStrip MainmenuStrip;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem prepareLetterForSendingToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Label Namespacelabel;
		private System.Windows.Forms.ToolStripMenuItem translatorInfoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.TextBox sourcetextBox;
		private System.Windows.Forms.GroupBox sourcegroupBox;
		private System.Windows.Forms.TextBox translationtextBox;
		private System.Windows.Forms.GroupBox translategroupBox;
		private System.Windows.Forms.ListBox itemslistBox;
		private System.Windows.Forms.Label Listlabel;
		private System.Windows.Forms.ToolStripMenuItem turnOnAutovalidationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem validationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem;
	}
}
