using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class Odeme
	{
		public int Id { get; set; }

		public int Tur { get; set; }

		public decimal Tutar { get; set; }

		public int SiparisID { get; set; }

		public Siparis siparis { get; set; }
	}
}
