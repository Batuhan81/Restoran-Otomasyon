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

namespace Restoran_Otomasyon
{
	public partial class VtBilgiGir : Form
	{
		public VtBilgiGir()
		{
			InitializeComponent();
		}
		private static Context db;
		private void button1_Click(object sender, EventArgs e)
		{
			db = new Context();
			VtBilgileri vt = new VtBilgileri();
			if (Yardimcilar.HepsiDoluMu(groupBox1))//veritabanı oluşturmak için gerekli tüm bilgiler girilimi kontrolü
			{
				// Kullanıcı tarafından girilen bağlantı bilgilerini al
				vt.DatabaseAdi = DbAdi.Text;
				vt.Port = Convert.ToInt32(port.Text);
				vt.VtSifre = VtSifre.Text;
				vt.UserBilgisi = UserAdi.Text;
				vt.ServerAdi = svAdi.Text;

				// Bağlantı dizesini ayarla
				//string svad, int port, string dbad,string user,string sifre
				vt.BağlantıDizesiniAyarla(svAdi.Text, Convert.ToInt32(port.Text), DbAdi.Text, UserAdi.Text, VtSifre.Text);
				db.Database.Connection.ConnectionString =vt.yeniBağlantıDizesi;//Bağlantı Dizesini yenisiyle değiştirdim
					 //db.Database.Connection.ConnectionString = vt.yeniBağlantıDizesi;//Bağlantı Dizesini yenisiyle değiştirdim
				try
				{
					if (!db.Database.Exists()) // Veritabanı yoksa
					{
						timer1.Start();
						MessageBox.Show("Veri Tabanı Oluşturuluyor İşlem Biraz Zaman Alabilir.");
						db.Database.Create(); // Yeni bir veritabanı oluştur
						if (!db.Kullanicilar.Any())
						{
							// Eklemek istediğiniz kullanıcı adları ve şifreler
							string[] kullaniciAdlari = { "Admin", "Kasa", "Mutfak" };
							string[] sifreler = { "admin123", "kasa123", "mutfak123" };

							// Kullanıcı adları ve şifreleri dizilerinin uzunluğu kadar döngüyü çalıştır
							for (int i = 0; i < kullaniciAdlari.Length; i++)
							{
								// Yeni bir Kullanici nesnesi oluşturun
								Kullanici k = new Kullanici();
								// Kullanıcı adını ve şifreyi dizi elemanlarından alın
								k.Ad = kullaniciAdlari[i];
								k.Sifre = sifreler[i];
								k.Gorunurluk = true;

								// Kullanıcıyı veritabanına ekleyin
								db.Kullanicilar.Add(k);
							}
							Kasa kasa = new Kasa();
							kasa.Bakiye = 0;
							db.Kasalar.Add(kasa);
							db.SaveChanges();
						}
						else
						{
							;
						}
						timer1.Start();
						MessageBox.Show("Veri Tabanı Oluşturuldu.");
						timer1.Start();
						MessageBox.Show("Tekrar Giriş Sayfasına Yönlendirileceksiniz.");
						this.Close();
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Girdiğiniz isimde bir veritabanı zaten mevcut.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Veri Tabanı Oluşturulurken Bir Hata Oluştu. Bilgileri Doğru Girdiğinizden Emin Olunuz.\nHata Mesajı: " + ex.InnerException.Message, "Veri Tabanı Oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Tüm Bilgileri Girmeden Bir VeriTabanı Oluşturamazsınız.");
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Yardimcilar.GeriCik(timer1);
		}
	}
}
