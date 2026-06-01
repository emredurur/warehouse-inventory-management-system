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

namespace DepoTakipSistemi
{
    public partial class frmStokGiriş : Form
    {
        public frmStokGiriş()
        {
            InitializeComponent();
        }


        public void temizle()
        {
            txtUrunKodu.Clear();
            txtUrunAdi.Clear();         
            txtMiktar.Clear();
            txtAciklama.Clear();
            txtKritikSeviye.Clear();
            txtBirimFiyat.Clear();
            txtUrunKodu.Focus();

        }



        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void frmStokGiriş_Load(object sender, EventArgs e)
        {
            ComboDoldur();



        }

        public void btnKaydet_Click(object sender, EventArgs e)
        {

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    SqlCommand komut=new SqlCommand("sp_YeniUrunStokGirisi", baglanti);
                    komut.CommandType = CommandType.StoredProcedure;

                    komut.Parameters.AddWithValue("@UrunKodu", txtUrunKodu.Text);
                    komut.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
                    komut.Parameters.AddWithValue("@TedarikciID", cmbTedarikci.SelectedValue);
                    komut.Parameters.AddWithValue("@Miktar", Convert.ToInt32(txtMiktar.Text));
                    komut.Parameters.AddWithValue("@BirimFiyat", Convert.ToDecimal(txtBirimFiyat.Text));
                    komut.Parameters.AddWithValue("@KritikSeviye", Convert.ToInt32(txtKritikSeviye.Text));
                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);         
                    komut.Parameters.AddWithValue("@IslemTarihi", dateTimePicker1.Value); 

                    komut.ExecuteNonQuery();
                    
                    MessageBox.Show("YENİ ÜRÜN STOK GİRİŞİ BAŞARIYLA KAYDEDİLDİ...");
                    temizle();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("HATA: " + ex.Message);
                }

            }



        }


        void ComboDoldur()
        {
            SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi);

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT TedarikciID, FirmaAdi FROM Tedarikciler",
                baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbTedarikci.DataSource = dt;
            cmbTedarikci.DisplayMember = "FirmaAdi";
            cmbTedarikci.ValueMember = "TedarikciID";
        }
        public void cmbTedarikci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStokTipi frmMevcutStokGiris=new frmStokTipi();
            frmMevcutStokGiris.ShowDialog();
        }
    }
}
