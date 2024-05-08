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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restoran_Otomasyon.Paneller
{
	public partial class StokGirdiESG : Form
	{
		public StokGirdiESG()
		{
			InitializeComponent();
		}

		StokGirdi girdi = new StokGirdi();
		Stok stok = new Stok();
		Context db = new Context();
		int malzemeId;
		int stokID;
		decimal alisMiktari;
		decimal islemSonu;
		decimal guncellemedenAlinan;
		//decimal formatsizİslemSonu;
		decimal alinanMikFormatsız;
		decimal fiyatformatsiz;
		string Olcu;

		#region Eventler
		private void comboMalzeme_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Seçilen malzemenin Id'sini al
			int selectedMalzemeId = (int)comboMalzeme.SelectedValue;

			// Malzemenin stok girdilerini getir ve en son eklenen kaydı al
			var sonStokGirdisi = db.Stoklar
									.Where(s => s.MalzemeId == selectedMalzemeId)
									.OrderByDescending(s => s.Id)
									.FirstOrDefault();

			if (sonStokGirdisi != null)
			{
				// Seçilen malzemenin en son stok girdisinin tedarikçi Id'sini ve adını al
				int tedarikciId = sonStokGirdisi.TedarikciId;
				string tedarikciAdi = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).AdSoyad;
				string Firma = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).Firma;
				txtfirma.Text = Firma;
				txtTedarikci.Text = tedarikciAdi;
				hiddenTedarikciId.Text = tedarikciId.ToString();

			}
			else
			{
				// Malzeme için stok girdisi bulunamadıysa kullanıcıyı bilgilendir
				MessageBox.Show("Seçilen malzeme için stok girdisi bulunamadı.");
			}
			var stokKaydi = db.Stoklar.FirstOrDefault(s => s.Malzeme.Id == selectedMalzemeId);

			if (stokKaydi != null)
			{
				// Seçilen malzemenin stok Id'sini al
				stokID = stokKaydi.Id;
				hiddenStokId.Text = stokID.ToString();
			}
			Olcu = db.Malzemeler.FirstOrDefault(o => o.Id == selectedMalzemeId).Tur;//Seçilen malzemenin IDsinden Olcu türünü al
		}

		private void gridStokGirdi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridStokGirdi.Rows[e.RowIndex];
				hiddensStokGirdiId.Text = row.Cells["Id"].Value.ToString();
				txtfirma.Text = row.Cells["TedarikciAdi"].Value.ToString();
				comboMalzeme.Text = row.Cells["MalzemeAdi"].Value.ToString();
				txtAlisF.Text = row.Cells["AlisFiyati"].Value.ToString();
				hiddenMalzemeId.Text = row.Cells["MalzemeId"].Value.ToString();
				malzemeId = Convert.ToInt32(hiddenMalzemeId.Text);

				int tedarikciId = Convert.ToInt32(row.Cells["TedarikciId"].Value.ToString());
				hiddenTedarikciId.Text = tedarikciId.ToString();

				txtfirma.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).Firma;
				txtTedarikci.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).AdSoyad;

				Olcu = row.Cells["MalzemeTur"].Value.ToString();
				//string islemsonu = gridStokGirdi.CurrentRow.Cells["İşlemSonuStok"].Value.ToString();
				//formatsizİslemSonu = Convert.ToDecimal(islemsonu);

				string girdi = row.Cells["GirdiMiktar"].Value.ToString();
				if (Olcu != "Adet")//Olçü Adet değilse Kg cinsine çevir ve öyle göster
				{
					alinanMikFormatsız = Convert.ToDecimal(girdi) / 1000;
				}
				else
				{
					alinanMikFormatsız = Convert.ToDecimal(girdi);
				}

				txtalinanMik.Text = Yardimcilar.BirimFormatı(alinanMikFormatsız, Olcu);
				guncellemedenAlinan = Convert.ToDecimal(alinanMikFormatsız);

				var stokKaydi = db.Stoklar.FirstOrDefault(s => s.Malzeme.Id == malzemeId);

				if (stokKaydi != null)
				{
					// Seçilen malzemenin stok Id'sini al
					stokID = stokKaydi.Id;
					hiddenStokId.Text = stokID.ToString();
				}
			}
		}

		//Textboxları Formatlama
		private void txtalinanMik_Leave(object sender, EventArgs e)
		{
			if (txtalinanMik.Text != "")
			{
				alinanMikFormatsız = Yardimcilar.TemizleVeDondur(txtalinanMik, Olcu);
				txtalinanMik.Text = Yardimcilar.BirimFormatı(alinanMikFormatsız, Olcu);
			}
		}
		private void txtAlisF_Leave(object sender, EventArgs e)
		{
			if (txtalinanMik.Text != "")
			{
				fiyatformatsiz = Yardimcilar.TemizleVeDondur(txtAlisF, "");
				txtAlisF.Text = Yardimcilar.FormatliDeger(txtAlisF.Text);
			}
		}

		private void gridStokGirdi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//Datagrid üzerindeli sütunları Formatlama
		{
			Yardimcilar.GridFormat(gridStokGirdi, "AlisFiyati", e);
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "GirdiMiktar");
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "İşlemSonuStok");
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupGirdi))
			{
				malzemeId = (int)comboMalzeme.SelectedValue;
				stokID = Convert.ToInt32(hiddenStokId.Text);
				alisMiktari = alinanMikFormatsız;
				var stok = db.Stoklar.Find(stokID);

				if (hiddensStokGirdiId.Text == "")
				{
					stokgirdisiEkle(stok);
				}
				else
				{
					int stokGirdisiId = Convert.ToInt32(hiddensStokGirdiId.Text);
					var stokGirdisi = db.StokGirdiler.Find(stokGirdisiId);

					if (stokGirdisi != null)
					{
						// Malzeme bazında en son eklenen stok girdisini bul
						var sonStokGirdisi = db.StokGirdiler
												.Where(s => s.MalzemeId == malzemeId)
												.OrderByDescending(s => s.Id)
												.FirstOrDefault();

						// Güncellenmek istenen stok girdisi ID'si
						int sonStokGirdisiId = sonStokGirdisi.Id;

						// Eğer güncellenmek istenen stok girdisi en son eklenenle aynı değilse uyarı ver
						if (stokGirdisiId != sonStokGirdisiId)
						{
							timer1.Start();
							MessageBox.Show("Sadece En Son Eklenen Stok Girdisini Güncelleyebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							Yardimcilar.Temizle(groupGirdi);
							hiddenMalzemeId.Text = "";
							hiddensStokGirdiId.Text = "";
							hiddenStokId.Text = "";
							hiddenTedarikciId.Text = "";
							return; // İşlemi sonlandır
						}
						// Önceki stok miktarını al
						decimal oncekiStokMiktari = stok.Miktar;

						// Eğer güncelleme yapılmadan önceki miktar ile güncellenmek istenen miktar aynı değilse
						if (alisMiktari != guncellemedenAlinan)
						{
							// Stok miktarını güncelle
							if (Olcu != "Adet")
							{
								// Ölçü birimi "Adet" değilse miktarı gram cinsine çevirerek güncelle
								stok.Miktar = (((oncekiStokMiktari / 1000) - guncellemedenAlinan) + alisMiktari) * 1000;
								stokGirdisi.Miktar = alisMiktari * 1000;
							}
							else
							{
								// Ölçü birimi "Adet" ise miktarı direkt olarak güncelle
								stok.Miktar = oncekiStokMiktari - guncellemedenAlinan + alisMiktari;
								stokGirdisi.Miktar = alisMiktari;
							}

							// Stok girdisi ve diğer özellikleri güncelle
							stokGirdisi.Tarih = DateTime.Now;
							stokGirdisi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
							stokGirdisi.AlısFiyati = fiyatformatsiz;
							stokGirdisi.SonStokMiktari = stok.Miktar;
							stokGirdisi.Neden = "Stok Girdi";

							db.SaveChanges();
							timer1.Start();
							MessageBox.Show("Stok Girdi Bilgisi Güncellendi");
						}
						else
						{
							timer1.Start();
							MessageBox.Show("Miktarda Değişiklik Yapılmadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Stok Girdisi Bulunmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

				// Yenileme ve temizleme işlemleri
				db.SaveChanges();
				Yardimcilar.Temizle(groupGirdi);
				Girdilİstesi();
				hiddenTedarikciId.Text = "";
				hiddenStokId.Text = "";
				hiddensStokGirdiId.Text = "";
				Yardimcilar.TemizleVeDondur(txtalinanMik, Olcu);
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Girdiye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void StokGirdiESG_Load(object sender, EventArgs e)
		{
			malzemeleriDoldur();
			Girdilİstesi();
			Yardimcilar.GridRenklendir(gridStokGirdi);
		}
		#endregion

		#region Metodlarım
		private void stokgirdisiEkle(Stok stok)
		{
			girdi.Tarih = DateTime.Now;
			girdi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
			girdi.AlısFiyati = fiyatformatsiz;
			girdi.MalzemeId = malzemeId;
			girdi.Neden = "Stok Girdisi";
			var stokKaydi = db.Stoklar.FirstOrDefault(s => s.Malzeme.Id == malzemeId);
			int selectedMalzemeId = (int)comboMalzeme.SelectedValue;
			Olcu = db.Malzemeler.FirstOrDefault(o => o.Id == selectedMalzemeId).Tur;

			if (Olcu != "Adet")//Olçü birimi adet değilse gr veya l için 1000 ile çarpıyoruz
			{
				stok.Miktar = ((stok.Miktar / 1000) + alinanMikFormatsız) * 1000;
				islemSonu = stok.Miktar;

				girdi.Miktar = alisMiktari * 1000;
			}
			else
			{
				stok.Miktar = ((stok.Miktar) + alinanMikFormatsız);
				islemSonu = stok.Miktar;
				girdi.Miktar = alisMiktari;
			}
			girdi.SonStokMiktari = islemSonu;
			db.StokGirdiler.Add(girdi);
			db.SaveChanges();
			timer1.Start();
			MessageBox.Show("Yeni Stok Girdisi Kayıt Edildi");
		}

		void Girdilİstesi()
		{
			// Stok girdilerini en son ID'ye göre sırala ve ilgili stok bilgilerini ekle
			var stokGirdiler = db.StokGirdiler.OrderByDescending(s => s.Id)
											   .Select(o => new
											   {
												   Id = o.Id,
												   GirdiMiktar = o.Miktar,
												   TedarikciAdi = o.Tedarikci.AdSoyad,
												   MalzemeAdi = o.Malzeme.Ad,
												   AlisFiyati = o.AlısFiyati,
												   TedarikciId = o.TedarikciId,
												   MalzemeId = o.MalzemeId,
												   İşlemSonuStok = o.SonStokMiktari,
												   Neden = o.Neden,
												   GirdiTarih = o.Tarih,
												   MalzemeTur = db.Malzemeler.Where(s => s.Id == o.MalzemeId).Select(x => x.Tur).FirstOrDefault(),
											   })
											   .ToList();
			gridStokGirdi.DataSource = stokGirdiler;

			// DataGridView'deki sütunları düzenleme ve Gizleme
			gridStokGirdi.Columns["Id"].DisplayIndex = 0; // Girdi ID sütununu en başa al
			gridStokGirdi.Columns["TedarikciId"].Visible = false;
			gridStokGirdi.Columns["MalzemeId"].Visible = false;
			gridStokGirdi.Columns["MalzemeTur"].Visible = false;
			gridStokGirdi.Columns["Id"].Visible = false;
			gridStokGirdi.Columns["Neden"].Visible = false;
		}

		void malzemeleriDoldur()
		{
			// Görünürlüğü true olan malzemeleri veritabanından al ve combo box'a doldur
			var malzemeler = db.Malzemeler.Where(m => m.Gorunurluk).ToList();
			comboMalzeme.DisplayMember = "Ad"; // ComboBox'ta görünecek metin malzeme adı olacak
			comboMalzeme.ValueMember = "Id"; // ComboBox'ta saklanacak değer malzeme ID'si olacak
			comboMalzeme.DataSource = malzemeler;
		}
		#endregion

		private void txtalinanMik_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtalinanMik, sender, e);
		}

		private void txtalinanMik_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtalinanMik, e);
		}

		private void txtAlisF_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtAlisF, sender, e);
		}

		private void txtAlisF_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtAlisF, e);
		}
	}
}
