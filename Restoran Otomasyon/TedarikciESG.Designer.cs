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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TedarikciESG));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.hiddenAdresID = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
			this.hiddenTedarikciId = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.uzanti = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.txtAdres = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txteposta = new System.Windows.Forms.TextBox();
			this.txttelefon = new System.Windows.Forms.MaskedTextBox();
			this.txtfirma = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtad = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupTedarikci = new System.Windows.Forms.GroupBox();
			this.gridTedarikci = new System.Windows.Forms.DataGridView();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTelAra = new System.Windows.Forms.MaskedTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtmailAra = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtAdAra = new System.Windows.Forms.TextBox();
			this.groupTedarikci.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridTedarikci)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// hiddenAdresID
			// 
			this.hiddenAdresID.Location = new System.Drawing.Point(365, 404);
			this.hiddenAdresID.Margin = new System.Windows.Forms.Padding(4);
			this.hiddenAdresID.Name = "hiddenAdresID";
			this.hiddenAdresID.Size = new System.Drawing.Size(49, 27);
			this.hiddenAdresID.TabIndex = 43;
			this.hiddenAdresID.Visible = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.ImageKey = "Kaydet.png";
			this.button1.ImageList = this.ımageList1;
			this.button1.Location = new System.Drawing.Point(9, 375);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(126, 66);
			this.button1.TabIndex = 6;
			this.button1.Text = "Kaydet";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ımageList1
			// 
			this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
			this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
			this.ımageList1.Images.SetKeyName(1, "Sil butonu - Kopya.png");
			// 
			// hiddenTedarikciId
			// 
			this.hiddenTedarikciId.Location = new System.Drawing.Point(365, 366);
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
			this.button4.Location = new System.Drawing.Point(610, 436);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(146, 28);
			this.button4.TabIndex = 5;
			this.button4.Text = "Adres Seç";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Visible = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtAdres
			// 
			this.txtAdres.Location = new System.Drawing.Point(9, 263);
			this.txtAdres.Name = "txtAdres";
			this.txtAdres.Size = new System.Drawing.Size(285, 88);
			this.txtAdres.TabIndex = 5;
			this.txtAdres.Text = "";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.SkyBlue;
			this.button2.ImageKey = "Sil butonu - Kopya.png";
			this.button2.ImageList = this.ımageList1;
			this.button2.Location = new System.Drawing.Point(168, 373);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(126, 66);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sil";
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txteposta
			// 
			this.txteposta.Location = new System.Drawing.Point(119, 146);
			this.txteposta.Margin = new System.Windows.Forms.Padding(4);
			this.txteposta.Name = "txteposta";
			this.txteposta.Size = new System.Drawing.Size(175, 27);
			this.txteposta.TabIndex = 3;
			// 
			// txttelefon
			// 
			this.txttelefon.Location = new System.Drawing.Point(119, 202);
			this.txttelefon.Margin = new System.Windows.Forms.Padding(4);
			this.txttelefon.Mask = "(999) 000-0000";
			this.txttelefon.Name = "txttelefon";
			this.txttelefon.Size = new System.Drawing.Size(175, 27);
			this.txttelefon.TabIndex = 4;
			// 
			// txtfirma
			// 
			this.txtfirma.Location = new System.Drawing.Point(119, 34);
			this.txtfirma.Margin = new System.Windows.Forms.Padding(4);
			this.txtfirma.Name = "txtfirma";
			this.txtfirma.Size = new System.Drawing.Size(175, 27);
			this.txtfirma.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label9.Location = new System.Drawing.Point(134, 244);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 27;
			this.label9.Text = "Adres:";
			// 
			// txtad
			// 
			this.txtad.Location = new System.Drawing.Point(119, 90);
			this.txtad.Margin = new System.Windows.Forms.Padding(4);
			this.txtad.Name = "txtad";
			this.txtad.Size = new System.Drawing.Size(175, 27);
			this.txtad.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.Location = new System.Drawing.Point(42, 206);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 18);
			this.label4.TabIndex = 22;
			this.label4.Text = "Telefon:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(40, 150);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 18);
			this.label3.TabIndex = 21;
			this.label3.Text = "E-Posta:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(33, 38);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 18);
			this.label2.TabIndex = 20;
			this.label2.Text = "Firma Ad:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(6, 94);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 18);
			this.label1.TabIndex = 19;
			this.label1.Text = "Ad ve Soyad:";
			// 
			// groupTedarikci
			// 
			this.groupTedarikci.Controls.Add(this.uzanti);
			this.groupTedarikci.Controls.Add(this.txtAdres);
			this.groupTedarikci.Controls.Add(this.button2);
			this.groupTedarikci.Controls.Add(this.button1);
			this.groupTedarikci.Controls.Add(this.txteposta);
			this.groupTedarikci.Controls.Add(this.txttelefon);
			this.groupTedarikci.Controls.Add(this.txtfirma);
			this.groupTedarikci.Controls.Add(this.label9);
			this.groupTedarikci.Controls.Add(this.txtad);
			this.groupTedarikci.Controls.Add(this.label4);
			this.groupTedarikci.Controls.Add(this.label3);
			this.groupTedarikci.Controls.Add(this.label2);
			this.groupTedarikci.Controls.Add(this.label1);
			this.groupTedarikci.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupTedarikci.Location = new System.Drawing.Point(13, 5);
			this.groupTedarikci.Margin = new System.Windows.Forms.Padding(4);
			this.groupTedarikci.Name = "groupTedarikci";
			this.groupTedarikci.Padding = new System.Windows.Forms.Padding(4);
			this.groupTedarikci.Size = new System.Drawing.Size(310, 459);
			this.groupTedarikci.TabIndex = 42;
			this.groupTedarikci.TabStop = false;
			this.groupTedarikci.Text = "Tedarikçi Bilgileri";
			// 
			// gridTedarikci
			// 
			this.gridTedarikci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridTedarikci.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTedarikci.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.gridTedarikci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridTedarikci.DefaultCellStyle = dataGridViewCellStyle11;
			this.gridTedarikci.Location = new System.Drawing.Point(331, 80);
			this.gridTedarikci.Margin = new System.Windows.Forms.Padding(4);
			this.gridTedarikci.Name = "gridTedarikci";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridTedarikci.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.gridTedarikci.RowHeadersWidth = 51;
			this.gridTedarikci.RowTemplate.Height = 24;
			this.gridTedarikci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridTedarikci.Size = new System.Drawing.Size(700, 384);
			this.gridTedarikci.TabIndex = 41;
			this.gridTedarikci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTedarikci_CellClick);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.Location = new System.Drawing.Point(524, 404);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(262, 16);
			this.label5.TabIndex = 39;
			this.label5.Text = "Adres ıd için kullanmıştık kapalı şuan";
			this.label5.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtTelAra);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtmailAra);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.txtAdAra);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.groupBox1.Location = new System.Drawing.Point(331, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(699, 68);
			this.groupBox1.TabIndex = 45;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtre Seçenekleri";
			// 
			// txtTelAra
			// 
			this.txtTelAra.Location = new System.Drawing.Point(538, 33);
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
			this.label13.Location = new System.Drawing.Point(453, 36);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 22);
			this.label13.TabIndex = 43;
			this.label13.Text = "Telefon:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(257, 36);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(52, 22);
			this.label12.TabIndex = 3;
			this.label12.Text = "Mail:";
			// 
			// txtmailAra
			// 
			this.txtmailAra.Location = new System.Drawing.Point(308, 33);
			this.txtmailAra.Name = "txtmailAra";
			this.txtmailAra.Size = new System.Drawing.Size(144, 28);
			this.txtmailAra.TabIndex = 2;
			this.txtmailAra.TextChanged += new System.EventHandler(this.txtmailAra_TextChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(5, 36);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 22);
			this.label11.TabIndex = 1;
			this.label11.Text = "Firma Ad:";
			// 
			// txtAdAra
			// 
			this.txtAdAra.Location = new System.Drawing.Point(107, 33);
			this.txtAdAra.Name = "txtAdAra";
			this.txtAdAra.Size = new System.Drawing.Size(144, 28);
			this.txtAdAra.TabIndex = 0;
			this.txtAdAra.TextChanged += new System.EventHandler(this.txtAdAra_TextChanged);
			// 
			// TedarikciESG
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1046, 482);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button4);
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
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
		private System.Windows.Forms.TextBox txtfirma;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtad;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupTedarikci;
		private System.Windows.Forms.DataGridView gridTedarikci;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ImageList ımageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MaskedTextBox txtTelAra;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtmailAra;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAdAra;
	}
}