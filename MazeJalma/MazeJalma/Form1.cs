using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace MazeJalma
{

    public partial class Form1 : Form
    {
        //all elements images to bitmaps
        private Bitmap soldierimage = Properties.Resources.shooting;
        private Bitmap mapimage = Properties.Resources.imagemBack;
        private Bitmap ottoimage = Properties.Resources.otto;
        private Bitmap ammoimage = Properties.Resources.ammoImg;
        private Bitmap botimage = Properties.Resources.survivor_move_knife_12;

        private Graphics g2 = null;

        int speedx = 0; int speedy = 0;//move for player
        int pMove = 54; int pStop = 0;//states of player movement
        int speedcX = 0; int speedcY = 0; //move for elements
        int speed = 37; int health; //bot
        int pontos = 20; int municao = 0; //hud
        int col = 0; int col2 = 0; int col3 = 0; //collision
        int ottoX = 0; int ottoY = 0; //otto location
        int ammoX = 0; int ammoY = 0; //ammo location
        float botX = 0; float botY = 0; //edjalma location
        float angle = 0; float angle2 = 0; float angle3 = 0; //angles for rotation
        bool click = false; //shoot

        Random randX = new Random(); 
        Random randY = new Random();

        Rectangle soldierRect; //player hitbox
        Rectangle botRect; //edjalma hitbox
        RectangleF bulletRect; //shot hitbox
        Point radarCenter; 
        PointF botLoc; //edjalma location
        SizeF botSpeed; //edjalma track

        Player playerEvents;
        Otto ottoEvents;
        Bullet bulletEvents;
        Ammo ammoEvents;
        Bot botEvents;
        Radar radarEvents;
        Spawn spawnEvents;

        Victory frm1;
        Defeat frm2;

        public Form1()
        {
            InitializeComponent();

            int x = 0; //screen&player location
            int y = 0;

            health = 100;
            healthBar.Value = 100;
            ottoX = randX.Next(1000, 8000); ottoY = randY.Next(1000, 8000); //first otto spawn
            ammoX = randX.Next(1000, 8000); ammoY = randY.Next(1000, 8000); //first ammo spawn
            botX = 8720; botY = 8355; //first edjalma spawn
            botSpeed = new SizeF(ottoX, ottoY);
            botLoc = new PointF(botX, botY);

            int middleX = this.Width / 2; //exactly center od the screen
            int middleY = this.Height / 2;

            Timer tm = new Timer();
            tm.Interval = 20; //game in 20fps

            this.Load += delegate
            {
                pictureBox2.SendToBack();

                g2 = Graphics.FromImage(pictureBox2.Image);

                frm1 = new Victory();
                frm2 = new Defeat();

                playerEvents = new Player(g2);
                spawnEvents = new Spawn();
                ottoEvents = new Otto(g2);
                ammoEvents = new Ammo(g2);
                botEvents = new Bot(g2);
                radarEvents = new Radar(g2);
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
                        speedx = -pMove;
                        speedcX = pMove;
                        break;
                    case Keys.D:
                        speedx = pMove;
                        speedcX = -pMove;
                        break;
                    case Keys.W:
                        speedy = -pMove;
                        speedcY = pMove;
                        break;
                    case Keys.S:
                        speedy = pMove;
                        speedcY = -pMove;
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
                        speedx = pStop;
                        speedcX = pStop;
                        break;
                    case Keys.D:
                        speedx = pStop;
                        speedcX = pStop;
                        break;
                    case Keys.W:
                        speedy = pStop;
                        speedcY = pStop;
                        break;
                    case Keys.S:
                        speedy = pStop;
                        speedcY = pStop;
                        break;
                }
            };
            tm.Tick += delegate
            {
                //ensures elements stay in his location
                botSpeed = new SizeF(ottoX, ottoY); 
                x += speedx; y += speedy;
                ottoX += speedcX; ottoY += speedcY;
                ammoX += speedcX; ammoY += speedcY;

                //ensures elements stay still when player hit max length of the map in any ways
                if (x < 0) { x = 0; ottoX -= speedcX; ammoX -= speedcX; botX -= speedcX; }
                if (y < 0){ y = 0; ottoY -= speedcY; ammoY -= speedcY; botY -= speedcY; }
                if (x >= 8820){ x = 8820; ottoX -= speedcX; ammoX -= speedcX; botX -= speedcX; }
                if (y >= 8455) { y = 8455; ottoY -= speedcY; ammoY -= speedcY; botY -= speedcY; }

                //update hud labels
                score.Text = $"{pontos -= col}";
                lblAmmo.Text = $"{municao+=col2*3}";

                if(pontos == 0)
                {
                    this.Hide();
                    frm2.FormClosed += (s, args) => this.Close();
                    frm2.Show();
                    tm.Stop();
                }

                /* classes methods */

                //player move
                playerEvents.mapMove(x, y, mapimage, pictureBox2);
                //otto
                ottoEvents.ottoMove(ottoimage, ottoX, ottoY);
                radarCenter = new Point(80, 150);
                //ammo
                ammoEvents.ammoMove(ammoimage, ammoX, ammoY);
                angle3 = (float)Math.Atan2(ammoY  - ammoimage.Height/4 - radarCenter.Y, ammoX - ammoimage.Width - radarCenter.X) * (float)(180 / Math.PI);
                //edjalma
                botLoc.X = botX; botLoc.Y = botY;
                botLoc = botEvents.update(botLoc, botSpeed, speed);
                botX = botLoc.X; botY = botLoc.Y;
                botRect = botEvents.botMove(botimage, (int)botX, (int)botY);
                angle2 = (float)Math.Atan2(botY - radarCenter.Y, botX - radarCenter.X) * (float)(180 / Math.PI);
                //radar
                radarEvents.Draw();
                radarEvents.rotateBotRadar(angle2);
                radarEvents.rotateAmmoRadar(angle3);
                //player rotation
                soldierRect = playerEvents.rotateSoldier(angle, soldierimage, pictureBox2);

                //update bullet movement
                if (bulletEvents != null)
                {
                    bulletEvents.Update();
                    bulletRect = bulletEvents.Draw();
                }

                //shoot
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
                    else
                    {
                        playNoBulletSound();
                    }
                }

                //edjalma takes otto
                col = ottoEvents.collisionOtto(botRect);
                if (col == 1)
                {
                    ottoX = spawnEvents.coordenada(x);
                    ottoY = spawnEvents.coordenada(y);
                }
                //player takes ammo
                col2 = ammoEvents.collisionAmmo(soldierRect);
                if (col2 == 1)
                {
                    ammoX = spawnEvents.coordenada(x);
                    ammoY = spawnEvents.coordenada(y);
                }
                //player shoot edjalma
                col3 = botEvents.killBot(bulletRect);
                if (col3 == 1)
                {
                    health -= 34;
                    if (health <= 0)
                    {
                        this.Hide();
                        frm1.FormClosed += (s, args) => this.Close();
                        frm1.Show();
                        tm.Stop();
                    }
                    else
                        healthBar.Value = health;
                        
                    botX = spawnEvents.coordenada(x);
                    botY = spawnEvents.coordenada(y);
                }

                pictureBox2.Refresh();
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //detect player command to shoot
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            click = true;
        }

        //detect player's aim
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
        private void playNoBulletSound()
        {
            SoundPlayer noBullet = new SoundPlayer(Properties.Resources.audioSemMuni);
            noBullet.Play();
        }
    }
}
