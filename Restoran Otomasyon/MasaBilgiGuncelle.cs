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
	public partial class MasaBilgiGuncelle : Form
	{
		public event EventHandler FormClosedEvent;
		public MasaBilgiGuncelle(int MasaID)
		{
			InitializeComponent();
			masaId = MasaID;
		}
		int masaId;
		int personelId;
		Context db = new Context();
		private void MasaBilgiGuncelle_Load(object sender, EventArgs e)
		{
			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, db);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Masa Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				var masa = db.Masalar.Find(masaId);
				masa.Kod = txtmasaadi.Text;
				masa.Kapasite = Convert.ToInt32(txtkapasite.Text);
				string dosyaYolu = Yardimcilar.KareKodOlustur(masa.Kod);
				masa.Qr = dosyaYolu;
				masa.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
				masa.OdenenTutar = Yardimcilar.TemizleVeDondur(txtodenen, "");
				if (personelId == 0)
				{
					masa.PersonelId = null;
				}
				else
				{
					masa.PersonelId = personelId;
				}
				db.SaveChanges();
			}
			else
			{
				Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, db);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var masa = db.Masalar.Find(masaId);
			if (masa != null)
			{
				// Masa durumu boşsa ve ileri tarihli bir rezervasyon yoksa
				if (masa.Durum == 1 && !IleriTarihliRezervasyonVar(masaId))
				{
					masa.Gorunurluk = false; // Masa silme işlemi
					db.SaveChanges();
				}
				else
				{
					MessageBox.Show($"Masa Silme İşlemi İçin Masa Durumunun Boş Olması ve İleri Tarihli Bir Rezervasyonun Olmaması Gerekir!", "İşlem Gerçekleştirilemez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		// İleri tarihli bir rezervasyonun olup olmadığını kontrol eden metod
		private bool IleriTarihliRezervasyonVar(int masaId)
		{
			// İleri tarihli bir rezervasyon kontrolü için gereken işlemleri yapın
			var ileriTarihliRezervasyon = db.MasaRezervasyonlar.Any(o => o.MasaId == masaId && o.Rezervasyon.BitisSaat > DateTime.Now);
			return ileriTarihliRezervasyon;
		}
		private void button3_Click(object sender, EventArgs e)
		{
			var masa = db.Masalar.Find(masaId);

			if (masa == null)
			{
				MessageBox.Show("Masa bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (masa.Durum == 2 || masa.Durum == 3 || masa.Durum == 4)
			{
				MessageBox.Show("Masa kapatma işlemi için masa durumunun boş veya kapalı olması gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (masa.Durum == 1)
			{
				if (IleriTarihliRezervasyonVar(masaId))
				{
					MessageBox.Show("Masa kapatma işlemi için ileri tarihli bir rezervasyon olmamalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				masa.Durum = 5; // Masa Kapatma işlemi
				MessageBox.Show("Masa kapatıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (masa.Durum == 5)
			{
				masa.Durum = 1; // Masa Açma işlemi
				MessageBox.Show("Masa açıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			db.SaveChanges();

			// Masa butonlarını güncelle
			MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
			if (calisanForm != null)
			{
				calisanForm.MasaButonlariniGuncelle();
			}
			this.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var masa = db.Masalar.Find(masaId);
			if (masa.Durum == 3)
			{
				masa.Durum = 1;
				MessageBox.Show("Masa Durumu Temiz Olarak Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Yalnızca Kirli Masaların Durumu Temiz Olarak Ayarlanabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			db.SaveChanges();
			// Masa butonlarını güncelle
			MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
			if (calisanForm != null)
			{
				calisanForm.MasaButonlariniGuncelle();
			}
			this.Close();
		}
	}
}
