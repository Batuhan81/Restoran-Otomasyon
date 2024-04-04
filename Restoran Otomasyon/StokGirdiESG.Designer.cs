namespace Restoran_Otomasyon.Paneller
{
	partial class StokGirdiESG
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
			this.hiddenStokId = new System.Windows.Forms.TextBox();
			this.groupGirdi = new System.Windows.Forms.GroupBox();
			this.txtTedarikci = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboMalzeme = new System.Windows.Forms.ComboBox();
			this.txtAlisF = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtalinanMik = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uzanti = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.gridStokGirdi = new System.Windows.Forms.DataGridView();
			this.hiddenTedarikciId = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.hiddenMalzemeId = new System.Windows.Forms.TextBox();
			this.hiddensStokGirdiId = new System.Windows.Forms.TextBox();
			this.groupGirdi.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStokGirdi)).BeginInit();
			this.SuspendLayout();
			// 
			// hiddenStokId
			// 
			this.hiddenStokId.Location = new System.Drawing.Point(420, 78);
			this.hiddenStokId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenStokId.Name = "hiddenStokId";
			this.hiddenStokId.Size = new System.Drawing.Size(49, 22);
			this.hiddenStokId.TabIndex = 50;
			this.hiddenStokId.Visible = false;
			// 
			// groupGirdi
			// 
			this.groupGirdi.Controls.Add(this.txtTedarikci);
			this.groupGirdi.Controls.Add(this.label4);
			this.groupGirdi.Controls.Add(this.label3);
			this.groupGirdi.Controls.Add(this.comboMalzeme);
			this.groupGirdi.Controls.Add(this.txtAlisF);
			this.groupGirdi.Controls.Add(this.label2);
			this.groupGirdi.Controls.Add(this.txtalinanMik);
			this.groupGirdi.Controls.Add(this.label1);
			this.groupGirdi.Controls.Add(this.uzanti);
			this.groupGirdi.Controls.Add(this.button1);
			this.groupGirdi.Location = new System.Drawing.Point(10, 13);
			this.groupGirdi.Margin = new System.Windows.Forms.Padding(4);
			this.groupGirdi.Name = "groupGirdi";
			this.groupGirdi.Padding = new System.Windows.Forms.Padding(4);
			this.groupGirdi.Size = new System.Drawing.Size(393, 391);
			this.groupGirdi.TabIndex = 47;
			this.groupGirdi.TabStop = false;
			this.groupGirdi.Text = "Girdi Bilgileri";
			// 
			// txtTedarikci
			// 
			this.txtTedarikci.Location = new System.Drawing.Point(152, 228);
			this.txtTedarikci.Name = "txtTedarikci";
			this.txtTedarikci.ReadOnly = true;
			this.txtTedarikci.Size = new System.Drawing.Size(149, 22);
			this.txtTedarikci.TabIndex = 46;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 229);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 16);
			this.label4.TabIndex = 45;
			this.label4.Text = "Tedarikçi:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 44;
			this.label3.Text = "Malzeme Adı:";
			// 
			// comboMalzeme
			// 
			this.comboMalzeme.FormattingEnabled = true;
			this.comboMalzeme.Location = new System.Drawing.Point(152, 40);
			this.comboMalzeme.Name = "comboMalzeme";
			this.comboMalzeme.Size = new System.Drawing.Size(149, 24);
			this.comboMalzeme.TabIndex = 43;
			this.comboMalzeme.SelectedIndexChanged += new System.EventHandler(this.comboMalzeme_SelectedIndexChanged);
			// 
			// txtAlisF
			// 
			this.txtAlisF.Location = new System.Drawing.Point(152, 166);
			this.txtAlisF.Name = "txtAlisF";
			this.txtAlisF.Size = new System.Drawing.Size(149, 22);
			this.txtAlisF.TabIndex = 42;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(52, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 41;
			this.label2.Text = "Alış Fiyatı";
			// 
			// txtalinanMik
			// 
			this.txtalinanMik.Location = new System.Drawing.Point(152, 104);
			this.txtalinanMik.Name = "txtalinanMik";
			this.txtalinanMik.Size = new System.Drawing.Size(149, 22);
			this.txtalinanMik.TabIndex = 40;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 16);
			this.label1.TabIndex = 39;
			this.label1.Text = "Alınan Miktar";
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(71, 294);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(177, 66);
			this.button1.TabIndex = 6;
			this.button1.Text = "Kaydet";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// gridStokGirdi
			// 
			this.gridStokGirdi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridStokGirdi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridStokGirdi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridStokGirdi.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridStokGirdi.Location = new System.Drawing.Point(411, 13);
			this.gridStokGirdi.Margin = new System.Windows.Forms.Padding(4);
			this.gridStokGirdi.Name = "gridStokGirdi";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridStokGirdi.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridStokGirdi.RowHeadersWidth = 51;
			this.gridStokGirdi.RowTemplate.Height = 24;
			this.gridStokGirdi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridStokGirdi.Size = new System.Drawing.Size(1111, 391);
			this.gridStokGirdi.TabIndex = 46;
			this.gridStokGirdi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStokGirdi_CellClick);
			// 
			// hiddenTedarikciId
			// 
			this.hiddenTedarikciId.Location = new System.Drawing.Point(420, 11);
			this.hiddenTedarikciId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenTedarikciId.Name = "hiddenTedarikciId";
			this.hiddenTedarikciId.Size = new System.Drawing.Size(49, 22);
			this.hiddenTedarikciId.TabIndex = 48;
			this.hiddenTedarikciId.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			// 
			// hiddenMalzemeId
			// 
			this.hiddenMalzemeId.Location = new System.Drawing.Point(420, 46);
			this.hiddenMalzemeId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenMalzemeId.Name = "hiddenMalzemeId";
			this.hiddenMalzemeId.Size = new System.Drawing.Size(49, 22);
			this.hiddenMalzemeId.TabIndex = 49;
			this.hiddenMalzemeId.Visible = false;
			// 
			// hiddensStokGirdiId
			// 
			this.hiddensStokGirdiId.Location = new System.Drawing.Point(420, 116);
			this.hiddensStokGirdiId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddensStokGirdiId.Name = "hiddensStokGirdiId";
			this.hiddensStokGirdiId.Size = new System.Drawing.Size(49, 22);
			this.hiddensStokGirdiId.TabIndex = 51;
			this.hiddensStokGirdiId.Visible = false;
			// 
			// StokGirdiESG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1527, 408);
			this.Controls.Add(this.hiddensStokGirdiId);
			this.Controls.Add(this.hiddenTedarikciId);
			this.Controls.Add(this.hiddenMalzemeId);
			this.Controls.Add(this.hiddenStokId);
			this.Controls.Add(this.groupGirdi);
			this.Controls.Add(this.gridStokGirdi);
			this.Name = "StokGirdiESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stok Girdisi Ekle";
			this.Load += new System.EventHandler(this.StokGirdiESG_Load);
			this.groupGirdi.ResumeLayout(false);
			this.groupGirdi.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStokGirdi)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox hiddenStokId;
		private System.Windows.Forms.GroupBox groupGirdi;
		private System.Windows.Forms.Label uzanti;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView gridStokGirdi;
		public System.Windows.Forms.TextBox hiddenTedarikciId;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox hiddenMalzemeId;
		private System.Windows.Forms.TextBox txtTedarikci;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboMalzeme;
		private System.Windows.Forms.TextBox txtAlisF;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtalinanMik;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox hiddensStokGirdiId;
	}
}