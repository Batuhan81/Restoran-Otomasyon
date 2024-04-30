namespace Restoran_Otomasyon.Paneller
{
	partial class Admin_Paneli
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.çalışanİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CalisanCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.CalisanRol = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.TedarikciCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleSilGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.malzemeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UrunCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.menüOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.masaİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.masaOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.masaÖzellikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stokİşlemleriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.stokGirdiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stokSayımToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.stokÇıktıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çalışanİşlemleriToolStripMenuItem,
            this.toolStripMenuItem1,
            this.kategoriEkleToolStripMenuItem,
            this.ürünİşlemleriToolStripMenuItem,
            this.masaİşlemleriToolStripMenuItem,
            this.stokİşlemleriToolStripMenuItem1,
            this.kasaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1672, 31);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// çalışanİşlemleriToolStripMenuItem
			// 
			this.çalışanİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CalisanCRUD,
            this.CalisanRol});
			this.çalışanİşlemleriToolStripMenuItem.Name = "çalışanİşlemleriToolStripMenuItem";
			this.çalışanİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(153, 27);
			this.çalışanİşlemleriToolStripMenuItem.Text = "Çalışan İşlemleri";
			// 
			// CalisanCRUD
			// 
			this.CalisanCRUD.Name = "CalisanCRUD";
			this.CalisanCRUD.Size = new System.Drawing.Size(290, 28);
			this.CalisanCRUD.Text = "Çalışan Ekle/Sil/Güncelle";
			this.CalisanCRUD.Click += new System.EventHandler(this.CalisanCRUD_Click);
			// 
			// CalisanRol
			// 
			this.CalisanRol.Name = "CalisanRol";
			this.CalisanRol.Size = new System.Drawing.Size(290, 28);
			this.CalisanRol.Text = "Çalışan Rol Ekle";
			this.CalisanRol.Click += new System.EventHandler(this.CalisanRol_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TedarikciCRUD});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 27);
			this.toolStripMenuItem1.Text = "Tedarikçi İşlemleri";
			// 
			// TedarikciCRUD
			// 
			this.TedarikciCRUD.Name = "TedarikciCRUD";
			this.TedarikciCRUD.Size = new System.Drawing.Size(303, 28);
			this.TedarikciCRUD.Text = "Tedarikçi Ekle/Sil/Güncelle";
			this.TedarikciCRUD.Click += new System.EventHandler(this.TedarikciCRUD_Click);
			// 
			// kategoriEkleToolStripMenuItem
			// 
			this.kategoriEkleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategoriEkleSilGüncelleToolStripMenuItem});
			this.kategoriEkleToolStripMenuItem.Name = "kategoriEkleToolStripMenuItem";
			this.kategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(161, 27);
			this.kategoriEkleToolStripMenuItem.Text = "Kategori İşlemleri";
			// 
			// kategoriEkleSilGüncelleToolStripMenuItem
			// 
			this.kategoriEkleSilGüncelleToolStripMenuItem.Name = "kategoriEkleSilGüncelleToolStripMenuItem";
			this.kategoriEkleSilGüncelleToolStripMenuItem.Size = new System.Drawing.Size(305, 28);
			this.kategoriEkleSilGüncelleToolStripMenuItem.Text = "Kategori Ekle//Sil/Güncelle";
			this.kategoriEkleSilGüncelleToolStripMenuItem.Click += new System.EventHandler(this.kategoriEkleSilGüncelleToolStripMenuItem_Click);
			// 
			// ürünİşlemleriToolStripMenuItem
			// 
			this.ürünİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.malzemeEkleToolStripMenuItem,
            this.UrunCRUD,
            this.menüOluşturToolStripMenuItem});
			this.ürünİşlemleriToolStripMenuItem.Name = "ürünİşlemleriToolStripMenuItem";
			this.ürünİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(133, 27);
			this.ürünİşlemleriToolStripMenuItem.Text = "Ürün İşlemleri";
			// 
			// malzemeEkleToolStripMenuItem
			// 
			this.malzemeEkleToolStripMenuItem.Name = "malzemeEkleToolStripMenuItem";
			this.malzemeEkleToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
			this.malzemeEkleToolStripMenuItem.Text = "Malzeme Ekle";
			this.malzemeEkleToolStripMenuItem.Click += new System.EventHandler(this.malzemeEkleToolStripMenuItem_Click);
			// 
			// UrunCRUD
			// 
			this.UrunCRUD.Name = "UrunCRUD";
			this.UrunCRUD.Size = new System.Drawing.Size(201, 28);
			this.UrunCRUD.Text = "Ürün Oluştur";
			this.UrunCRUD.Click += new System.EventHandler(this.UrunCRUD_Click);
			// 
			// menüOluşturToolStripMenuItem
			// 
			this.menüOluşturToolStripMenuItem.Name = "menüOluşturToolStripMenuItem";
			this.menüOluşturToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
			this.menüOluşturToolStripMenuItem.Text = "Menü Oluştur";
			this.menüOluşturToolStripMenuItem.Click += new System.EventHandler(this.menüOluşturToolStripMenuItem_Click);
			// 
			// masaİşlemleriToolStripMenuItem
			// 
			this.masaİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masaOluşturToolStripMenuItem,
            this.masaÖzellikToolStripMenuItem});
			this.masaİşlemleriToolStripMenuItem.Name = "masaİşlemleriToolStripMenuItem";
			this.masaİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(136, 27);
			this.masaİşlemleriToolStripMenuItem.Text = "Masa İşlemleri";
			// 
			// masaOluşturToolStripMenuItem
			// 
			this.masaOluşturToolStripMenuItem.Name = "masaOluşturToolStripMenuItem";
			this.masaOluşturToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
			this.masaOluşturToolStripMenuItem.Text = "Masa Oluştur";
			this.masaOluşturToolStripMenuItem.Click += new System.EventHandler(this.masaOluşturToolStripMenuItem_Click);
			// 
			// masaÖzellikToolStripMenuItem
			// 
			this.masaÖzellikToolStripMenuItem.Name = "masaÖzellikToolStripMenuItem";
			this.masaÖzellikToolStripMenuItem.Size = new System.Drawing.Size(197, 28);
			this.masaÖzellikToolStripMenuItem.Text = "Masa Özellik";
			this.masaÖzellikToolStripMenuItem.Click += new System.EventHandler(this.masaÖzellikToolStripMenuItem_Click);
			// 
			// stokİşlemleriToolStripMenuItem1
			// 
			this.stokİşlemleriToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokGirdiToolStripMenuItem,
            this.stokSayımToolStripMenuItem1,
            this.stokÇıktıToolStripMenuItem});
			this.stokİşlemleriToolStripMenuItem1.Name = "stokİşlemleriToolStripMenuItem1";
			this.stokİşlemleriToolStripMenuItem1.Size = new System.Drawing.Size(128, 27);
			this.stokİşlemleriToolStripMenuItem1.Text = "Stok İşlemleri";
			// 
			// stokGirdiToolStripMenuItem
			// 
			this.stokGirdiToolStripMenuItem.Name = "stokGirdiToolStripMenuItem";
			this.stokGirdiToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
			this.stokGirdiToolStripMenuItem.Text = "Stok Girdi";
			this.stokGirdiToolStripMenuItem.Click += new System.EventHandler(this.stokGirdiToolStripMenuItem_Click);
			// 
			// stokSayımToolStripMenuItem1
			// 
			this.stokSayımToolStripMenuItem1.Name = "stokSayımToolStripMenuItem1";
			this.stokSayımToolStripMenuItem1.Size = new System.Drawing.Size(180, 28);
			this.stokSayımToolStripMenuItem1.Text = "Stok Sayım";
			this.stokSayımToolStripMenuItem1.Click += new System.EventHandler(this.stokSayımToolStripMenuItem1_Click);
			// 
			// stokÇıktıToolStripMenuItem
			// 
			this.stokÇıktıToolStripMenuItem.Name = "stokÇıktıToolStripMenuItem";
			this.stokÇıktıToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
			this.stokÇıktıToolStripMenuItem.Text = "Stok Çıktı";
			this.stokÇıktıToolStripMenuItem.Click += new System.EventHandler(this.stokÇıktıToolStripMenuItem_Click);
			// 
			// kasaToolStripMenuItem
			// 
			this.kasaToolStripMenuItem.Name = "kasaToolStripMenuItem";
			this.kasaToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
			this.kasaToolStripMenuItem.Text = "Kasa";
			this.kasaToolStripMenuItem.Click += new System.EventHandler(this.kasaToolStripMenuItem_Click);
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(12, 52);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(423, 350);
			this.chart1.TabIndex = 1;
			this.chart1.Text = "chart1";
			// 
			// Admin_Paneli
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1672, 686);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Admin_Paneli";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Admin Paneli";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Admin_Paneli_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem çalışanİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CalisanCRUD;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem CalisanRol;
		private System.Windows.Forms.ToolStripMenuItem TedarikciCRUD;
		private System.Windows.Forms.ToolStripMenuItem ürünİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UrunCRUD;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleSilGüncelleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem masaİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem masaOluşturToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem masaÖzellikToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stokİşlemleriToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem stokGirdiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stokSayımToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem stokÇıktıToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem malzemeEkleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menüOluşturToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kasaToolStripMenuItem;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}