﻿using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Mysqlx.Crud;
using QRCoder;
using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;


namespace Restoran_Otomasyon
{
	public class Yardimcilar
	{
		// Windows API'yi içe aktar
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		// WM_CLOSE mesajının sabit değeri
		private const int WM_CLOSE = 0x0010;

		public static Process signalRProcess;

		public static void GeriCik(Timer timer)
		{
			timer.Stop();
			SendKeys.Send("{ESC}");
		}
		public static void SignalRSunucuBaslat()
		{
			try
			{
				signalRProcess = new Process();
				//@"C:\Users\Batuhan\Desktop\Dönemlik Staj\Restoran Otomasyon Final\Signal Sunucu\Signal Sunucu\obj\Debug\Signal Sunucu.exe";
				signalRProcess.StartInfo.FileName = @"C:\Users\Batuhan\Desktop\Yedekler\Dönemlik Staj\Restoran Otomasyon Final\Signal Sunucu\Signal Sunucu\obj\Debug\Signal Sunucu.exe";

				signalRProcess.StartInfo.CreateNoWindow = true;
				signalRProcess.StartInfo.UseShellExecute = true;  // Yönetici olarak çalıştırmak için true olmalı
				signalRProcess.StartInfo.Verb = "runas";  // Yönetici olarak çalıştırmak için
				//signalRProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized; // Minimalize başlatmak için
				signalRProcess.Start();

			}
			catch (Exception ex)
			{
				MessageBox.Show($"SignalR sunucusu başlatılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public async static void SignalTetikleMasaDurum()
		{
			bool baglantiBasarili = BaglantiDurumu();
			if (baglantiBasarili == true)
			{
				try
				{
					await Yardimcilar.hubProxy.Invoke("MasaDurumDegisti");
				}
				catch (Exception ex)
				{
					MessageBox.Show("SignalR hub ile iletişim kurulurken bir hata oluştu: " + ex.Message);
				}
			}
			else
			{
				ConnectToSignalR();
				MessageBox.Show("SignalR Bağlantısı Açık Değil");
			}
		}

		public async static Task SignalTetikleSiparis()
		{
			int maxRetryCount = 3; // Hata alırsan 3 kez bağlanmayı dene
			int retryCount = 0;
			int delayBetweenRetries = 2000; // her deneme için 2 sn bekle

			while (retryCount < maxRetryCount)
			{
				if (BaglantiDurumu())
				{
					try
					{
						await Yardimcilar.hubProxy.Invoke("SiparisAlindi");
						return; // bağlantı başarılı döngüden çık
					}
					catch/* (Exception ex)*/
					{
						//if (retryCount == 0)
						//{
						//	MessageBox.Show("SignalR hub ile iletişim kurulurken bir hata oluştu: " + ex.Message);
						//}
					}
				}
				else
				{
					ConnectToSignalR();
					if (retryCount == 0)
					{
						MessageBox.Show("SignalR Bağlantısı Açık Değil, tekrar deneniyor...");
					}
				}

				// Tekrar denemeden önce biraz bekle
				await Task.Delay(delayBetweenRetries);
				retryCount++;
			}
			// En son denemede başarısız olunursa hata mesajını göster
			MessageBox.Show("SignalR bağlantısı kurulamadı, lütfen daha sonra tekrar deneyin.");
		}

		public async static void SignalTetikleOdemeAlindi()
		{
			bool baglantiBasarili = BaglantiDurumu();
			if (baglantiBasarili == true)
			{
				try
				{
					await Yardimcilar.hubProxy.Invoke("OdemeAlindi");
				}
				catch (Exception ex)
				{
					MessageBox.Show("SignalR hub ile iletişim kurulurken bir hata oluştu: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("SignalR Bağlantısı Açık Değil");
			}
		}

		// Bu metot bildirim sesini çalar
		public static void CalBildirimSesi()
		{
			try
			{
				// Ses dosyasının yolunu belirtin
				string sesDosyasiYolu = "C:\\Users\\Batuhan\\Desktop\\Yedekler\\Dönemlik Staj\\Restoran Otomasyon Final\\Üzerinde Çalıştığım SignalRlı\\Restoran Otomasyon\\Resim Ve İconlar\\Bildirim Sesi.Wav";

				// SoundPlayer ile sesi çal
				SoundPlayer player = new SoundPlayer(sesDosyasiYolu);
				player.Play();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Bildirim sesi çalınırken bir hata oluştu: {ex.Message}");
			}
		}

		public async static void SignalTetikleBildirimAlindi()
		{
			bool baglantiBasarili = BaglantiDurumu();
			if (baglantiBasarili == true)
			{
				try
				{
					await Yardimcilar.hubProxy.Invoke("BildirimAlindi");
				}
				catch (Exception ex)
				{
					MessageBox.Show("SignalR hub ile iletişim kurulurken bir hata oluştu: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("SignalR Bağlantısı Açık Değil");
			}
		}
		public async static void SignalTetikleOdemeBildirim()
		{
			bool baglantiBasarili = BaglantiDurumu();
			if (baglantiBasarili == true)
			{
				try
				{
					await Yardimcilar.hubProxy.Invoke("OdemeBildirim");
				}
				catch (Exception ex)
				{
					MessageBox.Show("SignalR hub ile iletişim kurulurken bir hata oluştu: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("SignalR Bağlantısı Açık Değil");
			}
		}

		public static IHubProxy hubProxy;
		public static HubConnection connection;
		public static string url = "http://192.168.1.245:8080/signalr/hubs"; // SignalR sunucusunun adresi
		//192.168.1.227
		public static async void ConnectToSignalR()
		{
			connection = new HubConnection(url);
			hubProxy = connection.CreateHubProxy("RestaurantHub");
			try
			{
				await connection.Start();
				if (Yardimcilar.BaglantiDurumu() == true)
				{
					try
					{
						hubProxy.On("MasaDurumDegisti", () =>
						{
							Console.WriteLine("MasaDurumDegisti olayı alındı.");
							MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
							if (calisanForm != null)
							{
								calisanForm.BeginInvoke(new Action(() =>
								{
									calisanForm.MasaButonlariniGuncelle();
									calisanForm.comboKat.SelectedIndex = 0;
								}));
							}
						});

						hubProxy.On("SiparisAlindi", () =>
						{
							KasaPaneli calisanForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
							if (calisanForm != null)
							{
								calisanForm.BeginInvoke(new Action(() =>
								{
									calisanForm.grafikleriGuncelle();
								}));
							}
							Admin_Paneli calisanForm2 = Application.OpenForms.OfType<Admin_Paneli>().FirstOrDefault();
							if (calisanForm2 != null)
							{
								calisanForm2.BeginInvoke(new Action(() =>
								{
									calisanForm2.grafikleriGuncelle();
								}));
							}
							MutfakPaneli calisanForm3 = Application.OpenForms.OfType<MutfakPaneli>().FirstOrDefault();
							if (calisanForm3 != null)
							{
								calisanForm3.BeginInvoke(new Action(() =>
								{
									calisanForm3.Siparisler();
									calisanForm3.Bildirimler();
								}));
							}
						});

						hubProxy.On("OdemeAlindi", () =>
						{
							Console.WriteLine("OdemeAlindi olayı alındı.");

							KasaPaneli calisanForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
							if (calisanForm != null)
							{
								calisanForm.BeginInvoke(new Action(() =>
								{
									calisanForm.grafikleriGuncelle();
									calisanForm.BakiyeHesapla();
								}));
							}
							Admin_Paneli calisanForm2 = Application.OpenForms.OfType<Admin_Paneli>().FirstOrDefault();
							if (calisanForm2 != null)
							{
								calisanForm2.BeginInvoke(new Action(() =>
								{
									calisanForm2.grafikleriGuncelle();
									calisanForm2.bakiyeHesapla();
								}));
							}
						});
						hubProxy.On("OdemeBildirim", () =>
						{
							Console.WriteLine("OdemeBildirim olayı alındı.");

							KasaPaneli calisanForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
							if (calisanForm != null)
							{
								calisanForm.BeginInvoke(new Action(() =>
								{
									calisanForm.Bildirimler();
								}));
							}
						});
						hubProxy.On("BildirimAlindi", () =>
						{
							Console.WriteLine("BildirimAlindi olayı alındı.");
							KasaPaneli calisanForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
							if (calisanForm != null)
							{
								calisanForm.BeginInvoke(new Action(() =>
								{
									calisanForm.Bildirimler();
								}));
							}
							Admin_Paneli calisanForm2 = Application.OpenForms.OfType<Admin_Paneli>().FirstOrDefault();
							if (calisanForm2 != null)
							{
								calisanForm2.BeginInvoke(new Action(() =>
								{
									calisanForm2.Bildirimler();
								}));
							}

						});
					}
					catch (Exception ex)
					{
						MessageBox.Show("SignalR Abone Olma İşlemlerinde Bir Hata Gerçekleşti " + ex);
					}

					//MessageBox.Show("SignalR sunucusuna bağlanıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"SignalR sunucusuna bağlanılamadı: {ex.Message}"); // Hata varsa mesaj göster
			}
		}

		public static bool BaglantiDurumu()
		{
			bool _isConnectionOpen = false;
			int denemeSayisi = 0;

			while (true)
			{
				if (connection != null)
				{
					switch (connection.State)
					{
						case ConnectionState.Connected:
							_isConnectionOpen = true;
							return _isConnectionOpen;

						case ConnectionState.Disconnected:
							// Uyarı mesajı göstermeden önce bir iş parçacığı oluşturarak sistem kitlenmesini önleyelim
							Task.Factory.StartNew(() => ShowMessage("SignalR Bağlantısında Bir Sorun Oluştu. Yeniden Bağlantı Sağlanana Kadar Bekleniyor...", MessageBoxIcon.Question));

							// Bağlantı kopması durumunda hemen tekrar bağlanmayı deneyelim
							_isConnectionOpen = false;
							SignalRSunucuBaslat();
							ConnectToSignalR();

							// Bağlantı durumu kontrolü için biraz bekleyelim
							Task.Delay(2000).Wait();

							// Bağlantı durumu kontrol edildikten sonra eğer bağlanabildiysek döngüden çıkalım
							if (connection.State == ConnectionState.Connected)
							{
								_isConnectionOpen = true;
								return _isConnectionOpen;
							}
							denemeSayisi++;

							// 3 denemeden fazla ise hata mesajı göster ve çık
							if (denemeSayisi >= 3)
							{
								ShowMessage("3 kez denenmesine rağmen bağlantı sağlanamadı. Lütfen SignalR sunucunuzu kontrol ediniz!", MessageBoxIcon.Error);
								return _isConnectionOpen;
							}
							break;

						case ConnectionState.Reconnecting:
						case ConnectionState.Connecting:
							Task.Delay(1000).Wait();
							break;
					}
				}
				else
				{
					ShowMessage("SignalR Bağlantısında Bir Sorun Oluştu. Yeniden Bağlantı Sağlanana Kadar Bekleniyor...", MessageBoxIcon.Question);
					SignalRSunucuBaslat();
					ConnectToSignalR();
					denemeSayisi = 1; // Bağlantı yeniden başlatıldığında deneme sayısını sıfırla
				}
			}
		}

		private static void ShowMessage(string message, MessageBoxIcon icon)
		{
			MessageBox.Show(message, "Bilgilendirme", MessageBoxButtons.OK, icon);
		}


		public static void KontrolEt(Control control, KeyPressEventArgs e)
		{
			TextBoxBase textBox = control as TextBoxBase;
			MaskedTextBox maskedTextBox = control as MaskedTextBox;
			if (textBox != null)
			{
				if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)  // Eğer bir rakam veya BACKSPACE tuşu ise
				{
					textBox.BackColor = Color.White; // Arkaplan rengini beyaz yap
				}
				else
				{
					e.Handled = true; // Karakteri engelle
					textBox.BackColor = Color.Red; // Arkaplan rengini kırmızı yap
				}
			}
			else if (maskedTextBox != null)
			{
				if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)  // Eğer bir rakam veya BACKSPACE tuşu ise
				{
					maskedTextBox.BackColor = Color.White; // Arkaplan rengini beyaz yap
				}
				else
				{
					e.Handled = true; // Karakteri engelle
					maskedTextBox.BackColor = Color.Red; // Arkaplan rengini kırmızı yap
				}
			}
		}

		public static void Kopyalama(Control control, object sender, KeyEventArgs e)
		{
			TextBoxBase textBox = control as TextBoxBase;
			MaskedTextBox maskedTextBox = control as MaskedTextBox;

			if (textBox != null)
			{
				if (e.Control && e.KeyCode == Keys.C)
				{
					// Ctrl + C tuş kombinasyonu algılandı, metni panoya kopyala
					Clipboard.SetText(textBox.SelectedText);
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
				else if (e.Control && e.KeyCode == Keys.A)
				{
					// Ctrl + A tuş kombinasyonu algılandı, tüm metni seç
					textBox.SelectAll();
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
				else if (e.Control && e.KeyCode == Keys.V)
				{
					// Ctrl + V tuş kombinasyonu algılandı, panodan metni yapıştır
					textBox.Paste();
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
			}
			else if (maskedTextBox != null)
			{
				if (e.Control && e.KeyCode == Keys.C)
				{
					// Ctrl + C tuş kombinasyonu algılandı, metni panoya kopyala
					Clipboard.SetText(maskedTextBox.SelectedText);
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
				else if (e.Control && e.KeyCode == Keys.A)
				{
					// Ctrl + A tuş kombinasyonu algılandı, tüm metni seç
					maskedTextBox.SelectAll();
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
				else if (e.Control && e.KeyCode == Keys.V)
				{
					// Ctrl + V tuş kombinasyonu algılandı, panodan metni yapıştır
					maskedTextBox.Paste();
					// Tuş kombinasyonunu engelleme
					e.SuppressKeyPress = true;
				}
			}
		}

		public static void Urunlist(DataGridView gridUrun)//Admin göreceği için gorunurlık filtresi yok
		{
			using (var db = new Context())
			{
				var Urunler = db.Urunler.OrderByDescending(o => o.Id).Select(o => new
				{
					Id = o.Id,
					Ad = o.Ad,
					Aciklama = o.Aciklama,
					Detay = o.Detay,
					Fiyat = o.Fiyat,
					Fotoğraf = o.Fotograf,
					Aktiflik = o.Akitf ? "Aktif" : "Pasif",
					Görünürlük = o.Gorunurluk ? "Görünür" : "Görünmez",
					İndirimliFiyat = o.IndirimliFiyat,
					İndirimTarihi = o.IndirimTarihi,
					Yüzde = o.IndirimYuzdesi,
					Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategorId).Ad,
				}).ToList();
				gridUrun.DataSource = Urunler;
				gridUrun.Columns["Fotoğraf"].Visible = false;
				gridUrun.Columns["Id"].Visible = false;
			}
		}

		public static void Menulist(DataGridView gridMenu)//Admin göreceği için gorunurlık filtresi yok
		{
			using (var db = new Context())
			{
				var Menuler = db.Menuler.OrderByDescending(o => o.Id).Select(o => new
				{
					Id = o.Id,
					Ad = o.Ad,
					Aciklama = o.Aciklama,
					Detay = o.Detay,
					Fiyat = o.Fiyat,
					Fotoğraf = o.Fotograf,
					Aktiflik = o.Akitf ? "Aktif" : "Pasif",
					İndirimliFiyat = o.IndirimliFiyat,
					Görünürlük = o.Gorunurluk ? "Görünür" : "Görünmez",
					İndirimTarihi = o.IndirimTarihi,
					Yüzde = o.IndirimYuzdesi,
					Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategoriId).Ad,
				}).ToList();
				gridMenu.DataSource = Menuler;
				gridMenu.Columns["Fotoğraf"].Visible = false;
				gridMenu.Columns["Id"].Visible = false;
			}
		}

		public static string KareKodOlustur(string masakodu)
		{
			// QR kodunu oluştur
			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://192.168.137.1:5001/Masas/MasaMenu/Menu/" + masakodu, QRCodeGenerator.ECCLevel.Q);
			QRCode qrCode = new QRCode(qrCodeData);
			Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20: piksel başına ölçek faktörü

			// Uygulamanın çalıştığı dizini bul
			string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory;

			// Kayıt edilecek klasörün adını ve yolu belirle
			string klasorAdi = "QrKodlar";
			string klasorYolu = Path.Combine(uygulamaDizini, klasorAdi);

			// Eğer klasör yoksa oluştur
			if (!Directory.Exists(klasorYolu))
			{
				Directory.CreateDirectory(klasorYolu);
			}
			// Dosya adını belirle
			string dosyaAdi = $"{masakodu}_QR.png";
			string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

			// QR kodunu dosyaya kaydet
			qrCodeImage.Save(dosyaYolu, ImageFormat.Png);

			// Dosya yolunu geri döndür
			return dosyaYolu;
		}

		public static bool StoklariKontrolEt(Urun urun, int miktar, Context db)
		{
			// Ürünün gerekli malzemelerini bul
			var gerekliMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == urun.Id).ToList();

			// Her bir malzeme için stok kontrolü yap
			foreach (var malzeme in gerekliMalzemeler)
			{
				// Malzemenin stok bilgisini al
				var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzeme.MalzemeId);

				// Eğer stok bulunamadıysa veya stok miktarı yeterli değilse, işlemi durdur
				if (stok == null || stok.Miktar < malzeme.Miktar * miktar)
				{
					return false;
				}
			}

			// Eğer tüm malzemelerin stok miktarı yeterli ise true dön
			return true;
		}

		//public static bool MenuStoklariniKontrolEt(Data.Menu menu, int miktar, Context db)
		//{
		//	// Menünün içindeki ürünleri bul
		//	var menuUrunleri = db.MenuUrunler.Where(mu => mu.MenuId == menu.Id).Select(mu => mu.Urun).ToList();

		//	// Her bir ürün için stok kontrolü yap
		//	foreach (var urun in menuUrunleri)
		//	{
		//		if (!StoklariKontrolEt(urun, miktar, db))
		//		{
		//			return false;
		//		}
		//	}

		//	// Eğer tüm ürünlerin stok miktarı yeterli ise true dön
		//	return true;
		//}


		public static void MasaBilgileri(int masaId, TextBox txtMasaAdi, TextBox txtDurum, TextBox txtKapasite, TextBox txtTutar, TextBox txtOdenen, TextBox txtPersonel, TextBox txtKategori, TextBox txtsiparisDurum, Context db)
		{
			var x = db.Masalar.Find(masaId);

			var masasiparis = db.MasaSiparisler.Where(s => s.MasaId == masaId)
									 .OrderByDescending(s => s.Id)
									 .FirstOrDefault();
			if (masasiparis != null)
			{
				if (masasiparis.SiparisId != 0)
				{
					var maxAd = db.Durumlar.Where(o => o.SiparisId == masasiparis.SiparisId).Max(o => o.Ad);

					switch (maxAd)
					{
						case 1: txtsiparisDurum.Text = "Sipariş Alındı"; break;
						case 2: txtsiparisDurum.Text = "Sipariş Onaylandı"; break;
						case 3: txtsiparisDurum.Text = "Hazırlanıyor"; break;
						case 4: txtsiparisDurum.Text = "Hazırlandı"; break;
						case 5: txtsiparisDurum.Text = "Ödeme Bekliyor"; break;
						case 6: txtsiparisDurum.Text = "Ödendi"; break;
						case 7: txtsiparisDurum.Text = "İptal Edildi"; break;
						case 8: txtsiparisDurum.Text = "Yolda"; break;
						case 9: txtsiparisDurum.Text = "Teslim Edildi"; break;
					}
				}
			}

			// x.Durum'a göre durumu belirleyin
			txtMasaAdi.Text = x.Kod;
			string durumMetni = "";
			switch (x.Durum)
			{
				case 1:
					durumMetni = "Boş";
					break;
				case 2:
					durumMetni = "Dolu";
					break;
				case 3:
					durumMetni = "Kirli";
					break;
				case 4:
					durumMetni = "Rezerve";
					break;
				case 5:
					durumMetni = "Kapalı";
					break;
				default:
					durumMetni = "Bilinmeyen Durum";
					break;
			}

			// Text kutusuna durum metnini ata
			txtDurum.Text = durumMetni;
			txtKapasite.Text = x.Kapasite.ToString();
			if (masasiparis != null && x.Durum == 2)//Masa doluysa bilgilerini getir değilse 0 olması gerekir.
			{
				txtTutar.Text = Yardimcilar.FormatliDeger(masasiparis.Tutar.ToString());
				txtOdenen.Text = Yardimcilar.FormatliDeger(masasiparis.OdenenTutar.ToString());
			}
			else
			{
				txtTutar.Text = "0 ₺";
				txtOdenen.Text = "0 ₺";
			}

			var personel = db.Personeller.FirstOrDefault(o => o.Id == x.Id);
			string adSoyad = personel != null ? $"{personel.Ad} {personel.Soyad}" : "";
			txtPersonel.Text = adSoyad;
			txtKategori.Text = db.Kategoriler.FirstOrDefault(o => o.Id == x.KategoriId).Ad;
		}

		public static void GridRenklendir(DataGridView grid)
		{
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			grid.RowsDefaultCellStyle.BackColor = Color.White;
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
		}

		public static bool GecerliTarihMi(string tarih)
		{
			DateTime sonuc;
			if (DateTime.TryParseExact(tarih, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sonuc))
			{
				// Ayın 1 ile 12 arasında, günün de 1 ile ayın gün sayısı arasında olup olmadığını kontrol ediyoruz
				if (sonuc.Month >= 1 && sonuc.Month <= 12 && sonuc.Day >= 1 && sonuc.Day <= DateTime.DaysInMonth(sonuc.Year, sonuc.Month))
				{
					return true;
				}
			}
			return false;
		}


		public static bool MailKontrol(string mail)
		{
			try
			{
				MailAddress mailAddress = new MailAddress(mail);
				// Ek kontroller yapabiliriz, örneğin domain kısmını kontrol etmek
				if (mailAddress.Host.Contains('.'))
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}


		public static void Temizle(GroupBox group)
		{
			foreach (Control item in group.Controls)
			{
				if (item is TextBox || item is ComboBox || item is RichTextBox || item is MaskedTextBox)
				{
					item.Text = "";
				}
			}
		}

		public static void OpenForm(Form form, Panel panel)
		{
			// Panel içinde mevcut herhangi bir formu kaldır
			panel.Controls.Clear();

			// Form'u panelin boyutuna göre ayarla
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			form.Resize += (sender, e) =>
			{
				panel.Size = form.Size;
			};

			// Panel içine yeni formu ekleyin
			panel.Controls.Add(form);
			form.Show();
		}

		public static string FormatliDeger(string deger)//Veriyi 100 =>100.00₺ ye çevirir
		{
			if (string.IsNullOrWhiteSpace(deger))
				return "";

			// Eğer değer zaten ₺ işareti ile bitiyorsa, sadece geri döndür
			if (deger.EndsWith("₺"))
				return deger;

			decimal degerDecimal = decimal.Parse(deger, NumberStyles.Currency, CultureInfo.GetCultureInfo("tr-TR"));
			return degerDecimal.ToString("N2") + "₺";
		}

		public static void gridFormatStokMiktari(DataGridView dataGridView, string hedefSutunAdi)
		{
			// Olay dinleyicisini tanımlayalım
			DataGridViewCellFormattingEventHandler gridFormatStokMiktariHandler = null;

			// Olay dinleyicisini oluşturalım
			gridFormatStokMiktariHandler = (sender, args) =>
			{
				if (args.Value != null && args.Value != DBNull.Value && args.ColumnIndex == dataGridView.Columns[hedefSutunAdi].Index)
				{
					var row = dataGridView.Rows[args.RowIndex];
					var turValue = row.Cells["MalzemeTur"].Value?.ToString(); // Malzeme türünü al
					if (!string.IsNullOrEmpty(turValue))
					{
						decimal deger;
						if (decimal.TryParse(args.Value.ToString(), out deger)) // Decimal'e dönüşümü TryParse ile güvenli hale getirdik
						{
							string birim = "";

							switch (turValue)
							{
								case "Kg":
									birim = "Kg";
									deger = deger / 1000;
									break;
								case "Litre":
									birim = "Litre";
									deger = deger / 1000;
									break;
								case "Adet":
									birim = "Adet";
									break;
								default:
									birim = "";
									break;

							}
							string formatliDeger = BirimFormatı(deger, birim);
							args.Value = formatliDeger;

							args.FormattingApplied = true;
						}
					}
				}
			};
			// Olay dinleyicisini ekleyelim
			dataGridView.CellFormatting += gridFormatStokMiktariHandler;
		}

		public static string BirimFormatı(decimal deger, string birim)
		{
			string formatliDeger;

			// Adet birimiyse, ondalık kısmı kaldırarak formatla
			if (birim == "Adet")
				formatliDeger = Math.Round(deger).ToString();
			else
				formatliDeger = deger.ToString("N2"); // Diğer birimler için standart format

			// Birim ekle
			switch (birim)
			{
				case "Kg":
					formatliDeger += " Kg"; // Birim "Kg" ise sonuna "Kg" ekle
					break;
				case "Litre":
					formatliDeger += " L"; // Birim "Litre" ise sonuna "L" ekle
					break;
				case "Adet":
					formatliDeger += " Adet"; // Birim "Adet" ise sonuna "Adet" ekle
					break;
			}
			return formatliDeger;
		}

		public static decimal TemizleVeDondur(TextBox textBox, string birim)
		{
			string text = textBox.Text.Trim(); // Textbox'tan değeri alırken baştaki ve sondaki boşlukları temizle
			text = text.TrimEnd(' ', 'K', 'g', 'L', 'A', 'd', 'e', 't', '₺', '%'); // Textbox'tan birim ifadesini temizle
			text = text.TrimStart('₺');

			// Temizlenmiş değeri uygun formata dönüştür ve decimal türüne dönüştür
			decimal deger;
			if (decimal.TryParse(text, out deger))
			{
				//// Birim kontrolü yaparak değeri uygun şekilde dönüştürme
				//if (birim == "Kg" || birim == "Litre")
				//{
				//	deger = deger / 1000; // Gramı kilograma veya litreye dönüştürme
				//}
				// Diğer birimler için herhangi bir işlem yapmıyoruz, değeri değiştirmiyoruz
			}
			return deger;
		}

		public static string FormatsizDeger(string deger)
		{
			// Eğer kullanıcı sadece ₺ işaretini girdiyse, sadece nokta kaldıysa veya aradaki bir noktayı sildiyse, bunları temizleyerek döndür
			if (deger.Contains("₺"))
			{
				deger = deger.Replace("₺", "");
			}
			// Sondaki noktayı kaldır
			if (deger.EndsWith("."))
			{
				deger = deger.Substring(0, deger.Length - 1);
			}
			// Başındaki noktayı kaldır
			if (deger.StartsWith("."))
			{
				deger = deger.Substring(1);
			}
			else if (deger.Contains(".") && deger.LastIndexOf(".") < deger.LastIndexOf("₺"))
			{
				// Aradaki bir noktayı sildiyse ve bu nokta ₺ işaretinden önceyse, sadece bu noktayı kaldır
				deger = deger.Remove(deger.LastIndexOf("."));
			}

			// Formatlı değeri formatlı olmayan hale çevirerek döndür
			return decimal.Parse(deger, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands).ToString();
		}

		public static void GridFormat(DataGridView dataGridView, string columnName, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value != null && e.Value != DBNull.Value)
			{
				// Belirtilen sütun adında ise
				if (dataGridView.Columns[e.ColumnIndex].Name == columnName)
				{
					if (e.Value.ToString() != "Yok")
					{
						if (columnName == "Yüzde")
						{
							if (e.Value != null && e.Value.GetType() == typeof(int))
							{
								int yuzdeDegeri = (int)e.Value;
								string yuzdeMetni = "%" + yuzdeDegeri.ToString("N0").Replace(",", "."); // "N2" formatı ile iki basamaklı virgülden sonraki sayıları gösteriyoruz
								// DataGridView hücresine biçimlendirilmiş değeri ata
								e.Value = yuzdeMetni;
								e.FormattingApplied = true;
							}
						}
						else
						{
							e.Value = ((decimal)e.Value).ToString("N2") + "₺"; // "N2" formatı ile iki basamaklı virgülden sonraki sayıları gösteriyoruz
							e.FormattingApplied = true;
						}
					}
				}
			}
		}

		public class ResimBoyutlandir
		{
			public static Image DosyaSec(PictureBox pictureBox, Label uzanti)
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.Filter = "PNG Dosyaları (*.png)|*.png|JPG Dosyaları (*.jpg)|*.jpg|Tüm Dosyalar (*.png, *.jpg)|*.png;*.jpg";
				fileDialog.FilterIndex = 3;
				fileDialog.RestoreDirectory = true;
				fileDialog.CheckFileExists = true;
				fileDialog.Title = "Dosya Seçiniz";

				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					// Seçilen fotoğrafı PictureBox'ta göster
					pictureBox.Image = Image.FromFile(fileDialog.FileName);

					// Resim uzantısını ve dosya yolunu göster
					pictureBox.Visible = true;
					uzanti.Text = fileDialog.FileName;

					return pictureBox.Image;
				}
				return null;
			}

			public static Image Boyutlandir(Image image, int width, int height)
			{
				if (image == null)
				{
					return null;
				}

				Bitmap boyutlandirilmisResim = new Bitmap(width, height);
				using (Graphics graphics = Graphics.FromImage(boyutlandirilmisResim))
				{
					graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					graphics.DrawImage(image, 0, 0, width, height);
				}
				return boyutlandirilmisResim;
			}

			public static Image DosyaYoluIleBoyutlandir(string dosyaYolu, int width, int height)
			{
				Image image = Image.FromFile(dosyaYolu);
				return Boyutlandir(image, width, height);
			}
		}

		public static bool HepsiDoluMu(GroupBox groupBox)
		{
			foreach (Control control in groupBox.Controls)
			{
				if (control is TextBox)
				{
					TextBox textBox = (TextBox)control;
					if (string.IsNullOrWhiteSpace(textBox.Text))
					{
						return false; // TextBox'ın içeriği boş veya sadece boşluk karakterlerinden oluşuyorsa false döndür
					}
				}
				if (control is ComboBox)
				{
					ComboBox comboBox = (ComboBox)control;
					if (string.IsNullOrWhiteSpace(comboBox.Text))
					{
						return false;
					}
				}
				if (control is MaskedTextBox)
				{
					MaskedTextBox masked = (MaskedTextBox)control;
					if (string.IsNullOrWhiteSpace(masked.Text))
					{
						return false;
					}
				}
				if (control is RichTextBox)
				{
					RichTextBox rich = (RichTextBox)control;
					if (string.IsNullOrWhiteSpace(rich.Text))
					{
						return false;
					}
				}
			}
			return true; // Tüm Her şey dolu ise true döndür
		}
	}
}
