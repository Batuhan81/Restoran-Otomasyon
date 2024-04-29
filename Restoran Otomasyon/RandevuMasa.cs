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
			
		}
		int secilenSaat;
		int secilendakika;
		DateTime secilentarih;

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

			// Seçilen tarihteki rezervasyonları al
			var rezervasyonlar = db.Rezervasyonlar.Where(r => r.Tarih.Date == Takvim.SelectionStart.Date).ToList();

			// Her bir rezervasyon için vurgula
			foreach (var rezervasyon in rezervasyonlar)
			{
				Takvim.AddBoldedDate(rezervasyon.Tarih);
			}

			Takvim.UpdateBoldedDates(); // Yeniden çiz
		}
		private void Takvim_DateChanged(object sender, DateRangeEventArgs e)
		{
			GUnlereRenkVerme();
			secilentarih = Takvim.SelectionStart;
			if (secilentarih.Date == DateTime.Today)
			{
				ComboDakika.Items.Clear();
				ComboSaat.Items.Clear();
				int suankiSaat=DateTime.Now.Hour;
				int suankiDakika=DateTime.Now.Minute;
				int yuvarlanmisDakika = (suankiDakika + 9) / 10 * 10 % 60;
				for (int i = suankiSaat; i <= 24; i++)
				{
					ComboSaat.Items.Add(i);
				}
				ComboDakika.Items.Add("00");
				if(yuvarlanmisDakika > 0)
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
			ComboSaat.Text ="";
			ComboDakika.Text = "";
			bitisDakika.Text = "";
			bitisSaat.Text = "";
			txtkisiSayisi.Text = "";
			txttalep.Text = "";
		}
		MasaRezervasyon masarezervasyon = new MasaRezervasyon();
		Rezervasyon rezervasyon=new Rezervasyon();
		Context db=new Context();
		private void button1_Click(object sender, EventArgs e)
		{
			// Rezervasyonun tarihini seçilen tarih olarak ayarla
			rezervasyon.Tarih = secilentarih.Date;

			// Seçilen saat ve dakikayı birleştirerek başlangıç saatini oluştur
			TimeSpan baslangicSaat = new TimeSpan(secilenSaat, secilendakika, 0);
			TimeSpan bitisSaat = new TimeSpan(bitisSaati, bitisDakikasi, 0);
			rezervasyon.BaslangicSaat = baslangicSaat;
			rezervasyon.BitisSaat = bitisSaat;
			rezervasyon.KisiSayisi=Convert.ToInt32(txtkisiSayisi.Text);
			rezervasyon.Talep = txttalep.Text;
			rezervasyon.Onay = 1;
			rezervasyon.Gorunurluk = true;
			rezervasyon.TalepTarihi=DateTime.Now;
			db.Rezervasyonlar.Add(rezervasyon);
			db.SaveChanges();
			// Masanın rezervasyon bilgilerini ayarla
			masarezervasyon.RezervasyonId= rezervasyon.Id;
			masarezervasyon.MasaId = masaId;
			masarezervasyon.Gorunurluk = true;
			db.MasaRezervasyonlar.Add(masarezervasyon);
			db.SaveChanges();

			MessageBox.Show("Rezarvasyon Başarı İle Oluşturuldu.");
			temizle();
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
				for (int i = secilendakika+10; i <= 50; i = i + 10)
				{
					bitisDakika.Items.Add(i);
				}
			}
			
		}

		private void bitisDakika_SelectedIndexChanged(object sender, EventArgs e)
		{
			bitisDakikasi = Convert.ToInt32(bitisDakika.SelectedItem);
		}
	}
}
