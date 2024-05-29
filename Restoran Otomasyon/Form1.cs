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

		public Form1()
		{
			InitializeComponent();
			Yardimcilar.SignalRSunucuBaslat(); /*Şuanlık otomatik olarak başlatıyor ama bağlanırken sorunlu o yüzden kapattım*/
			Yardimcilar.ConnectToSignalR();
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
