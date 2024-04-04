namespace Restoran_Otomasyon
{
	partial class TedarikciESG
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
			this.hiddenAdresID = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.hiddenTedarikciId = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.uzanti = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.txtAdres = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txteposta = new System.Windows.Forms.TextBox();
			this.txttelefon = new System.Windows.Forms.MaskedTextBox();
			this.txtsoyad = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtad = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupTedarikci = new System.Windows.Forms.GroupBox();
			this.gridTedarikci = new System.Windows.Forms.DataGridView();
			this.groupTedarikci.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTedarikci)).BeginInit();
			this.SuspendLayout();
			// 
			// hiddenAdresID
			// 
			this.hiddenAdresID.Location = new System.Drawing.Point(436, 43);
			this.hiddenAdresID.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenAdresID.Name = "hiddenAdresID";
			this.hiddenAdresID.Size = new System.Drawing.Size(49, 27);
			this.hiddenAdresID.TabIndex = 43;
			this.hiddenAdresID.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 375);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(177, 66);
			this.button1.TabIndex = 6;
			this.button1.Text = "Kaydet";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// hiddenTedarikciId
			// 
			this.hiddenTedarikciId.Location = new System.Drawing.Point(436, 5);
			this.hiddenTedarikciId.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenTedarikciId.Name = "hiddenTedarikciId";
			this.hiddenTedarikciId.Size = new System.Drawing.Size(49, 27);
			this.hiddenTedarikciId.TabIndex = 44;
			this.hiddenTedarikciId.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
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
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(191, 282);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(146, 28);
			this.button4.TabIndex = 5;
			this.button4.Text = "Adres Seç";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtAdres
			// 
			this.txtAdres.Location = new System.Drawing.Point(8, 318);
			this.txtAdres.Name = "txtAdres";
			this.txtAdres.Size = new System.Drawing.Size(377, 50);
			this.txtAdres.TabIndex = 36;
			this.txtAdres.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(208, 375);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(177, 66);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sil";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txteposta
			// 
			this.txteposta.Location = new System.Drawing.Point(149, 160);
			this.txteposta.Margin = new System.Windows.Forms.Padding(4);
			this.txteposta.Name = "txteposta";
			this.txteposta.Size = new System.Drawing.Size(175, 27);
			this.txteposta.TabIndex = 3;
			// 
			// txttelefon
			// 
			this.txttelefon.Location = new System.Drawing.Point(149, 221);
			this.txttelefon.Margin = new System.Windows.Forms.Padding(4);
			this.txttelefon.Mask = "(999) 000-0000";
			this.txttelefon.Name = "txttelefon";
			this.txttelefon.Size = new System.Drawing.Size(175, 27);
			this.txttelefon.TabIndex = 4;
			// 
			// txtsoyad
			// 
			this.txtsoyad.Location = new System.Drawing.Point(149, 99);
			this.txtsoyad.Margin = new System.Windows.Forms.Padding(4);
			this.txtsoyad.Name = "txtsoyad";
			this.txtsoyad.Size = new System.Drawing.Size(175, 27);
			this.txtsoyad.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label9.Location = new System.Drawing.Point(127, 287);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 27;
			this.label9.Text = "Adres:";
			// 
			// txtad
			// 
			this.txtad.Location = new System.Drawing.Point(149, 38);
			this.txtad.Margin = new System.Windows.Forms.Padding(4);
			this.txtad.Name = "txtad";
			this.txtad.Size = new System.Drawing.Size(175, 27);
			this.txtad.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(55, 227);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "Telefon:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(53, 166);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 16);
			this.label3.TabIndex = 21;
			this.label3.Text = "E-Posta:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(63, 105);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 20;
			this.label2.Text = "Soyad:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(89, 44);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 16);
			this.label1.TabIndex = 19;
			this.label1.Text = "Ad:";
			// 
			// groupTedarikci
			// 
			this.groupTedarikci.Controls.Add(this.uzanti);
			this.groupTedarikci.Controls.Add(this.button4);
			this.groupTedarikci.Controls.Add(this.txtAdres);
			this.groupTedarikci.Controls.Add(this.button2);
			this.groupTedarikci.Controls.Add(this.button1);
			this.groupTedarikci.Controls.Add(this.txteposta);
			this.groupTedarikci.Controls.Add(this.txttelefon);
			this.groupTedarikci.Controls.Add(this.txtsoyad);
			this.groupTedarikci.Controls.Add(this.label9);
			this.groupTedarikci.Controls.Add(this.txtad);
			this.groupTedarikci.Controls.Add(this.label4);
			this.groupTedarikci.Controls.Add(this.label3);
			this.groupTedarikci.Controls.Add(this.label2);
			this.groupTedarikci.Controls.Add(this.label1);
			this.groupTedarikci.Location = new System.Drawing.Point(13, 5);
			this.groupTedarikci.Margin = new System.Windows.Forms.Padding(4);
			this.groupTedarikci.Name = "groupTedarikci";
			this.groupTedarikci.Padding = new System.Windows.Forms.Padding(4);
			this.groupTedarikci.Size = new System.Drawing.Size(393, 459);
			this.groupTedarikci.TabIndex = 42;
			this.groupTedarikci.TabStop = false;
			this.groupTedarikci.Text = "Tedarikçi Bilgileri";
			// 
			// gridTedarikci
			// 
			this.gridTedarikci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTedarikci.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.gridTedarikci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTedarikci.DefaultCellStyle = dataGridViewCellStyle5;
			this.gridTedarikci.Location = new System.Drawing.Point(414, 13);
			this.gridTedarikci.Margin = new System.Windows.Forms.Padding(4);
			this.gridTedarikci.Name = "gridTedarikci";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTedarikci.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.gridTedarikci.RowHeadersWidth = 51;
			this.gridTedarikci.RowTemplate.Height = 24;
			this.gridTedarikci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridTedarikci.Size = new System.Drawing.Size(617, 451);
			this.gridTedarikci.TabIndex = 41;
			this.gridTedarikci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTedarikci_CellClick);
			// 
			// TedarikciESG
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1047, 482);
			this.Controls.Add(this.hiddenAdresID);
			this.Controls.Add(this.hiddenTedarikciId);
			this.Controls.Add(this.groupTedarikci);
			this.Controls.Add(this.gridTedarikci);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "TedarikciESG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tedarikçi İşlemleri";
			this.Load += new System.EventHandler(this.TedarikciESG_Load);
			this.groupTedarikci.ResumeLayout(false);
			this.groupTedarikci.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTedarikci)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.TextBox hiddenAdresID;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox hiddenTedarikciId;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label uzanti;
		private System.Windows.Forms.Button button4;
		public System.Windows.Forms.RichTextBox txtAdres;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txteposta;
		private System.Windows.Forms.MaskedTextBox txttelefon;
		private System.Windows.Forms.TextBox txtsoyad;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtad;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupTedarikci;
		private System.Windows.Forms.DataGridView gridTedarikci;
	}
}