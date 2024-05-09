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
	public partial class MenuListe : Form
	{
		public MenuListe()
		{
			InitializeComponent();
		}
		Context db=new Context();
		string Ad;
		bool? Aktiflik;
		int? KategoriId;
		private void FiltreKaldır()
		{
			Ad = "";
			Aktiflik = null;
			KategoriId = null;
			txtAdAra.Text = "";
			KategoriAra.Text = "";
			AktiflikAra.Text = "";
			MenulerinListesi();
		}
		private void Filtrele()
		{
			// Tüm filtreleme kriterlerini burada topla
			IQueryable<Data.Menu> query = db.Menuler.OrderByDescending(o => o.Id);

			if (!string.IsNullOrEmpty(Ad))
			{
				query = query.Where(p => p.Ad.Contains(Ad));
			}

			if (Aktiflik != null)
			{
				query = query.Where(p => p.Akitf == Aktiflik);
			}

			if (KategoriId != null)
			{
				query = query.Where(p => p.KategoriId == KategoriId);
			}

			var Menuler = query.Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
				Aciklama = o.Aciklama,
				Detay = o.Detay,
				Fiyat = o.Fiyat,
				Fotoğraf = o.Fotograf,
				Aktiflik = o.Akitf ? "Aktif" : "Pasif",
				İndirimliFiyat = o.IndirimliFiyat,
				İndirimTarihi = o.IndirimTarihi,
				Yüzde = o.IndirimYuzdesi,
				Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategoriId).Ad,
			}).ToList();

			// Grid'in veri kaynağını güncelle
			gridMenu.DataSource = Menuler;
			// Bazı sütunları gizle
			gridMenu.Columns["Fotoğraf"].Visible = false;
			gridMenu.Columns["Id"].Visible = false;
		}
		private void MenuListe_Load(object sender, EventArgs e)
		{
			KategoriAra.DataSource = null;
			var kategoriler = db.Kategoriler.Where(o => o.Gorunurluk == true && o.Tur == "Menü").Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
			}).ToList();
			KategoriAra.DisplayMember = "Ad";
			KategoriAra.ValueMember = "Id";
			KategoriAra.DataSource = kategoriler;
			MenulerinListesi();
			Yardimcilar.GridRenklendir(gridMenu);
			
			
			FiltreKaldır();
		}

		private void MenulerinListesi()
		{
			using (var db = new Context())
			{
				var Menuler = db.Menuler.Where(o => o.Gorunurluk == true).OrderByDescending(o => o.Id).Select(o => new
				{
					Id = o.Id,
					Ad = o.Ad,
					Aciklama = o.Aciklama,
					Detay = o.Detay,
					Fiyat = o.Fiyat,
					Fotoğraf = o.Fotograf,
					Aktiflik = o.Akitf ? "Aktif" : "Pasif",
					İndirimliFiyat = o.IndirimliFiyat,
					İndirimTarihi = o.IndirimTarihi,
					Yüzde = o.IndirimYuzdesi,
					Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategoriId).Ad,
				}).ToList();
				gridMenu.DataSource = Menuler;
				gridMenu.Columns["Fotoğraf"].Visible = false;
				gridMenu.Columns["Id"].Visible = false;
			}
		}

		private void gridMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value != null && e.ColumnIndex == gridMenu.Columns["Yüzde"].Index) // İndirimliFiyat sütununun indeksi
			{
				decimal Yuzde;
				if (decimal.TryParse(e.Value.ToString(), out Yuzde)) // İndirimli fiyat değerini decimal'e dönüştür
				{
					if (Yuzde == 0)
					{
						e.Value = "Yok"; // Eğer indirimli fiyat 0 ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
				Yardimcilar.GridFormat(gridMenu, "Yüzde", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridMenu.Columns["İndirimliFiyat"].Index) // İndirimliFiyat sütununun indeksi
			{
				decimal indirimliFiyat;
				if (decimal.TryParse(e.Value.ToString(), out indirimliFiyat)) // İndirimli fiyat değerini decimal'e dönüştür
				{
					if (indirimliFiyat == 0)
					{
						e.Value = "Yok"; // Eğer indirimli fiyat 0 ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
				Yardimcilar.GridFormat(gridMenu, "İndirimliFiyat", e);
			}
			else if (e.Value != null && e.ColumnIndex == gridMenu.Columns["İndirimTarihi"].Index) // İndirimTarihi sütununun indeksi
			{
				DateTime indirimTarihi;
				if (DateTime.TryParse(e.Value.ToString(), out indirimTarihi)) // İndirim tarihi değerini DateTime'a dönüştür
				{
					if (indirimTarihi == DateTime.MinValue)
					{
						e.Value = "Yok"; // Eğer indirim tarihi min date ise "Yok" olarak ayarla
						e.FormattingApplied = true; // Formatlama uygulandı olarak işaretle
					}
				}
			}
			Yardimcilar.GridFormat(gridMenu, "Fiyat", e);
		}

		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			Ad = txtAdAra.Text;
			Filtrele();
		}

		private void AktiflikAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			Aktiflik = AktiflikAra.SelectedIndex == 0;
			Filtrele();
		}

		private void KategoriAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			KategoriId = (int)KategoriAra.SelectedValue;
			Filtrele();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			FiltreKaldır();
		}
	}
}
