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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.çalışanİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CalisanCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.CalisanRol = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.TedarikciCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.stokİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StokGİrdiCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.MalzemeCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.ürünİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UrunCRUD = new System.Windows.Forms.ToolStripMenuItem();
			this.menüİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kategoriEkleSilGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menüEkleSilGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
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
            this.stokİşlemleriToolStripMenuItem,
            this.ürünİşlemleriToolStripMenuItem,
            this.menüİşlemleriToolStripMenuItem});
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
			// stokİşlemleriToolStripMenuItem
			// 
			this.stokİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StokGİrdiCRUD,
            this.MalzemeCRUD});
			this.stokİşlemleriToolStripMenuItem.Name = "stokİşlemleriToolStripMenuItem";
			this.stokİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(165, 27);
			this.stokİşlemleriToolStripMenuItem.Text = "Malzeme İşlemleri";
			// 
			// StokGİrdiCRUD
			// 
			this.StokGİrdiCRUD.Name = "StokGİrdiCRUD";
			this.StokGİrdiCRUD.Size = new System.Drawing.Size(219, 28);
			this.StokGİrdiCRUD.Text = "Stok Girdisi Ekle";
			this.StokGİrdiCRUD.Click += new System.EventHandler(this.StokGİrdiCRUD_Click);
			// 
			// MalzemeCRUD
			// 
			this.MalzemeCRUD.Name = "MalzemeCRUD";
			this.MalzemeCRUD.Size = new System.Drawing.Size(219, 28);
			this.MalzemeCRUD.Text = "Malzeme Ekle";
			this.MalzemeCRUD.Click += new System.EventHandler(this.MalzemeCRUD_Click);
			// 
			// ürünİşlemleriToolStripMenuItem
			// 
			this.ürünİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UrunCRUD});
			this.ürünİşlemleriToolStripMenuItem.Name = "ürünİşlemleriToolStripMenuItem";
			this.ürünİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(133, 27);
			this.ürünİşlemleriToolStripMenuItem.Text = "Ürün İşlemleri";
			// 
			// UrunCRUD
			// 
			this.UrunCRUD.Name = "UrunCRUD";
			this.UrunCRUD.Size = new System.Drawing.Size(224, 28);
			this.UrunCRUD.Text = "Ürün Oluştur";
			this.UrunCRUD.Click += new System.EventHandler(this.UrunCRUD_Click);
			// 
			// menüİşlemleriToolStripMenuItem
			// 
			this.menüİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menüEkleSilGüncelleToolStripMenuItem});
			this.menüİşlemleriToolStripMenuItem.Name = "menüİşlemleriToolStripMenuItem";
			this.menüİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(138, 27);
			this.menüİşlemleriToolStripMenuItem.Text = "Menü İşlemleri";
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
			// menüEkleSilGüncelleToolStripMenuItem
			// 
			this.menüEkleSilGüncelleToolStripMenuItem.Name = "menüEkleSilGüncelleToolStripMenuItem";
			this.menüEkleSilGüncelleToolStripMenuItem.Size = new System.Drawing.Size(275, 28);
			this.menüEkleSilGüncelleToolStripMenuItem.Text = "Menü Ekle/Sil/Güncelle";
			this.menüEkleSilGüncelleToolStripMenuItem.Click += new System.EventHandler(this.menüEkleSilGüncelleToolStripMenuItem_Click);
			// 
			// Admin_Paneli
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1672, 686);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Admin_Paneli";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Admin Paneli";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem stokİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem StokGİrdiCRUD;
		private System.Windows.Forms.ToolStripMenuItem MalzemeCRUD;
		private System.Windows.Forms.ToolStripMenuItem ürünİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UrunCRUD;
		private System.Windows.Forms.ToolStripMenuItem menüİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kategoriEkleSilGüncelleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menüEkleSilGüncelleToolStripMenuItem;
	}
}