using System.Drawing;
using System.Media;

namespace MazeJalma
{
    public class Otto
    {
        private Graphics g = null;
        private Rectangle ottoRect;
        private Rectangle soldierRect;

        public Otto(Graphics g)
        {
            this.g = g;
        }

        public void ottoMove(Bitmap otto, int ottoX, int ottoY)
        {
            int ottoW = 50;
            int ottoH = 50;
            g.TranslateTransform(ottoX, ottoY);
            g.DrawImage(otto,
                new Rectangle(0, 0, ottoW, ottoH),
                new Rectangle(0, 0, ottoW * 10, ottoH * 10), GraphicsUnit.Pixel);
            g.TranslateTransform(-ottoX, -ottoY);

            ottoRect = new Rectangle(ottoX, ottoY, ottoW, ottoH);
        }
        public int collisionOtto(Rectangle soldier)
        {
            soldierRect = soldier;

            g.DrawRectangle(Pens.Red, ottoRect);
            g.DrawRectangle(Pens.Red, soldierRect);

            if (soldierRect.Top <= ottoRect.Bottom && soldierRect.Top > ottoRect.Top && ottoRect.Left >= soldierRect.Left && ottoRect.Left <= soldierRect.Right ||
                soldierRect.Top <= ottoRect.Bottom && soldierRect.Top > ottoRect.Top && ottoRect.Right >= soldierRect.Left && ottoRect.Right <= soldierRect.Right)
            {
                playOttoSound();
                return 1;
            }
            if (soldierRect.Bottom >= ottoRect.Top && soldierRect.Bottom < ottoRect.Bottom && ottoRect.Left >= soldierRect.Left && ottoRect.Left <= soldierRect.Right ||
               soldierRect.Bottom >= ottoRect.Top && soldierRect.Bottom < ottoRect.Bottom && ottoRect.Right >= soldierRect.Left && ottoRect.Right <= soldierRect.Right)
            {
                playOttoSound();
                return 1;
            }
            if (soldierRect.Right >= ottoRect.Left && soldierRect.Right < ottoRect.Right && ottoRect.Top >= soldierRect.Top && ottoRect.Top <= soldierRect.Bottom ||
               soldierRect.Right >= ottoRect.Left && soldierRect.Right < ottoRect.Right && ottoRect.Bottom >= soldierRect.Top && ottoRect.Bottom <= soldierRect.Bottom)
            {
                playOttoSound();
                return 1;
            }
            if (soldierRect.Left <= ottoRect.Right && soldierRect.Left > ottoRect.Left && ottoRect.Top >= soldierRect.Top && ottoRect.Top <= soldierRect.Bottom ||
               soldierRect.Left <= ottoRect.Right && soldierRect.Left > ottoRect.Left && ottoRect.Bottom >= soldierRect.Top && ottoRect.Bottom <= soldierRect.Bottom)
            {
                playOttoSound();
                return 1;
            }
            return 0;
        }

        public void menuOtto(Bitmap otto, int x, int y)
        {
            int ottoW = 50; int ottoH = 50;
            g.DrawImage(otto,
                new Rectangle(x, y, ottoW, ottoH));
        }

        public void animOtto(Bitmap otto, int x, int y)
        {
            int ottoW = 50; int ottoH = 50;
            g.DrawImage(otto,
                new Rectangle(0, 0, ottoW, ottoH),
                new Rectangle(x, y, ottoW, ottoH), GraphicsUnit.Pixel);
        }
        private void playOttoSound()
        {
            SoundPlayer ottoSound = new SoundPlayer(Properties.Resources.pop);
            ottoSound.Play();
        }
    }
}
