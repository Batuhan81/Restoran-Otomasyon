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
using System.Windows.Documents;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public partial class DoluMasa : Form
	{
		public DoluMasa(int masaID,int kullaniciID)
		{
			InitializeComponent();
			masaId = masaID;
			kullaniciId=kullaniciID;
		}
		int masaId;
		Context db = new Context();
		int sonSiparisId;
		int urunID;
		int MenuID;
		int kullaniciId;
		decimal masatutari;
		decimal masaOdenen;
		decimal geriyekalanUcret;
		decimal Odenecek;
		decimal ToplamTutar;
		decimal OdenenTutar;
		int kisisayisi;
		decimal kisibasiUcret;
		decimal enYakinUcret;
		Odeme odeme = new Odeme();

		void masaBilgileri()
		{
			var masa = db.MasaSiparisler.Where(s => s.MasaId == masaId)
									 .OrderByDescending(s => s.Id)
									 .FirstOrDefault();
			if(masa != null)
			{
				masatutari = masa.Tutar;
				masaOdenen = masa.OdenenTutar;
				geriyekalanUcret = masatutari - masaOdenen;
				txtkalan.Text = geriyekalanUcret.ToString();
			}
		}

		private void MasaSiparisi()
		{
			var sonSiparis = db.MasaSiparisler.OrderByDescending(o => o.Id).FirstOrDefault(o => o.MasaId == masaId);
			if (sonSiparis != null)
			{
				sonSiparisId = sonSiparis.SiparisId;
			}
		}

		private void UrunleriGoster(int kategoriId)
		{
			// Siparişte gelen ürünleri al
			var siparisUrunler = db.SiparisUrunler.Where(s => s.SiparisId == sonSiparisId).Select(s => s.UrunId);
			var siparisMenuler = db.SiparisMenus.Where(s => s.SiparisId == sonSiparisId).Select(s => s.MenuId);

			// Tüm ürünleri göster
			var urunler = db.Urunler.Where(o => o.Gorunurluk && o.Akitf && siparisUrunler.Contains(o.Id)).ToList();
			var menuler = db.Menuler.Where(o => o.Gorunurluk && o.Akitf && siparisMenuler.Contains(o.Id)).ToList();

			int groupBoxHeight = 400; // GroupBox yüksekliği
			int groupBoxWidth = 300;  // GroupBox genişliği

			int pictureBoxWidth = 200; // PictureBox genişliği
			int pictureBoxHeight = 200; // PictureBox yüksekliği

			int textBoxMiktarWidth = 100; // Miktar TextBox'ının genişliği

			int spacing = 10; // Elemanlar arasındaki boşluk

			int x = spacing; // Başlangıç konumu X
			int y = spacing; // Başlangıç konumu Y

			// Panel'e bir AutoScroll özelliği ekle
			UrunPaneli.AutoScroll = true;

			// Ürünleri göster
			foreach (var urun in urunler)
			{
				// Yeni bir GroupBox oluştur
				GroupBox groupBox = new GroupBox();
				groupBox.Text = urun.Ad; // GroupBox başlığına ürün adını ekle
				groupBox.Font = new Font("Arial", 10, FontStyle.Bold);
				groupBox.Width = groupBoxWidth;
				groupBox.Height = groupBoxHeight;
				groupBox.Location = new System.Drawing.Point(x, y);
				groupBox.BackColor = Color.LightGray; // Arka plan rengini ayarla
				groupBox.BackColor = Color.FromArgb(170, 198, 227);
				groupBox.Padding = new Padding(spacing); // Kenar boşluklarını ayarla

				// PictureBox oluştur ve fotoğrafı yükle
				PictureBox pictureBox = new PictureBox();
				pictureBox.ImageLocation = urun.Fotograf;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox.Width = pictureBoxWidth;
				pictureBox.Height = pictureBoxHeight;
				pictureBox.Location = new System.Drawing.Point((groupBoxWidth - pictureBoxWidth) / 2, spacing * 2); // PictureBox'in konumu

				// Label oluştur ve ürün detaylarını ekle
				Label labelDetay = new Label();
				labelDetay.Text = urun.Detay;
				labelDetay.AutoSize = true;
				labelDetay.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
				labelDetay.Location = new System.Drawing.Point((groupBoxWidth - labelDetay.Width) / 2, pictureBoxHeight + 3 * spacing); // Label'in konumu

				// Label oluştur ve ürün fiyatını ekle
				Label labelFiyat = new Label();
				labelFiyat.Text = "Fiyat: " + urun.Fiyat.ToString("C2"); // Para birimi formatıyla fiyatı ekle
				labelFiyat.AutoSize = true;
				labelFiyat.Font = new Font("Arial", 12); // Yazı tipi ve boyutunu ayarla
				labelFiyat.Location = new System.Drawing.Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing);
				//Label'in konumu

				// TextBox oluştur ve miktar girişi yapılacak
				TextBox textBoxMiktar = new TextBox();
				textBoxMiktar.Location = new System.Drawing.Point((groupBoxWidth - textBoxMiktarWidth) / 2, labelFiyat.Location.Y + labelFiyat.Height + spacing); // TextBox'in konumu
				textBoxMiktar.Width = textBoxMiktarWidth; // TextBox genişliği
				textBoxMiktar.TextAlign = HorizontalAlignment.Center; // Metni ortala

				// Ürün miktarını veritabanından çek
				var siparisDetay = db.SiparisUrunler.FirstOrDefault(o => o.SiparisId == sonSiparisId && o.UrunId == urun.Id);
				if (siparisDetay != null)
				{
					textBoxMiktar.Text = siparisDetay.Miktar.ToString();
				}
				else
				{
					textBoxMiktar.Text = "0";
				}

				// - Butonu oluştur
				Button buttonEksi = new Button();
				buttonEksi.Text = "-";
				buttonEksi.Width = 25;
				buttonEksi.Height = 25;
				buttonEksi.Location = new Point(textBoxMiktar.Location.X - buttonEksi.Width - 5, textBoxMiktar.Location.Y);
				buttonEksi.Click += (sender, e) =>
				{
					int miktar = 0;
					if (int.TryParse(textBoxMiktar.Text, out miktar))
					{
						miktar = Math.Max(0, miktar - 1); // Negatif olmayan miktarı güvence altına al
						textBoxMiktar.Text = miktar.ToString();
					}
				};

				// + Butonu oluştur
				Button buttonArti = new Button();
				buttonArti.Text = "+";
				buttonArti.Width = 25;
				buttonArti.Height = 25;
				buttonArti.Location = new Point(textBoxMiktar.Location.X + textBoxMiktar.Width + 5, textBoxMiktar.Location.Y);
				buttonArti.Click += (sender, e) =>
				{
					int miktar = 0;
					if (int.TryParse(textBoxMiktar.Text, out miktar))
					{
						miktar += 1;
						textBoxMiktar.Text = miktar.ToString();
					}
				};

				// Button oluştur ve onay butonu olarak ayarla
				Button buttonOnayla = new Button();
				buttonOnayla.Text = "Onayla";
				buttonOnayla.Width = 150;
				buttonOnayla.Height = 40; // Yükseklik artırıldı
				buttonOnayla.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
				buttonOnayla.BackColor = Color.DarkOrange; // Buton rengini ayarla
				buttonOnayla.ForeColor = Color.White; // Yazı rengini ayarla
				buttonOnayla.Location = new System.Drawing.Point((groupBoxWidth - buttonOnayla.Width) / 2, textBoxMiktar.Location.Y + textBoxMiktar.Height + spacing); // Button'un konumu

				// GroupBox'a kontrol öğelerini ekle
				groupBox.Controls.Add(pictureBox);
				groupBox.Controls.Add(labelDetay);
				groupBox.Controls.Add(labelFiyat);
				groupBox.Controls.Add(textBoxMiktar);
				groupBox.Controls.Add(buttonEksi);
				groupBox.Controls.Add(buttonArti);
				groupBox.Controls.Add(buttonOnayla);

				// Panel'e GroupBox'ı ekle
				UrunPaneli.Controls.Add(groupBox);

				// Konumları güncelle
				x += groupBoxWidth + spacing; // X konumunu güncelle, spacing kadar ileri taşı
				if (x + groupBoxWidth + spacing > UrunPaneli.Width) // Eğer sığmıyorsa bir sonraki satıra geç
				{
					x = spacing; // X konumunu sıfırla
					y += groupBoxHeight + spacing * 2; // Y konumunu bir sonraki satıra taşı
				}
			}

			// Menüleri göster
			foreach (var menu in menuler)
			{
				// Yeni bir GroupBox oluştur
				GroupBox groupBox = new GroupBox();
				groupBox.Text = menu.Ad; // GroupBox başlığına ürün adını ekle
				groupBox.Font = new Font("Arial", 10, FontStyle.Bold);
				groupBox.Width = groupBoxWidth;
				groupBox.Height = groupBoxHeight;
				groupBox.Location = new System.Drawing.Point(x, y);
				groupBox.BackColor = Color.LightGray; // Arka plan rengini ayarla
				groupBox.BackColor = Color.FromArgb(170, 198, 227);
				groupBox.Padding = new Padding(spacing); // Kenar boşluklarını ayarla


				// PictureBox oluştur ve fotoğrafı yükle
				PictureBox pictureBox = new PictureBox();
				pictureBox.ImageLocation = menu.Fotograf;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox.Width = pictureBoxWidth;
				pictureBox.Height = pictureBoxHeight;
				pictureBox.Location = new System.Drawing.Point((groupBoxWidth - pictureBoxWidth) / 2, spacing * 2); // PictureBox'in konumu

				// Label oluştur ve ürün detaylarını ekle
				Label labelDetay = new Label();
				labelDetay.Text = menu.Detay;
				labelDetay.AutoSize = true;
				labelDetay.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
				labelDetay.Location = new System.Drawing.Point((groupBoxWidth - labelDetay.Width) / 2, pictureBoxHeight + 3 * spacing); // Label'in konumu

				// Label oluştur ve ürün fiyatını ekle
				Label labelFiyat = new Label();
				labelFiyat.Text = "Fiyat: " + menu.Fiyat.ToString("C2"); // Para birimi formatıyla fiyatı ekle
				labelFiyat.AutoSize = true;
				labelFiyat.Font = new Font("Arial", 12); // Yazı tipi ve boyutunu ayarla
				labelFiyat.Location = new System.Drawing.Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing);
				//Label'in konumu

				// TextBox oluştur ve miktar girişi yapılacak
				TextBox textBoxMiktar = new TextBox();
				textBoxMiktar.Location = new System.Drawing.Point((groupBoxWidth - textBoxMiktarWidth) / 2, labelFiyat.Location.Y + labelFiyat.Height + spacing); // TextBox'in konumu
				textBoxMiktar.Width = textBoxMiktarWidth; // TextBox genişliği
				textBoxMiktar.TextAlign = HorizontalAlignment.Center; // Metni ortala

				// Ürün miktarını veritabanından çek
				var siparisDetay = db.SiparisMenus.FirstOrDefault(o => o.SiparisId == sonSiparisId && o.MenuId == menu.Id);
				if (siparisDetay != null)
				{
					textBoxMiktar.Text = siparisDetay.Miktar.ToString();
				}
				else
				{
					textBoxMiktar.Text = "0";
				}

				// - Butonu oluştur
				Button buttonEksi = new Button();
				buttonEksi.Text = "-";
				buttonEksi.Width = 25;
				buttonEksi.Height = 25;
				buttonEksi.Location = new Point(textBoxMiktar.Location.X - buttonEksi.Width - 5, textBoxMiktar.Location.Y);
				buttonEksi.Click += (sender, e) =>
				{
					int miktar = 0;
					if (int.TryParse(textBoxMiktar.Text, out miktar))
					{
						miktar = Math.Max(0, miktar - 1); // Negatif olmayan miktarı güvence altına al
						textBoxMiktar.Text = miktar.ToString();
					}
				};

				// + Butonu oluştur
				Button buttonArti = new Button();
				buttonArti.Text = "+";
				buttonArti.Width = 25;
				buttonArti.Height = 25;
				buttonArti.Location = new Point(textBoxMiktar.Location.X + textBoxMiktar.Width + 5, textBoxMiktar.Location.Y);
				buttonArti.Click += (sender, e) =>
				{
					int miktar = 0;
					if (int.TryParse(textBoxMiktar.Text, out miktar))
					{
						miktar += 1;
						textBoxMiktar.Text = miktar.ToString();
					}
				};

				// Button oluştur ve onay butonu olarak ayarla
				Button buttonOnayla = new Button();
				buttonOnayla.Text = "Onayla";
				buttonOnayla.Width = 150;
				buttonOnayla.Height = 40; // Yükseklik artırıldı
				buttonOnayla.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
				buttonOnayla.BackColor = Color.DarkOrange; // Buton rengini ayarla
				buttonOnayla.ForeColor = Color.White; // Yazı rengini ayarla
				buttonOnayla.Location = new System.Drawing.Point((groupBoxWidth - buttonOnayla.Width) / 2, textBoxMiktar.Location.Y + textBoxMiktar.Height + spacing); // Button'un konumu

				// GroupBox'a kontrol öğelerini ekle
				groupBox.Controls.Add(pictureBox);
				groupBox.Controls.Add(labelDetay);
				groupBox.Controls.Add(labelFiyat);
				groupBox.Controls.Add(textBoxMiktar);
				groupBox.Controls.Add(buttonEksi);
				groupBox.Controls.Add(buttonArti);
				groupBox.Controls.Add(buttonOnayla);

				// Panel'e GroupBox'ı ekle
				UrunPaneli.Controls.Add(groupBox);

				// Konumları güncelle
				x += groupBoxWidth + spacing; // X konumunu güncelle, spacing kadar ileri taşı
				if (x + groupBoxWidth + spacing > UrunPaneli.Width) // Eğer sığmıyorsa bir sonraki satıra geç
				{
					x = spacing; // X konumunu sıfırla
					y += groupBoxHeight + spacing * 2; // Y konumunu bir sonraki satıra taşı
				}
			}
		}



		private void DoluMasa_Load(object sender, EventArgs e)
		{
			MasaSiparisi();
			masaBilgileri();

			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, db);
			UrunleriGoster(-1); // Tüm ürünleri göster
			label7.Text = txtmasaadi.Text + " Nolu Masanın Siparişleri";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (OdemePaneli.Visible != true)
			{
				txtkalan.Text = geriyekalanUcret.ToString();
				OdemePaneli.Visible = true;
				txtmasatutarı.Text = txttutar.Text;
			}
			else
			{
				OdemePaneli.Visible = false;
			}
		}
	
		private void button5_Click(object sender, EventArgs e)
		{
			if (Odenecek <= geriyekalanUcret)
			{
				if (comboOdemeTur.SelectedIndex != -1)
				{
					odeme.Tur = comboOdemeTur.SelectedIndex + 1;
					Odenecek = Yardimcilar.TemizleVeDondur(txtodenecek, "");
					odeme.Tutar = Odenecek;
					odeme.SiparisID = sonSiparisId;
					odeme.OdemeTarih = DateTime.Now;
					db.Odemeler.Add(odeme);
					db.SaveChanges();
					var masa = db.Masalar.Find(masaId);
					var masasiparis = db.MasaSiparisler.Where(s => s.MasaId == masaId)
									 .OrderByDescending(s => s.Id)
									 .FirstOrDefault();
					masasiparis.OdenenTutar += Odenecek;
					//Masanın ödenen ücretiyle tutar 5 aşağı yukarı eşleşiyorsa masa durumunu kirli yapm ve masanı tutarlarını 0'la
					if (Math.Abs(masasiparis.Tutar - masasiparis.OdenenTutar) <= 5)
					{
						masa.Durum = 3;
						masasiparis.Tutar = 0;
						masasiparis.OdenenTutar = 0;
					}
					txtodenen.Text = masasiparis.OdenenTutar + "₺";
					db.SaveChanges();
					masaBilgileri();
					MessageBox.Show($"{Odenecek}₺ Ödeme Alındı Geriye Kalan {geriyekalanUcret}₺");
					if (geriyekalanUcret == 0)
					{
						MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
						if (calisanForm != null)
						{
							calisanForm.MasaButonlariniGuncelle();
						}
						this.Close();
					}
				}
			}
			else
			{
				MessageBox.Show("Alınması Gerekenden Daha Fazla Ücret Alınıyor!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Temizle();
		}

		private void Temizle()
		{
			txtodenecek.Text = "";
			Odenecek = 0;
			comboOdemeTur.Text = "";
		}

		private void txtkisisayisi_TextChanged(object sender, EventArgs e)
		{
			kisisayisi = Convert.ToInt32(txtkisisayisi.Text);
			// Kişi başı ücreti hesapla
			kisibasiUcret = geriyekalanUcret / kisisayisi;

			// Yuvarlanmış ücretleri depolamak için bir dizi oluştur
			decimal[] yuvarlanmisUcretler = new decimal[5];
			for (int i = 0; i < 5; i++)
			{
				// İlgili ücreti yuvarla ve diziye ekle
				yuvarlanmisUcretler[i] = Math.Floor(kisibasiUcret * 4) / 4; // 0.25 katsayısı ile yuvarla
			}

			// Orijinal ücrete en yakın olan yuvarlanmış ücreti bul
			enYakinUcret = yuvarlanmisUcretler.OrderBy(x => Math.Abs(x - kisibasiUcret)).First();
			txtodenecek.Text = enYakinUcret.ToString();
		}

		private void btn20_Click(object sender, EventArgs e)
		{
			int deger = 20;
			ButonluOdeme(deger);
		}
		void ButonluOdeme(int Deger)
		{
			Odenecek = Yardimcilar.TemizleVeDondur(txtodenecek, "");
			Odenecek = Odenecek + Deger;
			txtodenecek.Text = Odenecek.ToString();
			Odenecek = Yardimcilar.TemizleVeDondur(txtodenecek, "");
		}
		private void btn50_Click(object sender, EventArgs e)
		{
			int deger = 50;
			ButonluOdeme(deger);
		}

		private void btn100_Click(object sender, EventArgs e)
		{
			int deger = 100;
			ButonluOdeme(deger);
		}

		private void btn200_Click(object sender, EventArgs e)
		{
			int deger = 200;
			ButonluOdeme(deger);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Temizle();
		}

		private void btn5_Click(object sender, EventArgs e)
		{
			int deger = 5;
			ButonluOdeme(deger);
		}

		private void btn10_Click(object sender, EventArgs e)
		{
			int deger = 10;
			ButonluOdeme(deger);
		}

		private void DoluMasa_FormClosing(object sender, FormClosingEventArgs e)
		{
			Admin_Paneli adminPaneliForm = new Admin_Paneli(kullaniciId);
			adminPaneliForm.grafikleriGuncelle();
		}
	}
}
