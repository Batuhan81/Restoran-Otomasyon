using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class TeslimatSiparis
	{
		public int Id { get; set; }

		public DateTime OluşturmaTarihi { get; set; }

		public int SiparisId { get; set; }

		public int TeslimatId { get; set; }

		public int MusteriId { get; set; }

		public bool Gorunurluk { get; set; }

		public Musteri Musteri { get; set; }

		public Siparis Siparis { get; set; }

		public Teslimat Teslimat { get; set; }
	}
}
