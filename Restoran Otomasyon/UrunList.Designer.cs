namespace Restoran_Otomasyon.Paneller
{
	partial class UrunList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gridUrun = new System.Windows.Forms.DataGridView();
			this.groupUrunFiltre = new System.Windows.Forms.GroupBox();
			this.KategoriAra = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.AktiflikAra = new System.Windows.Forms.ComboBox();
			this.button8 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtAdAra = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.gridUrun)).BeginInit();
			this.groupUrunFiltre.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridUrun
			// 
			this.gridUrun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridUrun.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridUrun.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridUrun.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridUrun.Location = new System.Drawing.Point(14, 82);
			this.gridUrun.Margin = new System.Windows.Forms.Padding(5);
			this.gridUrun.Name = "gridUrun";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridUrun.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridUrun.RowHeadersWidth = 51;
			this.gridUrun.RowTemplate.Height = 24;
			this.gridUrun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridUrun.Size = new System.Drawing.Size(1505, 715);
			this.gridUrun.TabIndex = 47;
			this.gridUrun.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridUrun_CellFormatting);
			// 
			// groupUrunFiltre
			// 
			this.groupUrunFiltre.Controls.Add(this.KategoriAra);
			this.groupUrunFiltre.Controls.Add(this.label16);
			this.groupUrunFiltre.Controls.Add(this.AktiflikAra);
			this.groupUrunFiltre.Controls.Add(this.button8);
			this.groupUrunFiltre.Controls.Add(this.label6);
			this.groupUrunFiltre.Controls.Add(this.label15);
			this.groupUrunFiltre.Controls.Add(this.txtAdAra);
			this.groupUrunFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupUrunFiltre.Location = new System.Drawing.Point(183, 12);
			this.groupUrunFiltre.Name = "groupUrunFiltre";
			this.groupUrunFiltre.Size = new System.Drawing.Size(1168, 62);
			this.groupUrunFiltre.TabIndex = 70;
			this.groupUrunFiltre.TabStop = false;
			this.groupUrunFiltre.Text = "Filtre Seçenekleri";
			// 
			// KategoriAra
			// 
			this.KategoriAra.FormattingEnabled = true;
			this.KategoriAra.Items.AddRange(new object[] {
            ""});
			this.KategoriAra.Location = new System.Drawing.Point(899, 23);
			this.KategoriAra.Margin = new System.Windows.Forms.Padding(4);
			this.KategoriAra.Name = "KategoriAra";
			this.KategoriAra.Size = new System.Drawing.Size(125, 30);
			this.KategoriAra.TabIndex = 46;
			this.KategoriAra.SelectedIndexChanged += new System.EventHandler(this.KategoriAra_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label16.Location = new System.Drawing.Point(801, 29);
			this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(76, 18);
			this.label16.TabIndex = 47;
			this.label16.Text = "Kategori:";
			// 
			// AktiflikAra
			// 
			this.AktiflikAra.FormattingEnabled = true;
			this.AktiflikAra.Items.AddRange(new object[] {
            "Aktif",
            "Pasif"});
			this.AktiflikAra.Location = new System.Drawing.Point(497, 23);
			this.AktiflikAra.Margin = new System.Windows.Forms.Padding(4);
			this.AktiflikAra.Name = "AktiflikAra";
			this.AktiflikAra.Size = new System.Drawing.Size(125, 30);
			this.AktiflikAra.TabIndex = 45;
			this.AktiflikAra.SelectedIndexChanged += new System.EventHandler(this.AktiflikAra_SelectedIndexChanged);
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.SkyBlue;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button8.Location = new System.Drawing.Point(1061, 21);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(84, 35);
			this.button8.TabIndex = 44;
			this.button8.Text = "Kaldır";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(399, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 22);
			this.label6.TabIndex = 3;
			this.label6.Text = " Aktiflik:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(30, 27);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 22);
			this.label15.TabIndex = 1;
			this.label15.Text = "Ad:";
			// 
			// txtAdAra
			// 
			this.txtAdAra.Location = new System.Drawing.Point(76, 24);
			this.txtAdAra.Name = "txtAdAra";
			this.txtAdAra.Size = new System.Drawing.Size(144, 28);
			this.txtAdAra.TabIndex = 0;
			this.txtAdAra.TextChanged += new System.EventHandler(this.txtAdAra_TextChanged);
			// 
			// UrunList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.groupUrunFiltre);
			this.Controls.Add(this.gridUrun);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UrunList";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ürün Listesi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.UrunList_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridUrun)).EndInit();
			this.groupUrunFiltre.ResumeLayout(false);
			this.groupUrunFiltre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridUrun;
		private System.Windows.Forms.GroupBox groupUrunFiltre;
		private System.Windows.Forms.ComboBox KategoriAra;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox AktiflikAra;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtAdAra;
	}
}