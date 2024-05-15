using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
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
	public partial class MasaOzellikleri : Form
	{
		public MasaOzellikleri(int masaID, int kullaniciID)
		{
			InitializeComponent();
			masaId = masaID;
			kullaniciId = kullaniciID;
			if(kullaniciId != 1)
			{
				this.Size = new Size(300, 300);
			}
		}
		int masaId;
		int kullaniciId;
		Context db = new Context();
		private void MasaOzellikleri_Load(object sender, EventArgs e)
		{
			var masaAd = db.Masalar.FirstOrDefault(o => o.Id == masaId)?.Kod;
			label1.Text = masaAd + " Nolu Masanın Özellikleri";

			OzellikleriGetir();
		}

		private void OzellikleriGetir()
		{
			OzellikList.Items.Clear();
			var masaOzellikler = db.MasaOzellikler.Where(o => o.MasaId == masaId && o.Gorunurluk==true).Select(o => o.Ozellik.Ad).ToList();
			foreach (var ozellik in masaOzellikler)
			{
				OzellikList.Items.Add(ozellik);
			}

			if (kullaniciId == 1)
			{
				var tumOzellikler = db.Ozellikler.Where(o => o.Gorunurluk == true).ToList();

				// OzellikList'te zaten bulunan özelliklerin adlarını alalım
				var ozellikListeAdlar = OzellikList.Items.Cast<string>().ToList();

				// OzellikList'te bulunmayan özellikleri MasaOzellik'e ekleyelim
				var eklenecekOzellikler = tumOzellikler.Where(o => !ozellikListeAdlar.Contains(o.Ad)).ToList();

				// MasaOzellik'e özellik adlarını ekleyelim
				MasaOzellik.DataSource = eklenecekOzellikler.Select(o => o.Ad).ToList();

				MasaOzellik.Visible = true;
				btnKaydet.Visible = true;
				label2.Visible = true;
				
			}
		}

		private void btnKaydet_Click(object sender, EventArgs e)
		{
			// MasaOzellik.CheckedItems öğelerini kopyalayalım
			var Eklenecekler = new List<object>();
			foreach (var item in MasaOzellik.CheckedItems)
			{
				Eklenecekler.Add(item);
			}

			var silinecekler = new List<object>();
			foreach (var item in OzellikList.CheckedItems)
			{
				silinecekler.Add(item);
			}
			// Seçilen özelliklerin görünürlüğünü kapat
			foreach (var checkedItem in silinecekler)
			{
				// Seçilen özelliğin adını alalım
				string selectedOzellikAd = checkedItem.ToString();

				// Eğer seçilen özellik listede varsa, görünürlüğünü kapat
				if (OzellikList.Items.Contains(selectedOzellikAd))
				{
					// Özellik görünürlüğünü kapat
					var selectedOzellikId = db.Ozellikler.FirstOrDefault(o => o.Ad == selectedOzellikAd)?.Id;
					if (selectedOzellikId != null)
					{
						var masaOzellik = db.MasaOzellikler.Where(m => m.MasaId == masaId && m.OzellikId == selectedOzellikId).ToList();
						if (masaOzellik != null)
						{
							foreach (var item in masaOzellik)
							{
								item.Gorunurluk = false;
							}
							db.SaveChanges();
						}
					}
				}
			}

			foreach (var checkedItem in Eklenecekler)
			{
				// Seçilen özelliğin adını alalım
				string selectedOzellikAd = checkedItem.ToString();

				// Seçilen özelliğin daha önce eklenip eklenmediğini kontrol edelim
				var existingMasaOzellik = db.MasaOzellikler.FirstOrDefault(mo => mo.Ozellik.Ad == selectedOzellikAd && mo.MasaId == masaId);
				if (existingMasaOzellik == null)
				{
					// Seçilen özelliğin Id'sini bulalım
					var selectedOzellik = db.Ozellikler.FirstOrDefault(o => o.Ad == selectedOzellikAd);
					if (selectedOzellik != null)
					{
						// MasaÖzellik tablosuna yeni bir kayıt ekleyelim
						MasaOzellik yeniMasaOzellik = new MasaOzellik
						{
							OzellikId = selectedOzellik.Id,
							MasaId = masaId, // Masa ID'sini değişkenden alalım
							Gorunurluk = true // Varsayılan olarak özelliği görünür yapalım
						};

						// Yeni masa özelliğini veritabanına ekleyelim
						db.MasaOzellikler.Add(yeniMasaOzellik);
						db.SaveChanges();

						// Özellik listesine ekleyelim
						OzellikList.Items.Add(selectedOzellikAd);
					}
				}
				else
				{
					// Mevcut kaydın görünürlüğünü kontrol edelim
					if (!existingMasaOzellik.Gorunurluk)
					{
						// Görünürlüğü kapalıysa, görünürlüğünü açalım
						existingMasaOzellik.Gorunurluk = true;
						db.SaveChanges();
					}
					else
					{
						MessageBox.Show($"{selectedOzellikAd} özelliği zaten masaya eklenmiş!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}

			OzellikleriGetir();
			MasaOzellik.ClearSelected();
			OzellikList.ClearSelected();

		}
	}
}
