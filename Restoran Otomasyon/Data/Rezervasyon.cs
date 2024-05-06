using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Rezervasyon
	{
		public int Id { get; set; }

		public int MusteriId { get; set; }

		public DateTime Tarih { get; set; }

		public TimeSpan BaslangicSaat { get; set; }

		public TimeSpan BitisSaat { get; set; }

		public int KisiSayisi { get; set; }

		public string Talep { get; set; }

		public int Onay { get; set; }

		public bool Gorunurluk { get; set; }

		public DateTime TalepTarihi { get; set; }

	}
}
