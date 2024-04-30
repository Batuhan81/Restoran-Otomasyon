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
	public partial class StokCiktiSayfasi : Form
	{
		public StokCiktiSayfasi()
		{
			InitializeComponent();
		}
		Context db = new Context();
		private void StokCikti_Load(object sender, EventArgs e)
		{
			Malzemeler();
			Ciktilar();
		}

		void Ciktilar()
		{
			//Nden/malzemeadı/miktar/sonmiktar yeterli
			var stokCiktilar = db.stokCiktilar.OrderByDescending(s => s.Id)
											   .Select(o => new
											   {
												   Id = o.Id,
												   MalzemeAd = o.Malzeme.Ad,
												   Neden = o.Neden,
												   Miktar = o.Miktar,
												   SonStok = o.SonStok,
												   TedarikciAdi = o.Tedarikci.AdSoyad,
												   TedarikciId = o.TedarikciId,
												   MalzemeId = o.MalzemeId,
												   GirdiTarih = o.Tarih,
												   MalzemeTur = db.Malzemeler.Where(s => s.Id == o.MalzemeId).Select(x => x.Tur).FirstOrDefault(),
											   })
											   .ToList();
			gridCikti.DataSource = stokCiktilar;
			gridCikti.Columns["Id"].Visible = false;
			gridCikti.Columns["TedarikciId"].Visible = false;
			gridCikti.Columns["MalzemeId"].Visible = false;
			gridCikti.Columns["MalzemeTur"].Visible = false;
			gridCikti.Columns["TedarikciAdi"].Visible = false;
			gridCikti.Columns["GirdiTarih"].Visible = false;
		}

		private void Malzemeler()//Buna gerekli olan tüm sütunları ekleyeceğim 
		{
			var malzemeStokBilgileri = from malzeme in db.Malzemeler
									   join stok in db.Stoklar on malzeme.Id equals stok.MalzemeId
									   join tedarikci in db.Tedarikciler on stok.TedarikciId equals tedarikci.Id
									   where malzeme.Gorunurluk == true //Yalnızca Görünür olan malzemeleri listeler
									   select new
									   {
										   MalzemeId = malzeme.Id,
										   MalzemeAd = malzeme.Ad,
										   MalzemeTur = malzeme.Tur,
										   Tedarikci=stok.Tedarikci.AdSoyad,
										   TedarikciFirma=stok.Tedarikci.Firma,
										   StokMiktar = stok.Miktar,
										   StokMin = stok.MinStok,
										   StokMax = stok.MaxStok,
										   TedarikciId = tedarikci.Id, // Tedarikçi ID'sini gösteriyoruz
										   StokId = stok.Id,
									   };
			gridMalzemeler.DataSource = malzemeStokBilgileri.ToList();
			gridMalzemeler.Columns["MalzemeId"].Visible = false;
			gridMalzemeler.Columns["StokId"].Visible = false;
			gridMalzemeler.Columns["TedarikciId"].Visible = false;
			gridMalzemeler.Columns["MalzemeTur"].Visible = false;
		}

		private void gridMalzemeler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.gridFormatStokMiktari(gridMalzemeler, "StokMiktar");
			Yardimcilar.gridFormatStokMiktari(gridMalzemeler, "StokMin");
			Yardimcilar.gridFormatStokMiktari(gridMalzemeler, "StokMax");
		}
		StokCikti cikti = new StokCikti();
		int malzemeID;
		int stokID;
		int TedarikciID;
		int CiktiID;
		private void BtnCikti_Click(object sender, EventArgs e)
		{
			if (HiddenCiktiID.Text == "")
			{
				decimal miktar = Yardimcilar.TemizleVeDondur(txtmiktar, "");
				var stok = db.Stoklar.Find(stokID);
				cikti.Neden = ComboNeden.Text;
				cikti.Miktar = miktar;
				cikti.Gorunuluk = true;
				cikti.TedarikciId = TedarikciID;
				cikti.MalzemeId = malzemeID;
				cikti.Tarih = DateTime.Now;
				
				decimal islemSonu = ((stok.Miktar / 1000) - miktar) * 1000;
				if(islemSonu < 0)
				{
					MessageBox.Show("Eldeki Malzemeden Daha Fazla Çıktı Eklenemez","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				cikti.SonStok = islemSonu;
				stok.Miktar = islemSonu;
				db.stokCiktilar.Add(cikti);
				db.SaveChanges();
				MessageBox.Show("Stok Çıktısı Kayıt Edildi");
			}
			else
			{
				var stokCiktisi = db.stokCiktilar.Find(CiktiID);

				if (stokCiktisi != null)
				{
					// Malzeme bazında en son eklenen stok girdisini bul
					var SonStokCikti = db.stokCiktilar
											.Where(s => s.MalzemeId == malzemeID)
											.OrderByDescending(s => s.Id)
											.FirstOrDefault();

					// Güncellenmek istenen stok girdisi ID'si
					int sonStokCiktisiId = SonStokCikti.Id;

					// Eğer güncellenmek istenen stok girdisi en son eklenenle aynı değilse uyarı ver
					if (CiktiID != sonStokCiktisiId)
					{
						MessageBox.Show("Sadece En Son Eklenen Stok Çıktısını Güncelleyebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

						return; // İşlemi sonlandır
					}
					decimal miktar = Yardimcilar.TemizleVeDondur(txtmiktar, "");
					var stok = db.Stoklar.Find(stokID);
					var ciktib = db.stokCiktilar.Find(CiktiID);
					ciktib.Neden = ComboNeden.Text;
					ciktib.Miktar = miktar;
					ciktib.Gorunuluk = true;
					ciktib.TedarikciId = TedarikciID;
					ciktib.MalzemeId = malzemeID;
					ciktib.Tarih = DateTime.Now;
					stok.Miktar = (((stok.Miktar / 1000) + tiklandimiktar))*1000;

					decimal islemSonu = ((stok.Miktar / 1000)-miktar) * 1000;
					if (islemSonu < 0)
					{
						MessageBox.Show("Eldeki Malzemeden Daha Fazla Çıktı Eklenemez", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					ciktib.SonStok = islemSonu;
					stok.Miktar = islemSonu;
					db.SaveChanges();
					MessageBox.Show("Stok Çıktısı Güncellendi");
				}
			}
			Temizle();
			Malzemeler();
			Ciktilar();
		}
		void Temizle()
		{
			foreach (Control item in groupCikti.Controls)
			{
				if (item is TextBox)
				{
					item.Text = "";
				}
			}
		}
		string tur;
		decimal stok;
		private void gridMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			stokID = Convert.ToInt32(gridMalzemeler.CurrentRow.Cells["StokId"].Value.ToString());
			malzemeID = Convert.ToInt32(gridMalzemeler.CurrentRow.Cells["MalzemeId"].Value.ToString());
			TedarikciID = Convert.ToInt32(gridMalzemeler.CurrentRow.Cells["TedarikciID"].Value.ToString());
			tur = gridMalzemeler.CurrentRow.Cells["MalzemeTur"].Value.ToString();
			stok = Convert.ToDecimal(gridMalzemeler.CurrentRow.Cells["StokMiktar"].Value.ToString());
			hiddenTedarikciID.Text = TedarikciID.ToString();
			HiddenMalzemeID.Text = malzemeID.ToString();
			HiddenStokID.Text = stokID.ToString();
			if (tur != "Adet")
			{
				stok = stok / 1000;
			}
			txtstok.Text = Yardimcilar.BirimFormatı(stok, tur);
		}
		decimal tiklandimiktar;
		private void gridCikti_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			CiktiID=Convert.ToInt32(gridCikti.CurrentRow.Cells["Id"].Value.ToString());
			malzemeID = Convert.ToInt32(gridCikti.CurrentRow.Cells["MalzemeId"].Value.ToString());
			TedarikciID = Convert.ToInt32(gridCikti.CurrentRow.Cells["TedarikciID"].Value.ToString());
			ComboNeden.Text = gridCikti.CurrentRow.Cells["Neden"].Value.ToString();
			txtmiktar.Text = gridCikti.CurrentRow.Cells["Miktar"].Value.ToString();
			tiklandimiktar =Convert.ToDecimal( txtmiktar.Text);
			var stoklar = db.Stoklar.FirstOrDefault(o => o.MalzemeId == malzemeID);
			stokID = stoklar.Id;
			stok = stoklar.Miktar;
			hiddenTedarikciID.Text = TedarikciID.ToString();
			HiddenMalzemeID.Text = malzemeID.ToString();
			HiddenStokID.Text = stokID.ToString();
			HiddenCiktiID.Text = CiktiID.ToString();
			tur = db.Malzemeler.FirstOrDefault(o => o.Id == malzemeID).Tur;
			if (tur != "Adet")
			{
				stok = stok / 1000;
			}
			txtstok.Text = Yardimcilar.BirimFormatı(stok, tur);
			
		}

		private void gridCikti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.gridFormatStokMiktari(gridCikti, "SonStok");
		}
	}
}
