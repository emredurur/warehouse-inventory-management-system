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
    public partial class frmStokÇıkış : Form
    {
        public frmStokÇıkış()
        {
            InitializeComponent();
        }

        private void frmStokÇıkış_Load(object sender, EventArgs e)
        {
            ComboDoldur();
            dateTimePicker1.Value = DateTime.Now;

            cmbUrunAdi.SelectedIndexChanged += cmbUrunAdi_SelectedIndexChanged;

            if (cmbUrunAdi.SelectedValue != null)
                MevcutStokGoster();
        }

        public void temizle()
        {
            txtMiktar.Clear();
            txtBirimFiyat.Clear();
            txtAciklama.Clear();
            dateTimePicker1.Value = DateTime.Now;

            if (cmbUrunAdi.Items.Count > 0)
                cmbUrunAdi.SelectedIndex = 0;
        }

        void ComboDoldur()
        {
            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
                    SELECT 
                        UrunID,
                        UrunKodu + ' - ' + UrunAdi AS UrunGosterim
                    FROM Urunler
                    ORDER BY UrunAdi";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUrunAdi.DataSource = dt;
                cmbUrunAdi.DisplayMember = "UrunGosterim";
                cmbUrunAdi.ValueMember = "UrunID";
            }
        }

        private bool FormKontrol(out int miktar, out decimal birimFiyat)
        {
            miktar = 0;
            birimFiyat = 0;

            if (cmbUrunAdi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
                return false;
            }

            if (!int.TryParse(txtMiktar.Text, out miktar))
            {
                MessageBox.Show("Miktar sayısal bir değer olmalıdır.");
                return false;
            }

            if (miktar <= 0)
            {
                MessageBox.Show("Miktar sıfırdan büyük olmalıdır.");
                return false;
            }

            if (!decimal.TryParse(txtBirimFiyat.Text, out birimFiyat))
            {
                MessageBox.Show("Birim fiyat sayısal bir değer olmalıdır.");
                return false;
            }

            if (birimFiyat <= 0)
            {
                MessageBox.Show("Birim fiyat sıfırdan büyük olmalıdır.");
                return false;
            }

            return true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!FormKontrol(out int miktar, out decimal birimFiyat))
                return;

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
                {
                    baglanti.Open();

                    using (SqlCommand komut = new SqlCommand("sp_StokCikisYap", baglanti))
                    {
                        komut.CommandType = CommandType.StoredProcedure;

                        komut.Parameters.AddWithValue("@UrunID", Convert.ToInt32(cmbUrunAdi.SelectedValue));
                        komut.Parameters.AddWithValue("@KullaniciID", 1);
                        komut.Parameters.AddWithValue("@Miktar", miktar);
                        komut.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                        komut.Parameters.AddWithValue("@IslemTarihi", dateTimePicker1.Value);
                        komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());

                        komut.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Stok çıkışı başarıyla yapıldı.");
                temizle();
                ComboDoldur();
                MevcutStokGoster();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrunAdi.SelectedValue == null)
                return;

            if (cmbUrunAdi.SelectedValue is DataRowView)
                return;

            MevcutStokGoster();
        }
        private void MevcutStokGoster()
        {
            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
            SELECT MevcutMiktar
            FROM Urunler
            WHERE UrunID = @UrunID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@UrunID", Convert.ToInt32(cmbUrunAdi.SelectedValue));

                baglanti.Open();

                object sonuc = komut.ExecuteScalar();

                if (sonuc != null)
                {
                    lblMevcutStok.Text = "Mevcut stok: " + sonuc.ToString() + " adet";
                }
                else
                {
                    lblMevcutStok.Text = "Mevcut stok: -";
                }
            }
        }
    }
}
