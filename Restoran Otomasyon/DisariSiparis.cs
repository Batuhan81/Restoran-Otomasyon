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
using static Restoran_Otomasyon.UrunleriGoster;

namespace Restoran_Otomasyon
{
	public partial class DisariSiparis : Form
	{
		public DisariSiparis()
		{
			InitializeComponent();
		}
		Context db=new Context();
		bool loaddayuklendi = false;
		private UrunGosterici urunGosterici;
		private void DisariSiparis_Load(object sender, EventArgs e)
		{
			// UrunGosterici sınıfından bir örnek oluşturun
			urunGosterici = new UrunGosterici(UrunPaneli, gridSiparisler, txttutar, db);
			BosMasa. StokKontrol();
			BosMasa.UrunKategori(ComboUrun, db);
			BosMasa.menuKategoriler(ComboMenu, db);
			urunGosterici.UrunleriGoster(0);
			urunGosterici.MenuleriGoster(0);

			loaddayuklendi = true;
			gridSiparisler.Columns.Add("UrunAdi", "Ürün Adı");
			gridSiparisler.Columns.Add("Adet", "Adet");
			gridSiparisler.Columns.Add("Fiyat", "Fiyat");
			gridSiparisler.Columns.Add("UrunID", "UrunID");
			gridSiparisler.Columns.Add("MenuID", "MenuID");

			// Gizli sütunları bulup gizli hale getirme
			foreach (DataGridViewColumn column in gridSiparisler.Columns)
			{
				if (column.HeaderText == "UrunID" || column.HeaderText == "MenuID")
				{
					column.Visible = false;
				}
			}
			// Formun constructor veya Load metodu içinde ContextMenuStrip'i oluştur
			ContextMenuStrip siparisSilMenu = new ContextMenuStrip();
			ToolStripMenuItem siparisSilMenuItem = new ToolStripMenuItem();
			siparisSilMenuItem.Name = "siparisSilMenuItem";
			siparisSilMenuItem.Size = new Size(180, 22);
			siparisSilMenuItem.Text = "Siparişi Sil";
			siparisSilMenuItem.Click += SiparisSilMenuItem_Click; // Siparişi silme işlevini tanımlayan bir event handler ekleyin
			siparisSilMenu.Items.AddRange(new ToolStripItem[] { siparisSilMenuItem });

			// DataGridView'e ContextMenuStrip'i ata
			gridSiparisler.ContextMenuStrip = siparisSilMenu;
		}
		private void SiparisSilMenuItem_Click(object sender, EventArgs e)
		{
			if (gridSiparisler.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in gridSiparisler.SelectedRows)
				{
					// Seçili satırın ürün ID'sini al
					int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);

					// UrunPaneli içindeki tüm GroupBox'ları döngüye al
					foreach (Control control in UrunPaneli.Controls)
					{
						if (control is GroupBox groupBox)
						{
							// GroupBox içindeki TextBox'ları bul
							foreach (Control innerControl in groupBox.Controls)
							{
								if (innerControl is TextBox textBox)
								{
									// Ürün ID'si seçilen ürün ID'sine eşitse, miktarı sıfırla
									if (textBox.Tag != null && Convert.ToInt32(textBox.Tag) == urunID)
									{
										textBox.Text = "0";
										break;
									}
								}
							}
						}
					}

					// İlgili satırı sil
					gridSiparisler.Rows.Remove(row);
				}
			}
			else
			{
				MessageBox.Show("Lütfen silmek için bir satır seçin.");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Siparis siparis = new Siparis();
			Durum Durum = new Durum();
			TeslimatSiparis TeslimatSiparis=new TeslimatSiparis();
			Teslimat teslimat=new Teslimat();

			siparis.Tarih = DateTime.Now;
			siparis.OdemeDurum = false;
			siparis.Not = null;
			siparis.YorumId = null;
			siparis.Gorunurluk = true;
			siparis.Tutar = Yardimcilar.TemizleVeDondur(txttutar, "");
			//Bunlar başka yerde dolmalı
			//teslimat.Cıkıs=DateTime.Now; 
			//teslimat.Varis=
			//teslimat.PersonelId=
			teslimat.OdemeDurum = false;
			teslimat.Gorunurluk=true;
			TeslimatSiparis.OluşturmaTarihi=DateTime.Now;
			TeslimatSiparis.SiparisId = siparis.Id;
			TeslimatSiparis.Gorunurluk = true;
			/*TeslimatSiparis.DurumId = 1;*///Sipariş Alındı
			TeslimatSiparis.OluşturmaTarihi = DateTime.Now;
			//TeslimatSiparis.MusteriId=
			db.Siparisler.Add(siparis);
			db.Teslimatlar.Add(teslimat);	
		}
	}
}
