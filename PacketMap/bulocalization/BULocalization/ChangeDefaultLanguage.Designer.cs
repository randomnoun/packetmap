/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */
namespace BULocalization
{
	partial class ChangeDefaultLanguage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDefaultLanguage));
			this.ItemslistBox = new System.Windows.Forms.ListBox();
			this.TranslationgroupBox = new System.Windows.Forms.GroupBox();
			this.TextOptionsgroupBox = new System.Windows.Forms.GroupBox();
			this.idlabel = new System.Windows.Forms.Label();
			this.IDtextBox = new System.Windows.Forms.TextBox();
			this.Namespacelabel = new System.Windows.Forms.Label();
			this.NamespacecomboBox = new System.Windows.Forms.ComboBox();
			this.MaintoolStrip = new System.Windows.Forms.ToolStrip();
			this.NewtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.CopytoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.SettoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RemovetoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.SrchtoolStripButton = new System.Windows.Forms.ToolStripButton();
			this.AutoPastAndSetcheckBox = new System.Windows.Forms.CheckBox();
			this.SourcetextBox = new System.Windows.Forms.TextBox();
			this.Savebutton = new System.Windows.Forms.Button();
			this.Closebutton = new System.Windows.Forms.Button();
			this.NamespaceslistBox = new System.Windows.Forms.ListBox();
			this.Namespaceslabel = new System.Windows.Forms.Label();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.NamespacetextBox = new System.Windows.Forms.TextBox();
			this.Newbutton = new System.Windows.Forms.Button();
			this.NamespacegroupBox = new System.Windows.Forms.GroupBox();
			this.AddnamespacegroupBox = new System.Windows.Forms.GroupBox();
			this.Newlabel = new System.Windows.Forms.Label();
			this.NewNStextBox = new System.Windows.Forms.TextBox();
			this.NamespaceRenamegroupBox = new System.Windows.Forms.GroupBox();
			this.NewNametextBox = new System.Windows.Forms.TextBox();
			this.NewNamelabel = new System.Windows.Forms.Label();
			this.OldNamelabel = new System.Windows.Forms.Label();
			this.Renamebutton = new System.Windows.Forms.Button();
			this.WhereTosendlabel = new System.Windows.Forms.Label();
			this.WhereTosendtextBox = new System.Windows.Forms.TextBox();
			this.wwwlabel = new System.Windows.Forms.Label();
			this.WWWtextBox = new System.Windows.Forms.TextBox();
			this.downlabel = new System.Windows.Forms.Label();
			this.MaintabControl = new System.Windows.Forms.TabControl();
			this.ItemstabPage = new System.Windows.Forms.TabPage();
			this.NamespacestabPage = new System.Windows.Forms.TabPage();
			this.OptionstabPage = new System.Windows.Forms.TabPage();
			this.Helplabel = new System.Windows.Forms.Label();
			this.TranslationgroupBox.SuspendLayout();
			this.TextOptionsgroupBox.SuspendLayout();
			this.MaintoolStrip.SuspendLayout();
			this.NamespacegroupBox.SuspendLayout();
			this.AddnamespacegroupBox.SuspendLayout();
			this.NamespaceRenamegroupBox.SuspendLayout();
			this.MaintabControl.SuspendLayout();
			this.ItemstabPage.SuspendLayout();
			this.NamespacestabPage.SuspendLayout();
			this.OptionstabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// ItemslistBox
			// 
			this.ItemslistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemslistBox.BackColor = System.Drawing.Color.Linen;
			this.ItemslistBox.FormattingEnabled = true;
			this.ItemslistBox.Location = new System.Drawing.Point(6, 6);
			this.ItemslistBox.Name = "ItemslistBox";
			this.ItemslistBox.ScrollAlwaysVisible = true;
			this.ItemslistBox.Size = new System.Drawing.Size(619, 121);
			this.ItemslistBox.TabIndex = 0;
			this.ItemslistBox.SelectedIndexChanged += new System.EventHandler(this.ItemslistBoxSelectedIndexChanged);
			// 
			// TranslationgroupBox
			// 
			this.TranslationgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TranslationgroupBox.Controls.Add(this.TextOptionsgroupBox);
			this.TranslationgroupBox.Controls.Add(this.MaintoolStrip);
			this.TranslationgroupBox.Controls.Add(this.AutoPastAndSetcheckBox);
			this.TranslationgroupBox.Controls.Add(this.SourcetextBox);
			this.TranslationgroupBox.Location = new System.Drawing.Point(6, 137);
			this.TranslationgroupBox.Name = "TranslationgroupBox";
			this.TranslationgroupBox.Size = new System.Drawing.Size(619, 202);
			this.TranslationgroupBox.TabIndex = 2;
			this.TranslationgroupBox.TabStop = false;
			this.TranslationgroupBox.Text = "Source text";
			// 
			// TextOptionsgroupBox
			// 
			this.TextOptionsgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TextOptionsgroupBox.Controls.Add(this.idlabel);
			this.TextOptionsgroupBox.Controls.Add(this.IDtextBox);
			this.TextOptionsgroupBox.Controls.Add(this.Namespacelabel);
			this.TextOptionsgroupBox.Controls.Add(this.NamespacecomboBox);
			this.TextOptionsgroupBox.Location = new System.Drawing.Point(448, 66);
			this.TextOptionsgroupBox.Name = "TextOptionsgroupBox";
			this.TextOptionsgroupBox.Size = new System.Drawing.Size(165, 100);
			this.TextOptionsgroupBox.TabIndex = 12;
			this.TextOptionsgroupBox.TabStop = false;
			this.TextOptionsgroupBox.Text = "Options";
			// 
			// idlabel
			// 
			this.idlabel.Location = new System.Drawing.Point(10, 25);
			this.idlabel.Name = "idlabel";
			this.idlabel.Size = new System.Drawing.Size(41, 16);
			this.idlabel.TabIndex = 2;
			this.idlabel.Text = "ID:";
			// 
			// IDtextBox
			// 
			this.IDtextBox.Location = new System.Drawing.Point(102, 22);
			this.IDtextBox.Name = "IDtextBox";
			this.IDtextBox.ReadOnly = true;
			this.IDtextBox.Size = new System.Drawing.Size(57, 20);
			this.IDtextBox.TabIndex = 3;
			// 
			// Namespacelabel
			// 
			this.Namespacelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Namespacelabel.Location = new System.Drawing.Point(10, 45);
			this.Namespacelabel.Name = "Namespacelabel";
			this.Namespacelabel.Size = new System.Drawing.Size(100, 18);
			this.Namespacelabel.TabIndex = 7;
			this.Namespacelabel.Text = "Namespace:";
			// 
			// NamespacecomboBox
			// 
			this.NamespacecomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NamespacecomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.NamespacecomboBox.FormattingEnabled = true;
			this.NamespacecomboBox.Location = new System.Drawing.Point(6, 69);
			this.NamespacecomboBox.Name = "NamespacecomboBox";
			this.NamespacecomboBox.Size = new System.Drawing.Size(153, 21);
			this.NamespacecomboBox.TabIndex = 8;
			this.NamespacecomboBox.TextChanged += new System.EventHandler(this.NamespacecomboBoxTextChanged);
			// 
			// MaintoolStrip
			// 
			this.MaintoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.NewtoolStripButton,
									this.toolStripSeparator2,
									this.CopytoolStripButton,
									this.toolStripSeparator3,
									this.SettoolStripButton,
									this.toolStripSeparator1,
									this.RemovetoolStripButton,
									this.SrchtoolStripButton});
			this.MaintoolStrip.Location = new System.Drawing.Point(3, 16);
			this.MaintoolStrip.Name = "MaintoolStrip";
			this.MaintoolStrip.Size = new System.Drawing.Size(613, 47);
			this.MaintoolStrip.TabIndex = 11;
			this.MaintoolStrip.Text = "TexttoolStrip";
			// 
			// NewtoolStripButton
			// 
			this.NewtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.NewtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewtoolStripButton.Image")));
			this.NewtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.NewtoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.NewtoolStripButton.Name = "NewtoolStripButton";
			this.NewtoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.NewtoolStripButton.Text = "New...";
			this.NewtoolStripButton.Click += new System.EventHandler(this.NewtoolStripButtonClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
			// 
			// CopytoolStripButton
			// 
			this.CopytoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.CopytoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CopytoolStripButton.Image")));
			this.CopytoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.CopytoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.CopytoolStripButton.Name = "CopytoolStripButton";
			this.CopytoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.CopytoolStripButton.Text = "Copy source to clipboard";
			this.CopytoolStripButton.Click += new System.EventHandler(this.CopytoolStripButtonClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
			// 
			// SettoolStripButton
			// 
			this.SettoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.SettoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SettoolStripButton.Image")));
			this.SettoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.SettoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.SettoolStripButton.Name = "SettoolStripButton";
			this.SettoolStripButton.Size = new System.Drawing.Size(23, 44);
			this.SettoolStripButton.Text = "Set";
			this.SettoolStripButton.Click += new System.EventHandler(this.SettoolStripButtonClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
			// 
			// RemovetoolStripButton
			// 
			this.RemovetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.RemovetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RemovetoolStripButton.Image")));
			this.RemovetoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.RemovetoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.RemovetoolStripButton.Name = "RemovetoolStripButton";
			this.RemovetoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.RemovetoolStripButton.Text = "Remove";
			this.RemovetoolStripButton.Click += new System.EventHandler(this.RemovetoolStripButtonClick);
			// 
			// SrchtoolStripButton
			// 
			this.SrchtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.SrchtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SrchtoolStripButton.Image")));
			this.SrchtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.SrchtoolStripButton.ImageTransparentColor = System.Drawing.Color.White;
			this.SrchtoolStripButton.Name = "SrchtoolStripButton";
			this.SrchtoolStripButton.Size = new System.Drawing.Size(44, 44);
			this.SrchtoolStripButton.Text = "Search";
			this.SrchtoolStripButton.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// AutoPastAndSetcheckBox
			// 
			this.AutoPastAndSetcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.AutoPastAndSetcheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AutoPastAndSetcheckBox.Location = new System.Drawing.Point(3, 172);
			this.AutoPastAndSetcheckBox.Name = "AutoPastAndSetcheckBox";
			this.AutoPastAndSetcheckBox.Size = new System.Drawing.Size(601, 24);
			this.AutoPastAndSetcheckBox.TabIndex = 9;
			this.AutoPastAndSetcheckBox.Text = "Past text from buffer into SOURCE field, press button SET automatically after pre" +
			"ssing NEW button";
			this.AutoPastAndSetcheckBox.UseVisualStyleBackColor = true;
			// 
			// SourcetextBox
			// 
			this.SourcetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.SourcetextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SourcetextBox.Location = new System.Drawing.Point(6, 67);
			this.SourcetextBox.Multiline = true;
			this.SourcetextBox.Name = "SourcetextBox";
			this.SourcetextBox.Size = new System.Drawing.Size(436, 99);
			this.SourcetextBox.TabIndex = 1;
			// 
			// Savebutton
			// 
			this.Savebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Savebutton.Location = new System.Drawing.Point(533, 412);
			this.Savebutton.Name = "Savebutton";
			this.Savebutton.Size = new System.Drawing.Size(118, 36);
			this.Savebutton.TabIndex = 4;
			this.Savebutton.Text = "Save";
			this.Savebutton.UseVisualStyleBackColor = true;
			this.Savebutton.Click += new System.EventHandler(this.SavebuttonClick);
			// 
			// Closebutton
			// 
			this.Closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Closebutton.Location = new System.Drawing.Point(395, 412);
			this.Closebutton.Name = "Closebutton";
			this.Closebutton.Size = new System.Drawing.Size(132, 36);
			this.Closebutton.TabIndex = 5;
			this.Closebutton.Text = "Close";
			this.Closebutton.UseVisualStyleBackColor = true;
			this.Closebutton.Click += new System.EventHandler(this.ClosebuttonClick);
			// 
			// NamespaceslistBox
			// 
			this.NamespaceslistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.NamespaceslistBox.FormattingEnabled = true;
			this.NamespaceslistBox.Location = new System.Drawing.Point(6, 35);
			this.NamespaceslistBox.Name = "NamespaceslistBox";
			this.NamespaceslistBox.ScrollAlwaysVisible = true;
			this.NamespaceslistBox.Size = new System.Drawing.Size(304, 290);
			this.NamespaceslistBox.TabIndex = 6;
			this.NamespaceslistBox.SelectedIndexChanged += new System.EventHandler(this.NamespaceslistBoxSelectedIndexChanged);
			// 
			// Namespaceslabel
			// 
			this.Namespaceslabel.Location = new System.Drawing.Point(96, 16);
			this.Namespaceslabel.Name = "Namespaceslabel";
			this.Namespaceslabel.Size = new System.Drawing.Size(169, 16);
			this.Namespaceslabel.TabIndex = 7;
			this.Namespaceslabel.Text = "Translation namespaces:";
			// 
			// DeleteButton
			// 
			this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteButton.BackColor = System.Drawing.Color.White;
			this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
			this.DeleteButton.Location = new System.Drawing.Point(316, 35);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(106, 30);
			this.DeleteButton.TabIndex = 8;
			this.DeleteButton.Text = "Remove";
			this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.DeleteButton.UseVisualStyleBackColor = false;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
			// 
			// NamespacetextBox
			// 
			this.NamespacetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.NamespacetextBox.Location = new System.Drawing.Point(6, 42);
			this.NamespacetextBox.Name = "NamespacetextBox";
			this.NamespacetextBox.ReadOnly = true;
			this.NamespacetextBox.Size = new System.Drawing.Size(285, 20);
			this.NamespacetextBox.TabIndex = 9;
			// 
			// Newbutton
			// 
			this.Newbutton.Image = ((System.Drawing.Image)(resources.GetObject("Newbutton.Image")));
			this.Newbutton.Location = new System.Drawing.Point(176, 65);
			this.Newbutton.Name = "Newbutton";
			this.Newbutton.Size = new System.Drawing.Size(115, 24);
			this.Newbutton.TabIndex = 10;
			this.Newbutton.Text = "Create";
			this.Newbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.Newbutton.UseVisualStyleBackColor = true;
			this.Newbutton.Click += new System.EventHandler(this.NewbuttonClick);
			// 
			// NamespacegroupBox
			// 
			this.NamespacegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.NamespacegroupBox.Controls.Add(this.AddnamespacegroupBox);
			this.NamespacegroupBox.Controls.Add(this.NamespaceRenamegroupBox);
			this.NamespacegroupBox.Controls.Add(this.NamespaceslistBox);
			this.NamespacegroupBox.Controls.Add(this.Namespaceslabel);
			this.NamespacegroupBox.Controls.Add(this.DeleteButton);
			this.NamespacegroupBox.Location = new System.Drawing.Point(6, 6);
			this.NamespacegroupBox.Name = "NamespacegroupBox";
			this.NamespacegroupBox.Size = new System.Drawing.Size(619, 333);
			this.NamespacegroupBox.TabIndex = 11;
			this.NamespacegroupBox.TabStop = false;
			this.NamespacegroupBox.Text = "Namespaces";
			// 
			// AddnamespacegroupBox
			// 
			this.AddnamespacegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AddnamespacegroupBox.Controls.Add(this.Newlabel);
			this.AddnamespacegroupBox.Controls.Add(this.NewNStextBox);
			this.AddnamespacegroupBox.Controls.Add(this.Newbutton);
			this.AddnamespacegroupBox.Location = new System.Drawing.Point(316, 229);
			this.AddnamespacegroupBox.Name = "AddnamespacegroupBox";
			this.AddnamespacegroupBox.Size = new System.Drawing.Size(297, 96);
			this.AddnamespacegroupBox.TabIndex = 13;
			this.AddnamespacegroupBox.TabStop = false;
			this.AddnamespacegroupBox.Text = "Add new namespace";
			// 
			// Newlabel
			// 
			this.Newlabel.Location = new System.Drawing.Point(6, 24);
			this.Newlabel.Name = "Newlabel";
			this.Newlabel.Size = new System.Drawing.Size(100, 12);
			this.Newlabel.TabIndex = 12;
			this.Newlabel.Text = "Name:";
			// 
			// NewNStextBox
			// 
			this.NewNStextBox.Location = new System.Drawing.Point(6, 39);
			this.NewNStextBox.Name = "NewNStextBox";
			this.NewNStextBox.Size = new System.Drawing.Size(285, 20);
			this.NewNStextBox.TabIndex = 11;
			// 
			// NamespaceRenamegroupBox
			// 
			this.NamespaceRenamegroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NamespaceRenamegroupBox.Controls.Add(this.NewNametextBox);
			this.NamespaceRenamegroupBox.Controls.Add(this.NewNamelabel);
			this.NamespaceRenamegroupBox.Controls.Add(this.OldNamelabel);
			this.NamespaceRenamegroupBox.Controls.Add(this.NamespacetextBox);
			this.NamespaceRenamegroupBox.Controls.Add(this.Renamebutton);
			this.NamespaceRenamegroupBox.Location = new System.Drawing.Point(316, 71);
			this.NamespaceRenamegroupBox.Name = "NamespaceRenamegroupBox";
			this.NamespaceRenamegroupBox.Size = new System.Drawing.Size(297, 152);
			this.NamespaceRenamegroupBox.TabIndex = 12;
			this.NamespaceRenamegroupBox.TabStop = false;
			this.NamespaceRenamegroupBox.Text = "Rename current namespace";
			// 
			// NewNametextBox
			// 
			this.NewNametextBox.Location = new System.Drawing.Point(6, 92);
			this.NewNametextBox.Name = "NewNametextBox";
			this.NewNametextBox.Size = new System.Drawing.Size(285, 20);
			this.NewNametextBox.TabIndex = 14;
			// 
			// NewNamelabel
			// 
			this.NewNamelabel.Location = new System.Drawing.Point(6, 74);
			this.NewNamelabel.Name = "NewNamelabel";
			this.NewNamelabel.Size = new System.Drawing.Size(285, 15);
			this.NewNamelabel.TabIndex = 13;
			this.NewNamelabel.Text = "New name:";
			// 
			// OldNamelabel
			// 
			this.OldNamelabel.Location = new System.Drawing.Point(6, 24);
			this.OldNamelabel.Name = "OldNamelabel";
			this.OldNamelabel.Size = new System.Drawing.Size(285, 15);
			this.OldNamelabel.TabIndex = 12;
			this.OldNamelabel.Text = "Old name:";
			// 
			// Renamebutton
			// 
			this.Renamebutton.Location = new System.Drawing.Point(176, 124);
			this.Renamebutton.Name = "Renamebutton";
			this.Renamebutton.Size = new System.Drawing.Size(115, 22);
			this.Renamebutton.TabIndex = 11;
			this.Renamebutton.Text = "Rename";
			this.Renamebutton.UseVisualStyleBackColor = true;
			this.Renamebutton.Click += new System.EventHandler(this.RenamebuttonClick);
			// 
			// WhereTosendlabel
			// 
			this.WhereTosendlabel.Location = new System.Drawing.Point(15, 23);
			this.WhereTosendlabel.Name = "WhereTosendlabel";
			this.WhereTosendlabel.Size = new System.Drawing.Size(101, 18);
			this.WhereTosendlabel.TabIndex = 12;
			this.WhereTosendlabel.Text = "E-mail*:";
			// 
			// WhereTosendtextBox
			// 
			this.WhereTosendtextBox.Location = new System.Drawing.Point(122, 20);
			this.WhereTosendtextBox.Name = "WhereTosendtextBox";
			this.WhereTosendtextBox.Size = new System.Drawing.Size(337, 20);
			this.WhereTosendtextBox.TabIndex = 13;
			// 
			// wwwlabel
			// 
			this.wwwlabel.Location = new System.Drawing.Point(15, 49);
			this.wwwlabel.Name = "wwwlabel";
			this.wwwlabel.Size = new System.Drawing.Size(101, 16);
			this.wwwlabel.TabIndex = 14;
			this.wwwlabel.Text = "Site*:";
			// 
			// WWWtextBox
			// 
			this.WWWtextBox.Location = new System.Drawing.Point(122, 46);
			this.WWWtextBox.Name = "WWWtextBox";
			this.WWWtextBox.Size = new System.Drawing.Size(337, 20);
			this.WWWtextBox.TabIndex = 15;
			// 
			// downlabel
			// 
			this.downlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.downlabel.Enabled = false;
			this.downlabel.Location = new System.Drawing.Point(0, 383);
			this.downlabel.Name = "downlabel";
			this.downlabel.Size = new System.Drawing.Size(666, 23);
			this.downlabel.TabIndex = 16;
			this.downlabel.Text = resources.GetString("downlabel.Text");
			// 
			// MaintabControl
			// 
			this.MaintabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.MaintabControl.Controls.Add(this.ItemstabPage);
			this.MaintabControl.Controls.Add(this.NamespacestabPage);
			this.MaintabControl.Controls.Add(this.OptionstabPage);
			this.MaintabControl.Location = new System.Drawing.Point(12, 12);
			this.MaintabControl.Name = "MaintabControl";
			this.MaintabControl.SelectedIndex = 0;
			this.MaintabControl.Size = new System.Drawing.Size(639, 371);
			this.MaintabControl.TabIndex = 17;
			// 
			// ItemstabPage
			// 
			this.ItemstabPage.Controls.Add(this.ItemslistBox);
			this.ItemstabPage.Controls.Add(this.TranslationgroupBox);
			this.ItemstabPage.Location = new System.Drawing.Point(4, 22);
			this.ItemstabPage.Name = "ItemstabPage";
			this.ItemstabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ItemstabPage.Size = new System.Drawing.Size(631, 345);
			this.ItemstabPage.TabIndex = 0;
			this.ItemstabPage.Text = "Items";
			this.ItemstabPage.UseVisualStyleBackColor = true;
			// 
			// NamespacestabPage
			// 
			this.NamespacestabPage.Controls.Add(this.NamespacegroupBox);
			this.NamespacestabPage.Location = new System.Drawing.Point(4, 22);
			this.NamespacestabPage.Name = "NamespacestabPage";
			this.NamespacestabPage.Padding = new System.Windows.Forms.Padding(3);
			this.NamespacestabPage.Size = new System.Drawing.Size(631, 345);
			this.NamespacestabPage.TabIndex = 1;
			this.NamespacestabPage.Text = "Namespaces";
			this.NamespacestabPage.UseVisualStyleBackColor = true;
			// 
			// OptionstabPage
			// 
			this.OptionstabPage.Controls.Add(this.Helplabel);
			this.OptionstabPage.Controls.Add(this.WWWtextBox);
			this.OptionstabPage.Controls.Add(this.WhereTosendlabel);
			this.OptionstabPage.Controls.Add(this.WhereTosendtextBox);
			this.OptionstabPage.Controls.Add(this.wwwlabel);
			this.OptionstabPage.Location = new System.Drawing.Point(4, 22);
			this.OptionstabPage.Name = "OptionstabPage";
			this.OptionstabPage.Size = new System.Drawing.Size(631, 345);
			this.OptionstabPage.TabIndex = 2;
			this.OptionstabPage.Text = "Options";
			this.OptionstabPage.UseVisualStyleBackColor = true;
			// 
			// Helplabel
			// 
			this.Helplabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Helplabel.Location = new System.Drawing.Point(15, 76);
			this.Helplabel.Name = "Helplabel";
			this.Helplabel.Size = new System.Drawing.Size(562, 55);
			this.Helplabel.TabIndex = 16;
			this.Helplabel.Text = resources.GetString("Helplabel.Text");
			// 
			// ChangeDefaultLanguage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(663, 460);
			this.Controls.Add(this.MaintabControl);
			this.Controls.Add(this.downlabel);
			this.Controls.Add(this.Closebutton);
			this.Controls.Add(this.Savebutton);
			this.MinimumSize = new System.Drawing.Size(671, 494);
			this.Name = "ChangeDefaultLanguage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change default language";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeDefaultLanguageFormClosing);
			this.Load += new System.EventHandler(this.ChangeDefaultLanguageLoad);
			this.TranslationgroupBox.ResumeLayout(false);
			this.TranslationgroupBox.PerformLayout();
			this.TextOptionsgroupBox.ResumeLayout(false);
			this.TextOptionsgroupBox.PerformLayout();
			this.MaintoolStrip.ResumeLayout(false);
			this.MaintoolStrip.PerformLayout();
			this.NamespacegroupBox.ResumeLayout(false);
			this.AddnamespacegroupBox.ResumeLayout(false);
			this.AddnamespacegroupBox.PerformLayout();
			this.NamespaceRenamegroupBox.ResumeLayout(false);
			this.NamespaceRenamegroupBox.PerformLayout();
			this.MaintabControl.ResumeLayout(false);
			this.ItemstabPage.ResumeLayout(false);
			this.NamespacestabPage.ResumeLayout(false);
			this.OptionstabPage.ResumeLayout(false);
			this.OptionstabPage.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton SrchtoolStripButton;
		private System.Windows.Forms.ToolStrip MaintoolStrip;
		private System.Windows.Forms.GroupBox TextOptionsgroupBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton RemovetoolStripButton;
		private System.Windows.Forms.ToolStripButton SettoolStripButton;
		private System.Windows.Forms.ToolStripButton CopytoolStripButton;
		private System.Windows.Forms.ToolStripButton NewtoolStripButton;
		private System.Windows.Forms.CheckBox AutoPastAndSetcheckBox;
		private System.Windows.Forms.Label Helplabel;
		private System.Windows.Forms.Label OldNamelabel;
		private System.Windows.Forms.Label NewNamelabel;
		private System.Windows.Forms.TextBox NewNametextBox;
		private System.Windows.Forms.GroupBox NamespaceRenamegroupBox;
		private System.Windows.Forms.TextBox NewNStextBox;
		private System.Windows.Forms.Label Newlabel;
		private System.Windows.Forms.GroupBox AddnamespacegroupBox;
		private System.Windows.Forms.TabPage OptionstabPage;
		private System.Windows.Forms.TabPage NamespacestabPage;
		private System.Windows.Forms.TabPage ItemstabPage;
		private System.Windows.Forms.TabControl MaintabControl;
		private System.Windows.Forms.Label downlabel;
		private System.Windows.Forms.TextBox WWWtextBox;
		private System.Windows.Forms.Label wwwlabel;
		private System.Windows.Forms.TextBox WhereTosendtextBox;
		private System.Windows.Forms.Label WhereTosendlabel;
		private System.Windows.Forms.ComboBox NamespacecomboBox;
		private System.Windows.Forms.Label Namespacelabel;
		private System.Windows.Forms.Button Renamebutton;
		private System.Windows.Forms.GroupBox NamespacegroupBox;
		private System.Windows.Forms.Button Newbutton;
		private System.Windows.Forms.TextBox NamespacetextBox;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Label Namespaceslabel;
		private System.Windows.Forms.ListBox NamespaceslistBox;
		private System.Windows.Forms.ListBox ItemslistBox;
		private System.Windows.Forms.TextBox SourcetextBox;
		private System.Windows.Forms.Label idlabel;
		private System.Windows.Forms.TextBox IDtextBox;
		private System.Windows.Forms.Button Closebutton;
		private System.Windows.Forms.Button Savebutton;
		private System.Windows.Forms.GroupBox TranslationgroupBox;
	}
}
