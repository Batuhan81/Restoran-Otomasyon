using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Masa
	{
		public int Id { get; set; }

		public string Kod { get; set; }

		public int Durum { get; set; }

		public int Kapasite { get; set; }

        public  int KategoriId { get; set; }

		public string Qr {  get; set; }

        public decimal Tutar { get; set; }

		public decimal OdenenTutar { get; set; }

		public int? PersonelId { get; set; }

		public bool Gorunurluk { get; set; }

		////Buda silinecek
		//public ICollection<Musteri> Musterilers { get; set; } = new List<Musteri>();
		public ICollection<MasaOzellik> MasaOzellikler { get; set; } = new List<MasaOzellik>();

		public Personel Personel { get; set; }
	}
}
