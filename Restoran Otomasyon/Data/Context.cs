﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class Context : DbContext
	{
		public DbSet<Adres> Adresler { get; set; }
		public DbSet<Bildirim> Bildirimler { get; set; }
		public DbSet<Durum> Durumlar { get; set; }
		public DbSet<Kampanya> Kampayalar { get; set; }
		public DbSet<Kasa> Kasalar { get; set; }
		public DbSet<Kategori> Kategoriler{ get; set; }
		public DbSet<Malzeme> Malzemeler { get; set; }
		public DbSet<Masa> Masalar{ get; set; }
		public DbSet<MasaOzellik> MasaOzellikler { get; set; }
		public DbSet<MasaRezervasyon> MasaRezervasyonlar { get; set; }
		public DbSet<MasaSiparis> MasaSiparisler { get; set; }
		public DbSet<Menu> Menuler { get; set; }
		public DbSet<MenuUrun> MenuUrunler { get; set; }
		public DbSet<Musteri> Musteriler { get; set; }
		public DbSet<Mutfak> Mutfaklar { get; set; }
		public DbSet<Ozellik>Ozellikler { get; set; }
		public DbSet<Personel>Personeller { get; set; }
		public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
		public DbSet<Rol>Roller { get; set; }
		public DbSet<Siparis>Siparisler { get; set; }
		public DbSet<SiparisMenu>SiparisMenus { get; set; }
		public DbSet<SiparisUrun>SiparisUrunler{ get; set; }
		public DbSet<Stok> Stoklar{ get; set; }
		public DbSet<StokGirdi> StokGirdiler { get; set; }
		public DbSet<Tedarikci>Tedarikciler { get; set; }
		public DbSet<Teslimat>Teslimatlar { get; set; }
		public DbSet<TeslimatAdres>TeslimatAdresler { get; set; }
		public DbSet<TeslimatSiparis>TeslimatSiparisler { get; set; }
		public DbSet<Urun>Urunler { get; set; }
		public DbSet<UrunMalzeme>urunMalzemeler { get; set; }
		public DbSet<Yorum> Yorumlar { get; set; }
		public DbSet<Kullanici> Kullanicilar { get; set; }
		public DbSet<StokCikti> stokCiktilar { get; set; }


	}
}
