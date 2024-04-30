namespace Restoran_Otomasyon.Paneller
{
	partial class StokSayim
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
			this.VtStok = new System.Windows.Forms.TextBox();
			this.EldekiStok = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnGuncelle = new System.Windows.Forms.Button();
			this.BtnEslesti = new System.Windows.Forms.Button();
			this.malzemeListesi = new System.Windows.Forms.ListBox();
			this.ComboNeden = new System.Windows.Forms.ComboBox();
			this.hiddenMalzemeID = new System.Windows.Forms.TextBox();
			this.hiddenstokId = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// VtStok
			// 
			this.VtStok.Location = new System.Drawing.Point(305, 11);
			this.VtStok.Name = "VtStok";
			this.VtStok.ReadOnly = true;
			this.VtStok.Size = new System.Drawing.Size(100, 24);
			this.VtStok.TabIndex = 1;
			// 
			// EldekiStok
			// 
			this.EldekiStok.Location = new System.Drawing.Point(305, 60);
			this.EldekiStok.Name = "EldekiStok";
			this.EldekiStok.Size = new System.Drawing.Size(100, 24);
			this.EldekiStok.TabIndex = 2;
			this.EldekiStok.Leave += new System.EventHandler(this.EldekiStok_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(208, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Vtdeki Stok";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(208, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Eldeki Stok";
			// 
			// BtnGuncelle
			// 
			this.BtnGuncelle.Location = new System.Drawing.Point(244, 237);
			this.BtnGuncelle.Name = "BtnGuncelle";
			this.BtnGuncelle.Size = new System.Drawing.Size(141, 39);
			this.BtnGuncelle.TabIndex = 5;
			this.BtnGuncelle.Text = "Güncelle";
			this.BtnGuncelle.UseVisualStyleBackColor = true;
			this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
			// 
			// BtnEslesti
			// 
			this.BtnEslesti.Location = new System.Drawing.Point(244, 288);
			this.BtnEslesti.Name = "BtnEslesti";
			this.BtnEslesti.Size = new System.Drawing.Size(141, 39);
			this.BtnEslesti.TabIndex = 6;
			this.BtnEslesti.Text = "Eşleşti";
			this.BtnEslesti.UseVisualStyleBackColor = true;
			this.BtnEslesti.Click += new System.EventHandler(this.BtnEslesti_Click);
			// 
			// malzemeListesi
			// 
			this.malzemeListesi.FormattingEnabled = true;
			this.malzemeListesi.ItemHeight = 18;
			this.malzemeListesi.Location = new System.Drawing.Point(12, 10);
			this.malzemeListesi.Name = "malzemeListesi";
			this.malzemeListesi.Size = new System.Drawing.Size(190, 346);
			this.malzemeListesi.TabIndex = 7;
			this.malzemeListesi.SelectedIndexChanged += new System.EventHandler(this.malzemeListesi_SelectedIndexChanged);
			// 
			// ComboNeden
			// 
			this.ComboNeden.FormattingEnabled = true;
			this.ComboNeden.Location = new System.Drawing.Point(244, 125);
			this.ComboNeden.Name = "ComboNeden";
			this.ComboNeden.Size = new System.Drawing.Size(141, 26);
			this.ComboNeden.TabIndex = 8;
			// 
			// hiddenMalzemeID
			// 
			this.hiddenMalzemeID.Location = new System.Drawing.Point(263, 169);
			this.hiddenMalzemeID.Name = "hiddenMalzemeID";
			this.hiddenMalzemeID.Size = new System.Drawing.Size(100, 24);
			this.hiddenMalzemeID.TabIndex = 9;
			this.hiddenMalzemeID.Visible = false;
			// 
			// hiddenstokId
			// 
			this.hiddenstokId.Location = new System.Drawing.Point(271, 177);
			this.hiddenstokId.Name = "hiddenstokId";
			this.hiddenstokId.Size = new System.Drawing.Size(100, 24);
			this.hiddenstokId.TabIndex = 10;
			this.hiddenstokId.Visible = false;
			// 
			// StokSayim
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 363);
			this.Controls.Add(this.hiddenstokId);
			this.Controls.Add(this.hiddenMalzemeID);
			this.Controls.Add(this.ComboNeden);
			this.Controls.Add(this.malzemeListesi);
			this.Controls.Add(this.BtnEslesti);
			this.Controls.Add(this.BtnGuncelle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EldekiStok);
			this.Controls.Add(this.VtStok);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Name = "StokSayim";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stok Sayım";
			this.Load += new System.EventHandler(this.StokSayim_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox VtStok;
		private System.Windows.Forms.TextBox EldekiStok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BtnGuncelle;
		private System.Windows.Forms.Button BtnEslesti;
		private System.Windows.Forms.ListBox malzemeListesi;
		private System.Windows.Forms.ComboBox ComboNeden;
		private System.Windows.Forms.TextBox hiddenMalzemeID;
		private System.Windows.Forms.TextBox hiddenstokId;
	}
}