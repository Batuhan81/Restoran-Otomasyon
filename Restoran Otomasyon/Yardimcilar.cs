using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public class Yardimcilar
	{
		public static void GridRenklendir(DataGridView grid)
		{
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			grid.RowsDefaultCellStyle.BackColor = Color.White;
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
		}
		public static bool GecerliTarihMi(string tarih)
		{
			DateTime sonuc;
			return DateTime.TryParseExact(tarih, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sonuc);
		}

		public static bool MailKontrol(string mail)
		{
			try
			{
				MailAddress mailAddress = new MailAddress(mail);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void Temizle(GroupBox group)
		{
			foreach (Control item in group.Controls)
			{
				if (item is TextBox || item is ComboBox || item is RichTextBox || item is MaskedTextBox)
				{
					item.Text = "";
				}
			}
		}
		public static void OpenForm(Form form, Panel panel)
		{
			// Panel içinde mevcut herhangi bir formu kaldır
			panel.Controls.Clear();

			// Form'u panelin boyutuna göre ayarla
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			form.Resize += (sender, e) =>
			{
				panel.Size = form.Size;
			};

			// Panel içine yeni formu ekleyin
			panel.Controls.Add(form);
			form.Show();
		}

		public static void CloseForm(Form form)
		{
			if (form != null)
			{
				form.Close();
			}
		}

		public static string FormatliDeger(string deger)//Veriyi 100 =>100.00₺ ye çevirir
		{
			if (string.IsNullOrWhiteSpace(deger))
				return "";

			// Eğer değer zaten ₺ işareti ile bitiyorsa, sadece geri döndür
			if (deger.EndsWith("₺"))
				return deger;

			decimal degerDecimal = decimal.Parse(deger, NumberStyles.Currency, CultureInfo.GetCultureInfo("tr-TR"));
			return degerDecimal.ToString("N2") + "₺";
		}

		//Bunda hayla bir sorun var son eklenen ürünün türüne göre fotmatlıyor hepsini olması gereken şey her satırdaki MalzemeTur Sütununu okuyup o satırdaki tüm formatla işlemlerini burada okuduğu türe göre işlemlerini gerçekleştirmeli bu sayede grid içerisinde birden fazla Ture göre formatlama sağlanmalı
		public static void gridFormatStokMiktari(DataGridView dataGridView, string hedefSutunAdi)
		{
			// Olay dinleyicisini tanımlayalım
			DataGridViewCellFormattingEventHandler gridFormatStokMiktariHandler = null;

			// Olay dinleyicisini oluşturalım
			gridFormatStokMiktariHandler = (sender, args) =>
			{
				if (args.Value != null && args.Value != DBNull.Value && args.ColumnIndex == dataGridView.Columns[hedefSutunAdi].Index)
				{
					var row = dataGridView.Rows[args.RowIndex];
					var turValue = row.Cells["MalzemeTur"].Value?.ToString(); // Malzeme türünü al

					if (!string.IsNullOrEmpty(turValue))
					{
						decimal deger;
						if (decimal.TryParse(args.Value.ToString(), out deger)) // Decimal'e dönüşümü TryParse ile güvenli hale getirdik
						{
							string birim = "";

							switch (turValue)
							{
								case "Kg":
									birim = "Kg";
									deger = deger / 1000;
									break;
								case "Litre":
									birim = "Litre";
									deger = deger / 1000;
									break;
								case "Adet":
									birim = "Adet";

									break;
								default:
									birim = "";
									break;

							}
							string formatliDeger = BirimFormatı(deger, birim);
							args.Value = formatliDeger;


							args.FormattingApplied = true;

						}
					}
				}
			};

			// Olay dinleyicisini ekleyelim
			dataGridView.CellFormatting += gridFormatStokMiktariHandler;
		}

		public static string BirimFormatı(decimal deger, string birim)
		{
			string formatliDeger;

			// Adet birimiyse, ondalık kısmı kaldırarak formatla
			if (birim == "Adet")
				formatliDeger = Math.Round(deger).ToString();
			else
				formatliDeger = deger.ToString("N2"); // Diğer birimler için standart format

			// Birim ekle
			switch (birim)
			{
				case "Kg":
					formatliDeger += " Kg"; // Birim "Kg" ise sonuna "Kg" ekle
					break;
				case "Litre":
					formatliDeger += " L"; // Birim "Litre" ise sonuna "L" ekle
					break;
				case "Adet":
					formatliDeger += " Adet"; // Birim "Adet" ise sonuna "Adet" ekle
					break;
			}
			return formatliDeger;
		}


		public static decimal TemizleVeDondur(TextBox textBox, string birim)
		{
			string text = textBox.Text.Trim(); // Textbox'tan değeri alırken baştaki ve sondaki boşlukları temizle
			text = text.TrimEnd(' ', 'K', 'g', 'L', 'A', 'd', 'e', 't', '₺'); // Textbox'tan birim ifadesini temizle

			// Temizlenmiş değeri uygun formata dönüştür ve decimal türüne dönüştür
			decimal deger;
			if (decimal.TryParse(text, out deger))
			{
				//// Birim kontrolü yaparak değeri uygun şekilde dönüştürme
				//if (birim == "Kg" || birim == "Litre")
				//{
				//	deger = deger / 1000; // Gramı kilograma veya litreye dönüştürme
				//}
				// Diğer birimler için herhangi bir işlem yapmıyoruz, değeri değiştirmiyoruz
			}
			return deger;
		}

		public static string FormatsizDeger(string deger)
		{
			// Eğer kullanıcı sadece ₺ işaretini girdiyse, sadece nokta kaldıysa veya aradaki bir noktayı sildiyse, bunları temizleyerek döndür
			if (deger.Contains("₺"))
			{
				deger = deger.Replace("₺", "");
			}
			else if (deger.EndsWith("."))
			{
				deger = deger.Remove(deger.Length - 1); // Sondaki noktayı kaldır
			}
			else if (deger.Contains(".") && deger.LastIndexOf(".") < deger.LastIndexOf("₺"))
			{
				// Aradaki bir noktayı sildiyse ve bu nokta ₺ işaretinden önceyse, sadece bu noktayı kaldır
				deger = deger.Remove(deger.LastIndexOf("."));
			}

			// Formatlı değeri formatlı olmayan hale çevirerek döndür
			return decimal.Parse(deger, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands).ToString();
		}

		public static void GridFormat(DataGridView dataGridView, string columnName, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value != null && e.Value != DBNull.Value)
			{
				// Belirtilen sütun adında ise
				if (dataGridView.Columns[e.ColumnIndex].Name == columnName)
				{
					e.Value = ((decimal)e.Value).ToString("N2") + "₺"; // "N2" formatı ile iki basamaklı virgülden sonraki sayıları gösteriyoruz
					e.FormattingApplied = true;
				}
			}//Kullanışı
			 //private void urunGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
			 //{
			 //	FormatCurrencyColumn(urunGrid, "Satış_Fiyatı", e);
			 //}
		}

		public class ResimBoyutlandir
		{
			public static Image DosyaSec(PictureBox pictureBox, Label uzanti)
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.Filter = "PNG Dosyaları (*.png)|*.png|JPG Dosyaları (*.jpg)|*.jpg|Tüm Dosyalar (*.png, *.jpg)|*.png;*.jpg";
				fileDialog.FilterIndex = 1;
				fileDialog.RestoreDirectory = true;
				fileDialog.CheckFileExists = true;
				fileDialog.Title = "Dosya Seçiniz";

				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					// Seçilen fotoğrafı PictureBox'ta göster
					pictureBox.Image = Image.FromFile(fileDialog.FileName);

					// Resim uzantısını ve dosya yolunu göster
					pictureBox.Visible = true;
					uzanti.Text = fileDialog.FileName;

					return pictureBox.Image;
				}
				return null;
			}

			public static Image Boyutlandir(Image image, int width, int height)
			{
				if (image == null)
				{
					return null;
				}

				Bitmap boyutlandirilmisResim = new Bitmap(width, height);
				using (Graphics graphics = Graphics.FromImage(boyutlandirilmisResim))
				{
					graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					graphics.DrawImage(image, 0, 0, width, height);
				}

				return boyutlandirilmisResim;
			}

			public static Image DosyaYoluIleBoyutlandir(string dosyaYolu, int width, int height)
			{
				Image image = Image.FromFile(dosyaYolu);
				return Boyutlandir(image, width, height);
			}
		}

		public static bool HepsiDoluMu(GroupBox groupBox)
		{
			foreach (Control control in groupBox.Controls)
			{
				if (control is TextBox)
				{
					TextBox textBox = (TextBox)control;
					if (string.IsNullOrWhiteSpace(textBox.Text))
					{
						return false; // TextBox'ın içeriği boş veya sadece boşluk karakterlerinden oluşuyorsa false döndür
					}
				}
				if (control is ComboBox)
				{
					ComboBox comboBox = (ComboBox)control;
					if (string.IsNullOrWhiteSpace(comboBox.Text))
					{
						return false;
					}
				}
				if (control is MaskedTextBox)
				{
					MaskedTextBox masked = (MaskedTextBox)control;
					if (string.IsNullOrWhiteSpace(masked.Text))
					{
						return false;
					}
				}
				if (control is RichTextBox)
				{
					RichTextBox rich = (RichTextBox)control;
					if (string.IsNullOrWhiteSpace(rich.Text))
					{
						return false;
					}
				}
			}
			return true; // Tüm Her şey dolu ise true döndür
		}
	}
}
