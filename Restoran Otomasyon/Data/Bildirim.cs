using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Bildirim
	{
		public int Id { get; set; }

		public string Baslik { get; set; }

		public string Aciklama { get; set; }

		public bool Okundu { get; set; }

		public int MusteriId { get; set; }

		public int PersonelId { get; set; }

		public int KasaId { get; set; }

		public int MutfakId { get; set; }

		public Kasa Kasa { get; set; }

		public Musteri Musteri { get; set; }

		public Mutfak Mutfak { get; set; }

		public Personel Personel { get; set; }
	}
}
