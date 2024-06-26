﻿using Restoran_Otomasyon.Data;
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
	public partial class Giris : Form
	{
		public Giris()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)//Bilgileri Alıp metoda yönlendir
		{
			string Ad = txtAd.Text;
			string Sifre = txtsifre.Text;
			GirisYap(Ad, Sifre);
		}
		Context db = new Context();
		int ıd;
		public void GirisYap(string Ad, string Sifre)//gelen ad ve şifre bilgisine göre kullanıyı ilgili panele yönlendir
		{
			db.Dispose();
			db = new Context();
			var kullanici = db.Kullanicilar.FirstOrDefault(o => o.Ad == Ad && o.Sifre == Sifre);
			if (kullanici != null)
			{
				ıd = kullanici.Id;

				if (kullanici.Ad == "Kasa")
				{
					KasaPaneli git = new KasaPaneli(ıd);
					git.Show();
					this.Close();
				}
				else if (kullanici.Ad == "Admin")
				{
					Yardimcilar.SignalRSunucuBaslat();
					Admin_Paneli git = new Admin_Paneli(ıd);
					git.Show();
					this.Close();
				}
				else if (kullanici.Ad == "Mutfak")
				{
					MutfakPaneli git = new MutfakPaneli(ıd);
					git.Show();
					this.Close();
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Kullanıcı Bulunamadı Lütfen Bilgileri Kontrol Ediniz");
				}
				Yardimcilar.ConnectToSignalR();
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Kullanıcı Bulunamadı Lütfen Bilgileri Kontrol Ediniz");
			}
		}

		Kullanici k = new Kullanici();
		private void Giris_Load(object sender, EventArgs e)
		{
			txtAd.Focus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//şifre işlemleri için ilgili sayfaya yönlendirme
		{
			SifremiUnuttum git = new SifremiUnuttum();
			git.Show();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Yardimcilar.GeriCik(timer1);
		}
	}
}
