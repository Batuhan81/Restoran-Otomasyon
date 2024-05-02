using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon.Paneller
{
	public partial class MenuESG : Form
	{
		public MenuESG()
		{
			InitializeComponent();
		}
		#region Global Değikenler
		bool gosterildi = false;
		private KategoriESG kategoriESGForm;
		Context db = new Context();
		decimal indirimliFiyat;
		decimal formatsizFiyat;
		decimal indirimliFiyatformatsiz;
		Data.Menu menu1 = new Data.Menu();
		private bool isGridLoading = false;
		int id;


		#endregion
		#region Metodlarım
		private void YuzdeHesabi()
		{
			formatsizFiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
			if (txtyuzde.Text != "")
			{
				int yuzdeMiktari = Convert.ToInt32(txtyuzde.Text);
				if (yuzdeMiktari <= 100)
				{
					indirimliFiyat = formatsizFiyat - (formatsizFiyat / 100 * yuzdeMiktari);
					txtindirimli.Text = indirimliFiyat.ToString();
					txtindirimli.Text = Yardimcilar.FormatliDeger(txtindirimli.Text);
				}
				else
				{
					timer1.Start();
					MessageBox.Show("İndirim Yüzdesi Olarak En Fazla %100 Verebilirsiniz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void İndirimUygula()
		{
			if (txtyuzde.Text == 0.ToString())
			{
				indirimliFiyat = Yardimcilar.TemizleVeDondur(txtindirimli, "");
			}
			if (hiddenMenuId.Text != "")
			{
				int id = Convert.ToInt32(hiddenMenuId.Text);
				var menu = db.Menuler.Find(id);
				menu.Fiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
				menu.IndirimliFiyat = indirimliFiyat;
				if (txtindirimTarihi.Text == "  .  .")
				{
					menu.IndirimTarihi = DateTime.MinValue;
				}
				else
				{
					menu.IndirimTarihi = Convert.ToDateTime(txtindirimTarihi.Text);
				}
				menu.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);
				db.SaveChanges();
				MessageBox.Show("İndirim Uygulandı");
				Checkİndirim.Checked = false;
				MenuList();
			}
			else if(txtindirimli.Text.Length> 0)
			{
				timer1.Start();
				MessageBox.Show("Kayıt Eklenirken İndirim Uygulanacaktır", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		public void menukategoriler()
		{
			comboKategori.DataSource = null;
			var kategoriler = db.Kategoriler.Where(o => o.Gorunurluk == true && o.Tur == "Menü").Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
			}).ToList();
			comboKategori.DataSource = kategoriler;
			comboKategori.DisplayMember = "Ad";
			comboKategori.ValueMember = "Id";
		}
		void UrunListe()
		{
			var Uruns = db.Urunler
								.Where(m => m.Gorunurluk == true)
								.Select(m => m.Ad) // Sadece malzeme adını seç
								.ToList();

			checkedListMalzeme.DataSource = Uruns;
		}
		void MenuList()
		{
			var Menuler = db.Menuler.Where(o => o.Gorunurluk == true).Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
				Aciklama = o.Aciklama,
				Detay = o.Detay,
				Fiyat = o.Fiyat,
				Fotoğraf = o.Fotograf,
				Aktiflik = o.Akitf ? "Aktif" : "Pasif",
				İndirimliFiyat = o.IndirimliFiyat,
				İndirimTarihi = o.IndirimTarihi,
				Yüzde = o.IndirimYuzdesi,
				Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategoriId).Ad,
			}).ToList();

			gridMenu.DataSource = Menuler;
			gridMenu.Columns["Fotoğraf"].Visible = false;
			gridMenu.Columns["Id"].Visible = true;
		}
		#endregion
		#region Butonlar
		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupMenu))
			{
				if (uzanti.Text != "")
				{
					if (!Yardimcilar.GecerliTarihMi(txtindirimTarihi.Text))
					{
						if (checkedListMalzeme.CheckedItems.Count != 0)
						{

							if (hiddenMenuId.Text == "")//Kayıt Ekleme İşlemi
							{
								menu1.Ad = txtad.Text;
								menu1.Aciklama = txtaciklama.Text;
								if (txtdetay.Text.EndsWith(","))
								{
									menu1.Detay = txtdetay.Text.Remove(txtdetay.Text.Length - 1);
								}
								else
								{
									menu1.Detay = txtdetay.Text;
								}

								menu1.Fiyat = formatsizFiyat;
								menu1.Fotograf = uzanti.Text;
								if (Aktiflik.Checked)
								{
									menu1.Akitf = true;
								}
								else
								{
									menu1.Akitf = false;
								}
								//İlk Kayıt edilirken inidirim yok Şimdilik
								if (txtindirimTarihi.Text == "  .  .")
								{
									menu1.IndirimTarihi = DateTime.MinValue;
								}
								else
								{
									menu1.IndirimTarihi = DateTime.Parse(txtindirimTarihi.Text);

								}
								menu1.IndirimliFiyat = indirimliFiyat;
								if (txtyuzde.Text == "")
								{
									txtyuzde.Text = 0.ToString();
								}
								menu1.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);

								menu1.KategoriId = (int)comboKategori.SelectedValue;
								menu1.Gorunurluk = true;
								db.Menuler.Add(menu1);
								timer1.Start();
								MessageBox.Show("Yeni Ürün Kayıt Edildi");
								db.SaveChanges();
								id = db.Menuler.Max(o => o.Id);
								// Her bir seçilen malzeme için işlem yap
								foreach (DataGridViewRow row in gridSecilenUrunler.Rows)
								{
									if (row.Cells["Miktar"].Value != null && Convert.ToInt32(row.Cells["Miktar"].Value) > 0)
									{
										// Seçilen malzemenin miktarını al
										int miktar = Convert.ToInt32(row.Cells["Miktar"].Value.ToString());

										// Seçilen malzemenin ID'sini al
										int UrunID = Convert.ToInt32(row.Cells["MalzemeID"].Value.ToString());

										// UrunMalzeme nesnesi oluştur
										MenuUrun menuUrun = new MenuUrun();
										menuUrun.Miktar = miktar;
										menuUrun.MenuId = id; // Burada ürün ID'si olacak
										menuUrun.UrunId = UrunID;
										menuUrun.Gorunurluk = true;
										db.MenuUrunler.Add(menuUrun);
										db.SaveChanges();
									}
								}
							}
							else//Güncelleme İşlemi
							{
								id = Convert.ToInt32(hiddenMenuId.Text);
								var x = db.Menuler.Find(id);
								x.Ad = txtad.Text;
								x.Aciklama = txtaciklama.Text;
								if (txtdetay.Text.EndsWith(","))
								{
									x.Detay = txtdetay.Text.Remove(txtdetay.Text.Length - 1);
								}
								else
								{
									x.Detay = txtdetay.Text;
								}

								x.Fiyat = formatsizFiyat;
								x.Fotograf = uzanti.Text;
								if (Aktiflik.Checked)
								{
									x.Akitf = true;
								}
								else
								{
									x.Akitf = false;
								}
								if (txtindirimTarihi.Text != "  .  .")
								{
									x.IndirimTarihi = DateTime.Parse(txtindirimTarihi.Text);
								}
								else
								{
									x.IndirimTarihi = DateTime.MinValue;
								}
								x.IndirimliFiyat = Yardimcilar.TemizleVeDondur(txtindirimli, "");
								x.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);
								x.KategoriId = (int)comboKategori.SelectedValue;
								timer1.Start();
								MessageBox.Show("Ürün Güncellendi");
								// Gridde olmayan malzeme ID'leri için HashSet oluşturun
								HashSet<int> gridUrunIdsi = new HashSet<int>();

								// Mevcut malzemelerin güncellenmesi veya silinmesi
								foreach (DataGridViewRow row in gridSecilenUrunler.Rows)
								{
									int UrunID = Convert.ToInt32(row.Cells["MalzemeID"].Value);
									int miktar = row.Cells["Miktar"].Value != null ? Convert.ToInt32(row.Cells["Miktar"].Value) : 0;

									gridUrunIdsi.Add(UrunID);

									var Urun = db.MenuUrunler.FirstOrDefault(um => um.MenuId == id && um.UrunId == UrunID);

									if (Urun != null)
									{
										if (miktar > 0)
										{
											// Mevcut malzemenin miktarını güncelle ve görünürlüğünü açık bırak
											Urun.Miktar = miktar;
											Urun.Gorunurluk = true;
										}
										else
										{
											// Miktarı sıfır veya null olan malzemenin görünürlüğünü kapat
											Urun.Gorunurluk = false;
										}
									}
									else if (miktar > 0)
									{
										// Yeni malzemenin eklenmesi
										MenuUrun yeniUrun = new MenuUrun
										{
											MenuId = id,
											UrunId = UrunID,
											Miktar = miktar,
											Gorunurluk = true
										};
										db.MenuUrunler.Add(yeniUrun);
									}
								}

								// Veritabanında olan ve gridde olmayan malzemeleri kontrol edin
								var vturunleri = db.MenuUrunler.Where(um => um.MenuId == id && !gridUrunIdsi.Contains(um.UrunId));

								foreach (var vtUrun in vturunleri)
								{
									// Gridde bulunmayan malzemelerin görünürlüğünü kapat
									vtUrun.Gorunurluk = false;
								}
								MalzemeSecPaneli.Visible = false;
							}
							Yardimcilar.Temizle(groupMenu);
							db.SaveChanges();
							MenuList();
							Aktiflik.Checked = true;
							pictureBox1.Visible = false;
							Checkİndirim.Checked = false;
							PanelKategori.Visible = false;
							MalzemeSecPaneli.Visible = false;
						}
						else
						{
							timer1.Start();
							MessageBox.Show("Menü İçin Malzeme Bilgilerini Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Geçerli Bir Tarih Girdiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Menüye Bir Fotoğraf Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Menüye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			İndirimUygula();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (hiddenUrunId.Text != "")
			{
				int id = Convert.ToInt32(hiddenUrunId.Text);
				var menu = db.Menuler.Find(id);
				menu.IndirimliFiyat = 0;
				menu.IndirimTarihi = DateTime.MinValue.Date;
				if (txtyuzde.Text != "")
				{
					menu.IndirimYuzdesi = 0;
				}
				db.SaveChanges();
				MessageBox.Show("İndirim Kaldırıldı");
				txtindirimli.Text = "";
				txtyuzde.Text = "";
				txtindirimTarihi.Text = "";
				Checkİndirim.Checked = false;
				MenuList();
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			int MenuID = Convert.ToInt32(hiddenMenuId.Text);
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenMenuId.Text != "")//Ürünün görünürlüğünün kapattım
				{
					int id = Convert.ToInt32(hiddenMenuId.Text);
					var urun = db.Menuler.Find(id);
					urun.Gorunurluk = false;
					db.SaveChanges();

					timer1.Start();
					MessageBox.Show("Kayıt Silindi");
					Yardimcilar.Temizle(groupMenu);
					// Ürüne ait malzemeleri bul
					var MenuUrunler = db.MenuUrunler.Where(um => um.MenuId == MenuID).ToList();

					// Her bir malzemenin görünürlüğünü kapat
					foreach (var urunMalzeme in MenuUrunler)
					{
						urunMalzeme.Gorunurluk = false;
					}
					MenuList();
				}
			}
		}
		private void button4_Click(object sender, EventArgs e)
		{
			if (MalzemeSecPaneli.Visible != true)
			{
				MalzemeSecPaneli.Visible = true;

				UrunListe();
			}
			else
			{
				MalzemeSecPaneli.Visible = false;
			}
		}

		private void MenuESG_Load(object sender, EventArgs e)
		{
			menukategoriler();
			MenuList();
			Yardimcilar.GridRenklendir(gridMenu);
			Yardimcilar.GridRenklendir(gridSecilenUrunler);
			Aktiflik.Checked=true;
			if (gridSecilenUrunler.Columns.Count == 0)
			{
				gridSecilenUrunler.Columns.Add("MalzemeAdi", "Malzeme Adı");
				gridSecilenUrunler.Columns.Add("MalzemeID", "Malzeme ID");
				gridSecilenUrunler.Columns.Add("Miktar", "Miktar");
				gridSecilenUrunler.Columns.Add("Arttir", "Arttır");
				gridSecilenUrunler.Columns.Add("Azalt", "Azalt");
			}

			// Arttırma ve azaltma butonları için sütunları ekledikten sonra, her satıra butonları eklememiz gerekiyor
			foreach (DataGridViewRow row in gridSecilenUrunler.Rows)
			{
				// Arttırma butonu
				DataGridViewButtonCell arttirButtonCell = new DataGridViewButtonCell();
				arttirButtonCell.Value = "+";
				row.Cells["Arttir"] = arttirButtonCell;

				// Azaltma butonu
				DataGridViewButtonCell azaltButtonCell = new DataGridViewButtonCell();
				azaltButtonCell.Value = "-";
				row.Cells["Azalt"] = azaltButtonCell;
			}
			panelİndirim.Visible = false;
			// Malzeme ID'sini saklamak için gizli bir sütun ekle
			gridSecilenUrunler.Columns["MalzemeID"].Visible = false;
			gridMenu.Columns["Id"].Visible = false;
		}
		private void btnresim_Click(object sender, EventArgs e)
		{
			// Resim seçme işlemi için Yardimcilar.ResimBoyutlandir.DosyaSec metodunu kullan
			Image selectedImage = Yardimcilar.ResimBoyutlandir.DosyaSec(pictureBox1, uzanti);

			// Seçilen resim varsa, boyutlandır ve PictureBox'ta göster
			if (selectedImage != null)
			{
				// Seçilen fotoğrafın dosya yolunu uzanti Label'ına kaydet
				string imagePath = uzanti.Text;

				// Resmi boyutlandır
				Image resizedImage = Yardimcilar.ResimBoyutlandir.Boyutlandir(selectedImage, pictureBox1.Width, pictureBox1.Height);
				pictureBox1.Image = resizedImage;
			}
		}
		private void button7_Click(object sender, EventArgs e)
		{
			if (PanelKategori.Visible != true)
			{
				PanelKategori.Visible = true;
				foreach (Control item in PanelKategori.Controls)
				{
					item.Visible = false;
				}
				kategoriESGForm = new KategoriESG();
				Yardimcilar.OpenForm(kategoriESGForm, PanelKategori);
				comboKategori.Text = "";
			}
			else
			{
				PanelKategori.Visible = false;
				foreach (Control item in PanelKategori.Controls)
				{
					item.Visible = true;
				}
				// Açılan formu kapatmak için
				if (kategoriESGForm != null && !kategoriESGForm.IsDisposed)
				{
					kategoriESGForm.Close();
				}
			}
		}
		#endregion
		#region Eventler
		private void txtindirimli_Leave(object sender, EventArgs e)
		{
			decimal fiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
			decimal indirim = Yardimcilar.TemizleVeDondur(txtindirimli, "");
			if (fiyat > indirim)
			{
				if (txtindirimli.Text != "")
				{
					indirimliFiyatformatsiz = Yardimcilar.TemizleVeDondur(txtindirimli, "");
					txtindirimli.Text = Yardimcilar.FormatliDeger(txtindirimli.Text);
				}
			}
			else
			{
				MessageBox.Show("Girmeye Çalıştığınız Değer Ürünün Kendi Fiyatından Yüksek", "İşlem Yapılamaz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtindirimli.Text = "";
			}
		}

		private void txtyuzde_Leave(object sender, EventArgs e)
		{
			YuzdeHesabi();
		}

		private void txtindirimli_Click(object sender, EventArgs e)
		{
			txtyuzde.Text = 0.ToString();
		}
		private void gridUrun_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridMenu.Rows[e.RowIndex];
				// TextBox'lara ürün bilgilerini doldur
				txtad.Text = row.Cells["Ad"].Value.ToString();
				txtaciklama.Text = row.Cells["Aciklama"].Value.ToString();
				txtdetay.Text = row.Cells["Detay"].Value.ToString();
				uzanti.Text = row.Cells["Fotoğraf"].Value.ToString();
				Aktiflik.Checked = row.Cells["Aktiflik"].Value.ToString() == "Aktif" ? true : false;
				txtyuzde.Text = row.Cells["Yüzde"].Value.ToString();
				comboKategori.Text = row.Cells["Kategori"].Value.ToString();
				DateTime indirimTarihi = Convert.ToDateTime(row.Cells["İndirimTarihi"].Value.ToString());

				formatsizFiyat=Convert.ToDecimal( row.Cells["Fiyat"].Value.ToString());
				txtfiyat.Text = Yardimcilar.FormatliDeger(formatsizFiyat.ToString());

				indirimliFiyat= Convert.ToDecimal(row.Cells["İndirimliFiyat"].Value.ToString());
				txtindirimli.Text = Yardimcilar.FormatliDeger(indirimliFiyat.ToString());

				formatsizFiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
				if (indirimTarihi == DateTime.MinValue)
				{
					txtindirimTarihi.Text = "";
				}
				else
				{
					txtindirimTarihi.Text = indirimTarihi.ToString();
				}

				// Menü ID'sini sakla (Güncelleme işlemi için kullanılacak)
				int menuId = Convert.ToInt32(row.Cells["Id"].Value.ToString());
				hiddenMenuId.Text = menuId.ToString();
				isGridLoading = true;
				// Eğer resim yolu boş değilse, resmi boyutlandır
				if (!string.IsNullOrEmpty(uzanti.Text))
				{
					// Seçilen resmin yolunu kullanarak boyutlandır ve PictureBox'ta göster
					Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(uzanti.Text, pictureBox1.Width, pictureBox1.Height);
					pictureBox1.Image = resizedImage;
					pictureBox1.Visible = true;
				}
				else
				{
					// Resim yolu boşsa, PictureBox'ı temizle
					pictureBox1.Image = null;
				}
				// Ürün ID'sine göre ilişkili malzemeleri getir
				var MenuUrun = db.MenuUrunler.Where(o => o.MenuId == menuId && o.Gorunurluk == true).ToList();

				// Mevcut satırları temizle
				gridSecilenUrunler.Rows.Clear();
				UrunListe();

				// Her bir ilişkili malzeme için işlem yap
				foreach (var urunMalzeme in MenuUrun)
				{
					// Malzeme özelliği null değilse, Ad özelliğine güvenle erişebiliriz
					string UrunAdi = db.Urunler.FirstOrDefault(o => o.Id == urunMalzeme.UrunId && o.Gorunurluk == true)?.Ad;

					// Sadece görünür olan malzemelerin işlenmesi
					if (!string.IsNullOrEmpty(UrunAdi))
					{
						int rowIndex = gridSecilenUrunler.Rows.Add(UrunAdi, urunMalzeme.UrunId, urunMalzeme.Miktar, "+", "-");

						// Buraya +- eksi butonlarını oluşturacak ve işlevlerinin itemcheck metodundaki yerine getirecek bir şey ekle

						int index = -1;
						for (int i = 0; i < checkedListMalzeme.Items.Count; i++)
						{
							// Eğer malzeme ID'si checkedListMalzeme içinde bulunuyorsa, dizinini al
							if (checkedListMalzeme.Items[i].ToString() == UrunAdi)
							{
								index = i;
								break;
							}
						}

						// Eğer malzeme ID'si checkedListMalzeme içinde bulunuyorsa, işaretle
						if (index != -1)
						{
							checkedListMalzeme.SetItemChecked(index, true);
						}
					}
				}
			}
		}
		private void gridUrun_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value != null && e.ColumnIndex == gridMenu.Columns["Yüzde"].Index) // İndirimliFiyat sütununun indeksi
			{
				decimal Yuzde;
				if (decimal.TryParse(e.Value.ToString(), out Yuzde)) // İndirimli fiyat değerini decimal'e dönüştür
				{
					if (Yuzde == 0)
					{
						e.Value = "Yok"; // Eğer indirimli fiyat 0 ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
				Yardimcilar.GridFormat(gridMenu, "Yüzde", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridMenu.Columns["İndirimliFiyat"].Index) // İndirimliFiyat sütununun indeksi
			{
				decimal indirimliFiyat;
				if (decimal.TryParse(e.Value.ToString(), out indirimliFiyat)) // İndirimli fiyat değerini decimal'e dönüştür
				{
					if (indirimliFiyat == 0)
					{
						e.Value = "Yok"; // Eğer indirimli fiyat 0 ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
				Yardimcilar.GridFormat(gridMenu, "İndirimliFiyat", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridMenu.Columns["İndirimTarihi"].Index) // İndirimTarihi sütununun indeksi
			{
				DateTime indirimTarihi;
				if (DateTime.TryParse(e.Value.ToString(), out indirimTarihi)) // İndirim tarihi değerini DateTime'a dönüştür
				{
					if (indirimTarihi == DateTime.MinValue)
					{
						e.Value = "Yok"; // Eğer indirim tarihi min date ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
			}
			Yardimcilar.GridFormat(gridMenu, "Fiyat", e);
		}

		private void txtfiyat_Leave(object sender, EventArgs e)
		{
			decimal guncelfiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
			if (formatsizFiyat != guncelfiyat)
			{
				YuzdeHesabi();
				İndirimUygula();
			}
			if (txtfiyat.Text != "")
			{
				formatsizFiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
				txtfiyat.Text = Yardimcilar.FormatliDeger(txtfiyat.Text);
			}
		}
		private void Checkİndirim_CheckedChanged(object sender, EventArgs e)
		{
			if (gosterildi == false)
			{
				//if (hiddenMenuId.Text != "")
				//{
					if (Checkİndirim.Checked == true)
					{
						panelİndirim.Visible = true;
						//foreach (Control item in MalzemeSecPaneli.Controls)//tek panelde 2 farklı alan açıyordum boyut farkından dolayı kaldırdım
						//{
						//	if (!(item is Panel))
						//	{
						//		item.Visible = false;
						//	}
						//}
						panelİndirim.Visible = true;
					}
					else
					{
						panelİndirim.Visible = false;
					}
				//}
				//else
				//{
				//	timer1.Start();
				//	MessageBox.Show("Ürünü Kayıt Etmeden İndirim Uygulayamazsınız", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//	gosterildi = true;
				//	Checkİndirim.Checked = false;
				//}
			}
			gosterildi = false;
		}
		private void checkedListMalzeme_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (!isGridLoading) // Grid yüklenirken işlem yapmayı engelle
			{
				string secilenurunAdi = checkedListMalzeme.Items[e.Index].ToString();
				int secilenurunId = db.Urunler.FirstOrDefault(o => o.Ad == secilenurunAdi)?.Id ?? 0;

				// Kontrol etmek için gridSecilenMalzemeler'deki her bir satırdaki malzeme adını ara
				bool malzemeVar = false;
				foreach (DataGridViewRow existingRow in gridSecilenUrunler.Rows)
				{
					if (existingRow.Cells["MalzemeAdi"].Value != null && existingRow.Cells["MalzemeAdi"].Value.ToString() == secilenurunAdi)
					{
						malzemeVar = true;
						break;
					}
				}

				if (!malzemeVar && e.NewValue == CheckState.Checked)
				{
					// Yeni bir satır oluştur ve verileri ekle
					DataGridViewRow newRow = new DataGridViewRow();
					newRow.CreateCells(gridSecilenUrunler);
					newRow.Cells[0].Value = secilenurunAdi;
					newRow.Cells[1].Value = secilenurunId;
					newRow.Cells[2].Value = 1; // Başlangıçta miktarı 1 olarak ayarla
					newRow.Cells[3].Value = "+";
					newRow.Cells[4].Value = "-";
					
					gridSecilenUrunler.Rows.Add(newRow);
					txtdetay.Text += secilenurunAdi + ",";
				}

				if (malzemeVar && e.NewValue != CheckState.Checked)
				{
					foreach (DataGridViewRow existingRow in gridSecilenUrunler.Rows)
					{
						if (existingRow.Cells["MalzemeAdi"].Value != null && existingRow.Cells["MalzemeAdi"].Value.ToString() == secilenurunAdi)
						{
							// Malzeme listeden çıkar
							gridSecilenUrunler.Rows.Remove(existingRow);
							break;
						}
					}
					// Detaydan malzemeyi çıkart
					txtdetay.Text = txtdetay.Text.Replace(secilenurunAdi + ",", "");
				}
			}
			else
			{
				isGridLoading = false;
			}
		}
		private void gridSecilenUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenUrunler.Columns["Arttir"].Index)
			{
				int currentMiktar = Convert.ToInt32(gridSecilenUrunler.Rows[e.RowIndex].Cells["Miktar"].Value);
				gridSecilenUrunler.Rows[e.RowIndex].Cells["Miktar"].Value = currentMiktar + 1;
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenUrunler.Columns["Azalt"].Index)
			{
				int currentMiktar = Convert.ToInt32(gridSecilenUrunler.Rows[e.RowIndex].Cells["Miktar"].Value);
				if (currentMiktar > 0)
					gridSecilenUrunler.Rows[e.RowIndex].Cells["Miktar"].Value = currentMiktar - 1;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)//Mboxları otomatik kapatma
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}
		private void gridSecilenUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenUrunler.Columns["Miktar"].Index)
			{
				DataGridViewTextBoxCell cell = gridSecilenUrunler.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;

				if (!gridSecilenUrunler.IsCurrentCellInEditMode)
				{
					gridSecilenUrunler.BeginEdit(true);
				}
			}
			isGridLoading = false;
		}
		#endregion
	}
}
