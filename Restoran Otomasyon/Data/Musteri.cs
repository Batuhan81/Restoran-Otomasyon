﻿using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Musteri
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Soyad { get; set; }

		public string Eposta { get; set; }

		public string Telefon { get; set; }

		public DateTime KayitTarihi { get; set; }

		public DateTime Dogumtarihi { get; set; }

		public int MasaId { get; set; }

		public int AdresId { get; set; }

		public bool Gorunurluk { get; set; }

		public Adres Adres { get; set; }

		public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

		public ICollection<Kampanya> Kampanyalars { get; set; } = new List<Kampanya>();

		public Masa Masa { get; set; }

		public ICollection<TeslimatAdres> Teslimatadreslers { get; set; } = new List<TeslimatAdres>();

		public ICollection<TeslimatSiparis> Teslimatsiparislers { get; set; } = new List<TeslimatSiparis>();

		public ICollection<Yorum> Yorumlars { get; set; } = new List<Yorum>();
	}
}
