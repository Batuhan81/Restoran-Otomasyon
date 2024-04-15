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
		Context db = new Context();
		Malzeme mal = new Malzeme();
		Urun urn = new Urun();
		private void button4_Click(object sender, EventArgs e)
		{
			if (MalzemePaneli.Visible != true)
			{
				MalzemePaneli.Visible = true;
				MalzemeListe();
			}
			else
			{
				MalzemePaneli.Visible = false;
			}
		}
		void MalzemeListe()
		{
			var malzemeler = db.Malzemeler
								.Where(m => m.Gorunurluk == true)
								.Select(m => m.Ad) // Sadece malzeme adını seç
								.ToList();

			checkedListMalzeme.DataSource = malzemeler;
		}

		private void checkedListMalzeme_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			gridSecilenMalzemeler.Rows.Clear(); // Önce mevcut satırları temizle

			// Eğer sütunlar daha önce eklenmediyse, sütunları ekle
			if (gridSecilenMalzemeler.Columns.Count == 0)
			{
				gridSecilenMalzemeler.Columns.Add("MalzemeAdi", "Malzeme Adı");
				gridSecilenMalzemeler.Columns.Add("MalzemeID", "Malzeme ID");
				gridSecilenMalzemeler.Columns.Add("Miktar", "Miktar");
				gridSecilenMalzemeler.Columns.Add("Arttir", "Arttir");
				gridSecilenMalzemeler.Columns.Add("Azalt", "Azalt");
			}

			foreach (var selectedItem in checkedListMalzeme.CheckedItems)
			{
				string secilenMalzemeAdi = selectedItem.ToString();
				int secilenMalzemeID = db.Malzemeler.FirstOrDefault(o => o.Ad == secilenMalzemeAdi)?.Id ?? 0;
				int miktar = 1; // Başlangıçta miktarı 1 olarak ayarla

				// Grid'e satır ekleme
				DataGridViewButtonCell btnArttir = new DataGridViewButtonCell();
				btnArttir.Value = "+";
				DataGridViewButtonCell btnAzalt = new DataGridViewButtonCell();
				btnAzalt.Value = "-";

				int rowIndex = gridSecilenMalzemeler.Rows.Add(secilenMalzemeAdi, secilenMalzemeID, miktar);
				gridSecilenMalzemeler.Rows[rowIndex].Cells["Arttir"] = btnArttir;
				gridSecilenMalzemeler.Rows[rowIndex].Cells["Azalt"] = btnAzalt;
				gridSecilenMalzemeler.Columns["MalzemeID"].Visible = false;
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
		UrunMalzeme Umalzeme = new UrunMalzeme();


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
								urn.Ad = txtad.Text;
								urn.Aciklama = txtaciklama.Text;
								urn.Detay = txtdetay.Text;
								urn.Fiyat = Decimal.Parse(txtfiyat.Text);
								urn.Fotograf = uzanti.Text;
								if (Aktiflik.Checked)
								{
									urn.Akitf = true;
								}
								else
								{
									urn.Akitf = false;
								}
								urn.IndirimTarihi = DateTime.Parse(txtindirimTarihi.Text);
								urn.IndirimliFiyat = decimal.Parse(txtindirimli.Text);
								urn.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);
								urn.KategorId = (int)comboKategori.SelectedValue;
								urn.Gorunurluk = true;
								db.Urunler.Add(urn);
							}
							else//Güncelleme İşlemi
							{
								int id = Convert.ToInt32(hiddenUrunId.Text);
								var x = db.Urunler.Find(id);
								x.Ad = txtad.Text;
								x.Aciklama = txtaciklama.Text;
								x.Detay = txtdetay.Text;
								x.Fiyat = Decimal.Parse(txtfiyat.Text);
								x.Fotograf = uzanti.Text;
								if (Aktiflik.Checked)
								{
									x.Akitf = true;
								}
								else
								{
									x.Akitf = false;
								}
								x.IndirimTarihi = DateTime.Parse(txtindirimTarihi.Text);
								x.IndirimliFiyat = decimal.Parse(txtindirimli.Text);
								x.IndirimYuzdesi = Convert.ToInt32(txtyuzde.Text);
								x.KategorId = (int)comboKategori.SelectedValue;
							}
							Yardimcilar.Temizle(groupUrun);
							db.SaveChanges();
							Urunlist();

							int maxId = db.Urunler.Max(u => u.Id);

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
									umalzeme.UrunId = maxId; // Burada ürün ID'si olacak
									umalzeme.MalzemeId = malzemeID;
									umalzeme.Gorunurluk = true;

									db.urunMalzemeler.Add(umalzeme);
									db.SaveChanges();
									MalzemePaneli.Visible = false;
								}
							}
							Aktiflik.Checked = false;
							pictureBox1.Visible = false;
						}
						else
						{
							timer1.Start();
							MessageBox.Show("Ürün İçin Malzeme Bilgilerini Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					MessageBox.Show("Ürüne Bir Fotoğraf Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Personele Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void UrunESG_Load(object sender, EventArgs e)
		{
			kategoriler();
			Urunlist();
			Yardimcilar.GridRenklendir(gridUrun);
			Yardimcilar.GridRenklendir(gridSecilenMalzemeler);
		}
		void Urunlist()
		{
			var Urunler = db.Urunler.Where(o => o.Gorunurluk == true).Select(o => new
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
				Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategorId).Ad,
			}).ToList();
			gridUrun.DataSource = Urunler;
			gridUrun.Columns["Fotoğraf"].Visible = false;
			gridUrun.Columns["Id"].Visible = false;
		}
		void kategoriler()
		{
			var kategoriler = db.Kategoriler.Where(o => o.Gorunurluk == true).Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
			}).ToList();
			comboKategori.DataSource = kategoriler;
			comboKategori.DisplayMember = "Ad"; // ComboBox'ta görünecek metin profesör adı olacak
			comboKategori.ValueMember = "Id";
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
				txtfiyat.Text = row.Cells["Fiyat"].Value.ToString();
				uzanti.Text = row.Cells["Fotoğraf"].Value.ToString();
				Aktiflik.Checked = row.Cells["Aktiflik"].Value.ToString() == "Aktif" ? true : false;
				txtindirimTarihi.Text = row.Cells["İndirimTarihi"].Value.ToString();
				txtindirimli.Text = row.Cells["İndirimliFiyat"].Value.ToString();
				txtyuzde.Text = row.Cells["Yüzde"].Value.ToString();
				comboKategori.Text = row.Cells["Kategori"].Value.ToString();

				// Ürün ID'sini sakla (Güncelleme işlemi için kullanılacak)
				int urunId = Convert.ToInt32(row.Cells["Id"].Value.ToString());
				hiddenUrunId.Text = urunId.ToString();

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
				var urunMalzemeler = db.urunMalzemeler.Where(o => o.UrunId == urunId).ToList();

				// Mevcut satırları temizle
				gridSecilenMalzemeler.Rows.Clear();

				// Her bir ilişkili malzeme için işlem yap
				foreach (var urunMalzeme in urunMalzemeler)
				{
					// Malzeme özelliği null değilse, Ad özelliğine güvenle erişebiliriz
					string malzemeAdi = db.Malzemeler.FirstOrDefault(o => o.Id == urunMalzeme.MalzemeId)?.Ad;

					// Grid'e satır ekleme
					DataGridViewButtonCell btnArttir = new DataGridViewButtonCell();
					btnArttir.Value = "+";
					DataGridViewButtonCell btnAzalt = new DataGridViewButtonCell();
					btnAzalt.Value = "-";
					if (gridSecilenMalzemeler.Columns.Count == 0)
					{
						gridSecilenMalzemeler.Columns.Add("MalzemeAdi", "Malzeme Adı");
						gridSecilenMalzemeler.Columns.Add("MalzemeID", "Malzeme ID");
						gridSecilenMalzemeler.Columns.Add("Miktar", "Miktar");
						gridSecilenMalzemeler.Columns.Add("Arttir", "Arttir");
						gridSecilenMalzemeler.Columns.Add("Azalt", "Azalt");
					}
					int rowIndex = gridSecilenMalzemeler.Rows.Add(malzemeAdi, urunMalzeme.MalzemeId, urunMalzeme.Miktar);
					gridSecilenMalzemeler.Rows[rowIndex].Cells["Arttir"] = btnArttir;
					gridSecilenMalzemeler.Rows[rowIndex].Cells["Azalt"] = btnAzalt;
					gridSecilenMalzemeler.Columns["MalzemeID"].Visible = false;
					// Eğer malzeme, checkedListMalzeme içinde ise işaretle
					int index = checkedListMalzeme.FindStringExact(malzemeAdi);
					if (index != -1)
					{
						checkedListMalzeme.SetItemChecked(index, true);
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
			if (e.RowIndex >= 0 && e.ColumnIndex != gridSecilenMalzemeler.Columns["Miktar"].Index)
			{
				DataGridViewTextBoxCell cell = gridSecilenMalzemeler.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;

				if (!gridSecilenMalzemeler.IsCurrentCellInEditMode)
				{
					gridSecilenMalzemeler.BeginEdit(true);
				}
			}
		}

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
	}
}
