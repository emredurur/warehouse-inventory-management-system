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
    public partial class frmKritikStok : Form
    {
        public frmKritikStok()
        {
            InitializeComponent();
        }


        public void KritikStoklarıListele()
        {

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
                string sorgu = @"
               SELECT 
                [Ürün Kodu],
                [Ürün Adı],
                [Mevcut Miktar],
                [Kritik Seviye],
                [Tedarikçi]
            FROM vw_KritikStoklar
            ORDER BY [Mevcut Miktar] ASC";


                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvKritikStok.Columns.Clear();
                dgvKritikStok.AutoGenerateColumns = true;
                dgvKritikStok.DataSource = dt;

                KritikSatirlariRenklendir();
            }
        }
             private void KritikSatirlariRenklendir()
              {
               
                        foreach (DataGridViewRow row in dgvKritikStok.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int mevcutMiktar = Convert.ToInt32(row.Cells["Mevcut Miktar"].Value);
                            int kritikSeviye = Convert.ToInt32(row.Cells["Kritik Seviye"].Value);

                            if (mevcutMiktar < kritikSeviye) // Kritik seviyenin altındaysa kırmızı renkle vurguluyorum
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                row.DefaultCellStyle.ForeColor = Color.White;
                            }
                            else if (mevcutMiktar == kritikSeviye)
                            {
                                row.DefaultCellStyle.BackColor = Color.Orange;
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
              }




        private void frmKritikStok_Load(object sender, EventArgs e)
        {
          
            KritikStoklarıListele();
        }
    }
}
