using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazeJalma
{
    public class Bot
    {
        private Graphics g;
        private Random rand = new Random();
        private Rectangle botRect;
        float angle = 0; 
        float dt = 0;
        float botX = 0; float botY = 0;
        Bullet bulletEvents = null;

        public Bot(Graphics g)
        {
            this.g = g; 
        }

        public void botMove(Bitmap bmp, int botX, int botY)
        {
            g.TranslateTransform(botX, botY);
            g.DrawImage(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                new Rectangle(0, 0, bmp.Width * 2, bmp.Height * 2), GraphicsUnit.Pixel);
            g.TranslateTransform(-botX, -botY);


            botRect = new Rectangle(botX, botY, bmp.Width / 2 - 18, bmp.Height / 2 + 5);
            g.DrawRectangle(Pens.Red, botRect);
        }

        public void followCoin()
        {

        }

        public PointF update(PointF Location, SizeF destiny, int speed)
        {
            destiny = new SizeF(destiny.Width - Location.X, destiny.Height - Location.Y);
            dt = speed / (float)Math.Sqrt(destiny.Width * destiny.Width + destiny.Height * destiny.Height);
            Location += new SizeF(destiny.Width * dt, destiny.Height * dt);
            return Location;
        }

        public void shoot(int playerX, int playerY)
        {
            angle = (float)Math.Atan2(playerY - botY, playerX - botX) * (float)(180 / Math.PI);

            bulletEvents = new Bullet(g, new PointF(botX, botY),
                            (float)Math.Cos(angle * (2 * Math.PI) / 360f),
                            (float)Math.Sin(angle * (2 * Math.PI) / 360f));
        }
    }
}
