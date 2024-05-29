using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon.Data
{
	public class VtBilgileri
	{
		public string ServerAdi { get; set; }

		public string DatabaseAdi { get; set; }

		public string UserBilgisi { get; set; }

		public string VtSifre { get; set; }

		public int Port { get; set; }

		public string yeniBağlantıDizesi;
		public void BağlantıDizesiniAyarla(string svad, int port, string dbad, string user, string sifre)
		{
			// Yeni bağlantı dizesini oluştur
			yeniBağlantıDizesi = $"Server={svad};Port={port};Database={dbad};Uid={user};Pwd={sifre};";

			// App.config dosyasındaki connection string'i güncelle
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
			connectionStringsSection.ConnectionStrings["Context"].ConnectionString = yeniBağlantıDizesi;

			// Değişiklikleri kaydet ve uygula
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("connectionStrings"); // Yapılandırma bölümünü yeniden yükle

			
		}
	}
}
