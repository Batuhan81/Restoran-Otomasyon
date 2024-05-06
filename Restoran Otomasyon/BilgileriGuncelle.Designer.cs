namespace Restoran_Otomasyon.Paneller
{
	partial class BilgileriGuncelle
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BilgileriGuncelle));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAd = new System.Windows.Forms.TextBox();
			this.txtmail = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtsifre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txttekrar = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.txttekrar);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtsifre);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtmail);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtAd);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(273, 292);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Kullanıcı Bilgileri";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(72, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ad:";
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(113, 47);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(139, 24);
			this.txtAd.TabIndex = 1;
			// 
			// txtmail
			// 
			this.txtmail.Location = new System.Drawing.Point(113, 85);
			this.txtmail.Name = "txtmail";
			this.txtmail.Size = new System.Drawing.Size(139, 24);
			this.txtmail.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(30, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "E-Posta:";
			// 
			// txtsifre
			// 
			this.txtsifre.Location = new System.Drawing.Point(113, 123);
			this.txtsifre.Name = "txtsifre";
			this.txtsifre.Size = new System.Drawing.Size(139, 24);
			this.txtsifre.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(56, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Şifre:";
			// 
			// txttekrar
			// 
			this.txttekrar.Location = new System.Drawing.Point(113, 161);
			this.txttekrar.Name = "txttekrar";
			this.txttekrar.Size = new System.Drawing.Size(139, 24);
			this.txttekrar.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(8, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Şifre Tekar:";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(75, 199);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(139, 87);
			this.button1.TabIndex = 1;
			this.button1.Text = "Kaydet";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			// 
			// BilgileriGuncelle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(297, 315);
			this.Controls.Add(this.groupBox1);
			this.Name = "BilgileriGuncelle";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bilgilerinizi Güncelleyin";
			this.Load += new System.EventHandler(this.BilgileriGuncelle_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtAd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txttekrar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtsifre;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtmail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList ımageList1;
	}
}