﻿using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Personel
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public string Soyad { get; set; }

		public string Eposta { get; set; }

		public string Telefon { get; set; }

		public decimal Maas { get; set; }

		public DateTime DogumTarihi { get; set; }

		public DateTime BaslamaTarihi { get; set; }

		public bool Cinsiyet { get; set; }

        public string Adres { get; set; }
        public int RolId { get; set; }

		public string fotograf {  get; set; }

		public bool Gorunurluk { get; set; }

		public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

		public ICollection<Masa> Masalars { get; set; } = new List<Masa>();

		public Rol Rol { get; set; }

		public ICollection<Teslimat> Teslimatlars { get; set; } = new List<Teslimat>();
	}
}
