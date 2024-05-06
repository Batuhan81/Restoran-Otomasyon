using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class Kullanici
	{
		[Key] 
		public int Id { get; set; }

        public string Mail { get; set; }

        public string Ad { get; set; }

        public string Sifre { get; set; }

		public bool Gorunurluk { get; set; }
	}
}
