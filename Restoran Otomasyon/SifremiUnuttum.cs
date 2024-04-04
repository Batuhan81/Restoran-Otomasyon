﻿using Restoran_Otomasyon.Data;
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
			if (comboBox1.SelectedIndex != -1)
			{
				email = txtmail.Text;
				SifreGonder(email);
				if (eslesenKayit != 0)
				{
					timer1.Start();
					MessageBox.Show("Yeni Şifreniz Mail Yolu İle İletilmiştir Lütfen Kontrol Edininiz...");
					this.Close();
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
			//girilen maile kod gidecek ama kullanıcı kontorlü yok gelen talebe göre şifre değişecek
			if (secilen == "")
			{
				MessageBox.Show("Öncelikle Bir Talep Seçmeniz Gerekmektedir.");
			}
			else
			{
				secilen = comboBox1.Text;
				// Yeni random şifre oluştur
				 eslesenKayit= db.Kullanicilar.Count(k=>k.Ad ==secilen);
				if(eslesenKayit > 0)
				{
					string yeniSifre = RandomSifreOlustur(8);

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
		// Yeni bir random şifre oluştur
		public static string RandomSifreOlustur(int uzunluk)
		{//ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
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
		// Kullanıcı şifresini güncelleme işlevi
		public void SifreyiGuncelle(string secilen, string yeniSifre)
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
		public static void EpostaGonder(string alici, string yeniSifre,string talep)
		{
			string gonderenEposta = "OrtakProje2@outlook.com";
			string gonderenSifre = "Bthn185Prj";
			string konu = "Yeni Şifre";
			string icerik = "Yeni şifreniz: " + yeniSifre;

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
	}
}
