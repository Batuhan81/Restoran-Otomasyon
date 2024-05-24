using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static Restoran_Otomasyon.SiparisleriGetir;

namespace Restoran_Otomasyon
{
	public partial class DoluMasa : Form
	{
		public DoluMasa(int masaID, int kullaniciID)
		{
			InitializeComponent();
			masaId = masaID;
			kullaniciId = kullaniciID;
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
			if (masa != null)
			{
				masatutari = masa.Tutar;
				masaOdenen = masa.OdenenTutar;
				geriyekalanUcret = masatutari - masaOdenen;
				txtkalan.Text = Yardimcilar.FormatliDeger(geriyekalanUcret.ToString());
			}
		}

		private void MasaSiparisi()
		{
			var sonSiparis = db.MasaSiparisler.OrderByDescending(o => o.Id).FirstOrDefault(o => o.MasaId == masaId);
			if (sonSiparis != null)
			{
				sonSiparisId = sonSiparis.SiparisId;
			}
			var masasiparisleri = db.MasaSiparisler.Where(o => o.Siparis.OdemeDurum == false && o.MasaId == masaId).ToList();

		}

		private void DoluMasa_Load(object sender, EventArgs e)
		{
			MasaSiparisi();
			masaBilgileri();

			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);

			// Örnek kullanım
			UrunleriGosterici urunGosterici = new UrunleriGosterici(masaId, UrunPaneli, db);
			urunGosterici.MasaSiparisi();
			urunGosterici.UrunleriGoster(-1);
			label7.Text = txtmasaadi.Text + " Nolu Masanın Siparişleri";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (OdemePaneli.Visible != true)
			{
				var maxAd = db.Durumlar.Where(o => o.SiparisId == sonSiparisId)
						.Max(o => o.Ad); // SiparisId'si sonSiparisId olan durumlar arasından en büyük Ad değerini bul
				var durum = db.Durumlar.FirstOrDefault(o => o.SiparisId == sonSiparisId && o.Ad == maxAd); // Bu en büyük Ad değerine sahip olan durumu getir

				if (durum.Ad == 5)
				{
					txtkalan.Text = Yardimcilar.FormatliDeger(geriyekalanUcret.ToString());
					OdemePaneli.Visible = true;
					txtmasatutarı.Text = txttutar.Text;
				}
				else
				{
					MessageBox.Show("Ödeme Yapılmadan Önce Sipariş Teslim Edilmelidir.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				OdemePaneli.Visible = false;
			}
		}

		Durum durum = new Durum();
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
					var kasa = db.Kasalar.Find(1);
					kasa.Bakiye += Odenecek;

					//Masanın ödenen ücretiyle tutar 5 aşağı yukarı eşleşiyorsa masa durumunu kirli yapma ve masanı tutarlarını 0'la
					if (Math.Abs(masasiparis.Tutar - masasiparis.OdenenTutar) <= 5)
					{
						masa.Durum = 3;
					}
					txtodenen.Text = masasiparis.OdenenTutar + "₺";
					db.SaveChanges();

					masaBilgileri();
					MessageBox.Show($"{Odenecek}₺ Ödeme Alındı Geriye Kalan {geriyekalanUcret}₺");
					if (geriyekalanUcret == 0)
					{
						durum.Yer = 3;//Kasa
						durum.Ad = 6;//Ödendi
						durum.Zaman = DateTime.Now;
						durum.SiparisId = masasiparis.SiparisId;
						db.Durumlar.Add(durum);
						db.SaveChanges();
						if (checkFis.Checked)
						{
							Yazdır();
						}
						Yardimcilar.SignalTetikleMasaDurum();
						Yardimcilar.SignalTetikleOdemeAlindi();
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
			TumunuOde.Checked = false;	
		}

		private void txtkisisayisi_TextChanged(object sender, EventArgs e)
		{
			if (txtkisisayisi.Text != "" && txtkisisayisi.Text != 0.ToString())
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
			txtodenecek.Text = Yardimcilar.FormatliDeger(Odenecek.ToString());
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

		private void DoluMasa_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (kullaniciId == 1)
			{
				var adminpaneliform = Application.OpenForms.OfType<Admin_Paneli>().FirstOrDefault();
				if (adminpaneliform != null)
				{
					// Grafikleri güncelle
					adminpaneliform.grafikleriGuncelle();
				}
			}
			else
			{
				var kasaPaneliForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
				if (kasaPaneliForm != null)
				{
					// Grafikleri güncelle
					kasaPaneliForm.grafikleriGuncelle();
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Durum durum = new Durum();
			Bildirim bildirim=new Bildirim();
			var maxAd = db.Durumlar.Where(o => o.SiparisId == sonSiparisId)
						.Max(o => o.Ad); // SiparisId'si sonSiparisId olan durumlar arasından en büyük Ad değerini bul
			var siparisdurum = db.Durumlar.FirstOrDefault(o => o.SiparisId == sonSiparisId && o.Ad == maxAd); // Bu en büyük Ad değerine sahip olan durumu getir
			if (siparisdurum.Ad == 4)
			{
				durum.Ad = 5;
				durum.Zaman = DateTime.Now;
				durum.Yer = 1;
				durum.SiparisId = sonSiparisId;
				db.Durumlar.Add(durum);
				db.SaveChanges();
				timer1.Start();
				MessageBox.Show("Sipariş Müşteriye Teslim Edildi.");
				Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);
				var masa=db.Masalar.FirstOrDefault(o => o.Id == masaId);
				bildirim.Aciklama = $"{masa.Kod	}' Kodlu Masadan {txtkalan.Text} Kadar Ödeme Alınacak";
				bildirim.Baslik= $"{masa.Kod}' Kodlu Masa Ödeme Bekliyor";
				bildirim.Tarih=DateTime.Now;
				bildirim.Okundu = false;
				bildirim.KullaniciId = 2;//Kasa
				db.Bildirimler.Add(bildirim);
				db.SaveChanges() ;
				Yardimcilar.SignalTetikleOdemeBildirim();
			}
			else if (siparisdurum.Ad == 5)
			{
				timer1.Start();
				MessageBox.Show("Sipariş Müşteriye Zaten Teslim Edildi.");
			}
			else
			{
				MessageBox.Show("Siparişin Teslim Edilebilmesi İçin Mutfakta Hazırlanmış Olması Gerekir !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Graphics graphic = e.Graphics;
			Font font = new Font("Arial", 12);

			// Fişin genişliği ve uzunluğunu belirle
			float receiptWidth = 80; // mm cinsinden genişlik
									 //float receiptHeight = 80; // mm cinsinden uzunluk

			float fontHeight = font.GetHeight();
			int startX = 10;
			int startY = 10;
			int offset = 40;
			Pen pen = new Pen(Color.Black);
			float endX = startX + receiptWidth; // Çizginin bitiş noktasını belirle

			// Restoran adını ve tarih saat bilgisini yazdır
			graphic.DrawString("Restoran Adı", new Font("Arial", 18), new SolidBrush(Color.Black), startX, startY);
			graphic.DrawString(DateTime.Now.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), startX, startY + (int)fontHeight + 10);

			offset += 10;

			// Veritabanından siparişleri çek
			var sonSiparis = db.MasaSiparisler.Where(o => o.MasaId == masaId).OrderByDescending(o => o.Id).FirstOrDefault();

			if (sonSiparis != null)
			{
				// Son siparişin ID'sini al
				int sonSiparisId = sonSiparis.SiparisId;

				// Sipariş detaylarını çek
				var siparisDetayListUrun = db.SiparisUrunler.Where(s => s.SiparisId == sonSiparisId).ToList();
				var siparisDetayListMenu = db.SiparisMenus.Where(s => s.SiparisId == sonSiparisId).ToList();

				// Her bir sipariş detayını fişe ekle
				foreach (var siparisDetay in siparisDetayListUrun)
				{
					int miktar = siparisDetay.Miktar;
					string urunAdi = siparisDetay.Urun.Ad;

					string orderDetail = $"{miktar} x {urunAdi}"; // Sipariş detayını oluştur
					graphic.DrawString(orderDetail, font, new SolidBrush(Color.Black), startX, startY + offset);
					offset += (int)fontHeight + 10; // Satır aralığı
				}

				// Her bir sipariş detayını fişe ekle
				foreach (var siparisDetay in siparisDetayListMenu)
				{
					int miktar = siparisDetay.Miktar;
					string urunAdi = siparisDetay.Menu.Ad;
					decimal fiyat = siparisDetay.Menu.Fiyat;

					string orderDetail = $"{miktar} x {urunAdi} - {fiyat}"; // Sipariş detayını oluştur
					graphic.DrawString(orderDetail, font, new SolidBrush(Color.Black), startX, startY + offset);
					offset += (int)fontHeight + 10; // Satır aralığı
				}

				// Tam çizgi ekle
				graphic.DrawLine(pen, startX, startY + offset, endX + 100, startY + offset);
				offset += 10;


				// Toplam ödenen tutarı al ve fişe ekle
				decimal toplamTutar = sonSiparis.Tutar;
				string total = $"Toplam: {toplamTutar} ₺"; // Toplam ödenen tutarı oluştur
				graphic.DrawString(total, font, new SolidBrush(Color.Black), startX, startY + offset);

				// Ödeme türünü al ve fişe ekle
				string odemeTuru = comboOdemeTur.Text;
				string paymentType = $"Ödeme Türü: {odemeTuru}"; // Ödeme türünü oluştur
				graphic.DrawString(paymentType, font, new SolidBrush(Color.Black), startX, startY + offset + (int)fontHeight + 5);

				// Bir sonraki sipariş için offset'i bir daha artır
				offset += (int)fontHeight + 10;
			}
		}

		private void Yazdır()
		{
			// Yazıcıyı kontrol et
			if (PrinterSettings.InstalledPrinters.Count > 0)
			{
				// Yazıcı varsa yazdırma işlemine devam et
				PrintDialog printDialog = new PrintDialog();
				printDialog.Document = printDocument1;

				if (printDialog.ShowDialog() == DialogResult.OK)
				{
					printDocument1.Print();
				}
			}
			else
			{
				// Yazıcı yoksa PDF olarak kaydetme işlemine geç
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "PDF Dosyası|*.pdf";
				saveFileDialog.Title = "Fişi Kaydet";
				saveFileDialog.FileName = "Fiş.pdf"; // Varsayılan dosya adı

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					printDocument1.PrinterSettings.PrintToFile = true;
					printDocument1.PrinterSettings.PrintFileName = filePath;
					printDocument1.Print();
				}
			}
		}

		private void txtodenecek_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtodenecek, e);
		}

		private void txtodenecek_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtodenecek, sender, e);
		}

		private void txtodenecek_Leave(object sender, EventArgs e)
		{
			txtodenecek.Text = Yardimcilar.FormatliDeger(txtodenecek.Text);
		}

		private void txtkisisayisi_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtkisisayisi, sender, e);
		}

		private void txtkisisayisi_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtkisisayisi, e);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (PanelSiparis.Visible != true)
			{
				PanelSiparis.Visible = true;
				Yardimcilar.OpenForm(new BosMasa(masaId, kullaniciId), PanelSiparis);
				PanelSiparis.BringToFront();
			}
			else
			{
				PanelSiparis.Visible = false;
			}
		}

		private void PanelSiparis_Paint(object sender, PaintEventArgs e)
		{

		}

		private void TumunuOde_CheckedChanged(object sender, EventArgs e)
		{
			if (TumunuOde.Checked == true)
			{
				txtodenecek.Text=txtkalan.Text;
			}
			else
			{
				txtodenecek.Text = "";
			}
		}
	}
}
