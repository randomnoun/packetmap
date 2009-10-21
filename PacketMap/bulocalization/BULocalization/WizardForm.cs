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
	/// Description of WizardForm.
	/// </summary>
	public partial class WizardForm : Form
	{
		int steppos = 0;
		int laststep = 0;
		string[] hlp;
		
		public WizardForm(string[] help)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			steppos = 0;
			hlp = help;
			laststep = hlp.Length - 1;
			
			Helplabel.Text = hlp[steppos];
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void NextbuttonClick(object sender, EventArgs e)
		{
			if (steppos < laststep)
			{
				steppos++;
				Helplabel.Text = hlp[steppos];
				Previousbutton.Enabled = true;
			}
			if (steppos >= laststep) Nextbutton.Enabled = false;
		}
		
		void PreviousbuttonClick(object sender, EventArgs e)
		{
			if (steppos > 0)
			{
				steppos--;
				Helplabel.Text = hlp[steppos];
				Nextbutton.Enabled = true;
			}
			if (steppos <= 0) Previousbutton.Enabled = false;
		}
	}
}
