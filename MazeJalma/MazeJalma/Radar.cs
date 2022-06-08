using System.Drawing;

namespace MazeJalma
{
    public class Radar
    {
        Graphics g;

        public Radar(Graphics g)
        {
            this.g = g;
        }

        public void Draw()
        {
            g.FillEllipse(Brushes.White, new RectangleF(new PointF(7.5f, 77.5f), new SizeF(155, 155)));
            g.FillEllipse(Brushes.Black, new RectangleF(new PointF(10, 80), new SizeF(150, 150)));
            g.DrawEllipse(Pens.LightGray, new RectangleF(new PointF(60, 130), new SizeF(50, 50)));
            g.DrawEllipse(Pens.LightGray, new RectangleF(new PointF(35, 105), new SizeF(100, 100)));
            g.FillEllipse(Brushes.White, new RectangleF(new PointF(80, 150), new SizeF(10, 10)));
        }

        public void rotateBotRadar(float angle)
        {
            g.TranslateTransform(85, 155);
            g.RotateTransform(angle);

            g.FillEllipse(Brushes.Red, new RectangleF(new PointF(0, 0), new SizeF(70, 1.5f)));

            g.RotateTransform(-angle);
            g.TranslateTransform(-85, -155);
        }

        public void rotateAmmoRadar(float angle)
        {
            g.TranslateTransform(85, 155);
            g.RotateTransform(angle);

            g.FillEllipse(Brushes.Yellow, new RectangleF(new PointF(0, 0), new SizeF(70, 1.5f)));

            g.RotateTransform(-angle);
            g.TranslateTransform(-85, -155);
        }
    }
}
