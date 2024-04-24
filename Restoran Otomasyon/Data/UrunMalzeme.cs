using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class UrunMalzeme
	{
		public int Id { get; set; }

		public int Miktar { get; set; }

		public int UrunId { get; set; }

		public int MalzemeId { get; set; }

		public bool Gorunurluk { get; set; }

		public bool Secenek {  get; set; }

		public Malzeme Malzeme { get; set; } 

		public Urun Urun { get; set; } 
	}
}
