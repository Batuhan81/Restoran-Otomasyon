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
	public partial class UrunList : Form
	{
		public UrunList()
		{
			InitializeComponent();
		}
		Context db = new Context();
		private void UrunList_Load(object sender, EventArgs e)
		{
			using (var db = new Context())
			{
				var Urunler = db.Urunler.Where(o => o.Gorunurluk == true).OrderByDescending(o => o.Id).Select(o => new
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
					Kategori = db.Kategoriler.FirstOrDefault(x => x.Id == o.KategorId).Ad,
				}).ToList();

				gridUrun.DataSource = Urunler;
				gridUrun.Columns["Fotoğraf"].Visible = false;
				gridUrun.Columns["Id"].Visible = true;
			}
		}
	}
}
