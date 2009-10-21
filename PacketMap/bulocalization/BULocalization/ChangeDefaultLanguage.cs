/*
 * (c)Cuchuk Sergey Alexandrovich, 2007
 * Cuchuk.Sergey@gmail.com
 * toCuchukSergey@yandex.ru
 * 
 * Developed in #Develop IDE
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using BUtil.Localization;

namespace BULocalization
{
	/// <summary>
	/// Description of ChangeDefaultLanguage.
	/// </summary>
	public partial class ChangeDefaultLanguage : Form
	{
		BUTranslation buTranslation;
		BUTranslation.Item CurrentID;
		string path;
		SearchForm sf = new SearchForm();
			
		public ChangeDefaultLanguage(string Path)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			SearchForm.srchDelegate = OnSearch;
			
			path = Path;
			if (path.Length == 0) throw new Exception("Empty path transmitted!!!");
			
			CurrentID.id = -1;
			buTranslation = new BUTranslation();
		}
		
		string OnSearch(string pattern)
		{
			string rezIDs = "";
			for (int i = 0; i < buTranslation.Count(); i++)
				if (buTranslation.GetItem(i).Source.Contains(pattern))
				{
					rezIDs += buTranslation.GetItem(i).id.ToString() + "; ";
				}
			return rezIDs;
		}
		
		void ChangeDefaultLanguageLoad(object sender, EventArgs e)
		{
			
			try
			{
				buTranslation.LoadFromFile(path + "default.Language");
			}
			catch(Exception ee)
			{
				MessageBox.Show("Could not load default translation from file due to:\n" + ee.Message + "\n\nIf you are creating new translation - do not pay attention to this message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			for (int i = 0; i < buTranslation.Count(); i++)
			{
				CurrentID = buTranslation.GetItem(i);
				ItemslistBox.Items.Add(CurrentID.id + "  " + CurrentID.Source);
			}
			string[] ns = buTranslation.GetNameSpaces();
			
			for (int i = 0; i < ns.Length; i++)
			{
				NamespaceslistBox.Items.Add(ns[i]);
			}	
			
			WhereTosendtextBox.Text = buTranslation.eMail;
			WWWtextBox.Text = buTranslation.eWWW;
			UpdateAfterChangingNamespaces();
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			this.Close();
			
		}
		
		void Save()
		{
			buTranslation.eMail = WhereTosendtextBox.Text;
			buTranslation.eWWW = WWWtextBox.Text;
			buTranslation.SaveToFile(path + "default.Language");
		}
		
		void NewItem()
		{
			if (buTranslation.NamespacesCount == 0)
			{
				MessageBox.Show("At first please add namespaces on Namespaces tab", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			CurrentID.id = buTranslation.GetNewID();
			CurrentID.Source = "";
			CurrentID.State = "1";
			CurrentID.Source = "";
			CurrentID.Translation = "";
			
			buTranslation.AddNewItem(CurrentID);
			ItemslistBox.Items.Add(CurrentID.id + "  " + CurrentID.Source);
			
			ItemslistBox.SelectedIndex = ItemslistBox.Items.Count - 1;
			SourcetextBox.Select();
			
			// auto past text from buffer feature
			if (AutoPastAndSetcheckBox.Checked)
			{
				SourcetextBox.Text = "";
				SourcetextBox.Paste();
				ItemSet();
			}
		}
		
		void ItemslistBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (ItemslistBox.SelectedIndex == -1)
			{
				IDtextBox.Text = "";
				return;
			}
			
			CurrentID = buTranslation.GetItem(ItemslistBox.SelectedIndex);
			IDtextBox.Text = CurrentID.id.ToString();
			string[] sometext = new string[1];
			string source = CurrentID.Source;
			if (source.Length > 1)
			{
				int count = 1;
				for (int i = 0; i < source.Length - 1; i++)
				{
					if ((source[i] == '\\') && (source[i + 1] == 'n'))
						count++;
				}
				sometext = new string[count];
				
				for (int i = 0; i < count - 1; i++)
				{
					sometext[i] = source.Substring(0, source.IndexOf("\\n"));
					source = source.Remove(0, source.IndexOf("\\n") + 2);
				}				
				sometext[count - 1] = source;
			}
			else
			{
				sometext[0] = source;
			}
			
			SourcetextBox.Lines = sometext;
			if (CurrentID.N_ID == -1) 
			{
				NamespacecomboBox.Text = BUTranslation.DefaultNamespaceName;
				return;
			}
			
			int pos = NamespacecomboBox.Items.IndexOf(buTranslation.GetNamespaceByN_ID(CurrentID.N_ID));
			if (pos < 0)
			{
				NamespacecomboBox.Text = BUTranslation.DefaultNamespaceName;
			}
			else
			{
				NamespacecomboBox.SelectedIndex = pos;
				NamespacecomboBox.Invalidate();
			}
			
		}
		
		void ItemSet()
		{
			if (IDtextBox.Text.Length != 0)
			{
				int count = SourcetextBox.Lines.Length;
				
				
				if (count <= 1) CurrentID.Source = SourcetextBox.Text;
				else
				{
					CurrentID.Source = "";
					for (int i = 0; i < count - 1; i++) CurrentID.Source += SourcetextBox.Lines[i] + "\\n";
					CurrentID.Source += SourcetextBox.Lines[count - 1];
				}
				
				if ((NamespacecomboBox.Items.Count == 0) || (NamespacecomboBox.SelectedIndex < 0))
					CurrentID.N_ID = -1;
				else
					CurrentID.N_ID = buTranslation.GetN_IDByName( (string)NamespacecomboBox.SelectedItem);
				
				buTranslation.UpdateItem(CurrentID, ItemslistBox.SelectedIndex);
				ItemslistBox.Items[ItemslistBox.SelectedIndex] = CurrentID.id + "  " + CurrentID.Source;
				
			}
			
		}
		
		void DeleteItem()
		{
			if (IDtextBox.Text.Length != 0)
			{
				if (MessageBox.Show("Are you sure you want delete this item?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					buTranslation.DeleteItem(ItemslistBox.SelectedIndex);
					ItemslistBox.Items.Remove(ItemslistBox.Items[ItemslistBox.SelectedIndex]);
					IDtextBox.Text = "";
				}
			}

		}
		
		void SavebuttonClick(object sender, EventArgs e)
		{
			try
			{
				Save();
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		
		void NewbuttonClick(object sender, EventArgs e)
		{
			try
			{
				buTranslation.AddNamespace(NewNStextBox.Text);
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			NamespaceslistBox.Items.Add(NewNStextBox.Text);
			UpdateAfterChangingNamespaces();
		}
		
		void RenamebuttonClick(object sender, EventArgs e)
		{
			if ((NamespaceslistBox.Items.Count < 1) || (NamespaceslistBox.SelectedIndex < 0)) return;
			
			try
			{
				buTranslation.RenameNamespace(NamespacetextBox.Text, NewNametextBox.Text);
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			NamespaceslistBox.Items[NamespaceslistBox.SelectedIndex] = NewNametextBox.Text;
			UpdateAfterChangingNamespaces();
		}
		
		void DeleteButtonClick(object sender, EventArgs e)
		{
			if ((NamespaceslistBox.Items.Count < 1) || (NamespaceslistBox.SelectedIndex < 0)) return;
			if (MessageBox.Show("Are you sure you want delete this namespace?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
			
			try
			{
				buTranslation.DeleteNamespace((string)NamespaceslistBox.Items[NamespaceslistBox.SelectedIndex]);
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			NamespaceslistBox.Items.Remove(NamespaceslistBox.Items[NamespaceslistBox.SelectedIndex]);
			UpdateAfterChangingNamespaces();
		}
		
		void UpdateAfterChangingNamespaces()
		{
			IDtextBox.Text = "";
			SourcetextBox.Text = "";
			
			NamespacecomboBox.Items.Clear();
			
			
			for (int i = 0; i < NamespaceslistBox.Items.Count; i++)
			{
				NamespacecomboBox.Items.Add(NamespaceslistBox.Items[i]);
			}
			
			NamespacecomboBox.Text = BUTranslation.DefaultNamespaceName;
			
			
		
		}
		
		void NamespaceslistBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if ((NamespaceslistBox.Items.Count < 1) || (NamespaceslistBox.SelectedIndex < 0)) 
			{
				NamespacetextBox.Text = "<Type a namespace name here>";
				
			}
			else 
				NamespacetextBox.Text = (string)NamespaceslistBox.Items[NamespaceslistBox.SelectedIndex];
			
			NamespacetextBox.Select();
		}
		
		void NamespacecomboBoxTextChanged(object sender, EventArgs e)
		{
			//NamespacecomboBox.Text = BUTranslation.DefaultNamespaceName;
		}
		
		void ChangeDefaultLanguageFormClosing(object sender, FormClosingEventArgs e)
		{
			switch (MessageBox.Show("Would you like to save default localization?", "Exiting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					try
					{
						Save();
					}
					catch(Exception ee)
					{
						MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						e.Cancel = true;
						return;
					}
					
					sf.AllowClose = true;
					sf.Close();
					
					DialogResult = DialogResult.OK;
					
					break;
				case DialogResult.No:
					sf.AllowClose = true;
					sf.Close();
					
					DialogResult = DialogResult.Cancel;
					break;
					
				default: 
					e.Cancel = true;
					break;
					
			}
		}
		
		void CopyToClipboard()
		{
			SourcetextBox.SelectAll();
			SourcetextBox.Copy();
			SourcetextBox.Select(0,0);
		}
		
		void SettoolStripButtonClick(object sender, EventArgs e)
		{
			ItemSet();
		}
		
		void NewtoolStripButtonClick(object sender, EventArgs e)
		{
			NewItem();
		}
		
		void CopytoolStripButtonClick(object sender, EventArgs e)
		{
			CopyToClipboard();
		}
		
		void RemovetoolStripButtonClick(object sender, EventArgs e)
		{
			DeleteItem();
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			sf.Show();
		}
	}
}
