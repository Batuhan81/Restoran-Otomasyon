using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Restoran_Otomasyon.Paneller
{
	public partial class Admin_Paneli : Form
	{
		public Admin_Paneli(int KullaniciID)
		{
			InitializeComponent();
			KullaniciId = KullaniciID;
		}

		int KullaniciId;
		string kullaniciAdi;
		string bakiye;
		Context db = new Context();

		private void CalisanCRUD_Click(object sender, EventArgs e)
		{
			CalisanESG git = new CalisanESG(KullaniciId);
			git.Show();
		}

		private void CalisanRol_Click(object sender, EventArgs e)
		{
			RolESG git = new RolESG();
			git.Show();
		}

		private void TedarikciCRUD_Click(object sender, EventArgs e)
		{
			TedarikciESG git = new TedarikciESG();
			git.Show();
		}

		private void UrunCRUD_Click(object sender, EventArgs e)
		{
			UrunESG git = new UrunESG();
			git.Show();
		}

		private void KategoriESG(object sender, EventArgs e)
		{
			KategoriESG git = new KategoriESG(0);
			git.Show();
		}

		private void MasaESG(object sender, EventArgs e)
		{
			MasaESG git = new MasaESG(KullaniciId);
			git.Show();
		}

		private void MasaOzellik(object sender, EventArgs e)
		{
			OzellikESG git = new OzellikESG();
			git.Show();
		}

		private void malzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MalzemeESG git = new MalzemeESG();
			git.Show();
		}

		private void MenuESG(object sender, EventArgs e)
		{
			MenuESG git = new MenuESG();
			git.Show();
		}

		private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KasaFormu git = new KasaFormu();
			git.Show();
		}

		private void Admin_Paneli_Load(object sender, EventArgs e)
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

			if (Bakiyee.Text.Length == 6)
			{
				bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 2);
			}
			else if (Bakiyee.Text.Length == 8)
			{
				bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 5);
			}
			else if (Bakiyee.Text.Length > 8)
			{
				bosluklar.Text = bosluklar.Text.Substring(0, bosluklar.Text.Length - 8);
			}
			Bildirimler();
		}
		public void Bildirimler()
		{
			BildirimYoneticisi.BildirimleriGetir(db, BildirimlerToolStrip, KullaniciId);
		}
		public void bakiyeHesapla()
		{
			db.Dispose();
			db = new Context();
			var kasabakiye = db.Kasalar.Find(1);
			bakiye = kasabakiye.Bakiye.ToString();
			Bakiyee.Text = Yardimcilar.FormatliDeger(bakiye);
			this.Refresh();
		}

		public void grafikleriGuncelle()
		{
			bakiyeHesapla();
			ComboFiltre.SelectedIndex = 0;
			string filteAd = ComboFiltre.Text;
			Grafikler.EnCokSiparisMenu(EnCokSiparisMenu, db, filteAd);
			Grafikler.EnCokSiparisUrun(EnCokSiparisUrun, db, filteAd);
			Grafikler.MasaYogunluk(MasaYogunluk, db, filteAd);
			Grafikler.GunlereGoreGrafik(GunlereGore, db, filteAd);
			Grafikler.OdemeYuzdesi(OdemeYuzde, db, filteAd);
			Grafikler.DolulukGrafik(DolulukOranlari, db);
			this.Refresh();
		}

		private void GirisSayfasi(object sender, EventArgs e)
		{
			Giris girisSayfasi = new Giris();
			girisSayfasi.Show();
			KomplemiCikiliyor = false;
			this.Close();
		}

		private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KomplemiCikiliyor = true;
			Application.Exit();
		}

		private void BilgilerimiGuncelle(object sender, EventArgs e)
		{
			BilgileriGuncelle git = new BilgileriGuncelle(KullaniciId);
			git.Show();
		}

		private void MusteriList(object sender, EventArgs e)
		{
			MusteriListesi git = new MusteriListesi(1);
			git.Show();
		}

		private void KayitsizMusteriList(object sender, EventArgs e)
		{
			MusteriListesi git = new MusteriListesi(2);
			git.Show();
		}

		private void KasaGuncelle(object sender, EventArgs e)
		{
			BilgileriGuncelle git = new BilgileriGuncelle(2);//2 nolu kullanıcı Kasa oluyor
			git.Show();
		}

		private void MutfakBilgiGuncelle(object sender, EventArgs e)
		{
			BilgileriGuncelle git = new BilgileriGuncelle(3);//3 nolu kullanıcı Mutfak oluyor
			git.Show();
		}

		private void DisariyaSiparis(object sender, EventArgs e)
		{
			DisariSiparis git = new DisariSiparis();
			git.Show();
		}

		private void ComboFiltre_SelectedIndexChanged(object sender, EventArgs e)
		{
			string filteAd = ComboFiltre.Text;
			Grafikler.EnCokSiparisMenu(EnCokSiparisMenu, db, filteAd);
			Grafikler.EnCokSiparisUrun(EnCokSiparisUrun, db, filteAd);
			Grafikler.MasaYogunluk(MasaYogunluk, db, filteAd);
			Grafikler.GunlereGoreGrafik(GunlereGore, db, filteAd);
			Grafikler.OdemeYuzdesi(OdemeYuzde, db, filteAd);
		}
		bool KomplemiCikiliyor = true;
		private void Admin_Paneli_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (KomplemiCikiliyor == true)
			{
				DialogResult result = MessageBox.Show("Bu Panel Kapatıldığı Zaman Tüm Projeyle Beraber SignalR Sunucusuda Kapatılacaktır Emin Misiniz ? ", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					try
					{
						Yardimcilar.signalRProcess.Kill();
					}
					catch /*(Exception ex)*/
					{
						//MessageBox.Show(ex.ToString());
						;
					}
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

		private void Bildirimler_Click(object sender, EventArgs e)
		{

		}

		private void stokGirdiToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			StokGirdiESG git = new StokGirdiESG();
			git.Show();
		}

		private void StokCiktiToolStrip(object sender, EventArgs e)
		{
			StokCiktiSayfasi git = new StokCiktiSayfasi();
			git.Show();
		}

		private void StokSayimToolStrip_Click(object sender, EventArgs e)
		{
			StokSayim git = new StokSayim();
			git.Show();
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
