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
					mal.Tur = olcu;
					mal.Gorunurluk = true;
					mal.Fiyat = fiyatformatsiz;
					db.Malzemeler.Add(mal);
					db.SaveChanges();
					int maxMalId = db.Malzemeler.Max(m => m.Id);
					stok.MalzemeId = maxMalId;
					stok.Gorunurluk = true;
					stok.Miktar = 0;
					if (olcu != "Adet")
					{
						stok.MinStok = formatsizMin * 1000;
						stok.MaxStok = formatsizMax * 1000;
					}
					else
					{
						stok.MinStok = formatsizMin;
						stok.MaxStok = formatsizMax;
					}

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
					x.Fiyat = fiyatformatsiz;
					int stokId = Convert.ToInt32(hiddenStokId.Text);
					var t = db.Stoklar.Find(stokId);
					t.Gorunurluk = true;
					if (olcu != "Adet")
					{
						t.MinStok = formatsizMin * 1000;
						t.MaxStok = formatsizMax * 1000;
					}
					else
					{
						t.MinStok = formatsizMin;
						t.MaxStok = formatsizMax;
					}
					t.TedarikciId = (int)comboTedarik.SelectedValue;
					timer1.Start();
					MessageBox.Show("Malzeme Bilgisi Güncellendi");
				}
				db.SaveChanges();
				Yardimcilar.Temizle(groupMalzeme);
				MalzemeList();
				txtstok.Text = "0";
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Malzemeye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				olcu = comboOlcu.Text;
				hiddenTedarikciId.Text = row.Cells["TedarikciId"].Value.ToString();
				hiddenStokId.Text = row.Cells["StokId"].Value.ToString();
				int tedarikID = Convert.ToInt32(hiddenTedarikciId.Text);
				comboTedarik.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikID).Ad;


				string fiyat = row.Cells["MalzemeFiyat"].Value.ToString();
				fiyatformatsiz = Decimal.Parse(fiyat);
				txtfiyat.Text = Yardimcilar.FormatliDeger(fiyat);

				string stok = row.Cells["StokMiktar"].Value.ToString();
				formatsizStok = Convert.ToDecimal(stok)/1000;
				txtstok.Text = Yardimcilar.BirimFormatı(formatsizStok, olcu);


				string minstok = row.Cells["StokMin"].Value.ToString();
				formatsizMin = Convert.ToDecimal(minstok) / 1000;
				txtmin.Text = Yardimcilar.BirimFormatı(formatsizMin, olcu);

				string maxstok = row.Cells["StokMax"].Value.ToString();
				formatsizMax = Convert.ToDecimal(maxstok) / 1000;
				txtmax.Text = Yardimcilar.BirimFormatı(formatsizMax, olcu);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Yardimcilar.Temizle(groupMalzeme);
		}

		private void gridMalzeme_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.GridFormat(gridMalzeme, "MalzemeFiyat", e);
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMiktar", e);
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMin", e);
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMax", e);
		}
		decimal fiyatformatsiz;
		private void txtfiyat_Leave(object sender, EventArgs e)
		{
			fiyatformatsiz = Convert.ToDecimal(txtfiyat.Text);
			txtfiyat.Text = Yardimcilar.FormatliDeger(txtfiyat.Text);
		}
		decimal formatsizMin;
		decimal formatsizMax;
		decimal formatsizStok;
		private void txtmin_Leave(object sender, EventArgs e)
		{
			formatsizMin = Yardimcilar.TemizleVeDondur(txtmin,olcu);
			txtmin.Text = Yardimcilar.BirimFormatı(formatsizMin, olcu);
		}
		string olcu;
		private void comboOlcu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboOlcu.SelectedIndex == 0)
			{
				olcu = "Kg";
			}
			else if (comboOlcu.SelectedIndex == 1)
			{
				olcu = "Litre";
			}
			else
			{
				olcu = "Adet";
			}
		}

		private void txtmax_Leave(object sender, EventArgs e)
		{
			formatsizMax = Yardimcilar.TemizleVeDondur(txtmax, olcu);
			txtmax.Text = Yardimcilar.BirimFormatı(formatsizMax, olcu);
		}

		private void txtstok_Leave(object sender, EventArgs e)
		{
			formatsizStok = Yardimcilar.TemizleVeDondur(txtstok, olcu);
			txtstok.Text = Yardimcilar.BirimFormatı(formatsizStok, olcu);
		}
	}
}
