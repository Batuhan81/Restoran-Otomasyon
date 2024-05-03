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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OzellikESG));
			this.label1 = new System.Windows.Forms.Label();
			this.txtAd = new System.Windows.Forms.TextBox();
			this.Kaydet = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.gridOzellik = new System.Windows.Forms.DataGridView();
			this.hiddenId = new System.Windows.Forms.TextBox();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridOzellik)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(44, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Özellik Ad:";
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(1, 64);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(175, 22);
			this.txtAd.TabIndex = 1;
			// 
			// Kaydet
			// 
			this.Kaydet.BackColor = System.Drawing.Color.SkyBlue;
			this.Kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Kaydet.ImageKey = "Kaydet.png";
			this.Kaydet.ImageList = this.ımageList1;
			this.Kaydet.Location = new System.Drawing.Point(4, 92);
			this.Kaydet.Name = "Kaydet";
			this.Kaydet.Size = new System.Drawing.Size(169, 60);
			this.Kaydet.TabIndex = 2;
			this.Kaydet.Text = "Kaydet";
			this.Kaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.Kaydet.UseVisualStyleBackColor = false;
			this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button1.ImageKey = "Sil butonu - Kopya.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(4, 163);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(169, 60);
			this.button1.TabIndex = 3;
			this.button1.Text = "Sil";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			// 
			// gridOzellik
			// 
			this.gridOzellik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridOzellik.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOzellik.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridOzellik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridOzellik.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridOzellik.Location = new System.Drawing.Point(186, 7);
			this.gridOzellik.Margin = new System.Windows.Forms.Padding(4);
			this.gridOzellik.Name = "gridOzellik";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridOzellik.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			this.ımageList1.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// OzellikESG
			// 
			this.AcceptButton = this.Kaydet;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
		private System.Windows.Forms.ImageList ımageList1;
	}
}