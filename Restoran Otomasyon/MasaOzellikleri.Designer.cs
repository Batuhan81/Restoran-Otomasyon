namespace Restoran_Otomasyon
{
	partial class MasaOzellikleri
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasaOzellikleri));
			this.MasaOzellik = new System.Windows.Forms.CheckedListBox();
			this.btnKaydet = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.OzellikList = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// MasaOzellik
			// 
			this.MasaOzellik.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.MasaOzellik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.MasaOzellik.FormattingEnabled = true;
			this.MasaOzellik.Location = new System.Drawing.Point(384, 32);
			this.MasaOzellik.Name = "MasaOzellik";
			this.MasaOzellik.Size = new System.Drawing.Size(351, 289);
			this.MasaOzellik.TabIndex = 6;
			this.MasaOzellik.Visible = false;
			// 
			// btnKaydet
			// 
			this.btnKaydet.BackColor = System.Drawing.Color.SkyBlue;
			this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKaydet.ImageKey = "Kaydet.png";
			this.btnKaydet.ImageList = this.ımageList1;
			this.btnKaydet.Location = new System.Drawing.Point(285, 327);
			this.btnKaydet.Name = "btnKaydet";
			this.btnKaydet.Size = new System.Drawing.Size(201, 66);
			this.btnKaydet.TabIndex = 7;
			this.btnKaydet.Text = "Kaydet";
			this.btnKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnKaydet.UseVisualStyleBackColor = false;
			this.btnKaydet.Visible = false;
			this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			// 
			// OzellikList
			// 
			this.OzellikList.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.OzellikList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.OzellikList.FormattingEnabled = true;
			this.OzellikList.Location = new System.Drawing.Point(9, 32);
			this.OzellikList.Name = "OzellikList";
			this.OzellikList.Size = new System.Drawing.Size(351, 289);
			this.OzellikList.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(33, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 18);
			this.label1.TabIndex = 9;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(501, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 18);
			this.label2.TabIndex = 10;
			this.label2.Text = "Tüm Özellikler";
			this.label2.Visible = false;
			// 
			// MasaOzellikleri
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(746, 400);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OzellikList);
			this.Controls.Add(this.btnKaydet);
			this.Controls.Add(this.MasaOzellik);
			this.Name = "MasaOzellikleri";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Masa Özellikleri";
			this.Load += new System.EventHandler(this.MasaOzellikleri_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckedListBox MasaOzellik;
		private System.Windows.Forms.Button btnKaydet;
		private System.Windows.Forms.CheckedListBox OzellikList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.Label label2;
	}
}