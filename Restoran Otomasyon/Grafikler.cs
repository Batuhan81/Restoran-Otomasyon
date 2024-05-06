using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting; // Chart kullanacağımız için bu namespace'i ekliyoruz

namespace Restoran_Otomasyon
{
	public class Grafikler
	{
		public static void DolulukGrafik(Chart chart, Context db)
		{
			var masaDurumlari = db.Masalar.Select(m => m.Durum).ToList();

			// Durum sayaçları
			int toplamMasa = masaDurumlari.Count;
			int bosSayac = 0;
			int doluSayac = 0;
			int kirliSayac = 0;
			int rezerveSayac = 0;
			int kapaliSayac = 0;

			// Masa durumlarını say
			foreach (int durum in masaDurumlari)
			{
				switch (durum)
				{
					case 1:
						bosSayac++;
						break;
					case 2:
						doluSayac++;
						break;
					case 3:
						kirliSayac++;
						break;
					case 4:
						rezerveSayac++;
						break;
					case 5:
						kapaliSayac++;
						break;
				}
			}

			// Yüzde hesaplamaları
			double bosYuzde = (double)bosSayac / toplamMasa * 100;
			double doluYuzde = (double)doluSayac / toplamMasa * 100;
			double kirliYuzde = (double)kirliSayac / toplamMasa * 100;
			double rezerveYuzde = (double)rezerveSayac / toplamMasa * 100;
			double kapaliYuzde = (double)kapaliSayac / toplamMasa * 100;

			// Pasta grafiği için veri noktalarını ayarla
			Dictionary<string, double> veriNoktalari = new Dictionary<string, double>();
			if (bosYuzde > 0)
				veriNoktalari.Add($"Boş (%{(int)bosYuzde})", bosYuzde);
			if (doluYuzde > 0)
				veriNoktalari.Add($"Dolu (%{(int)doluYuzde})", doluYuzde);
			if (kirliYuzde > 0)
				veriNoktalari.Add($"Kirli (%{(int)kirliYuzde})", kirliYuzde);
			if (rezerveYuzde > 0)
				veriNoktalari.Add($"Rezerve (%{(int)rezerveYuzde})", rezerveYuzde);
			if (kapaliYuzde > 0)
				veriNoktalari.Add($"Kapalı (%{(int)kapaliYuzde})", kapaliYuzde);

			// Pasta grafiği oluştur
			chart.Series.Clear();
			chart.Titles.Clear();
			chart.Series.Add("Doluluk Oranları");
			chart.Series["Doluluk Oranları"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

			foreach (var kvp in veriNoktalari)
			{
				chart.Series["Doluluk Oranları"].Points.AddXY(kvp.Key, kvp.Value);
			}

			// Grafiğin başlığını ayarla
			chart.Titles.Clear();
			chart.Titles.Add("Doluluk Oranları").Font = new Font("Arial", 12, FontStyle.Bold);
			// Legend'i devre dışı bırak
			chart.Legends.Clear();

			// Chart kontrolünün güncellenmesi
			chart.Update();
		}


		public static void EnCokSiparisMenu(Chart EnCokSiparisMenu, Context db)
		{
			// Ürünlerin sipariş sayılarını hesapla
			Dictionary<string, int> menuSiparisSayilari = new Dictionary<string, int>();

			// Toplam sipariş miktarını hesaplamak için bir değişken tanımla
			int toplamSiparisSayisi = 0;

			// Tüm sipariş ürünlerini al
			var siparisMenuler = db.SiparisMenus.ToList();

			// Sipariş ürünlerindeki her bir ürünü ve miktarını hesapla
			foreach (var siparisMenu in siparisMenuler)
			{
				// İlgili siparişin bilgilerini al
				var siparis = db.Siparisler.Find(siparisMenu.SiparisId);
				if (siparis != null)
				{
					int MenuID = siparisMenu.MenuId;
					string MenuAdi = db.Menuler.Find(MenuID).Ad;
					// Eğer ürün daha önce listede yoksa, ekleyin ve miktarı 1 olarak ayarlayın
					if (!menuSiparisSayilari.ContainsKey(MenuAdi))
					{
						menuSiparisSayilari[MenuAdi] = siparisMenu.Miktar;
					}
					// Eğer ürün zaten listede ise, sipariş miktarını arttırın
					else
					{
						menuSiparisSayilari[MenuAdi] += siparisMenu.Miktar;
					}

					// Toplam sipariş sayısını güncelle
					toplamSiparisSayisi += siparisMenu.Miktar;
				}
			}
			// En çok sipariş edilen 5 ürünü seç
			var enCokSiparisEdilenMenuler = menuSiparisSayilari.OrderByDescending(x => x.Value).Take(5);

			// Pasta grafiği oluşturma
			EnCokSiparisMenu.Series.Clear();
			EnCokSiparisMenu.Series.Add("Siparişler");
			EnCokSiparisMenu.Series["Siparişler"].ChartType = SeriesChartType.Pie; // Pasta grafiği tipi
			EnCokSiparisMenu.Titles.Clear();
			EnCokSiparisMenu.Titles.Add("En Çok Sipariş Edilen Menüler").Font = new Font("Arial", 12, FontStyle.Bold); // Başlık ekleme, fontu büyük ve kalın yapma
			EnCokSiparisMenu.Legends.Clear();

			// Grafiğe veri ekleme
			foreach (var Menu in enCokSiparisEdilenMenuler)
			{
				double yuzde = (double)Menu.Value / toplamSiparisSayisi * 100; // Yüzde hesaplama
				EnCokSiparisMenu.Series["Siparişler"].Points.AddXY($"{Menu.Key}- {Menu.Value} Adet", Menu.Value);
			}
		}
		public static void EnCokSiparisUrun(Chart chartEnCokSiparisEdilenUrunler, Context db)
		{
			// Ürünlerin sipariş sayılarını hesapla
			Dictionary<string, int> urunSiparisSayilari = new Dictionary<string, int>();

			// Toplam sipariş miktarını hesaplamak için bir değişken tanımla
			int toplamSiparisSayisi = 0;

			// Tüm sipariş ürünlerini al
			var siparisUrunler = db.SiparisUrunler.ToList();
			// Sipariş ürünlerindeki her bir ürünü ve miktarını hesapla
			foreach (var siparisUrun in siparisUrunler)
			{
				// İlgili siparişin bilgilerini al
				var siparis = db.Siparisler.Find(siparisUrun.SiparisId);
				if (siparis != null)
				{
					int urunID = siparisUrun.UrunId;
					string urunAdi = db.Urunler.Find(urunID).Ad;
					// Eğer ürün daha önce listede yoksa, ekleyin ve miktarı 1 olarak ayarlayın
					if (!urunSiparisSayilari.ContainsKey(urunAdi))
					{
						urunSiparisSayilari[urunAdi] = siparisUrun.Miktar;
					}
					// Eğer ürün zaten listede ise, sipariş miktarını arttırın
					else
					{
						urunSiparisSayilari[urunAdi] += siparisUrun.Miktar;
					}

					// Toplam sipariş sayısını güncelle
					toplamSiparisSayisi += siparisUrun.Miktar;
				}
			}
			// En çok sipariş edilen 5 ürünü seç
			var enCokSiparisEdilenUrunler = urunSiparisSayilari.OrderByDescending(x => x.Value).Take(5);

			// Pasta grafiği oluşturma
			chartEnCokSiparisEdilenUrunler.Series.Clear();
			chartEnCokSiparisEdilenUrunler.Series.Add("Siparişler");
			chartEnCokSiparisEdilenUrunler.Series["Siparişler"].ChartType = SeriesChartType.Pie; // Pasta grafiği tipi
			chartEnCokSiparisEdilenUrunler.Titles.Clear();
			chartEnCokSiparisEdilenUrunler.Titles.Add("En Çok Sipariş Edilen Ürünler").Font = new Font("Arial", 12, FontStyle.Bold);  // Başlık ekleme
			chartEnCokSiparisEdilenUrunler.Legends.Clear();
			// Grafiğe veri ekleme
			foreach (var urun in enCokSiparisEdilenUrunler)
			{
				double yuzde = (double)urun.Value / toplamSiparisSayisi * 100; // Yüzde hesaplama
				chartEnCokSiparisEdilenUrunler.Series["Siparişler"].Points.AddXY($"{urun.Key}- {urun.Value} Adet", urun.Value);
			}
		}

		public static void MasaYogunluk(Chart chart, Context db)
		{
			// Masaların kullanım oranlarını hesapla
			var masaKullanimOranlari = new Dictionary<string, int>();

			foreach (var masa in db.Masalar)
			{
				using (var dbContext = new Context())
				{
					int masaID = masa.Id;
					// Masanın toplam sipariş sayısını al
					int toplamSiparisSayisi = dbContext.MasaSiparisler.Where(o => o.MasaId == masaID).Count();

					if (toplamSiparisSayisi != 0)
					{
						masaKullanimOranlari.Add(masa.Kod, toplamSiparisSayisi);
					}
				}
			}
			// Grafik veri bağlama
			chart.Series.Clear();
			chart.Series.Add("Sipariş Sayısı");

			foreach (var masaKullanimOrani in masaKullanimOranlari)
			{
				chart.Series["Sipariş Sayısı"].Points.AddXY(masaKullanimOrani.Key, masaKullanimOrani.Value);
			}

			chart.ChartAreas[0].AxisX.Interval = 1;
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisX.Title = "Masa Kodu";
			chart.ChartAreas[0].AxisY.Title = "Sipariş Sayısı";
			chart.Titles.Clear();
			chart.Titles.Add("Masa Kullanım Oranları").Font = new Font("Arial", 12, FontStyle.Bold);

			// Eksenlerin tamsayı değerlerine uygun hale getirilmesi
			chart.ChartAreas[0].AxisY.Interval = 1; // Y eksenindeki tamsayılar arası aralık
			chart.ChartAreas[0].AxisY.Minimum = 0; // Y ekseninin minimum değeri
			chart.Legends.Clear();
		}

		public static void GunlereGoreGrafik(Chart chartGunlereGoreSiparis, Context db)
		{
			// Haftanın günlerine göre sipariş sayılarını hesapla ve sıralı bir şekilde tutmak için bir dizi kullan
			string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
			Dictionary<string, int> gunlereGoreSiparisSayilari = new Dictionary<string, int>();

			// Tüm siparişleri al
			var siparisler = db.Siparisler.ToList();

			// Siparişlerin günlerine göre sayısını hesapla
			foreach (var siparis in siparisler)
			{
				// Siparişin tarihinden günü al ve Türkçe adını bul
				string gun = siparis.Tarih.DayOfWeek.ToString();
				string gunTuru = GunTuruTercihininTercihineGoreCevir(gun);

				// Eğer sözlükte bu gün anahtarı yoksa, yeni bir anahtar oluştur ve değerini 1 yap
				if (!gunlereGoreSiparisSayilari.ContainsKey(gunTuru))
				{
					gunlereGoreSiparisSayilari[gunTuru] = 1;
				}
				// Eğer anahtar zaten varsa, değerini bir arttır
				else
				{
					gunlereGoreSiparisSayilari[gunTuru]++;
				}
			}

			// Grafik oluşturma
			chartGunlereGoreSiparis.Series.Clear();
			chartGunlereGoreSiparis.Series.Add("Sipariş Sayısı");

			// Her günün sipariş sayısını grafiğe ekle, günlerin sırasını koru
			foreach (var gun in gunler)
			{
				int siparisSayisi = 0;
				// Eğer o gün için sipariş sayısı varsa, değeri al, yoksa 0 olarak bırak
				if (gunlereGoreSiparisSayilari.ContainsKey(gun))
				{
					siparisSayisi = gunlereGoreSiparisSayilari[gun];
				}
				chartGunlereGoreSiparis.Series["Sipariş Sayısı"].Points.AddXY(gun, siparisSayisi);
			}

			// Grafik görünüm ayarları
			chartGunlereGoreSiparis.ChartAreas[0].AxisX.Interval = 1;
			chartGunlereGoreSiparis.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chartGunlereGoreSiparis.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chartGunlereGoreSiparis.ChartAreas[0].AxisX.Title = "Günler";
			chartGunlereGoreSiparis.ChartAreas[0].AxisY.Title = "Sipariş Sayısı";

			// Grafik renkleri ve stil ayarları
			chartGunlereGoreSiparis.BackColor = Color.FromArgb(255, 255, 255);
			chartGunlereGoreSiparis.ChartAreas[0].BackColor = Color.FromArgb(243, 243, 243);
			chartGunlereGoreSiparis.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(64, 64, 64);
			chartGunlereGoreSiparis.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(64, 64, 64);
			chartGunlereGoreSiparis.Series[0].Color = Color.FromArgb(0, 102, 204);
			// Legend'i devre dışı bırak
			chartGunlereGoreSiparis.Legends.Clear();
		}

		private static string GunTuruTercihininTercihineGoreCevir(string gunTuru)
		{
			switch (gunTuru)
			{
				case "Monday":
					return "Pazartesi";
				case "Tuesday":
					return "Salı";
				case "Wednesday":
					return "Çarşamba";
				case "Thursday":
					return "Perşembe";
				case "Friday":
					return "Cuma";
				case "Saturday":
					return "Cumartesi";
				case "Sunday":
					return "Pazar";
				default:
					return gunTuru;
			}
		}


		public static void OdemeYuzdesi(Chart chart, Context db)
		{
			if (db.Odemeler.Any())
			{
				// Nakit ve Kart ödemelerinin tutarlarını hesapla
				decimal? nakitToplamNullable = db.Odemeler.Where(o => o.Tur == 1).Sum(o => (decimal?)o.Tutar);
				decimal nakitToplam = nakitToplamNullable ?? 0;

				decimal? kartToplamNullable = db.Odemeler.Where(o => o.Tur == 2).Sum(o => (decimal?)o.Tutar);
				decimal kartToplam = kartToplamNullable ?? 0;

				// Toplam ödeme tutarı
				decimal toplamTutar = nakitToplam + kartToplam;

				// Nakit ve Kart oranlarını hesapla
				decimal nakitOran = (nakitToplam / toplamTutar) * 100;
				decimal kartOran = (kartToplam / toplamTutar) * 100;

				// Pasta grafiği oluştur
				chart.Series.Clear();
				chart.Series.Add("Ödeme Yöntemi");
				chart.Series["Ödeme Yöntemi"].Points.AddXY("Nakit", nakitOran);
				chart.Series["Ödeme Yöntemi"].Points.AddXY("Kart", kartOran);

				// Pasta dilimlerinin üzerine gelindiğinde açıklama gösterme
				chart.Series["Ödeme Yöntemi"].IsValueShownAsLabel = true;
				chart.Series["Ödeme Yöntemi"].Label = "#PERCENT{P0}";

				// Pasta dilimlerinin renkleri
				chart.Series["Ödeme Yöntemi"].Points[0].Color = Color.Green; // Nakit
				chart.Series["Ödeme Yöntemi"].Points[1].Color = Color.Blue; // Kart

				// Pasta grafiği görünüm ayarları
				chart.Legends.Clear();
				chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
				chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

				chart.ChartAreas[0].AxisX.Interval = 1;
				chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.Title = "Ödeme Yöntemi";
				chart.ChartAreas[0].AxisY.Title = "Yüzde";
				chart.Series["Ödeme Yöntemi"].IsValueShownAsLabel = true;
				chart.Series["Ödeme Yöntemi"].Label = "#PERCENT{P0}";
				chart.ChartAreas[0].BackColor = Color.LightGray;

				// Pasta dilimlerinin üzerine gelindiğinde toplam tutarı gösterme
				chart.GetToolTipText += (sender, e) =>
				{
					if (e.HitTestResult.Series != null && e.HitTestResult.Series.Points != null)
					{
						if (e.HitTestResult.PointIndex >= 0 && e.HitTestResult.Series.Points.Count > 0)
						{
							var point = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
							var odemeYontemi = point.AxisLabel;
							if (odemeYontemi == "Nakit")
							{
								e.Text = $"Nakit: {nakitToplam:C2}";
							}
							else if (odemeYontemi == "Kart")
							{
								e.Text = $"Kart: {kartToplam:C2}";
							}
						}
					}
				};
			}
		}
	}
}
