using System;
using System.Collections.Generic;
using System.Drawing;
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

		public class SecilenAdres
		{
			public int AdresId { get; set; }
			public string AdresBilgisi { get; set; }
			public string AdresTarif { get; set; }
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
