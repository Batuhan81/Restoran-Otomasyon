using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Rezervasyon
	{
		public int Id { get; set; }

		public int? MusteriId { get; set; }

		public int? KayitsizMusteriId { get; set; }

		public DateTime Tarih { get; set; }

		public TimeSpan BaslangicSaat { get; set; }

		public TimeSpan BitisSaat { get; set; }

		public int KisiSayisi { get; set; }

		public string Talep { get; set; }

		public int Onay { get; set; }//1 Onay Bekliyor /2 Onaylandı /3 Gerçekleşti /4 İptal Edildi /5 Onaylanmadı /6 Gelmedi

		public bool Gorunurluk { get; set; }

		public DateTime TalepTarihi { get; set; }

		public Musteri musteri { get; set; }

		public KayitsizMusteri kayitsizMusteri { get; set; }

	}
}
