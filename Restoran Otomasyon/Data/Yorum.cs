﻿using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Yorum
	{
		public int Id { get; set; }

		public string Baslik { get; set; }

		public string Icerik { get; set; }

		public DateTime Tarih { get; set; }

		public int Puan { get; set; }

		public int Begenme { get; set; }

		public int MusteriId { get; set; }

		public bool Gorunurluk { get; set; }

		public Musteri Musteri { get; set; }

		public ICollection<Siparis> Siparislers { get; set; } = new List<Siparis>();
	}
}
