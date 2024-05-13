using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Durum
	{
		public int Id { get; set; }

		public int Ad { get; set; }//1 sipariş alındı/2 Sipariş Onaylandı/3 Hazırlanıyor/4 Hazırlandı/5 Ödeme Bekliyor /6 Ödendi/ İptal Edildi/8 Yolda /Teslim Edildi

		public DateTime Zaman { get; set; }

		public int Yer { get; set; }//1 Müşteri /2Mutfak /3 Kasa/4 kurye?

		//Bu sanki masaSiparişin durumu olsa daha mantıklı gibi bu sayede bir sipariş hazırlanırken bir diğeri çoktan teslim edilmiş olabilir.
		public int SiparisId { get; set; }

		public virtual Siparis Siparis { get; set; }
	}
}
