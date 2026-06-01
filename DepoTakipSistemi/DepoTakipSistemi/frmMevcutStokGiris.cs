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
    public partial class frmMevcutStokGiris : Form
    {
        public frmMevcutStokGiris()
        {
            InitializeComponent();
        }
        private void UrunleriYukle()
        {
            using (SqlConnection conn = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string query = @"
                    SELECT
                    UrunID,Gosterim
                    FROM vw_MevcutUrunler
                    ORDER BY UrunAdi";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUrunKodu.DataSource = dt;
                cmbUrunKodu.DisplayMember = "Gosterim";
                cmbUrunKodu.ValueMember = "UrunID";
                cmbUrunKodu.SelectedIndex = -1;
            }
        }
        private void cmbUrunKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrunKodu.SelectedIndex == -1) return;
            if (cmbUrunKodu.SelectedValue is DataRowView) return;

            int urunId = Convert.ToInt32(cmbUrunKodu.SelectedValue);

            using (SqlConnection conn = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string query = @"
                    SELECT
                    UrunAdi,kritikSeviye,MevcutMiktar,FirmaAdi
                    FROM vw_MevcutUrunler
                    WHERE UrunID = @UrunID
                  
                ";

                SqlCommand komut= new SqlCommand(query, conn);
                komut.Parameters.AddWithValue("@UrunID", urunId);

                conn.Open();
                SqlDataReader dr =komut.ExecuteReader();

                if (dr.Read())
                {
                    txtUrunAdi.Text = dr["UrunAdi"].ToString();
                    txtKritikSeviye.Text = dr["KritikSeviye"].ToString();
               
                    cmbTedarikci.Text = dr["FirmaAdi"].ToString();
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUrunKodu.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Miktar pozitif sayı olmalıdır.");
                return;
            }

            if (!decimal.TryParse(txtBirimFiyat.Text, out decimal birimFiyat) || birimFiyat < 0)
            {
                MessageBox.Show("Birim fiyat geçerli olmalıdır.");
                return;
            }

            int urunId = Convert.ToInt32(cmbUrunKodu.SelectedValue);
            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                SqlCommand komut = new SqlCommand("sp_MevcutUrunStokGiris", baglanti);
                komut.CommandType = CommandType.StoredProcedure;

                komut.Parameters.AddWithValue("@UrunID", urunId);
                komut.Parameters.AddWithValue("@KullaniciID", 1);
                komut.Parameters.AddWithValue("@Miktar", miktar);
                komut.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                komut.Parameters.AddWithValue("@IslemTarihi", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                komut.Parameters.AddWithValue("@EvrakNo", Guid.NewGuid().ToString().Substring(0, 8));
                try
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Stok girişi başarıyla kaydedildi.");
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }

        }


        private void Temizle()
        {
            cmbUrunKodu.SelectedIndex = -1;
            txtUrunAdi.Clear();
            txtKritikSeviye.Clear();
            txtMiktar.Clear();
            txtBirimFiyat.Clear();
            txtAciklama.Clear();
            cmbTedarikci.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void frmMevcutStokGiris_Load(object sender, EventArgs e)
        {
            UrunleriYukle();

            txtUrunAdi.ReadOnly = true;
            txtKritikSeviye.ReadOnly = true;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
