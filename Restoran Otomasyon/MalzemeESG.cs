using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restoran_Otomasyon.Paneller
{
	public partial class MalzemeESG : Form
	{
		public MalzemeESG()
		{
			InitializeComponent();
		}
		Context db = new Context();
		Malzeme mal = new Malzeme();
		Stok stok = new Stok();
		private void TedarikciDoldur()
		{
			// Profesörleri veritabanından al ve combo box'a doldur
			var tedarikciAd = db.Tedarikciler.ToList();
			comboTedarik.DisplayMember = "Ad";
			comboTedarik.ValueMember = "Id";
			comboTedarik.DataSource = tedarikciAd;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupMalzeme))
			{
				if (hiddenMalzemeId.Text == "")
				{
					mal.Ad = txtad.Text;
					mal.Tur = comboOlcu.Text;
					mal.Gorunurluk = true;
					mal.Fiyat = Convert.ToDecimal(txtfiyat.Text);
					db.Malzemeler.Add(mal);
					db.SaveChanges();
					int maxMalId = db.Malzemeler.Max(m => m.Id);
					stok.MalzemeId = maxMalId;
					stok.Gorunurluk = true;
					stok.Miktar = 0;
					stok.MinStok = Convert.ToInt32(txtmin.Text);
					stok.MaxStok = Convert.ToInt32(txtmax.Text);
					stok.TedarikciId = (int)comboTedarik.SelectedValue;

					db.Stoklar.Add(stok);
					timer1.Start();
					MessageBox.Show("Yeni Malzeme Kayıt Edildi");
				}
				else
				{
					int id = Convert.ToInt32(hiddenMalzemeId.Text);
					var x = db.Malzemeler.Find(id);
					x.Ad = txtad.Text;
					x.Tur = comboOlcu.Text;
					x.Fiyat = Convert.ToDecimal(txtfiyat.Text);
					//Stok Idsine göre işlem yapacan unutma
					int stokId = Convert.ToInt32(hiddenStokId.Text);
					var t = db.Stoklar.Find(stokId);
					int maxMalId = db.Malzemeler.Max(m => m.Id);
					t.MalzemeId = maxMalId;
					t.Gorunurluk = true;
					t.Miktar = 0;
					t.MinStok = Convert.ToInt32(txtmin.Text);
					t.MaxStok = Convert.ToInt32(txtmax.Text);
					t.TedarikciId = (int)comboTedarik.SelectedValue;
					timer1.Start();
					MessageBox.Show("Malzeme Bilgisi Güncellendi");
				}
				db.SaveChanges();
				Yardimcilar.Temizle(groupMalzeme);
				MalzemeList();
			}
		}
		void MalzemeList()
		{
			var malzemeStokBilgileri = from malzeme in db.Malzemeler
									   join stok in db.Stoklar on malzeme.Id equals stok.MalzemeId
									   join tedarikci in db.Tedarikciler on stok.TedarikciId equals tedarikci.Id
									   where malzeme.Gorunurluk == true // İsteğe bağlı: Sadece görünür malzemeleri al
									   select new
									   {
										   MalzemeId = malzeme.Id,
										   MalzemeAd = malzeme.Ad,
										   MalzemeTur = malzeme.Tur,
										   MalzemeFiyat = malzeme.Fiyat,
										   StokMiktar = stok.Miktar,
										   StokMin = stok.MinStok,
										   StokMax = stok.MaxStok,
										   TedarikciAd = tedarikci.Ad,
										   TedarikciId = tedarikci.Id, // Tedarikçi ID'sini gösteriyoruz
										   StokId = stok.Id,
									   };



			gridMalzeme.DataSource = malzemeStokBilgileri.ToList();
			// DataGridView'da TedarikciId sütununu gizli hale getiriyoruz
			gridMalzeme.Columns["TedarikciId"].Visible = false;
			gridMalzeme.Columns["StokId"].Visible = false;
		}

		private void MalzemeESG_Load(object sender, EventArgs e)
		{
			MalzemeList();
			TedarikciDoldur();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridMalzeme);
		}

		private void gridMalzeme_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridMalzeme.Rows[e.RowIndex];
				hiddenMalzemeId.Text = row.Cells["MalzemeId"].Value.ToString();
				txtad.Text = row.Cells["MalzemeAd"].Value.ToString();
				comboOlcu.Text = row.Cells["MalzemeTur"].Value.ToString();
				txtfiyat.Text = row.Cells["MalzemeFiyat"].Value.ToString();
				txtstok.Text = row.Cells["StokMiktar"].Value.ToString();
				txtmin.Text = row.Cells["StokMin"].Value.ToString();
				txtmax.Text = row.Cells["StokMax"].Value.ToString();
				hiddenTedarikciId.Text = row.Cells["TedarikciId"].Value.ToString();
				hiddenStokId.Text = row.Cells["StokId"].Value.ToString();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Yardimcilar.Temizle(groupMalzeme);
		}
	}
}
