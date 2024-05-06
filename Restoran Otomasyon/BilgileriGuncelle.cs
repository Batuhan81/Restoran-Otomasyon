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
		Context db=new Context();
		private void BilgileriGuncelle_Load(object sender, EventArgs e)
		{
			var x=db.Kullanicilar.Find(kullaniciId);
			txtAd.Text= x.Ad;
			txtmail.Text= x.Mail;
			txtsifre.Text=x.Sifre;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Yardimcilar.HepsiDoluMu(groupBox1))
			{
				if(txtsifre.Text ==txttekrar.Text)
				{
					if (Yardimcilar.MailKontrol(txtmail.Text))
					{
						var x = db.Kullanicilar.Find(kullaniciId);
						x.Ad = txtAd.Text;
						x.Mail = txtmail.Text;
						x.Sifre = txtsifre.Text;
						db.SaveChanges();
					}
					else
					{
						MessageBox.Show("Geçerli Bir Mail Adresi Giriniz!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
				}
				else
				{
					MessageBox.Show("Şifreler Eşleşmiyor !","İşlem Başarısız",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Tüm Alanları Doldurmalısınız !", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
