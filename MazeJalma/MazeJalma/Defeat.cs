using System;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;

namespace MazeJalma
{
    public partial class Defeat : Form
    {
        int som = 1;

        public Defeat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sound1()
        {
            SoundPlayer som = new SoundPlayer(Properties.Resources.tome);
            som.Play();
        }
        private void sound2()
        {
            SoundPlayer som = new SoundPlayer(Properties.Resources.ele_gosta);
            som.Play();
        }
        private void sound3()
        {
            SoundPlayer som = new SoundPlayer(Properties.Resources.demais);
            som.Play();
        }

        private void Defeat_Load(object sender, EventArgs e)
        {
            Timer tm = new Timer();
            tm.Interval = 2000;
            tm.Tick += delegate
            {
                switch(som)
                {
                    case 1:
                        som = 2;
                        sound1();
                        break;
                    case 2:
                        som = 3;
                        sound2();
                        break;
                    case 3:
                        som = 1;
                        sound3();
                        break;
                }
            };
            tm.Start();
        }
    }
}
