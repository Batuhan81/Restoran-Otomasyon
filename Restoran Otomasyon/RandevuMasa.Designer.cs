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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.gridRandevular = new System.Windows.Forms.DataGridView();
			this.hiddenID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboOnay = new System.Windows.Forms.ComboBox();
			this.groupBaslangic.SuspendLayout();
			this.GroupBitis.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRandevular)).BeginInit();
			this.SuspendLayout();
			// 
			// Takvim
			// 
			this.Takvim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Takvim.Location = new System.Drawing.Point(9, 4);
			this.Takvim.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
			this.Takvim.MaxSelectionCount = 1;
			this.Takvim.Name = "Takvim";
			this.Takvim.TabIndex = 1;
			this.Takvim.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Takvim_DateChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Saat";
			// 
			// ComboSaat
			// 
			this.ComboSaat.FormattingEnabled = true;
			this.ComboSaat.Location = new System.Drawing.Point(99, 21);
			this.ComboSaat.Margin = new System.Windows.Forms.Padding(4);
			this.ComboSaat.Name = "ComboSaat";
			this.ComboSaat.Size = new System.Drawing.Size(150, 24);
			this.ComboSaat.TabIndex = 3;
			this.ComboSaat.SelectedIndexChanged += new System.EventHandler(this.ComboSaat_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Dakika";
			// 
			// ComboDakika
			// 
			this.ComboDakika.FormattingEnabled = true;
			this.ComboDakika.Location = new System.Drawing.Point(99, 53);
			this.ComboDakika.Margin = new System.Windows.Forms.Padding(4);
			this.ComboDakika.Name = "ComboDakika";
			this.ComboDakika.Size = new System.Drawing.Size(150, 24);
			this.ComboDakika.TabIndex = 5;
			this.ComboDakika.SelectedIndexChanged += new System.EventHandler(this.ComboDakika_SelectedIndexChanged);
			// 
			// bitisDakika
			// 
			this.bitisDakika.FormattingEnabled = true;
			this.bitisDakika.Location = new System.Drawing.Point(99, 50);
			this.bitisDakika.Margin = new System.Windows.Forms.Padding(4);
			this.bitisDakika.Name = "bitisDakika";
			this.bitisDakika.Size = new System.Drawing.Size(150, 24);
			this.bitisDakika.TabIndex = 9;
			this.bitisDakika.SelectedIndexChanged += new System.EventHandler(this.bitisDakika_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 52);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Dakika";
			// 
			// bitisSaat
			// 
			this.bitisSaat.FormattingEnabled = true;
			this.bitisSaat.Location = new System.Drawing.Point(99, 21);
			this.bitisSaat.Margin = new System.Windows.Forms.Padding(4);
			this.bitisSaat.Name = "bitisSaat";
			this.bitisSaat.Size = new System.Drawing.Size(150, 24);
			this.bitisSaat.TabIndex = 7;
			this.bitisSaat.SelectedIndexChanged += new System.EventHandler(this.bitisSaat_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 23);
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
			this.groupBaslangic.Location = new System.Drawing.Point(262, 4);
			this.groupBaslangic.Margin = new System.Windows.Forms.Padding(4);
			this.groupBaslangic.Name = "groupBaslangic";
			this.groupBaslangic.Padding = new System.Windows.Forms.Padding(4);
			this.groupBaslangic.Size = new System.Drawing.Size(264, 82);
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
			this.GroupBitis.Location = new System.Drawing.Point(262, 109);
			this.GroupBitis.Margin = new System.Windows.Forms.Padding(4);
			this.GroupBitis.Name = "GroupBitis";
			this.GroupBitis.Padding = new System.Windows.Forms.Padding(4);
			this.GroupBitis.Size = new System.Drawing.Size(264, 82);
			this.GroupBitis.TabIndex = 11;
			this.GroupBitis.TabStop = false;
			this.GroupBitis.Text = "Bitiş Saati";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(4, 202);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "Kişi Sayısı:";
			// 
			// txtkisiSayisi
			// 
			this.txtkisiSayisi.Location = new System.Drawing.Point(103, 199);
			this.txtkisiSayisi.Name = "txtkisiSayisi";
			this.txtkisiSayisi.Size = new System.Drawing.Size(149, 24);
			this.txtkisiSayisi.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label6.Location = new System.Drawing.Point(174, 231);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 20);
			this.label6.TabIndex = 13;
			this.label6.Text = "Talep:";
			// 
			// txttalep
			// 
			this.txttalep.Location = new System.Drawing.Point(4, 252);
			this.txttalep.Name = "txttalep";
			this.txttalep.Size = new System.Drawing.Size(387, 194);
			this.txttalep.TabIndex = 14;
			this.txttalep.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(397, 263);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 72);
			this.button1.TabIndex = 15;
			this.button1.Text = "Rezarvasyon Oluştur";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(397, 357);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 72);
			this.button2.TabIndex = 16;
			this.button2.Text = "Rezarvasyon Sil";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// gridRandevular
			// 
			this.gridRandevular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridRandevular.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.gridRandevular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridRandevular.DefaultCellStyle = dataGridViewCellStyle8;
			this.gridRandevular.Location = new System.Drawing.Point(533, 12);
			this.gridRandevular.Margin = new System.Windows.Forms.Padding(4);
			this.gridRandevular.Name = "gridRandevular";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridRandevular.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.gridRandevular.RowHeadersWidth = 51;
			this.gridRandevular.RowTemplate.Height = 24;
			this.gridRandevular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRandevular.Size = new System.Drawing.Size(535, 426);
			this.gridRandevular.TabIndex = 46;
			this.gridRandevular.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRandevular_CellClick);
			// 
			// hiddenID
			// 
			this.hiddenID.Location = new System.Drawing.Point(566, 11);
			this.hiddenID.Name = "hiddenID";
			this.hiddenID.Size = new System.Drawing.Size(149, 24);
			this.hiddenID.TabIndex = 47;
			this.hiddenID.Visible = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.Location = new System.Drawing.Point(259, 202);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 20);
			this.label7.TabIndex = 48;
			this.label7.Text = "Onay Durumu:";
			// 
			// comboOnay
			// 
			this.comboOnay.FormattingEnabled = true;
			this.comboOnay.Items.AddRange(new object[] {
            "Onay Bekleniyor",
            "Onaylandı",
            "Gerçekleşti",
            "İptal Edildi",
            "Onaylanmadı",
            "Gelmedi"});
			this.comboOnay.Location = new System.Drawing.Point(384, 198);
			this.comboOnay.Margin = new System.Windows.Forms.Padding(4);
			this.comboOnay.Name = "comboOnay";
			this.comboOnay.Size = new System.Drawing.Size(142, 26);
			this.comboOnay.TabIndex = 10;
			// 
			// RandevuMasa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1070, 450);
			this.Controls.Add(this.comboOnay);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.hiddenID);
			this.Controls.Add(this.gridRandevular);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txttalep);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtkisiSayisi);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.GroupBitis);
			this.Controls.Add(this.groupBaslangic);
			this.Controls.Add(this.Takvim);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RandevuMasa";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Masa Randevu";
			this.Load += new System.EventHandler(this.RandevuMasa_Load);
			this.groupBaslangic.ResumeLayout(false);
			this.groupBaslangic.PerformLayout();
			this.GroupBitis.ResumeLayout(false);
			this.GroupBitis.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRandevular)).EndInit();
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
		private System.Windows.Forms.DataGridView gridRandevular;
		private System.Windows.Forms.TextBox hiddenID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboOnay;
	}
}