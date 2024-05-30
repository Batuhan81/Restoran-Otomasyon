using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static Restoran_Otomasyon.UrunleriGoster;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Microsoft.AspNet.SignalR.Client;

namespace Restoran_Otomasyon
{
	public partial class BosMasa : Form
	{
		public BosMasa(int masaID, int kullaniciID)
		{
			InitializeComponent();
			masaId = masaID;
			kullaniciId = kullaniciID;
		}

		int masaId;
		int kullaniciId;
		Context db = new Context();
		bool loaddayuklendi = false;

		public static void StokKontrol()
		{
			using (Context db = new Context())
			{
				var tumMalzemeler = db.Malzemeler.ToList();
				List<string> yetersizMalzemeler = new List<string>();
				List<string> gorunurluguAcilanlar = new List<string>();

				foreach (var malzeme in tumMalzemeler)
				{
					// Malzemenin stok bilgisini al
					var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzeme.Id);

					if (stok != null)
					{
						bool yetersizStok =
							(malzeme.Tur == "Adet" && stok.Miktar <= 5) ||
							(malzeme.Tur == "Kg" && stok.Miktar <= 500) ||
							(malzeme.Tur == "L" && stok.Miktar <= 500);

						if (yetersizStok)
						{
							// Malzemeyi kullanan tüm ürünleri bul
							var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).Select(u => u.Urun).Distinct().ToList();
							bool herhangiBirUrunKapatildi = false;

							foreach (var urun in urunler)
							{
								if (urun.Akitf)
								{
									urun.Akitf = false;
									herhangiBirUrunKapatildi = true;
								}

								// Ürünü kullanan menülerin aktifliğini kapat
								var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.Id).Select(mu => mu.Menu).Distinct().ToList();
								foreach (var menu in kullananMenuler)
								{
									if (menu.Akitf)
									{
										menu.Akitf = false;
										herhangiBirUrunKapatildi = true;
									}
								}
							}

							if (herhangiBirUrunKapatildi)
							{
								yetersizMalzemeler.Add(malzeme.Ad);
							}

							// Gün içerisinde zaten bildirim gönderildi mi kontrol et
							if (!BildirimGonderildiMi(db, malzeme.Ad, "Stok Tükendi"))
							{
								BildirimOlustur(db, $"{malzeme.Ad} Adlı Malzemeden Elimizde Kalmadı.", "Stok Tükendi");
							}
						}
					}
				}

				foreach (var malzeme in tumMalzemeler)
				{
					var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzeme.Id);
					if (stok != null && stok.Miktar >= stok.MinStok)
					{
						var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).Select(u => u.Urun).Distinct().ToList();
						foreach (var urun in urunler)
						{
							bool tumMalzemelerYeterli = true;

							// Ürünün tüm malzemelerinin yeterli olup olmadığını kontrol et
							var urununMalzemeleri = db.urunMalzemeler.Where(u => u.UrunId == urun.Id).ToList();
							foreach (var um in urununMalzemeleri)
							{
								var urunStok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == um.MalzemeId);
								if (urunStok != null)
								{
									bool yetersizStok =
										(um.Malzeme.Tur == "Adet" && urunStok.Miktar <= 5) ||
										(um.Malzeme.Tur == "Kg" && urunStok.Miktar <= 500) ||
										(um.Malzeme.Tur == "L" && urunStok.Miktar <= 500);

									if (yetersizStok)
									{
										tumMalzemelerYeterli = false;
										break;
									}
								}
								else
								{
									tumMalzemelerYeterli = false;
									break;
								}
							}

							if (tumMalzemelerYeterli && !urun.Akitf)
							{
								urun.Akitf = true;
								gorunurluguAcilanlar.Add(malzeme.Ad);

								// Ürünü kullanan menülerin aktifliğini aç
								var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.Id).Select(mu => mu.Menu).Distinct().ToList();
								foreach (var menu in kullananMenuler)
								{
									if (!menu.Akitf)
									{
										menu.Akitf = true;
										gorunurluguAcilanlar.Add(malzeme.Ad);
									}
								}
							}
						}
					}
				}

				foreach (var menu in db.MenuUrunler.Select(mu => mu.Menu).Distinct().ToList())
				{
					bool menuStokYeterli = true;
					var menuUrunler = db.MenuUrunler.Where(mu => mu.MenuId == menu.Id).Select(mu => mu.Urun).ToList();
					foreach (var urun in menuUrunler)
					{
						if (!StoklariKontrolEt(urun, 1, db))
						{
							menuStokYeterli = false;
							break;
						}
					}
					if (menuStokYeterli && !menu.Akitf)
					{
						menu.Akitf = true;
						gorunurluguAcilanlar.Add(menu.Ad);
					}
					else if (!menuStokYeterli && menu.Akitf)
					{
						menu.Akitf = false;
						yetersizMalzemeler.Add(menu.Ad);
					}
				}

				db.SaveChanges();

				if (yetersizMalzemeler.Any())
				{
					string yetersizMalzemelerMesaj = string.Join(", ", yetersizMalzemeler.Distinct());
					BildirimOlustur(db, $"Stoklar Yetersiz Olduğundan Bazı Ürün ve Menülerin Aktifliği Kapatılmıştır. (Yetersiz Malzemeler => {yetersizMalzemelerMesaj})", "Stok Tükendi");
				}

				if (gorunurluguAcilanlar.Any())
				{
					string gorunurlukAcilanlar = string.Join(", ", gorunurluguAcilanlar.Distinct());
					BildirimOlustur(db, $"Stoklar Minimum Değerin Üzerine Çıktığından Ürün ve Menülerin Aktifliği Açılmıştır. (Stok Girdisi Olan Malzemeler => {gorunurlukAcilanlar})", "Aktiflikler Açıldı.");
				}
			}
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

		private static bool BildirimGonderildiMi(Context db, string malzemeAd, string bildirimBaslik)
		{
			var bugun = DateTime.Now.Date;
			return db.Bildirimler.Any(b => b.Baslik == bildirimBaslik && b.Aciklama.Contains(malzemeAd) && b.Tarih >= bugun);
		}

		private static void BildirimOlustur(Context db, string aciklama, string baslik)
		{
			Bildirim bildiri = new Bildirim
			{
				KullaniciId = 1,
				Aciklama = aciklama,
				MusteriId = null,
				PersonelId = null,
				Baslik = baslik,
				Okundu = false,
				Tarih = DateTime.Now
			};
			db.Bildirimler.Add(bildiri);
			db.SaveChanges();
			Yardimcilar.SignalTetikleBildirimAlindi();
		}



		private UrunGosterici urunGosterici;
		private void BosMasa_Load(object sender, EventArgs e)
		{
			MasaBilgileri();
			// UrunGosterici sınıfından bir örnek oluşturun
			urunGosterici = new UrunGosterici(UrunPaneli, gridSiparisler, txttutar, db);
			StokKontrol();
			UrunKategori(ComboUrun, db);
			menuKategoriler(ComboMenu, db);
			urunGosterici.UrunleriGoster(0);
			urunGosterici.MenuleriGoster(0);

			loaddayuklendi = true;
			gridSiparisler.Columns.Add("UrunAdi", "Ürün Adı");
			gridSiparisler.Columns.Add("Adet", "Adet");
			gridSiparisler.Columns.Add("Fiyat", "Fiyat");
			gridSiparisler.Columns.Add("UrunID", "UrunID");
			gridSiparisler.Columns.Add("MenuID", "MenuID");

			// Gizli sütunları bulup gizli hale getirme
			foreach (DataGridViewColumn column in gridSiparisler.Columns)
			{
				if (column.HeaderText == "UrunID" || column.HeaderText == "MenuID")
				{
					column.Visible = false;
				}
			}
			// Formun constructor veya Load metodu içinde ContextMenuStrip'i oluştur
			ContextMenuStrip siparisSilMenu = new ContextMenuStrip();
			ToolStripMenuItem siparisSilMenuItem = new ToolStripMenuItem();
			siparisSilMenuItem.Name = "siparisSilMenuItem";
			siparisSilMenuItem.Size = new Size(180, 22);
			siparisSilMenuItem.Text = "Siparişi Sil";
			siparisSilMenuItem.Click += SiparisSilMenuItem_Click; // Siparişi silme işlevini tanımlayan bir event handler ekleyin
			siparisSilMenu.Items.AddRange(new ToolStripItem[] { siparisSilMenuItem });

			// DataGridView'e ContextMenuStrip'i ata
			gridSiparisler.ContextMenuStrip = siparisSilMenu;
			ComboUrun.Text = "";
			ComboMenu.Text = "";
		}

		private void SiparisSilMenuItem_Click(object sender, EventArgs e)
		{
			if (gridSiparisler.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in gridSiparisler.SelectedRows)
				{
					// Seçili satırın ürün ID'sini al
					int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);

					// UrunPaneli içindeki tüm GroupBox'ları döngüye al
					foreach (Control control in UrunPaneli.Controls)
					{
						if (control is GroupBox groupBox)
						{
							// GroupBox içindeki TextBox'ları bul
							foreach (Control innerControl in groupBox.Controls)
							{
								if (innerControl is TextBox textBox)
								{
									// Ürün ID'si seçilen ürün ID'sine eşitse, miktarı sıfırla
									if (textBox.Tag != null && Convert.ToInt32(textBox.Tag) == urunID)
									{
										textBox.Text = "0";
										break;
									}
								}
							}
						}
					}
					// İlgili satırı sil
					gridSiparisler.Rows.Remove(row);
				}
				// Toplam tutarı yeniden hesapla
				UrunGosterici.HesaplaToplamTutar(gridSiparisler, txttutar);
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Lütfen silmek için bir satır seçin.");
			}
		}

		private void MasaBilgileri()
		{
			Yardimcilar.MasaBilgileri(masaId, txtmasaadi, txtDurum, txtkapasite, txttutar, txtodenen, txtpersonel, txtkategori, txtsiparisDurum, db);
			if (txtDurum.Text == "Kirli")
			{
				DialogResult result = MessageBox.Show("Bu Masada Sipariş Almak İstediğinize Emin Misiniz(Masa Durumu=>Kirli)", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (DialogResult.No == result)
				{
					this.Close();
				}
			}
			if (txtDurum.Text == "Kapalı")
			{
				timer1.Start();
				MessageBox.Show("Bu Masa Durumu Şuanda Kaplı Durumda Burada Sadece Görüntüleme Yapabilirsiniz Sipariş Alamazsınız !", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		public static void menuKategoriler(ComboBox combo, Context db)
		{
			var menuKat = db.Kategoriler.Where(o => o.Tur == "Menü" && o.Gorunurluk == true).ToList();
			combo.DisplayMember = "Ad";
			combo.ValueMember = "Id";
			combo.DataSource = menuKat;
		}

		public static void UrunKategori(ComboBox combo, Context db)
		{
			var Urunkategori = db.Kategoriler.Where(o => o.Tur == "Ürün" && o.Gorunurluk == true).ToList();
			combo.DisplayMember = "Ad";
			combo.ValueMember = "Id";
			combo.DataSource = Urunkategori;
		}
		Bildirim bildirim = new Bildirim();

		private async void button2_Click(object sender, EventArgs e)//Sipariş Onaylama Butonu
		{
			#region Masaya İlk Kez Sipariş Veriliyorsa
			if (gridSiparisler.Rows.Count != 1)
			{
				// Yeni bir sipariş oluştur
				Siparis siparis = new Siparis();
				MasaSiparis masasip = new MasaSiparis();
				Masa masa = new Masa();
				Durum Durum = new Durum();
				//Bu kısımda bir masaya tıklanıldığında eğer masa durumu rezerve ise durumunu gerçekleştiye çeviriyor yani rezerve eden kişinin geldiğini anlamına geliyor.
				var x = db.Masalar.Find(masaId);
				if (x.Durum != 5)
				{
					if (x.Durum == 4)
					{
						var rezervasyon = db.MasaRezervasyonlar.Where(o => o.MasaId == masaId && o.Rezervasyon.Tarih == DateTime.Today).ToList();
						if (rezervasyon != null)
						{
							foreach (var item in rezervasyon)
							{
								// Rezervasyonun başlangıç saati ile mevcut zamandan yarım saat sonrasının farkını al
								TimeSpan baslangicZamani = item.Rezervasyon.BaslangicSaat;
								TimeSpan yarimSaatSonrasininZamani = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(30));

								// Rezervasyonun başlangıç saati şu anki zamandan ileri bir zamansa veya aynı zamandaysa
								if (baslangicZamani >= DateTime.Now.TimeOfDay && baslangicZamani <= yarimSaatSonrasininZamani)
								{
									// Rezervasyonun onay durumu henüz 3 değilse
									if (item.Rezervasyon.Onay != 3)
									{
										// Rezervasyonun onay durumunu 3 olarak güncelleyin
										item.Rezervasyon.Onay = 3;
										int rezervasyonId = item.Id;
										db.SaveChanges();
									}
								}
							}
						}
					}
					x.Durum = 2;//Masa durumu dolu yapıldı.
					db.SaveChanges();
					siparis.Tarih = DateTime.Now;
					siparis.OdemeDurum = false;
					siparis.Not = null;
					siparis.YorumId = null;
					siparis.Gorunurluk = true;
					siparis.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
					masasip.MasaId = masaId;
					masasip.SiparisId = siparis.Id;
					masasip.MusteriId = null;
					masasip.Gorunurluk = true;
					masasip.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
					masasip.OdenenTutar = 0;
					db.MasaSiparisler.Add(masasip);
					db.Siparisler.Add(siparis);

					foreach (DataGridViewRow row in gridSiparisler.Rows)
					{
						if (row.Cells["Adet"].Value != null && Convert.ToInt32(row.Cells["Adet"].Value) > 0)
						{
							int miktar = Convert.ToInt32(row.Cells["Adet"].Value.ToString());

							if (row.Cells["UrunID"].Value != null && row.Cells["UrunID"].Value.ToString() != "")
							{
								int urunId = Convert.ToInt32(row.Cells["UrunID"].Value.ToString());
								SiparisUrun urun = new SiparisUrun();
								urun.UrunId = urunId;
								urun.Miktar = miktar;
								urun.SiparisId = siparis.Id;
								urun.Gorunurluk = true;
								db.SiparisUrunler.Add(urun);
							}
							else if (row.Cells["MenuID"].Value != null && row.Cells["MenuID"].Value.ToString() != "")
							{
								int menuId = Convert.ToInt32(row.Cells["MenuID"].Value.ToString());
								SiparisMenu menu = new SiparisMenu();
								menu.MenuId = menuId;
								menu.Miktar = miktar;
								menu.SiparisId = siparis.Id;
								menu.Gorunurluk = true;
								db.SiparisMenus.Add(menu);
							}
						}
					}
					db.SaveChanges();
					timer1.Start();
					MessageBox.Show("Siparişiniz Onaylanmıştır.");
					// Seçilen siparişin içindeki ürünleri al
					var siparisUrunler = db.SiparisUrunler.Where(su => su.SiparisId == siparis.Id).ToList();
					var siparisMenuUrunler = db.SiparisMenus.Where(su => su.SiparisId == siparis.Id).ToList();

					if (siparisUrunler.Count() > 0)
					{
						foreach (var siparisUrun in siparisUrunler)
						{
							// Ürünün malzemelerini ve miktarlarını al
							var urunMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == siparisUrun.UrunId).ToList();
							// Her bir malzeme için işlem yap
							foreach (var urunMalzeme in urunMalzemeler)
							{
								// Malzemenin stok miktarından düşülecek miktarı belirle
								int dusulecekMiktar = urunMalzeme.Miktar * siparisUrun.Miktar;

								// İlgili malzemenin stokunu bul
								var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == urunMalzeme.MalzemeId);

								// Eğer stok bulunduysa ve düşülecek miktar stok miktarından fazla değilse
								if (stok != null && stok.Miktar >= dusulecekMiktar)
								{
									// Malzemeden stoktan düşüm yap
									stok.Miktar -= dusulecekMiktar;

									string malzemeAd = db.Malzemeler.FirstOrDefault(s => s.Id == stok.MalzemeId).Ad;

									// Stok miktarı minimum stok değerine ulaştıysa veya altına düştüyse
									if (stok.Miktar < stok.MinStok)
									{
										if (!BildirimGonderildiMi(db, malzemeAd, "Min Stok Uyarısı"))
										{
											bildirim.Tarih = DateTime.Now;
											bildirim.Aciklama = $"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.";
											bildirim.Baslik = $"Min Stok Uyarısı";
											bildirim.KullaniciId = 1;
											bildirim.Okundu = false;

											db.Bildirimler.Add(bildirim);
											db.SaveChanges();
											Yardimcilar.SignalTetikleBildirimAlindi();
										}

									}
									else if (stok.Miktar == 0)
									{
										if (!BildirimGonderildiMi(db, malzemeAd, "Stok Kalmadı"))
										{
											bildirim.Tarih = DateTime.Now;
											bildirim.Aciklama = $"{malzemeAd} adlı malzemenin stoğu Tükendi.";
											bildirim.Baslik = $"Stok Kalmadı";
											bildirim.KullaniciId = 1;
											bildirim.Okundu = false;

											db.Bildirimler.Add(bildirim);
											db.SaveChanges();
											Yardimcilar.SignalTetikleBildirimAlindi();
										}
									}
									// Stok çıkışı kaydını oluştur
									var stokCikti = new StokCikti
									{
										Neden = "Sipariş Hazırlama",
										Miktar = dusulecekMiktar,
										SonStok = stok.Miktar,
										Gorunuluk = true, // Gösterim durumunu belirle
										TedarikciId = stok.TedarikciId,
										MalzemeId = stok.MalzemeId,
										Tarih = DateTime.Now // Şu anki zamanı ata
									};
									// Stok çıkışını veritabanına ekle
									db.stokCiktilar.Add(stokCikti);
								}
								else
								{
									// Ürünün aktifliğini kapat
									urunMalzeme.Urun.Akitf = false;
									timer1.Start();
									MessageBox.Show("Stok yetersiz.");
									return;
								}
							}
						}
					}
					else if (siparisMenuUrunler.Count > 0)
					{
						foreach (var siparisMenuUrun in siparisMenuUrunler)
						{
							// Sipariş menüsündeki her bir ürün için işlem yap
							var menuUrunler = db.MenuUrunler.Where(mu => mu.MenuId == siparisMenuUrun.MenuId).ToList();
							foreach (var menuUrun in menuUrunler)
							{
								// Ürünün malzemelerini ve miktarlarını al
								var urunMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == menuUrun.UrunId).ToList();
								// Her bir malzeme için işlem yap
								foreach (var urunMalzeme in urunMalzemeler)
								{
									// Malzemenin stok miktarından düşülecek miktarı belirle
									int dusulecekMiktar = urunMalzeme.Miktar * siparisMenuUrun.Miktar;

									// İlgili malzemenin stokunu bul
									var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == urunMalzeme.MalzemeId);

									// Eğer stok bulunduysa ve düşülecek miktar stok miktarından fazla değilse
									if (stok != null && stok.Miktar >= dusulecekMiktar)
									{
										// Malzemeden stoktan düşüm yap
										stok.Miktar -= dusulecekMiktar;

										string malzemeAd = db.Malzemeler.FirstOrDefault(s => s.Id == stok.MalzemeId).Ad;

										// Stok miktarı minimum stok değerine ulaştıysa veya altına düştüyse
										if (stok.Miktar < stok.MinStok)
										{
											if (!BildirimGonderildiMi(db, malzemeAd, "Min Stok Uyarısı"))
											{
												bildirim.Tarih = DateTime.Now;
												bildirim.Aciklama = $"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.";
												bildirim.Baslik = $"Min Stok Uyarısı";
												bildirim.KullaniciId = 1;
												bildirim.Okundu = false;

												db.Bildirimler.Add(bildirim);
												db.SaveChanges();
												Yardimcilar.SignalTetikleBildirimAlindi();
											}
										}
										else if (stok.Miktar == 0)
										{
											if (!BildirimGonderildiMi(db, malzemeAd, "Stok Kalmadı"))
											{
												bildirim.Tarih = DateTime.Now;
												bildirim.Aciklama = $"{malzemeAd} adlı malzemenin stoğu Tükendi.";
												bildirim.Baslik = $"Stok Kalmadı";
												bildirim.KullaniciId = 1;
												bildirim.Okundu = false;

												db.Bildirimler.Add(bildirim);
												db.SaveChanges();
												Yardimcilar.SignalTetikleBildirimAlindi();
											}
										}
										// Stok çıkışı kaydını oluştur
										var stokCikti = new StokCikti
										{
											Neden = "Sipariş Hazırlama",
											Miktar = dusulecekMiktar,
											SonStok = stok.Miktar,
											Gorunuluk = true, // Gösterim durumunu belirle
											TedarikciId = stok.TedarikciId,
											MalzemeId = stok.MalzemeId,
											Tarih = DateTime.Now // Şu anki zamanı ata
										};
										// Stok çıkışını veritabanına ekle
										db.stokCiktilar.Add(stokCikti);
									}
									else
									{
										// Ürünün aktifliğini kapat
										urunMalzeme.Urun.Akitf = false; 
										timer1.Start();
										MessageBox.Show("Stok yetersiz.");
										return;
									}
								}
							}
						}
					}
					//Sipariş Durumunun Ayarlandığı Kısım
					Durum.Ad = 2;//Sipariş Onaylandı
					Durum.Zaman = DateTime.Now;//Onaylanma Zamanı
					Durum.Yer = 1;//Bu işlem nerede yapıldı Müşteri Tarafında sipariş alındığında
					Durum.SiparisId = siparis.Id;
					db.Durumlar.Add(Durum);
					db.SaveChanges();

					bildirim.Okundu = false;
					bildirim.KullaniciId = 3;
					bildirim.Aciklama = $"{masa.Kod} nolu masadan Gelen Sipariş";
					bildirim.Baslik = "Yeni Sipariş Alındı";
					bildirim.Tarih = DateTime.Now;
					db.Bildirimler.Add(bildirim);
					db.SaveChanges();
					//SignalR Tetiklemeleri
					Yardimcilar.SignalTetikleMasaDurum();
					await Yardimcilar.SignalTetikleSiparis();
					this.Close();
					#endregion
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Kapalı Masada İşlem Yapamazsınız !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Siparişi Onaylamak İçin En Az 1 Ürün Seçmeniz Gerekmektedir !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void PaneliTemizle()
		{
			UrunPaneli.Controls.Clear();
		}

		private void ComboUrun_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loaddayuklendi == true)
			{
				ComboMenu.Text = "";
				int kategoriID = (int)ComboUrun.SelectedValue;
				PaneliTemizle();
				urunGosterici.UrunleriGoster(kategoriID);
			}
		}

		private void ComboMenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loaddayuklendi == true)
			{
				ComboUrun.Text = "";
				int kategoriID = (int)ComboMenu.SelectedValue;
				PaneliTemizle();
				urunGosterici.MenuleriGoster(kategoriID);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ComboUrun.Text = "";
			ComboMenu.Text = "";
			PaneliTemizle();
			urunGosterici.UrunleriGoster(0);
			urunGosterici.MenuleriGoster(0);
		}

		private void BosMasa_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (kullaniciId == 1)
			{
				var adminpaneliform = Application.OpenForms.OfType<Admin_Paneli>().FirstOrDefault();
				if (adminpaneliform != null)
				{
					// Grafikleri güncelle
					adminpaneliform.grafikleriGuncelle();
				}
			}
			else
			{
				var kasaPaneliForm = Application.OpenForms.OfType<KasaPaneli>().FirstOrDefault();
				if (kasaPaneliForm != null)
				{
					// Grafikleri güncelle
					kasaPaneliForm.grafikleriGuncelle();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Yardimcilar.GeriCik(timer1);
		}
	}
}
