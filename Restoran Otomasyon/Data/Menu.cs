using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Menu
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Aciklama { get; set; }

		public int Fiyat { get; set; }

		public string Detay { get; set; }

		public string Fotograf { get; set; }

		public bool Akitf { get; set; }
		public bool Gorunurluk { get; set; }

		public int IndirimliFiyat { get; set; }
	}
}
