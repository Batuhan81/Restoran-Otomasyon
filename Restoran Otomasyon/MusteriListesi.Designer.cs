namespace Restoran_Otomasyon.Paneller
{
	partial class MusteriListesi
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
			this.gridMusteriler = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSoyadAra = new System.Windows.Forms.TextBox();
			this.txtTelAra = new System.Windows.Forms.MaskedTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtmailAra = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtAdAra = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridMusteriler
			// 
			this.gridMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridMusteriler.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.gridMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridMusteriler.DefaultCellStyle = dataGridViewCellStyle8;
			this.gridMusteriler.Location = new System.Drawing.Point(15, 89);
			this.gridMusteriler.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.gridMusteriler.Name = "gridMusteriler";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridMusteriler.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.gridMusteriler.RowHeadersWidth = 51;
			this.gridMusteriler.RowTemplate.Height = 24;
			this.gridMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridMusteriler.Size = new System.Drawing.Size(1507, 705);
			this.gridMusteriler.TabIndex = 47;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtSoyadAra);
			this.groupBox1.Controls.Add(this.txtTelAra);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtmailAra);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.txtAdAra);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(15, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1507, 68);
			this.groupBox1.TabIndex = 48;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtre Seçenekleri";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(361, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 22);
			this.label1.TabIndex = 45;
			this.label1.Text = "Soyad:";
			// 
			// txtSoyadAra
			// 
			this.txtSoyadAra.Location = new System.Drawing.Point(488, 26);
			this.txtSoyadAra.Name = "txtSoyadAra";
			this.txtSoyadAra.Size = new System.Drawing.Size(144, 28);
			this.txtSoyadAra.TabIndex = 44;
			this.txtSoyadAra.TextChanged += new System.EventHandler(this.txtSoyadAra_TextChanged);
			// 
			// txtTelAra
			// 
			this.txtTelAra.Location = new System.Drawing.Point(1167, 26);
			this.txtTelAra.Margin = new System.Windows.Forms.Padding(4);
			this.txtTelAra.Mask = "(999) 000-0000";
			this.txtTelAra.Name = "txtTelAra";
			this.txtTelAra.Size = new System.Drawing.Size(146, 28);
			this.txtTelAra.TabIndex = 42;
			this.txtTelAra.TextChanged += new System.EventHandler(this.txtTelAra_TextChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
			this.label13.Location = new System.Drawing.Point(1028, 29);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 22);
			this.label13.TabIndex = 43;
			this.label13.Text = "Telefon:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(687, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(87, 22);
			this.label12.TabIndex = 3;
			this.label12.Text = "E-Posta:";
			// 
			// txtmailAra
			// 
			this.txtmailAra.Location = new System.Drawing.Point(829, 26);
			this.txtmailAra.Name = "txtmailAra";
			this.txtmailAra.Size = new System.Drawing.Size(144, 28);
			this.txtmailAra.TabIndex = 2;
			this.txtmailAra.TextChanged += new System.EventHandler(this.txtmailAra_TextChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(67, 29);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 22);
			this.label11.TabIndex = 1;
			this.label11.Text = "Ad:";
			// 
			// txtAdAra
			// 
			this.txtAdAra.Location = new System.Drawing.Point(162, 26);
			this.txtAdAra.Name = "txtAdAra";
			this.txtAdAra.Size = new System.Drawing.Size(144, 28);
			this.txtAdAra.TabIndex = 0;
			this.txtAdAra.TextChanged += new System.EventHandler(this.txtAdAra_TextChanged);
			// 
			// button8
			// 
			this.button8.BackColor = System.Drawing.Color.SkyBlue;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button8.Location = new System.Drawing.Point(1368, 23);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(84, 35);
			this.button8.TabIndex = 49;
			this.button8.Text = "Kaldır";
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// MusteriListesi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1924, 909);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gridMusteriler);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MusteriListesi";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Müşteri Listesi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MusteriListesi_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.DataGridView gridMusteriler;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MaskedTextBox txtTelAra;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtmailAra;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAdAra;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSoyadAra;
		private System.Windows.Forms.Button button8;
	}
}