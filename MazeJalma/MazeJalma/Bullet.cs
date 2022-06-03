using System.Drawing;


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
            this.Speed = new SizeF(50 * cx, 50 * cy);
        }

        public void Draw()
        {
            g.FillEllipse(Brushes.Black, new RectangleF(Location, new SizeF(10, 10)));
        }

        public void Update()
        {
            Location += Speed;
        }
    }
}
