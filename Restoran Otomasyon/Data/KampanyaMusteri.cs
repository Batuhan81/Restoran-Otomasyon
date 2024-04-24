using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class KampanyaMusteri
	{
		public int Id { get; set; }

		public string Kod { get; set; }

		public decimal Indirim { get; set; }

		public DateTime GecerlilikTarihi { get; set; }

		public bool Durum { get; set; }

		public int MusteriId { get; set; }

        public bool Gorunurluk { get; set; }

        public Musteri Musteri { get; set; }
	}
}


