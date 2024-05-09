namespace Restoran_Otomasyon.Paneller
{
	partial class KategoriESG
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KategoriESG));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.hiddenKategoriId = new System.Windows.Forms.TextBox();
			this.groupKategori = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboTur = new System.Windows.Forms.ComboBox();
			this.uzanti = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.txtad = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gridKategori = new System.Windows.Forms.DataGridView();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.ComboFiltre = new System.Windows.Forms.ComboBox();
			this.groupKategori.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridKategori)).BeginInit();
			this.SuspendLayout();
			// 
			// hiddenKategoriId
			// 
			this.hiddenKategoriId.Location = new System.Drawing.Point(458, -5);
			this.hiddenKategoriId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenKategoriId.Name = "hiddenKategoriId";
			this.hiddenKategoriId.Size = new System.Drawing.Size(49, 22);
			this.hiddenKategoriId.TabIndex = 48;
			this.hiddenKategoriId.Visible = false;
			// 
			// groupKategori
			// 
			this.groupKategori.Controls.Add(this.label3);
			this.groupKategori.Controls.Add(this.ComboFiltre);
			this.groupKategori.Controls.Add(this.label2);
			this.groupKategori.Controls.Add(this.comboTur);
			this.groupKategori.Controls.Add(this.uzanti);
			this.groupKategori.Controls.Add(this.button2);
			this.groupKategori.Controls.Add(this.button1);
			this.groupKategori.Controls.Add(this.txtad);
			this.groupKategori.Controls.Add(this.label1);
			this.groupKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupKategori.Location = new System.Drawing.Point(7, 7);
			this.groupKategori.Margin = new System.Windows.Forms.Padding(4);
			this.groupKategori.Name = "groupKategori";
			this.groupKategori.Padding = new System.Windows.Forms.Padding(4);
			this.groupKategori.Size = new System.Drawing.Size(393, 227);
			this.groupKategori.TabIndex = 46;
			this.groupKategori.TabStop = false;
			this.groupKategori.Text = "Kategori Bilgileri";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(42, 110);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 18);
			this.label2.TabIndex = 40;
			this.label2.Text = "Kategori Türü:";
			// 
			// comboTur
			// 
			this.comboTur.FormattingEnabled = true;
			this.comboTur.Items.AddRange(new object[] {
            "Masa",
            "Ürün",
            "Menü"});
			this.comboTur.Location = new System.Drawing.Point(170, 107);
			this.comboTur.Name = "comboTur";
			this.comboTur.Size = new System.Drawing.Size(175, 26);
			this.comboTur.TabIndex = 2;
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
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(210, 153);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(177, 66);
			this.button2.TabIndex = 4;
			this.button2.Text = "Sil";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			this.ımageList1.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(10, 153);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(177, 66);
			this.button1.TabIndex = 3;
			this.button1.Text = "Kaydet";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtad
			// 
			this.txtad.Location = new System.Drawing.Point(170, 63);
			this.txtad.Margin = new System.Windows.Forms.Padding(4);
			this.txtad.Name = "txtad";
			this.txtad.Size = new System.Drawing.Size(175, 24);
			this.txtad.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(125, 66);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 19;
			this.label1.Text = "Ad:";
			// 
			// gridKategori
			// 
			this.gridKategori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridKategori.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridKategori.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridKategori.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridKategori.Location = new System.Drawing.Point(402, 15);
			this.gridKategori.Margin = new System.Windows.Forms.Padding(4);
			this.gridKategori.Name = "gridKategori";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridKategori.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridKategori.RowHeadersWidth = 51;
			this.gridKategori.RowTemplate.Height = 24;
			this.gridKategori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridKategori.Size = new System.Drawing.Size(387, 219);
			this.gridKategori.TabIndex = 45;
			this.gridKategori.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKategori_CellClick);
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(63, 27);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 18);
			this.label3.TabIndex = 42;
			this.label3.Text = "Tür Filtresi:";
			// 
			// ComboFiltre
			// 
			this.ComboFiltre.FormattingEnabled = true;
			this.ComboFiltre.Items.AddRange(new object[] {
            "Tümü",
            "Masa",
            "Ürün",
            "Menü"});
			this.ComboFiltre.Location = new System.Drawing.Point(170, 24);
			this.ComboFiltre.Name = "ComboFiltre";
			this.ComboFiltre.Size = new System.Drawing.Size(175, 26);
			this.ComboFiltre.TabIndex = 41;
			this.ComboFiltre.SelectedIndexChanged += new System.EventHandler(this.ComboFiltre_SelectedIndexChanged);
			// 
			// KategoriESG
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(802, 239);
			this.Controls.Add(this.hiddenKategoriId);
			this.Controls.Add(this.groupKategori);
			this.Controls.Add(this.gridKategori);
			this.Name = "KategoriESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kategori İşlemleri";
			this.Load += new System.EventHandler(this.KategoriESG_Load);
			this.groupKategori.ResumeLayout(false);
			this.groupKategori.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridKategori)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox hiddenKategoriId;
		private System.Windows.Forms.GroupBox groupKategori;
		private System.Windows.Forms.Label uzanti;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtad;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView gridKategori;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboTur;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ComboFiltre;
	}
}