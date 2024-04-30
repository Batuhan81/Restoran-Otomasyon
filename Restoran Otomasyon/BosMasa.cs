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
	public partial class BosMasa : Form
	{
		public BosMasa(int masaID)
		{
			InitializeComponent();
			masaId = masaID;
		}

		int masaId;
		Context db = new Context();
		bool loaddayuklendi = false;

		private void BosMasa_Load(object sender, EventArgs e)
		{
			MasaBilgileri();
			UrunKategori();
			menuKategoriler();
			UrunleriGoster(0);
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
					column.Visible = false;
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
			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, db);
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
				groupBox.Width = groupBoxWidth;
				groupBox.Height = groupBoxHeight;
				groupBox.Location = new System.Drawing.Point(x, y);
				groupBox.BackColor = Color.LightGray; // Arka plan rengini ayarla
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
				labelFiyat.Location = new System.Drawing.Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing); // Label'in konumu

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
						// Ürün adı, miktar ve fiyat bilgilerini DataGridView'e ekle
						DataGridViewRow newRow = new DataGridViewRow();
						newRow.CreateCells(gridSiparisler);
						newRow.Cells[0].Value = urun.Ad; // Ürün adı
						newRow.Cells[1].Value = miktar; // Miktar
						newRow.Cells[2].Value = urun.Fiyat.ToString("C2"); // Fiyat
						newRow.Cells[3].Value = urun.Id.ToString(); // Fiyat
						gridSiparisler.Rows.Add(newRow);
						// Toplam tutarı hesapla ve txttutar.Text'e yaz
						HesaplaToplamTutar();
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

			var x = db.Masalar.Find(masaId);//Bukısımda sorunvar
			// Masanın durumunu kontrol edin
			if (x.Durum == 4)
			{
				// Masanın rezervasyonunu bulun
				var rezervasyon = db.MasaRezervasyonlar.Where(o => o.MasaId == masaId && o.Rezervasyon.Tarih == DateTime.Today).ToList();

				// Rezervasyon bulunduysa
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
			x.Durum = 2;
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
					if (Convert.ToInt32(row.Cells["UrunID"].Value.ToString()) != 0 && row.Cells["UrunID"].Value.ToString() != "")
					{
						int urunId = Convert.ToInt32(row.Cells["UrunID"].Value.ToString());
						SiparisUrun urun = new SiparisUrun();
						urun.UrunId = urunId;
						urun.Miktar = miktar;
						urun.SiparisId = siparis.Id;
						urun.Gorunurluk = true;
						db.SiparisUrunler.Add(urun);
					}
					else if (Convert.ToInt32(row.Cells["MenuID"].Value.ToString()) != 0 && row.Cells["MenuID"].Value.ToString() != "")
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
				UrunleriGoster(kategoriID);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ComboUrun.Text = "";
			ComboMenu.Text = "";
			PaneliTemizle();
			UrunleriGoster(0);
		}
	}
}
