using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Masa
	{
		public int Id { get; set; }

		public string Kod { get; set; }

		public int Durum { get; set; }// 1 Boş/2 Dolu/3 Kirli/4 Rezerve/5 Kapalı

		public int Kapasite { get; set; }

        public  int KategoriId { get; set; }

		public string Qr {  get; set; }

		//MasaSiparişe Taşıdık
		public int? PersonelId { get; set; }

		public bool Gorunurluk { get; set; }

		public virtual ICollection<MasaOzellik> MasaOzellikler { get; set; } = new List<MasaOzellik>();

		public virtual ICollection<MasaSiparis> MasaSiparis { get; set; } = new List<MasaSiparis>();

		public Personel Personel { get; set; }
	}
}
