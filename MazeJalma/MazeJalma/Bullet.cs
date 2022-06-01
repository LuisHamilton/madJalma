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
        public PointF Location { get; set; }
        public SizeF Speed { get; set; }

        public Bullet (Graphics g, PointF loc, float cx, float cy)
        {
            this.g = g;
            this.Location = loc;
            this.Speed = new SizeF(cx, cy);
        }

        public void Draw()
        {
            g.FillEllipse(Brushes.Black, new RectangleF(Location, new SizeF(10, 10)));
        }

        public void Update()
        {
            Location += Speed * 2;
        }
    }
}
