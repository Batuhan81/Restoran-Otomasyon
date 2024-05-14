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

		public CalisanESG(int kullaniID)
		{
			InitializeComponent();
			kullaniId = kullaniID;
		}
		int kullaniId;
		private void button4_Click(object sender, EventArgs e)//Buna gerek kalmadı çünkü adres bilgisini doğrudan çalışsan içerisinde kayıt edeceğiz (yapmıştım silmek istemedim erişilebilir bir buton değil)
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
		string fotouzanti;


		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupPersonel))//Tüm Alanlar Dolumu Kontrolü
			{
				fotouzanti = uzanti.Text;
				if (fotouzanti != "")//Foto seçildi mi kontrolü
				{
					//Girilen tarihler geçerli bir tarih mi?
					if (Yardimcilar.GecerliTarihMi(txtdogumT.Text) && Yardimcilar.GecerliTarihMi(txtbaslamaT.Text))
					{

						if (Restoran_Otomasyon.Yardimcilar.MailKontrol(txteposta.Text))//Mail geçrli mi kontorlü
						{
							bool cinsiyet = false;//Kadın
							if (comboCinsiyet.SelectedIndex == 0)//Comboboxtan seçilen değere göre cinsiyeti bool olarak kayıt etme
							{
								cinsiyet = false;//Kadın
							}
							else
							{
								cinsiyet = true;//Erkek
							}
							int rolId = (int)ComboRol.SelectedValue;//Comboboxtan Seçilendeğerin Idsi
							if (hiddenPersonelId.Text == "")
							{
								var EslesenMail = db.Personeller.FirstOrDefault(x => x.Eposta == txteposta.Text && x.Gorunurluk==true);
								var EslesenTel = db.Personeller.FirstOrDefault(x => x.Telefon == txttelefon.Text && x.Gorunurluk == true);
								if (EslesenMail == null)
								{
									if(EslesenTel == null)
									{
										if(maasformatsız< 2147483647)
										{
											int uzunluk = txttelefon.Text.Length;
											if (uzunluk == 14)
											{
												PersonelEkle(cinsiyet, rolId);

											}
											else
											{
												timer1.Start();
												MessageBox.Show("Telefon Numarasının Doğruluğundan Emin Olunuz!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
												return;
											}
										}
										else
										{
											timer1.Start();
											MessageBox.Show("Girilen Değer Veritabanı Hafızasını Aşıyor!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
											return;
										}
									}
									else
									{
										timer1.Start();
										MessageBox.Show("Personel Telefon Numarsası Daha Önceden Kullanılmış !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
								}
								else
								{
									timer1.Start();
									MessageBox.Show("Personel Maili Daha Önceden Kullanılmış !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							else
							{
								PersonelGuncelle(cinsiyet, rolId);
							}
							db.SaveChanges();
							PersonelList();
							Yardimcilar.Temizle(groupPersonel);
							pictureBox1.Visible = false;
							uzanti.Text = "";
							txtbaslamaT.Text = gününT;
						}//Gerekli Hata Mesajları
						else
						{
							timer1.Start();
							MessageBox.Show("Girdiğiniz E-Posta Geçersizdir");
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
					MessageBox.Show("Personele Bir Fotoğraf Seçtiğinizden Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Personele Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void PersonelGuncelle(bool cinsiyet, int rolId)//Personel Bilgilerini güncelleme
		{
			int perId = Convert.ToInt32(hiddenPersonelId.Text);
			var x = db.Personeller.Find(perId);
			x.Ad = txtad.Text;
			x.Soyad = txtsoyad.Text;
			x.Eposta = txteposta.Text;
			x.Telefon = txttelefon.Text;
			x.Maas = maasformatsız;
			x.DogumTarihi = DateTime.Parse(txtdogumT.Text);
			x.BaslamaTarihi = DateTime.Parse(txtbaslamaT.Text);
			x.Cinsiyet = cinsiyet;
			x.RolId = rolId;
			x.fotograf = fotouzanti;
			x.Adres = txtAdres.Text;
			timer1.Start();
			MessageBox.Show("Personel Bilgisi Güncellendi");
		}

		private void PersonelEkle(bool cinsiyet, int rolId)//Personel Bilgilerini Kayıt etme
		{
			p.Ad = txtad.Text;
			p.Soyad = txtsoyad.Text;
			p.Eposta = txteposta.Text;
			p.Telefon = txttelefon.Text;
			p.Maas = maasformatsız;
			p.DogumTarihi = DateTime.Parse(txtdogumT.Text);
			p.BaslamaTarihi = DateTime.Parse(txtbaslamaT.Text);
			p.Cinsiyet = cinsiyet;
			p.RolId = rolId;
			p.Adres = txtAdres.Text;
			p.Gorunurluk = true;
			p.fotograf = fotouzanti;
			db.Personeller.Add(p);
			timer1.Start();
			MessageBox.Show("Yeni Personel Kayıt Edildi");
		}

		public void RolleriDoldur()
		{
			var Roller = db.Roller.Where(r => r.Gorunurluk == true).ToList();

			// ComboRol için veri kaynağı ayarla
			ComboRol.DisplayMember = "Ad";
			ComboRol.ValueMember = "Id";
			ComboRol.DataSource = Roller;

			// txtRolAra için ayrı bir veri kaynağı oluştur
			var txtRolAraVeriKaynagi = new List<Rol>(Roller);
			txtRolAra.DisplayMember = "Ad";
			txtRolAra.ValueMember = "Id";
			txtRolAra.DataSource = txtRolAraVeriKaynagi;
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
				Adres = o.Adres,
				//AdresAdi = db.Adresler.FirstOrDefault(r => r.Id == o.AdresId).Ad, // Adres adını al
				//AdresID = o.AdresId, // Adres ID'sini al
				Foto = o.fotograf,
			}).ToList();
			gridPersonel.DataSource = personeller;
		}
		string gününT;

		
		private void CalisanESG_Load(object sender, EventArgs e)
		{
			RolleriDoldur();
			PersonelList();
			//Giren kullanıcı admin değilse Crud işlemlerini sağlayan butonları sakladım ve açılan boşluğu kapatmak adına konumlarla oynadım
			var kullanici = db.Kullanicilar.Find(kullaniId);
			if (kullanici.Ad != "Admin")
			{
				button1.Visible = false;
				button2.Visible = false;
				button3.Visible = false;
				button4.Visible = false;
				button5.Visible = false;
				label9.Location = new Point(148, 570);
				txtAdres.Location = new Point(8, 600);
				txtAdres.Size = new Size(330, 140);
				foreach (Control control in groupPersonel.Controls)
				{
					control.Location = new Point(control.Location.X, control.Location.Y + 30);
				}
			}
			//işe başlama tarihi günün tarihi olarak geliyor
			gününT = DateTime.Now.ToString("dd/MM/yyyy");
			txtbaslamaT.Text = gününT;

			//gridPersonel.Columns["AdresID"].Visible = false;

			//Id ve Fotoğraf uzantısını gizleme
			gridPersonel.Columns["Foto"].Visible = false;
			gridPersonel.Columns["Id"].Visible = false;
			//Gridi renklendirme
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
				txtdogumT.Text = row.Cells["Doğum_Tarihi"].Value.ToString();
				if (txtdogumT.Text.Length < 10)
				{
					txtdogumT.Text = "0" + txtdogumT.Text;
				}
				txtbaslamaT.Text = row.Cells["Baslangıç_Tarihi"].Value.ToString();
				if (txtbaslamaT.Text.Length < 10)
				{
					txtbaslamaT.Text = "0" + txtbaslamaT.Text;
				}
				comboCinsiyet.Text = row.Cells["Cinsiyet"].Value.ToString();
				ComboRol.Text = row.Cells["Rol"].Value.ToString();
				txtAdres.Text = row.Cells["Adres"].Value.ToString();
				int perId = Convert.ToInt32(hiddenPersonelId.Text);

				//amaç 100 olarak geleni 100.00₺ yapmak ama arka planda veri hayla 100
				string maas = row.Cells["Maas"].Value.ToString();
				maasformatsız = Decimal.Parse(maas);
				txtmaas.Text = Yardimcilar.FormatliDeger(maas);

				//Bunların Hepsi Adres Formundan Dolayı gelenler buna gerek kalmadı doğrudan adres bilgisini personel içerisinde girip içine kayıt ediyoruz

				/* Adres Id'sini al
				//int adresID = Convert.ToInt32(row.Cells["AdresID"].Value);
				// Veritabanından seçilen adresin açık adresini al
				//var selectedAddress = db.Adresler.FirstOrDefault(a => a.Id == adresID);
				//if (selectedAddress != null)
				//{
				//	// Seçilen adresin açık adresini txtadres öğesine atayın
				//	txtAdres.Text = selectedAddress.AcikAdres;
				//}
				//hiddenAdresID.Text = adresID.ToString();
				*/

				uzanti.Text = row.Cells["Foto"].Value.ToString();

				// Eğer resim yolu boş değilse,Seçilen resmin yolunu kullanarak boyutlandır ve PictureBox'ta göster
				if (!string.IsNullOrEmpty(fotouzanti))
				{
					Image resizedImage = Yardimcilar.ResimBoyutlandir.DosyaYoluIleBoyutlandir(fotouzanti, pictureBox1.Width, pictureBox1.Height);
					pictureBox1.Image = resizedImage;
					pictureBox1.Visible = true;
				}
				else// Resim yolu boşsa, PictureBox'ı temizle
				{
					pictureBox1.Image = null;
				}
			}
		}


		private void button2_Click(object sender, EventArgs e)//Kaydı Silme İşlemi
		{
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenPersonelId.Text != null)
				{
					int id = Convert.ToInt32(hiddenPersonelId.Text);
					var x = db.Personeller.Find(id);
					x.Gorunurluk = false;
					db.SaveChanges();
					timer1.Start();
					MessageBox.Show("Kayıt Silindi");
					PersonelList();
					Yardimcilar.Temizle(groupPersonel);
					hiddenPersonelId.Text = "";
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// Resim seçme işlemi için Yardimcilar.ResimBoyutlandir.DosyaSec metodunu kullandım
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

		private void gridPersonel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//Grid üzerinde maaş bilgisini 1000 yerine 1.000,00₺ yapma
		{
			Yardimcilar.GridFormat(gridPersonel, "Maas", e);
		}
		Decimal maasformatsız;

		private void uzanti_TextChanged(object sender, EventArgs e)
		{
			fotouzanti = uzanti.Text;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (RolPaneli.Visible != true)
			{
				RolPaneli.Visible = true;
				// Form1'i açmak için
				Yardimcilar.OpenForm(new RolESG(), RolPaneli);
				ComboRol.Text = "";
			}
			else
			{
				RolPaneli.Visible = false;
			}
			//RolleriDoldur();anlık olarak iletiyorum
		}

		//maskedda gerek yokmuşta ben gene yapmış bulundum
		private void txttelefon_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txttelefon, e);
		}

		private void txttelefon_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txttelefon, sender, e);
		}

		private void txtmaas_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtmaas, sender, e);
		}

		private void txtmaas_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtmaas,e);
		}

		private void txtmaas_Leave(object sender, EventArgs e)
		{
			if (txtmaas.Text != "")
			{
				maasformatsız = Convert.ToDecimal(Yardimcilar.FormatsizDeger(txtmaas.Text));
				txtmaas.Text = maasformatsız.ToString();
				txtmaas.Text = Yardimcilar.FormatliDeger(txtmaas.Text);
			}
		}

		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			FiltreleVeYukle();
		}

		private void txtmailAra_TextChanged(object sender, EventArgs e)
		{
			FiltreleVeYukle();
		}
		private void FiltreleVeYukle()
		{
			string ad = txtAdAra.Text;
			string mail = txtmailAra.Text;
			string telefon = txtTelAra.Text;
			bool cinsiyet;
			if (TxtCinsiyetAra.SelectedIndex == 0)
			{
				cinsiyet = false;
			}
			else
			{
				cinsiyet=true;
			}
			int rol =(int)txtRolAra.SelectedValue;

			// Kullanıcı tarafından girilen telefon numarasından gereksiz karakterleri ve boşlukları kaldırma
			telefon = new string(telefon.Where(char.IsDigit).ToArray());

			// LINQ sorgusu ile filtreleme yapıyoruz
			var filtrelenmisPersoneller = db.Personeller
				.Where(p => p.Ad.Contains(ad) && p.Eposta.Contains(mail) && p.Telefon.Contains(telefon) && p.Cinsiyet==cinsiyet&&p.RolId==rol) // Telefon numarasının içerisinde belirtilen rakamların geçtiği kayıtları al
				.Select(o => new
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
					Adres = o.Adres,
					Foto = o.fotograf,
				}).ToList();

			// BindingSource'un DataSource'ını filtrelenmiş personel listesi olarak ayarlıyoruz
			gridPersonel.DataSource = filtrelenmisPersoneller;
		}

		private void txtTelAra_TextChanged(object sender, EventArgs e)
		{
			FiltreleVeYukle();
		}

		private void TxtCinsiyetAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			FiltreleVeYukle();
		}

		private void txtRolAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			FiltreleVeYukle(); 
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Yardimcilar.Temizle(groupCalisanFiltre);
			PersonelList();
		}
	}
}
