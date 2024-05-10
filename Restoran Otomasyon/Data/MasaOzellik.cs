using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class MasaOzellik
	{
		public int Id { get; set; }

		public int OzellikId { get; set; }

		public int MasaId { get; set; }

		public bool Gorunurluk { get; set; }

		public Masa Masa { get; set; } 

		public virtual Ozellik Ozellik { get; set; }
	}
}
