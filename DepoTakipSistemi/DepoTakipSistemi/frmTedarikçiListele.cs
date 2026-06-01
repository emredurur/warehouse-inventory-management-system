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


    public partial class frmTedarikçiListele : Form
    {

        public int seciliTedarikciID = -1;


        public frmTedarikçiListele()
        {
            InitializeComponent();
        }

        public void frmTedarikçiListele_Load(object sender, EventArgs e)
        {
            TedarikcileriListele();
        }

        public void TedarikcileriListele()
        {
            string sorgu = "SELECT * FROM Tedarikciler";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTedarikciler.DataSource = dt;
            }

            //  dgvTedarikciler.Columns["TedarikciID"].HeaderText = "Tedarikçi ID";
            dgvTedarikciler.Columns["FirmaAdi"].HeaderText = "Firma ADI";
            dgvTedarikciler.Columns["AdSoyad"].HeaderText = "Yetkili Kişi";
            dgvTedarikciler.Columns["Telefon"].HeaderText = "Telefon";
            dgvTedarikciler.Columns["Mail"].HeaderText = "E-Posta";
            dgvTedarikciler.Columns["Adres"].HeaderText = "Adres";
        }



        public void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (dgvTedarikciler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir tedarikçi seçin.");
                return;
            }

            int secilenID = Convert.ToInt32(dgvTedarikciler.CurrentRow.Cells["TedarikciID"].Value);

            frmTedarikciGuncelle form = new frmTedarikciGuncelle(secilenID);

            if (form.ShowDialog() == DialogResult.OK)
            {
                TedarikcileriListele();
            }
        }

        private void dgvTedarikciler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void tedarikciSilme_Click(object sender, EventArgs e)
        {

            if (dgvTedarikciler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek bir tedarikçi seçin.");
                return;
            }

            int secilenID = Convert.ToInt32(dgvTedarikciler.CurrentRow.Cells["TedarikciID"].Value);

            DialogResult cevap = MessageBox.Show(
                "Seçili tedarikçiyi silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (cevap == DialogResult.No)
                return;

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            using (SqlCommand komut = new SqlCommand("sp_TedarikciSil", baglanti))
            {
                komut.CommandType = CommandType.StoredProcedure;

                komut.Parameters.AddWithValue("@TedarikciID", secilenID);

                try
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Tedarikçi başarıyla silindi.");
                    TedarikcileriListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }

        }
    }
}

