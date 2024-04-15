using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Urun///ilişikileri nerede
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Aciklama { get; set; }

		public string Detay { get; set; }

		public decimal Fiyat { get; set; }

		public string Fotograf { get; set; }

		public bool Akitf { get; set; }

		public DateTime IndirimTarihi { get; set; }

		public decimal IndirimliFiyat { get; set; }

		public int IndirimYuzdesi { get; set; }

		public int KategorId { get; set; }

		public bool Gorunurluk { get; set; }

		public Kategori Kategori { get; set; }	
	}
}
