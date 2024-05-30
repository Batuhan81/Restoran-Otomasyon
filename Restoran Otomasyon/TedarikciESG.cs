using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
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
					var eslesenmail = db.Tedarikciler.FirstOrDefault(o => o.Eposta == txteposta.Text);
					var eslesentel = db.Tedarikciler.FirstOrDefault(o => o.Telefon == txttelefon.Text);
					var eslesenFirma = db.Tedarikciler.FirstOrDefault(o => o.Firma == txtfirma.Text);
					if (hiddenTedarikciId.Text == "")
					{
						if (eslesenFirma == null)
						{
							if (eslesentel == null)
							{
								if (eslesenmail == null)
								{
									int uzunluk = txttelefon.Text.Length;
									if (uzunluk == 14)
									{
										tedarikci.AdSoyad = txtad.Text;
										tedarikci.Firma = txtfirma.Text;
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
										timer1.Start();
										MessageBox.Show("Telefon Numarasını Kontrol Edinizé", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
								}
								else
								{
									timer1.Start();
									MessageBox.Show("Tedarikçi Maili Daha Önceden Kullanılıyor", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							else
							{
								timer1.Start();
								MessageBox.Show("Tedarikçi Telefon Numarası Daha Önceden Kullanılıyor", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
						else
						{
							timer1.Start();
							MessageBox.Show("Firma Adı Daha Önce Kullanulmış", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else
					{
						int id = Convert.ToInt32(hiddenTedarikciId.Text);
						var x = db.Tedarikciler.Find(id);
						x.AdSoyad = txtad.Text;
						x.Firma = txtfirma.Text;
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
					// Rol ekledikten sonra ComboRol'ü güncelle
					MalzemeESG calisanForm = Application.OpenForms.OfType<MalzemeESG>().FirstOrDefault();
					if (calisanForm != null)
					{
						calisanForm.TedarikciDoldur();
					}
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
				Ad = o.AdSoyad,
				Firma = o.Firma,
				Eposta = o.Eposta,
				Telefon = o.Telefon,
				Adres = o.AdresBİlgisi,
			}).ToList();
			gridTedarikci.DataSource = Tedarikciler;
		}

		//Adresi Adres tablosu yerine doğrudan içerisinde tuttuğumuz için buna gerek kalmadı Visible ı kapalı
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

		private void TedarikciESG_Load(object sender, EventArgs e)
		{
			TedarikciList();
			//gridTedarikci.Columns["AdresID"].Visible = false;
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridTedarikci);
			gridTedarikci.Columns["Id"].Visible = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int tedId = Convert.ToInt32(hiddenTedarikciId.Text);
			int kisiSayisi = db.StokGirdiler.Count(k => k.TedarikciId == tedId);
			if (kisiSayisi == 0)
			{
				DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (hiddenTedarikciId.Text != null)
					{
						int id = Convert.ToInt32(hiddenTedarikciId.Text);
						var x = db.Tedarikciler.Find(id);
						x.Gorunurluk = false;
						db.SaveChanges();
						timer1.Start();
						MessageBox.Show("Kayıt Silindi");
						TedarikciList();
						Yardimcilar.Temizle(groupTedarikci);
						hiddenTedarikciId.Text = "";
					}
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show($"Silmek İstediğiniz Tedarikçiden Almış Olduğunuz {kisiSayisi} Adet Malzeme Var Önce Bunların Tedarikçilerini Değiştirmelisiniz ", "İşlem Gerçekleştirilemez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private void gridTedarikci_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridTedarikci.CurrentRow;

				hiddenTedarikciId.Text = row.Cells["Id"].Value.ToString();
				txtad.Text = row.Cells["Ad"].Value.ToString();
				txtfirma.Text = row.Cells["Firma"].Value.ToString();
				txteposta.Text = row.Cells["Eposta"].Value.ToString();
				txttelefon.Text = row.Cells["Telefon"].Value.ToString();
				txtAdres.Text = row.Cells["Adres"].Value.ToString();
				int perId = Convert.ToInt32(hiddenTedarikciId.Text);

				//Adres bilgisi doğrudan form içerisinde kayıt edildiği için buna gerek kalmadı
				/*Adres Id'sini al
				int adresID = Convert.ToInt32(row.Cells["AdresID"].Value);
				Veritabanından seçilen adresin açık adresini al
				var selectedAddress = db.Adresler.FirstOrDefault(a => a.Id == adresID);
				if (selectedAddress != null)
				{
					// Seçilen adresin açık adresini txtadres öğesine atayın
					txtAdres.Text = selectedAddress.AcikAdres;
				}
				hiddenAdresID.Text = adresID.ToString();
				*/
			}
		}
		List<Tedarikci> query = new List<Tedarikci>();
		string ad;
		string mail;
		string telefon;
		void Filtrele()
		{
			query = db.Tedarikciler.ToList();
			if (ad != null)
			{
				query=query.Where(o=>o.Firma.Contains(ad)).ToList();
			}
			if (mail != null)
			{
				query = query.Where(o => o.Eposta.Contains(mail)).ToList();
			}
			if (telefon != null)
			{
				// Kullanıcının girdiği telefon numarasından sadece rakamları al
				string temizTelefon = new string(telefon.Where(char.IsDigit).ToArray());

				// Veritabanındaki telefon numaralarından sadece rakamları alarak karşılaştır
				query = query.Where(o => new string(o.Telefon.Where(char.IsDigit).ToArray()).Contains(temizTelefon)).ToList();
			}
			var Tedarikciler = query.Where(o=>o.Gorunurluk==true).Select(o => new
			{
				Id = o.Id,
				Ad = o.AdSoyad,
				Firma = o.Firma,
				Eposta = o.Eposta,
				Telefon = o.Telefon,
				Adres = o.AdresBİlgisi,
			}).ToList();
			gridTedarikci.DataSource = Tedarikciler;
		}

		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			ad = txtAdAra.Text;
			Filtrele();
		}

		private void txtmailAra_TextChanged(object sender, EventArgs e)
		{
			mail = txtmailAra.Text;
			Filtrele();
		}

		private void txtTelAra_TextChanged(object sender, EventArgs e)
		{
			telefon = txtTelAra.Text;
			Filtrele();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			ad = null;
			mail = null;
			telefon=null;
			Filtrele();
			txtAdAra.Text = "";
			txtmailAra.Text = "";
			txtTelAra.Text = "";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Yardimcilar.GeriCik(timer1);
		}
	}
}
