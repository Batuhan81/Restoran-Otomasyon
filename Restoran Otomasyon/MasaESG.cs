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
		public MasaESG()
		{
			InitializeComponent();
		}
		#region Global Değişkenler
		private KategoriESG kategoriESGForm;
		private OzellikESG OzellikEsgForm;
		MasaOzellik ozellik = new MasaOzellik();
		Context db = new Context();
		Masa masa = new Masa();
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
			MasaOzellik.DataSource = Ozellik;
		}
		#endregion
		#region Butonlar
		private void MasaEkle_Click(object sender, EventArgs e)
		{
			if (MasaEklePanel.Visible != true)
			{
				MasaEklePanel.Visible = true;
				MasaOzellikler();
			}
			else
			{
				MasaEklePanel.Visible = false;
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
			if (PanelKategori.Visible != true)
			{
				PanelKategori.Visible = true;
				kategoriESGForm = new KategoriESG();
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
			MasaKategoriler();
			if (comboKat.Items.Count > 0)
			{
				comboKat.SelectedIndex = 0; // Eğer eleman varsa, ilk elemanı seç
			}
			ButonlarıGetir(secilenKategoriId);
		}


		#endregion

		private void MasaKaydet_Click(object sender, EventArgs e)
		{
			if (txtkapasite.Text != "" && txtkod.Text != "")
			{
				string masakodu = txtkod.Text;
				masa.Kapasite = Convert.ToInt32(txtkapasite.Text);
				masa.Kod = masakodu;
				masa.PersonelId = null;
				masa.Gorunurluk = true;
				secilenKategoriId = (int)comboKat.SelectedValue;
				masa.KategoriId = secilenKategoriId;
				masa.Durum = 1;

				// QR kodunu oluştur
				QRCodeGenerator qrGenerator = new QRCodeGenerator();
				QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.google.com/" + masakodu, QRCodeGenerator.ECCLevel.Q);
				QRCode qrCode = new QRCode(qrCodeData);
				Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20: piksel başına ölçek faktörü

				// Uygulamanın çalıştığı dizini bul
				string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory;

				// Kayıt edilecek klasörün adını ve yolu belirle
				string klasorAdi = "QrKodlar";
				string klasorYolu = Path.Combine(uygulamaDizini, klasorAdi);

				// Eğer klasör yoksa oluştur
				if (!Directory.Exists(klasorYolu))
				{
					Directory.CreateDirectory(klasorYolu);
				}
				// Dosya adını belirle
				string dosyaAdi = $"{masa.Kod}_QR.png";
				string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

				// QR kodunu dosyaya kaydet
				qrCodeImage.Save(dosyaYolu, ImageFormat.Png);


				// Masa kaydına QR kodunun dosya yolunu ekleyerek veritabanına kaydet
				masa.Qr = dosyaYolu;

				// Masa nesnesini veritabanına kaydet
				db.Masalar.Add(masa);
				db.SaveChanges();

				// İşlem tamamlandıktan sonra mesaj 
				MessageBox.Show("Masa başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

				ButonlarıGetir(secilenKategoriId);
			}
			else
			{
				MessageBox.Show("Masayla ilgili tüm alanları doldurmalısınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		void Yonlendir()
		{

		}
		int secilenKategoriId;
		void ButonlarıGetir(int secilenKategoriId)
		{
			// MasaPanel'i alın
			Panel masaPanel = this.Controls.Find("MasaPanel", true).FirstOrDefault() as Panel;

			// Eğer masa paneli bulunamazsa veya masa paneli null ise, işlemi sonlandır
			if (masaPanel == null)
			{
				return;
			}

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
					masaButton.Text = masa.Kod; // Butonun metni masa kodu olacak
					masaButton.Name = "masaButton" + masa.Id; // Butonun adı masa Id'si olacak
					masaButton.Location = new Point(10, 10); // Örneğin, butonun panel içerisindeki konumu
					masaButton.Size = new Size(150, 100); // Butonun boyutu

					// Butonun durumuna göre uygun rengi belirle
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
					masaButton.Click += (sender, e) =>//Test amacıyla burada görünüyor qr
					{
						// Tıklanan masa butonuna ait olan masa nesnesini al
						Masa tıklananMasa = masa;

						// Tıklanan masa nesnesinden ID'yi al
						int masaId = tıklananMasa.Id;
						switch (masa.Durum)
						{
							case 1: // Boş
								//Müşteri tanımlama formunu aç
									BosMasa musteriForm = new BosMasa(masaId);
								musteriForm.Show();
								break;
							case 2: // Dolu
							   DoluMasa siparisForm = new DoluMasa(masaId); // Burada masa Id'sini göndermeniz gerekebilir
								siparisForm.Show();
								break;
							case 3: // Kirli
								BosMasa kirlimasa = new BosMasa(masaId);
								kirlimasa.Show();
								break;
							case 4: // Rezerve
								DoluMasa rezervemasa = new DoluMasa(masaId); // Burada masa Id'sini göndermeniz gerekebilir
								rezervemasa.Show();
								break;
							case 5: // Kapalı
								BosMasa kapaliMasa = new BosMasa(masaId);
								kapaliMasa.Show();
								break;
							default:
								MessageBox.Show("Bilinmeyen masa durumu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
						}
						Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(masa.Qr, pictureBox1.Width, pictureBox1.Height);
						pictureBox1.Image = resizedImage;
						pictureBox1.Visible = true;
					};
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



		private void TemizleMasaButonlari()
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
	}
}
