using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Restoran_Otomasyon.Paneller
{
	public partial class KasaPaneli : Form
	{
		public KasaPaneli(int KullaniciID)
		{
			InitializeComponent();
			KullaniciId = KullaniciID;
		}
		int KullaniciId;
		Context db = new Context();
		string kullaniciAdi;
		string bakiye;

		private void KasaPaneli_Load(object sender, EventArgs e)
		{
			db.Dispose();
			db = new Context();
			var x = db.Kullanicilar.FirstOrDefault(o => o.Id == KullaniciId);
			if (x != null)
			{
				kullaniciAdi = x.Ad;
				Karsilama.Text = $"Merhaba,{kullaniciAdi}";
			}
			grafikleriGuncelle();
			Bildirimler();
		}
		public void Bildirimler()
		{
			BildirimYoneticisi.BildirimleriGetir(db, BildirimlerToolStrip, KullaniciId);
		}

		public void BakiyeHesapla()
		{
			db.Dispose();
			db = new Context();
			var kasabakiye = db.Kasalar.Find(1);
			bakiye = kasabakiye.Bakiye.ToString();
			Bakiyee.Text = Yardimcilar.FormatliDeger(bakiye);
			int sayi = bosluklar.Text.Length;
			if (sayi > 22)
			{
				if (Bakiyee.Text.Length == 6)
				{
					bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 2);
				}
				else if (Bakiyee.Text.Length == 8)
				{
					bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 4);
				}
				else if (Bakiyee.Text.Length > 8)
				{
					bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 6);
				}
			}
			this.Refresh();
		}

		private void girişSayfasıToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Giris girisSayfasi = new Giris();
			girisSayfasi.Show();
			this.Close();
		}

		private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void CalisanCRUD_Click(object sender, EventArgs e)
		{
			CalisanESG git = new CalisanESG(KullaniciId);
			git.Show();
		}

		private void UrunCRUD_Click(object sender, EventArgs e)
		{
			UrunList git = new UrunList();
			git.Show();
		}

		private void menüOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MenuListe git = new MenuListe();
			git.Show();
		}

		private void masaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MasaESG git = new MasaESG(KullaniciId);
			git.Show();
		}

		private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KasaFormu git = new KasaFormu();
			git.Show();
		}

		public void grafikleriGuncelle()
		{
			ComboFiltre.SelectedIndex = 0;
			Grafikler.DolulukGrafik(DolulukOranlari, db);
			BakiyeHesapla();
			string filteAd = ComboFiltre.Text;
			Grafikler.EnCokSiparisMenu(EnCokSiparisMenu, db, filteAd);
			Grafikler.EnCokSiparisUrun(EnCokSiparisUrun, db, filteAd);
			Grafikler.MasaYogunluk(MasaYogunluk, db, filteAd);
			Grafikler.GunlereGoreGrafik(GunlereGore, db, filteAd);
			Grafikler.OdemeYuzdesi(OdemeYuzde, db, filteAd);
			this.Refresh();
			//Invalidate();
		}

		private void bilgilerimiGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BilgileriGuncelle git = new BilgileriGuncelle(KullaniciId);
			git.Show();
		}

		private void ComboFiltre_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			string filteAd = ComboFiltre.Text;
			Grafikler.EnCokSiparisMenu(EnCokSiparisMenu, db, filteAd);
			Grafikler.EnCokSiparisUrun(EnCokSiparisUrun, db, filteAd);
			Grafikler.MasaYogunluk(MasaYogunluk, db, filteAd);
			Grafikler.GunlereGoreGrafik(GunlereGore, db, filteAd);
			Grafikler.OdemeYuzdesi(OdemeYuzde, db, filteAd);
		}

		private void BildirimKapat_Click(object sender, EventArgs e)
		{
			BildirimPanel.Visible = false;
			txtaciklama.Text = "";
			txtbaslik.Text = "";
			lblTarih.Text = "";
		}
	}
}
