using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Kategori
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Tur { get; set; }//Masa/Ürün/Menü

		public bool Gorunurluk { get; set; }
	}
}
