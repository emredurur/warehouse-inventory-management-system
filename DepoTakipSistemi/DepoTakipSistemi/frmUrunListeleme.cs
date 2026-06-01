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
    public partial class frmUrunListeleme : Form
    {
        public frmUrunListeleme()
        {
            InitializeComponent();
        }


        private void frmUrunListeleme_Load(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            string sorgu = @"
                SELECT
                    UrunID,
                    UrunKodu,
                    UrunAdi,
                    MevcutMiktar,
                    KritikSeviye,
                    Tedarikci,
                    SonAlisFiyati,
                    AktifMi
                FROM vw_UrunListeDetay
                ORDER BY UrunAdi";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUrunler.DataSource = dt;
            }

            dgvUrunler.Columns["UrunID"].Visible = false;

            dgvUrunler.Columns["UrunKodu"].HeaderText = "Ürün Kodu";
            dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dgvUrunler.Columns["MevcutMiktar"].HeaderText = "Mevcut Miktar";
            dgvUrunler.Columns["KritikSeviye"].HeaderText = "Kritik Seviye";
            dgvUrunler.Columns["Tedarikci"].HeaderText = "Tedarikçi";
            dgvUrunler.Columns["SonAlisFiyati"].HeaderText = "Son Alış Fiyatı";
            dgvUrunler.Columns["AktifMi"].HeaderText = "Aktif Mi";

            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.ReadOnly = true;
            dgvUrunler.AllowUserToAddRows = false;
        }
    }
}
