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

namespace BULocalization
{
	/// <summary>
	/// Description of SearchForm.
	/// </summary>
	public partial class SearchForm : Form
	{
		public delegate string  Search(string Pattern);
		
		public static Search srchDelegate = null;
		public bool AllowClose = false;
		
		public SearchForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void SearchbuttonClick(object sender, EventArgs e)
		{
			RezultstextBox.Text = "";
			
			if (SearchtextBox.Text.Length == 0) return;
			if (srchDelegate == null) return;
			
			RezultstextBox.Text = srchDelegate(SearchtextBox.Text);
			
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			Hide();
		}
		
		void SearchFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !AllowClose;
			Hide();
		}
	}
}
