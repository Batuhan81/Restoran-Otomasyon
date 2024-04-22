namespace Restoran_Otomasyon.Paneller
{
	partial class OzellikESG
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
			this.txtAd = new System.Windows.Forms.TextBox();
			this.Kaydet = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.gridOzellik = new System.Windows.Forms.DataGridView();
			this.hiddenId = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.gridOzellik)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(48, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Özellik Ad:";
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(4, 64);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(175, 22);
			this.txtAd.TabIndex = 1;
			// 
			// Kaydet
			// 
			this.Kaydet.Location = new System.Drawing.Point(4, 92);
			this.Kaydet.Name = "Kaydet";
			this.Kaydet.Size = new System.Drawing.Size(169, 60);
			this.Kaydet.TabIndex = 2;
			this.Kaydet.Text = "Kaydet";
			this.Kaydet.UseVisualStyleBackColor = true;
			this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(4, 163);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(169, 60);
			this.button1.TabIndex = 3;
			this.button1.Text = "Sil";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// gridOzellik
			// 
			this.gridOzellik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOzellik.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridOzellik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridOzellik.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridOzellik.Location = new System.Drawing.Point(186, 7);
			this.gridOzellik.Margin = new System.Windows.Forms.Padding(4);
			this.gridOzellik.Name = "gridOzellik";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOzellik.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridOzellik.RowHeadersWidth = 51;
			this.gridOzellik.RowTemplate.Height = 24;
			this.gridOzellik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridOzellik.Size = new System.Drawing.Size(232, 219);
			this.gridOzellik.TabIndex = 46;
			this.gridOzellik.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOzellik_CellClick);
			// 
			// hiddenId
			// 
			this.hiddenId.Location = new System.Drawing.Point(126, 6);
			this.hiddenId.Name = "hiddenId";
			this.hiddenId.Size = new System.Drawing.Size(53, 22);
			this.hiddenId.TabIndex = 47;
			this.hiddenId.Visible = false;
			// 
			// OzellikESG
			// 
			this.AcceptButton = this.Kaydet;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 229);
			this.Controls.Add(this.hiddenId);
			this.Controls.Add(this.gridOzellik);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Kaydet);
			this.Controls.Add(this.txtAd);
			this.Controls.Add(this.label1);
			this.Name = "OzellikESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Özellik İşlemleri";
			this.Load += new System.EventHandler(this.OzellikESG_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridOzellik)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAd;
		private System.Windows.Forms.Button Kaydet;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView gridOzellik;
		private System.Windows.Forms.TextBox hiddenId;
	}
}