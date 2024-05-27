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
		public MasaBilgiGuncelle(int MasaID,int kullaniciID)
		{
			InitializeComponent();
			masaId = MasaID;
			kullaniciId = kullaniciID;
		}
		int masaId;
		int kullaniciId;
		int personelId;
		Context db = new Context();
		private void MasaBilgiGuncelle_Load(object sender, EventArgs e)
		{
			if (kullaniciId != 1)
			{
				button2.Visible= false;
				button3.Visible= false;
				button1.Location=new Point(321, 100);
				button4.Location=new Point(321, 200);
			}
			Yukle();
		}

		private void Yukle()
		{
			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);
			if (txtDurum.Text == "Kapalı")
			{
				button3.ImageKey = "Aç.png";
			}
			else
			{
				button3.ImageKey = "Kapalı.png";
			}
			ilkAd = txtmasaadi.Text;
		}

		string ilkAd;
		private void button1_Click(object sender, EventArgs e)
		{
			bool eslesti = false;
			if (ilkAd != txtmasaadi.Text)
			{
				var eslesen = db.Masalar.FirstOrDefault(o => o.Kod == txtmasaadi.Text);
				if (eslesen == null)
				{
					eslesti = false;
				}
				else
				{
					eslesti = true;
				}
			}

			if (eslesti == false)
			{
				DialogResult result = MessageBox.Show("Masa Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{


					var masa = db.Masalar.Find(masaId);

					var masasiparis = db.MasaSiparisler.Where(s => s.MasaId == masaId)
										 .OrderByDescending(s => s.Id)
										 .FirstOrDefault();

					masa.Kod = txtmasaadi.Text;
					masa.Kapasite = Convert.ToInt32(txtkapasite.Text);
					string dosyaYolu = Yardimcilar.KareKodOlustur(masa.Kod);
					masa.Qr = dosyaYolu;
					if (masasiparis != null)//Masaya Sipariş Verilmediysee es geç
					{
						masasiparis.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
						masasiparis.OdenenTutar = Yardimcilar.TemizleVeDondur(txtodenen, "");
					}
					if (personelId == 0)
					{
						masa.PersonelId = null;
					}
					else
					{
						masa.PersonelId = personelId;
					}
					db.SaveChanges();
					MessageBox.Show("Güncelleme İşlemi Başarılı");

				}
				else
				{
					Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);
				}
			}
			else
			{
				MessageBox.Show("Bu Masa Adına Sahip Bir Masa Zaten Kayıtlı !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				eslesti = false;
				Yukle();
				return;
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
					MessageBox.Show("Masa Başarıyla Silindi");
					Yardimcilar.SignalTetikleMasaDurum();
					this.Close();
				}
				else
				{
					MessageBox.Show($"Masa Silme İşlemi İçin Masa Durumunun Boş Olması ve İleri Tarihli Bir Rezervasyonun Olmaması Gerekir!", "İşlem Gerçekleştirilemez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				MessageBox.Show("Masa Bilgisi Bulunmadı","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// İleri tarihli bir rezervasyonun olup olmadığını kontrol eden metod
		private bool IleriTarihliRezervasyonVar(int masaId)
		{
			// İleri tarihli bir rezervasyon kontrolü için gereken işlemleri yapın
			var ileriTarihliRezervasyon = db.MasaRezervasyonlar.Any(o => o.MasaId == masaId &&
				(o.Rezervasyon.Tarih > DateTime.Today ||
				(o.Rezervasyon.Tarih == DateTime.Today && o.Rezervasyon.BitisSaat.Hours > DateTime.Now.Hour) ||
				(o.Rezervasyon.Tarih == DateTime.Today && o.Rezervasyon.BitisSaat.Hours == DateTime.Now.Hour && o.Rezervasyon.BitisSaat.Minutes > DateTime.Now.Minute) ||
				(o.Rezervasyon.Tarih == DateTime.Today && o.Rezervasyon.BitisSaat.Hours == DateTime.Now.Hour && o.Rezervasyon.BitisSaat.Minutes == DateTime.Now.Minute && o.Rezervasyon.BitisSaat.Seconds > DateTime.Now.Second)));


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

			if (masa.Durum == 2 || masa.Durum == 4)
			{
				MessageBox.Show("Masa kapatma işlemi için masa durumunun boş veya kapalı olması gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (masa.Durum == 1 || masa.Durum == 3)
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

		private void txtodenen_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtodenen, sender, e);
		}

		private void txtodenen_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtodenen, e);
		}

		private void txttutar_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txttutar, sender, e);
		}

		private void txttutar_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txttutar, e);
		}
	}
}
