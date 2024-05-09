using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public partial class Kasa
	{
		public int Id { get; set; }

		public decimal Bakiye { get; set; } // Bakiye özelliğini ekleyin

		public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();
	}
}
