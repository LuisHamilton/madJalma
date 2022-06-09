using System;
using System.Drawing;
using System.Media;

namespace MazeJalma
{
    public class Bot
    {
        private Graphics g;
        private Rectangle botRect;
        float dt = 0;

        public Bot(Graphics g)
        {
            this.g = g; 
        }

        public Rectangle botMove(Bitmap bmp, int botX, int botY)
        {
            g.TranslateTransform(botX, botY);
            g.DrawImage(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                new Rectangle(0, 0, bmp.Width * 2, bmp.Height * 2), GraphicsUnit.Pixel);
            g.TranslateTransform(-botX, -botY);

            botRect = new Rectangle(botX, botY, bmp.Width / 2 - 18, bmp.Height / 2 + 5);
            g.DrawRectangle(Pens.Red, botRect);

            return botRect;
        }

        public PointF update(PointF Location, SizeF destiny, int speed)
        {
            destiny = new SizeF(destiny.Width - Location.X, destiny.Height - Location.Y);

            dt = speed / (float)Math.Sqrt(destiny.Width * destiny.Width + destiny.Height * destiny.Height);

            Location += new SizeF(destiny.Width * dt, destiny.Height * dt);
            
            return Location;
        }


        private RectangleF bulletRect;
        public int killBot(RectangleF bullet)
        {
           bulletRect = bullet;

           if (botRect.Top <= bulletRect.Bottom && botRect.Top > bulletRect.Top && bulletRect.Left >= botRect.Left && bulletRect.Left <= botRect.Right ||
               botRect.Top <= bulletRect.Bottom && botRect.Top > bulletRect.Top && bulletRect.Right >= botRect.Left && bulletRect.Right <= botRect.Right)
           {
                playEdSound();
               return 1;
           }
           if (botRect.Bottom >= bulletRect.Top && botRect.Bottom < bulletRect.Bottom && bulletRect.Left >= botRect.Left && bulletRect.Left <= botRect.Right ||
              botRect.Bottom >= bulletRect.Top && botRect.Bottom < bulletRect.Bottom && bulletRect.Right >= botRect.Left && bulletRect.Right <= botRect.Right)
           {
                playEdSound();
                return 1;
           }
           if (botRect.Right >= bulletRect.Left && botRect.Right < bulletRect.Right && bulletRect.Top >= botRect.Top && bulletRect.Top <= botRect.Bottom ||
              botRect.Right >= bulletRect.Left && botRect.Right < bulletRect.Right && bulletRect.Bottom >= botRect.Top && bulletRect.Bottom <= botRect.Bottom)
           {
                playEdSound();
                return 1;
           }
           if (botRect.Left <= bulletRect.Right && botRect.Left > bulletRect.Left && bulletRect.Top >= botRect.Top && bulletRect.Top <= botRect.Bottom ||
              botRect.Left <= bulletRect.Right && botRect.Left > bulletRect.Left && bulletRect.Bottom >= botRect.Top && bulletRect.Bottom <= botRect.Bottom)
           {
                playEdSound();
                return 1;
           }
           return 0;
        }

        public void playEdSound()
        {
            SoundPlayer edSound = new SoundPlayer(Properties.Resources.maldito);
            edSound.Play();
        }
    }
}
