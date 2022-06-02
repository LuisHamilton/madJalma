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
using System.Media;

namespace MazeJalma
{

    public partial class Form1 : Form
    {
        private Bitmap soldierimage = Properties.Resources.survivor_move_knife_12;
        private Bitmap mapimage = Properties.Resources.background;
        private Bitmap coinimage = Properties.Resources.coin;
        private Bitmap ammoimage = Properties.Resources.ammoImg;
        private Graphics g2 = null;

        int speedx = 0;
        int speedy = 0;
        int speedcX = 0;
        int speedcY = 0;
        int pontos = 0;
        int municao = 0;
        int col = 0;
        int col2 = 0;
        int coinX = 0;
        int coinY = 0;
        int ammoX = 0;
        int ammoY = 0;
        bool spawn = false;
        bool spawn2 = false;
        bool click = false;

        Random randX = new Random();
        Random randY = new Random();

        Rectangle soldierRect;

        Player playerEvents;
        Coin coinEvents;
        Bullet bulletEvents;
        Ammo ammoEvents;

        public Form1()
        {
            InitializeComponent();

            int x = 0;
            int y = 0;

            coinX = randX.Next(500, 2660);
            coinY = randY.Next(500, 1620);
            ammoX = randX.Next(500, 2660);
            ammoY = randY.Next(500, 1620);

            int middleX = this.Width / 2;
            int middleY = this.Height / 2;

            Timer tm = new Timer();
            tm.Interval = 20;

            this.Load += delegate
            {
                score.Text = $"{pontos}";

                pictureBox2.SendToBack();

                g2 = Graphics.FromImage(pictureBox2.Image);

                playerEvents = new Player(g2);
                coinEvents = new Coin(g2);
                ammoEvents = new Ammo(g2);
                bulletEvents = null;

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
                ammoX += speedcX;
                ammoY += speedcY;

                if (x < 0){ x = 0; coinX -= speedcX; }
                if (y < 0){ y = 0; coinY -= speedcY; }
                if (x >= 2660){ x = 2660; coinX -= speedcX; }
                if (y >= 1620) { y = 1620; coinY -= speedcY; }
                if (x >= 2660) { x = 2660; ammoX -= speedcX; }
                if (y >= 1620) { y = 1620; ammoY -= speedcY; }

                score.Text = $"{pontos+=col}";
                lblAmmo.Text = $"{municao += col2*3}";
                
                playerEvents.mapMove(x, y, mapimage, pictureBox2);
                coinEvents.coinMove(coinimage, coinX, coinY);
                ammoEvents.ammoMove(ammoimage, ammoX, ammoY);
                soldierRect = playerEvents.rotateSoldier(angle, soldierimage, pictureBox2);

                if (bulletEvents != null)
                {
                    bulletEvents.Update();
                    bulletEvents.Draw();
                }

                if (click)
                {
                    click = false;
                    if(municao>0)
                    {
                        playShootSound();
                        municao--;
                        bulletEvents = new Bullet(g2, new PointF(middleX, middleY), 
                            (float)Math.Cos(angle * (2 * Math.PI) / 360f),
                            (float)Math.Sin(angle * (2 * Math.PI) / 360f));
                    }
                }
                
                col = coinEvents.collisionCoin(soldierRect);
                if(col == 1)
                {
                    if (spawn == false)
                    {
                        coinX = randX.Next(1660 - x, 2660 - x);
                        coinY = randY.Next(620 - y, 1620 - y);
                        spawn = true;
                    }
                    else
                    {
                        coinX = randX.Next(0 - x + 500, 1660 - x);
                        coinY = randY.Next(0 - y + 500, 620 - y);
                        spawn = false;
                    }
                }
                col2 = ammoEvents.collisionAmmo(soldierRect);
                if (col2 == 1)
                {
                    if (spawn2 == false)
                    {
                        ammoX = randX.Next(1660 - x, 2660 - x);
                        ammoY = randY.Next(620 - y, 1620 - y);
                        spawn2 = true;
                    }
                    else
                    {
                        ammoX = randX.Next(0 - x + 500, 1660 - x);
                        ammoY = randY.Next(0 - y + 500, 620 - y);
                        spawn2 = false;
                    }
                }

                pictureBox2.Refresh();
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        float angle = 0;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            click = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point center = new Point(this.Width / 2, this.Height / 2);
            angle = (float)Math.Atan2(e.Y - center.Y, e.X - center.X) * (float)(180 / Math.PI);
        }
        private void playShootSound()
        {
            SoundPlayer shootSound = new SoundPlayer(Properties.Resources.tiro);
            shootSound.Play();
        }
    }
}
