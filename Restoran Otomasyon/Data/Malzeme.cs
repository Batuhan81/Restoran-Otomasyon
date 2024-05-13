using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Malzeme
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Tur { get; set; }//Kg/L/Adet

		public decimal Fiyat { get; set; }

		public bool Gorunurluk { get; set; }

	}
}
