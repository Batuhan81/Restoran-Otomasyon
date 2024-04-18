namespace Restoran_Otomasyon.Paneller
{
	partial class RolESG
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolESG));
			this.label1 = new System.Windows.Forms.Label();
			this.txtad = new System.Windows.Forms.TextBox();
			this.grid1 = new System.Windows.Forms.DataGridView();
			this.Kaydet = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.Sil = new System.Windows.Forms.Button();
			this.hiddenRolId = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Rol Adı:";
			// 
			// txtad
			// 
			this.txtad.Location = new System.Drawing.Point(92, 59);
			this.txtad.Name = "txtad";
			this.txtad.Size = new System.Drawing.Size(140, 27);
			this.txtad.TabIndex = 1;
			// 
			// grid1
			// 
			this.grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grid1.DefaultCellStyle = dataGridViewCellStyle11;
			this.grid1.Location = new System.Drawing.Point(250, 12);
			this.grid1.Name = "grid1";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.grid1.RowHeadersWidth = 51;
			this.grid1.RowTemplate.Height = 24;
			this.grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid1.Size = new System.Drawing.Size(349, 277);
			this.grid1.TabIndex = 17;
			this.grid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid1_CellClick);
			// 
			// Kaydet
			// 
			this.Kaydet.ImageKey = "Kaydet.png";
			this.Kaydet.ImageList = this.ımageList1;
			this.Kaydet.Location = new System.Drawing.Point(66, 106);
			this.Kaydet.Name = "Kaydet";
			this.Kaydet.Size = new System.Drawing.Size(142, 75);
			this.Kaydet.TabIndex = 2;
			this.Kaydet.Text = "Kaydet";
			this.Kaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.Kaydet.UseVisualStyleBackColor = true;
			this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			this.ımageList1.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// Sil
			// 
			this.Sil.ImageKey = "Sil butonu - Kopya.png";
			this.Sil.ImageList = this.ımageList1;
			this.Sil.Location = new System.Drawing.Point(66, 207);
			this.Sil.Name = "Sil";
			this.Sil.Size = new System.Drawing.Size(142, 75);
			this.Sil.TabIndex = 3;
			this.Sil.Text = "Sil";
			this.Sil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.Sil.UseVisualStyleBackColor = true;
			this.Sil.Click += new System.EventHandler(this.Sil_Click);
			// 
			// hiddenRolId
			// 
			this.hiddenRolId.Location = new System.Drawing.Point(92, 12);
			this.hiddenRolId.Name = "hiddenRolId";
			this.hiddenRolId.Size = new System.Drawing.Size(140, 27);
			this.hiddenRolId.TabIndex = 20;
			this.hiddenRolId.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// RolESG
			// 
			this.AcceptButton = this.Kaydet;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 294);
			this.Controls.Add(this.hiddenRolId);
			this.Controls.Add(this.Sil);
			this.Controls.Add(this.Kaydet);
			this.Controls.Add(this.grid1);
			this.Controls.Add(this.txtad);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RolESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rol İşlemleri";
			this.Load += new System.EventHandler(this.RolESG_Load);
			((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtad;
		private System.Windows.Forms.DataGridView grid1;
		private System.Windows.Forms.Button Kaydet;
		private System.Windows.Forms.Button Sil;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.TextBox hiddenRolId;
		private System.Windows.Forms.Timer timer1;
	}
}