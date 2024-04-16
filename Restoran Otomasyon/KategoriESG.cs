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

namespace Restoran_Otomasyon.Paneller
{
	public partial class KategoriESG : Form
	{
		public KategoriESG()
		{
			InitializeComponent();
		}
		Kategori kat=new Kategori();
		Context db=new Context();
		int id;
		private void button1_Click(object sender, EventArgs e)
		{
			if (txtad.Text != "")
			{
				if (hiddenKategoriId.Text == "")
				{
					kat.Ad = txtad.Text;
					kat.Gorunurluk = true;
					db.Kategoriler.Add(kat);
					timer1.Start();
					MessageBox.Show("Yeni Rol Kayıt Edildi");
				}
				else
				{
					id = Convert.ToInt32(hiddenKategoriId.Text);
					var x = db.Roller.Find(id);
					x.Ad = txtad.Text;
					timer1.Start();
					MessageBox.Show("Rol Güncellendi");
				}
				db.SaveChanges();
				Temizle();
				Listele();
			}
			else
			{
				MessageBox.Show("Role Bir Ad Verdiğinizden Emin Olun", "Rol Eklenemiyor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void KategoriESG_Load(object sender, EventArgs e)
		{
			Listele();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridKategori);
			gridKategori.Columns["Id"].Visible = false;
		}
		void Temizle()
		{
			hiddenKategoriId.Text = "";
			txtad.Text = "";
		}

		void Listele()
		{
			var kategoriler = db.Kategoriler
						   .Where(r => r.Gorunurluk == true)
						   .Select(kategori => new
						   {
							   Id = kategori.Id,
							   Ad = kategori.Ad,
						   })
						   .ToList();
			gridKategori.DataSource = kategoriler;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int kategoriId = Convert.ToInt32(hiddenKategoriId.Text);
			int Urunler = db.Urunler.Count(k => k.KategorId == kategoriId);


			if (Urunler == 0)
			{
				DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (hiddenKategoriId.Text != "")
					{
						id = Convert.ToInt32(hiddenKategoriId.Text);
						var kategori = db.Kategoriler.Find(id);
						kategori.Gorunurluk = false;
						db.SaveChanges();
						timer1.Start();
						MessageBox.Show("Kayıt Silindi");
						Temizle();
						Listele();
					}
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show($"Silmek İstediğiniz Kategoriye  Ait {Urunler}  Adet Ürün Var", "İşlem Gerçekleştirilemez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void gridKategori_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			hiddenKategoriId.Text = gridKategori.CurrentRow.Cells["Id"].Value.ToString();
			txtad.Text = gridKategori.CurrentRow.Cells["Ad"].Value.ToString();
		}
	}
}
