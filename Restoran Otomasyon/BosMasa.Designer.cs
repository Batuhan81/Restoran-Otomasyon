﻿namespace Restoran_Otomasyon
{
	partial class BosMasa
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BosMasa));
			this.ComboUrun = new System.Windows.Forms.ComboBox();
			this.ComboMenu = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.UrunPaneli = new System.Windows.Forms.FlowLayoutPanel();
			this.DetayPaneli = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.gridSiparisler = new System.Windows.Forms.DataGridView();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtsiparisDurum = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtkategori = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtpersonel = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtodenen = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txttutar = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtkapasite = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDurum = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtmasaadi = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.UrunPaneli.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ComboUrun
			// 
			this.ComboUrun.FormattingEnabled = true;
			this.ComboUrun.Items.AddRange(new object[] {
            "Tümü"});
			this.ComboUrun.Location = new System.Drawing.Point(234, 12);
			this.ComboUrun.Name = "ComboUrun";
			this.ComboUrun.Size = new System.Drawing.Size(121, 26);
			this.ComboUrun.TabIndex = 1;
			this.ComboUrun.SelectedIndexChanged += new System.EventHandler(this.ComboUrun_SelectedIndexChanged);
			// 
			// ComboMenu
			// 
			this.ComboMenu.FormattingEnabled = true;
			this.ComboMenu.Items.AddRange(new object[] {
            "Tümü"});
			this.ComboMenu.Location = new System.Drawing.Point(962, 12);
			this.ComboMenu.Name = "ComboMenu";
			this.ComboMenu.Size = new System.Drawing.Size(121, 26);
			this.ComboMenu.TabIndex = 2;
			this.ComboMenu.SelectedIndexChanged += new System.EventHandler(this.ComboMenu_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.Location = new System.Drawing.Point(89, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 18);
			this.label7.TabIndex = 12;
			this.label7.Text = "Ürün Kategorileri";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label8.Location = new System.Drawing.Point(803, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(140, 18);
			this.label8.TabIndex = 13;
			this.label8.Text = "Menü Kategorileri";
			// 
			// UrunPaneli
			// 
			this.UrunPaneli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.UrunPaneli.Controls.Add(this.DetayPaneli);
			this.UrunPaneli.Location = new System.Drawing.Point(12, 48);
			this.UrunPaneli.Name = "UrunPaneli";
			this.UrunPaneli.Size = new System.Drawing.Size(1244, 760);
			this.UrunPaneli.TabIndex = 14;
			// 
			// DetayPaneli
			// 
			this.DetayPaneli.Location = new System.Drawing.Point(3, 3);
			this.DetayPaneli.Name = "DetayPaneli";
			this.DetayPaneli.Size = new System.Drawing.Size(1241, 581);
			this.DetayPaneli.TabIndex = 0;
			this.DetayPaneli.Visible = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.Location = new System.Drawing.Point(497, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(219, 33);
			this.button1.TabIndex = 16;
			this.button1.Text = "Tüm Ürünler";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// gridSiparisler
			// 
			this.gridSiparisler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridSiparisler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridSiparisler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridSiparisler.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridSiparisler.Location = new System.Drawing.Point(1263, 488);
			this.gridSiparisler.Margin = new System.Windows.Forms.Padding(4);
			this.gridSiparisler.Name = "gridSiparisler";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridSiparisler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridSiparisler.RowHeadersWidth = 51;
			this.gridSiparisler.RowTemplate.Height = 24;
			this.gridSiparisler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridSiparisler.Size = new System.Drawing.Size(266, 307);
			this.gridSiparisler.TabIndex = 47;
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "siparisOnayla2.png");
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button2.ImageKey = "siparisOnayla2.png";
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(1263, 380);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(265, 89);
			this.button2.TabIndex = 48;
			this.button2.Text = "Sipariş Onayla";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtsiparisDurum);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtkategori);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtpersonel);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtodenen);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txttutar);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtkapasite);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtDurum);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtmasaadi);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(1263, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(265, 358);
			this.groupBox1.TabIndex = 50;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Masa Bilgileri";
			// 
			// txtsiparisDurum
			// 
			this.txtsiparisDurum.Location = new System.Drawing.Point(135, 322);
			this.txtsiparisDurum.Name = "txtsiparisDurum";
			this.txtsiparisDurum.ReadOnly = true;
			this.txtsiparisDurum.Size = new System.Drawing.Size(123, 24);
			this.txtsiparisDurum.TabIndex = 15;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label14.Location = new System.Drawing.Point(9, 325);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(120, 18);
			this.label14.TabIndex = 14;
			this.label14.Text = "Sipariş Durum:";
			// 
			// txtkategori
			// 
			this.txtkategori.Location = new System.Drawing.Point(135, 285);
			this.txtkategori.Name = "txtkategori";
			this.txtkategori.ReadOnly = true;
			this.txtkategori.Size = new System.Drawing.Size(123, 24);
			this.txtkategori.TabIndex = 13;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label9.Location = new System.Drawing.Point(53, 288);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(76, 18);
			this.label9.TabIndex = 12;
			this.label9.Text = "Kategori:";
			// 
			// txtpersonel
			// 
			this.txtpersonel.Location = new System.Drawing.Point(135, 241);
			this.txtpersonel.Name = "txtpersonel";
			this.txtpersonel.ReadOnly = true;
			this.txtpersonel.Size = new System.Drawing.Size(123, 24);
			this.txtpersonel.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label6.Location = new System.Drawing.Point(15, 244);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "İlgili Personel:";
			// 
			// txtodenen
			// 
			this.txtodenen.Location = new System.Drawing.Point(135, 197);
			this.txtodenen.Name = "txtodenen";
			this.txtodenen.ReadOnly = true;
			this.txtodenen.Size = new System.Drawing.Size(123, 24);
			this.txtodenen.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(14, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Ödenen Tutar:";
			// 
			// txttutar
			// 
			this.txttutar.Location = new System.Drawing.Point(135, 153);
			this.txttutar.Name = "txttutar";
			this.txttutar.ReadOnly = true;
			this.txttutar.Size = new System.Drawing.Size(123, 24);
			this.txttutar.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(77, 156);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Tutar:";
			// 
			// txtkapasite
			// 
			this.txtkapasite.Location = new System.Drawing.Point(135, 109);
			this.txtkapasite.Name = "txtkapasite";
			this.txtkapasite.ReadOnly = true;
			this.txtkapasite.Size = new System.Drawing.Size(123, 24);
			this.txtkapasite.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(51, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Kapasite:";
			// 
			// txtDurum
			// 
			this.txtDurum.Location = new System.Drawing.Point(135, 65);
			this.txtDurum.Name = "txtDurum";
			this.txtDurum.ReadOnly = true;
			this.txtDurum.Size = new System.Drawing.Size(123, 24);
			this.txtDurum.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(57, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Durumu:";
			// 
			// txtmasaadi
			// 
			this.txtmasaadi.Location = new System.Drawing.Point(135, 21);
			this.txtmasaadi.Name = "txtmasaadi";
			this.txtmasaadi.ReadOnly = true;
			this.txtmasaadi.Size = new System.Drawing.Size(123, 24);
			this.txtmasaadi.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(47, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Masa Adı:";
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// BosMasa
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1634, 799);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.gridSiparisler);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.UrunPaneli);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ComboMenu);
			this.Controls.Add(this.ComboUrun);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "BosMasa";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sipariş Girişi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BosMasa_FormClosed);
			this.Load += new System.EventHandler(this.BosMasa_Load);
			this.UrunPaneli.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox ComboUrun;
		private System.Windows.Forms.ComboBox ComboMenu;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.FlowLayoutPanel UrunPaneli;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView gridSiparisler;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Panel DetayPaneli;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtsiparisDurum;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtkategori;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtpersonel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtodenen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txttutar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtkapasite;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDurum;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtmasaadi;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
	}
}