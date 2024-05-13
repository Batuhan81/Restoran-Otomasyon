using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class KayitsizMusteri
	{
		public int Id {  get; set; }

		public string Ad { get; set; }

		public string Telefon { get; set; }

		//Dışarıya giden siparişler için
		//public string Adres { get; set; }

		//Bunun kalkması gerek birden fazla rezervasyonu olabilir
		public int RezarvasyonId {  get; set; }

		public bool Gorunurluk {  get; set; }

		public DateTime KayitTarihi { get; set; }
	}
}
