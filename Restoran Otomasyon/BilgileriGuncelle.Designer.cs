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
			this.sifreT = new System.Windows.Forms.Label();
			this.txtmevcutsifre = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txttekrar = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtyeniSifre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtmail = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sifreT);
			this.groupBox1.Controls.Add(this.txtmevcutsifre);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.txttekrar);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtyeniSifre);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtmail);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtAd);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 338);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Kullanıcı Bilgileri";
			// 
			// sifreT
			// 
			this.sifreT.AutoSize = true;
			this.sifreT.Location = new System.Drawing.Point(116, 245);
			this.sifreT.Name = "sifreT";
			this.sifreT.Size = new System.Drawing.Size(0, 18);
			this.sifreT.TabIndex = 1;
			// 
			// txtmevcutsifre
			// 
			this.txtmevcutsifre.Location = new System.Drawing.Point(119, 128);
			this.txtmevcutsifre.Name = "txtmevcutsifre";
			this.txtmevcutsifre.PasswordChar = '*';
			this.txtmevcutsifre.Size = new System.Drawing.Size(139, 24);
			this.txtmevcutsifre.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(6, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Mevcut Şifre:";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(68, 266);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(139, 65);
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
			// txttekrar
			// 
			this.txttekrar.Location = new System.Drawing.Point(119, 218);
			this.txttekrar.Name = "txttekrar";
			this.txttekrar.PasswordChar = '*';
			this.txttekrar.Size = new System.Drawing.Size(139, 24);
			this.txttekrar.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(17, 218);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Şifre Tekar:";
			// 
			// txtyeniSifre
			// 
			this.txtyeniSifre.Location = new System.Drawing.Point(119, 173);
			this.txtyeniSifre.Name = "txtyeniSifre";
			this.txtyeniSifre.PasswordChar = '*';
			this.txtyeniSifre.Size = new System.Drawing.Size(139, 24);
			this.txtyeniSifre.TabIndex = 5;
			this.txtyeniSifre.TextChanged += new System.EventHandler(this.txtyeniSifre_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(65, 173);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Şifre:";
			// 
			// txtmail
			// 
			this.txtmail.Location = new System.Drawing.Point(119, 83);
			this.txtmail.Name = "txtmail";
			this.txtmail.Size = new System.Drawing.Size(139, 24);
			this.txtmail.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(39, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "E-Posta:";
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(119, 38);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(139, 24);
			this.txtAd.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(81, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ad:";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// BilgileriGuncelle
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(303, 355);
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
		private System.Windows.Forms.TextBox txtyeniSifre;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtmail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.TextBox txtmevcutsifre;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label sifreT;
		private System.Windows.Forms.Timer timer1;
	}
}