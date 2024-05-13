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
		public KategoriESG(int Deger)
		{
			InitializeComponent();
			//Burada bir değer almasını sağliyim örn 1 gelirse ürün sayfasında görünmesi gereken 0 da genel
			deger = Deger;
		}
		int deger;
		Kategori kat = new Kategori();
		Context db = new Context();
		int id;
		private void button1_Click(object sender, EventArgs e)
		{
			if (txtad.Text != "")
			{
				if (hiddenKategoriId.Text == "")//Kategori Ekle
				{
					var EslesenAd = db.Kategoriler.FirstOrDefault(o => o.Ad == txtad.Text && o.Gorunurluk == true);
					if (EslesenAd == null)
					{
						kat.Ad = txtad.Text;
						kat.Gorunurluk = true;
						kat.Tur = comboTur.Text;
						db.Kategoriler.Add(kat);
						timer1.Start();
						MessageBox.Show("Yeni Kategori Kayıt Edildi");
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Personel Telefon Numarsası Daha Önceden Kullanılmış !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else//Kategori Güncelle
				{
					id = Convert.ToInt32(hiddenKategoriId.Text);
					var x = db.Kategoriler.Find(id);
					x.Ad = txtad.Text;
					x.Tur = comboTur.Text;
					timer1.Start();
					MessageBox.Show("Kategori Bilgisi Güncellendi");
				}
				db.SaveChanges();
				Temizle();
				Listele();
				// Rol ekledikten sonra ComboRol'ü güncelle
				UrunESG calisanForm = Application.OpenForms.OfType<UrunESG>().FirstOrDefault();
				if (calisanForm != null)
				{
					calisanForm.kategoriler();
				}
				MenuESG calisanForm2 = Application.OpenForms.OfType<MenuESG>().FirstOrDefault();
				if (calisanForm2 != null)
				{
					calisanForm2.menukategoriler();
				}
				MasaESG calisanForm3 = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
				if (calisanForm3 != null)
				{
					calisanForm3.MasaKategoriler();
				}
			}
			else
			{
				MessageBox.Show("Kategoriye Bir Ad Verdiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)//Mboxları otomatik kapatma
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void KategoriESG_Load(object sender, EventArgs e)
		{
			if (deger == 0)//0 olduğunda tüm bilgiler yer alacak
			{
				Tur = "";//Bu sayede null olacak ve filtreye girmeyecek
				comboTur.Items.Clear();
				comboTur.Items.Add("Masa");
				comboTur.Items.Add("Ürün");
				comboTur.Items.Add("Menü");
			}
			if (deger == 1)//Burada sadece Masa
			{
				Tur = "Masa";
				comboTur.Items.Clear();
				comboTur.Items.Add("Masa");
				comboTur.SelectedIndex = 0;
			}
			if (deger == 2)//Sadece Ürün
			{
				Tur = "Ürün";
				comboTur.Items.Clear();
				comboTur.Items.Add("Ürün");
				comboTur.SelectedIndex = 0;
			}
			if (deger == 3)//sadece Menü
			{
				Tur = "Menü";
				comboTur.Items.Clear();
				comboTur.Items.Add("Menü");
				comboTur.SelectedIndex = 0;
			}
			Listele();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridKategori);//grid renklendirme
			gridKategori.Columns["Id"].Visible = false;//Id sütununu sakla
		}

		void Temizle()
		{
			hiddenKategoriId.Text = "";
			txtad.Text = "";
		}
		string Tur;
		void Listele()
		{
			IQueryable<Kategori> query = db.Kategoriler.OrderByDescending(o => o.Id);

			if (!string.IsNullOrEmpty(Tur))
			{
				query = query.Where(o => o.Tur == Tur);
			}
			var kategoriler = query
						   .Where(r => r.Gorunurluk == true)
						   .Select(kategori => new
						   {
							   Id = kategori.Id,
							   Ad = kategori.Ad,
							   Tür = kategori.Tur,
						   })
						   .ToList();
			gridKategori.DataSource = kategoriler;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int kategoriId = Convert.ToInt32(hiddenKategoriId.Text);
			int Urunler = db.Urunler.Count(k => k.KategorId == kategoriId);//bu kategoriye sahip ürün sayısı
			if (Urunler == 0)//kategoriye sahip ürün yoksa sil var sa ürün sayısını belirterek silme işlemini engelle
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
			comboTur.Text = gridKategori.CurrentRow.Cells["Tür"].Value.ToString();
		}

		private void ComboFiltre_SelectedIndexChanged(object sender, EventArgs e)
		{
			string TurAd = ComboFiltre.Text;

			if (TurAd == "Tümü")
			{
				Listele();
			}
			else
			{
				var kategoriler = db.Kategoriler
						   .Where(r => r.Gorunurluk == true && r.Tur == TurAd)
						   .Select(kategori => new
						   {
							   Id = kategori.Id,
							   Ad = kategori.Ad,
							   Tür = kategori.Tur,
						   })
						   .ToList();
				gridKategori.DataSource = kategoriler;
			}
		}
	}
}
