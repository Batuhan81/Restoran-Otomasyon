using Org.BouncyCastle.Asn1.X509;
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
using static Restoran_Otomasyon.Yardimcilar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restoran_Otomasyon.Paneller
{
	public partial class UrunESG : Form
	{
		public UrunESG()
		{
			InitializeComponent();
		}
		#region Global Degiskenler
		decimal indirimliFiyat;
		bool gosterildi = false;
		private KategoriESG kategoriESGForm;
		decimal formatsizFiyat;
		decimal indirimliFiyatformatsiz;
		Context db = new Context();
		Malzeme mal = new Malzeme();
		Urun urn = new Urun();
		UrunMalzeme Umalzeme = new UrunMalzeme();
		int id;
		private bool isGridLoading = false;
		#endregion

		#region Metodlar
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
					txtyuzde.Text = 0.ToString();
				}
			}
		}

		private void İndirimUygula()
		{
			if (txtyuzde.Text == 0.ToString())
			{
				indirimliFiyat = Yardimcilar.TemizleVeDondur(txtindirimli, "");
			}
			if (hiddenUrunId.Text != "")
			{
				int id = Convert.ToInt32(hiddenUrunId.Text);
				var urun = db.Urunler.Find(id);
				urun.Fiyat = Yardimcilar.TemizleVeDondur(txtfiyat, "");
				urun.IndirimliFiyat = indirimliFiyat;
				if (txtindirimTarihi.Text == "  .  .")
				{
					urun.IndirimTarihi = DateTime.MinValue;
				}
				else
				{
					urun.IndirimTarihi = Convert.ToDateTime(txtindirimTarihi.Text);
				}
				urun.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);
				db.SaveChanges();
				MessageBox.Show("İndirim Uygulandı");
				Checkİndirim.Checked = false;
				Urunlist(gridUrun);
			}
			else if (txtindirimli.Text.Length > 0)
			{
				timer1.Start();
				MessageBox.Show("Kayıt Eklenirken İndirim Uygulanacaktır", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}


		public void kategoriler()
		{

			comboKategori.DataSource = null;
			var kategoriler = db.Kategoriler.Where(o => o.Gorunurluk == true && o.Tur == "Ürün").Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
			}).ToList();
			comboKategori.DataSource = kategoriler;
			comboKategori.DisplayMember = "Ad";
			comboKategori.ValueMember = "Id";

			// txtRolAra için ayrı bir veri kaynağı oluştur
			var kategoriListesi = db.Kategoriler.Where(o => o.Gorunurluk == true && o.Tur == "Ürün").ToList();
			KategoriAra.DisplayMember = "Ad";
			KategoriAra.ValueMember = "Id";
			KategoriAra.DataSource = kategoriListesi;

		}

		void MalzemeListe()
		{
			var malzemeler = db.Malzemeler
								.Where(m => m.Gorunurluk == true)
								.Select(m => m.Ad) // Sadece malzeme adını seç
								.ToList();
			checkedListMalzeme.ClearSelected();
			checkedListMalzeme.DataSource = malzemeler;
		}

		#endregion

		#region Eventler
		private void checkedListMalzeme_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (!isGridLoading) // Grid yüklenirken işlem yapmayı engelle
			{
				string secilenMalzemeAdi = checkedListMalzeme.Items[e.Index].ToString();
				int secilenMalzemeID = db.Malzemeler.FirstOrDefault(o => o.Ad == secilenMalzemeAdi)?.Id ?? 0;

				// Kontrol etmek için gridSecilenMalzemeler'deki her bir satırdaki malzeme adını ara
				bool malzemeVar = false;
				foreach (DataGridViewRow existingRow in gridSecilenMalzemeler.Rows)
				{
					if (existingRow.Cells["MalzemeAdi"].Value != null && existingRow.Cells["MalzemeAdi"].Value.ToString() == secilenMalzemeAdi)
					{
						malzemeVar = true;
						break;
					}
				}

				if (!malzemeVar && e.NewValue == CheckState.Checked)
				{
					// Yeni bir satır oluştur ve verileri ekle
					DataGridViewRow newRow = new DataGridViewRow();
					newRow.CreateCells(gridSecilenMalzemeler);
					newRow.Cells[0].Value = secilenMalzemeAdi;
					newRow.Cells[1].Value = secilenMalzemeID;
					newRow.Cells[2].Value = 1; // Başlangıçta miktarı 1 olarak ayarla
					newRow.Cells[3].Value = "+";
					newRow.Cells[4].Value = "-";
					// Malzeme ID'sini saklamak için gizli bir sütun ekle
					gridSecilenMalzemeler.Rows.Add(newRow);
					txtdetay.Text += secilenMalzemeAdi + ",";
				}

				if (malzemeVar && e.NewValue != CheckState.Checked)
				{
					foreach (DataGridViewRow existingRow in gridSecilenMalzemeler.Rows)
					{
						if (existingRow.Cells["MalzemeAdi"].Value != null && existingRow.Cells["MalzemeAdi"].Value.ToString() == secilenMalzemeAdi)
						{
							// Malzeme listeden çıkar
							gridSecilenMalzemeler.Rows.Remove(existingRow);
							break;
						}
					}
					// Detaydan malzemeyi çıkart
					txtdetay.Text = txtdetay.Text.Replace(secilenMalzemeAdi + ",", "");
				}
			}
			else
			{
				isGridLoading = false;
			}
		}

		private void gridSecileMalzemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenMalzemeler.Columns["Arttir"].Index)
			{
				int currentMiktar = Convert.ToInt32(gridSecilenMalzemeler.Rows[e.RowIndex].Cells["Miktar"].Value);
				gridSecilenMalzemeler.Rows[e.RowIndex].Cells["Miktar"].Value = currentMiktar + 1;
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenMalzemeler.Columns["Azalt"].Index)
			{
				int currentMiktar = Convert.ToInt32(gridSecilenMalzemeler.Rows[e.RowIndex].Cells["Miktar"].Value);
				if (currentMiktar > 0)
					gridSecilenMalzemeler.Rows[e.RowIndex].Cells["Miktar"].Value = currentMiktar - 1;
			}
		}

		private void UrunESG_Load(object sender, EventArgs e)
		{
			kategoriler();
			Yardimcilar.Urunlist(gridUrun);
			Yardimcilar.GridRenklendir(gridUrun);
			Yardimcilar.GridRenklendir(gridSecilenMalzemeler);
			CheckAktiflik.Checked = true;
			CheckGorunurluk.Checked = true;
			if (gridSecilenMalzemeler.Columns.Count == 0)
			{
				gridSecilenMalzemeler.Columns.Add("MalzemeAdi", "Malzeme Adı");
				gridSecilenMalzemeler.Columns.Add("MalzemeID", "Malzeme ID");
				gridSecilenMalzemeler.Columns.Add("Miktar", "Miktar");
				gridSecilenMalzemeler.Columns.Add("Arttir", "Arttır");
				gridSecilenMalzemeler.Columns.Add("Azalt", "Azalt");
			}
			// Arttırma ve azaltma butonları için sütunları ekledikten sonra, her satıra butonları eklememiz gerekiyor
			foreach (DataGridViewRow row in gridSecilenMalzemeler.Rows)
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
			gridSecilenMalzemeler.Columns["MalzemeID"].Visible = false;
			gridUrun.Columns["Id"].Visible = false;
			FiltreKaldır();
		}

		private void gridUrun_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridUrun.Rows[e.RowIndex];
				// TextBox'lara ürün bilgilerini doldur
				txtad.Text = row.Cells["Ad"].Value.ToString();
				txtaciklama.Text = row.Cells["Aciklama"].Value.ToString();
				txtdetay.Text = row.Cells["Detay"].Value.ToString();
				uzanti.Text = row.Cells["Fotoğraf"].Value.ToString();
				CheckAktiflik.Checked = row.Cells["Aktiflik"].Value.ToString() == "Aktif" ? true : false;
				CheckGorunurluk.Checked = row.Cells["Görünürlük"].Value.ToString() == "Görünür" ? true : false;
				indirimliFiyat = Convert.ToDecimal(row.Cells["İndirimliFiyat"].Value.ToString());
				txtindirimli.Text = Yardimcilar.FormatliDeger(indirimliFiyat.ToString());
				txtyuzde.Text = row.Cells["Yüzde"].Value.ToString();
				comboKategori.Text = row.Cells["Kategori"].Value.ToString();
				DateTime indirimTarihi = Convert.ToDateTime(row.Cells["İndirimTarihi"].Value.ToString());
				formatsizFiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value.ToString());
				txtfiyat.Text = Yardimcilar.FormatliDeger(formatsizFiyat.ToString());
				formatsizFiyat = TemizleVeDondur(txtfiyat, "");
				if (indirimTarihi == DateTime.MinValue)
				{
					txtindirimTarihi.Text = "";
				}
				else
				{
					txtindirimTarihi.Text = indirimTarihi.ToString();
				}
				// Ürün ID'sini sakla (Güncelleme işlemi için kullanılacak)
				int urunId = Convert.ToInt32(row.Cells["Id"].Value.ToString());
				hiddenUrunId.Text = urunId.ToString();
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
				var urunMalzemeler = db.urunMalzemeler.Where(o => o.UrunId == urunId && o.Gorunurluk == true).ToList();

				// Mevcut satırları temizle
				gridSecilenMalzemeler.Rows.Clear();
				MalzemeListe();

				// Her bir ilişkili malzeme için işlem yap
				foreach (var urunMalzeme in urunMalzemeler)
				{
					// Malzeme özelliği null değilse, Ad özelliğine güvenle erişebiliriz
					string malzemeAdi = db.Malzemeler.FirstOrDefault(o => o.Id == urunMalzeme.MalzemeId && o.Gorunurluk == true)?.Ad;

					// Sadece görünür olan malzemelerin işlenmesi
					if (!string.IsNullOrEmpty(malzemeAdi))
					{
						int rowIndex = gridSecilenMalzemeler.Rows.Add(malzemeAdi, urunMalzeme.MalzemeId, urunMalzeme.Miktar, "+", "-");

						// Buraya +- eksi butonlarını oluşturacak ve işlevlerinin itemcheck metodundaki yerine getirecek bir şey ekle
						int index = -1;
						for (int i = 0; i < checkedListMalzeme.Items.Count; i++)
						{
							// Eğer malzeme ID'si checkedListMalzeme içinde bulunuyorsa, dizinini al
							if (checkedListMalzeme.Items[i].ToString() == malzemeAdi)
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

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void gridSecilenMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == gridSecilenMalzemeler.Columns["Miktar"].Index)
			{
				DataGridViewTextBoxCell cell = gridSecilenMalzemeler.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;

				if (!gridSecilenMalzemeler.IsCurrentCellInEditMode)
				{
					gridSecilenMalzemeler.BeginEdit(true);
				}
			}
			isGridLoading = false;
		}

		private void txtindirimli_Click(object sender, EventArgs e)
		{
			txtyuzde.Text = 0.ToString();
		}

		private void gridUrun_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value != null && e.ColumnIndex == gridUrun.Columns["Yüzde"].Index) // İndirimliFiyat sütununun indeksi
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
				Yardimcilar.GridFormat(gridUrun, "Yüzde", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridUrun.Columns["İndirimliFiyat"].Index) // İndirimliFiyat sütununun indeksi
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
				Yardimcilar.GridFormat(gridUrun, "İndirimliFiyat", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridUrun.Columns["İndirimTarihi"].Index) // İndirimTarihi sütununun indeksi
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
			Yardimcilar.GridFormat(gridUrun, "Fiyat", e);
		}

		private void Checkİndirim_CheckedChanged(object sender, EventArgs e)
		{
			if (gosterildi == false)
			{
				if (Checkİndirim.Checked == true)
				{
					panelİndirim.Visible = true;
					panelİndirim.Visible = true;
				}
				else
				{
					panelİndirim.Visible = false;
				}
			}
			gosterildi = false;
		}

		private void txtfiyat_Leave_1(object sender, EventArgs e)
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

		private void txtindirimli_Leave_1(object sender, EventArgs e)
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

		#endregion

		#region Butonlar
		private void button3_Click(object sender, EventArgs e)
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

		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupUrun))
			{
				if (uzanti.Text != "")
				{
					if (!Yardimcilar.GecerliTarihMi(txtindirimTarihi.Text))
					{
						if (checkedListMalzeme.CheckedItems.Count != 0)
						{

							if (hiddenUrunId.Text == "")//Kayıt Ekleme İşlemi
							{
								var eslesen = db.Urunler.FirstOrDefault(o => o.Ad == txtad.Text && o.Gorunurluk == true);
								if(eslesen == null)
								{
									urn.Ad = txtad.Text;
									urn.Aciklama = txtaciklama.Text;
									if (txtdetay.Text.EndsWith(","))
									{
										urn.Detay = txtdetay.Text.Remove(txtdetay.Text.Length - 1);
									}
									else
									{
										urn.Detay = txtdetay.Text;
									}

									urn.Fiyat = formatsizFiyat;
									urn.Fotograf = uzanti.Text;
									if (CheckAktiflik.Checked)
									{
										urn.Akitf = true;
									}
									else
									{
										urn.Akitf = false;
									}
									//İlk Kayıt edilirken inidirim yok Şimdilik
									if (txtindirimTarihi.Text == "  .  .")
									{
										urn.IndirimTarihi = DateTime.MinValue;
									}
									else
									{
										urn.IndirimTarihi = DateTime.Parse(txtindirimTarihi.Text);
									}
									urn.IndirimliFiyat = indirimliFiyat;
									if (txtyuzde.Text == "")
									{
										txtyuzde.Text = 0.ToString();
									}
									urn.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);

									urn.KategorId = (int)comboKategori.SelectedValue;
									urn.Gorunurluk = CheckGorunurluk.Checked;
									db.Urunler.Add(urn);
									timer1.Start();
									MessageBox.Show("Yeni Ürün Kayıt Edildi");
									db.SaveChanges();
									id = db.Urunler.Max(o => o.Id);
									// Her bir seçilen malzeme için işlem yap
									foreach (DataGridViewRow row in gridSecilenMalzemeler.Rows)
									{
										if (row.Cells["Miktar"].Value != null && Convert.ToInt32(row.Cells["Miktar"].Value) > 0)
										{
											// Seçilen malzemenin miktarını al
											int miktar = Convert.ToInt32(row.Cells["Miktar"].Value.ToString());

											// Seçilen malzemenin ID'sini al
											int malzemeID = Convert.ToInt32(row.Cells["MalzemeID"].Value.ToString());

											// UrunMalzeme nesnesi oluştur
											UrunMalzeme umalzeme = new UrunMalzeme();
											umalzeme.Miktar = miktar;
											umalzeme.UrunId = id; // Burada ürün ID'si olacak
											umalzeme.MalzemeId = malzemeID;
											umalzeme.Gorunurluk = true;

											db.urunMalzemeler.Add(umalzeme);
											db.SaveChanges();
										}
									}
								}
								else
								{
									timer1.Start();
									MessageBox.Show("Ürün İçin Malzeme Bilgilerini Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							else//Güncelleme İşlemi
							{
								id = Convert.ToInt32(hiddenUrunId.Text);
								var x = db.Urunler.Find(id);
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
								if (CheckAktiflik.Checked)
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
								x.Gorunurluk = CheckGorunurluk.Checked;
								x.IndirimliFiyat = Yardimcilar.TemizleVeDondur(txtindirimli, "");
								if (txtyuzde.Text == "")
								{
									x.IndirimYuzdesi =0;
								}
								else
								{
									x.KategorId = (int)comboKategori.SelectedValue;
								}
								timer1.Start();
								MessageBox.Show("Ürün Güncellendi");

								// Gridde olmayan malzeme ID'leri için HashSet oluşturun
								HashSet<int> gridMalzemeIDs = new HashSet<int>();

								// Mevcut malzemelerin güncellenmesi veya silinmesi
								foreach (DataGridViewRow row in gridSecilenMalzemeler.Rows)
								{
									int malzemeID = Convert.ToInt32(row.Cells["MalzemeID"].Value);
									int miktar = row.Cells["Miktar"].Value != null ? Convert.ToInt32(row.Cells["Miktar"].Value) : 0;

									gridMalzemeIDs.Add(malzemeID);

									var malzeme = db.urunMalzemeler.FirstOrDefault(um => um.UrunId == id && um.MalzemeId == malzemeID);

									if (malzeme != null)
									{
										if (miktar > 0)
										{
											// Mevcut malzemenin miktarını güncelle ve görünürlüğünü açık bırak
											malzeme.Miktar = miktar;
											malzeme.Gorunurluk = true;
										}
										else
										{
											// Miktarı sıfır veya null olan malzemenin görünürlüğünü kapat
											malzeme.Gorunurluk = false;
										}
									}
									else if (miktar > 0)
									{
										// Yeni malzemenin eklenmesi
										UrunMalzeme yeniMalzeme = new UrunMalzeme
										{
											UrunId = id,
											MalzemeId = malzemeID,
											Miktar = miktar,
											Gorunurluk = true
										};
										db.urunMalzemeler.Add(yeniMalzeme);
									}
								}

								// Veritabanında olan ve gridde olmayan malzemeleri kontrol edin
								var vtMalzemeleri = db.urunMalzemeler.Where(um => um.UrunId == id && !gridMalzemeIDs.Contains(um.MalzemeId));

								//Bu kısımın olmaması gerrekli gibiemin değilim
								foreach (var vtMalzeme in vtMalzemeleri)
								{
									// Gridde bulunmayan malzemelerin görünürlüğünü kapat
									vtMalzeme.Gorunurluk = false;
								}
								MalzemeSecPaneli.Visible = false;
							}
							Yardimcilar.Temizle(groupUrun);
							db.SaveChanges();
							Urunlist(gridUrun);
							CheckAktiflik.Checked = true;
							pictureBox1.Visible = false;
							Checkİndirim.Checked = false;
							PanelKategori.Visible = false;
							CheckGorunurluk.Checked = true;
							MalzemeSecPaneli.Visible = false;
							hiddenMalzemeId.Text = "";
							hiddenStokId.Text = "";
							hiddenUrunId.Text = "";
							checkedListMalzeme.ClearSelected();
							gridSecilenMalzemeler.Rows.Clear();
							// checkedListMalzeme'deki tüm seçimleri temizle
							for (int i = 0; i < checkedListMalzeme.Items.Count; i++)
							{
								checkedListMalzeme.SetItemChecked(i, false);
							}

						}
						else
						{
							timer1.Start();
							MessageBox.Show("Ürün İçin Malzeme Bilgilerini Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Geçerli Bir Tarih Girdiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Ürüne Bir Fotoğraf Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Ürüne Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private void button2_Click(object sender, EventArgs e)//Sil butonu
		{
			int UrunId = Convert.ToInt32(hiddenUrunId.Text);
			int Menusayisi = db.MenuUrunler.Count(k => k.UrunId == UrunId);//Role sahip kullanıcı sayısı
			if (Menusayisi == 0)
			{
				DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (hiddenUrunId.Text != "")//Ürünün görünürlüğünün kapattım
					{
						int id = Convert.ToInt32(hiddenUrunId.Text);
						var urun = db.Urunler.Find(id);
						urun.Gorunurluk = false;
						db.SaveChanges();
						timer1.Start();
						MessageBox.Show("Kayıt Silindi");
						Yardimcilar.Temizle(groupUrun);
						// Ürüne ait malzemeleri bul
						var urunMalzemeler = db.urunMalzemeler.Where(um => um.UrunId == UrunId).ToList();

						// Her bir malzemenin görünürlüğünü kapat
						foreach (var urunMalzeme in urunMalzemeler)
						{
							urunMalzeme.Gorunurluk = false;
						}
						Urunlist(gridUrun);
					}
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show($"Silmek İstediğiniz Ürünü  {Menusayisi} Adet Menü Kullanıyor", "İşlem Gerçekleştirilemez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		private void button4_Click(object sender, EventArgs e)
		{
			if (MalzemeSecPaneli.Visible != true)
			{
				MalzemeSecPaneli.Visible = true;

				MalzemeListe();
			}
			else
			{
				MalzemeSecPaneli.Visible = false;
			}
		}

		private void button5_Click(object sender, EventArgs e)//burada kaldım
		{
			if (hiddenUrunId.Text != "")
			{
				int id = Convert.ToInt32(hiddenUrunId.Text);
				var urun = db.Urunler.Find(id);
				urun.IndirimliFiyat = 0;
				urun.IndirimTarihi = DateTime.MinValue.Date;
				if (txtyuzde.Text != "")
				{
					urun.IndirimYuzdesi = 0;
				}
				db.SaveChanges();
				MessageBox.Show("İndirim Kaldırıldı");
				txtindirimli.Text = "";
				txtyuzde.Text = "";
				txtindirimTarihi.Text = "";
				Checkİndirim.Checked = false;
				Urunlist(gridUrun);
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			İndirimUygula();
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
				// Form1'i açmak için
				kategoriESGForm = new KategoriESG(2);
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

		private void txtfiyat_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtfiyat, e);
		}

		private void txtfiyat_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtfiyat, sender, e);
		}

		private void txtindirimli_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtindirimli, sender, e);
		}

		private void txtindirimli_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtindirimli, e);
		}

		private void txtyuzde_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtyuzde, sender, e);
		}

		private void txtyuzde_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtyuzde, e);
		}

		string Ad;
		bool? Aktiflik;
		bool? Gorunurluk;
		int? KategoriId;
		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			Ad = txtAdAra.Text;
			Filtrele();
		}

		private void AktiflikAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			Aktiflik = AktiflikAra.SelectedIndex == 0;
			Filtrele();
		}

		private void GorunurlukAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			Gorunurluk = GorunurlukAra.SelectedIndex == 0;
			Filtrele();
		}

		private void KategoriAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			KategoriId = KategoriAra.SelectedValue as int?;
			Filtrele();
		}

		private void Filtrele()
		{
			// Tüm filtreleme kriterlerini burada topla
			IQueryable<Urun> query = db.Urunler.OrderByDescending(o => o.Id);

			if (!string.IsNullOrEmpty(Ad))
			{
				query = query.Where(p => p.Ad.Contains(Ad));
			}

			if (Aktiflik !=null)
			{
				query = query.Where(p => p.Akitf == Aktiflik);
			}

			if (Gorunurluk != null)
			{
				query = query.Where(p => p.Gorunurluk == Gorunurluk);
			}

			if (KategoriId != null)
			{
				query = query.Where(p => p.KategorId == KategoriId);
			}

			var Menuler = query.Select(o => new
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

			// Grid'in veri kaynağını güncelle
			gridUrun.DataSource = Menuler;
			// Bazı sütunları gizle
			gridUrun.Columns["Fotoğraf"].Visible = false;
			gridUrun.Columns["Id"].Visible = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			FiltreKaldır();
		}
		private void FiltreKaldır()
		{
			Ad = "";
			Aktiflik = null;
			KategoriId = null;
			txtAdAra.Text = "";
			KategoriAra.Text = "";
			AktiflikAra.Text = "";
			Yardimcilar.Urunlist(gridUrun);
		}

		private void txtyuzde_TextChanged(object sender, EventArgs e)
		{
			YuzdeHesabi();
		}
	}
}
