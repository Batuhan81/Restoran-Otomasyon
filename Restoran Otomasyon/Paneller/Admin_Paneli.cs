using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon.Paneller
{
	public partial class Admin_Paneli : Form
	{
		public Admin_Paneli()
		{
			InitializeComponent();
		}

		private void çalışanEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CalisanESG git = new CalisanESG();
			git.Show();
		}

		private void çalışanRolEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RolESG git=new RolESG();
			git.Show();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{

		}

		private void tedarikçiEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TedarikciESG git=new TedarikciESG();
			git.Show();
		}

		private void stokGirdisiEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StokGirdiESG git=new StokGirdiESG();
			git.Show();
		}

		private void malzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MalzemeESG git=new MalzemeESG();
			git.Show();
		}

		private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KategoriESG git=new KategoriESG();	
			git.Show();
		}

		private void ürünOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UrunESG git = new UrunESG();
			git.Show();
		}
	}
}
