namespace Restoran_Otomasyon
{
	partial class VtBilgiGir
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtBilgiGir));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.UserAdi = new System.Windows.Forms.TextBox();
			this.port = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.svAdi = new System.Windows.Forms.TextBox();
			this.VtSifre = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DbAdi = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.baglantiDizesi = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this.UserAdi);
			this.groupBox1.Controls.Add(this.port);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.svAdi);
			this.groupBox1.Controls.Add(this.VtSifre);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.DbAdi);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(445, 413);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Veri Tabanı İçin Bİlgileri Giriniz";
			// 
			// UserAdi
			// 
			this.UserAdi.Location = new System.Drawing.Point(170, 208);
			this.UserAdi.Name = "UserAdi";
			this.UserAdi.Size = new System.Drawing.Size(263, 22);
			this.UserAdi.TabIndex = 4;
			this.UserAdi.Text = "root";
			// 
			// port
			// 
			this.port.Location = new System.Drawing.Point(170, 88);
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(263, 22);
			this.port.TabIndex = 2;
			this.port.Text = "3306";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(59, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server Adı:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(80, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Port No:";
			// 
			// svAdi
			// 
			this.svAdi.Location = new System.Drawing.Point(170, 28);
			this.svAdi.Name = "svAdi";
			this.svAdi.Size = new System.Drawing.Size(263, 22);
			this.svAdi.TabIndex = 1;
			this.svAdi.Text = "localhost";
			// 
			// VtSifre
			// 
			this.VtSifre.Location = new System.Drawing.Point(170, 268);
			this.VtSifre.Name = "VtSifre";
			this.VtSifre.Size = new System.Drawing.Size(263, 22);
			this.VtSifre.TabIndex = 5;
			this.VtSifre.Text = "123456789";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(99, 327);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(221, 81);
			this.button1.TabIndex = 6;
			this.button1.Text = "  Kaydet";
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
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(4, 271);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Veri Tabanı Şifresi";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(36, 151);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Databese Adı:";
			// 
			// DbAdi
			// 
			this.DbAdi.Location = new System.Drawing.Point(170, 148);
			this.DbAdi.Name = "DbAdi";
			this.DbAdi.Size = new System.Drawing.Size(263, 22);
			this.DbAdi.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(50, 211);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "User Bilgisi:";
			// 
			// baglantiDizesi
			// 
			this.baglantiDizesi.AutoSize = true;
			this.baglantiDizesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.baglantiDizesi.Location = new System.Drawing.Point(25, 46);
			this.baglantiDizesi.Name = "baglantiDizesi";
			this.baglantiDizesi.Size = new System.Drawing.Size(0, 22);
			this.baglantiDizesi.TabIndex = 16;
			// 
			// VtBilgiGir
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(474, 434);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.baglantiDizesi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "VtBilgiGir";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VtBilgiGir";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox UserAdi;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox svAdi;
		private System.Windows.Forms.TextBox VtSifre;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox DbAdi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label baglantiDizesi;
	}
}