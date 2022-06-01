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
    public class Bullet
    {
        Graphics g;
        float angle;
        Brush brush;

        public Bullet (Graphics g)
        {
            this.g = g;
        }

        public void Loop(int X, int Y, int pX, int pY)
        {
            if (X >= pX)
            {
                for (int posX = pX; posX <= X; posX += 18)
                {
                    if(Y >= pY)
                    {
                        for (int posY = pY; posY <= Y; posY += 18)
                            g.FillEllipse(Brushes.Black, new RectangleF(posX, posY, 10, 10));
                    }
                    else
                    {
                        for (int posY = pY; posY >= Y; posY -= 18)
                            g.FillEllipse(Brushes.Black, new RectangleF(posX, posY, 10, 10));
                    }
                }
            }
            else
            {
                for (int posX = pX; posX >= X; posX -= 18)
                {
                    if (Y >= pY)
                    {
                        for (int posY = pY; posY <= Y; posY += 18)
                            g.FillEllipse(Brushes.Black, new RectangleF(posX, posY, 10, 10));
                    }
                    else
                    {
                        for (int posY = pY; posY >= Y; posY -= 18)
                            g.FillEllipse(Brushes.Black, new RectangleF(posX, posY, 10, 10));
                    }
                }
            }
        }
    }
}
