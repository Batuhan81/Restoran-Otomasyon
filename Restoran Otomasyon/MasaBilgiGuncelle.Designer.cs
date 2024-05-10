namespace Restoran_Otomasyon
{
	partial class MasaBilgiGuncelle
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasaBilgiGuncelle));
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
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
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Güncelle.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(321, 60);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 58);
			this.button1.TabIndex = 51;
			this.button1.Text = "Güncelle";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kapalı.png");
			this.ımageList1.Images.SetKeyName(1, "Aç.png");
			this.ımageList1.Images.SetKeyName(2, "Temiz.png");
			this.ımageList1.Images.SetKeyName(3, "Güncelle.png");
			this.ımageList1.Images.SetKeyName(4, "Sil butonu - Kopya.png");
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.ImageKey = "Sil butonu - Kopya.png";
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(321, 133);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 58);
			this.button2.TabIndex = 52;
			this.button2.Text = "Sil";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.SkyBlue;
			this.button3.ImageKey = "Aç.png";
			this.button3.ImageList = this.ımageList1;
			this.button3.Location = new System.Drawing.Point(321, 206);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(144, 58);
			this.button3.TabIndex = 53;
			this.button3.Text = "Masayı Aç/Kapat";
			this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.SkyBlue;
			this.button4.ImageKey = "Temiz.png";
			this.button4.ImageList = this.ımageList1;
			this.button4.Location = new System.Drawing.Point(321, 280);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(144, 58);
			this.button4.TabIndex = 54;
			this.button4.Text = "Temiz";
			this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
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
			this.groupBox1.Location = new System.Drawing.Point(12, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(284, 358);
			this.groupBox1.TabIndex = 55;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Masa Bilgileri";
			// 
			// txtsiparisDurum
			// 
			this.txtsiparisDurum.Location = new System.Drawing.Point(135, 322);
			this.txtsiparisDurum.Name = "txtsiparisDurum";
			this.txtsiparisDurum.ReadOnly = true;
			this.txtsiparisDurum.Size = new System.Drawing.Size(142, 22);
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
			this.txtkategori.Size = new System.Drawing.Size(142, 22);
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
			this.txtpersonel.Size = new System.Drawing.Size(142, 22);
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
			this.txtodenen.Size = new System.Drawing.Size(142, 22);
			this.txtodenen.TabIndex = 9;
			this.txtodenen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtodenen_KeyDown);
			this.txtodenen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtodenen_KeyPress);
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
			this.txttutar.Size = new System.Drawing.Size(142, 22);
			this.txttutar.TabIndex = 7;
			this.txttutar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttutar_KeyDown);
			this.txttutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttutar_KeyPress);
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
			this.txtkapasite.Size = new System.Drawing.Size(142, 22);
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
			this.txtDurum.Size = new System.Drawing.Size(142, 22);
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
			this.txtmasaadi.Size = new System.Drawing.Size(142, 22);
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
			// MasaBilgiGuncelle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(477, 381);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "MasaBilgiGuncelle";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Masa İşlemleri";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MasaBilgiGuncelle_FormClosed);
			this.Load += new System.EventHandler(this.MasaBilgiGuncelle_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
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
	}
}