using System.Drawing;


namespace MazeJalma
{
    public class Bullet
    {
        Graphics g;
        public PointF Location { get; set; }
        public SizeF Speed { get; set; }
        public RectangleF bulletRect { get; set; }


        public Bullet (Graphics g, PointF loc, float cx, float cy)
        {
            this.g = g;
            this.Location = loc;
            this.Speed = new SizeF(50 * cx, 50 * cy);
        }

        public RectangleF Draw()
        {
            g.FillEllipse(Brushes.Black, new RectangleF(Location, new SizeF(10, 10)));

            bulletRect = new RectangleF(Location, new SizeF(10, 10));
            return bulletRect;
        }

        public void Update()
        {
            Location += Speed;
        }
    }
}
