using System;
using System.Collections.Generic;
namespace Restoran_Otomasyon.Data
{
	public partial class MenuUrun
	{
		public int Id { get; set; }

		public int UrunId { get; set; }

		public int MenuId { get; set; }

		public bool Gorunurluk { get; set; }

		public Menu Menu { get; set; } 

		public Urun Urun { get; set; }
	}
}
