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

namespace Restoran_Otomasyon.Paneller
{
	public partial class StokSayim : Form
	{
		public StokSayim()
		{
			InitializeComponent();
		}
		Context db = new Context();
		string tur;
		decimal stokmik;
		string formatlıStok;
		decimal kontrolEdilenStok;
		int malzemeId;
		int stokId;
		bool durum = false;
		decimal fark;
		StokGirdi girdi = new StokGirdi();
		StokCikti cikti = new StokCikti();
		int secilenIndex;
		void Malzemeler()
		{
			var malzemeler = db.Malzemeler.Where(o => o.Gorunurluk == true).ToList();
			malzemeListesi.DataSource = malzemeler;
			malzemeListesi.DisplayMember = "Ad";
			malzemeListesi.ValueMember = "Id";
		}

		private void StokSayim_Load(object sender, EventArgs e)
		{
			Malzemeler();
			ComboNeden.Items.Add("Bozuk");
			ComboNeden.Items.Add("Stok Uyuşmazlık");
			ComboNeden.Items.Add("Diğer");
		}

		private void malzemeListesi_SelectedIndexChanged(object sender, EventArgs e)
		{
			secilenIndex = malzemeListesi.SelectedIndex;
			var secilenMalzeme = (Malzeme)malzemeListesi.SelectedItem;
			if (secilenMalzeme != null)
			{
				malzemeId = secilenMalzeme.Id;
				hiddenMalzemeID.Text = malzemeId.ToString();
				tur = secilenMalzeme.Tur;

				var stok = db.Stoklar.FirstOrDefault(o => o.MalzemeId == secilenMalzeme.Id);
				stokId = stok.Id;
				stokmik = stok.Miktar;
				if (tur != "Adet")
				{
					stokmik = stokmik / 1000;
				}
				formatlıStok = Yardimcilar.BirimFormatı(stokmik, tur);
				VtStok.Text = formatlıStok;
			}
		}

		private void BtnEslesti_Click(object sender, EventArgs e)
		{
			if (kontrolEdilenStok == stokmik)
			{
				var secilenMalzeme = (Malzeme)malzemeListesi.SelectedItem;
				if (secilenMalzeme != null)
				{
					var malzemeler = (List<Malzeme>)malzemeListesi.DataSource;
					malzemeler.RemoveAt(secilenIndex);
					malzemeListesi.DataSource = null;
					malzemeListesi.DataSource = malzemeler;
					MessageBox.Show("Eşleşti");
					Temizle();
				}
			}
		}

		void Temizle()
		{
			VtStok.Text = "";
			ComboNeden.Text = "";
			EldekiStok.Text = "";
			hiddenMalzemeID.Text = "";
			hiddenstokId.Text = "";
		}

		private void EldekiStok_Leave(object sender, EventArgs e)
		{
			kontrolEdilenStok = decimal.Parse(EldekiStok.Text);
			if (kontrolEdilenStok > stokmik)//stokgirdisi ekle
			{
				ComboNeden.Items.Clear();
				ComboNeden.Items.Add("Stok Uyuşmazlık");
				ComboNeden.Items.Add("Diğer");
			}
			else if (kontrolEdilenStok == stokmik)
			{
				ComboNeden.Items.Clear();
			}
			else
			{
				ComboNeden.Items.Clear();
				ComboNeden.Items.Add("Stok Uyuşmazlık");
				ComboNeden.Items.Add("Bozuk");
				ComboNeden.Items.Add("Diğer");
			}
		}

		private void BtnGuncelle_Click(object sender, EventArgs e)//Burayı kontrol et
		{
			var x = db.Stoklar.FirstOrDefault(o => o.Id == stokId);
			if (kontrolEdilenStok > stokmik)//stokgirdisi ekle
			{
				fark = kontrolEdilenStok - stokmik;
				girdi.Miktar = fark;
				girdi.Neden = ComboNeden.Text;
				girdi.AlısFiyati = 0;
				girdi.Tarih = DateTime.Now;
				if (tur != "Adet")
				{
					girdi.SonStokMiktari = ((x.Miktar / 1000) + fark) * 1000;
				}
				else
				{
					girdi.SonStokMiktari = x.Miktar + fark;
				}
				x.Miktar = girdi.SonStokMiktari;
				girdi.MalzemeId = malzemeId;
				girdi.TedarikciId = x.TedarikciId;
				db.StokGirdiler.Add(girdi);
				db.SaveChanges();
				if (x.Malzeme.Tur != "Adet")
				{
					MessageBox.Show($"Yeni Stok Çıktısı Kayıt Edildi (Son Stok {x.Miktar / 1000 + " " + x.Malzeme.Tur})");
				}
				else
				{
					MessageBox.Show($"Yeni Stok Çıktısı Kayıt Edildi (Son Stok {x.Miktar + " " + x.Malzeme.Tur})");
				}
				
			}
			else if (kontrolEdilenStok == stokmik)
			{
				malzemeListesi.Items.Remove(secilenIndex);
			}
			else//stokçıktısı ekle
			{
				fark = stokmik - kontrolEdilenStok;
				cikti.Miktar = fark;
				cikti.Neden = ComboNeden.Text;
				cikti.Tarih = DateTime.Now;
				if (tur != "Adet")
				{
					cikti.SonStok = ((x.Miktar / 1000) - fark) * 1000;
				}
				else
				{
					cikti.SonStok = x.Miktar - fark;
				}
				x.Miktar = girdi.SonStokMiktari;
				cikti.Gorunuluk = true;
				cikti.MalzemeId = malzemeId;
				cikti.TedarikciId = x.TedarikciId;
				db.stokCiktilar.Add(cikti);
				db.SaveChanges();
				if (x.Malzeme.Tur != "Adet")
				{
					MessageBox.Show($"Yeni Stok Çıktısı Kayıt Edildi (Son Stok {x.Miktar/1000 +" "+x.Malzeme.Tur})");
				}
				else
				{
					MessageBox.Show($"Yeni Stok Çıktısı Kayıt Edildi (Son Stok {x.Miktar+ " " + x.Malzeme.Tur})");
				}
			}
			var secilenMalzeme = (Malzeme)malzemeListesi.SelectedItem;
			if (secilenMalzeme != null)
			{
				var malzemeler = (List<Malzeme>)malzemeListesi.DataSource;
				malzemeler.RemoveAt(secilenIndex);
				malzemeListesi.DataSource = null;
				malzemeListesi.DataSource = malzemeler;
				Temizle();
			}
		}

		private void EldekiStok_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(EldekiStok,sender,e);
		}

		private void EldekiStok_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(EldekiStok, e);
		}
	}
}
