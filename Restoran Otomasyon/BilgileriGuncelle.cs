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
	public partial class BilgileriGuncelle : Form
	{
		public BilgileriGuncelle(int kullaniID)
		{
			InitializeComponent();
			kullaniciId = kullaniID;
		}
		int kullaniciId;
		Context db = new Context();
		private void BilgileriGuncelle_Load(object sender, EventArgs e)
		{
			var x = db.Kullanicilar.Find(kullaniciId);
			txtAd.Text = x.Ad;
			txtmail.Text = x.Mail;
			mevcutSifre = x.Sifre;
		}
		void SifreTuru(string sifre)
		{
			bool buyukharf = false;
			bool kucukharf = false;
			bool rakam = false;
			foreach (char c in sifre)
			{
				if (char.IsUpper(c))
				{
					buyukharf = true;
				}
				if (char.IsLower(c))
				{
					kucukharf = true;
				}
				if (char.IsDigit(c))
				{
					rakam = true;
				}
			}
			if (buyukharf && kucukharf && rakam && sifre.Length > 8)
			{
				sifreT.Text = "Güçlü Şifre";
			}
			else if (kucukharf && rakam && sifre.Length < 8)
			{
				sifreT.Text = "Zor Şifre";
			}
			else if (rakam && sifre.Length < 5)
			{
				sifreT.Text = "Kolay Şifre";
			}
			else
			{
				sifreT.Text = "Kolay Şifre";
			}
			if (sifre.Length == 0)
			{
				sifreT.Text = "";
			}
		}
		string mevcutSifre;

		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupBox1))
			{
				if (txtmevcutsifre.Text == mevcutSifre)
				{
					if (txtyeniSifre.Text == txttekrar.Text)
					{
						if (Yardimcilar.MailKontrol(txtmail.Text))
						{
							var x = db.Kullanicilar.Find(kullaniciId);
							//x.Ad = txtAd.Text;
							x.Mail = txtmail.Text;
							x.Sifre = txtyeniSifre.Text;
							db.SaveChanges();
						}
						else
						{
							MessageBox.Show("Geçerli Bir Mail Adresi Giriniz!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Şifreler Eşleşmiyor !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Girilen Mevcut Şifre Yanlış !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Tüm Alanları Doldurmalısınız !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtyeniSifre_TextChanged(object sender, EventArgs e)
		{
			SifreTuru(txtyeniSifre.Text);
		}

		private void txtAd_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
		{

		}
	}
}
