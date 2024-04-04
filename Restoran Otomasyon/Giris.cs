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
	public partial class Giris : Form
	{
		public Giris()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string Ad=txtAd.Text;
			string Sifre=txtsifre.Text;
			GirisYap(Ad, Sifre);
		}
		Context db = new Context();
		public void GirisYap(string Ad,string Sifre)
		{
			var kullanici = db.Kullanicilar.FirstOrDefault(o => o.Ad == Ad && o.Sifre == Sifre);
			if (kullanici != null)
			{
				if (kullanici.Ad == "Kasa")
				{
					//kasa paneli
				}
				else if(kullanici.Ad == "Admin")
				{
					//Admin Paneli
					MessageBox.Show("Admin paneli");
				}
				else if (kullanici.Ad == "Mutfak")
				{
					//mutfak Paneli
				}
				else
				{
					MessageBox.Show("Kullanıcı Bulunamadı Lütfen Bilgileri Kontrol Ediniz");
				}
			}
			else
			{
				MessageBox.Show("Kullanıcı Bulunamadı Lütfen Bilgileri Kontrol Ediniz");
			}
		}

		Kullanici k = new Kullanici();
		private void Giris_Load(object sender, EventArgs e)
		{
			if (!db.Kullanicilar.Any())
			{
				k.Ad = "Admin";
				k.Sifre = "admin123";
				db.Kullanicilar.Add(k);
				db.SaveChanges();
			}
			else
			{
				;
			}
			txtAd.Focus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SifremiUnuttum git=new SifremiUnuttum();
			git.Show();
		}
	}
}
