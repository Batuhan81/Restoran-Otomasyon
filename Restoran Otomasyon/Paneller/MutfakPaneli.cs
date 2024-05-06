using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon.Data
{
	public partial class MutfakPaneli : Form
	{
		public MutfakPaneli(int KullaniciID)
		{
			InitializeComponent();
			kullaniciId = KullaniciID;
		}
		int kullaniciId;
		Context db = new Context();

		private void MutfakPaneli_Load(object sender, EventArgs e)
		{
			OnaylananSiparisler();
			HazirlanmaktaOlanSiparisler();
		}

		void OnaylananSiparisler()
		{
			gridOnaylananlar.DataSource = null;
			var siparisler = new List<object>();
			var onaylananSiparisler = db.Siparisler
				.Where(s => s.Gorunurluk == true && s.Durumlars.Any(d => d.Ad == 2 && !s.Durumlars.Any(d2 => d2.Ad == 3)))
				.ToList();

			foreach (var siparis in onaylananSiparisler)
			{
				var masaKodu = db.MasaSiparisler.FirstOrDefault(o => o.Gorunurluk == true && o.SiparisId == siparis.Id)?.Masa.Kod;

				if (masaKodu != null)
				{
					var urunler = db.SiparisUrunler
						.Where(u => u.Gorunurluk == true && u.SiparisId == siparis.Id)
						.Select(u => new { SiparisId = siparis.Id, MasaKodu = masaKodu, Ad = u.Urun.Ad, Miktar = u.Miktar })
						.ToList();

					var menuler = db.SiparisMenus
						.Where(m => m.Gorunurluk == true && m.SiparisId == siparis.Id)
						.Select(m => new { SiparisId = siparis.Id, MasaKodu = masaKodu, Ad = m.Menu.Ad, Miktar = m.Miktar })
						.ToList();

					siparisler.AddRange(urunler);
					siparisler.AddRange(menuler);
				}
			}
			gridOnaylananlar.DataSource = siparisler;
		}



		void HazirlanmaktaOlanSiparisler()
		{
			gridHazirlananlar.DataSource = null;
			var siparisler = new List<object>();
			var onaylananSiparisler = db.Siparisler
				.Where(s => s.Gorunurluk == true && s.Durumlars.Any(d => d.Ad == 3 && !s.Durumlars.Any(d2 => d2.Ad == 4)))
				.ToList();

			foreach (var siparis in onaylananSiparisler)
			{
				var masaKodu = db.MasaSiparisler.FirstOrDefault(o => o.Gorunurluk == true && o.SiparisId == siparis.Id).Masa.Kod;

				var urunler = db.SiparisUrunler
					.Where(u => u.Gorunurluk == true && u.SiparisId == siparis.Id)
					.Select(u => new { SiparisId = siparis.Id, MasaKodu = masaKodu, Ad = u.Urun.Ad, Miktar = u.Miktar })
					.ToList();

				var menuler = db.SiparisMenus
					.Where(m => m.Gorunurluk == true && m.SiparisId == siparis.Id)
					.Select(m => new { SiparisId = siparis.Id, MasaKodu = masaKodu, Ad = m.Menu.Ad, Miktar = m.Miktar })
					.ToList();

				siparisler.AddRange(urunler);
				siparisler.AddRange(menuler);
			}
			gridHazirlananlar.DataSource = siparisler;
			siparisler = null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Seçilen satırın ID'sini al
			int selectedSiparisId = (int)gridOnaylananlar.CurrentRow.Cells["SiparisId"].Value;

			// Yeni bir Durum oluştur
			var yeniDurum = new Durum()
			{
				Ad = 3, // Hazırlanıyor durumu
				Zaman = DateTime.Now, // Şu anki zamanı al
				Yer = 2, // Mutfak yerine 2 değerini atadım
				SiparisId = selectedSiparisId // Seçilen siparişin ID'sini ata
			};

			// Yeni Durumu veritabanına ekle
			db.Durumlar.Add(yeniDurum);
			db.SaveChanges(); // Değişiklikleri kaydet

			// Seçilen siparişin durumunu yeni Durum'un ID'siyle güncelle
			var siparislerToUpdate = db.Siparisler.Where(s => s.Id == selectedSiparisId).ToList();
			foreach (var siparis in siparislerToUpdate)
			{
				siparis.Durumlars.Add(yeniDurum);
			}

			db.SaveChanges(); // Değişiklikleri kaydet

			// Onaylanan siparişleri yeniden yükle
			OnaylananSiparisler();
			HazirlanmaktaOlanSiparisler();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			// Seçilen satırın ID'sini al
			int selectedSiparisId = (int)gridHazirlananlar.CurrentRow.Cells["SiparisId"].Value;

			// Yeni bir Durum oluştur
			var yeniDurum = new Durum()
			{
				Ad = 4, // Hazırlanıyor durumu
				Zaman = DateTime.Now, // Şu anki zamanı al
				Yer = 2, // Mutfak yerine 2 değerini atadım
				SiparisId = selectedSiparisId // Seçilen siparişin ID'sini ata
			};

			// Yeni Durumu veritabanına ekle
			db.Durumlar.Add(yeniDurum);
			db.SaveChanges(); // Değişiklikleri kaydet

			// Seçilen siparişin durumunu yeni Durum'un ID'siyle güncelle
			var siparislerToUpdate = db.Siparisler.Where(s => s.Id == selectedSiparisId).ToList();
			foreach (var siparis in siparislerToUpdate)
			{
				siparis.Durumlars.Add(yeniDurum);
			}

			db.SaveChanges(); // Değişiklikleri kaydet

			// Onaylanan siparişleri yeniden yükle
			OnaylananSiparisler();
			HazirlanmaktaOlanSiparisler();
		}
	}
}
