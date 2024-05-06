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
	public partial class MusteriListesi : Form
	{
		public MusteriListesi(int Deger)
		{
			InitializeComponent();
			deger = Deger;
		}
		int deger;
		private void MusteriListesi_Load(object sender, EventArgs e)
		{
			Musteriler();
		}
		Context db = new Context();
		void Musteriler()
		{

			if (deger == 1)//Kayıtlı müşterileri listelemek için 1 kayıtsızlar için 2 bu sayede gereksiz form oluşturmadım
			{
				var Musteriler = db.Musteriler
					.Where(x => x.Gorunurluk == true)
					.OrderByDescending(o => o.Id)
					.Select(x => new
					{
						Id = x.Id,
						Ad = x.Ad,
						Soyad = x.Soyad,
						Mail = x.Eposta,
						Telefon = x.Telefon,
						Doğum_Tarihi = x.Dogumtarihi,
						Kayıt_Tarihi = x.KayitTarihi,
					})
					.ToList();
				gridMusteriler.DataSource = Musteriler;
				gridMusteriler.Columns["Id"].Visible = false;
			}
			else
			{
				var Kayitsizlar = db.KayitsizMusteriler
					   .Where(x => x.Gorunurluk == true)
					   .OrderByDescending(o => o.Id)
					   .Select(x =>new
					   {
						   Id = x.Id,
						   Ad = x.Ad,
						   Telefon = x.Telefon,
						   Kayıt_Tarihi = x.KayitTarihi,
					   })
					   .ToList();
				gridMusteriler.DataSource = Kayitsizlar;
				gridMusteriler.Columns["Id"].Visible = false;
			}
		}


	}
}
