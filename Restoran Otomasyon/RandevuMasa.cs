﻿using Restoran_Otomasyon.Data;
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
	public partial class RandevuMasa : Form
	{
		public RandevuMasa(int masaID)
		{
			InitializeComponent();
			masaId = masaID;
		}
		int masaId;
		int musteriId = 0;
		int kayitsizMusteriId = 0;


		private void RandevuMasa_Load(object sender, EventArgs e)
		{
			Takvim.MinDate = DateTime.Now;
			Takvim.MaxDate = DateTime.Now.AddMonths(3);
			GUnlereRenkVerme(masaId);
			Yardimcilar.GridRenklendir(gridRandevular);
			RandevulariYukle();
			comboOnay.SelectedIndex = 0;
			Musteriler();
			kayitsizListesi();
		}
		int secilenSaat;
		int secilendakika;
		DateTime secilentarih;
		void RandevulariYukle()
		{
			// Masaya ait rezervasyonları veritabanından al
			var masaninRandevulari = db.MasaRezervasyonlar
			.Where(x => x.MasaId == masaId && x.Rezervasyon.Tarih >= DateTime.Today)
			.Select(x => new
			{
				RezervasyonID = x.Rezervasyon.Id,
				Tarih = x.Rezervasyon.Tarih,
				BaslangicSaat = x.Rezervasyon.BaslangicSaat,
				BitisSaat = x.Rezervasyon.BitisSaat,
				KisiSayisi = x.Rezervasyon.KisiSayisi,
				Talep = x.Rezervasyon.Talep,
				Durum = x.Rezervasyon.Onay == 1 ? "Onay Bekliyor" :
						x.Rezervasyon.Onay == 2 ? "Onaylandı" :
						x.Rezervasyon.Onay == 3 ? "Gerçekleşti" :
						x.Rezervasyon.Onay == 4 ? "İptal Edildi" :
						x.Rezervasyon.Onay == 5 ? "Onaylanmadı" :
						x.Rezervasyon.Onay == 6 ? "Gelmedi" : "Bilinmeyen",
				Telefon = x.Rezervasyon.musteri != null ? x.Rezervasyon.musteri.Telefon : x.Rezervasyon.kayitsizMusteri.Telefon,
			})
			.ToList();
			// Verileri datagridview'e yükle
			gridRandevular.DataSource = masaninRandevulari;
			gridRandevular.Columns["RezervasyonID"].Visible = false;
		}

		private void ComboSaat_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Seçilen saat değerini al
			secilenSaat = Convert.ToInt32(ComboSaat.SelectedItem);

			// ComboBitisSaat kontrolünü temizle
			CombobitisSaat.Items.Clear();

			// Seçilen saatten sonraki saat değerlerini ComboBitisSaat'e ekle
			if (secilenSaat == 24)
			{
				secilenSaat = 1;
			}
			for (int i = secilenSaat; i <= 24; i++)
			{
				CombobitisSaat.Items.Add(i);
			}
		}

		private void ComboDakika_SelectedIndexChanged(object sender, EventArgs e)
		{
			secilendakika = Convert.ToInt32(ComboDakika.SelectedItem);
		}
		void GUnlereRenkVerme(int masaId)
		{
			Takvim.RemoveAllBoldedDates(); // Önceki vurgulamaları kaldır

			// Seçilen masaya ait rezervasyonları al
			var rezervasyonlar = db.MasaRezervasyonlar
									.Where(x => x.Rezervasyon.Onay < 3 && x.Rezervasyon.Tarih >= DateTime.Today && x.MasaId == masaId)
									.Select(x => x.Rezervasyon.Tarih)
									.ToList();

			// Her bir rezervasyon için günü sarı arka plan ve kalın yazı tipi ile işaretle
			foreach (var tarih in rezervasyonlar)
			{
				Takvim.AddBoldedDate(tarih);
			}

			Takvim.UpdateBoldedDates();
		}

		private void Takvim_DateChanged(object sender, DateRangeEventArgs e)
		{
			GUnlereRenkVerme(masaId);
			secilentarih = Takvim.SelectionStart;
			ComboDakika.Items.Clear();
			ComboSaat.Items.Clear();
			if (secilentarih.Date == DateTime.Today)
			{
				
				int suankiSaat = DateTime.Now.Hour;
				int suankiDakika = DateTime.Now.Minute;
				int yuvarlanmisDakika = (suankiDakika + 9) / 10 * 10 % 60;
				for (int i = suankiSaat; i <= 24; i++)
				{
					ComboSaat.Items.Add(i);
				}
				ComboDakika.Items.Add("00");
				if (yuvarlanmisDakika > 0)
				{
					for (int i = yuvarlanmisDakika; i <= 50; i = i + 10)
					{
						ComboDakika.Items.Add(i);
					}
				}
			}
			else
			{
				for (int i = 1; i <= 24; i++)
				{
					ComboSaat.Items.Add(i);
				}
				ComboDakika.Items.Add("00");
				for (int i = 10; i <= 50; i = i + 10)
				{
					ComboDakika.Items.Add(i);
				}
			}
		}

		void temizle()
		{
			ComboSaat.Text = "";
			ComboDakika.Text = "";
			bitisDakika.Text = "";
			CombobitisSaat.Text = "";
			txtkisiSayisi.Text = "";
			txttalep.Text = "";
		}

		MasaRezervasyon masarezervasyon = new MasaRezervasyon();
		Rezervasyon rezervasyon = new Rezervasyon();
		Context db = new Context();
		int ıd;

		private void button1_Click(object sender, EventArgs e)
		{
			if (ComboSaat.SelectedIndex != -1 && ComboDakika.SelectedIndex != -1 && CombobitisSaat.SelectedIndex != -1 && bitisDakika.SelectedIndex != -1 && txtkisiSayisi.Text != "")
			{
				if (musteriId != 0 || kayitsizMusteriId != 0)
				{// Seçilen saat ve dakikayı birleştirerek başlangıç ve bitiş saatlerini oluştur
					TimeSpan baslangicSaat = new TimeSpan(secilenSaat, secilendakika, 0);
					TimeSpan bitisSaat = new TimeSpan(bitisSaati, bitisDakikasi, 0);

					// Yeni rezervasyonun zaman aralığını oluştur
					DateTime yeniRezervasyonBaslangic = secilentarih.Date + baslangicSaat;
					DateTime yeniRezervasyonBitis = secilentarih.Date + bitisSaat;
					var mevcutRezervasyonlar = db.MasaRezervasyonlar.Where(mr => mr.MasaId == masaId).ToList();

					// Yeni rezervasyonun zaman aralığını kontrol et
					bool zamanUygun = true;
					foreach (var rezervasyon in mevcutRezervasyonlar)
					{
						DateTime mevcutRezervasyonBaslangic = rezervasyon.Rezervasyon.Tarih + rezervasyon.Rezervasyon.BaslangicSaat;
						DateTime mevcutRezervasyonBitis = rezervasyon.Rezervasyon.Tarih + rezervasyon.Rezervasyon.BitisSaat;

						// Yeni rezervasyonun zaman aralığı mevcut rezervasyonlarla çakışıyor mu kontrol et
						if ((yeniRezervasyonBaslangic >= mevcutRezervasyonBaslangic && yeniRezervasyonBaslangic < mevcutRezervasyonBitis) ||
							(yeniRezervasyonBitis > mevcutRezervasyonBaslangic && yeniRezervasyonBitis <= mevcutRezervasyonBitis) ||
							(yeniRezervasyonBaslangic <= mevcutRezervasyonBaslangic && yeniRezervasyonBitis >= mevcutRezervasyonBitis))
						{
							zamanUygun = false;
							break;
						}
					}
					if (zamanUygun)
					{
						if (hiddenID.Text == "")
						{
							// Rezervasyonun tarihini seçilen tarih olarak ayarla
							rezervasyon.Tarih = secilentarih.Date;
							rezervasyon.BaslangicSaat = baslangicSaat;
							rezervasyon.BitisSaat = bitisSaat;
							rezervasyon.KisiSayisi = Convert.ToInt32(txtkisiSayisi.Text);
							rezervasyon.Talep = txttalep.Text;
							rezervasyon.Onay = comboOnay.SelectedIndex + 1;
							rezervasyon.Gorunurluk = true;

							if (musteriId != 0)
							{
								rezervasyon.MusteriId = musteriId;
								rezervasyon.KayitsizMusteriId = null;
							}
							else if (kayitsizMusteriId != 0)
							{
								rezervasyon.MusteriId = null;
								rezervasyon.KayitsizMusteriId = kayitsizMusteriId;
							}
							rezervasyon.TalepTarihi = DateTime.Now;
							db.Rezervasyonlar.Add(rezervasyon);
							db.SaveChanges();
							// Masanın rezervasyon bilgilerini ayarla
							masarezervasyon.RezervasyonId = rezervasyon.Id;
							masarezervasyon.MasaId = masaId;
							masarezervasyon.Gorunurluk = true;
							db.MasaRezervasyonlar.Add(masarezervasyon);
							db.SaveChanges();
							timer1.Start();
							MessageBox.Show("Rezarvasyon Başarı İle Oluşturuldu.");
						}
						else
						{
							var y = db.MasaRezervasyonlar.Find(ıd);
							y.RezervasyonId = rezervasyon.Id;
							y.MasaId = masaId;
							y.Gorunurluk = true;
							var x = db.Rezervasyonlar.Find(y.RezervasyonId);
							// Rezervasyonun tarihini seçilen tarih olarak ayarla
							x.Tarih = secilentarih.Date;
							x.BaslangicSaat = baslangicSaat;
							x.BitisSaat = bitisSaat;
							x.KisiSayisi = Convert.ToInt32(txtkisiSayisi.Text);
							x.Talep = txttalep.Text;

							if (musteriId != 0)
							{
								x.MusteriId = musteriId;
								x.KayitsizMusteriId = null;
							}
							else if (kayitsizMusteriId != 0)
							{
								x.MusteriId = null;
								x.KayitsizMusteriId = kayitsizMusteriId;
							}

							x.Onay = comboOnay.SelectedIndex + 1;
							x.Gorunurluk = true;
							x.TalepTarihi = DateTime.Now;
							timer1.Start();
							MessageBox.Show("Rezarvasyon Başarı İle Güncellendi.");
							db.SaveChanges();
						}
						temizle();
						RandevulariYukle();
						GUnlereRenkVerme(masaId);
						gridMusteriler.Visible = false;
						gridKayitsiz.Visible = false;
						gridRandevular.Visible=true;
						PanelMusteri.Visible = false;
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Seçilen saatlerde başka bir rezervasyon var, lütfen farklı bir saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					timer1.Start();
					MessageBox.Show("Rezervasyon İçin Müşteri Seçtiğinizden Emin Olunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				timer1.Start();
				MessageBox.Show("Rezervasyon İçin Gerekli Tüm Bilgileri Girdiğinizden Emin Olunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		int bitisSaati;
		int bitisDakikasi;
		private void bitisSaat_SelectedIndexChanged(object sender, EventArgs e)
		{
			bitisSaati = Convert.ToInt32(CombobitisSaat.SelectedItem);
			bitisDakika.Items.Clear();
			if (bitisSaati > secilenSaat)
			{
				bitisDakika.Items.Add("00");
				for (int i = 10; i <= 50; i = i + 10)
				{
					bitisDakika.Items.Add(i);
				}
			}
			else
			{
				for (int i = secilendakika + 10; i <= 50; i = i + 10)
				{
					bitisDakika.Items.Add(i);
				}
			}
		}




		private void bitisDakika_SelectedIndexChanged(object sender, EventArgs e)
		{
			bitisDakikasi = Convert.ToInt32(bitisDakika.SelectedItem);
		}

		private void gridRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// İlgili değerleri ilgili alanlara doldur
			if (gridRandevular.Rows.Count > 0)
			{
				// İlk satırı seç ve değerlerini ilgili alanlara aktar
				DataGridViewRow selectedRow = gridRandevular.Rows[0];
				hiddenID.Text = selectedRow.Cells["RezervasyonID"].Value.ToString();
				//Takvim.SelectionStart = (DateTime)selectedRow.Cells["Tarih"].Value;
				ComboSaat.Text = ((TimeSpan)selectedRow.Cells["BaslangicSaat"].Value).Hours.ToString();
				ComboDakika.Text = ((TimeSpan)selectedRow.Cells["BaslangicSaat"].Value).Minutes.ToString();
				CombobitisSaat.Text = ((TimeSpan)selectedRow.Cells["BitisSaat"].Value).Hours.ToString();
				bitisDakika.Text = ((TimeSpan)selectedRow.Cells["BitisSaat"].Value).Minutes.ToString();
				txtkisiSayisi.Text = selectedRow.Cells["KisiSayisi"].Value.ToString();
				txttalep.Text = selectedRow.Cells["Talep"].Value.ToString();
				string durum = selectedRow.Cells["Durum"].Value.ToString();
				switch (durum)
				{
					case "Onay Bekleniyor":
						comboOnay.SelectedIndex = 0;
						break;
					case "Onaylandı":
						comboOnay.SelectedIndex = 1;
						break;
					case "Gerçekleşti":
						comboOnay.SelectedIndex = 2;
						break;
					case "İptal Edildi":
						comboOnay.SelectedIndex = 3;
						break;
					case "Onaylanmadı":
						comboOnay.SelectedIndex = 4;
						break;
					case "Gelmedi":
						comboOnay.SelectedIndex = 5;
						break;

					default:
						// Belirli bir durum eşleşmediğinde yapılacak işlem
						break;
				}


				ıd = Convert.ToInt32(hiddenID.Text);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Rezervasyou Silmek İstediğinize Emin Misiniz?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				var x = db.MasaRezervasyonlar.Find(ıd);
				x.Gorunurluk = false;
				x.Rezervasyon.Onay = 4;
				db.SaveChanges();
			}
			timer1.Start();
			MessageBox.Show("Rezervasyon İptal Edildi");
			temizle();
			RandevulariYukle();
			GUnlereRenkVerme(masaId);
		}

		void Musteriler()
		{
			var Musteriler = db.Musteriler.Where(x => x.Gorunurluk == true).OrderByDescending(o => o.Id).Select(x => new
			{
				Id = x.Id,
				Ad = x.Ad,
				Soyad = x.Soyad,
				Mail = x.Eposta,
				Telefon = x.Telefon,
				Doğum_Tarihi = x.Dogumtarihi,
				Kayıt_Tarihi = x.KayitTarihi,
			}).ToList();
			gridMusteriler.DataSource = Musteriler;
			gridMusteriler.Columns["Id"].Visible = false;
		}
		private void gridMusteriler_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (PanelMusteri.Visible != true)
			{
				PanelMusteri.Visible = true;
			}
			else
			{
				PanelMusteri.Visible = false;
			}
		}

		private void gridMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			musteriId = (int)gridMusteriler.CurrentRow.Cells["Id"].Value;
			var x = db.Musteriler.Find(musteriId);
			timer1.Start();
			MessageBox.Show($"'{x.Ad}' Adlı Müşteri Seçildi ");
			kayitsizMusteriId = 0;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			gridMusteriler.Visible = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			KayitsizMusteri kayitsiz = new KayitsizMusteri();
			if (txtAd.Text != "" && maskedTel.Text != "")
			{
				if (txthiddenId.Text == "")
				{
					if (maskedTel.Text.Length == 14)
					{
						kayitsiz.Ad = txtAd.Text;
						kayitsiz.Telefon = maskedTel.Text;
						kayitsiz.KayitTarihi = DateTime.Now;
						kayitsiz.Gorunurluk = true;
						db.KayitsizMusteriler.Add(kayitsiz);
						timer1.Start();
						MessageBox.Show("Bilgiler Kayıt Edildi");
					}
					else
					{
						timer1.Start();
						MessageBox.Show("Telefon Numarasını Kontrol Ediniz!","İşlem Başarısız",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
				else
				{
					kayitsizMusteriId = Convert.ToInt32(txthiddenId.Text);
					var x = db.KayitsizMusteriler.Find(kayitsizMusteriId);
					x.Ad = txtAd.Text;
					x.Telefon = maskedTel.Text;
					kayitsiz.Gorunurluk = true; 
					timer1.Start();
					MessageBox.Show("Bilgiler Güncellendi");
				}
				db.SaveChanges();
				kayitsizListesi();
				txtAd.Text = "";
				maskedTel.Text = null;
				kayitsizMusteriId = 0;
			}
		}
		void kayitsizListesi()
		{
			var kayitsizmus = db.KayitsizMusteriler.Where(o => o.Gorunurluk).Select(o => new
			{
				Id = o.Id,
				Ad = o.Ad,
				Telefon = o.Telefon,
			}).ToList();
			gridKayitsiz.DataSource = kayitsizmus;
		}

		private void gridKayitsiz_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			kayitsizMusteriId = (int)gridKayitsiz.CurrentRow.Cells["Id"].Value;
			var x = db.KayitsizMusteriler.Find(kayitsizMusteriId);
			timer1.Start();
			MessageBox.Show($"'{x.Ad}' Adlı Müşteri Seçildi ");
			musteriId = 0;
		}

		private void txtkisiSayisi_KeyPress(object sender, KeyPressEventArgs e)
		{
			Yardimcilar.KontrolEt(txtkisiSayisi, e);
		}

		private void txtkisiSayisi_KeyDown(object sender, KeyEventArgs e)
		{
			Yardimcilar.Kopyalama(txtkisiSayisi, sender, e);
		}

		private void RandevuMasa_FormClosed(object sender, FormClosedEventArgs e)
		{
				// Masa butonlarını güncelle
			MasaESG calisanForm = Application.OpenForms.OfType<MasaESG>().FirstOrDefault();
			if (calisanForm != null)
			{
				calisanForm.MasaButonlariniGuncelle();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Start();
		}
	}
}
