using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoTakipSistemi
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            frmTedarikciYonetim tedarikciYonetim = new frmTedarikciYonetim();
            tedarikciYonetim.ShowDialog();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            frmStokİşlemleri stokİşlemleri = new frmStokİşlemleri();
            stokİşlemleri.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmStokHareket stokHareket = new frmStokHareket();
            stokHareket.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmKritikStok kritikStok = new frmKritikStok();
            kritikStok.ShowDialog();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUrunListeleme urunListeleme = new frmUrunListeleme();
            urunListeleme.ShowDialog();
        }
    }
}
