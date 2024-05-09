namespace Restoran_Otomasyon.Paneller
{
	partial class MalzemeESG
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MalzemeESG));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.hiddenTedarikciId = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
			this.hiddenMalzemeId = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.uzanti = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.txtfiyat = new System.Windows.Forms.MaskedTextBox();
			this.txtad = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupMalzeme = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.StokGir = new System.Windows.Forms.Button();
			this.txtmax = new System.Windows.Forms.TextBox();
			this.txtmin = new System.Windows.Forms.TextBox();
			this.txtstok = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboOlcu = new System.Windows.Forms.ComboBox();
			this.comboTedarik = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gridMalzeme = new System.Windows.Forms.DataGridView();
			this.hiddenStokId = new System.Windows.Forms.TextBox();
			this.TedarikciPaneli = new System.Windows.Forms.Panel();
			this.groupMalzemeFiltre = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.ComboTedarikciAra = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtAdAra = new System.Windows.Forms.TextBox();
			this.olcuAra = new System.Windows.Forms.ComboBox();
			this.groupMalzeme.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMalzeme)).BeginInit();
			this.TedarikciPaneli.SuspendLayout();
			this.groupMalzemeFiltre.SuspendLayout();
			this.SuspendLayout();
			// 
			// hiddenTedarikciId
			// 
			this.hiddenTedarikciId.Location = new System.Drawing.Point(4, 27);
			this.hiddenTedarikciId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenTedarikciId.Name = "hiddenTedarikciId";
			this.hiddenTedarikciId.Size = new System.Drawing.Size(49, 22);
			this.hiddenTedarikciId.TabIndex = 43;
			this.hiddenTedarikciId.Visible = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList2;
			this.button1.Location = new System.Drawing.Point(8, 586);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(177, 66);
			this.button1.TabIndex = 6;
			this.button1.Text = "Kaydet";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ımageList2
			// 
			this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
			this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList2.Images.SetKeyName(0, "Ekle2.png");
			this.ımageList2.Images.SetKeyName(1, "Kaydet.png");
			this.ımageList2.Images.SetKeyName(2, "Resim Ekle2.png");
			this.ımageList2.Images.SetKeyName(3, "Sil butonu - Kopya.png");
			this.ımageList2.Images.SetKeyName(4, "Stok.png");
			// 
			// hiddenMalzemeId
			// 
			this.hiddenMalzemeId.Location = new System.Drawing.Point(4, 62);
			this.hiddenMalzemeId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenMalzemeId.Name = "hiddenMalzemeId";
			this.hiddenMalzemeId.Size = new System.Drawing.Size(49, 22);
			this.hiddenMalzemeId.TabIndex = 44;
			this.hiddenMalzemeId.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			// 
			// uzanti
			// 
			this.uzanti.AutoSize = true;
			this.uzanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.uzanti.Location = new System.Drawing.Point(363, 730);
			this.uzanti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.uzanti.Name = "uzanti";
			this.uzanti.Size = new System.Drawing.Size(0, 16);
			this.uzanti.TabIndex = 38;
			this.uzanti.Visible = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.ImageKey = "Sil butonu - Kopya.png";
			this.button2.ImageList = this.ımageList2;
			this.button2.Location = new System.Drawing.Point(208, 586);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(177, 66);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sil";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtfiyat
			// 
			this.txtfiyat.Location = new System.Drawing.Point(133, 198);
			this.txtfiyat.Margin = new System.Windows.Forms.Padding(4);
			this.txtfiyat.Name = "txtfiyat";
			this.txtfiyat.Size = new System.Drawing.Size(175, 27);
			this.txtfiyat.TabIndex = 3;
			this.txtfiyat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfiyat_KeyDown);
			this.txtfiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfiyat_KeyPress);
			this.txtfiyat.Leave += new System.EventHandler(this.txtfiyat_Leave);
			// 
			// txtad
			// 
			this.txtad.Location = new System.Drawing.Point(133, 38);
			this.txtad.Margin = new System.Windows.Forms.Padding(4);
			this.txtad.Name = "txtad";
			this.txtad.Size = new System.Drawing.Size(175, 27);
			this.txtad.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(72, 203);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 16);
			this.label5.TabIndex = 23;
			this.label5.Text = "Fiyat:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(32, 123);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 16);
			this.label3.TabIndex = 21;
			this.label3.Text = "Ölçü Birimi:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(87, 43);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 19;
			this.label1.Text = "Ad:";
			// 
			// groupMalzeme
			// 
			this.groupMalzeme.Controls.Add(this.button5);
			this.groupMalzeme.Controls.Add(this.StokGir);
			this.groupMalzeme.Controls.Add(this.txtmax);
			this.groupMalzeme.Controls.Add(this.txtmin);
			this.groupMalzeme.Controls.Add(this.txtstok);
			this.groupMalzeme.Controls.Add(this.label7);
			this.groupMalzeme.Controls.Add(this.comboOlcu);
			this.groupMalzeme.Controls.Add(this.comboTedarik);
			this.groupMalzeme.Controls.Add(this.label2);
			this.groupMalzeme.Controls.Add(this.label6);
			this.groupMalzeme.Controls.Add(this.label4);
			this.groupMalzeme.Controls.Add(this.uzanti);
			this.groupMalzeme.Controls.Add(this.button2);
			this.groupMalzeme.Controls.Add(this.button1);
			this.groupMalzeme.Controls.Add(this.txtfiyat);
			this.groupMalzeme.Controls.Add(this.txtad);
			this.groupMalzeme.Controls.Add(this.label5);
			this.groupMalzeme.Controls.Add(this.label3);
			this.groupMalzeme.Controls.Add(this.label1);
			this.groupMalzeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupMalzeme.Location = new System.Drawing.Point(13, 13);
			this.groupMalzeme.Margin = new System.Windows.Forms.Padding(4);
			this.groupMalzeme.Name = "groupMalzeme";
			this.groupMalzeme.Padding = new System.Windows.Forms.Padding(4);
			this.groupMalzeme.Size = new System.Drawing.Size(393, 787);
			this.groupMalzeme.TabIndex = 42;
			this.groupMalzeme.TabStop = false;
			this.groupMalzeme.Text = "Malzeme Bilgileri";
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.SystemColors.Control;
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button5.ImageKey = "Ekle2.png";
			this.button5.ImageList = this.ımageList1;
			this.button5.Location = new System.Drawing.Point(315, 514);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(33, 28);
			this.button5.TabIndex = 46;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Ekle2.png");
			// 
			// StokGir
			// 
			this.StokGir.BackColor = System.Drawing.Color.SkyBlue;
			this.StokGir.ImageKey = "Stok.png";
			this.StokGir.ImageList = this.ımageList2;
			this.StokGir.Location = new System.Drawing.Point(103, 680);
			this.StokGir.Margin = new System.Windows.Forms.Padding(4);
			this.StokGir.Name = "StokGir";
			this.StokGir.Size = new System.Drawing.Size(177, 66);
			this.StokGir.TabIndex = 8;
			this.StokGir.Text = "Stok Girdi";
			this.StokGir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.StokGir.UseVisualStyleBackColor = false;
			this.StokGir.Click += new System.EventHandler(this.StokGir_Click);
			// 
			// txtmax
			// 
			this.txtmax.Location = new System.Drawing.Point(133, 435);
			this.txtmax.Name = "txtmax";
			this.txtmax.Size = new System.Drawing.Size(175, 27);
			this.txtmax.TabIndex = 5;
			this.txtmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtmax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmax_KeyDown);
			this.txtmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmax_KeyPress);
			this.txtmax.Leave += new System.EventHandler(this.txtmax_Leave);
			// 
			// txtmin
			// 
			this.txtmin.Location = new System.Drawing.Point(133, 356);
			this.txtmin.Name = "txtmin";
			this.txtmin.Size = new System.Drawing.Size(175, 27);
			this.txtmin.TabIndex = 4;
			this.txtmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmin_KeyDown);
			this.txtmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmin_KeyPress);
			this.txtmin.Leave += new System.EventHandler(this.txtmin_Leave);
			// 
			// txtstok
			// 
			this.txtstok.Location = new System.Drawing.Point(133, 277);
			this.txtstok.Name = "txtstok";
			this.txtstok.ReadOnly = true;
			this.txtstok.Size = new System.Drawing.Size(175, 27);
			this.txtstok.TabIndex = 48;
			this.txtstok.Text = "0";
			this.txtstok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtstok.Leave += new System.EventHandler(this.txtstok_Leave);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.Location = new System.Drawing.Point(75, 282);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 16);
			this.label7.TabIndex = 47;
			this.label7.Text = "Stok:";
			// 
			// comboOlcu
			// 
			this.comboOlcu.FormattingEnabled = true;
			this.comboOlcu.Items.AddRange(new object[] {
            "Kg",
            "Litre",
            "Adet"});
			this.comboOlcu.Location = new System.Drawing.Point(133, 117);
			this.comboOlcu.Name = "comboOlcu";
			this.comboOlcu.Size = new System.Drawing.Size(175, 28);
			this.comboOlcu.TabIndex = 2;
			this.comboOlcu.SelectedIndexChanged += new System.EventHandler(this.comboOlcu_SelectedIndexChanged);
			// 
			// comboTedarik
			// 
			this.comboTedarik.FormattingEnabled = true;
			this.comboTedarik.Location = new System.Drawing.Point(133, 514);
			this.comboTedarik.Name = "comboTedarik";
			this.comboTedarik.Size = new System.Drawing.Size(175, 28);
			this.comboTedarik.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(40, 520);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 16);
			this.label2.TabIndex = 44;
			this.label2.Text = "Tedarikçi:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label6.Location = new System.Drawing.Point(43, 440);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 16);
			this.label6.TabIndex = 42;
			this.label6.Text = "Max Stok:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(47, 361);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 16);
			this.label4.TabIndex = 40;
			this.label4.Text = "Min Stok:";
			// 
			// gridMalzeme
			// 
			this.gridMalzeme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridMalzeme.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMalzeme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridMalzeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridMalzeme.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridMalzeme.Location = new System.Drawing.Point(414, 88);
			this.gridMalzeme.Margin = new System.Windows.Forms.Padding(4);
			this.gridMalzeme.Name = "gridMalzeme";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMalzeme.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridMalzeme.RowHeadersWidth = 51;
			this.gridMalzeme.RowTemplate.Height = 24;
			this.gridMalzeme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridMalzeme.Size = new System.Drawing.Size(1111, 712);
			this.gridMalzeme.TabIndex = 41;
			this.gridMalzeme.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMalzeme_CellClick);
			this.gridMalzeme.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridMalzeme_CellFormatting);
			// 
			// hiddenStokId
			// 
			this.hiddenStokId.Location = new System.Drawing.Point(4, 101);
			this.hiddenStokId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenStokId.Name = "hiddenStokId";
			this.hiddenStokId.Size = new System.Drawing.Size(49, 22);
			this.hiddenStokId.TabIndex = 45;
			this.hiddenStokId.Visible = false;
			// 
			// TedarikciPaneli
			// 
			this.TedarikciPaneli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.TedarikciPaneli.Controls.Add(this.hiddenMalzemeId);
			this.TedarikciPaneli.Controls.Add(this.hiddenStokId);
			this.TedarikciPaneli.Controls.Add(this.hiddenTedarikciId);
			this.TedarikciPaneli.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.TedarikciPaneli.Location = new System.Drawing.Point(423, 109);
			this.TedarikciPaneli.Name = "TedarikciPaneli";
			this.TedarikciPaneli.Size = new System.Drawing.Size(1040, 472);
			this.TedarikciPaneli.TabIndex = 46;
			this.TedarikciPaneli.Visible = false;
			// 
			// groupMalzemeFiltre
			// 
			this.groupMalzemeFiltre.Controls.Add(this.olcuAra);
			this.groupMalzemeFiltre.Controls.Add(this.button6);
			this.groupMalzemeFiltre.Controls.Add(this.ComboTedarikciAra);
			this.groupMalzemeFiltre.Controls.Add(this.label14);
			this.groupMalzemeFiltre.Controls.Add(this.label12);
			this.groupMalzemeFiltre.Controls.Add(this.label11);
			this.groupMalzemeFiltre.Controls.Add(this.txtAdAra);
			this.groupMalzemeFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupMalzemeFiltre.Location = new System.Drawing.Point(413, 13);
			this.groupMalzemeFiltre.Name = "groupMalzemeFiltre";
			this.groupMalzemeFiltre.Size = new System.Drawing.Size(1112, 68);
			this.groupMalzemeFiltre.TabIndex = 47;
			this.groupMalzemeFiltre.TabStop = false;
			this.groupMalzemeFiltre.Text = "Filtre Seçenekleri";
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.SkyBlue;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button6.Location = new System.Drawing.Point(1003, 24);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(84, 35);
			this.button6.TabIndex = 44;
			this.button6.Text = "Kaldır";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// ComboTedarikciAra
			// 
			this.ComboTedarikciAra.FormattingEnabled = true;
			this.ComboTedarikciAra.Items.AddRange(new object[] {
            "Kadın",
            "Erkek"});
			this.ComboTedarikciAra.Location = new System.Drawing.Point(776, 31);
			this.ComboTedarikciAra.Margin = new System.Windows.Forms.Padding(4);
			this.ComboTedarikciAra.Name = "ComboTedarikciAra";
			this.ComboTedarikciAra.Size = new System.Drawing.Size(125, 30);
			this.ComboTedarikciAra.TabIndex = 42;
			this.ComboTedarikciAra.SelectedIndexChanged += new System.EventHandler(this.ComboTedarikciAra_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label14.Location = new System.Drawing.Point(686, 37);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(82, 18);
			this.label14.TabIndex = 43;
			this.label14.Text = "Tedarikçi:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(375, 35);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(57, 22);
			this.label12.TabIndex = 3;
			this.label12.Text = "Ölçü:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(54, 35);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 22);
			this.label11.TabIndex = 1;
			this.label11.Text = "Ad:";
			// 
			// txtAdAra
			// 
			this.txtAdAra.Location = new System.Drawing.Point(100, 32);
			this.txtAdAra.Name = "txtAdAra";
			this.txtAdAra.Size = new System.Drawing.Size(144, 28);
			this.txtAdAra.TabIndex = 0;
			this.txtAdAra.TextChanged += new System.EventHandler(this.txtAdAra_TextChanged);
			// 
			// olcuAra
			// 
			this.olcuAra.FormattingEnabled = true;
			this.olcuAra.Items.AddRange(new object[] {
            "Kg",
            "Litre",
            "Adet"});
			this.olcuAra.Location = new System.Drawing.Point(439, 31);
			this.olcuAra.Margin = new System.Windows.Forms.Padding(4);
			this.olcuAra.Name = "olcuAra";
			this.olcuAra.Size = new System.Drawing.Size(125, 30);
			this.olcuAra.TabIndex = 45;
			this.olcuAra.SelectedIndexChanged += new System.EventHandler(this.olcuAra_SelectedIndexChanged);
			// 
			// MalzemeESG
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1810, 863);
			this.Controls.Add(this.groupMalzemeFiltre);
			this.Controls.Add(this.TedarikciPaneli);
			this.Controls.Add(this.groupMalzeme);
			this.Controls.Add(this.gridMalzeme);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "MalzemeESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Malzeme Yönetimi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MalzemeESG_Load);
			this.groupMalzeme.ResumeLayout(false);
			this.groupMalzeme.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMalzeme)).EndInit();
			this.TedarikciPaneli.ResumeLayout(false);
			this.TedarikciPaneli.PerformLayout();
			this.groupMalzemeFiltre.ResumeLayout(false);
			this.groupMalzemeFiltre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.TextBox hiddenTedarikciId;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox hiddenMalzemeId;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label uzanti;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.MaskedTextBox txtfiyat;
		private System.Windows.Forms.TextBox txtad;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupMalzeme;
		private System.Windows.Forms.DataGridView gridMalzeme;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboTedarik;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboOlcu;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtstok;
		private System.Windows.Forms.TextBox txtmax;
		private System.Windows.Forms.TextBox txtmin;
		private System.Windows.Forms.TextBox hiddenStokId;
		private System.Windows.Forms.Button StokGir;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.Panel TedarikciPaneli;
		private System.Windows.Forms.ImageList ımageList2;
		private System.Windows.Forms.GroupBox groupMalzemeFiltre;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ComboBox ComboTedarikciAra;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAdAra;
		private System.Windows.Forms.ComboBox olcuAra;
	}
}