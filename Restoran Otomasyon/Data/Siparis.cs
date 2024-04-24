using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Siparis
	{
		public int Id { get; set; }

		public DateTime Tarih { get; set; }

		//bu adres ıd olacak 
		public string Adres { get; set; }

		public decimal Tutar { get; set; }

		public bool OdemeDurum { get; set; }

		public string Not { get; set; }

		public int? YorumId { get; set; }

		public bool Gorunurluk { get; set; }

		public ICollection<Durum> Durumlars { get; set; } = new List<Durum>();

		public ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();

		public ICollection<Odeme> Odemeler { get; set; }=new List<Odeme>();

		public Yorum Yorum { get; set; }
	}
}
