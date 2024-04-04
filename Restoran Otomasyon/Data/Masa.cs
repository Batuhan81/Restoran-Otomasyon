﻿using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Masa
	{
		public int Id { get; set; }

		public string Kod { get; set; }

		public bool Durum { get; set; }

		public int Kapasite { get; set; }

		public bool Temizlik { get; set; }

		public int Tutar { get; set; }

		public int OdenenTutar { get; set; }

		public int PersonelId { get; set; }

		public bool Gorunurluk { get; set; }

		public ICollection<Musteri> Musterilers { get; set; } = new List<Musteri>();

		public Personel Personel { get; set; }
	}
}
