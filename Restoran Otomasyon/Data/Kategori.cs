using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Kategori
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Tur { get; set; }
		public bool Gorunurluk { get; set; }
	}
}
