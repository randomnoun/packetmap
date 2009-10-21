/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BULocalization
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.localeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.currentTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.updateAllTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wizardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.openWeblinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.supportRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.featureRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.makeADonationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.MaintoolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.TranslationtoolStrip = new System.Windows.Forms.ToolStrip();
			this.UpdateSimpleLanguagetoolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.UpdateDefaulttoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.UpgradetoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.LetterSendtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.AddNewtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.DeltoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ModifytoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.LangdataGridView = new System.Windows.Forms.DataGridView();
			this.NaturalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LanguageSpecific = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip.SuspendLayout();
			this.MaintoolStripContainer.TopToolStripPanel.SuspendLayout();
			this.MaintoolStripContainer.SuspendLayout();
			this.TranslationtoolStrip.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LangdataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.localeFileToolStripMenuItem,
									this.languageToolStripMenuItem,
									this.modifyToolStripMenuItem1,
									this.optionsToolStripMenuItem,
									this.wizardsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(571, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// localeFileToolStripMenuItem
			// 
			this.localeFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.saveAsToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.loadToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.localeFileToolStripMenuItem.Name = "localeFileToolStripMenuItem";
			this.localeFileToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
			this.localeFileToolStripMenuItem.Text = "Locale file project";
			this.localeFileToolStripMenuItem.Click += new System.EventHandler(this.LocaleFileToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadLangdataGridViewoolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addToolStripMenuItem,
									this.modifyToolStripMenuItem,
									this.removeToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
			this.languageToolStripMenuItem.Text = "Language description";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
			this.addToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.addToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.addToolStripMenuItem.Text = "Add...";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
			// 
			// modifyToolStripMenuItem
			// 
			this.modifyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modifyToolStripMenuItem.Image")));
			this.modifyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			this.modifyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.modifyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.modifyToolStripMenuItem.Text = "Modify...";
			this.modifyToolStripMenuItem.Click += new System.EventHandler(this.ModifyToolStripMenuItemClick);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
			this.removeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItemClick);
			// 
			// modifyToolStripMenuItem1
			// 
			this.modifyToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.defaultTranslationToolStripMenuItem,
									this.toolStripSeparator2,
									this.currentTranslationToolStripMenuItem,
									this.toolStripSeparator3,
									this.updateAllTranslationsToolStripMenuItem,
									this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem});
			this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(105, 20);
			this.modifyToolStripMenuItem1.Text = "Modify translation";
			// 
			// defaultTranslationToolStripMenuItem
			// 
			this.defaultTranslationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("defaultTranslationToolStripMenuItem.Image")));
			this.defaultTranslationToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.defaultTranslationToolStripMenuItem.Name = "defaultTranslationToolStripMenuItem";
			this.defaultTranslationToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.defaultTranslationToolStripMenuItem.Text = "Default translation";
			this.defaultTranslationToolStripMenuItem.Click += new System.EventHandler(this.DefaultTranslationToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(283, 6);
			// 
			// currentTranslationToolStripMenuItem
			// 
			this.currentTranslationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentTranslationToolStripMenuItem.Image")));
			this.currentTranslationToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.currentTranslationToolStripMenuItem.Name = "currentTranslationToolStripMenuItem";
			this.currentTranslationToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.currentTranslationToolStripMenuItem.Text = "Current translation";
			this.currentTranslationToolStripMenuItem.Click += new System.EventHandler(this.CurrentTranslationToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(283, 6);
			// 
			// updateAllTranslationsToolStripMenuItem
			// 
			this.updateAllTranslationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateAllTranslationsToolStripMenuItem.Image")));
			this.updateAllTranslationsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
			this.updateAllTranslationsToolStripMenuItem.Name = "updateAllTranslationsToolStripMenuItem";
			this.updateAllTranslationsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.updateAllTranslationsToolStripMenuItem.Text = "Update all translations";
			this.updateAllTranslationsToolStripMenuItem.Click += new System.EventHandler(this.UpdateAllTranslationsToolStripMenuItemClick);
			// 
			// askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem
			// 
			this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem.Name = "askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem";
			this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
			this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem.Text = "Ask translators to upgrade their translations";
			this.askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem.Click += new System.EventHandler(this.AskTranslatorsToUpgradeTheirTranslationsToolStripMenuItemClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.emailToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// emailToolStripMenuItem
			// 
			this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
			this.emailToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.emailToolStripMenuItem.Text = "E-mail";
			this.emailToolStripMenuItem.Click += new System.EventHandler(this.EmailToolStripMenuItemClick);
			// 
			// wizardsToolStripMenuItem
			// 
			this.wizardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newProjectToolStripMenuItem});
			this.wizardsToolStripMenuItem.Name = "wizardsToolStripMenuItem";
			this.wizardsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.wizardsToolStripMenuItem.Text = "Wizards";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.newProjectToolStripMenuItem.Text = "New project";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem,
									this.documentationToolStripMenuItem,
									this.toolStripSeparator6,
									this.openWeblinkToolStripMenuItem,
									this.toolStripSeparator4,
									this.supportRequestToolStripMenuItem,
									this.featureRequestToolStripMenuItem,
									this.reportABugToolStripMenuItem,
									this.toolStripSeparator5,
									this.makeADonationToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// documentationToolStripMenuItem
			// 
			this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
			this.documentationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.documentationToolStripMenuItem.Text = "Documentation";
			this.documentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItemClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(150, 6);
			// 
			// openWeblinkToolStripMenuItem
			// 
			this.openWeblinkToolStripMenuItem.Name = "openWeblinkToolStripMenuItem";
			this.openWeblinkToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.openWeblinkToolStripMenuItem.Text = "Visit homepage";
			this.openWeblinkToolStripMenuItem.Click += new System.EventHandler(this.OpenWeblinkToolStripMenuItemClick);
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
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "xml files|*.xml";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "xml files|*.xml";
			// 
			// MaintoolStripContainer
			// 
			this.MaintoolStripContainer.BottomToolStripPanelVisible = false;
			// 
			// MaintoolStripContainer.ContentPanel
			// 
			this.MaintoolStripContainer.ContentPanel.Size = new System.Drawing.Size(571, 5);
			this.MaintoolStripContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.MaintoolStripContainer.LeftToolStripPanelVisible = false;
			this.MaintoolStripContainer.Location = new System.Drawing.Point(0, 24);
			this.MaintoolStripContainer.Margin = new System.Windows.Forms.Padding(0);
			this.MaintoolStripContainer.Name = "MaintoolStripContainer";
			this.MaintoolStripContainer.RightToolStripPanelVisible = false;
			this.MaintoolStripContainer.Size = new System.Drawing.Size(571, 58);
			this.MaintoolStripContainer.TabIndex = 12;
			this.MaintoolStripContainer.Text = "toolStripContainer1";
			// 
			// MaintoolStripContainer.TopToolStripPanel
			// 
			this.MaintoolStripContainer.TopToolStripPanel.Controls.Add(this.TranslationtoolStrip);
			this.MaintoolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.MaintoolStripContainer.TopToolStripPanel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MaintoolStripContainer.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 55);
			this.MaintoolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			// 
			// TranslationtoolStrip
			// 
			this.TranslationtoolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.TranslationtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.UpdateSimpleLanguagetoolStripButton1,
									this.UpdateDefaulttoolStripButton,
									this.UpgradetoolStripButton,
									this.LetterSendtoolStripButton});
			this.TranslationtoolStrip.Location = new System.Drawing.Point(3, 0);
			this.TranslationtoolStrip.Name = "TranslationtoolStrip";
			this.TranslationtoolStrip.Size = new System.Drawing.Size(265, 53);
			this.TranslationtoolStrip.TabIndex = 11;
			this.TranslationtoolStrip.Text = "Translation tools";
			// 
			// UpdateSimpleLanguagetoolStripButton1
			// 
			this.UpdateSimpleLanguagetoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.UpdateSimpleLanguagetoolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("UpdateSimpleLanguagetoolStripButton1.Image")));
			this.UpdateSimpleLanguagetoolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.UpdateSimpleLanguagetoolStripButton1.ImageTransparentColor = System.Drawing.Color.White;
			this.UpdateSimpleLanguagetoolStripButton1.Name = "UpdateSimpleLanguagetoolStripButton1";
			this.UpdateSimpleLanguagetoolStripButton1.Size = new System.Drawing.Size(53, 50);
			this.UpdateSimpleLanguagetoolStripButton1.Text = "Update selected language translation";
			this.UpdateSimpleLanguagetoolStripButton1.Click += new System.EventHandler(this.UpdateSimpleLanguagetoolStripButton1Click);
			// 
			// UpdateDefaulttoolStripButton
			// 
			this.UpdateDefaulttoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.UpdateDefaulttoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateDefaulttoolStripButton.Image")));
			this.UpdateDefaulttoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.UpdateDefaulttoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.UpdateDefaulttoolStripButton.Name = "UpdateDefaulttoolStripButton";
			this.UpdateDefaulttoolStripButton.Size = new System.Drawing.Size(53, 50);
			this.UpdateDefaulttoolStripButton.Text = "Update default(template) sources for other languages";
			this.UpdateDefaulttoolStripButton.Click += new System.EventHandler(this.UpdateDefaulttoolStripButtonClick);
			// 
			// UpgradetoolStripButton
			// 
			this.UpgradetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.UpgradetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UpgradetoolStripButton.Image")));
			this.UpgradetoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.UpgradetoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.UpgradetoolStripButton.Name = "UpgradetoolStripButton";
			this.UpgradetoolStripButton.Size = new System.Drawing.Size(53, 50);
			this.UpgradetoolStripButton.Text = "Upgrade all translations on \"default\" translation base";
			this.UpgradetoolStripButton.Click += new System.EventHandler(this.UpgradetoolStripButtonClick);
			// 
			// LetterSendtoolStripButton
			// 
			this.LetterSendtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.LetterSendtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("LetterSendtoolStripButton.Image")));
			this.LetterSendtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.LetterSendtoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.LetterSendtoolStripButton.Name = "LetterSendtoolStripButton";
			this.LetterSendtoolStripButton.Size = new System.Drawing.Size(94, 50);
			this.LetterSendtoolStripButton.Text = "Send letters to translators: ask them to upgrade their translations";
			this.LetterSendtoolStripButton.Click += new System.EventHandler(this.LetterSendtoolStripButtonClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.AddNewtoolStripButton,
									this.DeltoolStripButton,
									this.ModifytoolStripButton});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(281, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(144, 47);
			this.toolStrip1.TabIndex = 12;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// AddNewtoolStripButton
			// 
			this.AddNewtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.AddNewtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewtoolStripButton.Image")));
			this.AddNewtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.AddNewtoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.AddNewtoolStripButton.Name = "AddNewtoolStripButton";
			this.AddNewtoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.AddNewtoolStripButton.Text = "Adds new language";
			this.AddNewtoolStripButton.Click += new System.EventHandler(this.AddNewtoolStripButtonClick);
			// 
			// DeltoolStripButton
			// 
			this.DeltoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.DeltoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeltoolStripButton.Image")));
			this.DeltoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.DeltoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.DeltoolStripButton.Name = "DeltoolStripButton";
			this.DeltoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.DeltoolStripButton.Text = "Deletes selected language";
			this.DeltoolStripButton.Click += new System.EventHandler(this.DeltoolStripButtonClick);
			// 
			// ModifytoolStripButton
			// 
			this.ModifytoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ModifytoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ModifytoolStripButton.Image")));
			this.ModifytoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.ModifytoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.ModifytoolStripButton.Name = "ModifytoolStripButton";
			this.ModifytoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.ModifytoolStripButton.Text = "Modify descriptions of selected item";
			this.ModifytoolStripButton.Click += new System.EventHandler(this.ModifytoolStripButtonClick);
			// 
			// LangdataGridView
			// 
			this.LangdataGridView.AllowUserToAddRows = false;
			this.LangdataGridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			this.LangdataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.LangdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.LangdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.LangdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.NaturalName,
									this.LanguageSpecific});
			this.LangdataGridView.Location = new System.Drawing.Point(12, 85);
			this.LangdataGridView.MultiSelect = false;
			this.LangdataGridView.Name = "LangdataGridView";
			this.LangdataGridView.ReadOnly = true;
			this.LangdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.LangdataGridView.Size = new System.Drawing.Size(547, 326);
			this.LangdataGridView.TabIndex = 13;
			this.LangdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LangdataGridViewCellContentClick);
			// 
			// NaturalName
			// 
			this.NaturalName.HeaderText = "Natural";
			this.NaturalName.Name = "NaturalName";
			this.NaturalName.ReadOnly = true;
			this.NaturalName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.NaturalName.Width = 250;
			// 
			// LanguageSpecific
			// 
			this.LanguageSpecific.HeaderText = "Language specific name";
			this.LanguageSpecific.Name = "LanguageSpecific";
			this.LanguageSpecific.ReadOnly = true;
			this.LanguageSpecific.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.LanguageSpecific.Width = 250;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 423);
			this.Controls.Add(this.LangdataGridView);
			this.Controls.Add(this.MaintoolStripContainer);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(579, 457);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BULocalization";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.MaintoolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.MaintoolStripContainer.TopToolStripPanel.PerformLayout();
			this.MaintoolStripContainer.ResumeLayout(false);
			this.MaintoolStripContainer.PerformLayout();
			this.TranslationtoolStrip.ResumeLayout(false);
			this.TranslationtoolStrip.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LangdataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wizardsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem askTranslatorsToUpgradeTheirTranslationsToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn LanguageSpecific;
		private System.Windows.Forms.DataGridViewTextBoxColumn NaturalName;
		private System.Windows.Forms.DataGridView LangdataGridView;
		private System.Windows.Forms.ToolStripButton UpdateSimpleLanguagetoolStripButton1;
		private System.Windows.Forms.ToolStripButton UpdateDefaulttoolStripButton;
		private System.Windows.Forms.ToolStripButton ModifytoolStripButton;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer MaintoolStripContainer;
		private System.Windows.Forms.ToolStripButton DeltoolStripButton;
		private System.Windows.Forms.ToolStripButton AddNewtoolStripButton;
		private System.Windows.Forms.ToolStrip TranslationtoolStrip;
		private System.Windows.Forms.ToolStripButton LetterSendtoolStripButton;
		private System.Windows.Forms.ToolStripButton UpgradetoolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem makeADonationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem featureRequestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supportRequestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openWeblinkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem updateAllTranslationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentTranslationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultTranslationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem localeFileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip;
		
		

		

	}
}
