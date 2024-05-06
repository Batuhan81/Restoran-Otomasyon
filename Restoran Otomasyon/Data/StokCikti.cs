using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class StokCikti
	{
        public int Id { get; set; }

		public string Neden { get; set; }

		public decimal Miktar { get; set; }

		public decimal SonStok { get; set; }

        public bool Gorunuluk { get; set; }

        public int TedarikciId { get; set; }

        public int MalzemeId { get; set; }

        public Tedarikci Tedarikci { get; set; }

        public Malzeme Malzeme { get; set; }

        public DateTime Tarih {  get; set; }
    }
}
