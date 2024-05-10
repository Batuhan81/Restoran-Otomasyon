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
using QRCoder;
using System.Drawing.Imaging;
using System.IO;


namespace Restoran_Otomasyon.Paneller
{
	public partial class MasaESG : Form
	{
		public MasaESG(int kullaniciID)
		{
			InitializeComponent();
			InitializeEvents();
			kullaniciId = kullaniciID;
		}
		int kullaniciId;
		private void InitializeEvents()
		{
			if (masabilgisiGuncelle != null)
			{
				masabilgisiGuncelle.FormClosedEvent += UpdateMainForm; // MasaBilgiGuncelle formunun olayını dinle
			}
		}

		private void UpdateMainForm(object sender, EventArgs e)
		{
			MasaButonlariniGuncelle(); // Ana formdaki buton renklerini güncelle
		}
		#region Global Değişkenler
		ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

		private KategoriESG kategoriESGForm;
		private OzellikESG OzellikEsgForm;
		private MasaBilgiGuncelle masabilgisiGuncelle;
		MasaOzellik ozellik = new MasaOzellik();
		int masaId;
		Context db = new Context();
		#endregion

		#region Metodlar
		public void MasaKategoriler()
		{
			// Kategorileri Id ve Ad olarak seçip listeye dönüştürün
			var kategoriler = db.Kategoriler
								.Where(o => o.Gorunurluk == true && o.Tur == "Masa")
								.Select(y => new { Id = y.Id, Ad = y.Ad })
								.ToList();

			comboKat.DisplayMember = "Ad";

			// ComboBox'ın değerini belirtin
			comboKat.ValueMember = "Id";
			// ComboBox'ın veri kaynağını ayarlayın
			comboKat.DataSource = kategoriler;

			// ComboBox'ta gösterilecek metni belirtin

		}

		public void MasaOzellikler()
		{
			var Ozellik = db.Ozellikler.Where(o => o.Gorunurluk == true).Select(y => y.Ad).ToList();
			MasaOzellik.DisplayMember = "Ad";
			MasaOzellik.ValueMember = "Id";
			MasaOzellik.DataSource = Ozellik;
		}
		#endregion
		#region Butonlar
		private void MasaEkle_Click(object sender, EventArgs e)
		{
			int katsayisi = db.Kategoriler.Count(o => o.Tur == "Masa");
			if (katsayisi != 0)
			{
				if (MasaEklePanel.Visible != true)
				{
					MasaEklePanel.Visible = true;
					MasaOzellikler();
				}
				else
				{
					MasaEklePanel.Visible = false;
					MasaOzellikPanel.Visible = false;
				}
			}
			else
			{
				MessageBox.Show("Masa Eklemeden Önce Bir Kat Eklenmelidir!");
				KatEklePanel();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (MasaOzellikPanel.Visible != true)
			{
				MasaOzellikPanel.Visible = true;
				OzellikEsgForm = new OzellikESG();
				Yardimcilar.OpenForm(OzellikEsgForm, MasaOzellikPanel);
			}
			else
			{
				MasaOzellikPanel.Visible = false;
			}
		}
		private void btnKatEkle_Click(object sender, EventArgs e)
		{
			KatEklePanel();
		}

		private void KatEklePanel()
		{
			if (PanelKategori.Visible != true)
			{
				PanelKategori.Visible = true;
				kategoriESGForm = new KategoriESG(1);
				Yardimcilar.OpenForm(kategoriESGForm, PanelKategori);
				MasaKategoriler();
			}
			else
			{
				PanelKategori.Visible = false;
			}
		}
		#endregion

		#region Eventler
		private void MasaESG_Load(object sender, EventArgs e)
		{
			RezarvasyonKontrol();
			MasaKategoriler();
			if (comboKat.Items.Count > 0)
			{
				comboKat.SelectedIndex = 0; // Eğer eleman varsa, ilk elemanı seç
			}
			var kullanici = db.Kullanicilar.Find(kullaniciId);
			if (kullanici != null && kullanici.Ad != "Admin")
			{
				// Eğer kullanıcı admin değilse, ilgili butonları ve kontrolleri gizle ve bazı şeylerin konumlarını değiştir
				btnKatEkle.Visible = false;
				btnKatSil.Visible = false;
				MasaEkle.Visible = false;
				MasaPanel.Location = new Point(20, 30); // MasaPanel'i biraz aşağı kaydır

				// Label2 ve ComboKat'ı formun üstüne taşınması
				label2.Location = new Point(680, 8);
				this.Controls.Add(label2); 
				comboKat.Location = new Point(720, 8);
				this.Controls.Add(comboKat);
				MasaPanel.Size = new Size(1500, 781);
			}
			// ContextMenuStrip'i oluşturun
			// "Masa Güncelle" öğesini ekle
			ToolStripMenuItem menuItemMasaGuncelle = new ToolStripMenuItem("Masa Güncelle");
			menuItemMasaGuncelle.Click += MenuItemMasaGuncelle_Click; // Doğru işleyiciyi ekleyin
			contextMenuStrip1.Items.Add(menuItemMasaGuncelle);

			// "Randevular" öğesini ekle
			ToolStripMenuItem menuItemRandevular = new ToolStripMenuItem("Randevular");
			menuItemRandevular.Click += MenuItemRandevular_Click;
			contextMenuStrip1.Items.Add(menuItemRandevular);

			ToolStripMenuItem menuItemMasaQr = new ToolStripMenuItem("Masa Qr Kodu");
			menuItemMasaQr.Click += MenuItemMasaQrları_Click;
			contextMenuStrip1.Items.Add(menuItemMasaQr);

			ToolStripMenuItem masaTemizle = new ToolStripMenuItem("Masayı Temizle");
			masaTemizle.Click += MenuItemMasaTemizle_Click;
			contextMenuStrip1.Items.Add(masaTemizle);

			ToolStripMenuItem MasaOzellik = new ToolStripMenuItem("Özellikleri Görüntüle");
			MasaOzellik.Click += MenuItemMasaOzellik_Click;
			contextMenuStrip1.Items.Add(MasaOzellik);

			TemizleMasaButonlari();
			ButonlarıGetir(secilenKategoriId);
		}

		// "Masa Güncelle" öğesine tıklama olayı
		private void MenuItemMasaGuncelle_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control sourceControl = menu.SourceControl;

			// Sağ tıklanan butonun adından masa ID'sini çıkarın
			int masaId = int.Parse(sourceControl.Name.Replace("masaButton", ""));

			// Masa bilgi güncelleme formunu açın
			MasaBilgiGuncelle git = new MasaBilgiGuncelle(masaId);
			git.Show();
		}
		private void MenuItemMasaOzellik_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control sourceControl = menu.SourceControl;

			// Sağ tıklanan butonun adından masa ID'sini çıkarın
			int masaId = int.Parse(sourceControl.Name.Replace("masaButton", ""));

			// Masa bilgi güncelleme formunu açın
			MasaOzellikleri git = new MasaOzellikleri(masaId,kullaniciId);
			git.Show();
		}

		private void MenuItemMasaTemizle_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control sourceControl = menu.SourceControl;

			// Sağ tıklanan butonun adından masa ID'sini çıkarın
			int masaId = int.Parse(sourceControl.Name.Replace("masaButton", ""));

			// Masa bilgi güncelleme formunu açın
			var masa=db.Masalar.Find(masaId);
			masa.Durum = 1;
			db.SaveChanges();
			MasaButonlariniGuncelle();
		}

		// "Randevular" öğesine tıklama olayı
		private void MenuItemRandevular_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control sourceControl = menu.SourceControl;

			// Sağ tıklanan butonun adından masa ID'sini çıkarın
			int masaId = int.Parse(sourceControl.Name.Replace("masaButton", ""));
			RandevuMasa git = new RandevuMasa(masaId);
			git.Show();
		}

		private void MenuItemMasaQrları_Click(object sender, EventArgs e)
		{

			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control sourceControl = menu.SourceControl;

			// Sağ tıklanan butonun adından masa ID'sini çıkarın
			int masaId = int.Parse(sourceControl.Name.Replace("masaButton", ""));
			MasaQr git = new MasaQr(masaId);
			git.Show();
			// Randevular formunu açmak için gerekli işlemleri burada gerçekleştirin
		}
		#endregion

		private void MasaKaydet_Click(object sender, EventArgs e)
		{
			Masa masa = new Masa();
			if (txtkapasite.Text != "" && txtkod.Text != "")
			{
				string masakodu = txtkod.Text;

				var eslesen = db.Masalar.FirstOrDefault(o => o.Kod == masakodu);
				if(eslesen == null)
				{
					masa.Kapasite = Convert.ToInt32(txtkapasite.Text);
					masa.Kod = masakodu;
					masa.PersonelId = null;
					masa.Gorunurluk = true;
					secilenKategoriId = (int)comboKat.SelectedValue;
					masa.KategoriId = secilenKategoriId;
					masa.Durum = 1;
					string dosyaYolu = Yardimcilar.KareKodOlustur(masakodu);

					// Masa kaydına QR kodunun dosya yolunu ekleyerek veritabanına kaydet
					masa.Qr = dosyaYolu;

					// Masa nesnesini veritabanına kaydet
					db.Masalar.Add(masa);
					db.SaveChanges();
					// Masa özelliklerini kaydet
					foreach (var ozellikAdiObj in MasaOzellik.SelectedItems)
					{
						if (ozellikAdiObj is string ozellikAdi)
						{
							var ozellik = db.Ozellikler.FirstOrDefault(o => o.Ad == ozellikAdi);
							if (ozellik != null)
							{
								MasaOzellik masaOzellik = new MasaOzellik();
								masaOzellik.MasaId = masa.Id;
								masaOzellik.OzellikId = ozellik.Id;
								masaOzellik.Gorunurluk = true; // Özellik başlangıçta görünür olarak ayarlanıyor
								db.MasaOzellikler.Add(masaOzellik);
							}
						}
					}
					//Gerek yok
					//MasaSiparis siparis = new MasaSiparis();
					//siparis.MasaId = masaId;
					//siparis.Tutar = 0;
					//siparis.OdenenTutar = 0;
					//db.MasaSiparisler.Add(siparis);
					db.SaveChanges();

					MessageBox.Show("Masa başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

					ButonlarıGetir(secilenKategoriId);
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Bu Masa Kodu Hali Hazırda Kullanımda !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Masayla ilgili tüm alanları doldurmalısınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			txtkod.Text = "";
			txtkapasite.Text = "";
			while (MasaOzellik.CheckedItems.Count > 0)
			{
				MasaOzellik.SetItemChecked(MasaOzellik.CheckedIndices[0], false);
			}
		}

		int secilenKategoriId;
		// Masanın butonunu ID'ye göre bulan yardımcı bir metod
		private Button GetMasaButton(int masaId)
		{
			string buttonName;
			foreach (Control item in MasaPanel.Controls)
			{
				buttonName = "masaButton" + masaId;
				return this.Controls.Find(buttonName, true).FirstOrDefault() as Button;

			}
			return null;
		}
		public void ButonlarıGetir(int secilenKategoriId)
		{
			// MasaPanel'i alın
			Panel masaPanel = this.Controls.Find("MasaPanel", true).FirstOrDefault() as Panel;

			// Eğer masa paneli bulunamazsa veya masa paneli null ise, işlemi sonlandır
			if (masaPanel == null)
			{
				return;
			}

			// db nesnesini temizleyin veya yeniden oluşturun
			db.Dispose();
			db = new Context();

			// Veritabanından seçilen kategoriye ait tüm masaları alın
			var tumMasalar = db.Masalar.Where(m => m.Gorunurluk == true && m.KategoriId == secilenKategoriId).ToList();

			if (tumMasalar.Count != 0)
			{
				foreach (var masa in tumMasalar)
				{
					// Eğer buton zaten varsa, yeniden oluşturmak yerine mevcut butonu kullan
					Button mevcutButon = masaPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "masaButton" + masa.Id);
					if (mevcutButon != null)
					{
						continue;
					}

					// Butonu oluşturun
					Button masaButton = new Button();
					masaButton.Name = "masaButton" + masa.Id; // Butonun adı masa Id'si olacak
					masaButton.Location = new Point(10, 10); // Örneğin, butonun panel içerisindeki konumu
					masaButton.Size = new Size(180, 180); // Butonun boyutu
					masaButton.FlatStyle = FlatStyle.Flat; // Düz bir stil kullanarak kenarlığı kaldırın

					// Butonun arka planına resim ekleyin
					masaButton.BackgroundImage = Image.FromFile(@"C:\Users\Batuhan\Desktop\Üzerinde Çalıştığım\Restoran Otomasyon\Resim Ve İconlar\İconlar\masa3.png");
					masaButton.BackgroundImageLayout = ImageLayout.Stretch; // Resmi buton boyutuna sığacak şekilde germe

					// Butonun üzerindeki metni büyük ve belirgin hale getirin
					masaButton.Font = new Font("Arial", 14, FontStyle.Bold);
					masaButton.ForeColor = Color.White; // Metin rengini beyaz yapın
					masaButton.ContextMenuStrip = contextMenuStrip1;
					// Butonun üstüne metin ekleyin
					masaButton.Text = masa.Kod; // Butonun metni masa kodu olacak
					masaButton.TextAlign = ContentAlignment.MiddleCenter; // Metni ortala

					// Butonun durumuna göre uygun rengi belirleyin
					switch (masa.Durum)
					{
						case 1: // Boş
							masaButton.BackColor = Color.Green;
							break;
						case 2: // Dolu
							masaButton.BackColor = Color.Red;
							break;
						case 3: // Kirli
							masaButton.BackColor = Color.Brown;
							break;
						case 4: // Rezerve
							masaButton.BackColor = Color.Yellow;
							break;
						case 5: // Kapalı
							masaButton.BackColor = Color.Gray;
							break;
						default:
							masaButton.BackColor = Color.White; // Varsayılan renk
							break;
					}

					// Butona tıklama olayını ayarlayın
					masaButton.Click += (sender, e) =>
					{
						// Tıklanan masa butonuna ait olan masa nesnesini al
						Masa tıklananMasa = masa;

						// Tıklanan masa nesnesinden ID'yi al
						int masaId = tıklananMasa.Id;
						switch (masa.Durum)
						{
							case 1: // Boş
									// Müşteri tanımlama formunu aç
								BosMasa musteriForm = new BosMasa(masaId, kullaniciId);
								musteriForm.Show();
								break;
							case 2: // Dolu
								DoluMasa siparisForm = new DoluMasa(masaId, kullaniciId);
								siparisForm.Show();
								break;
							case 3: // Kirli
								BosMasa kirlimasa = new BosMasa(masaId, kullaniciId);
								kirlimasa.Show();
								break;
							case 4: // Rezerve
								BosMasa rezervemasa = new BosMasa(masaId, kullaniciId); // Burada masa Id'sini göndermeniz gerekebilir
								rezervemasa.Show();
								break;
							case 5: // Kapalı
								BosMasa kapaliMasa = new BosMasa(masaId, kullaniciId);
								kapaliMasa.Show();
								break;
							default:
								MessageBox.Show("Bilinmeyen masa durumu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
						}
					};
					masaButton.Margin = new Padding(23, 23, 23, 23); // Sol: 20, Üst: 30, Sağ: 20, Alt: 30 piksel boşluk bırakır
					masaPanel.Controls.Add(masaButton);
				}
			}
		}

		private void comboKat_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Seçilen kategorinin sadece ID değerini al
			secilenKategoriId = (int)comboKat.SelectedValue;
			// Butonları temizle
			TemizleMasaButonlari();
			// Butonları seçilen kategoriye göre yeniden oluştur
			ButonlarıGetir(secilenKategoriId);
		}

		public void MasaButonlariniGuncelle()
		{
			var kat = db.Kategoriler.FirstOrDefault(o => o.Tur == "Masa");
			int secilenKategoriId = kat.Id;
			TemizleMasaButonlari(); // Mevcut butonları temizle
			ButonlarıGetir(secilenKategoriId);
		}


		public void TemizleMasaButonlari()
		{
			// MasaPanel'i al
			Panel masaPanel = this.Controls.Find("MasaPanel", true).FirstOrDefault() as Panel;

			// MasaPanel'i bulamazsa veya null ise, işlemi sonlandır
			if (masaPanel == null)
			{
				return;
			}

			// Kaldırılacak butonları depolamak için bir liste oluştur
			List<Button> kaldırılacakButonlar = new List<Button>();

			// MasaPanel'in içindeki tüm butonları kontrol edin
			foreach (Control control in masaPanel.Controls)
			{
				// Eğer kontrol bir buton ise, kaldırılacakButonlar listesine ekle
				if (control is Button button)
				{
					kaldırılacakButonlar.Add(button);
				}
			}

			// Kaldırılacak butonları listeden kaldır
			foreach (Button button in kaldırılacakButonlar)
			{
				masaPanel.Controls.Remove(button);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)//Her 10 dkda bir rezervasyonu yaklaşan masa var mı diye kontrol et
		{
			RezarvasyonKontrol();
		}

		private void RezarvasyonKontrol()
		{
			using (var db = new Context())
			{
				// Tüm masaları alın
				var masalar = db.Masalar.Where(m => m.Gorunurluk == true).ToList();

				foreach (var digerMasa in masalar)
				{
					// Masa üzerindeki rezervasyonları kontrol et
					var rezervasyonlar = db.MasaRezervasyonlar
						.Where(r => r.MasaId == digerMasa.Id && r.Rezervasyon.Tarih == DateTime.Today && r.Rezervasyon.Onay == 1)
						.ToList();

					foreach (var rezervasyon in rezervasyonlar)
					{
						// Rezervasyonun başlangıç saati ile mevcut zamandan yarım saat sonrasının farkını al
						TimeSpan baslangicZamani = rezervasyon.Rezervasyon.BaslangicSaat;
						TimeSpan yarimSaatSonrasininZamani = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(30));

						// Eğer rezervasyonun başlangıç saati şuanki zamandan yarım saat sonraysa veya daha azsa, masanın durumunu rezerve olarak güncelle
						if (baslangicZamani <= yarimSaatSonrasininZamani || baslangicZamani <= DateTime.Now.TimeOfDay)
						{
							digerMasa.Durum = 4;
							db.SaveChanges();
							MasaButonlariniGuncelle();
						}
						// Eğer rezervasyonun başlangıç saati, şu anki zamandan yarım saat sonrasından fazla ise ve onaylanmışsa, rezervasyon onayını 4 yap
						else if (baslangicZamani > yarimSaatSonrasininZamani && rezervasyon.Rezervasyon.Onay == 1)
						{
							rezervasyon.Rezervasyon.Onay = 4;
						}
					}
					// Rezervasyon tarihi bugünkü tarihten önce ve onaylanmışsa, onayı 6 yap
					var gecmisRezervasyonlar = db.MasaRezervasyonlar
						.Where(r => r.Rezervasyon.Tarih < DateTime.Today && r.Rezervasyon.Onay == 1)
						.ToList();

					foreach (var gecmisRezervasyon in gecmisRezervasyonlar)
					{
						gecmisRezervasyon.Rezervasyon.Onay = 6;
					}
				}
			}
		}

		private void MasaESG_FormClosed(object sender, FormClosedEventArgs e)
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

		private void txtkapasite_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtkapasite, e);
		}

		private void txtkapasite_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtkapasite, sender, e);
		}
	}
}
