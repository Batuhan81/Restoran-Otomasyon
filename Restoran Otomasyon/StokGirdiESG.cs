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
		int alisMiktari;
		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupGirdi))
			{
				malzemeId = (int)comboMalzeme.SelectedValue;
				stokID = Convert.ToInt32(hiddenStokId.Text);
				alisMiktari= Convert.ToInt32(txtalinanMik.Text);
				var stok = db.Stoklar.Find(stokID);
				if (hiddensStokGirdiId.Text == "")
				{
					girdi.Miktar = alisMiktari;
					girdi.Tarih = DateTime.Now;
					girdi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
					girdi.AlısFiyati = decimal.Parse(txtAlisF.Text);
					girdi.MalzemeId = malzemeId;
					
					stok.Miktar += Convert.ToInt32(txtalinanMik.Text);
					db.StokGirdiler.Add(girdi);
					girdi.SonStokMiktari = stok.Miktar;
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
						stok.Miktar -= guncellemedenAlinan;
						// Kontrol etmek istediğiniz stok girdisi ID'si
						int stokGirdisiId = Convert.ToInt32(hiddensStokGirdiId.Text);

						// Eğer güncellenmek istenen stok girdisi ID'si en son eklenen stok girdisinin ID'siyle uyuşmuyorsa, kullanıcıyı bilgilendir
						if (stokGirdisiId != sonStokGirdisi.Id)
						{
							timer1.Start();
							MessageBox.Show("Sadece En Son Eklenen Stok Girdisini Güncelleyebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return; // İşlemi sonlandır
						}
						alisMiktari = Convert.ToInt32(txtalinanMik.Text);

						// En son eklenen stok girdisini güncelleyin
						sonStokGirdisi.Miktar = alisMiktari;
						sonStokGirdisi.Tarih = DateTime.Now;
						sonStokGirdisi.TedarikciId = Convert.ToInt32(hiddenTedarikciId.Text);
						sonStokGirdisi.AlısFiyati = decimal.Parse(txtAlisF.Text);
						stok.Miktar += alisMiktari;
						// Stok girdisi için güncel stok miktarını ayarla
						int girdiId= Convert.ToInt32(hiddensStokGirdiId.Text);
						var x = db.StokGirdiler.Find(girdiId);
						x.SonStokMiktari = stok.Miktar;
						timer1.Start();
						MessageBox.Show("Stok Girdi Bilgisi Güncellendi");
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
												   GirdiTarih = o.Tarih,
												   TedarikciId = o.TedarikciId,
												   MalzemeId = o.MalzemeId,
												   İşlemSonuStok =o.SonStokMiktari,
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
			
		}


		private void StokGirdiESG_Load(object sender, EventArgs e)
		{
			Girdilİstesi();
			malzemeleriDoldur();
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
		}
		int guncellemedenAlinan;
		private void gridStokGirdi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtalinanMik.Text = gridStokGirdi.CurrentRow.Cells["GirdiMiktar"].Value.ToString();
			hiddensStokGirdiId.Text = gridStokGirdi.CurrentRow.Cells["Id"].Value.ToString();
			txtTedarikci.Text = gridStokGirdi.CurrentRow.Cells["TedarikciAdi"].Value.ToString();
			comboMalzeme.Text = gridStokGirdi.CurrentRow.Cells["MalzemeAdi"].Value.ToString();
			txtAlisF.Text = gridStokGirdi.CurrentRow.Cells["AlisFiyati"].Value.ToString();
			hiddenTedarikciId.Text = gridStokGirdi.CurrentRow.Cells["TedarikciId"].Value.ToString();
			hiddenMalzemeId.Text = gridStokGirdi.CurrentRow.Cells["MalzemeId"].Value.ToString();
			guncellemedenAlinan=Convert.ToInt32(txtalinanMik.Text);
			malzemeId = Convert.ToInt32(hiddenMalzemeId.Text);
			var stokKaydi = db.Stoklar.FirstOrDefault(s => s.Malzeme.Id == malzemeId);

			if (stokKaydi != null)
			{
				// Seçilen malzemenin stok Id'sini al
				stokID = stokKaydi.Id;
				hiddenStokId.Text = stokID.ToString();
			}
		}
	}
}
