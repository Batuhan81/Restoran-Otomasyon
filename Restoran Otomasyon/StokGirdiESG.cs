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
					girdi.Tarih = DateTime.Now;
					girdi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
					girdi.AlısFiyati = fiyatformatsiz;
					girdi.MalzemeId = malzemeId;
					var stokKaydi = db.Stoklar.FirstOrDefault(s => s.Malzeme.Id == malzemeId);
					int selectedMalzemeId = (int)comboMalzeme.SelectedValue;
					Olcu = db.Malzemeler.FirstOrDefault(o => o.Id == selectedMalzemeId).Tur;

					if (Olcu != "Adet")
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
				else// Eğer varolan bir stok girdisi güncelleniyorsa
				{
					// Malzeme bazında en son eklenen stok girdisini bul
					var sonStokGirdisi = db.StokGirdiler
											.Where(s => s.MalzemeId == malzemeId)
											.OrderByDescending(s => s.Id)
											.FirstOrDefault();

					if (sonStokGirdisi != null)
					{
						// Güncellenmek istenen stok girdisi ID'si
						int stokGirdisiId = Convert.ToInt32(hiddensStokGirdiId.Text);

						// Eğer güncellenmek istenen stok girdisi en son eklenenle aynı değilse uyarı ver
						if (stokGirdisiId != sonStokGirdisi.Id)
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

						// Güncellenecek stok girdisinin malzeme ID'sini al
						int malzemeId = sonStokGirdisi.MalzemeId;

						// Malzeme bilgisine göre ilgili stok kaydını bul
						var ilgiliStok = db.Stoklar.FirstOrDefault(s => s.MalzemeId == malzemeId);

						// Stok miktarını al
						decimal oncekiStokMiktari = ilgiliStok.Miktar;

						// Eğer güncelleme yapılmadan önceki miktar ile güncellenmek istenen miktar aynı değilse
						if (alisMiktari != guncellemedenAlinan)
						{
							if (Olcu != "Adet") // Ölçü birimi "Adet" değilse miktarı gram cinsine çevirerek güncelle
							{
								ilgiliStok.Miktar = alisMiktari * 1000;
								sonStokGirdisi.Miktar += alisMiktari * 1000;
							}
							else
							{
								ilgiliStok.Miktar = alisMiktari;
								sonStokGirdisi.Miktar += alisMiktari;
							}
							db.SaveChanges(); // Değişiklikleri veritabanına kaydet

							// Stok girdisi ve diğer özellikleri güncelle
							sonStokGirdisi.Tarih = DateTime.Now;
							sonStokGirdisi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
							sonStokGirdisi.AlısFiyati = fiyatformatsiz;
							sonStokGirdisi.SonStokMiktari = ilgiliStok.Miktar;
							db.SaveChanges(); // Değişiklikleri veritabanına kaydet

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
		}

		private void StokGirdiESG_Load(object sender, EventArgs e)
		{
			malzemeleriDoldur();
			Girdilİstesi();
			Yardimcilar.GridRenklendir(gridStokGirdi);

		}

		void malzemeleriDoldur()
		{
			// Görünürlüğü true olan malzemeleri veritabanından al ve combo box'a doldur
			var malzemeler = db.Malzemeler.Where(m => m.Gorunurluk).ToList();
			comboMalzeme.DisplayMember = "Ad"; // ComboBox'ta görünecek metin malzeme adı olacak
			comboMalzeme.ValueMember = "Id"; // ComboBox'ta saklanacak değer malzeme ID'si olacak
			comboMalzeme.DataSource = malzemeler;
		}

		string Olcu;
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
		decimal guncellemedenAlinan;
		//decimal formatsizİslemSonu;
		private void gridStokGirdi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridStokGirdi.Rows[e.RowIndex];
				hiddensStokGirdiId.Text = row.Cells["Id"].Value.ToString();
				txtfirma.Text = row.Cells["TedarikciAdi"].Value.ToString();
				comboMalzeme.Text = row.Cells["MalzemeAdi"].Value.ToString();
				txtAlisF.Text = row.Cells["AlisFiyati"].Value.ToString();
				int tedarikciId = Convert.ToInt32(row.Cells["TedarikciId"].Value.ToString());
				hiddenMalzemeId.Text = row.Cells["MalzemeId"].Value.ToString();
				malzemeId = Convert.ToInt32(hiddenMalzemeId.Text);

				hiddenTedarikciId.Text = tedarikciId.ToString();
				txtfirma.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).Firma;
				txtTedarikci.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).AdSoyad;
				Olcu = row.Cells["MalzemeTur"].Value.ToString();
				//string islemsonu = gridStokGirdi.CurrentRow.Cells["İşlemSonuStok"].Value.ToString();
				//formatsizİslemSonu = Convert.ToDecimal(islemsonu);
				string girdi = row.Cells["GirdiMiktar"].Value.ToString();
				if (Olcu != "Adet")
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
		decimal alinanMikFormatsız;
		private void txtalinanMik_Leave(object sender, EventArgs e)
		{
			if (txtalinanMik.Text != "")
			{
				alinanMikFormatsız = Yardimcilar.TemizleVeDondur(txtalinanMik, Olcu);
				txtalinanMik.Text = Yardimcilar.BirimFormatı(alinanMikFormatsız, Olcu);
			}
		}
		decimal fiyatformatsiz;
		private void txtAlisF_Leave(object sender, EventArgs e)
		{
			if (txtalinanMik.Text != "")
			{
				fiyatformatsiz = Yardimcilar.TemizleVeDondur(txtAlisF, "");
				txtAlisF.Text = Yardimcilar.FormatliDeger(txtAlisF.Text);
			}
		}

		private void gridStokGirdi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.GridFormat(gridStokGirdi, "AlisFiyati", e);
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "GirdiMiktar");
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "İşlemSonuStok");
		}
	}
}
