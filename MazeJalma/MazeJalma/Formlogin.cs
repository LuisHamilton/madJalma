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
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Formlogin_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += delegate
            {
                this.Hide();
                var form1 = new Form1();
                form1.Show();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
