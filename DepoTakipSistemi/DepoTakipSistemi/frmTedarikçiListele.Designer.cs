namespace DepoTakipSistemi
{
    partial class frmTedarikçiListele
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dgvTedarikciler = new System.Windows.Forms.DataGridView();
            this.tedarikciSilme = new System.Windows.Forms.Button();
            this.FirmaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTedarikciler)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(857, 163);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(219, 62);
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "GÜNCELLEME";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // dgvTedarikciler
            // 
            this.dgvTedarikciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTedarikciler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirmaAdi,
            this.AdSoyad,
            this.Telefon,
            this.Mail,
            this.Adres});
            this.dgvTedarikciler.Location = new System.Drawing.Point(21, 74);
            this.dgvTedarikciler.Name = "dgvTedarikciler";
            this.dgvTedarikciler.Size = new System.Drawing.Size(799, 427);
            this.dgvTedarikciler.TabIndex = 14;
            this.dgvTedarikciler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTedarikciler_CellContentClick);
            // 
            // tedarikciSilme
            // 
            this.tedarikciSilme.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tedarikciSilme.Location = new System.Drawing.Point(857, 282);
            this.tedarikciSilme.Name = "tedarikciSilme";
            this.tedarikciSilme.Size = new System.Drawing.Size(219, 62);
            this.tedarikciSilme.TabIndex = 15;
            this.tedarikciSilme.Text = "SİL";
            this.tedarikciSilme.UseVisualStyleBackColor = true;
            this.tedarikciSilme.Click += new System.EventHandler(this.tedarikciSilme_Click);
            // 
            // FirmaAdi
            // 
            this.FirmaAdi.DataPropertyName = "FirmaAdi";
            this.FirmaAdi.HeaderText = "Firma ADI";
            this.FirmaAdi.Name = "FirmaAdi";
            this.FirmaAdi.ReadOnly = true;
            this.FirmaAdi.Width = 135;
            // 
            // AdSoyad
            // 
            this.AdSoyad.DataPropertyName = "AdSoyad";
            this.AdSoyad.HeaderText = "Yetkili Kişi";
            this.AdSoyad.Name = "AdSoyad";
            this.AdSoyad.ReadOnly = true;
            this.AdSoyad.Width = 135;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            this.Telefon.Width = 135;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "E-Posta";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 135;
            // 
            // Adres
            // 
            this.Adres.DataPropertyName = "Adres";
            this.Adres.HeaderText = "Adres";
            this.Adres.Name = "Adres";
            this.Adres.ReadOnly = true;
            this.Adres.Width = 135;
            // 
            // frmTedarikçiListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 513);
            this.Controls.Add(this.tedarikciSilme);
            this.Controls.Add(this.dgvTedarikciler);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTedarikçiListele";
            this.Text = "frmTedarikçiListele";
            this.Load += new System.EventHandler(this.frmTedarikçiListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTedarikciler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView dgvTedarikciler;
        private System.Windows.Forms.Button tedarikciSilme;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirmaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adres;
    }
}