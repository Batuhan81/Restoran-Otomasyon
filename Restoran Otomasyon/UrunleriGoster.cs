using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	internal class UrunleriGoster
	{
		public class UrunGosterici
		{
			private Panel _panel;
			private DataGridView _gridSiparisler;
			private TextBox _txttutar;
			private Context _dbContext;

			public UrunGosterici(Panel panel, DataGridView gridSiparisler, TextBox txttutar, Context dbContext)
			{
				_panel = panel ?? throw new ArgumentNullException(nameof(panel), "Panel null olamaz.");
				_gridSiparisler = gridSiparisler ?? throw new ArgumentNullException(nameof(gridSiparisler), "GridSiparisler null olamaz.");
				_txttutar = txttutar ?? throw new ArgumentNullException(nameof(txttutar), "Txttutar null olamaz.");
				_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "DbContext null olamaz.");
			}

			public void UrunleriGoster(int kategoriId)
			{
				_panel.Controls.Clear();

				List<Urun> urunler;
				if (kategoriId <= 0)
				{
					urunler = _dbContext.Urunler
						.Where(o => o.Gorunurluk == true && o.Akitf == true)
						.ToList();
					// Tüm ürünleri göster
				}
				else
				{
					// Belirli bir kategoriye ait ürünleri getir
					urunler = _dbContext.Urunler
						.Where(o => o.Gorunurluk == true && o.Akitf == true && o.KategorId == kategoriId)
						.ToList();
					// Belirli kategoriye ait ürünleri göster
				}

				int groupBoxHeight = 400; // GroupBox yüksekliği
				int groupBoxWidth = 285;  // GroupBox genişliği

				int pictureBoxWidth = 200; // PictureBox genişliği
				int pictureBoxHeight = 200; // PictureBox yüksekliği

				int textBoxMiktarWidth = 100; // Miktar TextBox'ının genişliği

				int spacing = 10; // Elemanlar arasındaki boşluk

				int x = spacing; // Başlangıç konumu X
				int y = spacing; // Başlangıç konumu Y

				// Panel'e bir AutoScroll özelliği ekle
				_panel.AutoScroll = true;

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
							bool StokDurum = Yardimcilar.StoklariKontrolEt(urun, miktar, _dbContext);

							if (StokDurum == true)
							{
								// Ürün adı, miktar ve fiyat bilgilerini DataGridView'e ekle
								DataGridViewRow newRow = new DataGridViewRow();
								newRow.CreateCells(_gridSiparisler);
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
								_gridSiparisler.Rows.Add(newRow);
								// Toplam tutarı hesapla ve txttutar.Text'e yaz
								HesaplaToplamTutar(_gridSiparisler, _txttutar);
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
					_panel.Controls.Add(groupBox);

					// Konumları güncelle
					x += groupBoxWidth + spacing; // X konumunu güncelle, spacing kadar ileri taşı
					if (x + groupBoxWidth + spacing > _panel.Width) // Eğer sığmıyorsa bir sonraki satıra geç
					{
						x = spacing; // X konumunu sıfırla
						y += groupBoxHeight + spacing * 2; // Y konumunu bir sonraki satıra taşı
					}
					groupBox.Margin = new Padding(10, 10, 10, 10);
				}
			}

			public void MenuleriGoster(int kategoriId)
			{
				// Menüleri göster
				List<Data.Menu> menuler;
				if (kategoriId <= 0)
				{
					menuler = _dbContext.Menuler
								.Where(o => o.Gorunurluk == true && o.Akitf == true)
								.ToList();
				}
				else
				{
					menuler = _dbContext.Menuler
								.Where(o => o.Gorunurluk == true && o.Akitf == true && o.KategoriId == kategoriId)
								.ToList();
				}


				int groupBoxHeight = 400; // GroupBox yüksekliği
				int groupBoxWidth = 285;  // GroupBox genişliği

				int pictureBoxWidth = 200; // PictureBox genişliği
				int pictureBoxHeight = 200; // PictureBox yüksekliği

				int textBoxMiktarWidth = 100; // Miktar TextBox'ının genişliği

				int spacing = 10; // Elemanlar arasındaki boşluk

				int x = spacing; // Başlangıç konumu X
				int y = spacing; // Başlangıç konumu Y

				_panel.HorizontalScroll.Maximum = 0;
				_panel.AutoScroll = true;


				foreach (var Menu in menuler)
				{

					// Yeni bir GroupBox oluştur
					GroupBox groupBox = new GroupBox();
					groupBox.Text = Menu.Ad; // GroupBox başlığına menü adını ekle
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

					// Label oluştur ve menü detaylarını ekle
					Label labelDetay = new Label();
					labelDetay.Text = Menu.Detay;
					labelDetay.AutoSize = true;
					labelDetay.Font = new Font("Arial", 12, FontStyle.Bold); // Yazı tipi ve boyutunu ayarla
					labelDetay.Location = new System.Drawing.Point((groupBoxWidth - labelDetay.Width) / 2, pictureBoxHeight + 3 * spacing); // Label'in konumu

					// Label oluştur ve fiyatı ekle
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
							var menuUrunleri = _dbContext.MenuUrunler.Where(o => o.MenuId == o.MenuId).ToList();
							// Menünün içindeki her bir ürün için stok kontrolü yap
							foreach (var menuUrun in menuUrunleri)
							{
								// Her bir ürünün stok durumunu kontrol et
								bool urunStokDurumu = Yardimcilar.StoklariKontrolEt(menuUrun.Urun, miktar, _dbContext);

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
								newRow.CreateCells(_gridSiparisler);
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
								_gridSiparisler.Rows.Add(newRow);
								// Toplam tutarı hesapla ve txttutar.Text'e yaz
								HesaplaToplamTutar(_gridSiparisler, _txttutar);
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
					_panel.Controls.Add(groupBox);

					// Konumları güncelle
					x += groupBoxWidth + spacing; // X konumunu güncelle, spacing kadar ileri taşı
					if (x + groupBoxWidth + spacing > _panel.Width) // Eğer sığmıyorsa bir sonraki satıra geç
					{
						x = spacing; // X konumunu sıfırla
						y += groupBoxHeight + spacing * 2; // Y konumunu bir sonraki satıra taşı
					}
					groupBox.Margin = new Padding(10, 10, 10, 10);
				}
			}


			public static void HesaplaToplamTutar(DataGridView gridSiparisler, TextBox txttutar)
			{
				if (gridSiparisler != null && txttutar != null)
				{
					// Toplam tutarı hesapla ve txttutar.Text'e yaz
					decimal toplamTutar = 0;
					foreach (DataGridViewRow row in gridSiparisler.Rows)
					{
						decimal fiyat;
						if (row.Cells[2].Value != null)
						{
							if (decimal.TryParse(row.Cells[2].Value.ToString().Replace("₺", ""), out fiyat))
							{
								int miktar = Convert.ToInt32(row.Cells[1].Value);
								toplamTutar += fiyat * miktar;
							}
						}
					}
					txttutar.Text = toplamTutar.ToString("C2");
				}
				else
				{
					MessageBox.Show("nul geldi");
				}
			}
		}

	}
}
