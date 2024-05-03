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
	public partial class RandevuMasa : Form
	{
		public RandevuMasa(int masaID)
		{
			InitializeComponent();
			masaId = masaID;
		}
		int masaId;

		private void RandevuMasa_Load(object sender, EventArgs e)
		{
			Takvim.MinDate = DateTime.Now;
			Takvim.MaxDate = DateTime.Now.AddMonths(3);
			GUnlereRenkVerme();
			Yardimcilar.GridRenklendir(gridRandevular);
			RandevulariYukle();
			comboOnay.SelectedIndex = 0;
		}
		int secilenSaat;
		int secilendakika;
		DateTime secilentarih;
		void RandevulariYukle()
		{
			// Masaya ait rezervasyonları veritabanından al
			var masaninRandevulari = db.MasaRezervasyonlar
				.Where(x => x.MasaId == masaId &&  x.Rezervasyon.Tarih >= DateTime.Today)
				.Select(x => new
				{
					RezervasyonID = x.Rezervasyon.Id,
					Tarih = x.Rezervasyon.Tarih,
					BaslangicSaat = x.Rezervasyon.BaslangicSaat,
					BitisSaat = x.Rezervasyon.BitisSaat,
					KisiSayisi = x.Rezervasyon.KisiSayisi,
					Talep = x.Rezervasyon.Talep,
					Durum = x.Rezervasyon.Onay == 1 ? "Onay Bekliyor" :
					 x.Rezervasyon.Onay == 2 ? "Onaylandı" :
					 x.Rezervasyon.Onay == 3 ? "Gerçekleşti" :
					 x.Rezervasyon.Onay == 4 ? "İptal Edildi" :
					 x.Rezervasyon.Onay == 5 ? "Onaylanmadı" :
					 x.Rezervasyon.Onay == 6 ? "Gelmedi" : "Bilinmeyen"
				})
				.ToList();

			// Verileri datagridview'e yükle
			gridRandevular.DataSource = masaninRandevulari;
			gridRandevular.Columns["RezervasyonID"].Visible = false;

		}

		private void ComboSaat_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Seçilen saat değerini al
			secilenSaat = Convert.ToInt32(ComboSaat.SelectedItem);

			// ComboBitisSaat kontrolünü temizle
			bitisSaat.Items.Clear();

			// Seçilen saatten sonraki saat değerlerini ComboBitisSaat'e ekle
			if (secilenSaat == 24)
			{
				secilenSaat = 1;
			}
			for (int i = secilenSaat; i <= 24; i++)
			{
				bitisSaat.Items.Add(i);
			}
		}

		private void ComboDakika_SelectedIndexChanged(object sender, EventArgs e)
		{
			secilendakika = Convert.ToInt32(ComboDakika.SelectedItem);

		}
		void GUnlereRenkVerme()
		{
			Takvim.RemoveAllBoldedDates(); // Önceki vurgulamaları kaldır
			// Tüm rezervasyonları al
			var rezervasyonlar = db.Rezervasyonlar.Where(x => x.Onay < 3 && x.Tarih >= DateTime.Today).ToList();

			// Her bir rezervasyon için günü sarı arka plan ve kalın yazı tipi ile işaretle
			foreach (var rezervasyon in rezervasyonlar)
			{
				Takvim.AddBoldedDate(rezervasyon.Tarih);
				Takvim.UpdateBoldedDates();

				// Sarı arka plan rengi
				Takvim.BackColor = Color.Yellow;

				// Kalın yazı tipi
				Takvim.TitleForeColor = Color.Red; // Kalın yazı tipi için bir örnek renk kullanıldı, istediğiniz bir renk seçebilirsiniz
			}
		}


		private void Takvim_DateChanged(object sender, DateRangeEventArgs e)
		{
			GUnlereRenkVerme();
			secilentarih = Takvim.SelectionStart;
			if (secilentarih.Date == DateTime.Today)
			{
				ComboDakika.Items.Clear();
				ComboSaat.Items.Clear();
				int suankiSaat = DateTime.Now.Hour;
				int suankiDakika = DateTime.Now.Minute;
				int yuvarlanmisDakika = (suankiDakika + 9) / 10 * 10 % 60;
				for (int i = suankiSaat; i <= 24; i++)
				{
					ComboSaat.Items.Add(i);
				}
				ComboDakika.Items.Add("00");
				if (yuvarlanmisDakika > 0)
				{
					for (int i = yuvarlanmisDakika; i <= 50; i = i + 10)
					{
						ComboDakika.Items.Add(i);
					}
				}
			}
			else
			{
				for (int i = 1; i <= 24; i++)
				{
					ComboSaat.Items.Add(i);
				}
				ComboDakika.Items.Add("00");
				for (int i = 10; i <= 50; i = i + 10)
				{
					ComboDakika.Items.Add(i);
				}
			}
		}
		void temizle()
		{
			ComboSaat.Text = "";
			ComboDakika.Text = "";
			bitisDakika.Text = "";
			bitisSaat.Text = "";
			txtkisiSayisi.Text = "";
			txttalep.Text = "";
		}
		MasaRezervasyon masarezervasyon = new MasaRezervasyon();
		Rezervasyon rezervasyon = new Rezervasyon();
		Context db = new Context();
		int ıd;
		private void button1_Click(object sender, EventArgs e)
		{
			// Seçilen saat ve dakikayı birleştirerek başlangıç saatini oluştur
			TimeSpan baslangicSaat = new TimeSpan(secilenSaat, secilendakika, 0);
			TimeSpan bitisSaat = new TimeSpan(bitisSaati, bitisDakikasi, 0);

			if (hiddenID.Text == "")
			{
				// Rezervasyonun tarihini seçilen tarih olarak ayarla
				rezervasyon.Tarih = secilentarih.Date;
				rezervasyon.BaslangicSaat = baslangicSaat;
				rezervasyon.BitisSaat = bitisSaat;
				rezervasyon.KisiSayisi = Convert.ToInt32(txtkisiSayisi.Text);
				rezervasyon.Talep = txttalep.Text;
				rezervasyon.Onay = comboOnay.SelectedIndex + 1;
				rezervasyon.Gorunurluk = true;
				rezervasyon.TalepTarihi = DateTime.Now;
				db.Rezervasyonlar.Add(rezervasyon);
				db.SaveChanges();
				// Masanın rezervasyon bilgilerini ayarla
				masarezervasyon.RezervasyonId = rezervasyon.Id;
				masarezervasyon.MasaId = masaId;
				masarezervasyon.Gorunurluk = true;
				db.MasaRezervasyonlar.Add(masarezervasyon);
				db.SaveChanges();
				MessageBox.Show("Rezarvasyon Başarı İle Oluşturuldu.");
			}
			else
			{
				var y = db.MasaRezervasyonlar.Find(ıd);
				y.RezervasyonId = rezervasyon.Id;
				y.MasaId = masaId;
				y.Gorunurluk = true;
				var x = db.Rezervasyonlar.Find(y.RezervasyonId);
				// Rezervasyonun tarihini seçilen tarih olarak ayarla
				x.Tarih = secilentarih.Date;
				x.BaslangicSaat = baslangicSaat;
				x.BitisSaat = bitisSaat;
				x.KisiSayisi = Convert.ToInt32(txtkisiSayisi.Text);
				x.Talep = txttalep.Text;
				x.Onay = comboOnay.SelectedIndex + 1;
				x.Gorunurluk = true;
				x.TalepTarihi = DateTime.Now;
				MessageBox.Show("Rezarvasyon Başarı İle Güncellendi.");
				db.SaveChanges();
			}
			temizle();
			RandevulariYukle();
			GUnlereRenkVerme();
		}
		int bitisSaati;
		int bitisDakikasi;
		private void bitisSaat_SelectedIndexChanged(object sender, EventArgs e)
		{
			bitisSaati = Convert.ToInt32(bitisSaat.SelectedItem);
			bitisDakika.Items.Clear();
			if (bitisSaati > secilenSaat)
			{
				bitisDakika.Items.Add("00");
				for (int i = 10; i <= 50; i = i + 10)
				{
					bitisDakika.Items.Add(i);
				}
			}
			else
			{
				for (int i = secilendakika + 10; i <= 50; i = i + 10)
				{
					bitisDakika.Items.Add(i);
				}
			}

		}




		private void bitisDakika_SelectedIndexChanged(object sender, EventArgs e)
		{
			bitisDakikasi = Convert.ToInt32(bitisDakika.SelectedItem);
		}

		private void gridRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// İlgili değerleri ilgili alanlara doldur
			if (gridRandevular.Rows.Count > 0)
			{
				// İlk satırı seç ve değerlerini ilgili alanlara aktar
				DataGridViewRow selectedRow = gridRandevular.Rows[0];
				hiddenID.Text = selectedRow.Cells["RezervasyonID"].Value.ToString();
				Takvim.SelectionStart = (DateTime)selectedRow.Cells["Tarih"].Value;
				ComboSaat.SelectedItem = ((TimeSpan)selectedRow.Cells["BaslangicSaat"].Value).Hours;
				ComboDakika.SelectedItem = ((TimeSpan)selectedRow.Cells["BaslangicSaat"].Value).Minutes;
				bitisSaat.SelectedItem = ((TimeSpan)selectedRow.Cells["BitisSaat"].Value).Hours;
				bitisDakika.SelectedItem = ((TimeSpan)selectedRow.Cells["BitisSaat"].Value).Minutes;
				txtkisiSayisi.Text = selectedRow.Cells["KisiSayisi"].Value.ToString();
				txttalep.Text = selectedRow.Cells["Talep"].Value.ToString();
				comboOnay.SelectedIndex = Convert.ToInt32(selectedRow.Cells["Durum"].Value.ToString()) - 1;
				ıd = Convert.ToInt32(hiddenID.Text);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Rezervasyou Silmek İstediğinize Emin Misiniz?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				var x = db.MasaRezervasyonlar.Find(ıd);
				x.Gorunurluk = false;
				x.Rezervasyon.Onay = 4;
				db.SaveChanges();
			}
			MessageBox.Show("Rezervasyon İptal Edildi");
			temizle();
			RandevulariYukle();
			GUnlereRenkVerme();

		}
	}
}
