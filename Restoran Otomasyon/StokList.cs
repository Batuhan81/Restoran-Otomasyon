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
	public partial class StokList : Form
	{
		public StokList()
		{
			InitializeComponent();
		}
		Context db = new Context();
		private void StokList_Load(object sender, EventArgs e)
		{

			var malzemeStokBilgileri = from malzeme in db.Malzemeler
									   join stok in db.Stoklar on malzeme.Id equals stok.MalzemeId
									   join tedarikci in db.Tedarikciler on stok.TedarikciId equals tedarikci.Id
									   where malzeme.Gorunurluk == true //Yalnızca Görünür olan malzemeleri listeler
									   select new
									   {
										   MalzemeId = malzeme.Id,
										   MalzemeAd = malzeme.Ad,
										   MalzemeTur = malzeme.Tur,
										   StokMiktar = stok.Miktar,
										   StokMin = stok.MinStok,
										   StokMax = stok.MaxStok,
										   TedarikciId = tedarikci.Id, // Tedarikçi ID'sini gösteriyoruz
										   StokId = stok.Id,
									   };
			gridMalzemeList.DataSource = malzemeStokBilgileri.ToList();
			gridMalzemeList.Columns["MalzemeId"].Visible = false;
			gridMalzemeList.Columns["StokId"].Visible = false;
			gridMalzemeList.Columns["TedarikciId"].Visible = false;
			gridMalzemeList.Columns["MalzemeTur"].Visible = false;
		}
	}
}
