using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace MazeJalma
{

    public partial class Form1 : Form
    {
        private Bitmap soldierimage = Properties.Resources.shooting;
        private Bitmap mapimage = Properties.Resources.grama;
        private Bitmap coinimage = Properties.Resources.coin;
        private Bitmap ammoimage = Properties.Resources.ammoImg;
        private Bitmap botimage = Properties.Resources.survivor_move_knife_12;

        private Graphics g2 = null;

        int speedx = 0; int speedy = 0;
        int speedcX = 0; int speedcY = 0;
        int speed = 32;
        int pontos = 0;
        int municao = 0;
        int col = 0; int col2 = 0;
        int coinX = 0; int coinY = 0;
        int ammoX = 0; int ammoY = 0;
        float botX = 0; float botY = 0;
        bool spawn = false; bool spawn2 = false;
        bool click = false;

        Random randX = new Random();
        Random randY = new Random();

        Rectangle soldierRect;
        PointF botLoc;
        SizeF botSpeed;

        Player playerEvents;
        Coin coinEvents;
        Bullet bulletEvents;
        Ammo ammoEvents;
        Bot botEvents;

        public Form1()
        {
            InitializeComponent();

            int x = 0;
            int y = 0;

            coinX = randX.Next(2000, 8000); coinY = randY.Next(2000, 8000);
            ammoX = randX.Next(2000, 8000); ammoY = randY.Next(2000, 8000);
            botX = 8720; botY = 8355;
            botSpeed = new SizeF(coinX, coinY);
            botLoc = new PointF(botX, botY);

            int middleX = this.Width / 2;
            int middleY = this.Height / 2;

            Timer tm = new Timer();
            tm.Interval = 20;

            this.Load += delegate
            {
                pictureBox2.SendToBack();

                g2 = Graphics.FromImage(pictureBox2.Image);

                playerEvents = new Player(g2);
                coinEvents = new Coin(g2);
                ammoEvents = new Ammo(g2);
                botEvents = new Bot(g2);
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
                        speedx = -32;
                        speedcX = 32;
                        break;
                    case Keys.D:
                        speedx = 32;
                        speedcX = -32;
                        break;
                    case Keys.W:
                        speedy = -32;
                        speedcY = 32;
                        break;
                    case Keys.S:
                        speedy = 32;
                        speedcY = -32;
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
                botSpeed = new SizeF(coinX, coinY);
                x += speedx; y += speedy;
                coinX += speedcX; coinY += speedcY;
                ammoX += speedcX; ammoY += speedcY;
                //botX -= speedcX; botY -= speedcY;

                if (x < 0){ x = 0; coinX -= speedcX; ammoX -= speedcX; botX -= speedcX; }
                if (y < 0){ y = 0; coinY -= speedcY; ammoY -= speedcY; botY -= speedcY; }
                if (x >= 8820){ x = 8820; coinX -= speedcX; ammoX -= speedcX; botX -= speedcX; }
                if (y >= 8455) { y = 8455; coinY -= speedcY; ammoY -= speedcY; botY -= speedcY; }

                score.Text = $"{pontos+=col}";
                lblAmmo.Text = $"{municao += col2*3}";
                lblKill.Text = $"{botX} - {botY}";

                playerEvents.mapMove(x, y, mapimage, pictureBox2);
                coinEvents.coinMove(coinimage, coinX, coinY);
                ammoEvents.ammoMove(ammoimage, ammoX, ammoY);

                botLoc = botEvents.update(botLoc, botSpeed, speed);
                botX = botLoc.X; botY = botLoc.Y;
                botEvents.botMove(botimage, (int)botX, (int)botY);

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
                        botSpeed = new SizeF(coinX, coinY);
                        spawn = true;
                    }
                    else
                    {
                        coinX = randX.Next(0 - x + 700, 1660 - x);
                        coinY = randY.Next(0 - y + 700, 720 - y);
                        botSpeed = new SizeF(coinX, coinY);
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
                        ammoX = randX.Next(0 - x + 700, 1660 - x);
                        ammoY = randY.Next(0 - y + 700, 720 - y);
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
