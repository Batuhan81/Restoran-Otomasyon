﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class Odeme
	{
		public int Id { get; set; }

		public int Tur { get; set; }//1 Nakit/ 2 Kart

		public decimal Tutar { get; set; }

		public int SiparisID { get; set; }

		public virtual Siparis siparis { get; set; }

		public DateTime OdemeTarih { get; set; }
	}
}
