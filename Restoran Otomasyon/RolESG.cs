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
	public partial class RolESG : Form
	{
		public RolESG()
		{
			InitializeComponent();
		}

		Rol rol = new Rol();
		Context db = new Context();
		int id;
		private void Kaydet_Click(object sender, EventArgs e)
		{
			if (txtad.Text != "")
			{
				if (hiddenRolId.Text == "")//Rol Ekle
				{
					rol.Ad = txtad.Text;
					rol.Gorunurluk = true;
					rol.KayitT=DateTime.Today;
					db.Roller.Add(rol);
					timer1.Start();
					MessageBox.Show("Yeni Rol Kayıt Edildi");
				}
				else//Rol Güncelle
				{
					id = Convert.ToInt32(hiddenRolId.Text);
					var x = db.Roller.Find(id);
					x.Ad = txtad.Text;
					timer1.Start();
					MessageBox.Show("Rol Güncellendi");
				}
				db.SaveChanges();
				Temizle();
				Listele();
			}
			else
			{
				MessageBox.Show("Role Bir Ad Verdiğinizden Emin Olun","Rol Eklenemiyor",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			SendKeys.Send("{ESC}");
		}

		private void RolESG_Load(object sender, EventArgs e)
		{
			Listele();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(grid1);
			grid1.Columns["Id"].Visible = false;
		}

		void Listele()
		{
			var roller = db.Roller
						   .Where(r => r.Gorunurluk == true)
						   .Select(rol => new
						   {
							   Id = rol.Id,
							   Ad = rol.Ad,
							   Kayıt_Tarihi=rol.KayitT
						   })
						   .ToList();
			grid1.DataSource = roller;
		}

		void Temizle()
		{
			hiddenRolId.Text = "";
			txtad.Text = "";
		}

		private void Sil_Click(object sender, EventArgs e)
		{
			int rolId = Convert.ToInt32(hiddenRolId.Text);
			int kisiSayisi = db.Personeller.Count(k => k.RolId == rolId);//Role sahip kullanıcı sayısı

			
			if (kisiSayisi == 0)//Rolü kullanan yoksa sil varsa engelle
			{
				DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					if (hiddenRolId.Text != "")
					{
						id = Convert.ToInt32(hiddenRolId.Text);
						var rol = db.Roller.Find(id);
						rol.Gorunurluk = false;
						db.SaveChanges();
						timer1.Start();
						MessageBox.Show("Kayıt Silindi");
						Temizle();
						Listele();
					}
				}
			}
			else
			{
				timer1.Start ();
				MessageBox.Show($"Silmek İstediğiniz Role Sahip {kisiSayisi}  Kişi Var","İşlem Gerçekleştirilemez",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			
		}

		private void grid1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			hiddenRolId.Text = grid1.CurrentRow.Cells["Id"].Value.ToString();
			txtad.Text = grid1.CurrentRow.Cells["Ad"].Value.ToString();
		}
	}
}
