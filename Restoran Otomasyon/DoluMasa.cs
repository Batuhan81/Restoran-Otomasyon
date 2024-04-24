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

namespace Restoran_Otomasyon
{
	public partial class DoluMasa : Form
	{
		public DoluMasa(int masaID)
		{
			InitializeComponent();
			masaId=masaID;
		}
		int masaId;
		Context db=new Context();
		int sonSiparisId;
		void MasaSiparisi()
		{
			// MasaSiparisler tablosundan ilgili masa ID'sine göre en son eklenen siparişi bul
			var sonSiparis = db.MasaSiparisler
								.OrderByDescending(o => o.Id)
								.FirstOrDefault(o => o.MasaId == masaId);

			if (sonSiparis != null)
			{
				// Burada son siparişe erişebilirsiniz
				// Örneğin, son sipariş ID'si
				 sonSiparisId = sonSiparis.SiparisId;
				// Eğer Siparis tablosundan son siparişi almak istiyorsanız:
				var sonSiparisDetay = db.Siparisler.FirstOrDefault(s => s.Id == sonSiparisId);
				if (sonSiparisDetay != null)
				{
					// Burada son sipariş detaylarına erişebilirsiniz
				}
			}
			else
			{
				// İlgili masa ID'sine ait herhangi bir sipariş bulunamadı
			}

		}

		private void DoluMasa_Load(object sender, EventArgs e)
		{
			MasaSiparisi();
		}
	}
}
