using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazeJalma
{
    public class Player
    {
        private Graphics g = null;
        private Rectangle coinRect;
        private Rectangle soldierRect;

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
        
        public Rectangle rotateSoldier(float angle, Bitmap btm, PictureBox pb)
        {

            int deslocx = pb.Width / 2;
            int deslocy = pb.Height / 2;

            g.TranslateTransform(deslocx, deslocy);
            g.RotateTransform(angle);

            g.DrawImage(btm,
                new Rectangle(-btm.Width / 4, -btm.Height / 4, btm.Width, btm.Height),
                new Rectangle(0, 0, btm.Width * 2, btm.Height * 2),
                GraphicsUnit.Pixel);

            soldierRect = new Rectangle(pb.Width / 2 - btm.Width / 4 + 5, pb.Height / 2 - btm.Height / 4 - 15 / 2, btm.Width / 2 - 10, btm.Height / 2 + 15);

            g.RotateTransform(-angle);
            g.TranslateTransform(-deslocx, -deslocy);

            return soldierRect;
        }
    }
}
