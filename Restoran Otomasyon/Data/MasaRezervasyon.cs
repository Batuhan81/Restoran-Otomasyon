using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class MasaRezervasyon
	{
		public int Id { get; set; }

		public int RezervasyonId { get; set; }

		public int MasaId { get; set; }
		public bool Gorunurluk { get; set; }

		public Masa Masa { get; set; }

		public Rezervasyon Rezervasyon { get; set; }
	}

}
