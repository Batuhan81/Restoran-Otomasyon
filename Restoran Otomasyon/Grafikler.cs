using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
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
					case 1: // Boş
						bosSayac++;
						break;
					case 2: // Dolu
						doluSayac++;
						break;
					case 3: // Kirli
						kirliSayac++;
						break;
					case 4: // Rezerve
						rezerveSayac++;
						break;
					case 5: // Kapalı
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

			// Renklerin sabit olarak tanımlanması
			Color bosRenk = Color.Green;
			Color doluRenk = Color.Red;
			Color kirliRenk = Color.Brown;
			Color rezerveRenk = Color.Yellow;
			Color kapaliRenk = Color.Gray;

			foreach (var kvp in veriNoktalari)
			{
				// Her bir veri noktası için sabit renk ataması yap
				string durumAdi = kvp.Key.Split(' ')[0]; // Durum adını al
				Color renk;

				switch (durumAdi)
				{
					case "Boş":
						renk = bosRenk;
						break;
					case "Dolu":
						renk = doluRenk;
						break;
					case "Kirli":
						renk = kirliRenk;
						break;
					case "Rezerve":
						renk = rezerveRenk;
						break;
					case "Kapalı":
						renk = kapaliRenk;
						break;
					default:
						renk = Color.White; // Varsayılan renk
						break;
				}

				chart.Series["Doluluk Oranları"].Points.AddXY(kvp.Key, kvp.Value);
				chart.Series["Doluluk Oranları"].Points.Last().Color = renk;
			}

			// Grafiğin başlığını ayarla
			chart.Titles.Clear();
			chart.Titles.Add("Doluluk Oranları").Font = new Font("Arial", 12, FontStyle.Bold);
			// Legend'i devre dışı bırak
			chart.Legends.Clear();
			chart.ChartAreas[0].BackColor = Color.FromArgb(195, 230, 252);

			// Chart kontrolünün güncellenmesi
			chart.Update();
		}


		public static void EnCokSiparisMenu(Chart EnCokSiparisMenu, Context db, string zamanAraligi)
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

			// Zaman aralığına göre siparişleri filtrele
			IQueryable<Siparis> siparisler;

			switch (zamanAraligi)
			{
				case "Bugün":
					// Bugünün siparişlerini al
					siparisler = db.Siparisler.Where(s => s.Tarih.Date == DateTime.Today.Date);
					break;
				case "Bu Hafta":
					// Bu haftanın siparişlerini al
					DateTime baslangicHafta = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
					DateTime bitisHafta = baslangicHafta.AddDays(7);
					siparisler = db.Siparisler.Where(s => s.Tarih.Date >= baslangicHafta.Date && s.Tarih.Date < bitisHafta.Date);
					break;
				case "Bu Ay":
					// Bu ayın siparişlerini al
					siparisler = db.Siparisler.Where(s => s.Tarih.Month == DateTime.Today.Month && s.Tarih.Year == DateTime.Today.Year);
					break;
				default:
					// Tüm siparişleri al
					siparisler = db.Siparisler;
					break;
			}

			// En çok sipariş edilen 5 ürünü seç
			var enCokSiparisEdilenMenuler = menuSiparisSayilari.OrderByDescending(x => x.Value).Take(5);

			// Pasta grafiği oluşturma
			EnCokSiparisMenu.Series.Clear();
			EnCokSiparisMenu.Series.Add("Siparişler");
			EnCokSiparisMenu.Series["Siparişler"].ChartType = SeriesChartType.Pie; // Pasta grafiği tipi
			EnCokSiparisMenu.Titles.Clear();
			EnCokSiparisMenu.Titles.Add($"En Çok Sipariş Edilen Menüler {"- "+zamanAraligi}").Font = new Font("Arial", 12, FontStyle.Bold); // Başlık ekleme, fontu büyük ve kalın yapma
			EnCokSiparisMenu.Legends.Clear();
			EnCokSiparisMenu.ChartAreas[0].BackColor = Color.FromArgb(195, 230, 252);

			// Grafiğe veri ekleme
			foreach (var Menu in enCokSiparisEdilenMenuler)
			{
				double yuzde = (double)Menu.Value / toplamSiparisSayisi * 100; // Yüzde hesaplama
				EnCokSiparisMenu.Series["Siparişler"].Points.AddXY($"{Menu.Key}- {Menu.Value} Adet", Menu.Value);
			}
		}


		public static void EnCokSiparisUrun(Chart chart, Context db, string zamanAraligi)
		{
			// Ürünlerin sipariş sayılarını hesapla
			Dictionary<string, int> urunSiparisSayilari = new Dictionary<string, int>();

			// Toplam sipariş miktarını hesaplamak için bir değişken tanımla
			int toplamSiparisSayisi = 0;

			// Tüm sipariş ürünlerini al
			var siparisUrunler = db.SiparisUrunler.ToList();

			// Zaman aralığına göre siparişleri filtrele
			IQueryable<Siparis> siparisler;

			switch (zamanAraligi)
			{
				case "Bugün":
					// Bugünün siparişlerini al
					siparisler = db.Siparisler.Where(s => s.Tarih.Day == DateTime.Today.Day);
					break;
				case "Bu Hafta":
					// Bu haftanın siparişlerini al
					DateTime baslangicHafta = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
					DateTime bitisHafta = baslangicHafta.AddDays(7);
					siparisler = db.Siparisler.Where(s => s.Tarih.Day >= baslangicHafta.Day && s.Tarih.Day < bitisHafta.Day);
					break;
				case "Bu Ay":
					// Bu ayın siparişlerini al
					siparisler = db.Siparisler.Where(s => s.Tarih.Month == DateTime.Today.Month && s.Tarih.Year == DateTime.Today.Year);
					break;
				default:
					// Tüm siparişleri al
					siparisler = db.Siparisler;
					break;
			}

			// Sipariş ürünlerindeki her bir ürünü ve miktarını hesapla
			foreach (var siparisUrun in siparisUrunler)
			{
				// İlgili siparişin bilgilerini al
				var siparis = siparisler.FirstOrDefault(s => s.Id == siparisUrun.SiparisId);
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
			chart.Series.Clear();
			chart.Series.Add("Siparişler");
			chart.Series["Siparişler"].ChartType = SeriesChartType.Pie; // Pasta grafiği tipi
			chart.Titles.Clear();
			chart.Titles.Add($"En Çok Sipariş Edilen Ürünler {"- " + zamanAraligi}").Font = new Font("Arial", 12, FontStyle.Bold);  // Başlık ekleme
			chart.ChartAreas[0].BackColor = Color.FromArgb(195, 230, 252);

			chart.Legends.Clear();
			// Grafiğe veri ekleme
			foreach (var urun in enCokSiparisEdilenUrunler)
			{
				double yuzde = (double)urun.Value / toplamSiparisSayisi * 100; // Yüzde hesaplama
				chart.Series["Siparişler"].Points.AddXY($"{urun.Key}- {urun.Value} Adet", urun.Value);
			}
			chart.Series["Siparişler"]["PieLineColor"] = "Black";

		}

		public static void MasaYogunluk(Chart chart, Context db, string zamanAraligi)
		{
			// Masaların kullanım oranlarını hesapla
			var masaKullanimOranlari = new Dictionary<string, int>();

			// Zaman aralığına göre siparişleri filtrele
			IQueryable<MasaSiparis> masaSiparisler;
			switch (zamanAraligi)
			{
				case "Bugün":
					masaSiparisler = db.MasaSiparisler
						.Where(s => s.Siparis.Tarih.Day == DateTime.Today.Day);
					break;
				case "Bu Hafta":
					DateTime baslangicHafta = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
					DateTime bitisHafta = baslangicHafta.AddDays(7);
					masaSiparisler = db.MasaSiparisler
						.Where(s => s.Siparis.Tarih >= baslangicHafta && s.Siparis.Tarih < bitisHafta);
					break;
				case "Bu Ay":
					masaSiparisler = db.MasaSiparisler
						.Where(s => s.Siparis.Tarih.Month == DateTime.Today.Month && s.Siparis.Tarih.Year == DateTime.Today.Year);
					break;
				default:
					masaSiparisler = db.MasaSiparisler;
					break;
			}

			// Siparişlerin toplam sayısını hesapla
			var toplamSiparisSayilari = masaSiparisler
				.GroupBy(s => s.MasaId)
				.Select(g => new { MasaId = g.Key, ToplamSiparis = g.Count() })
				.ToList();

			// Masaların kodlarına göre sipariş sayılarını ekle
			foreach (var siparis in toplamSiparisSayilari)
			{
				Masa masa = db.Masalar.Find(siparis.MasaId);
				masaKullanimOranlari.Add(masa.Kod, siparis.ToplamSiparis);
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
			chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
			chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
			chart.ChartAreas[0].AxisX.Title = "Masa Kodu";
			chart.ChartAreas[0].AxisY.Title = "Sipariş Sayısı";
			chart.Titles.Clear();
			chart.Titles.Add($"Masa Kullanım Oranları {"- " + zamanAraligi}").Font = new Font("Arial", 12, FontStyle.Bold);
			chart.ChartAreas[0].BackColor = Color.FromArgb(195, 230, 252);
			// Eksenlerin tamsayı değerlerine uygun hale getirilmesi
			chart.ChartAreas[0].AxisY.Interval = 1; // Y eksenindeki tamsayılar arası aralık
			chart.ChartAreas[0].AxisY.Minimum = 0; // Y ekseninin minimum değeri
			chart.Legends.Clear();
		}


		public static void GunlereGoreGrafik(Chart chart, Context db, string zamanAraligi)
		{
			// Haftanın günlerine göre sipariş sayılarını hesapla ve sıralı bir şekilde tutmak için bir dizi kullan
			string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
			Dictionary<string, int> gunlereGoreSiparisSayilari = new Dictionary<string, int>();

			// Zaman aralığına göre siparişleri filtrele
			IQueryable<Siparis> siparisler;
			switch (zamanAraligi)
			{
				case "Bugün":
					siparisler = db.Siparisler.Where(s => s.Tarih.Day == DateTime.Today.Day);
					break;
				case "Bu Hafta":
					DateTime baslangicHafta = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
					DateTime bitisHafta = baslangicHafta.AddDays(7);
					siparisler = db.Siparisler.Where(s => s.Tarih >= baslangicHafta && s.Tarih < bitisHafta);
					break;
				case "Bu Ay":
					siparisler = db.Siparisler.Where(s => s.Tarih.Month == DateTime.Today.Month && s.Tarih.Year == DateTime.Today.Year);
					break;
				default:
					siparisler = db.Siparisler;
					break;
			}

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
			chart.Series.Clear();
			chart.Series.Add("Sipariş Sayısı");

			// Her günün sipariş sayısını grafiğe ekle, günlerin sırasını koru
			foreach (var gun in gunler)
			{
				int siparisSayisi = 0;
				// Eğer o gün için sipariş sayısı varsa, değeri al, yoksa 0 olarak bırak
				if (gunlereGoreSiparisSayilari.ContainsKey(gun))
				{
					siparisSayisi = gunlereGoreSiparisSayilari[gun];
				}
				chart.Series["Sipariş Sayısı"].Points.AddXY(gun, siparisSayisi);
			}

			// Grafik görünüm ayarları
			chart.ChartAreas[0].AxisX.Interval = 1;
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
			chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
			chart.ChartAreas[0].AxisX.Title = "Günler";
			chart.ChartAreas[0].AxisY.Title = "Sipariş Sayısı";

			// Grafik renkleri ve stil ayarları
			//chart.BackColor = Color.FromArgb(255, 255, 255);
			chart.ChartAreas[0].BackColor = Color.FromArgb(195 ,230 ,252);



			chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(64, 64, 64);
			chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(64, 64, 64);
			chart.Series[0].Color = Color.FromArgb(0, 102, 204);
			// Legend'i devre dışı bırak
			chart.Legends.Clear();
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


		public static void OdemeYuzdesi(Chart chart, Context db, string zamanAraligi)
		{
			IQueryable<Odeme> odemeler;
			switch (zamanAraligi)
			{
				case "Bugün":
					odemeler = db.Odemeler.Where(o => o.OdemeTarih.Year == DateTime.Today.Year &&
													   o.OdemeTarih.Month == DateTime.Today.Month &&
													   o.OdemeTarih.Day == DateTime.Today.Day);
					break;

				case "Bu Hafta":
					DateTime baslangicHafta = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
					DateTime bitisHafta = baslangicHafta.AddDays(7);
					odemeler = db.Odemeler.Where(o => o.OdemeTarih >= baslangicHafta && o.OdemeTarih < bitisHafta);
					break;

				case "Bu Ay":
					odemeler = db.Odemeler.Where(o => o.OdemeTarih.Month == DateTime.Today.Month &&
													   o.OdemeTarih.Year == DateTime.Today.Year);
					break;

				default:
					odemeler = db.Odemeler;
					break;
			}

			int sayi = odemeler.Count();
			if (odemeler.Any())
			{
				// Nakit ve Kart ödemelerinin tutarlarını hesapla
				decimal? nakitToplamNullable = odemeler.Where(o => o.Tur == 1).Sum(o => (decimal?)o.Tutar);
				decimal nakitToplam = nakitToplamNullable ?? 0;

				decimal? kartToplamNullable = odemeler.Where(o => o.Tur == 2).Sum(o => (decimal?)o.Tutar);
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

				chart.ChartAreas[0].AxisX.Interval = 10;
				chart.ChartAreas[0].AxisY.Minimum = 0; // Y ekseni minimum değeri
				chart.ChartAreas[0].AxisY.Maximum = 100; // Y ekseni maksimum değeri

				chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.Title = "Ödeme Yöntemi";
				chart.ChartAreas[0].AxisY.Title = "Yüzde";
				chart.ChartAreas[0].BackColor = Color.FromArgb(195, 230, 252);

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
