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
			FiltreKaldır();
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
					   .Select(x => new
					   {
						   Id = x.Id,
						   Ad = x.Ad,
						   Telefon = x.Telefon,
						   Kayıt_Tarihi = x.KayitTarihi,
					   })
					   .ToList();
				gridMusteriler.DataSource = Kayitsizlar;
				gridMusteriler.Columns["Id"].Visible = false;
				txtSoyadAra.ReadOnly=true;
				txtmailAra.ReadOnly=true;
			}
		}

		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			Ad = txtAdAra.Text;
			FiltrelerveGetir();
		}
		void FiltrelerveGetir()
		{
			
			telefon = new string(telefon.Where(char.IsDigit).ToArray());
			if (deger == 1)//Kayıtlı müşterilerin Filtreleme işlemi
			{
				
				var Musteriler = db.Musteriler
						.Where(p => p.Gorunurluk == true && p.Ad.Contains(Ad) && p.Soyad.Contains(soyad) && p.Eposta.Contains(mail) && p.Telefon.Contains(telefon))
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
				var KayitsizMusteri = db.KayitsizMusteriler
						.Where(p => p.Gorunurluk == true && p.Ad.Contains(Ad) && p.Telefon.Contains(telefon))
						.OrderByDescending(o => o.Id)
						.Select(x => new
						{
							Id = x.Id,
							Ad = x.Ad,
							Telefon = x.Telefon,
							Kayıt_Tarihi = x.KayitTarihi,
						})
						.ToList();
				gridMusteriler.DataSource = KayitsizMusteri;
				gridMusteriler.Columns["Id"].Visible = false;
			}
		}

		private void txtSoyadAra_TextChanged(object sender, EventArgs e)
		{
			soyad=txtSoyadAra.Text;
			FiltrelerveGetir();
		}

		private void txtmailAra_TextChanged(object sender, EventArgs e)
		{
			mail = txtmailAra.Text;
			FiltrelerveGetir();
		}

		private void txtTelAra_TextChanged(object sender, EventArgs e)
		{
			telefon = txtTelAra.Text;
			FiltrelerveGetir();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			FiltreKaldır();
		}
		string Ad;
		string soyad ;
		string mail;
		string telefon;
		private void FiltreKaldır()
		{
			Ad = "";
			soyad = "";
			mail = "";
			telefon = "";
			txtAdAra.Text = "";
			txtSoyadAra.Text = "";
			txtmailAra.Text = "";
			txtTelAra.Text = "";
		}
	}
}
