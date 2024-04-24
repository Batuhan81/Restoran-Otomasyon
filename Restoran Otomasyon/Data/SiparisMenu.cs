using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class SiparisMenu
	{
		public int Id { get; set; }

		public int Miktar { get; set; }

		public int MenuId { get; set; }

		public int SiparisId { get; set; }

		public bool Gorunurluk { get; set; }

		public Menu Menu { get; set; } 

		public Siparis Siparis { get; set; }
	}
}
