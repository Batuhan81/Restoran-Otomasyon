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
					stok.Miktar =((stok.Miktar/1000)+alinanMikFormatsız)*1000;
					decimal islemSonu = stok.Miktar;
					if (Olcu != "Adet")
					{
						girdi.Miktar = alisMiktari * 1000;
						girdi.SonStokMiktari = islemSonu ;
					}
					else
					{
						girdi.Miktar = alisMiktari;
						girdi.SonStokMiktari = islemSonu;
					}

					db.StokGirdiler.Add(girdi);
					timer1.Start();
					MessageBox.Show("Yeni Stok Girdisi Kayıt Edildi");
				}
				else
				{
					// Malzeme bazında en son eklenen stok girdisini bulmak için sorguyu yapın
					var sonStokGirdisi = db.StokGirdiler
											.Where(s => s.MalzemeId == malzemeId)
											.OrderByDescending(s => s.Id)
											.FirstOrDefault();

					if (sonStokGirdisi != null)
					{
						// Güncellenmek istenen stok girdisi ID'si
						int stokGirdisiId = Convert.ToInt32(hiddensStokGirdiId.Text);

						// Eğer güncellenmek istenen stok girdisi ID'si en son eklenen stok girdisinin ID'siyle uyuşmuyorsa, kullanıcıyı bilgilendir
						if (stokGirdisiId != sonStokGirdisi.Id)
						{
							timer1.Start();
							MessageBox.Show("Sadece En Son Eklenen Stok Girdisini Güncelleyebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return; // İşlemi sonlandır
						}

						// Güncellenmeden önce stok miktarını alın
						// Stok miktarını güncelleyin
						decimal oncekiStokMiktari = stok.Miktar;

						// Eğer güncelleme yapılmadan önceki miktar ile güncellenmek istenen miktar aynı ise, 1000 ile çarpma işlemi yapmayın
						if (alisMiktari != guncellemedenAlinan)
						{
							if (Olcu != "Adet")
							{
								// Eğer ölçü "Adet" değilse, miktarı ve son stok miktarını gram cinsine dönüştürerek güncelleyin
								stok.Miktar = alisMiktari * 1000;
							}
							else
							{
								// Ölçü "Adet" ise, miktarı doğrudan güncelleyin
								stok.Miktar = alisMiktari;
							}
						}
						else
						{

						}


						// Diğer özellikleri güncelleyin
						sonStokGirdisi.Tarih = DateTime.Now;
						sonStokGirdisi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
						sonStokGirdisi.AlısFiyati = fiyatformatsiz;
						sonStokGirdisi.Miktar = alisMiktari * 1000;

						// Stok girdisini kaydedin
						db.SaveChanges();

						// Stok miktarını güncelledikten sonra işlem sonu stok miktarını yeniden hesaplayın
						decimal islemSonuStokMiktari = stok.Miktar;
						sonStokGirdisi.SonStokMiktari = islemSonuStokMiktari;
						// Kullanıcıyı bilgilendirin
						timer1.Start();
						MessageBox.Show("Stok Girdi Bilgisi Güncellendi");

						// Grid'i güncelleyin
						oncekiStokMiktari = 0;
						islemSonuStokMiktari = 0;
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Stok Girdisi Bulunmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

				}
				db.SaveChanges();
				Yardimcilar.Temizle(groupGirdi);
				Girdilİstesi();
				hiddenTedarikciId.Text = "";
				hiddenStokId.Text = "";
				hiddensStokGirdiId.Text = "";
				// Temizleme işlemleri
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
												   TedarikciAdi = o.Tedarikci.Ad, // Tedarikçi adını al
												   MalzemeAdi = o.Malzeme.Ad, // Malzeme adını al
												   AlisFiyati = o.AlısFiyati,
												   TedarikciId = o.TedarikciId,
												   MalzemeId = o.MalzemeId,
												   İşlemSonuStok = o.SonStokMiktari,
												   GirdiTarih = o.Tarih,
												   MalzemeTur = Olcu,
												   //db.Stoklar
												   //	 .Where(s => s.MalzemeId == o.MalzemeId)
												   //	 .Select(s => s.Miktar)
												   //	 .FirstOrDefault() // Malzeme ID'sine göre stok miktarını al
											   })
											   .ToList();
			// DataGridView kontrolüne verileri bağla
			gridStokGirdi.DataSource = stokGirdiler;

			// DataGridView'deki sütunları düzenleme
			gridStokGirdi.Columns["Id"].DisplayIndex = 0; // Girdi ID sütununu en başa al
			gridStokGirdi.Columns["TedarikciId"].Visible = false;
			gridStokGirdi.Columns["MalzemeId"].Visible = false;
			gridStokGirdi.Columns["MalzemeTur"].Visible = false;

		}


		private void StokGirdiESG_Load(object sender, EventArgs e)
		{
			malzemeleriDoldur();
			Girdilİstesi();
			Yardimcilar.GridRenklendir(gridStokGirdi);
		}
		void malzemeleriDoldur()
		{
			// Profesörleri veritabanından al ve combo box'a doldur
			var malzemeler = db.Malzemeler.ToList();
			comboMalzeme.DisplayMember = "Ad"; // ComboBox'ta görünecek metin profesör adı olacak
			comboMalzeme.ValueMember = "Id"; // ComboBox'ta saklanacak değer profesör ID'si olacak

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
				string tedarikciAdi = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikciId).Ad;
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

			Olcu = db.Malzemeler.FirstOrDefault(o => o.Id == selectedMalzemeId).Tur;

		}
		decimal guncellemedenAlinan;
		//decimal formatsizİslemSonu;
		private void gridStokGirdi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = gridStokGirdi.Rows[e.RowIndex];
				hiddensStokGirdiId.Text = row.Cells["Id"].Value.ToString();
				txtTedarikci.Text = row.Cells["TedarikciAdi"].Value.ToString();
				comboMalzeme.Text = row.Cells["MalzemeAdi"].Value.ToString();
				txtAlisF.Text = row.Cells["AlisFiyati"].Value.ToString();
				hiddenTedarikciId.Text = row.Cells["TedarikciId"].Value.ToString();
				hiddenMalzemeId.Text = row.Cells["MalzemeId"].Value.ToString();
				malzemeId = Convert.ToInt32(hiddenMalzemeId.Text);

				Olcu = row.Cells["MalzemeTur"].Value.ToString();
				//string islemsonu = gridStokGirdi.CurrentRow.Cells["İşlemSonuStok"].Value.ToString();
				//formatsizİslemSonu = Convert.ToDecimal(islemsonu);

				string girdi = row.Cells["GirdiMiktar"].Value.ToString();
				alinanMikFormatsız = Convert.ToDecimal(girdi) / 1000;
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
			alinanMikFormatsız = Yardimcilar.TemizleVeDondur(txtalinanMik, Olcu);
			txtalinanMik.Text = Yardimcilar.BirimFormatı(alinanMikFormatsız, Olcu);
		}
		decimal fiyatformatsiz;
		private void txtAlisF_Leave(object sender, EventArgs e)
		{
			fiyatformatsiz = Yardimcilar.TemizleVeDondur(txtAlisF, "");
			txtAlisF.Text = Yardimcilar.FormatliDeger(txtAlisF.Text);
		}

		private void gridStokGirdi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Yardimcilar.GridFormat(gridStokGirdi, "AlisFiyati", e);
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "GirdiMiktar", e);
			Yardimcilar.gridFormatStokMiktari(gridStokGirdi, "İşlemSonuStok", e);
		}
	}
}
