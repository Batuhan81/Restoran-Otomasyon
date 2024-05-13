namespace Restoran_Otomasyon
{
	partial class DisariSiparis
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisariSiparis));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.button2 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.gridSiparisler = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.UrunPaneli = new System.Windows.Forms.FlowLayoutPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.ComboMenu = new System.Windows.Forms.ComboBox();
			this.ComboUrun = new System.Windows.Forms.ComboBox();
			this.txttutar = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button2.ImageKey = "siparisOnayla2.png";
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(1261, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(266, 89);
			this.button2.TabIndex = 58;
			this.button2.Text = "Sipariş Onayla";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "siparisOnayla2.png");
			// 
			// gridSiparisler
			// 
			this.gridSiparisler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridSiparisler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridSiparisler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridSiparisler.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridSiparisler.Location = new System.Drawing.Point(1261, 186);
			this.gridSiparisler.Margin = new System.Windows.Forms.Padding(4);
			this.gridSiparisler.Name = "gridSiparisler";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridSiparisler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridSiparisler.RowHeadersWidth = 51;
			this.gridSiparisler.RowTemplate.Height = 24;
			this.gridSiparisler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridSiparisler.Size = new System.Drawing.Size(284, 574);
			this.gridSiparisler.TabIndex = 57;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.button1.Location = new System.Drawing.Point(433, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(219, 33);
			this.button1.TabIndex = 56;
			this.button1.Text = "Tüm Ürünler";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// UrunPaneli
			// 
			this.UrunPaneli.Location = new System.Drawing.Point(2, 42);
			this.UrunPaneli.Name = "UrunPaneli";
			this.UrunPaneli.Size = new System.Drawing.Size(1252, 718);
			this.UrunPaneli.TabIndex = 55;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label8.Location = new System.Drawing.Point(725, 14);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(140, 18);
			this.label8.TabIndex = 54;
			this.label8.Text = "Menü Kategorileri";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.Location = new System.Drawing.Point(12, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 18);
			this.label7.TabIndex = 53;
			this.label7.Text = "Ürün Kategorileri";
			// 
			// ComboMenu
			// 
			this.ComboMenu.FormattingEnabled = true;
			this.ComboMenu.Items.AddRange(new object[] {
            "Tümü"});
			this.ComboMenu.Location = new System.Drawing.Point(884, 11);
			this.ComboMenu.Name = "ComboMenu";
			this.ComboMenu.Size = new System.Drawing.Size(121, 24);
			this.ComboMenu.TabIndex = 52;
			// 
			// ComboUrun
			// 
			this.ComboUrun.FormattingEnabled = true;
			this.ComboUrun.Items.AddRange(new object[] {
            "Tümü"});
			this.ComboUrun.Location = new System.Drawing.Point(156, 11);
			this.ComboUrun.Name = "ComboUrun";
			this.ComboUrun.Size = new System.Drawing.Size(121, 24);
			this.ComboUrun.TabIndex = 51;
			// 
			// txttutar
			// 
			this.txttutar.Location = new System.Drawing.Point(1366, 54);
			this.txttutar.Name = "txttutar";
			this.txttutar.ReadOnly = true;
			this.txttutar.Size = new System.Drawing.Size(127, 22);
			this.txttutar.TabIndex = 60;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(1297, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 18);
			this.label4.TabIndex = 59;
			this.label4.Text = "Tutar:";
			// 
			// DisariSiparis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1564, 832);
			this.Controls.Add(this.txttutar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.gridSiparisler);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.UrunPaneli);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ComboMenu);
			this.Controls.Add(this.ComboUrun);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "DisariSiparis";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dişarıya Sipariş";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.DisariSiparis_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.DataGridView gridSiparisler;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FlowLayoutPanel UrunPaneli;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ComboMenu;
		private System.Windows.Forms.ComboBox ComboUrun;
		private System.Windows.Forms.TextBox txttutar;
		private System.Windows.Forms.Label label4;
	}
}