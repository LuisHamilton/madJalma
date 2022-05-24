using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeJalma
{

    public partial class Form1 : Form
    {
        bool moveRight,moveLeft,moveUp,moveDown;

        private Bitmap soldierimage = Properties.Resources.survivor_move_knife_12;
        private Bitmap mapimage = Properties.Resources.background;
        private Bitmap coinimage = Properties.Resources.coin;
        private Graphics g2 = null;

        Bitmap bmp = null;
        Bitmap btmp = null;
        int speedx = 0;
        int speedy = 0;
        int speedcX = 0;
        int speedcY = 0;
        int pontos = 0;

        Player playerEvents;

        public Form1()
        {
            InitializeComponent();

            int x = 0;
            int y = 0;
            int coinX = 1000;
            int coinY = 1000;

            Timer tm = new Timer();
            tm.Interval = 20;


            this.Load += delegate
            {
                score.Text = $"{pontos}";
                pictureBox2.SendToBack();
                g2 = Graphics.FromImage(pictureBox2.Image);
                playerEvents = new Player(g2);
                tm.Start();
            };
            this.KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Application.Exit();
                        break;
                    case Keys.A:
                        speedx = -18;
                        speedcX = 18;
                        break;
                    case Keys.D:
                        speedx = 18;
                        speedcX = -18;
                        break;
                    case Keys.W:
                        speedy = -18;
                        speedcY = 18;
                        break;
                    case Keys.S:
                        speedy = 18;
                        speedcY = -18;
                        break;
                }
            };
            this.KeyUp += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Application.Exit();
                        break;
                    case Keys.A:
                        speedx = 0;
                        speedcX = 0;
                        break;
                    case Keys.D:
                        speedx = 0;
                        speedcX = 0;
                        break;
                    case Keys.W:
                        speedy = 0;
                        speedcY = 0;
                        break;
                    case Keys.S:
                        speedy = 0;
                        speedcY = 0;
                        break;
                }
            };
            tm.Tick += delegate
            {
                x += speedx;
                y += speedy;
                coinX += speedcX;
                coinY += speedcY;
                if (x < 0)
                    x = 0;
                if (y < 0)
                    y = 0;
                playerEvents.mapMove(x, y, mapimage, pictureBox2);
                playerEvents.coinMove(coinimage, coinX, coinY);
                playerEvents.rotateSoldier(angle, soldierimage, pictureBox2);
                pictureBox2.Refresh();
                
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        float angle = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point center = new Point(this.Width / 2, this.Height / 2);
            angle = (float)Math.Atan2(e.Y - center.Y, e.X - center.X) * (float)(180 / Math.PI);
        }
    }
}
