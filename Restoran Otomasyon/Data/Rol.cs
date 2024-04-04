using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Rol
	{
		public int Id { get; set; }

		public string Ad { get; set; }

		public bool Gorunurluk { get; set; }

		public DateTime KayitT { get; set; }

		public ICollection<Personel> Personellers { get; set; } = new List<Personel>();
	}
}
