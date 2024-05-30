using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon.Paneller
{
	public partial class KasaFormu : Form
	{
		public KasaFormu()
		{
			InitializeComponent();
		}
		Context db = new Context();
		private void Kasa_Load(object sender, EventArgs e)
		{
			Odemeler();
			bugun = DateTime.Now.Date;
			haftaninGunleri = DateTime.Now.DayOfWeek;
			Yardimcilar.GridRenklendir(gridOdemeler);
			OdemeFiltre.SelectedIndex = 0;
		}

		public void Odemeler()
		{
			var odemeler = db.Odemeler.Select(o => new
			{
				Id = o.Id,
				Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
				Tutar = o.Tutar,
				Ödeme_Tarihi = o.OdemeTarih,
			}).ToList();
			txtBakiye.Text = odemeler.Sum(o => o.Tutar).ToString();
			gridOdemeler.DataSource = odemeler;
			gridOdemeler.Columns["Id"].Visible = false;
		}

		DateTime baslangicTarihi;
		DateTime bitisTarihi;
		DayOfWeek haftaninGunleri;

		int tiklanmaSayisi = 0;
		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
			if (tiklanmaSayisi % 2 == 0)
			{
				baslangicTarihi = Takvim.SelectionStart.Date;
			}
			else
			{
				bitisTarihi = Takvim.SelectionEnd.Date.AddDays(1); // Bir sonraki günün başlangıcı
			}
			tiklanmaSayisi++;
			if (tiklanmaSayisi == 2)
			{
				var filtrelenmisOdemeler = db.Odemeler.Where(o => o.OdemeTarih >= baslangicTarihi && o.OdemeTarih < bitisTarihi).ToList();
				decimal toplamTutar = filtrelenmisOdemeler.Sum(o => o.Tutar);
				txtBakiye.Text = toplamTutar.ToString();
				tiklanmaSayisi = 0;
			}
		}
		DateTime bugun;
		private void button1_Click(object sender, EventArgs e)
		{
			// Bugünün başlangıç ve bitiş saatlerini belirle
			DateTime bugunBaslangic = new DateTime(bugun.Year, bugun.Month, bugun.Day, 0, 0, 0);
			DateTime bugunBitis = new DateTime(bugun.Year, bugun.Month, bugun.Day, 23, 59, 59);

			if (OdemeFiltre.SelectedIndex == 0)
			{
				// Bugünün başlangıç ve bitiş saatleri arasındaki ödemeleri al
				var Gunluk = db.Odemeler.Where(o => o.OdemeTarih >= bugunBaslangic && o.OdemeTarih <= bugunBitis).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				decimal toplamTutar = Gunluk.Sum(o => o.Tutar);
				txtBakiye.Text = toplamTutar.ToString();
				gridOdemeler.DataSource = Gunluk;
			}
			else
			{
				// Bugünün başlangıç ve bitiş saatleri arasındaki ödemeleri al
				var Gunluk = db.Odemeler.Where(o => o.OdemeTarih >= bugunBaslangic && o.OdemeTarih <= bugunBitis && o.Tur == Filtre).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				decimal toplamTutar = Gunluk.Sum(o => o.Tutar);
				txtBakiye.Text = toplamTutar.ToString();
				gridOdemeler.DataSource = Gunluk;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Haftanın ilk gününü bulma
			DateTime haftaninIlkGunu = bugun.AddDays(-(int)haftaninGunleri);
			// Haftanın son gününü bulma (haftanın ilk gününe 6 gün ekleyerek)
			DateTime haftaninSonGunu = haftaninIlkGunu.AddDays(6);
			if (OdemeFiltre.SelectedIndex == 0)
			{
				var haftalikOdemeler = db.Odemeler.Where(o => o.OdemeTarih >= haftaninIlkGunu && o.OdemeTarih <= haftaninSonGunu).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				// Haftalık ödemelerin toplamını hesaplayın
				decimal haftalikToplamTutar = haftalikOdemeler.Sum(o => o.Tutar);
				txtBakiye.Text = haftalikToplamTutar.ToString();
				gridOdemeler.DataSource = haftalikOdemeler;
			}
			else
			{
				var haftalikOdemeler = db.Odemeler.Where(o => o.OdemeTarih >= haftaninIlkGunu && o.OdemeTarih <= haftaninSonGunu && o.Tur == Filtre).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				// Haftalık ödemelerin toplamını hesaplayın
				decimal haftalikToplamTutar = haftalikOdemeler.Sum(o => o.Tutar);
				txtBakiye.Text = haftalikToplamTutar.ToString();
				gridOdemeler.DataSource = haftalikOdemeler;
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			DateTime ayinIlkGunu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date;
			DateTime ayinSonGunu = ayinIlkGunu.AddMonths(1).Date;
			if (OdemeFiltre.SelectedIndex == 0)
			{
				var ayinOdemeleri = db.Odemeler.Where(o => o.OdemeTarih >= ayinIlkGunu && o.OdemeTarih <= ayinSonGunu).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				// Bu ay içindeki ödemelerin toplamını hesaplayın
				decimal ayinToplamTutar = ayinOdemeleri.Sum(o => o.Tutar);
				txtBakiye.Text = ayinToplamTutar.ToString();
				gridOdemeler.DataSource = ayinOdemeleri;
			}
			else
			{
				var ayinOdemeleri = db.Odemeler.Where(o => o.OdemeTarih >= ayinIlkGunu && o.OdemeTarih <= ayinSonGunu && o.Tur==Filtre).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				// Bu ay içindeki ödemelerin toplamını hesaplayın
				decimal ayinToplamTutar = ayinOdemeleri.Sum(o => o.Tutar);
				txtBakiye.Text = ayinToplamTutar.ToString();
				gridOdemeler.DataSource = ayinOdemeleri;
			}
		}

		private void txtBakiye_TextChanged(object sender, EventArgs e)
		{
			txtBakiye.Text = Yardimcilar.FormatliDeger(txtBakiye.Text);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				FiltrePanel.Visible = true;
			}
			else
			{
				FiltrePanel.Visible = false;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Odemeler();
		}

		private void gridOdemeler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.GridFormat(gridOdemeler, "Tutar", e);
		}
		int Filtre;
		private void OdemeFiltre_SelectedIndexChanged(object sender, EventArgs e)
		{
			Filtre = OdemeFiltre.SelectedIndex;
			if (Filtre == 0)
			{
				Odemeler();
			}
			else
			{
				var odemeler = db.Odemeler.Where(o => o.Tur == Filtre).Select(o => new
				{
					Id = o.Id,
					Ödeme_Türü = (o.Tur == 1) ? "Nakit" : ((o.Tur == 2) ? "Kart" : "Diğer"),
					Tutar = o.Tutar,
					Ödeme_Tarihi = o.OdemeTarih,
				}).ToList();
				txtBakiye.Text = odemeler.Sum(o => o.Tutar).ToString();
				gridOdemeler.DataSource = odemeler;
				gridOdemeler.Columns["Id"].Visible = false;
			}
		}
	}
}
