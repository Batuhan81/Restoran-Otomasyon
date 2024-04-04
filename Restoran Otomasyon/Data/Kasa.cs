using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Kasa
	{
		public int Id { get; set; }

		public decimal Bakiye { get; set; }

		public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

		public ICollection<Siparis> Siparislers { get; set; } = new List<Siparis>();
	}
}
