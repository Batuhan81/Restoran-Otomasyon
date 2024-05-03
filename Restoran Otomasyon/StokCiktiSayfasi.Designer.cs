namespace Restoran_Otomasyon.Paneller
{
	partial class StokCiktiSayfasi
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokCiktiSayfasi));
			this.gridMalzemeler = new System.Windows.Forms.DataGridView();
			this.ComboNeden = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtmiktar = new System.Windows.Forms.TextBox();
			this.BtnCikti = new System.Windows.Forms.Button();
			this.HiddenStokID = new System.Windows.Forms.TextBox();
			this.HiddenMalzemeID = new System.Windows.Forms.TextBox();
			this.hiddenTedarikciID = new System.Windows.Forms.TextBox();
			this.HiddenCiktiID = new System.Windows.Forms.TextBox();
			this.txtstok = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupCikti = new System.Windows.Forms.GroupBox();
			this.gridCikti = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridMalzemeler)).BeginInit();
			this.groupCikti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCikti)).BeginInit();
			this.SuspendLayout();
			// 
			// gridMalzemeler
			// 
			this.gridMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridMalzemeler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMalzemeler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridMalzemeler.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridMalzemeler.Location = new System.Drawing.Point(13, 35);
			this.gridMalzemeler.Margin = new System.Windows.Forms.Padding(4);
			this.gridMalzemeler.Name = "gridMalzemeler";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMalzemeler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridMalzemeler.RowHeadersWidth = 51;
			this.gridMalzemeler.RowTemplate.Height = 24;
			this.gridMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridMalzemeler.Size = new System.Drawing.Size(500, 260);
			this.gridMalzemeler.TabIndex = 47;
			this.gridMalzemeler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMalzemeler_CellClick);
			this.gridMalzemeler.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridMalzemeler_CellFormatting);
			// 
			// ComboNeden
			// 
			this.ComboNeden.FormattingEnabled = true;
			this.ComboNeden.Items.AddRange(new object[] {
            "Bozuk",
            "Diğer"});
			this.ComboNeden.Location = new System.Drawing.Point(158, 80);
			this.ComboNeden.Name = "ComboNeden";
			this.ComboNeden.Size = new System.Drawing.Size(141, 26);
			this.ComboNeden.TabIndex = 48;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(35, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 18);
			this.label1.TabIndex = 49;
			this.label1.Text = "Çıktı Nedeni:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(36, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 18);
			this.label2.TabIndex = 50;
			this.label2.Text = "Çıktı Miktarı:";
			// 
			// txtmiktar
			// 
			this.txtmiktar.Location = new System.Drawing.Point(158, 127);
			this.txtmiktar.Name = "txtmiktar";
			this.txtmiktar.Size = new System.Drawing.Size(141, 24);
			this.txtmiktar.TabIndex = 51;
			// 
			// BtnCikti
			// 
			this.BtnCikti.BackColor = System.Drawing.Color.SkyBlue;
			this.BtnCikti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.BtnCikti.ImageKey = "stokDüş.png";
			this.BtnCikti.ImageList = this.ımageList1;
			this.BtnCikti.Location = new System.Drawing.Point(113, 176);
			this.BtnCikti.Name = "BtnCikti";
			this.BtnCikti.Size = new System.Drawing.Size(159, 78);
			this.BtnCikti.TabIndex = 52;
			this.BtnCikti.Text = "Çıktı Ekle";
			this.BtnCikti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.BtnCikti.UseVisualStyleBackColor = false;
			this.BtnCikti.Click += new System.EventHandler(this.BtnCikti_Click);
			// 
			// HiddenStokID
			// 
			this.HiddenStokID.Location = new System.Drawing.Point(1251, 96);
			this.HiddenStokID.Name = "HiddenStokID";
			this.HiddenStokID.Size = new System.Drawing.Size(52, 22);
			this.HiddenStokID.TabIndex = 53;
			this.HiddenStokID.Visible = false;
			// 
			// HiddenMalzemeID
			// 
			this.HiddenMalzemeID.Location = new System.Drawing.Point(1251, 128);
			this.HiddenMalzemeID.Name = "HiddenMalzemeID";
			this.HiddenMalzemeID.Size = new System.Drawing.Size(52, 22);
			this.HiddenMalzemeID.TabIndex = 54;
			this.HiddenMalzemeID.Visible = false;
			// 
			// hiddenTedarikciID
			// 
			this.hiddenTedarikciID.Location = new System.Drawing.Point(1251, 160);
			this.hiddenTedarikciID.Name = "hiddenTedarikciID";
			this.hiddenTedarikciID.Size = new System.Drawing.Size(52, 22);
			this.hiddenTedarikciID.TabIndex = 55;
			this.hiddenTedarikciID.Visible = false;
			// 
			// HiddenCiktiID
			// 
			this.HiddenCiktiID.Location = new System.Drawing.Point(1251, 64);
			this.HiddenCiktiID.Name = "HiddenCiktiID";
			this.HiddenCiktiID.Size = new System.Drawing.Size(52, 22);
			this.HiddenCiktiID.TabIndex = 56;
			this.HiddenCiktiID.Visible = false;
			// 
			// txtstok
			// 
			this.txtstok.Location = new System.Drawing.Point(158, 43);
			this.txtstok.Name = "txtstok";
			this.txtstok.ReadOnly = true;
			this.txtstok.Size = new System.Drawing.Size(141, 24);
			this.txtstok.TabIndex = 58;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(40, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 18);
			this.label3.TabIndex = 57;
			this.label3.Text = "Eldeki Stok:";
			// 
			// groupCikti
			// 
			this.groupCikti.Controls.Add(this.BtnCikti);
			this.groupCikti.Controls.Add(this.txtstok);
			this.groupCikti.Controls.Add(this.ComboNeden);
			this.groupCikti.Controls.Add(this.label3);
			this.groupCikti.Controls.Add(this.label1);
			this.groupCikti.Controls.Add(this.label2);
			this.groupCikti.Controls.Add(this.txtmiktar);
			this.groupCikti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupCikti.Location = new System.Drawing.Point(520, 35);
			this.groupCikti.Name = "groupCikti";
			this.groupCikti.Size = new System.Drawing.Size(323, 260);
			this.groupCikti.TabIndex = 59;
			this.groupCikti.TabStop = false;
			this.groupCikti.Text = "Çıktı Bilgileri";
			// 
			// gridCikti
			// 
			this.gridCikti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridCikti.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridCikti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridCikti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridCikti.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridCikti.Location = new System.Drawing.Point(850, 35);
			this.gridCikti.Margin = new System.Windows.Forms.Padding(4);
			this.gridCikti.Name = "gridCikti";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridCikti.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridCikti.RowHeadersWidth = 51;
			this.gridCikti.RowTemplate.Height = 24;
			this.gridCikti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridCikti.Size = new System.Drawing.Size(451, 260);
			this.gridCikti.TabIndex = 60;
			this.gridCikti.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCikti_CellClick);
			this.gridCikti.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridCikti_CellFormatting);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(177, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 25);
			this.label4.TabIndex = 59;
			this.label4.Text = "Malzemeler";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(1036, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 25);
			this.label5.TabIndex = 61;
			this.label5.Text = "Çıktılar";
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "stokDüş.png");
			// 
			// StokCiktiSayfasi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1304, 303);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gridCikti);
			this.Controls.Add(this.groupCikti);
			this.Controls.Add(this.gridMalzemeler);
			this.Controls.Add(this.HiddenCiktiID);
			this.Controls.Add(this.hiddenTedarikciID);
			this.Controls.Add(this.HiddenStokID);
			this.Controls.Add(this.HiddenMalzemeID);
			this.Name = "StokCiktiSayfasi";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stok Çıktı";
			this.Load += new System.EventHandler(this.StokCikti_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridMalzemeler)).EndInit();
			this.groupCikti.ResumeLayout(false);
			this.groupCikti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCikti)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gridMalzemeler;
		private System.Windows.Forms.ComboBox ComboNeden;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtmiktar;
		private System.Windows.Forms.Button BtnCikti;
		private System.Windows.Forms.TextBox HiddenStokID;
		private System.Windows.Forms.TextBox HiddenMalzemeID;
		private System.Windows.Forms.TextBox hiddenTedarikciID;
		private System.Windows.Forms.TextBox HiddenCiktiID;
		private System.Windows.Forms.TextBox txtstok;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupCikti;
		private System.Windows.Forms.DataGridView gridCikti;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ImageList ımageList1;
	}
}