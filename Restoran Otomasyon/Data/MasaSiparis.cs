using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class MasaSiparis
	{
		public int Id { get; set; }

		public int MasaId { get; set; }

		public int SiparisId { get; set; }

		//Sonra açılacak
		//public int PersonelId { get; set; }

		public int? MusteriId { get; set; }

		public bool Gorunurluk { get; set; }

		public decimal Tutar { get; set; }

		public decimal OdenenTutar { get; set; }

		public virtual Masa Masa { get; set; }

		public Siparis Siparis { get; set; } 
	}
}
