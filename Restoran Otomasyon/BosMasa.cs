using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Restoran_Otomasyon
{
	public partial class BosMasa : Form
	{
		public BosMasa(int masaID, int kullaniciID)
		{
			InitializeComponent();
			masaId = masaID;
			kullaniciId = kullaniciID;
		}

		int masaId;
		int kullaniciId;
		Context db = new Context();
		bool loaddayuklendi = false;

		void StokKontrol()
		{
			var tumMalzemeler = db.Malzemeler.ToList();

			foreach (var malzeme in tumMalzemeler)
			{
				// Malzemenin stok bilgisini al
				var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzeme.Id);

				if (stok != null)
				{
					//Eğer malze miktarları koşullardan daha küçükse o malzemeyi kullanan her şeyin aktifliği kapatıp sipariş verilmesini engelliyorum
					if ((malzeme.Tur == "Adet" && stok.Miktar <= 5) ||
						(malzeme.Tur == "Kg" && stok.Miktar <= 500) ||
						(malzeme.Tur == "L" && stok.Miktar <= 500))
					{
						// Malzemeyi kullanan tüm ürünleri bul
						var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).ToList();

						foreach (var urun in urunler)
						{
							// Ürünün aktifliğini kapat
							urun.Urun.Akitf = false;

							// Ürünü kullanan menülerin aktifliğini kapat
							var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.UrunId).Select(mu => mu.Menu).Distinct().ToList();
							foreach (var menu in kullananMenuler)
							{
								menu.Akitf = false;
							}
						}
					}
					else if (stok.Miktar >= stok.MinStok)
					{
						// Malzemeyi kullanan tüm ürünleri bul
						var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).ToList();

						foreach (var urun in urunler)
						{
							// Ürünün aktifliğini aç
							urun.Urun.Akitf = true;

							// Ürünü kullanan menülerin aktifliğini aç
							var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.UrunId).Select(mu => mu.Menu).Distinct().ToList();
							foreach (var menu in kullananMenuler)
							{
								menu.Akitf = true;
							}
						}
					}
				}
			}
			// Değişiklikleri kaydet
			db.SaveChanges();
		}

		private void BosMasa_Load(object sender, EventArgs e)
		{
			StokKontrol();
			MasaBilgileri();
			UrunKategori();
			menuKategoriler();
			UrunleriGoster(0);
			MenuleriGoster(0);
			loaddayuklendi = true;
			gridSiparisler.Columns.Add("UrunAdi", "Ürün Adı");
			gridSiparisler.Columns.Add("Adet", "Adet");
			gridSiparisler.Columns.Add("Fiyat", "Fiyat");
			gridSiparisler.Columns.Add("UrunID", "UrunID");
			gridSiparisler.Columns.Add("MenuID", "MenuID");

			// Gizli sütunları bulup gizli hale getirme
			foreach (DataGridViewColumn column in gridSiparisler.Columns)
			{
				if (column.HeaderText == "UrunID" || column.HeaderText == "MenuID")
				{
					column.Visible = true;
				}
			}
			// Formun constructor veya Load metodu içinde ContextMenuStrip'i oluştur
			ContextMenuStrip siparisSilMenu = new ContextMenuStrip();
			ToolStripMenuItem siparisSilMenuItem = new ToolStripMenuItem();
			siparisSilMenuItem.Name = "siparisSilMenuItem";
			siparisSilMenuItem.Size = new Size(180, 22);
			siparisSilMenuItem.Text = "Siparişi Sil";
			siparisSilMenuItem.Click += SiparisSilMenuItem_Click; // Siparişi silme işlevini tanımlayan bir event handler ekleyin
			siparisSilMenu.Items.AddRange(new ToolStripItem[] { siparisSilMenuItem });

			// DataGridView'e ContextMenuStrip'i ata
			gridSiparisler.ContextMenuStrip = siparisSilMenu;

		}
		private void SiparisSilMenuItem_Click(object sender, EventArgs e)
		{
			if (gridSiparisler.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in gridSiparisler.SelectedRows)
				{
					// Seçili satırın ürün ID'sini al
					int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);

					// UrunPaneli içindeki tüm GroupBox'ları döngüye al
					foreach (Control control in UrunPaneli.Controls)
					{
						if (control is GroupBox groupBox)
						{
							// GroupBox içindeki TextBox'ları bul
							foreach (Control innerControl in groupBox.Controls)
							{
								if (innerControl is TextBox textBox)
								{
									// Ürün ID'si seçilen ürün ID'sine eşitse, miktarı sıfırla
									if (textBox.Tag != null && Convert.ToInt32(textBox.Tag) == urunID)
									{
										textBox.Text = "0";
										break;
									}
								}
							}
						}
					}

					// İlgili satırı sil
					gridSiparisler.Rows.Remove(row);
				}
				// Toplam tutarı yeniden hesapla
				HesaplaToplamTutar();
			}
			else
			{
				MessageBox.Show("Lütfen silmek için bir satır seçin.");
			}
		}

		private void MasaBilgileri()
		{
			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);
			if (txtDurum.Text == "Kirli")
			{
				DialogResult result = MessageBox.Show("Bu Masada Sipariş Almak İstediğinize Emin Misiniz(Masa Durumu=>Kirli)", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (DialogResult.No == result)
				{
					this.Close();
				}
			}
		}

		void menuKategoriler()
		{
			var menuKat = db.Kategoriler.Where(o => o.Tur == "Menü" && o.Gorunurluk == true).ToList();
			ComboMenu.DisplayMember = "Ad";
			ComboMenu.ValueMember = "Id";
			ComboMenu.DataSource = menuKat;
		}

		void UrunKategori()
		{
			var Urunkategori = db.Kategoriler.Where(o => o.Tur == "Ürün" && o.Gorunurluk == true).ToList();
			ComboUrun.DisplayMember = "Ad";
			ComboUrun.ValueMember = "Id";
			ComboUrun.DataSource = Urunkategori;
		}
		List<object> listelenek = new List<object>();
		private void MenuleriGoster(int kategoriId)
		{
			// Menüleri göster
			List<Data.Menu> menuler;
			if (kategoriId <= 0)
			{
				menuler = db.Menuler
							.Where(o => o.Gorunurluk == true && o.Akitf == true)
							.ToList();
			}
			else
			{
				menuler = db.Menuler
							.Where(o => o.Gorunurluk == true && o.Akitf == true && o.KategoriId == kategoriId)
							.ToList();
			}


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

			foreach (var Menu in menuler)
			{

				// Yeni bir GroupBox oluştur
				GroupBox groupBox = new GroupBox();
				groupBox.Text = Menu.Ad; // GroupBox başlığına ürün adını ekle
				groupBox.Font = new Font("Arial", 10, FontStyle.Bold);
				groupBox.Width = groupBoxWidth;
				groupBox.Height = groupBoxHeight;
				groupBox.Location = new System.Drawing.Point(x, y);
				groupBox.BackColor = Color.FromArgb(170, 198, 227); // Arka plan rengini ayarla
				groupBox.Padding = new Padding(spacing); // Kenar boşluklarını ayarla

				// PictureBox oluştur ve fotoğrafı yükle
				PictureBox pictureBox = new PictureBox();
				pictureBox.ImageLocation = Menu.Fotograf;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox.Width = pictureBoxWidth;
				pictureBox.Height = pictureBoxHeight;
				pictureBox.Location = new System.Drawing.Point((groupBoxWidth - pictureBoxWidth) / 2, spacing * 2); // PictureBox'in konumu

				// Label oluştur ve ürün detaylarını ekle
				Label labelDetay = new Label();
				labelDetay.Text = Menu.Detay;
				labelDetay.AutoSize = true;
				labelDetay.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
				labelDetay.Location = new System.Drawing.Point((groupBoxWidth - labelDetay.Width) / 2, pictureBoxHeight + 3 * spacing); // Label'in konumu

				// Urun nesnesi oluşturulduğunu varsayalım

				Label labelFiyat = new Label();
				labelFiyat.AutoSize = true;
				labelFiyat.Font = new Font("Arial", 12); // Yazı tipi ve boyutunu ayarla
				labelFiyat.Location = new System.Drawing.Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing); // Label'in konumu

				// İndirimli fiyat varsa
				if (Menu.IndirimliFiyat < Menu.Fiyat && Menu.IndirimliFiyat != 0)
				{
					// Fiyat metnini oluştur
					string fiyatMetni = "Fiyat: " + Menu.Fiyat.ToString("C2"); // Normal fiyatı içeren metin

					// Eğer indirimli fiyat varsa, metne ekleyelim
					if (Menu.IndirimliFiyat < Menu.Fiyat)
					{
						fiyatMetni += " " + Menu.IndirimliFiyat.ToString("C2", CultureInfo.GetCultureInfo("tr-TR")); // Indirimli fiyatı metne ekleyelim
					}

					// Label'ın metnini fiyatMetni olarak ayarla
					labelFiyat.Text = fiyatMetni;

					// Sadece normal fiyatın üstünü çiz
					int index = fiyatMetni.IndexOf(Menu.IndirimliFiyat.ToString("C2")); // Normal fiyatın başlangıç index'ini bul
					int length = Menu.Fiyat.ToString("C2").Length - 1; // Normal fiyatın uzunluğunu bul

					// Label'ın Paint event'inde sadece normal fiyatın üstünü çiz
					labelFiyat.Paint += (sender, e) =>
					{
						using (var pen = new Pen(Color.Black, 2))
						{
							var yCoordinate = labelFiyat.Height / 2; // Etiketin yüksekliğinin yarısı
							e.Graphics.DrawLine(pen, labelFiyat.Left - 60, yCoordinate, labelFiyat.Left + length, yCoordinate); // Üstü çizili bir şekilde normal fiyatı çiz
						}
					};
				}
				// İndirim yoksa sadece normal fiyatı göster
				else
				{
					labelFiyat.Text = "Fiyat: " + Menu.Fiyat.ToString("C2");
				}

				// TextBox oluştur ve miktar girişi yapılacak
				TextBox textBoxMiktar = new TextBox();
				textBoxMiktar.Location = new System.Drawing.Point((groupBoxWidth - textBoxMiktarWidth) / 2, labelFiyat.Location.Y + labelFiyat.Height + spacing); // TextBox'in konumu
				textBoxMiktar.Width = textBoxMiktarWidth; // TextBox genişliği
				textBoxMiktar.TextAlign = HorizontalAlignment.Center; // Metni ortala
				textBoxMiktar.Text = "0"; // Başlangıçta sıfır olarak ayarla
				textBoxMiktar.Tag = Menu.Id;

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
				buttonOnayla.Click += (sender, e) =>
				{
					int miktar;
					if (int.TryParse(textBoxMiktar.Text, out miktar) && miktar > 0)
					{
						bool stokDurum = true; // Başlangıçta stok durumu true olarak ayarla
						var menuUrunleri = db.MenuUrunler.Where(o => o.MenuId == o.MenuId).ToList();
						// Menünün içindeki her bir ürün için stok kontrolü yap
						foreach (var menuUrun in menuUrunleri)
						{
							// Her bir ürünün stok durumunu kontrol et
							bool urunStokDurumu = Yardimcilar.StoklariKontrolEt(menuUrun.Urun, miktar, db);

							// Herhangi bir ürünün stok durumu false ise, menü için stok durumu false yap ve döngüden çık
							if (!urunStokDurumu)
							{
								stokDurum = false;
								break;
							}
						}

						if (stokDurum)
						{
							// Ürün adı, miktar ve fiyat bilgilerini DataGridView'e ekle
							DataGridViewRow newRow = new DataGridViewRow();
							newRow.CreateCells(gridSiparisler);
							newRow.Cells[0].Value = Menu.Ad; // Menü adı
							newRow.Cells[1].Value = miktar; // Miktar
							if (Menu.IndirimliFiyat != 0)
							{
								newRow.Cells[2].Value = Menu.IndirimliFiyat.ToString("C2"); // Fiyat
							}
							else
							{
								newRow.Cells[2].Value = Menu.Fiyat.ToString("C2"); // Fiyat
							}
							newRow.Cells[4].Value = Menu.Id.ToString(); // Fiyat
							gridSiparisler.Rows.Add(newRow);
							// Toplam tutarı hesapla ve txttutar.Text'e yaz
							HesaplaToplamTutar();
						}
						else
						{
							MessageBox.Show("Talep Edilen Menü İçin Yeterli Stok Yok.");
						}
					}
					else
					{
						MessageBox.Show("Lütfen geçerli bir miktar girin.");
					}
				};

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
				groupBox.Margin = new Padding(15, 15, 15, 15);
			}
		}
		private void UrunleriGoster(int kategoriId)
		{
			List<Urun> urunler;
			if (kategoriId <= 0)
			{
				urunler = db.Urunler
							.Where(o => o.Gorunurluk == true && o.Akitf == true)
							.ToList();
				// Tüm ürünleri göster
			}
			else
			{
				// Belirli bir kategoriye ait ürünleri getir
				urunler = db.Urunler
							.Where(o => o.Gorunurluk == true && o.Akitf == true && o.KategorId == kategoriId)
							.ToList();
				// Belirli kategoriye ait ürünleri göster
			}

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

			// Her bir ürün için işlem yap
			foreach (var urun in urunler)
			{
				// Yeni bir GroupBox oluştur
				GroupBox groupBox = new GroupBox();
				groupBox.Text = urun.Ad; // GroupBox başlığına ürün adını ekle
				groupBox.Font = new Font("Arial", 10, FontStyle.Bold);
				groupBox.Width = groupBoxWidth;
				groupBox.Height = groupBoxHeight;
				groupBox.Location = new System.Drawing.Point(x, y);
				groupBox.BackColor = Color.FromArgb(185, 209, 234);

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

				// Urun nesnesi oluşturulduğunu varsayalım

				Label labelFiyat = new Label();
				labelFiyat.AutoSize = true;
				labelFiyat.Font = new Font("Arial", 12); // Yazı tipi ve boyutunu ayarla
				labelFiyat.Location = new System.Drawing.Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing); // Label'in konumu

				// İndirimli fiyat varsa
				if (urun.IndirimliFiyat < urun.Fiyat && urun.IndirimliFiyat != 0)
				{
					// Fiyat metnini oluştur
					string fiyatMetni = "Fiyat: " + urun.Fiyat.ToString("C2"); // Normal fiyatı içeren metin

					// Eğer indirimli fiyat varsa, metne ekleyelim
					if (urun.IndirimliFiyat < urun.Fiyat)
					{
						fiyatMetni += " " + urun.IndirimliFiyat.ToString("C2", CultureInfo.GetCultureInfo("tr-TR")); // Indirimli fiyatı metne ekleyelim
					}

					// Label'ın metnini fiyatMetni olarak ayarla
					labelFiyat.Text = fiyatMetni;

					// Sadece normal fiyatın üstünü çiz
					int index = fiyatMetni.IndexOf(urun.IndirimliFiyat.ToString("C2")); // Normal fiyatın başlangıç index'ini bul
					int length = urun.Fiyat.ToString("C2").Length - 1; // Normal fiyatın uzunluğunu bul

					// Label'ın Paint event'inde sadece normal fiyatın üstünü çiz
					labelFiyat.Paint += (sender, e) =>
					{
						using (var pen = new Pen(Color.Black, 2))
						{
							var yCoordinate = labelFiyat.Height / 2; // Etiketin yüksekliğinin yarısı
							e.Graphics.DrawLine(pen, labelFiyat.Left - 60, yCoordinate, labelFiyat.Left + length, yCoordinate); // Üstü çizili bir şekilde normal fiyatı çiz
						}
					};
				}
				// İndirim yoksa sadece normal fiyatı göster
				else
				{
					labelFiyat.Text = "Fiyat: " + urun.Fiyat.ToString("C2");
				}

				// TextBox oluştur ve miktar girişi yapılacak
				TextBox textBoxMiktar = new TextBox();
				textBoxMiktar.Location = new System.Drawing.Point((groupBoxWidth - textBoxMiktarWidth) / 2, labelFiyat.Location.Y + labelFiyat.Height + spacing); // TextBox'in konumu
				textBoxMiktar.Width = textBoxMiktarWidth; // TextBox genişliği
				textBoxMiktar.TextAlign = HorizontalAlignment.Center; // Metni ortala
				textBoxMiktar.Text = "0"; // Başlangıçta sıfır olarak ayarla
				textBoxMiktar.Tag = urun.Id;

				// - Butonu oluştur
				Button buttonEksi = new Button();
				buttonEksi.Text = "-";
				buttonEksi.Width = 30;
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
				buttonArti.Width = 30;
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
				buttonOnayla.Click += (sender, e) =>
				{
					int miktar;
					if (int.TryParse(textBoxMiktar.Text, out miktar) && miktar > 0)
					{
						bool StokDurum = Yardimcilar.StoklariKontrolEt(urun, miktar, db);

						if (StokDurum == true)
						{
							// Ürün adı, miktar ve fiyat bilgilerini DataGridView'e ekle
							DataGridViewRow newRow = new DataGridViewRow();
							newRow.CreateCells(gridSiparisler);
							newRow.Cells[0].Value = urun.Ad; // Ürün adı
							newRow.Cells[1].Value = miktar; // Miktar
							if (urun.IndirimliFiyat != 0)
							{
								newRow.Cells[2].Value = urun.IndirimliFiyat.ToString("C2"); // Fiyat
							}
							else
							{
								newRow.Cells[2].Value = urun.Fiyat.ToString("C2"); // Fiyat
							}
							newRow.Cells[3].Value = urun.Id.ToString(); // Fiyat
							gridSiparisler.Rows.Add(newRow);
							// Toplam tutarı hesapla ve txttutar.Text'e yaz
							HesaplaToplamTutar();
						}
						else
						{
							MessageBox.Show("Talep Edilen Ürün İçin Yeterli Stok Yok.");
						}
					}
					else
					{
						MessageBox.Show("Lütfen geçerli bir miktar girin.");
						textBoxMiktar.Text = 0.ToString();	
					}
				};
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
				groupBox.Margin = new Padding(15, 15, 15, 15);
			}
		}

		private void HesaplaToplamTutar()
		{
			decimal toplamTutar = 0;

			foreach (DataGridViewRow row in gridSiparisler.Rows)
			{
				object adetCellValue = row.Cells["Adet"].Value;
				object fiyatCellValue = row.Cells["Fiyat"].Value;

				if (adetCellValue != null && fiyatCellValue != null)
				{
					int miktar;
					if (int.TryParse(adetCellValue.ToString(), out miktar))
					{
						decimal fiyat;
						if (decimal.TryParse(fiyatCellValue.ToString().Replace("₺", "").Trim(), out fiyat))
						{
							toplamTutar += fiyat * miktar;
						}
					}
				}
			}
			txttutar.Text = toplamTutar.ToString("C2");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Yeni bir sipariş oluştur
			Siparis siparis = new Siparis();
			MasaSiparis masasip = new MasaSiparis();
			Masa masa = new Masa();
			Durum Durum = new Durum();
			//Bu kısımda bir masaya tıklanıldığında eğer masa durumu rezerve ise durumunu gerçekleştiye çeviriyor yani rezerve eden kişinin geldiğini anlamına geliyor.
			var x = db.Masalar.Find(masaId);
			if (x.Durum == 4)
			{
				var rezervasyon = db.MasaRezervasyonlar.Where(o => o.MasaId == masaId && o.Rezervasyon.Tarih == DateTime.Today).ToList();
				if (rezervasyon != null)
				{
					foreach (var item in rezervasyon)
					{
						// Rezervasyonun başlangıç saati ile mevcut zamandan yarım saat sonrasının farkını al
						TimeSpan baslangicZamani = item.Rezervasyon.BaslangicSaat;
						TimeSpan yarimSaatSonrasininZamani = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(30));

						// Rezervasyonun başlangıç saati şu anki zamandan ileri bir zamansa veya aynı zamandaysa
						if (baslangicZamani >= DateTime.Now.TimeOfDay && baslangicZamani <= yarimSaatSonrasininZamani)
						{
							// Rezervasyonun onay durumu henüz 3 değilse
							if (item.Rezervasyon.Onay != 3)
							{
								// Rezervasyonun onay durumunu 3 olarak güncelleyin
								item.Rezervasyon.Onay = 3;
								int rezervasyonId = item.Id;

								// Değişiklikleri veritabanına kaydedin
								db.SaveChanges();
							}
						}
					}
				}
			}
			x.Durum = 2;//Masa durumu dolu yapıldı.
			db.SaveChanges();
			siparis.Tarih = DateTime.Now;
			siparis.OdemeDurum = false;
			siparis.Not = null;
			siparis.YorumId = null;
			siparis.Gorunurluk = true;
			siparis.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
			masasip.MasaId = masaId;
			masasip.SiparisId = siparis.Id;
			masasip.MusteriId = null;
			masasip.Gorunurluk = true;
			masasip.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
			masasip.OdenenTutar = 0;
			db.MasaSiparisler.Add(masasip);
			db.Siparisler.Add(siparis);

			foreach (DataGridViewRow row in gridSiparisler.Rows)
			{
				if (row.Cells["Adet"].Value != null && Convert.ToInt32(row.Cells["Adet"].Value) > 0)
				{
					int miktar = Convert.ToInt32(row.Cells["Adet"].Value.ToString());

					if (row.Cells["UrunID"].Value != null && row.Cells["UrunID"].Value.ToString() != "")
					{
						int urunId = Convert.ToInt32(row.Cells["UrunID"].Value.ToString());
						SiparisUrun urun = new SiparisUrun();
						urun.UrunId = urunId;
						urun.Miktar = miktar;
						urun.SiparisId = siparis.Id;
						urun.Gorunurluk = true;
						db.SiparisUrunler.Add(urun);
					}
					else if (row.Cells["MenuID"].Value != null && row.Cells["MenuID"].Value.ToString() != "")
					{
						int menuId = Convert.ToInt32(row.Cells["MenuID"].Value.ToString());
						SiparisMenu menu = new SiparisMenu();
						menu.MenuId = menuId;
						menu.Miktar = miktar;
						menu.SiparisId = siparis.Id;
						menu.Gorunurluk = true;
						db.SiparisMenus.Add(menu);
					}
				}
			}
			db.SaveChanges();
			MessageBox.Show("Siparişiniz Onaylanmıştır.");
			// Seçilen siparişin içindeki ürünleri al
			var siparisUrunler = db.SiparisUrunler.Where(su => su.SiparisId == siparis.Id).ToList();
			var siparisMenuUrunler = db.SiparisMenus.Where(su => su.SiparisId == siparis.Id).ToList();

			if (siparisUrunler.Count() > 0)
			{
				foreach (var siparisUrun in siparisUrunler)
				{
					// Ürünün malzemelerini ve miktarlarını al
					var urunMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == siparisUrun.UrunId).ToList();
					// Her bir malzeme için işlem yap
					foreach (var urunMalzeme in urunMalzemeler)
					{
						// Malzemenin stok miktarından düşülecek miktarı belirle
						int dusulecekMiktar = urunMalzeme.Miktar * siparisUrun.Miktar;

						// İlgili malzemenin stokunu bul
						var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == urunMalzeme.MalzemeId);

						// Eğer stok bulunduysa ve düşülecek miktar stok miktarından fazla değilse
						if (stok != null && stok.Miktar >= dusulecekMiktar)
						{
							// Malzemeden stoktan düşüm yap
							stok.Miktar -= dusulecekMiktar;

							string malzemeAd = db.Malzemeler.FirstOrDefault(s => s.Id == stok.MalzemeId).Ad;

							// Stok miktarı minimum stok değerine ulaştıysa veya altına düştüyse
							if (stok.Miktar < stok.MinStok)
							{
								//Bunu daha sonra Admine bildirim olarak atıcaz
								MessageBox.Show($"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.");
							}
							else if (stok.Miktar == 0)
							{
								MessageBox.Show($"{malzemeAd} adlı malzeme kalmadı.");
							}
							// Stok çıkışı kaydını oluştur
							var stokCikti = new StokCikti
							{
								Neden = "Sipariş Hazırlama",
								Miktar = dusulecekMiktar,
								SonStok = stok.Miktar,
								Gorunuluk = true, // Gösterim durumunu belirle
								TedarikciId = stok.TedarikciId,
								MalzemeId = stok.MalzemeId,
								Tarih = DateTime.Now // Şu anki zamanı ata
							};
							// Stok çıkışını veritabanına ekle
							db.stokCiktilar.Add(stokCikti);
						}
						else
						{
							// Ürünün aktifliğini kapat
							urunMalzeme.Urun.Akitf = false;
							MessageBox.Show("Stok yetersiz.");
							return;
						}
					}
				}
			}
			else if (siparisMenuUrunler.Count > 0)
			{
				foreach (var siparisMenuUrun in siparisMenuUrunler)
				{
					// Sipariş menüsündeki her bir ürün için işlem yap
					var menuUrunler = db.MenuUrunler.Where(mu => mu.MenuId == siparisMenuUrun.MenuId).ToList();
					foreach (var menuUrun in menuUrunler)
					{
						// Ürünün malzemelerini ve miktarlarını al
						var urunMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == menuUrun.UrunId).ToList();
						// Her bir malzeme için işlem yap
						foreach (var urunMalzeme in urunMalzemeler)
						{
							// Malzemenin stok miktarından düşülecek miktarı belirle
							int dusulecekMiktar = urunMalzeme.Miktar * siparisMenuUrun.Miktar;

							// İlgili malzemenin stokunu bul
							var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == urunMalzeme.MalzemeId);

							// Eğer stok bulunduysa ve düşülecek miktar stok miktarından fazla değilse
							if (stok != null && stok.Miktar >= dusulecekMiktar)
							{
								// Malzemeden stoktan düşüm yap
								stok.Miktar -= dusulecekMiktar;

								string malzemeAd = db.Malzemeler.FirstOrDefault(s => s.Id == stok.MalzemeId).Ad;

								// Stok miktarı minimum stok değerine ulaştıysa veya altına düştüyse
								if (stok.Miktar < stok.MinStok)
								{
									//Bunu daha sonra Admine bildirim olarak atıcaz
									MessageBox.Show($"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.");
								}
								else if (stok.Miktar == 0)
								{
									MessageBox.Show($"{malzemeAd} adlı malzeme kalmadı.");
								}
								// Stok çıkışı kaydını oluştur
								var stokCikti = new StokCikti
								{
									Neden = "Sipariş Hazırlama",
									Miktar = dusulecekMiktar,
									SonStok = stok.Miktar,
									Gorunuluk = true, // Gösterim durumunu belirle
									TedarikciId = stok.TedarikciId,
									MalzemeId = stok.MalzemeId,
									Tarih = DateTime.Now // Şu anki zamanı ata
								};
								// Stok çıkışını veritabanına ekle
								db.stokCiktilar.Add(stokCikti);
							}
							else
							{
								// Ürünün aktifliğini kapat
								urunMalzeme.Urun.Akitf = false;
								MessageBox.Show("Stok yetersiz.");
								return;
							}
						}
					}
				}

			}

			//Sipariş Durumunun Ayarlandığı Kısım
			Durum.Ad = 2;//Sipariş Onaylandı
			Durum.Zaman = DateTime.Now;//Onaylanma Zamanı
			Durum.Yer = 1;//Bu işlem nerede yapıldı Müşteri Tarafında sipariş alındığında
			Durum.SiparisId = siparis.Id;
			db.Durumlar.Add(Durum);
			db.SaveChanges();
			MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
			if (calisanForm != null)
			{
				calisanForm.MasaButonlariniGuncelle();
			}
			this.Close();
		}

		void PaneliTemizle()
		{
			UrunPaneli.Controls.Clear();
		}

		private void ComboUrun_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loaddayuklendi == true)
			{
				ComboMenu.Text = "";
				int kategoriID = (int)ComboUrun.SelectedValue;
				PaneliTemizle();
				UrunleriGoster(kategoriID);
			}
		}

		private void ComboMenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loaddayuklendi == true)
			{
				ComboUrun.Text = "";
				int kategoriID = (int)ComboMenu.SelectedValue;
				PaneliTemizle();
				MenuleriGoster(kategoriID);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ComboUrun.Text = "";
			ComboMenu.Text = "";
			PaneliTemizle();
			UrunleriGoster(0);
			MenuleriGoster(0);
		}

		private void BosMasa_FormClosed(object sender, FormClosedEventArgs e)
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
	}
}
