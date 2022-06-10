using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeJalma
{
    public partial class Initial : Form
    {
        Formlogin frm1 = new Formlogin();
        FrmLoad frm2 = new FrmLoad();

        public Initial()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm1.Show();
        }
    }
}
