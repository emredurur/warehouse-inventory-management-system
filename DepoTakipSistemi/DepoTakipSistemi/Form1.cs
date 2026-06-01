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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e) // giriş butonu 
        {


            string sorgu = "SELECT Count(*) FROM Kullanici WHERE KullaniciAdi=@KullaniciAdi AND Sifre= @Sifre";

            using (SqlConnection baglanti = new SqlConnection(baglanti_sql.baglantiCumlesi))
            {
               using(SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
                    komut.Parameters.AddWithValue("@Sifre", textBox2.Text);
                    baglanti.Open();
                    int sonuc = (int)komut.ExecuteScalar();
                    if (sonuc > 0)
                    {
                        frmAnaSayfa anaSayfa = new frmAnaSayfa();
                        anaSayfa.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                    }
                }
            }





           
        }

            

        
    }
}
