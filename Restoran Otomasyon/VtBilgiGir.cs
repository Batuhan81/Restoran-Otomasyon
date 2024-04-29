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

		private void button1_Click(object sender, EventArgs e)
		{ 
			Context c=new Context();
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
				c.Database.Connection.ConnectionString = vt.yeniBağlantıDizesi;//Bağlantı Dizesini yenisiyle değiştirdim
				try
				{
					if (!c.Database.Exists()) // Veritabanı yoksa
					{
						c.Database.Create(); // Yeni bir veritabanı oluştur
						MessageBox.Show("Veri Tabanı Oluşturuldu.");
						MessageBox.Show("Tekrar Giriş Sayfasına Yönlendirileceksiniz.");
						this.Close();
					}
					else
					{
						MessageBox.Show("Girdiğiniz isimde bir veritabanı zaten mevcut.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Veri Tabanı Oluşturulurken Bir Hata Oluştu. Bilgileri Doğru Girdiğinizden Emin Olunuz.\nHata Mesajı: " + ex.InnerException.Message, "Veri Tabanı Oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Tüm Bilgileri Girmeden Bir VeriTabanı Oluşturamazsınız.");
			}
		}
	}
}
