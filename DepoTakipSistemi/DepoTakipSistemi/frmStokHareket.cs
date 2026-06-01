using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DepoTakipSistemi
{
    public partial class frmStokHareket : Form
    {
        public frmStokHareket()
        {
            InitializeComponent();
        }

        public void label5_Click(object sender, EventArgs e)
        {

        }


        #region dvgFontStil
        public void dgvStokHareket_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) // dvg font stil
        {
            dgvStokHareket.EnableHeadersVisualStyles = false;

            dgvStokHareket.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvStokHareket.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            dgvStokHareket.RowTemplate.Height = 32;

            foreach (DataGridViewRow row in dgvStokHareket.Rows)
            {
                row.Height = 32;
            }

            dgvStokHareket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion


        public void frmStokHareket_Load(object sender, EventArgs e)
        {

            dgvStokHareket.DataBindingComplete += dgvStokHareket_DataBindingComplete;
            IslemTurGetir();
            tedarikciGetir();
            StokHareketleriniListele();

        }

        public void StokHareketleriniListele()
        {
            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
                                    
                                    SELECT 
                                            Tarih,
                                            IslemTuru AS [İşlem Türü],
                                            UrunKodu AS [Ürün Barkod],
                                            UrunAdi AS [Ürün Adı],
                                            Miktar,
                                            BirimFiyat AS [Birim Fiyat],
                                            ToplamTutar AS [Toplam Tutar],
                                            EvrakNo AS [Evrak No],
                                            KullaniciAdi AS [Kullanıcı],
                                            Tedarikci AS [Tedarikçi]
                                        FROM vw_StokHareketleri
                                        ORDER BY Tarih DESC";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStokHareket.AutoGenerateColumns = true;
                dgvStokHareket.DataSource = dt;
           

            }






        }

     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void TariheVeIslemGoreListele()
        {
            using(SqlConnection baglanti=new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_StokHareketFiltrele", baglanti);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                int hareketTurID = 0;
                int tedarikciID = 0;

                if (cmbIslemTuru.SelectedValue != null)
                    hareketTurID = Convert.ToInt32(cmbIslemTuru.SelectedValue);

                if (cmbTedarikci.SelectedValue != null)
                    tedarikciID = Convert.ToInt32(cmbTedarikci.SelectedValue);

                da.SelectCommand.Parameters.AddWithValue("@BaslangicTarihi", dtpBaslangicTarihi.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@BitisTarihi", dtpBitisTarihi.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@HareketTurID", hareketTurID);
                da.SelectCommand.Parameters.AddWithValue("@UrunKodu", txtUrunKodu.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@TedarikciID", tedarikciID);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStokHareket.AutoGenerateColumns = true;
                dgvStokHareket.DataSource = dt;

            }
        }

        public void IslemTurGetir()
        {

            using(SqlConnection baglanti=new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
                 SELECT HareketTurID , HareketTurAdi
                    FROM StokHareketTurleri
                    ORDER BY HareketTurAdi";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);    

                DataRow yeniSatir=dt.NewRow();
                yeniSatir["HareketTurID"] = 0;
                yeniSatir["HareketTurAdi"] = "Tümü";
                dt.Rows.InsertAt(yeniSatir, 0);

                cmbIslemTuru.DataSource = dt;
                cmbIslemTuru.DisplayMember = "HareketTurAdi";
                cmbIslemTuru.ValueMember = "HareketTurID";
               

            }
        }

        public void tedarikciGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
                        SELECT TedarikciID,FirmaAdi
                        FROM Tedarikciler
                        ORDER BY FirmaAdi";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt=new DataTable();
                da.Fill(dt);

                DataRow tumuSatiri=dt.NewRow();
                tumuSatiri["TedarikciID"] = 0;
                tumuSatiri["FirmaAdi"] = "Tümü";
                dt.Rows.InsertAt(tumuSatiri, 0);

                
                cmbTedarikci.DisplayMember = "FirmaAdi";
                cmbTedarikci.ValueMember = "TedarikciID";
                cmbTedarikci.DataSource = dt;

            }
     }






        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (dtpBaslangicTarihi.Value.Date > dtpBitisTarihi.Value.Date)
            {
                MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.");
                return;
            }
            TariheVeIslemGoreListele();
                     
        }
      

    }
}
