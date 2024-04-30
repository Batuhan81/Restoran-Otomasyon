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
	public partial class Admin_Paneli : Form
	{
		public Admin_Paneli()
		{
			InitializeComponent();
		}

		private void CalisanCRUD_Click(object sender, EventArgs e)
		{
			CalisanESG git = new CalisanESG();
			git.Show();
		}

		private void CalisanRol_Click(object sender, EventArgs e)
		{
			RolESG git = new RolESG();
			git.Show();
		}

		private void TedarikciCRUD_Click(object sender, EventArgs e)
		{
			TedarikciESG git = new TedarikciESG();
			git.Show();
		}

		private void MalzemeCRUD_Click(object sender, EventArgs e)
		{
			MalzemeESG git = new MalzemeESG();
			git.Show();
		}

		private void StokGİrdiCRUD_Click(object sender, EventArgs e)
		{
			StokGirdiESG git = new StokGirdiESG();
			git.Show();
		}

		private void UrunCRUD_Click(object sender, EventArgs e)
		{
			UrunESG git = new UrunESG();
			git.Show();
		}

		private void kategoriEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KategoriESG git = new KategoriESG();
			git.Show();
		}

		private void menüEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MenuESG git = new MenuESG();
			git.Show();
		}

		private void stokSayımToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StokSayim git = new StokSayim();
			git.Show();
		}

		private void masaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MasaESG git = new MasaESG();
			git.Show();
		}

		private void masaÖzellikToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OzellikESG git = new OzellikESG();
			git.Show();
		}

		private void stokGirdiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StokGirdiESG git = new StokGirdiESG();
			git.Show();
		}

		private void stokSayımToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			StokSayim git = new StokSayim();
			git.Show();
		}

		private void malzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MalzemeESG git = new MalzemeESG();
			git.Show();
		}

		private void menüOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MenuESG git = new MenuESG();
			git.Show();
		}

		private void stokÇıktıToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StokCiktiSayfasi git = new StokCiktiSayfasi();
			git.Show();
		}

		private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Kasa git = new Kasa();
			git.Show();
		}

		private void Admin_Paneli_Load(object sender, EventArgs e)
		{
			MasalariGrafikteGoster();
			OlusturMenu();
			
		}
		string kullaniciAdi = "Batuhan";
		int bakiye = 250;
		private void OlusturMenu()
		{
			// "Programı Kapat" butonu oluşturulması
			ToolStripMenuItem kapatItem = new ToolStripMenuItem("Programı Kapat");
			kapatItem.Click += KapatItem_Click;

			// "Giriş Ekranı" butonu oluşturulması
			ToolStripMenuItem girisEkranıItem = new ToolStripMenuItem("Giriş Ekranı");
			girisEkranıItem.Click += GirisEkranıItem_Click;

			// Kullanıcı adını ve bakiyeyi göstermek için ToolStripMenuItem'ları oluşturun
			ToolStripMenuItem bakiyeItem = new ToolStripMenuItem($"Bakiye: {bakiye:C}");
			ToolStripMenuItem kullaniciAdiItem = new ToolStripMenuItem($"Merhaba, {kullaniciAdi}");

			// MenuStrip'e öğeleri ekleme, sağdan sola doğru ekleniyor
			menuStrip1.Items.Add(kapatItem);
			menuStrip1.Items.Add(girisEkranıItem);
			menuStrip1.Items.Add(new ToolStripSeparator());
			menuStrip1.Items.Add(bakiyeItem);
			menuStrip1.Items.Add(kullaniciAdiItem);

			// MenuStrip'i formun en üstüne sabitleme
			menuStrip1.Dock = DockStyle.Top;
		}
		// "Giriş Ekranı" butonunun tıklama olayı
		private void GirisEkranıItem_Click(object sender, EventArgs e)
		{
			// Giriş ekranı formunu açma işlemi
			Giris girisEkranı = new Giris();
			girisEkranı.Show();
		}

		// "Programı Kapat" butonunun tıklama olayı
		private void KapatItem_Click(object sender, EventArgs e)
		{
			// Programın kapatılması
			Application.Exit();
		}
		Context db = new Context();
		private void MasalariGrafikteGoster()
		{
			// Masaların kullanım oranlarını hesapla
			var masaKullanimOranlari = new Dictionary<string, int>();

			foreach (var masa in db.Masalar)
			{
				using (var db = new Context())
				{
					int masaID = masa.Id;
					// Masanın toplam sipariş sayısını al
					int toplamSiparisSayisi = db.MasaSiparisler.Where(o => o.MasaId == masaID).Count();

					masaKullanimOranlari.Add(masa.Kod, toplamSiparisSayisi);
				}
			}

			// Grafik veri bağlama
			chart1.Series.Clear();
			chart1.Series.Add("Sipariş Sayısı");

			foreach (var masaKullanimOrani in masaKullanimOranlari)
			{
				chart1.Series["Sipariş Sayısı"].Points.AddXY(masaKullanimOrani.Key, masaKullanimOrani.Value);
			}

			// Grafik görünüm ayarları
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
			chart1.ChartAreas[0].AxisX.Title = "Masa Kodu";
			chart1.ChartAreas[0].AxisY.Title = "Sipariş Sayısı";
		}
		public  void grafikleriGuncelle()
		{
			MasalariGrafikteGoster();
		}
	}
}
