using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Teslimat
	{
		public int Id { get; set; }

		public DateTime Cıkıs { get; set; }

		public DateTime Varis { get; set; }

		public bool OdemeDurum { get; set; }

		public bool TeslimDurum { get; set; }

		public int PersonelId { get; set; }

		public bool Gorunurluk { get; set; }

		public Personel Personel { get; set; }

		public ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();
	}
}
