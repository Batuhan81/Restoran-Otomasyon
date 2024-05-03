using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class Kampanya
	{
        public int Id { get; set; }

		public string Ad { get; set; }

		public Decimal Indirim { get; set; }

		public int SartTutar {  get; set; }

		public int SartSiparisSayisi { get; set; }

		public DateTime BaslangıcTarihi { get; set; }	

		public DateTime BitisTarihi { get; set; }
		
		public bool Gorunuruk { get; set; }

		public ICollection<KampanyaMusteri>KampanyaMusteris { get; set; }
    }
}
