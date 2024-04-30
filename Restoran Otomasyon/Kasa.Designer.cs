namespace Restoran_Otomasyon.Paneller
{
	partial class Kasa
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBakiye = new System.Windows.Forms.TextBox();
			this.gridOdemeler = new System.Windows.Forms.DataGridView();
			this.Takvim = new System.Windows.Forms.MonthCalendar();
			this.FiltrePanel = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridOdemeler)).BeginInit();
			this.FiltrePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(532, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Kasa Bakiyeniz:";
			this.label1.UseWaitCursor = true;
			// 
			// txtBakiye
			// 
			this.txtBakiye.Location = new System.Drawing.Point(730, 14);
			this.txtBakiye.Name = "txtBakiye";
			this.txtBakiye.ReadOnly = true;
			this.txtBakiye.Size = new System.Drawing.Size(201, 24);
			this.txtBakiye.TabIndex = 2;
			this.txtBakiye.UseWaitCursor = true;
			this.txtBakiye.TextChanged += new System.EventHandler(this.txtBakiye_TextChanged);
			// 
			// gridOdemeler
			// 
			this.gridOdemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOdemeler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridOdemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridOdemeler.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridOdemeler.Location = new System.Drawing.Point(13, 61);
			this.gridOdemeler.Margin = new System.Windows.Forms.Padding(4);
			this.gridOdemeler.Name = "gridOdemeler";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOdemeler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridOdemeler.RowHeadersWidth = 51;
			this.gridOdemeler.RowTemplate.Height = 24;
			this.gridOdemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridOdemeler.Size = new System.Drawing.Size(1517, 732);
			this.gridOdemeler.TabIndex = 70;
			this.gridOdemeler.UseWaitCursor = true;
			this.gridOdemeler.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridOdemeler_CellFormatting);
			// 
			// Takvim
			// 
			this.Takvim.Location = new System.Drawing.Point(21, 50);
			this.Takvim.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
			this.Takvim.MaxSelectionCount = 100;
			this.Takvim.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.Takvim.Name = "Takvim";
			this.Takvim.TabIndex = 71;
			this.Takvim.UseWaitCursor = true;
			this.Takvim.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// FiltrePanel
			// 
			this.FiltrePanel.Controls.Add(this.button4);
			this.FiltrePanel.Controls.Add(this.button3);
			this.FiltrePanel.Controls.Add(this.button2);
			this.FiltrePanel.Controls.Add(this.button1);
			this.FiltrePanel.Controls.Add(this.label2);
			this.FiltrePanel.Controls.Add(this.Takvim);
			this.FiltrePanel.Location = new System.Drawing.Point(37, 509);
			this.FiltrePanel.Name = "FiltrePanel";
			this.FiltrePanel.Size = new System.Drawing.Size(468, 272);
			this.FiltrePanel.TabIndex = 72;
			this.FiltrePanel.UseWaitCursor = true;
			this.FiltrePanel.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(295, 207);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(168, 62);
			this.button3.TabIndex = 75;
			this.button3.Text = "Aylık";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.UseWaitCursor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(295, 139);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(168, 62);
			this.button2.TabIndex = 74;
			this.button2.Text = "Haftalık";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.UseWaitCursor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(295, 71);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 62);
			this.button1.TabIndex = 73;
			this.button1.Text = "Bugün";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.UseWaitCursor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(107, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 18);
			this.label2.TabIndex = 72;
			this.label2.Text = "Aralıklı Filtre";
			this.label2.UseWaitCursor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(1134, 13);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(62, 22);
			this.checkBox1.TabIndex = 73;
			this.checkBox1.Text = "Filtre";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.UseWaitCursor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(295, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(168, 62);
			this.button4.TabIndex = 76;
			this.button4.Text = "Genel";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.UseWaitCursor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Kasa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1532, 828);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.FiltrePanel);
			this.Controls.Add(this.gridOdemeler);
			this.Controls.Add(this.txtBakiye);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "Kasa";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kasa";
			this.UseWaitCursor = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Kasa_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridOdemeler)).EndInit();
			this.FiltrePanel.ResumeLayout(false);
			this.FiltrePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBakiye;
		private System.Windows.Forms.DataGridView gridOdemeler;
		private System.Windows.Forms.MonthCalendar Takvim;
		private System.Windows.Forms.Panel FiltrePanel;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button4;
	}
}