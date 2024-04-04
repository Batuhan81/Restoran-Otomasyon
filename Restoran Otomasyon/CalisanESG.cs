using Org.BouncyCastle.Asn1.Cmp;
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

namespace Restoran_Otomasyon.Paneller
{
	public partial class CalisanESG : Form
	{
		public CalisanESG()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// Adres formunu aç
			using (AdresESG adresForm = new AdresESG())
			{
				// Adres formunu modal olarak aç, yani diğer formla etkileşim yapılana kadar beklet
				if (adresForm.ShowDialog() == DialogResult.OK)
				{
					// Adres formundan dönen değerler burada işlenebilir, ancak gerekli değil
				}
			}
		}


		Personel p = new Personel();
		Context db = new Context();



		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupPersonel))
			{
				if (Restoran_Otomasyon.Yardimcilar.MailKontrol(txteposta.Text))
				{
					bool cinsiyet = false;//Kadın
					if (comboCinsiyet.SelectedIndex == 0)
					{
						cinsiyet = false;
					}
					else
					{
						cinsiyet = true;
					}
					var rolId = db.Roller.Where(o => o.Ad == ComboRol.Text).Select(o => o.Id).FirstOrDefault();
					if (hiddenPersonelId.Text == "")
					{
						p.Ad = txtad.Text;
						p.Soyad = txtsoyad.Text;
						p.Eposta = txteposta.Text;
						p.Telefon = txttelefon.Text;
						p.Maas = Decimal.Parse(txtmaas.Text);
						p.DogumTarihi = DateTime.Parse(txtdogumT.Text);
						p.BaslamaTarihi = DateTime.Parse(txtbaslamaT.Text);
						p.Cinsiyet = cinsiyet;
						p.RolId = rolId;
						p.AdresId = Convert.ToInt32(hiddenAdresID.Text);
						p.Gorunurluk = true;
						p.fotograf = uzanti.Text;
						db.Personeller.Add(p);
						timer1.Start();
						MessageBox.Show("Yeni Personel Kayıt Edildi");
					}
					else
					{
						int perId = Convert.ToInt32(hiddenPersonelId.Text);
						var x = db.Personeller.Find(perId);
						x.Ad = txtad.Text;
						x.Soyad = txtsoyad.Text;
						x.Eposta = txteposta.Text;
						x.Telefon = txttelefon.Text;
						x.Maas = Decimal.Parse(txtmaas.Text);
						x.DogumTarihi = DateTime.Parse(txtdogumT.Text);
						x.BaslamaTarihi = DateTime.Parse(txtbaslamaT.Text);
						x.Cinsiyet = cinsiyet;
						x.RolId = rolId;
						x.fotograf = uzanti.Text;
						x.AdresId = Convert.ToInt32(hiddenAdresID.Text);
						timer1.Start();
						MessageBox.Show("Personel Bilgisi Güncellendi");
					}
					db.SaveChanges();
					PersonelList();
					Yardimcilar.Temizle(groupPersonel);
					pictureBox1.Visible = false;
					uzanti.Text = "";
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Girdiğiniz E-Posta Geçersizdir");
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Personele Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RolleriDoldur()
		{
			// Profesörleri veritabanından al ve combo box'a doldur
			var profesorler = db.Roller.ToList();
			ComboRol.DisplayMember = "Ad"; // ComboBox'ta görünecek metin profesör adı olacak
			ComboRol.ValueMember = "Id"; // ComboBox'ta saklanacak değer profesör ID'si olacak
			ComboRol.DataSource = profesorler;
		}

		void PersonelList()
		{
			var personeller = db.Personeller.Where(r => r.Gorunurluk == true).Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
				Soyad = o.Soyad,
				Eposta = o.Eposta,
				Telefon = o.Telefon,
				Maas = o.Maas,
				Doğum_Tarihi = o.DogumTarihi,
				Baslangıç_Tarihi = o.BaslamaTarihi,
				Cinsiyet = o.Cinsiyet ? "Erkek" : "Kadın",
				Rol = db.Roller.FirstOrDefault(r => r.Id == o.RolId).Ad,
				AdresAdi = db.Adresler.FirstOrDefault(r => r.Id == o.AdresId).Ad, // Adres adını al
				AdresID = o.AdresId, // Adres ID'sini al
				Foto = o.fotograf,
			}).ToList();
			gridPersonel.DataSource = personeller;
		}


		private void CalisanESG_Load(object sender, EventArgs e)
		{
			RolleriDoldur();
			PersonelList();
			gridPersonel.Columns["AdresID"].Visible = false;
			gridPersonel.Columns["Foto"].Visible = false;
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridPersonel);
		}

		private void gridPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridPersonel.CurrentRow;

				hiddenPersonelId.Text = row.Cells["Id"].Value.ToString();
				txtad.Text = row.Cells["Ad"].Value.ToString();
				txtsoyad.Text = row.Cells["Soyad"].Value.ToString();
				txteposta.Text = row.Cells["Eposta"].Value.ToString();
				txttelefon.Text = row.Cells["Telefon"].Value.ToString();
				txtmaas.Text = row.Cells["Maas"].Value.ToString();
				txtdogumT.Text = row.Cells["Doğum_Tarihi"].Value.ToString();
				txtbaslamaT.Text = row.Cells["Baslangıç_Tarihi"].Value.ToString();
				comboCinsiyet.Text = row.Cells["Cinsiyet"].Value.ToString();
				ComboRol.Text = row.Cells["Rol"].Value.ToString();

				// Adres Id'sini al
				int adresID = Convert.ToInt32(row.Cells["AdresID"].Value);
				int perId = Convert.ToInt32(hiddenPersonelId.Text);
				// Veritabanından seçilen adresin açık adresini al
				var selectedAddress = db.Adresler.FirstOrDefault(a => a.Id == adresID);
				if (selectedAddress != null)
				{
					// Seçilen adresin açık adresini txtadres öğesine atayın
					pictureBox1.Visible = true;
					txtAdres.Text = selectedAddress.AcikAdres;
				}
				hiddenAdresID.Text = adresID.ToString();
				string imagePath = row.Cells["Foto"].Value.ToString();

				// Eğer resim yolu boş değilse, resmi boyutlandır
				if (!string.IsNullOrEmpty(imagePath))
				{
					// Seçilen resmin yolunu kullanarak boyutlandır ve PictureBox'ta göster
					Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(imagePath, pictureBox1.Width, pictureBox1.Height);
					pictureBox1.Image = resizedImage;
				}
				else
				{
					// Resim yolu boşsa, PictureBox'ı temizle
					pictureBox1.Image = null;
				}
			}
		}


		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenPersonelId.Text != null)
				{
					int id = Convert.ToInt32(hiddenPersonelId.Text);
					var x = db.Personeller.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
					x.Gorunurluk = false;
					db.SaveChanges();
					MessageBox.Show("Kayıt Silindi");
					PersonelList();
					Yardimcilar.Temizle(groupPersonel);
					hiddenPersonelId.Text = "";
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
