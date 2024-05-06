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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuMasa));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			this.Takvim = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.ComboSaat = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ComboDakika = new System.Windows.Forms.ComboBox();
			this.bitisDakika = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CombobitisSaat = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBaslangic = new System.Windows.Forms.GroupBox();
			this.GroupBitis = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtkisiSayisi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txttalep = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.gridRandevular = new System.Windows.Forms.DataGridView();
			this.hiddenID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboOnay = new System.Windows.Forms.ComboBox();
			this.PanelMusteri = new System.Windows.Forms.Panel();
			this.gridMusteriler = new System.Windows.Forms.DataGridView();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAd = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.maskedTel = new System.Windows.Forms.MaskedTextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.gridKayitsiz = new System.Windows.Forms.DataGridView();
			this.txthiddenId = new System.Windows.Forms.TextBox();
			this.groupBaslangic.SuspendLayout();
			this.GroupBitis.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRandevular)).BeginInit();
			this.PanelMusteri.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridKayitsiz)).BeginInit();
			this.SuspendLayout();
			// 
			// Takvim
			// 
			this.Takvim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Takvim.Location = new System.Drawing.Point(10, 4);
			this.Takvim.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
			this.Takvim.MaxSelectionCount = 1;
			this.Takvim.Name = "Takvim";
			this.Takvim.TabIndex = 1;
			this.Takvim.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Takvim_DateChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Saat";
			// 
			// ComboSaat
			// 
			this.ComboSaat.FormattingEnabled = true;
			this.ComboSaat.Location = new System.Drawing.Point(109, 23);
			this.ComboSaat.Margin = new System.Windows.Forms.Padding(4);
			this.ComboSaat.Name = "ComboSaat";
			this.ComboSaat.Size = new System.Drawing.Size(165, 24);
			this.ComboSaat.TabIndex = 3;
			this.ComboSaat.SelectedIndexChanged += new System.EventHandler(this.ComboSaat_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 62);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Dakika";
			// 
			// ComboDakika
			// 
			this.ComboDakika.FormattingEnabled = true;
			this.ComboDakika.Location = new System.Drawing.Point(109, 59);
			this.ComboDakika.Margin = new System.Windows.Forms.Padding(4);
			this.ComboDakika.Name = "ComboDakika";
			this.ComboDakika.Size = new System.Drawing.Size(165, 24);
			this.ComboDakika.TabIndex = 5;
			this.ComboDakika.SelectedIndexChanged += new System.EventHandler(this.ComboDakika_SelectedIndexChanged);
			// 
			// bitisDakika
			// 
			this.bitisDakika.FormattingEnabled = true;
			this.bitisDakika.Location = new System.Drawing.Point(109, 56);
			this.bitisDakika.Margin = new System.Windows.Forms.Padding(4);
			this.bitisDakika.Name = "bitisDakika";
			this.bitisDakika.Size = new System.Drawing.Size(165, 24);
			this.bitisDakika.TabIndex = 9;
			this.bitisDakika.SelectedIndexChanged += new System.EventHandler(this.bitisDakika_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 58);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Dakika";
			// 
			// CombobitisSaat
			// 
			this.CombobitisSaat.FormattingEnabled = true;
			this.CombobitisSaat.Location = new System.Drawing.Point(109, 23);
			this.CombobitisSaat.Margin = new System.Windows.Forms.Padding(4);
			this.CombobitisSaat.Name = "CombobitisSaat";
			this.CombobitisSaat.Size = new System.Drawing.Size(165, 24);
			this.CombobitisSaat.TabIndex = 7;
			this.CombobitisSaat.SelectedIndexChanged += new System.EventHandler(this.bitisSaat_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(45, 26);
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
			this.groupBaslangic.Location = new System.Drawing.Point(282, 5);
			this.groupBaslangic.Margin = new System.Windows.Forms.Padding(4);
			this.groupBaslangic.Name = "groupBaslangic";
			this.groupBaslangic.Padding = new System.Windows.Forms.Padding(4);
			this.groupBaslangic.Size = new System.Drawing.Size(290, 91);
			this.groupBaslangic.TabIndex = 10;
			this.groupBaslangic.TabStop = false;
			this.groupBaslangic.Text = "Başlangıç Saati";
			// 
			// GroupBitis
			// 
			this.GroupBitis.Controls.Add(this.bitisDakika);
			this.GroupBitis.Controls.Add(this.label4);
			this.GroupBitis.Controls.Add(this.CombobitisSaat);
			this.GroupBitis.Controls.Add(this.label3);
			this.GroupBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.GroupBitis.Location = new System.Drawing.Point(282, 122);
			this.GroupBitis.Margin = new System.Windows.Forms.Padding(4);
			this.GroupBitis.Name = "GroupBitis";
			this.GroupBitis.Padding = new System.Windows.Forms.Padding(4);
			this.GroupBitis.Size = new System.Drawing.Size(290, 91);
			this.GroupBitis.TabIndex = 11;
			this.GroupBitis.TabStop = false;
			this.GroupBitis.Text = "Bitiş Saati";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(2, 221);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "Kişi Sayısı:";
			// 
			// txtkisiSayisi
			// 
			this.txtkisiSayisi.Location = new System.Drawing.Point(111, 218);
			this.txtkisiSayisi.Name = "txtkisiSayisi";
			this.txtkisiSayisi.Size = new System.Drawing.Size(164, 27);
			this.txtkisiSayisi.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label6.Location = new System.Drawing.Point(191, 257);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 20);
			this.label6.TabIndex = 13;
			this.label6.Text = "Talep:";
			// 
			// txttalep
			// 
			this.txttalep.Location = new System.Drawing.Point(4, 280);
			this.txttalep.Name = "txttalep";
			this.txttalep.Size = new System.Drawing.Size(382, 215);
			this.txttalep.TabIndex = 14;
			this.txttalep.Text = "";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Rezervasyon.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(391, 302);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 80);
			this.button1.TabIndex = 15;
			this.button1.Text = "Rezarvasyon Oluştur";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Rezervasyon.png");
			this.ımageList1.Images.SetKeyName(1, "iptal.png");
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.ImageKey = "iptal.png";
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(391, 407);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(181, 80);
			this.button2.TabIndex = 16;
			this.button2.Text = "Rezarvasyon Sil";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// gridRandevular
			// 
			this.gridRandevular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridRandevular.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridRandevular.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
			this.gridRandevular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridRandevular.DefaultCellStyle = dataGridViewCellStyle20;
			this.gridRandevular.Location = new System.Drawing.Point(580, 13);
			this.gridRandevular.Margin = new System.Windows.Forms.Padding(4);
			this.gridRandevular.Name = "gridRandevular";
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridRandevular.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
			this.gridRandevular.RowHeadersWidth = 51;
			this.gridRandevular.RowTemplate.Height = 24;
			this.gridRandevular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRandevular.Size = new System.Drawing.Size(588, 491);
			this.gridRandevular.TabIndex = 46;
			this.gridRandevular.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRandevular_CellClick);
			// 
			// hiddenID
			// 
			this.hiddenID.Location = new System.Drawing.Point(802, 26);
			this.hiddenID.Name = "hiddenID";
			this.hiddenID.Size = new System.Drawing.Size(164, 27);
			this.hiddenID.TabIndex = 47;
			this.hiddenID.Visible = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.Location = new System.Drawing.Point(278, 225);
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
			this.comboOnay.Location = new System.Drawing.Point(416, 221);
			this.comboOnay.Margin = new System.Windows.Forms.Padding(4);
			this.comboOnay.Name = "comboOnay";
			this.comboOnay.Size = new System.Drawing.Size(156, 28);
			this.comboOnay.TabIndex = 10;
			// 
			// PanelMusteri
			// 
			this.PanelMusteri.Controls.Add(this.gridMusteriler);
			this.PanelMusteri.Controls.Add(this.gridKayitsiz);
			this.PanelMusteri.Controls.Add(this.button4);
			this.PanelMusteri.Controls.Add(this.maskedTel);
			this.PanelMusteri.Controls.Add(this.label9);
			this.PanelMusteri.Controls.Add(this.txtAd);
			this.PanelMusteri.Controls.Add(this.label8);
			this.PanelMusteri.Controls.Add(this.button3);
			this.PanelMusteri.Location = new System.Drawing.Point(580, 13);
			this.PanelMusteri.Name = "PanelMusteri";
			this.PanelMusteri.Size = new System.Drawing.Size(588, 491);
			this.PanelMusteri.TabIndex = 49;
			this.PanelMusteri.Visible = false;
			// 
			// gridMusteriler
			// 
			this.gridMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridMusteriler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
			this.gridMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridMusteriler.DefaultCellStyle = dataGridViewCellStyle23;
			this.gridMusteriler.Location = new System.Drawing.Point(0, 2);
			this.gridMusteriler.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.gridMusteriler.Name = "gridMusteriler";
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMusteriler.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
			this.gridMusteriler.RowHeadersWidth = 51;
			this.gridMusteriler.RowTemplate.Height = 24;
			this.gridMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridMusteriler.Size = new System.Drawing.Size(588, 449);
			this.gridMusteriler.TabIndex = 50;
			this.gridMusteriler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMusteriler_CellClick);
			this.gridMusteriler.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridMusteriler_MouseClick);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(416, 257);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(132, 24);
			this.checkBox1.TabIndex = 50;
			this.checkBox1.Text = "Müşteri Şeç";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.SkyBlue;
			this.button3.Location = new System.Drawing.Point(191, 458);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(255, 33);
			this.button3.TabIndex = 51;
			this.button3.Text = "Müşteri Bilgisi Ekle";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(104, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 20);
			this.label8.TabIndex = 52;
			this.label8.Text = "Ad:";
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(147, 12);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(141, 27);
			this.txtAd.TabIndex = 53;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(64, 51);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 20);
			this.label9.TabIndex = 54;
			this.label9.Text = "Telefon:";
			// 
			// maskedTel
			// 
			this.maskedTel.Location = new System.Drawing.Point(147, 51);
			this.maskedTel.Mask = "(999) 000-0000";
			this.maskedTel.Name = "maskedTel";
			this.maskedTel.Size = new System.Drawing.Size(141, 27);
			this.maskedTel.TabIndex = 55;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.SkyBlue;
			this.button4.Location = new System.Drawing.Point(312, 9);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(107, 74);
			this.button4.TabIndex = 56;
			this.button4.Text = "Kaydet";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// gridKayitsiz
			// 
			this.gridKayitsiz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridKayitsiz.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridKayitsiz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
			this.gridKayitsiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridKayitsiz.DefaultCellStyle = dataGridViewCellStyle26;
			this.gridKayitsiz.Location = new System.Drawing.Point(0, 92);
			this.gridKayitsiz.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.gridKayitsiz.Name = "gridKayitsiz";
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridKayitsiz.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
			this.gridKayitsiz.RowHeadersWidth = 51;
			this.gridKayitsiz.RowTemplate.Height = 24;
			this.gridKayitsiz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridKayitsiz.Size = new System.Drawing.Size(588, 359);
			this.gridKayitsiz.TabIndex = 57;
			this.gridKayitsiz.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKayitsiz_CellClick);
			// 
			// txthiddenId
			// 
			this.txthiddenId.Location = new System.Drawing.Point(579, -20);
			this.txthiddenId.Name = "txthiddenId";
			this.txthiddenId.Size = new System.Drawing.Size(100, 27);
			this.txthiddenId.TabIndex = 51;
			this.txthiddenId.Visible = false;
			// 
			// RandevuMasa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1176, 509);
			this.Controls.Add(this.txthiddenId);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.PanelMusteri);
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
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
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
			this.PanelMusteri.ResumeLayout(false);
			this.PanelMusteri.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridKayitsiz)).EndInit();
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
		private System.Windows.Forms.ComboBox CombobitisSaat;
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
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.Panel PanelMusteri;
		private System.Windows.Forms.DataGridView gridMusteriler;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.MaskedTextBox maskedTel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtAd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridView gridKayitsiz;
		private System.Windows.Forms.TextBox txthiddenId;
	}
}