﻿using System;
using System.Collections.Generic;

namespace Restoran_Otomasyon.Data
{
	public partial class Mutfak
	{
		public int Id { get; set; }

		public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

	}
}
