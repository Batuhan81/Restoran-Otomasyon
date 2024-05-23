using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Restoran_Otomasyon
{
	public partial class SifremiUnuttum : Form
	{
		public SifremiUnuttum()
		{
			InitializeComponent();
		}
		string email;
		string secilen;
		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex != -1)//Bir talep seçildiyse maili gönder
			{
				email = txtmail.Text;
				string adminEposta = db.Kullanicilar.Find(1).Mail;
				if (adminEposta == email)
				{
					SifreGonder(email);
					timer1.Start();
					MessageBox.Show("Yeni Şifreniz Mail Yolu İle İletilmiştir Lütfen Kontrol Edininiz...","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					MessageBox.Show("Şifre Sıfırlama Mailleri Yalnızca Yöneticilere Gönderilebilir Lütfen Yöneticinizle İletişime Geçiniz!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Lütfen Bir Talep Seçin");
			}
		}
		Context db = new Context();
		int eslesenKayit;
		void SifreGonder(string mail)
		{
			secilen = comboBox1.Text;
			//girilen maile kod gidecek ama kullanıcı kontorlü yok gelen talebe göre şifre değişecek
			if (secilen == "")
			{
				MessageBox.Show("Öncelikle Bir Talep Seçmeniz Gerekmektedir.");
			}
			else
			{

				// Yeni random şifre oluştur
				eslesenKayit = db.Kullanicilar.Count(k => k.Ad == secilen);
				if (eslesenKayit > 0)
				{
					string yeniSifre = RandomSifreOlustur(8);//8 haneli random bir şifre oluştur

					// Kullanıcının şifresini güncelle
					SifreyiGuncelle(secilen, yeniSifre);
					// Yeni şifreyi kullanıcının e-posta adresine gönder
					EpostaGonder(email, yeniSifre, secilen);
				}
				else
				{
					MessageBox.Show("Bu Ada Sahip Bir Kullanıcı Henüz Eklenmemiş");
				}
			}
		}
		// Yalnızca rakamkardan oluşan 8 haneli random bir şifre oluşturur
		public static string RandomSifreOlustur(int uzunluk)//default 8 verdim
		{
			const string karakterler = "0123456789";
			StringBuilder sb = new StringBuilder();
			Random rnd = new Random();
			for (int i = 0; i < uzunluk; i++)
			{
				int index = rnd.Next(karakterler.Length);
				sb.Append(karakterler[index]);
			}
			return sb.ToString();
		}

		public void SifreyiGuncelle(string secilen, string yeniSifre)//seçilen kullanıcının şifresini rendom şifreyle değiştir
		{
			var x = db.Kullanicilar.FirstOrDefault(o => o.Ad == secilen);
			if (x != null)
			{
				x.Sifre = yeniSifre;
			}
			else
			{
				MessageBox.Show("Kişi Bilgisi Bulunamadı");
			}
			db.SaveChanges();
		}

		// E-posta gönderme işlevi
		public static void EpostaGonder(string alici, string yeniSifre, string talep)
		{
			string gonderenEposta = "OrtakProje2@outlook.com";
			string gonderenSifre = "Bthn185Prj";
			string konu = "Yeni Şifre";
			string icerik = $"Yeni şifreniz:({talep}) " + yeniSifre;

			SmtpClient smtp = new SmtpClient();
			smtp.Port = 587;
			smtp.Host = "smtp.office365.com";
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential(gonderenEposta, gonderenSifre);

			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(gonderenEposta, $"Yeni Şifre Talebi({talep})");
			mail.To.Add(alici);
			mail.Subject = konu;
			mail.IsBodyHtml = true;
			mail.Body = icerik;
			smtp.Send(mail);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("ESC");
		}
	}
}
