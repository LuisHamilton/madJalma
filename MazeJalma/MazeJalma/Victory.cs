using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;

namespace MazeJalma
{
    public partial class Victory : Form
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

        public Victory()
        {
            InitializeComponent();

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

                loreLabel.Text = "Obrigado por nos salvar, você é o melhor!!!";
            };
        }

        public void soundVic()
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.ele_gosta);
            sound.Play();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
