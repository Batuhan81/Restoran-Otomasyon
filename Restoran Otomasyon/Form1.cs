using Restoran_Otomasyon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Windows.Controls;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;

namespace Restoran_Otomasyon
{
	public partial class Form1 : Form
	{
		public static IHubProxy hubProxy;
		public static HubConnection connection;
		public Form1()
		{
			InitializeComponent();
			ConnectToSignalR();
		}
		public static string url = "http://192.168.1.152:8080/signalr/hubs"; // SignalR sunucusunun adresi
		private async void ConnectToSignalR()
		{
			//http://localhost:8080/signalr/hubs
			//https://192.168.137.1:5001/hubs/mutfakhub

			connection = new HubConnection(url);
			hubProxy = connection.CreateHubProxy("RestaurantHub");

			hubProxy.On<string>("updateOrderStatus", message =>
			{
				Invoke((Action)(() =>
				{
					// Mesaj alındığında yapılacak işlemler buraya eklenir
					// Bu örnekte sadece konsola yazdırılıyor
					Console.WriteLine(message);
				}));
			});

			try
			{
				await connection.Start();
				if (connection.State == ConnectionState.Connected)
				{
					MessageBox.Show("SignalR sunucusuna bağlanıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Bağlantı başarılıysa mesaj göster
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"SignalR sunucusuna bağlanılamadı: {ex.Message}"); // Hata varsa mesaj göster
			}

			if (connection.State == ConnectionState.Disconnected)
			{
				MessageBox.Show("Bağlantı kapalı");
			}
		}

		private void timer1_Tick(object sender, EventArgs e)//timerın her süresi dolduğunda metnin başındaki harfi sonuna ekleyecek
		{
			label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
		}

		private void timer2_Tick_1(object sender, EventArgs e)//Kayar yazı timer2 boyunca haraket edecek süre dolunca giriş ekranı açılacak
		{
			timer1.Stop();
			timer2.Stop();
			this.Hide();
			Giris git = new Giris();
			git.ShowDialog();
		}
		Context db = new Context();

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!db.Database.Exists())//Projenin bağlı olduğu vt var mı diye kontrol ediyorum yoksa oluşturma Sayfasına yönlendiriyorum
			{
				timer1.Stop();
				timer2.Stop();
				MessageBox.Show("Bu Proje İçin Bir Veritabanın Oluşturulması Gerekiyor Sizi İlgili Sayfaya Yönlendiriyoruz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				VtBilgiGir git = new VtBilgiGir();
				git.ShowDialog();
				timer1.Start();
				timer2.Start();
			}
		}
	}
}
