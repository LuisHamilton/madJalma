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
        Random rand = new Random();
        SoundPlayer edMaldito = new SoundPlayer(Properties.Resources.maldito);
        SoundPlayer edQuebrar = new SoundPlayer(Properties.Resources.ed1);
        int i = 0;

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

        public int killBot(RectangleF bullet)
        {
            if (botRect.Contains(new Point((int)bullet.Location.X, (int)bullet.Location.Y)))
            {
                playEdSound();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void playEdSound()
        {
            i = rand.Next(1, 3);
            switch(i)
            {
                case 1:
                    edMaldito.Play();
                    break;
                case 2:
                    edQuebrar.Play();
                    break;
            }
        }
    }
}
