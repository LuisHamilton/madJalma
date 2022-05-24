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
    public class Player
    {
        private Graphics g = null;

        public Player(Graphics g)
        {
            this.g = g;
        }

        public void mapMove(int x, int y, Bitmap btm, PictureBox pb)
        {
            g.Clear(Color.Transparent);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(btm,
                new Rectangle(0, 0, pb.Width, pb.Height),
                new Rectangle(x, y, pb.Width, pb.Height), GraphicsUnit.Pixel);
        }
        public void coinMove(Bitmap coin, int coinX, int coinY)
        {
            int coinW = 50;
            int coinH = 50;
            g.TranslateTransform(coinX, coinY);
            g.DrawImage(coin,
                new Rectangle(0, 0, coinW, coinH),
                new Rectangle(0, 0, coinW * 4, coinH * 4), GraphicsUnit.Pixel);
            g.TranslateTransform(-coinX, -coinY);
        }
        public void collisionCoin(int x, int y, int coinX, int coinY)
        {
            
        }
        public void rotateSoldier(float angle, Bitmap btm, PictureBox pb)
        {

            int deslocx = pb.Width / 2;
            int deslocy = pb.Height / 2;

            g.TranslateTransform(deslocx, deslocy);
            g.RotateTransform(angle);

            g.DrawImage(btm,
                new Rectangle(-btm.Width / 4, -btm.Height / 4, btm.Width, btm.Height),
                new Rectangle(0, 0, btm.Width * 2, btm.Height * 2),
                GraphicsUnit.Pixel);

            g.RotateTransform(-angle);
            g.TranslateTransform(-deslocx, -deslocy);
        }
    }
}
