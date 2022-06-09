using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MazeJalma
{
    public partial class Menu : Form
    {
        private Bitmap ottoImg = Properties.Resources.otto;
        private Bitmap ottoImg2 = Properties.Resources.otto;
        private Bitmap ottoImg3 = Properties.Resources.otto;
        private Bitmap ottoImg4 = Properties.Resources.otto;
        private Bitmap ottoImg5 = Properties.Resources.otto;
        private Bitmap ottoImg6 = Properties.Resources.otto;
        private Bitmap ottoImg7 = Properties.Resources.otto;
        private Bitmap ottoImg8 = Properties.Resources.otto;
        private Bitmap ottoImg9 = Properties.Resources.otto;
        private Bitmap ottoImg10 = Properties.Resources.otto;

        private Graphics g = null;

        Otto ottoEvents;
        Formlogin frm = new Formlogin();
        SoundPlayer som = new SoundPlayer(Properties.Resources.mine);

        public Menu()
        {
            InitializeComponent();



            Timer tm = new Timer();
            tm.Interval = 20;

            this.Load += delegate
            {
                g = Graphics.FromImage(this.BackgroundImage);

                ottoEvents = new Otto(g);

                ottoEvents.menuOtto(ottoImg, 150, 320);
                ottoEvents.menuOtto(ottoImg2, 200, 320);
                ottoEvents.menuOtto(ottoImg3, 250, 320);
                ottoEvents.menuOtto(ottoImg4, 300, 320);
                ottoEvents.menuOtto(ottoImg5, 350, 320);
                ottoEvents.menuOtto(ottoImg6, 400, 320);
                ottoEvents.menuOtto(ottoImg7, 450, 320);
                ottoEvents.menuOtto(ottoImg8, 500, 320);
                ottoEvents.menuOtto(ottoImg9, 550, 320);
                ottoEvents.menuOtto(ottoImg10, 600, 320);

                sound();

                tm.Start();
            };
            tm.Tick += delegate
            {

                loreLabel.Text = "Esses são os ottos...";
                Task.Delay(2000).Wait();
                loreLabel.Text = "Robôs amigos que precisam de ajuda...";
                Task.Delay(2000).Wait();
                loreLabel.Text = "Um inimigo gosta deles e procura sequestrá-los...";
                Task.Delay(3000).Wait();
                loreLabel.Text = "Você tem uma bússola, a ponteira amarela é munição, e a vermelha é ele...";
                Task.Delay(5000).Wait();
                this.Hide();
                frm.Show();
                tm.Stop();
            };
        }
        public void sound()
        {
            som.Play();
        }
    }
}
