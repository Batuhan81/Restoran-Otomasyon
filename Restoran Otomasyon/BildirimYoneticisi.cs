using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_Otomasyon
{
	public static class BildirimYoneticisi
	{
		private static bool okuyatıklandı = false;

		public static void BildirimleriGetir(Context db, ToolStripMenuItem BildirimlerToolStrip, int KullaniciId)
		{
			// Kullanıcıya ait tüm bildirimleri al, okunmamış olanları en üste koy ve son 10 tanesini al
			var sonOnBildirim = db.Bildirimler
								  .Where(o => o.KullaniciId == KullaniciId)
								  .OrderBy(o => o.Okundu)
								  .ThenByDescending(o => o.Tarih)
								  .Take(10)
								  .ToList();

			// Kullanıcıya ait okunmamış bildirimleri kontrol et
			var okunmamisBildirimler = db.Bildirimler
										 .Where(o => o.Okundu == false && o.KullaniciId == KullaniciId)
										 .Any();

			// Bildirimler paneli temizle
			BildirimlerToolStrip.DropDownItems.Clear();

			// Bildirimler varsa çan ikonunu göster
			if (sonOnBildirim.Any())
			{
				// Okunmamış bildirimler varsa farklı bir çan simgesi kullan
				if (okunmamisBildirimler)
				{
					if (BildirimlerToolStrip.Image != Restoran_Otomasyon.Properties.Resources.bildirimCani)
					{
						BildirimlerToolStrip.Image = Restoran_Otomasyon.Properties.Resources.bildirimCani;
						if (!okuyatıklandı)
						{
							Yardimcilar.CalBildirimSesi(); // Bildirim sesi çal
						}
					}
				}
				else
				{
					BildirimlerToolStrip.Image = Restoran_Otomasyon.Properties.Resources.bildirimsizCan;
				}

				foreach (var bildirim in sonOnBildirim)
				{
					ToolStripMenuItem bildirimItem = new ToolStripMenuItem($"{bildirim.Baslik}");

					// Okunmamış bildirimler için farklı bir arka plan rengi ata
					if (!bildirim.Okundu)
					{
						bildirimItem.BackColor = Color.LightBlue; // Varsayılan arka plan rengi
					}

					bildirimItem.Click += (s, e) => BildirimOku(bildirim, BildirimlerToolStrip, KullaniciId);
					BildirimlerToolStrip.DropDownItems.Add(bildirimItem);
				}
			}
			//else
			//{
			//	BildirimlerToolStrip.Image = null; // Çan ikonunu gizle
			//}
		}

		private static void BildirimOku(Bildirim bildirim, ToolStripMenuItem BildirimlerToolStrip, int KullaniciId)
		{
			var form = Application.OpenForms.OfType<Form>().FirstOrDefault(f => ControlHelper.FindControlRecursive(f, "BildirimPanel") != null);
			if (form != null)
			{
				Panel bildirimPanel = ControlHelper.FindControlRecursive(form, "BildirimPanel") as Panel;
				if (bildirimPanel != null)
				{
					TextBox txtaciklama = ControlHelper.FindControlRecursive(bildirimPanel, "txtaciklama") as TextBox;
					TextBox txtbaslik = ControlHelper.FindControlRecursive(bildirimPanel, "txtbaslik") as TextBox;
					Label lblTarih = ControlHelper.FindControlRecursive(bildirimPanel, "lblTarih") as Label;

					if (txtaciklama == null || txtbaslik == null || lblTarih == null)
					{
						MessageBox.Show("Kontroller bulunamadı. Formda ilgili kontrol isimlerini kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					bildirimPanel.Visible = true;
					txtaciklama.Text = bildirim.Aciklama;
					txtbaslik.Text = bildirim.Baslik;
					lblTarih.Text = bildirim.Tarih.ToString();
				}
				else
				{
					MessageBox.Show("Bildirim paneli bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				MessageBox.Show("Form bulunamadı. Formun açık olduğundan ve gerekli kontrollerin mevcut olduğundan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (var db = new Context())
			{
				// Bildirimi okundu olarak işaretle
				var bildirimToUpdate = db.Bildirimler.Find(bildirim.Id);
				if (bildirimToUpdate != null)
				{
					bildirimToUpdate.Okundu = true;
					db.SaveChanges();
				}
			}

			okuyatıklandı = true;
			// Bildirimleri güncelle, ancak bildirim sesini tekrar çalmayacak
			BildirimleriGetir(new Context(), BildirimlerToolStrip, KullaniciId);
		}
	}

	public static class ControlHelper
	{
		// Recursive method to find a control by its name
		public static Control FindControlRecursive(Control parent, string controlName)
		{
			foreach (Control control in parent.Controls)
			{
				if (control.Name == controlName)
				{
					return control;
				}
				else
				{
					Control foundControl = FindControlRecursive(control, controlName);
					if (foundControl != null)
					{
						return foundControl;
					}
				}
			}
			return null;
		}
	}
}
