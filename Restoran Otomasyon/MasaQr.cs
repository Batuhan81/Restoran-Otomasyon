using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public partial class MasaQr : Form
	{
		public MasaQr(int masaID)
		{
			InitializeComponent();
			masaId = masaID;
		}
		int masaId;
		Context db = new Context();

		private void MasaQr_Load(object sender, EventArgs e)
		{
			var masa = db.Masalar.Find(masaId);
			if (masa != null)
			{
				try
				{
					label1.Text = $"{masa.Kod}'nolu masanın Qr Kodu";
					//Masanın Qrını gösterme
					Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(masa.Qr, pictureBox1.Width, pictureBox1.Height);
					pictureBox1.Image = resizedImage;
					pictureBox1.Visible = true;
				}
				catch
				{
					string dosyayolu = Yardimcilar.KareKodOlustur(masa.Kod);
					MessageBox.Show($"Masa Qr'ı Bulunamadı Yeniden Oluşturup Kayıt Ediliyor.(Şuraya Kayıt Edildi=>{dosyayolu})");
					masa.Qr = dosyayolu;
					db.SaveChanges();
					label1.Text = $"{masa.Kod}'nolu masanın Qr Kodu";
					//Masanın Qrını gösterme
					Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(masa.Qr, pictureBox1.Width, pictureBox1.Height);
					pictureBox1.Image = resizedImage;
					pictureBox1.Visible = true;
				}
				
			}
			else
			{
				// Masa bulunamadı veya null olarak döndü
				MessageBox.Show("Masa bulunamadı.");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

			var masa = db.Masalar.Find(masaId);
			if (masa != null && !string.IsNullOrEmpty(masa.Qr))
			{
				// QR kodu dosya yolundan oku
				try
				{
					byte[] qrBytes = File.ReadAllBytes(masa.Qr);
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
					saveFileDialog.FileName = masa.Kod + "_QR.png";
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						// Dosyayı kaydet
						File.WriteAllBytes(saveFileDialog.FileName, qrBytes);
						MessageBox.Show("QR kod başarıyla kaydedildi.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("QR kodu kaydederken bir hata oluştu: " + ex.Message);
				}
			}
			else
			{
				string dosyayolu = Yardimcilar.KareKodOlustur(masa.Kod);

				MessageBox.Show($"Masa Qr'ı Bulunamadı Yeniden Oluşturup Kayıt Ediliyor.(Şuraya Kayıt Edildi=>{dosyayolu})");
				masa.Qr = dosyayolu;
				db.SaveChanges();
			}
		}
	}
}
