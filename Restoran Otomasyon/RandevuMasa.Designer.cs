namespace Restoran_Otomasyon
{
	partial class RandevuMasa
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
			this.Takvim = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.ComboSaat = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ComboDakika = new System.Windows.Forms.ComboBox();
			this.bitisDakika = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.bitisSaat = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBaslangic = new System.Windows.Forms.GroupBox();
			this.GroupBitis = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtkisiSayisi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txttalep = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBaslangic.SuspendLayout();
			this.GroupBitis.SuspendLayout();
			this.SuspendLayout();
			// 
			// Takvim
			// 
			this.Takvim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Takvim.Location = new System.Drawing.Point(9, 5);
			this.Takvim.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
			this.Takvim.MaxSelectionCount = 1;
			this.Takvim.Name = "Takvim";
			this.Takvim.TabIndex = 1;
			this.Takvim.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Takvim_DateChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Saat";
			// 
			// ComboSaat
			// 
			this.ComboSaat.FormattingEnabled = true;
			this.ComboSaat.Location = new System.Drawing.Point(99, 23);
			this.ComboSaat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ComboSaat.Name = "ComboSaat";
			this.ComboSaat.Size = new System.Drawing.Size(150, 24);
			this.ComboSaat.TabIndex = 3;
			this.ComboSaat.SelectedIndexChanged += new System.EventHandler(this.ComboSaat_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 62);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Dakika";
			// 
			// ComboDakika
			// 
			this.ComboDakika.FormattingEnabled = true;
			this.ComboDakika.Location = new System.Drawing.Point(99, 59);
			this.ComboDakika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ComboDakika.Name = "ComboDakika";
			this.ComboDakika.Size = new System.Drawing.Size(150, 24);
			this.ComboDakika.TabIndex = 5;
			this.ComboDakika.SelectedIndexChanged += new System.EventHandler(this.ComboDakika_SelectedIndexChanged);
			// 
			// bitisDakika
			// 
			this.bitisDakika.FormattingEnabled = true;
			this.bitisDakika.Location = new System.Drawing.Point(99, 55);
			this.bitisDakika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.bitisDakika.Name = "bitisDakika";
			this.bitisDakika.Size = new System.Drawing.Size(150, 24);
			this.bitisDakika.TabIndex = 9;
			this.bitisDakika.SelectedIndexChanged += new System.EventHandler(this.bitisDakika_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 58);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Dakika";
			// 
			// bitisSaat
			// 
			this.bitisSaat.FormattingEnabled = true;
			this.bitisSaat.Location = new System.Drawing.Point(99, 23);
			this.bitisSaat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.bitisSaat.Name = "bitisSaat";
			this.bitisSaat.Size = new System.Drawing.Size(150, 24);
			this.bitisSaat.TabIndex = 7;
			this.bitisSaat.SelectedIndexChanged += new System.EventHandler(this.bitisSaat_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 26);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Saat";
			// 
			// groupBaslangic
			// 
			this.groupBaslangic.Controls.Add(this.ComboDakika);
			this.groupBaslangic.Controls.Add(this.label1);
			this.groupBaslangic.Controls.Add(this.ComboSaat);
			this.groupBaslangic.Controls.Add(this.label2);
			this.groupBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBaslangic.Location = new System.Drawing.Point(295, 5);
			this.groupBaslangic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBaslangic.Name = "groupBaslangic";
			this.groupBaslangic.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBaslangic.Size = new System.Drawing.Size(264, 91);
			this.groupBaslangic.TabIndex = 10;
			this.groupBaslangic.TabStop = false;
			this.groupBaslangic.Text = "Başlangıç Saati";
			// 
			// GroupBitis
			// 
			this.GroupBitis.Controls.Add(this.bitisDakika);
			this.GroupBitis.Controls.Add(this.label4);
			this.GroupBitis.Controls.Add(this.bitisSaat);
			this.GroupBitis.Controls.Add(this.label3);
			this.GroupBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.GroupBitis.Location = new System.Drawing.Point(295, 121);
			this.GroupBitis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBitis.Name = "GroupBitis";
			this.GroupBitis.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBitis.Size = new System.Drawing.Size(264, 91);
			this.GroupBitis.TabIndex = 11;
			this.GroupBitis.TabStop = false;
			this.GroupBitis.Text = "Bitiş Saati";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(183, 231);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "Kişi Sayısı:";
			// 
			// txtkisiSayisi
			// 
			this.txtkisiSayisi.Location = new System.Drawing.Point(282, 228);
			this.txtkisiSayisi.Name = "txtkisiSayisi";
			this.txtkisiSayisi.Size = new System.Drawing.Size(149, 27);
			this.txtkisiSayisi.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(86, 247);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 20);
			this.label6.TabIndex = 13;
			this.label6.Text = "Talep:";
			// 
			// txttalep
			// 
			this.txttalep.Location = new System.Drawing.Point(4, 280);
			this.txttalep.Name = "txttalep";
			this.txttalep.Size = new System.Drawing.Size(387, 215);
			this.txttalep.TabIndex = 14;
			this.txttalep.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(431, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 80);
			this.button1.TabIndex = 15;
			this.button1.Text = "Rezarvasyon Oluştur";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(431, 399);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 80);
			this.button2.TabIndex = 16;
			this.button2.Text = "Rezarvasyon Sil";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// RandevuMasa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 500);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txttalep);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtkisiSayisi);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.GroupBitis);
			this.Controls.Add(this.groupBaslangic);
			this.Controls.Add(this.Takvim);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "RandevuMasa";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RandevuMasa";
			this.Load += new System.EventHandler(this.RandevuMasa_Load);
			this.groupBaslangic.ResumeLayout(false);
			this.groupBaslangic.PerformLayout();
			this.GroupBitis.ResumeLayout(false);
			this.GroupBitis.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MonthCalendar Takvim;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ComboSaat;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox ComboDakika;
		private System.Windows.Forms.ComboBox bitisDakika;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox bitisSaat;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBaslangic;
		private System.Windows.Forms.GroupBox GroupBitis;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtkisiSayisi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox txttalep;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}