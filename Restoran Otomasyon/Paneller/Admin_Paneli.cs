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

		private void CalisanCRUD_Click(object sender, EventArgs e)
		{
			CalisanESG git = new CalisanESG();
			git.Show();
		}

		private void CalisanRol_Click(object sender, EventArgs e)
		{
			RolESG git = new RolESG();
			git.Show();
		}

		private void TedarikciCRUD_Click(object sender, EventArgs e)
		{
			TedarikciESG git = new TedarikciESG();
			git.Show();
		}

		private void MalzemeCRUD_Click(object sender, EventArgs e)
		{
			MalzemeESG git = new MalzemeESG();
			git.Show();
		}

		private void StokGİrdiCRUD_Click(object sender, EventArgs e)
		{
			StokGirdiESG git = new StokGirdiESG();
			git.Show();
		}

		private void UrunCRUD_Click(object sender, EventArgs e)
		{
			UrunESG git = new UrunESG();
			git.Show();
		}

		private void kategoriEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KategoriESG git = new KategoriESG();
			git.Show();
		}

		private void menüEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MenuESG git=new MenuESG();
			git.Show();
		}

		private void stokSayımToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StokSayim git= new StokSayim();
			git.Show();
		}
	}
}
