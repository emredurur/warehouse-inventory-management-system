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
    public partial class frmStokİşlemleri : Form
    {
        public frmStokİşlemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStokTipi frmStokTipi = new frmStokTipi();
            frmStokTipi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStokÇıkış stokÇıkış = new frmStokÇıkış();
            stokÇıkış.ShowDialog();
        }
    }
}
