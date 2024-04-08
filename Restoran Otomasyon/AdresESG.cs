using Restoran_Otomasyon.Data;
using Restoran_Otomasyon.Paneller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public partial class AdresESG : Form
	{
		public AdresESG()
		{
			InitializeComponent();
		}
		Adres adres = new Adres();
		Context db = new Context();

		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupAdres))
			{
				if (hiddenAdresId.Text == "")
				{
					adres.Ad = txtad.Text;
					adres.Il = txtil.Text;
					adres.Ilce = txtilce.Text;
					adres.Koy = txtkoy.Text;
					adres.Mahalle = txtmahalle.Text;
					adres.Sokak = txtsokak.Text;
					adres.No = Convert.ToInt32(txtno.Text);
					adres.Tarif = txttarif.Text;
					adres.Gorunurluk = true;
					db.Adresler.Add(adres);
					timer1.Start();
					MessageBox.Show("Yeni Adres Kayıt Edildi");
				}
				else
				{
					int id = Convert.ToInt32(hiddenAdresId.Text);
					var x = db.Adresler.Find(id);
					x.Ad = txtad.Text;
					x.Il = txtil.Text;
					x.Ilce = txtilce.Text;
					x.Koy = txtkoy.Text;
					x.Mahalle = txtmahalle.Text;
					x.Sokak = txtsokak.Text;
					x.No = Convert.ToInt32(txtno.Text);
					x.Tarif = txttarif.Text;
					timer1.Start();
					MessageBox.Show("Adres Bilgisi Güncellendi");
				}
				db.SaveChanges();
				db.SaveChanges();
				Yardimcilar.Temizle(groupAdres);
				Listele();
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Tüm Alanları Doldurduğunuzdan Emin Olunuz","Kayıt Eklenemiyor",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		void Listele()
		{
			var Adres = db.Adresler
						   .Where(r => r.Gorunurluk == true)
						   .Select(adr => new
						   {
							   Ad = adr.Ad,
							   Id = adr.Id,
							   İl = adr.Il,
							   İlçe = adr.Ilce,
							   Köy = adr.Koy,
							   Mahalle = adr.Mahalle,
							   Sokak = adr.Sokak,
							   No = adr.No,
							   Tarif = adr.Tarif,
						   }).ToList();
			gridAdres.DataSource = Adres;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void AdresESG_Load(object sender, EventArgs e)
		{
			Listele();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridAdres);
			gridAdres.Columns["Id"].Visible = false;
		}
		private void grid1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			hiddenAdresId.Text = gridAdres.CurrentRow.Cells["Id"].Value.ToString();
			int id = Convert.ToInt32(hiddenAdresId.Text);
			var x = db.Adresler.Find(id);
			txtad.Text = x.Ad;
			txtil.Text = x.Il;
			txtilce.Text = x.Ilce;
			txtkoy.Text = x.Koy;
			txtmahalle.Text = x.Mahalle;
			txtsokak.Text = x.Sokak;
			txtno.Text = x.No.ToString();
			txttarif.Text = x.Tarif;
		}

		private void SecBtn_Click(object sender, EventArgs e)
		{

			int selectedAddressId = Convert.ToInt32(hiddenAdresId.Text);
			var selectedAddress = db.Adresler.FirstOrDefault(a => a.Id == selectedAddressId);

			if (selectedAddress != null)
			{
				string acikAdres = selectedAddress.AcikAdres;
				string adresID = selectedAddressId.ToString();

				// Açık olan formları al
				var acikFormlar = Application.OpenForms.Cast<Form>().Where(f => f.Visible);

				// Sadece CalisanESG ve TedarikciESG form türlerini içeren formları filtrele
				var hedefFormlar = acikFormlar.Where(f => f.GetType() == typeof(CalisanESG) || f.GetType() == typeof(TedarikciESG));

				// Hedef formlara veri iletimi yap
				foreach (var form in hedefFormlar)
				{
					if (form is CalisanESG calisanForm)
					{
						calisanForm.txtAdres.Text = acikAdres;
						calisanForm.hiddenAdresID.Text = adresID;
					}
					else if (form is TedarikciESG tedarikciForm)
					{
						tedarikciForm.txtAdres.Text = acikAdres;
						tedarikciForm.hiddenAdresID.Text = adresID;
					}
				}

				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenAdresId.Text != null)
				{
					int id = int.Parse(hiddenAdresId.Text);
					var x = db.Adresler.Find(id);
					x.Gorunurluk = false;
					db.SaveChanges();
					timer1.Start();
					MessageBox.Show("Kayıt Silindi");
					Listele();
					Yardimcilar.Temizle(groupAdres);
					hiddenAdresId.Text = "";
				}
			}
		}
	}
}
