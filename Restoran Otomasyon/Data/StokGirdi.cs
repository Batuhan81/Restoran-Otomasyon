using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class StokGirdi
	{
		public int Id { get; set; }

		public decimal Miktar { get; set; }

		public decimal AlısFiyati { get; set; }

		public string Neden { get; set; }

		//public bool Gorunuruluk { get; set; }

		public DateTime Tarih { get; set; }

		public decimal SonStokMiktari { get; set; }

		public int MalzemeId { get; set; }

		public Malzeme Malzeme { get; set; }

		public int TedarikciId { get; set; }

		public Tedarikci Tedarikci { get; set; }
	}
}
