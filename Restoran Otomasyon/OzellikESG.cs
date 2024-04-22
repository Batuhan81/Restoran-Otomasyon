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
	public partial class OzellikESG : Form
	{
		public OzellikESG()
		{
			InitializeComponent();
		}
		Ozellik o=new Ozellik();
		Context db = new Context();
		private void Kaydet_Click(object sender, EventArgs e)
		{
			if (txtAd.Text != "")
			{
				if (hiddenId.Text == "")
				{
					o.Ad=txtAd.Text;
					o.Gorunurluk = true;
					db.Ozellikler.Add(o);
				}
				else
				{
					int id=Convert.ToInt32(hiddenId.Text);	
					var x=db.Ozellikler.Find(id);
					x.Ad=txtAd.Text;
					x.Gorunurluk=true;
				}
				db.SaveChanges();
				hiddenId.Text = "";
				txtAd.Text = "";
				Ozellikler();
			}
			MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
			if (calisanForm != null)
			{
				calisanForm.MasaOzellikler();
			}
		}
		void Ozellikler()
		{
			var ozellik = db.Ozellikler
						   .Where(r => r.Gorunurluk == true)
						   .Select(o => new
						   {
							   Id = o.Id,
							   Ad = o.Ad,
						   })
						   .ToList();
			gridOzellik.DataSource = ozellik;
			
		}

		private void gridOzellik_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			hiddenId.Text = gridOzellik.CurrentRow.Cells["Id"].Value.ToString();
			txtAd.Text = gridOzellik.CurrentRow.Cells["Ad"].Value.ToString();
		}

		private void OzellikESG_Load(object sender, EventArgs e)
		{
			Ozellikler();
			gridOzellik.Columns["Id"].Visible = false;
		}
	}
}
