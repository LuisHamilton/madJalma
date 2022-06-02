using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazeJalma
{
    public class Bot
    {
        private Graphics g;
        private int x = 2560;
        private int y = 1520;
        private int speed = 18;
        private Random rand = new Random();

        public Bot (Graphics g)
        {
            this.g = g;
        }

        public void start(Bitmap bmp)
        {
            g.Clear(Color.Transparent);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmp,
                new Rectangle(x, y, bmp.Width, bmp.Height));
        }

        public void globalMove(Bitmap bmp)
        {
            int coinW = 50;
            int coinH = 50;
            g.TranslateTransform(x, y);
            g.DrawImage(bmp,
                new Rectangle(0, 0, coinW, coinH),
                new Rectangle(0, 0, coinW * 4, coinH * 4), GraphicsUnit.Pixel);
            g.TranslateTransform(-x, -y);

            //coinRect = new Rectangle(x, y, coinW, coinH);
        }

        public void Move(Bitmap bmp)
        {
            g.Clear(Color.Transparent);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                new Rectangle(x, y, bmp.Width*2, bmp.Height*2), GraphicsUnit.Pixel);
        }
    }
}
