using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DepoTakipSistemi
{
    public partial class frmTedarikciYonetim : Form
    {



        public frmTedarikciYonetim()
        {
            InitializeComponent();
        }

        public void txtFirmaAdi_TextChanged(object sender, EventArgs e)
        {

        }

        public void frmTedarikciYonetim_Load(object sender, EventArgs e)
        {


        }




        public void Temizle()
        {
            txtFirmaAdi.Clear();
            txtYetkiliKişi.Clear();
            txtTelefon.Clear();
            txtEposta.Clear();
            txtAdres.Clear();

            txtFirmaAdi.Focus();
        }
        public void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Firma adı boş bırakılamaz.");
                return;
            }

            string sorgu = @"INSERT INTO Tedarikciler
                     (FirmaAdi, AdSoyad, Telefon, Mail, Adres)
                     VALUES
                     (@FirmaAdi, @AdSoyad, @Telefon, @Mail, @Adres)";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@FirmaAdi", txtFirmaAdi.Text.Trim());
                    komut.Parameters.AddWithValue("@AdSoyad", txtYetkiliKişi.Text.Trim());
                    komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Trim());
                    komut.Parameters.AddWithValue("@Mail", txtEposta.Text.Trim());
                    komut.Parameters.AddWithValue("@Adres", txtAdres.Text.Trim());

                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi başarıyla eklendi.");
                        Temizle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }


                }



            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frmTedarikçiListele tedarikciDetayFormu = new frmTedarikçiListele();
            tedarikciDetayFormu.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
