using System;
using System.Windows.Forms;
using System.Media;

namespace MazeJalma
{
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
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
