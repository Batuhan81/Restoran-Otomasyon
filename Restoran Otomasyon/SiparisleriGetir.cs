using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public class SiparisleriGetir
	{
		public class UrunleriGosterici
		{
			private readonly int masaId;
			private readonly Panel urunPaneli;
			private readonly Context db;
			private int sonSiparisId;

			public UrunleriGosterici(int masaId, Panel urunPaneli, Context dbContext)
			{
				this.masaId = masaId;
				this.urunPaneli = urunPaneli;
				this.db = dbContext;
			}

			public void MasaSiparisi()
			{
				var sonSiparis = db.MasaSiparisler.OrderByDescending(o => o.Id).FirstOrDefault(o => o.MasaId == masaId);
				if (sonSiparis != null)
				{
					sonSiparisId = sonSiparis.SiparisId;
				}
				var masasiparisleri = db.MasaSiparisler.Where(o => o.Siparis.OdemeDurum == false && o.MasaId == masaId).ToList();
			}

			public void UrunleriGoster(int kategoriId)
			{
				var siparisUrunler = db.SiparisUrunler.Where(s => s.SiparisId == sonSiparisId).Select(s => s.UrunId);
				var siparisMenuler = db.SiparisMenus.Where(s => s.SiparisId == sonSiparisId).Select(s => s.MenuId);

				var urunler = db.Urunler.Where(o => o.Gorunurluk && siparisUrunler.Contains(o.Id)).ToList();
				var menuler = db.Menuler.Where(o => o.Gorunurluk && siparisMenuler.Contains(o.Id)).ToList();

				int groupBoxHeight = 400;
				int groupBoxWidth = 300;
				int pictureBoxWidth = 200;
				int pictureBoxHeight = 200;
				int textBoxMiktarWidth = 100;
				int spacing = 10;
				int x = spacing;
				int y = spacing;

				urunPaneli.AutoScroll = true;

				foreach (var urun in urunler)
				{
					GroupBox groupBox = CreateGroupBox(urun.Ad, groupBoxWidth, groupBoxHeight, x, y, spacing);

					PictureBox pictureBox = CreatePictureBox(urun.Fotograf, pictureBoxWidth, pictureBoxHeight, groupBoxWidth, spacing);

					Label labelDetay = CreateLabel(urun.Detay, groupBoxWidth, pictureBoxHeight, spacing);

					Label labelFiyat = CreatePriceLabel(urun.Fiyat, urun.IndirimliFiyat, groupBoxWidth, labelDetay, spacing);

					TextBox textBoxMiktar = CreateQuantityTextBox(urun.Id, groupBoxWidth, labelFiyat, spacing);

					Button buttonEksi = CreateMinusButton(textBoxMiktar, groupBoxWidth, textBoxMiktarWidth, spacing);

					Button buttonArti = CreatePlusButton(textBoxMiktar, groupBoxWidth, textBoxMiktarWidth, spacing);

					Button buttonOnayla = CreateConfirmButton(textBoxMiktar, groupBoxWidth, pictureBoxHeight, spacing);

					AddControlsToGroupBox(groupBox, pictureBox, labelDetay, labelFiyat, textBoxMiktar, buttonEksi, buttonArti, buttonOnayla);

					urunPaneli.Controls.Add(groupBox);

					UpdatePositions(ref x, ref y, groupBoxWidth, spacing, urunPaneli.Width, groupBoxHeight);
				}

				foreach (var menu in menuler)
				{
					GroupBox groupBox = CreateGroupBox(menu.Ad, groupBoxWidth, groupBoxHeight, x, y, spacing);

					PictureBox pictureBox = CreatePictureBox(menu.Fotograf, pictureBoxWidth, pictureBoxHeight, groupBoxWidth, spacing);

					Label labelDetay = CreateLabel(menu.Detay, groupBoxWidth, pictureBoxHeight, spacing);

					Label labelFiyat = CreatePriceLabel(menu.Fiyat, menu.IndirimliFiyat, groupBoxWidth, labelDetay, spacing);

					TextBox textBoxMiktar = CreateQuantityTextBox(menu.Id, groupBoxWidth, labelFiyat, spacing);

					Button buttonEksi = CreateMinusButton(textBoxMiktar, groupBoxWidth, textBoxMiktarWidth, spacing);

					Button buttonArti = CreatePlusButton(textBoxMiktar, groupBoxWidth, textBoxMiktarWidth, spacing);

					Button buttonOnayla = CreateConfirmButton(textBoxMiktar, groupBoxWidth, pictureBoxHeight, spacing);

					AddControlsToGroupBox(groupBox, pictureBox, labelDetay, labelFiyat, textBoxMiktar, buttonEksi, buttonArti, buttonOnayla);

					urunPaneli.Controls.Add(groupBox);

					UpdatePositions(ref x, ref y, groupBoxWidth, spacing, urunPaneli.Width, groupBoxHeight);
				}
			}

			private GroupBox CreateGroupBox(string text, int width, int height, int x, int y, int spacing)
			{
				GroupBox groupBox = new GroupBox();
				groupBox.Text = text;
				groupBox.Font = new Font("Arial", 10, FontStyle.Bold);
				groupBox.Width = width;
				groupBox.Height = height;
				groupBox.Location = new Point(x, y);
				groupBox.BackColor = Color.FromArgb(170, 198, 227);
				groupBox.Padding = new Padding(spacing);
				groupBox.Margin = new Padding(15, 15, 15, 15);
				return groupBox;
			}

			private PictureBox CreatePictureBox(string imageLocation, int width, int height, int groupBoxWidth, int spacing)
			{
				PictureBox pictureBox = new PictureBox();
				pictureBox.ImageLocation = imageLocation;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox.Width = width;
				pictureBox.Height = height;
				pictureBox.Location = new Point((groupBoxWidth - width) / 2, spacing * 2);
				return pictureBox;
			}

			private Label CreateLabel(string text, int groupBoxWidth, int pictureBoxHeight, int spacing)
			{
				Label label = new Label();
				label.Text = text;
				label.AutoSize = true;
				label.Font = new Font("Arial", 12, FontStyle.Bold);
				label.Location = new Point((groupBoxWidth - label.Width) / 2, pictureBoxHeight + 3 * spacing);
				return label;
			}

			private Label CreatePriceLabel(decimal price, decimal discountedPrice, int groupBoxWidth, Label labelDetay, int spacing)
			{
				Label labelFiyat = new Label();
				labelFiyat.AutoSize = true;
				labelFiyat.Font = new Font("Arial", 12);
				labelFiyat.Location = new Point((groupBoxWidth - labelFiyat.Width) / 2, labelDetay.Location.Y + labelDetay.Height + spacing);
				if (discountedPrice < price && discountedPrice != 0)
				{
					string fiyatMetni = "Fiyat: " + price.ToString("C2");
					if (discountedPrice < price)
					{
						fiyatMetni += " " + discountedPrice.ToString("C2", CultureInfo.GetCultureInfo("tr-TR"));
					}
					labelFiyat.Text = fiyatMetni;
					int index = fiyatMetni.IndexOf(discountedPrice.ToString("C2"));
					int length = price.ToString("C2").Length - 1;
					labelFiyat.Paint += (sender, e) =>
					{
						using (var pen = new Pen(Color.Black, 2))
						{
							var yCoordinate = labelFiyat.Height / 2;
							e.Graphics.DrawLine(pen, labelFiyat.Left - 60, yCoordinate, labelFiyat.Left + length, yCoordinate);
						}
					};
				}
				else
				{
					labelFiyat.Text = "Fiyat: " + price.ToString("C2");
				}
				return labelFiyat;
			}

			private TextBox CreateQuantityTextBox(int id, int groupBoxWidth, Label labelFiyat, int spacing)
			{
				TextBox textBoxMiktar = new TextBox();
				textBoxMiktar.Location = new Point((groupBoxWidth - 100) / 2, labelFiyat.Location.Y + labelFiyat.Height + spacing);
				textBoxMiktar.Width = 100;
				textBoxMiktar.TextAlign = HorizontalAlignment.Center;
				var siparisDetay = db.SiparisUrunler.FirstOrDefault(o => o.SiparisId == sonSiparisId && o.UrunId == id);
				if (siparisDetay != null)
				{
					textBoxMiktar.Text = siparisDetay.Miktar.ToString();
				}
				else
				{
					textBoxMiktar.Text = "0";
				}
				return textBoxMiktar;
			}

			private Button CreateMinusButton(TextBox textBoxMiktar, int groupBoxWidth, int textBoxMiktarWidth, int spacing)
			{
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
						miktar = Math.Max(0, miktar - 1);
						textBoxMiktar.Text = miktar.ToString();
					}
				};
				return buttonEksi;
			}

			private Button CreatePlusButton(TextBox textBoxMiktar, int groupBoxWidth, int textBoxMiktarWidth, int spacing)
			{
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
				return buttonArti;
			}

			private Button CreateConfirmButton(TextBox textBoxMiktar, int groupBoxWidth, int pictureBoxHeight, int spacing)
			{
				Button buttonOnayla = new Button();
				buttonOnayla.Text = "Onayla";
				buttonOnayla.Width = 150;
				buttonOnayla.Height = 40;
				buttonOnayla.Font = new Font("Arial", 12, FontStyle.Bold);
				buttonOnayla.BackColor = Color.DarkOrange;
				buttonOnayla.ForeColor = Color.White;
				buttonOnayla.Location = new Point((groupBoxWidth - buttonOnayla.Width) / 2, textBoxMiktar.Location.Y + textBoxMiktar.Height + spacing);
				return buttonOnayla;
			}

			private void AddControlsToGroupBox(GroupBox groupBox, PictureBox pictureBox, Label labelDetay, Label labelFiyat, TextBox textBoxMiktar, Button buttonEksi, Button buttonArti, Button buttonOnayla)
			{
				groupBox.Controls.Add(pictureBox);
				groupBox.Controls.Add(labelDetay);
				groupBox.Controls.Add(labelFiyat);
				groupBox.Controls.Add(textBoxMiktar);
				groupBox.Controls.Add(buttonEksi);
				groupBox.Controls.Add(buttonArti);
				groupBox.Controls.Add(buttonOnayla);
			}

			private void UpdatePositions(ref int x, ref int y, int groupBoxWidth, int spacing, int panelWidth, int groupBoxHeight)
			{
				x += groupBoxWidth + spacing;
				if (x + groupBoxWidth + spacing > panelWidth)
				{
					x = spacing;
					y += groupBoxHeight + spacing * 2;
				}
			}
		}
	}
}
