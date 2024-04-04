using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Stok
	{
		public int Id { get; set; }

		public decimal Miktar { get; set; }

		public decimal MinStok { get; set; }

		public decimal MaxStok { get; set; }

		public int TedarikciId { get; set; }

		public bool Gorunurluk { get; set; }

		public int MalzemeId { get; set; }

		public Malzeme Malzeme { get; set; }

		public ICollection<Malzeme> Malzemelers { get; set; } = new List<Malzeme>();

		public Tedarikci Tedarikci { get; set; }
	}
}
