namespace Restoran_Otomasyon.Paneller
{
	partial class MasaESG
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasaESG));
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.comboKat = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.MasaPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.PanelKategori = new System.Windows.Forms.Panel();
			this.MasaEklePanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtkod = new System.Windows.Forms.TextBox();
			this.txtkapasite = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.MasaOzellik = new System.Windows.Forms.CheckedListBox();
			this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
			this.MasaOzellikPanel = new System.Windows.Forms.Panel();
			this.button7 = new System.Windows.Forms.Button();
			this.btnKatSil = new System.Windows.Forms.Button();
			this.btnKatEkle = new System.Windows.Forms.Button();
			this.MasaEkle = new System.Windows.Forms.Button();
			this.MasaKaydet = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.MasaPanel.SuspendLayout();
			this.MasaEklePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Ekle2.png");
			this.ımageList1.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(1236, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 22);
			this.label2.TabIndex = 25;
			this.label2.Text = "Kat:";
			// 
			// comboKat
			// 
			this.comboKat.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.comboKat.FormattingEnabled = true;
			this.comboKat.Location = new System.Drawing.Point(1311, 196);
			this.comboKat.Name = "comboKat";
			this.comboKat.Size = new System.Drawing.Size(210, 26);
			this.comboKat.TabIndex = 24;
			this.comboKat.SelectedIndexChanged += new System.EventHandler(this.comboKat_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1469, 771);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 29;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// MasaPanel
			// 
			this.MasaPanel.Controls.Add(this.MasaEklePanel);
			this.MasaPanel.Controls.Add(this.PanelKategori);
			this.MasaPanel.Controls.Add(this.pictureBox1);
			this.MasaPanel.Location = new System.Drawing.Point(13, 13);
			this.MasaPanel.Name = "MasaPanel";
			this.MasaPanel.Size = new System.Drawing.Size(1142, 781);
			this.MasaPanel.TabIndex = 30;
			// 
			// PanelKategori
			// 
			this.PanelKategori.Location = new System.Drawing.Point(390, 3);
			this.PanelKategori.Name = "PanelKategori";
			this.PanelKategori.Size = new System.Drawing.Size(373, 376);
			this.PanelKategori.TabIndex = 0;
			this.PanelKategori.Visible = false;
			// 
			// MasaEklePanel
			// 
			this.MasaEklePanel.Controls.Add(this.MasaKaydet);
			this.MasaEklePanel.Controls.Add(this.button7);
			this.MasaEklePanel.Controls.Add(this.MasaOzellik);
			this.MasaEklePanel.Controls.Add(this.label1);
			this.MasaEklePanel.Controls.Add(this.label4);
			this.MasaEklePanel.Controls.Add(this.txtkod);
			this.MasaEklePanel.Controls.Add(this.txtkapasite);
			this.MasaEklePanel.Controls.Add(this.label3);
			this.MasaEklePanel.Location = new System.Drawing.Point(3, 3);
			this.MasaEklePanel.Name = "MasaEklePanel";
			this.MasaEklePanel.Size = new System.Drawing.Size(381, 450);
			this.MasaEklePanel.TabIndex = 1;
			this.MasaEklePanel.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Masa Kodu:";
			// 
			// txtkod
			// 
			this.txtkod.Location = new System.Drawing.Point(140, 14);
			this.txtkod.Name = "txtkod";
			this.txtkod.Size = new System.Drawing.Size(185, 24);
			this.txtkod.TabIndex = 1;
			// 
			// txtkapasite
			// 
			this.txtkapasite.Location = new System.Drawing.Point(140, 57);
			this.txtkapasite.Name = "txtkapasite";
			this.txtkapasite.Size = new System.Drawing.Size(185, 24);
			this.txtkapasite.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Masa Kapasite:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(125, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 18);
			this.label4.TabIndex = 4;
			this.label4.Text = "Masa Özellik:";
			// 
			// MasaOzellik
			// 
			this.MasaOzellik.FormattingEnabled = true;
			this.MasaOzellik.Location = new System.Drawing.Point(16, 123);
			this.MasaOzellik.Name = "MasaOzellik";
			this.MasaOzellik.Size = new System.Drawing.Size(345, 232);
			this.MasaOzellik.TabIndex = 5;
			// 
			// ımageList2
			// 
			this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
			this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList2.Images.SetKeyName(0, "Ekle2.png");
			this.ımageList2.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// MasaOzellikPanel
			// 
			this.MasaOzellikPanel.Location = new System.Drawing.Point(1161, 256);
			this.MasaOzellikPanel.Name = "MasaOzellikPanel";
			this.MasaOzellikPanel.Size = new System.Drawing.Size(368, 387);
			this.MasaOzellikPanel.TabIndex = 2;
			this.MasaOzellikPanel.Visible = false;
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.SystemColors.Control;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button7.ImageKey = "Ekle2.png";
			this.button7.ImageList = this.ımageList2;
			this.button7.Location = new System.Drawing.Point(230, 88);
			this.button7.Margin = new System.Windows.Forms.Padding(4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(33, 28);
			this.button7.TabIndex = 59;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// btnKatSil
			// 
			this.btnKatSil.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnKatSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKatSil.ImageIndex = 1;
			this.btnKatSil.ImageList = this.ımageList1;
			this.btnKatSil.Location = new System.Drawing.Point(1352, 87);
			this.btnKatSil.Name = "btnKatSil";
			this.btnKatSil.Size = new System.Drawing.Size(177, 74);
			this.btnKatSil.TabIndex = 28;
			this.btnKatSil.Text = " Kat Sil";
			this.btnKatSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnKatSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnKatSil.UseVisualStyleBackColor = true;
			// 
			// btnKatEkle
			// 
			this.btnKatEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnKatEkle.BackColor = System.Drawing.Color.Transparent;
			this.btnKatEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKatEkle.ImageKey = "Ekle2.png";
			this.btnKatEkle.ImageList = this.ımageList1;
			this.btnKatEkle.Location = new System.Drawing.Point(1161, 87);
			this.btnKatEkle.Name = "btnKatEkle";
			this.btnKatEkle.Size = new System.Drawing.Size(177, 74);
			this.btnKatEkle.TabIndex = 27;
			this.btnKatEkle.Text = " Kat Ekle";
			this.btnKatEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnKatEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnKatEkle.UseVisualStyleBackColor = false;
			this.btnKatEkle.Click += new System.EventHandler(this.btnKatEkle_Click);
			// 
			// MasaEkle
			// 
			this.MasaEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.MasaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.MasaEkle.ImageKey = "Ekle2.png";
			this.MasaEkle.ImageList = this.ımageList1;
			this.MasaEkle.Location = new System.Drawing.Point(1253, 8);
			this.MasaEkle.Name = "MasaEkle";
			this.MasaEkle.Size = new System.Drawing.Size(177, 74);
			this.MasaEkle.TabIndex = 26;
			this.MasaEkle.Text = " Masa Ekle";
			this.MasaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MasaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.MasaEkle.UseVisualStyleBackColor = true;
			this.MasaEkle.Click += new System.EventHandler(this.MasaEkle_Click);
			// 
			// MasaKaydet
			// 
			this.MasaKaydet.Location = new System.Drawing.Point(107, 371);
			this.MasaKaydet.Name = "MasaKaydet";
			this.MasaKaydet.Size = new System.Drawing.Size(174, 69);
			this.MasaKaydet.TabIndex = 60;
			this.MasaKaydet.Text = "Kaydet";
			this.MasaKaydet.UseVisualStyleBackColor = true;
			this.MasaKaydet.Click += new System.EventHandler(this.MasaKaydet_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(769, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(345, 323);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// MasaESG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1541, 796);
			this.Controls.Add(this.MasaOzellikPanel);
			this.Controls.Add(this.MasaPanel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnKatSil);
			this.Controls.Add(this.btnKatEkle);
			this.Controls.Add(this.MasaEkle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboKat);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MasaESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Masa İşlemleri";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MasaESG_Load);
			this.MasaPanel.ResumeLayout(false);
			this.MasaEklePanel.ResumeLayout(false);
			this.MasaEklePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnKatEkle;
		private System.Windows.Forms.Button MasaEkle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboKat;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.FlowLayoutPanel MasaPanel;
		private System.Windows.Forms.Button btnKatSil;
		private System.Windows.Forms.Panel PanelKategori;
		private System.Windows.Forms.Panel MasaEklePanel;
		private System.Windows.Forms.TextBox txtkod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtkapasite;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox MasaOzellik;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.ImageList ımageList2;
		private System.Windows.Forms.Panel MasaOzellikPanel;
		private System.Windows.Forms.Button MasaKaydet;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}