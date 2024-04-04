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

namespace Restoran_Otomasyon
{
	public partial class TedarikciESG : Form
	{
		public TedarikciESG()
		{
			InitializeComponent();
		}
		Tedarikci tedarikci = new Tedarikci();
		Context db = new Context();

		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupTedarikci))
			{
				if (Restoran_Otomasyon.Yardimcilar.MailKontrol(txteposta.Text))
				{
					if (hiddenTedarikciId.Text == "")
					{
						tedarikci.Ad = txtad.Text;
						tedarikci.Soyad = txtsoyad.Text;
						tedarikci.Telefon = txttelefon.Text;
						tedarikci.Eposta = txteposta.Text;
						tedarikci.KayitTarihi = DateTime.Now;
						tedarikci.Gorunurluk = true;
						tedarikci.AdresBİlgisi = txtAdres.Text;
						//tedarikci.AdresId = Convert.ToInt32(hiddenAdresID.Text)
						db.Tedarikciler.Add(tedarikci);
						timer1.Start();
						MessageBox.Show("Yeni Tedarikçi Kayıt Edildi");
					}
					else
					{
						int id = Convert.ToInt32(hiddenTedarikciId.Text);
						var x = db.Tedarikciler.Find(id);
						x.Ad = txtad.Text;
						x.Soyad = txtsoyad.Text;
						x.Telefon = txttelefon.Text;
						x.AdresBİlgisi = txtAdres.Text;
						//x.AdresId = Convert.ToInt32(hiddenAdresID.Text);
						x.Eposta = txteposta.Text;
						timer1.Start();
						MessageBox.Show("Tedarikçi Bilgisi Güncellendi");
					}
					db.SaveChanges();
					TedarikciList();
					Yardimcilar.Temizle(groupTedarikci);
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
		void TedarikciList()
		{
			var Tedarikciler = db.Tedarikciler.Where(r => r.Gorunurluk == true).Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
				Soyad = o.Soyad,
				Eposta = o.Eposta,
				Telefon = o.Telefon,
				Adres=o.AdresBİlgisi,
			}).ToList();
			gridTedarikci.DataSource = Tedarikciler;
		}

		private void button4_Click(object sender, EventArgs e)//Adresi Adres tablosu yerine doğrudan içerisinde tuttuğumuz için buna gerek kalmadı Visible ı kapalı
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

		private void TedarikciESG_Load(object sender, EventArgs e)
		{
			TedarikciList();
			//gridTedarikci.Columns["AdresID"].Visible = false;
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridTedarikci);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenTedarikciId.Text != null)
				{
					int id = Convert.ToInt32(hiddenTedarikciId.Text);
					var x = db.Personeller.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
					x.Gorunurluk = false;
					db.SaveChanges();
					MessageBox.Show("Kayıt Silindi");
					TedarikciList();
					Yardimcilar.Temizle(groupTedarikci);
					hiddenTedarikciId.Text = "";
				}
			}
		}

		private void gridTedarikci_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridTedarikci.CurrentRow;

				hiddenTedarikciId.Text = row.Cells["Id"].Value.ToString();
				txtad.Text = row.Cells["Ad"].Value.ToString();
				txtsoyad.Text = row.Cells["Soyad"].Value.ToString();
				txteposta.Text = row.Cells["Eposta"].Value.ToString();
				txttelefon.Text = row.Cells["Telefon"].Value.ToString();
				txtAdres.Text = row.Cells["Adres"].Value.ToString();
				// Adres Id'sini al
				//int adresID = Convert.ToInt32(row.Cells["AdresID"].Value);
				int perId = Convert.ToInt32(hiddenTedarikciId.Text);
				// Veritabanından seçilen adresin açık adresini al
				//var selectedAddress = db.Adresler.FirstOrDefault(a => a.Id == adresID);
				//if (selectedAddress != null)
				//{
				//	// Seçilen adresin açık adresini txtadres öğesine atayın
				//	txtAdres.Text = selectedAddress.AcikAdres;
				//}
				//hiddenAdresID.Text = adresID.ToString();
			}
		}
	}
}
