using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Rezervasyon
	{
		public int Id { get; set; }

		public DateTime Tarih { get; set; }

		public DateTime BaslangicSaat { get; set; }
		public DateTime BitisSaat { get; set; }

		public int KisiSayisi { get; set; }

		public string Talep { get; set; }

		public bool Onay { get; set; }
		public bool Gorunurluk { get; set; }

		public DateTime TalepTarihi { get; set; }
	}
}
