using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
		}

		private void timer2_Tick_1(object sender, EventArgs e)
		{

			timer1.Stop();
			timer2.Stop();
			this.Hide();
			Giris git = new Giris();
			git.ShowDialog();
		}
	}
}
