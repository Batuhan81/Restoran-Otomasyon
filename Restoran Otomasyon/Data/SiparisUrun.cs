using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class SiparisUrun
	{
		public int Id { get; set; }

		public int Miktar { get; set; }

		public int SiparisId { get; set; }

		public int UrunId { get; set; }

		public bool Gorunurluk { get; set; }

		public Siparis Siparis { get; set; }

		public Urun Urun { get; set; } 
	}
}
