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
			Context db = new Context();
			var tumMalzemeler = db.Malzemeler.ToList();

			foreach (var malzeme in tumMalzemeler)
			{
				// Malzemenin stok bilgisini al
				var stok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzeme.Id);

				if (stok != null)
				{
					//Eğer malze miktarları koşullardan daha küçükse o malzemeyi kullanan her şeyin aktifliği kapatıp sipariş verilmesini engelliyorum
					if ((malzeme.Tur == "Adet" && stok.Miktar <= 5) ||
						(malzeme.Tur == "Kg" && stok.Miktar <= 500) ||
						(malzeme.Tur == "L" && stok.Miktar <= 500))
					{
						// Malzemeyi kullanan tüm ürünleri bul
						var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).ToList();

						foreach (var urun in urunler)
						{
							// Ürünün aktifliğini kapat
							urun.Urun.Akitf = false;

							// Ürünü kullanan menülerin aktifliğini kapat
							var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.UrunId).Select(mu => mu.Menu).Distinct().ToList();
							foreach (var menu in kullananMenuler)
							{
								menu.Akitf = false;
							}
						}
					}
					else if (stok.Miktar >= stok.MinStok)
					{
						// Malzemeyi kullanan tüm ürünleri bul
						var urunler = db.urunMalzemeler.Where(u => u.MalzemeId == malzeme.Id).ToList();

						foreach (var urun in urunler)
						{
							// Ürünün aktifliğini aç
							urun.Urun.Akitf = true;

							// Ürünü kullanan menülerin aktifliğini aç
							var kullananMenuler = db.MenuUrunler.Where(mu => mu.UrunId == urun.UrunId).Select(mu => mu.Menu).Distinct().ToList();
							foreach (var menu in kullananMenuler)
							{
								menu.Akitf = true;
							}
						}
					}
				}
			}
			// Değişiklikleri kaydet
			db.SaveChanges();
		}

		private UrunGosterici urunGosterici;
		private void BosMasa_Load(object sender, EventArgs e)
		{
			// UrunGosterici sınıfından bir örnek oluşturun
			urunGosterici = new UrunGosterici(UrunPaneli, gridSiparisler, txttutar, db);
			StokKontrol();
			MasaBilgileri();
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

		private void button2_Click(object sender, EventArgs e)//Sipariş Onaylama Butonu
		{
			#region Masaya İlk Kez Sipariş Veriliyorsa
			// Yeni bir sipariş oluştur
			Siparis siparis = new Siparis();
			MasaSiparis masasip = new MasaSiparis();
			Masa masa = new Masa();
			Durum Durum = new Durum();
			//Bu kısımda bir masaya tıklanıldığında eğer masa durumu rezerve ise durumunu gerçekleştiye çeviriyor yani rezerve eden kişinin geldiğini anlamına geliyor.
			var x = db.Masalar.Find(masaId);
			if (x.Durum == 1)//mayasa ilk kez sipariş alınıyorsa burası çalışsın
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

									// Değişiklikleri veritabanına kaydedin
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
									//Bunu daha sonra Admine bildirim olarak atıcaz
									MessageBox.Show($"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.");
								}
								else if (stok.Miktar == 0)
								{
									MessageBox.Show($"{malzemeAd} adlı malzeme kalmadı.");
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
										//Bunu daha sonra Admine bildirim olarak atıcaz
										MessageBox.Show($"{malzemeAd} adlı malzeme belirtilen MinStok değerinin altına indi.");
									}
									else if (stok.Miktar == 0)
									{
										MessageBox.Show($"{malzemeAd} adlı malzeme kalmadı.");
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
				MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
				if (calisanForm != null)
				{
					calisanForm.MasaButonlariniGuncelle();
				}
				this.Close();
				#endregion
			}
			else//mevcuttaki bir siparişe ekstra sipariş veriliyorsada burası çalışmalı
			{

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
	}
}
