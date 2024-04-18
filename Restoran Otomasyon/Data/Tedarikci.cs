using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Tedarikci
	{
		public int Id { get; set; }

		public string AdSoyad { get; set; }

		public string Firma { get; set; }

		public string Telefon { get; set; }

		public string Eposta { get; set; }

        public string AdresBİlgisi { get; set; }

        public bool Gorunurluk { get; set; }

        public DateTime KayitTarihi{ get; set; }

		public ICollection<StokGirdi> Stokgirdilers { get; set; } = new List<StokGirdi>();

		public ICollection<Stok> Stoklars { get; set; } = new List<Stok>();
	}
}
