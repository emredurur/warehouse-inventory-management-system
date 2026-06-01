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
    public partial class frmTedarikciGuncelle : Form
    {
        
        int tedarikciID;
     
        public void TedarikciBilgileriniGetir()
        {

            string sorgu = "SELECT * FROM Tedarikciler WHERE TedarikciID = @TedarikciID";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@TedarikciID", tedarikciID);

                try
                {
                    baglanti.Open();
                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        txtFirmaAdi.Text = dr["FirmaAdi"].ToString();
                        txtYetkiliKişi.Text = dr["AdSoyad"].ToString();
                        txtTelefon.Text = dr["Telefon"].ToString();
                        txtEposta.Text = dr["Mail"].ToString();
                        txtAdres.Text = dr["Adres"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Tedarikçi bulunamadı.");
                        this.Close();
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }


        public frmTedarikciGuncelle(int gelenTedarikciID)
        {
            InitializeComponent();
            tedarikciID = gelenTedarikciID;
        }

        public void frmTedarikciGuncelle_Load(object sender, EventArgs e)
        {
            TedarikciBilgileriniGetir();
        }




        public void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Firma adı boş bırakılamaz.");
                return;
            }

            string sorgu = @"UPDATE Tedarikciler
                     SET FirmaAdi = @FirmaAdi,
                         AdSoyad = @AdSoyad,
                         Telefon = @Telefon,
                         Mail = @Mail,
                         Adres = @Adres
                     WHERE TedarikciID = @TedarikciID";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@FirmaAdi", txtFirmaAdi.Text.Trim());
                komut.Parameters.AddWithValue("@AdSoyad", txtYetkiliKişi.Text.Trim());
                komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Trim());
                komut.Parameters.AddWithValue("@Mail", txtEposta.Text.Trim());
                komut.Parameters.AddWithValue("@Adres", txtAdres.Text.Trim());
                komut.Parameters.AddWithValue("@TedarikciID", tedarikciID);

                try
                {
                    baglanti.Open();
                    int etkilenenSatir = komut.ExecuteNonQuery();

                    if (etkilenenSatir > 0)
                    {
                        MessageBox.Show("Tedarikçi başarıyla güncellendi.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme yapılamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }

        }
       
    }
}
