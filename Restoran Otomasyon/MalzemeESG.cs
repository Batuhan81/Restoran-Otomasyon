using Org.BouncyCastle.Asn1.X509;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restoran_Otomasyon.Paneller
{
	public partial class MalzemeESG : Form
	{
		public MalzemeESG()
		{
			InitializeComponent();
		}
		Context db = new Context();
		Stok stok = new Stok();
		public void TedarikciDoldur()//Combobox üzerinde Tedarikçi firma adı yer alacak ama seçim işlemi yapıldığında değer olarak Tedarikçi Idsi olacak
		{
			comboTedarik.DataSource = null;
			var tedarikciFirma = db.Tedarikciler.Where(o => o.Gorunurluk == true).ToList();
			comboTedarik.DisplayMember = "Firma";
			comboTedarik.ValueMember = "Id";
			comboTedarik.DataSource = tedarikciFirma;
			var txtRolAraVeriKaynagi = new List<Tedarikci>(tedarikciFirma);
			ComboTedarikciAra.DisplayMember = "Firma";
			ComboTedarikciAra.ValueMember = "Id";
			ComboTedarikciAra.DataSource = txtRolAraVeriKaynagi;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Malzeme mal = new Malzeme();

			if (Yardimcilar.HepsiDoluMu(groupMalzeme))//gerekli Tüm bilgiler Dolumu diye kontrol
			{
				if (hiddenMalzemeId.Text == "")
				{
					var Eslesen = db.Malzemeler.FirstOrDefault(o => o.Ad == txtad.Text && o.Gorunurluk == true);
					if (Eslesen == null)
					{
						MalzemeEkle(mal);
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Girilen Malzeme Adına Sahip Bir Malzeme Zaten Bulunuyor", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					MalzemeGuncelle();
				}
				db.SaveChanges();
				Yardimcilar.Temizle(groupMalzeme);
				MalzemeList();
				txtstok.Text = "0";
				hiddenMalzemeId.Text = "";
				hiddenTedarikciId.Text = "";
				hiddenMalzemeId.Text = "";
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Malzemeye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			TedarikciPaneli.Visible = false;
		}

		private void MalzemeGuncelle()
		{
			int id = Convert.ToInt32(hiddenMalzemeId.Text);
			var x = db.Malzemeler.Find(id);
			x.Ad = txtad.Text;
			x.Tur = comboOlcu.Text;
			x.Fiyat = fiyatformatsiz;
			int stokId = Convert.ToInt32(hiddenStokId.Text);
			var t = db.Stoklar.Find(stokId);
			t.Gorunurluk = true;
			if (olcu != "Adet")//Ürün Türü Adet Değilse Gr ve Ml dönüşümü yap Adetse doğrudan yaz
			{
				t.MinStok = formatsizMin * 1000;
				t.MaxStok = formatsizMax * 1000;
			}
			else
			{
				t.MinStok = formatsizMin;
				t.MaxStok = formatsizMax;
			}
			t.TedarikciId = (int)comboTedarik.SelectedValue;
			timer1.Start();
			MessageBox.Show("Malzeme Bilgisi Güncellendi");
		}

		private void MalzemeEkle(Malzeme mal)
		{
			mal.Ad = txtad.Text;
			mal.Tur = olcu;
			mal.Gorunurluk = true;
			mal.Fiyat = fiyatformatsiz;
			db.Malzemeler.Add(mal);
			db.SaveChanges();
			int maxMalId = db.Malzemeler.Max(m => m.Id);
			stok.MalzemeId = maxMalId;
			stok.Gorunurluk = true;
			stok.Miktar = 0;
			if (olcu != "Adet")
			{
				stok.MinStok = formatsizMin * 1000;
				stok.MaxStok = formatsizMax * 1000;
			}
			else
			{
				stok.MinStok = formatsizMin;
				stok.MaxStok = formatsizMax;
			}

			stok.TedarikciId = (int)comboTedarik.SelectedValue;

			db.Stoklar.Add(stok);
			timer1.Start();
			MessageBox.Show("Yeni Malzeme Kayıt Edildi");
		}

		void MalzemeList()//Malzemeleri Datagrid üzerinde listeleme
		{
			var malzemeStokBilgileri = from malzeme in db.Malzemeler
									   join stok in db.Stoklar on malzeme.Id equals stok.MalzemeId
									   join tedarikci in db.Tedarikciler on stok.TedarikciId equals tedarikci.Id
									   orderby malzeme.Id //Yalnızca Görünür olan malzemeleri listeler
									   select new
									   {
										   MalzemeId = malzeme.Id,
										   MalzemeAd = malzeme.Ad,
										   MalzemeTur = malzeme.Tur,
										   MalzemeFiyat = malzeme.Fiyat,
										   StokMiktar = stok.Miktar,
										   StokMin = stok.MinStok,
										   StokMax = stok.MaxStok,
										   TedarikciFirma = tedarikci.Firma,
										   TedarikciAd = tedarikci.AdSoyad,
										   TedarikciId = tedarikci.Id, // Tedarikçi ID'sini gösteriyoruz
										   StokId = stok.Id,
									   };

			gridMalzeme.DataSource = malzemeStokBilgileri.ToList();
			// DataGridView'da Id sütunlarını gizli hale getiriyorum
			gridMalzeme.Columns["TedarikciId"].Visible = false;
			gridMalzeme.Columns["StokId"].Visible = false;
			gridMalzeme.Columns["MalzemeId"].Visible = false;
		}

		private void MalzemeESG_Load(object sender, EventArgs e)
		{
			MalzemeList();
			TedarikciDoldur();
			Restoran_Otomasyon.Yardimcilar.GridRenklendir(gridMalzeme);//Datagridde veriler daha rahat okunsun diye tek çift sütunlara farklı renk verme
		}

		private void gridMalzeme_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)//Grid üzerine tıklanınca verile ilgili alanlara fortmatlanarak getirliyor
			{
				DataGridViewRow row = gridMalzeme.Rows[e.RowIndex];
				hiddenMalzemeId.Text = row.Cells["MalzemeId"].Value.ToString();
				txtad.Text = row.Cells["MalzemeAd"].Value.ToString();
				hiddenTedarikciId.Text = row.Cells["TedarikciId"].Value.ToString();
				hiddenStokId.Text = row.Cells["StokId"].Value.ToString();

				int tedarikID = Convert.ToInt32(hiddenTedarikciId.Text);
				comboTedarik.Text = db.Tedarikciler.FirstOrDefault(o => o.Id == tedarikID).Firma;

				comboOlcu.Text = row.Cells["MalzemeTur"].Value.ToString();
				olcu = comboOlcu.Text;

				//fiyatı formatlı olarak gösterme
				string fiyat = row.Cells["MalzemeFiyat"].Value.ToString();
				fiyatformatsiz = Decimal.Parse(fiyat);
				txtfiyat.Text = Yardimcilar.FormatliDeger(fiyat);

				//Stok bilgilerini Formatlayarak gösterme
				string stok = row.Cells["StokMiktar"].Value.ToString();
				string minstok = row.Cells["StokMin"].Value.ToString();
				string maxstok = row.Cells["StokMax"].Value.ToString();

				if (olcu != "Adet")//Ölçüsü adet değilse kg ve L cinsine çevirmek için 1000 e böldüm
				{
					formatsizStok = Convert.ToDecimal(stok) / 1000;
					formatsizMin = Convert.ToDecimal(minstok) / 1000;
					formatsizMax = Convert.ToDecimal(maxstok) / 1000;
				}
				else
				{
					formatsizStok = Convert.ToDecimal(stok);
					formatsizMin = Convert.ToDecimal(minstok);
					formatsizMax = Convert.ToDecimal(maxstok);
				}
				txtmax.Text = Yardimcilar.BirimFormatı(formatsizMax, olcu);
				txtstok.Text = Yardimcilar.BirimFormatı(formatsizStok, olcu);
				txtmin.Text = Yardimcilar.BirimFormatı(formatsizMin, olcu);
			}
		}

		private void button2_Click(object sender, EventArgs e)//Seçilen malzemenin görünürlüğünü kapatıyor(siliyor)
		{
			DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				if (hiddenMalzemeId.Text != "")//Ürünün görünürlüğünün kapattım
				{
					int id = Convert.ToInt32(hiddenMalzemeId.Text);
					var malzeme = db.Malzemeler.Find(id);
					malzeme.Gorunurluk = false;
					db.SaveChanges();
					timer1.Start();
					MessageBox.Show("Kayıt Silindi");
					Yardimcilar.Temizle(groupMalzeme);
				}
			}
			Yardimcilar.Temizle(groupMalzeme);
			MalzemeList();
		}

		private void gridMalzeme_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//Grid üzerindeki sütunların formatlı görünmesini sağlıyor
		{
			Yardimcilar.GridFormat(gridMalzeme, "MalzemeFiyat", e);
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMiktar");
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMin");
			Yardimcilar.gridFormatStokMiktari(gridMalzeme, "StokMax");
		}

		//Seçilen ölçü birimini bir değişkene atıyorum bu sayede alanları ilgili türe göre formatlayabiliyorum
		private void comboOlcu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboOlcu.SelectedIndex == 0)
			{
				olcu = "Kg";
			}
			else if (comboOlcu.SelectedIndex == 1)
			{
				olcu = "Litre";
			}
			else
			{
				olcu = "Adet";
			}
			if (txtstok.Text != "")
			{
				formatsizStok = Yardimcilar.TemizleVeDondur(txtstok, olcu);
				txtstok.Text = Yardimcilar.BirimFormatı(formatsizStok, olcu);
			}
		}

		decimal fiyatformatsiz;
		decimal formatsizMin;
		decimal formatsizMax;
		decimal formatsizStok;
		string olcu;

		//Texboxlaradan ayrıldığında ön planla formatlı görünmelerini sağlıyorum ama arka planda düz veri olarak tutuyorum
		private void txtfiyat_Leave(object sender, EventArgs e)
		{
			if (txtfiyat.Text != "")
			{
				fiyatformatsiz = Decimal.Parse(Yardimcilar.FormatsizDeger(txtfiyat.Text));
				txtfiyat.Text = Yardimcilar.FormatliDeger(txtfiyat.Text);
			}
		}

		private void txtmin_Leave(object sender, EventArgs e)
		{
			if (txtmin.Text != "")
			{
				formatsizMin = Yardimcilar.TemizleVeDondur(txtmin, olcu);
				txtmin.Text = Yardimcilar.BirimFormatı(formatsizMin, olcu);
			}
		}

		private void txtmax_Leave(object sender, EventArgs e)
		{
			if (txtmax.Text != "")
			{
				formatsizMax = Yardimcilar.TemizleVeDondur(txtmax, olcu);
				txtmax.Text = Yardimcilar.BirimFormatı(formatsizMax, olcu);
			}
		}

		private void txtstok_Leave(object sender, EventArgs e)
		{
			if (txtstok.Text != "")
			{
				formatsizStok = Yardimcilar.TemizleVeDondur(txtstok, olcu);
				txtstok.Text = Yardimcilar.BirimFormatı(formatsizStok, olcu);
			}
		}

		private void StokGir_Click(object sender, EventArgs e)//Stokgirdilerinin yapılacağı forma yönlendirme
		{
			StokGirdiESG git = new StokGirdiESG();
			git.Show();
			this.Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (TedarikciPaneli.Visible != true)
			{
				TedarikciPaneli.Visible = true;
				// Form1'i açmak için
				Yardimcilar.OpenForm(new TedarikciESG(), TedarikciPaneli);
				comboTedarik.Text = "";
			}
			else
			{
				TedarikciPaneli.Visible = false;
			}
		}

		private void txtfiyat_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtfiyat, sender, e);
		}

		private void txtfiyat_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtfiyat, e);
		}

		private void txtmin_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtmin, sender, e);
		}

		private void txtmin_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtmin, e);
		}

		private void txtmax_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtmax, e);
		}

		private void txtmax_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtmax, sender, e);
		}

		private void txtAdAra_TextChanged(object sender, EventArgs e)
		{
			Filtrele();
		}

		private void ComboTedarikciAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			Filtrele();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Yardimcilar.Temizle(groupMalzemeFiltre);
			MalzemeList();
		}
		void Filtrele()
		{
			string MalzemeAd = txtAdAra.Text;
			string Olcu = olcuAra.Text;
			string Firma = ComboTedarikciAra.Text;

			var malzemeStokBilgileri = from malzeme in db.Malzemeler
									   join stok in db.Stoklar on malzeme.Id equals stok.MalzemeId
									   join tedarikci in db.Tedarikciler on stok.TedarikciId equals tedarikci.Id
									   where malzeme.Gorunurluk == true orderby malzeme.Id
									   select new
									   {
										   MalzemeId = malzeme.Id,
										   MalzemeAd = malzeme.Ad,
										   MalzemeTur = malzeme.Tur,
										   MalzemeFiyat = malzeme.Fiyat,
										   StokMiktar = stok.Miktar,
										   StokMin = stok.MinStok,
										   StokMax = stok.MaxStok,
										   TedarikciFirma = tedarikci.Firma,
										   TedarikciAd = tedarikci.AdSoyad,
										   TedarikciId = tedarikci.Id, // Tedarikçi ID'sini gösteriyoruz
										   StokId = stok.Id,
									   };

			if (!string.IsNullOrEmpty(MalzemeAd))
			{
				malzemeStokBilgileri = malzemeStokBilgileri.Where(p => p.MalzemeAd.Contains(MalzemeAd));
			}

			if (!string.IsNullOrEmpty(Olcu))
			{
				malzemeStokBilgileri = malzemeStokBilgileri.Where(p => p.MalzemeTur == Olcu);
			}

			if (!string.IsNullOrEmpty(Firma))
			{
				malzemeStokBilgileri = malzemeStokBilgileri.Where(p => p.TedarikciFirma == Firma);
			}
			gridMalzeme.DataSource = malzemeStokBilgileri.ToList();

			// DataGridView'da Id sütunlarını gizli hale getiriyorum
			gridMalzeme.Columns["TedarikciId"].Visible = false;
			gridMalzeme.Columns["StokId"].Visible = false;
			gridMalzeme.Columns["MalzemeId"].Visible = false;
		}

		private void olcuAra_SelectedIndexChanged(object sender, EventArgs e)
		{
			Filtrele();
		}
	}
}
