using System.Drawing;
using System.Media;

namespace MazeJalma
{
    public class Ammo
    {
        private Graphics g = null;
        private Rectangle ammoRect;
        private Rectangle soldierRect;

        public Ammo(Graphics g)
        {
            this.g = g;
        }

        public void ammoMove(Bitmap ammo, int ammoX, int ammoY)
        {
            int ammoW = 65;
            int ammoH = 65;
            g.TranslateTransform(ammoX, ammoY);
            g.DrawImage(ammo,
                new Rectangle(0, 0, ammoW, ammoH),
                new Rectangle(0, 0, ammoW * 8, ammoH * 8), GraphicsUnit.Pixel);
            g.TranslateTransform(-ammoX, -ammoY);

            ammoRect = new Rectangle(ammoX, ammoY, ammoW, ammoH);
        }
        public int collisionAmmo(Rectangle soldier)
        {
            soldierRect = soldier;

            if (soldierRect.Top <= ammoRect.Bottom && soldierRect.Top > ammoRect.Top && ammoRect.Left >= soldierRect.Left && ammoRect.Left <= soldierRect.Right ||
                soldierRect.Top <= ammoRect.Bottom && soldierRect.Top > ammoRect.Top && ammoRect.Right >= soldierRect.Left && ammoRect.Right <= soldierRect.Right)
            {
                playReloadSound();
                return 1;
            }
            if (soldierRect.Bottom >= ammoRect.Top && soldierRect.Bottom < ammoRect.Bottom && ammoRect.Left >= soldierRect.Left && ammoRect.Left <= soldierRect.Right ||
               soldierRect.Bottom >= ammoRect.Top && soldierRect.Bottom < ammoRect.Bottom && ammoRect.Right >= soldierRect.Left && ammoRect.Right <= soldierRect.Right)
            {
                playReloadSound();
                return 1;
            }
            if (soldierRect.Right >= ammoRect.Left && soldierRect.Right < ammoRect.Right && ammoRect.Top >= soldierRect.Top && ammoRect.Top <= soldierRect.Bottom ||
               soldierRect.Right >= ammoRect.Left && soldierRect.Right < ammoRect.Right && ammoRect.Bottom >= soldierRect.Top && ammoRect.Bottom <= soldierRect.Bottom)
            {
                playReloadSound();
                return 1;
            }
            if (soldierRect.Left <= ammoRect.Right && soldierRect.Left > ammoRect.Left && ammoRect.Top >= soldierRect.Top && ammoRect.Top <= soldierRect.Bottom ||
               soldierRect.Left <= ammoRect.Right && soldierRect.Left > ammoRect.Left && ammoRect.Bottom >= soldierRect.Top && ammoRect.Bottom <= soldierRect.Bottom)
            {
                playReloadSound();
                return 1;
            }
            return 0;
        }
        private void playReloadSound()
        {
            SoundPlayer ammoSound = new SoundPlayer(Properties.Resources.reload);
            ammoSound.Play();
        }
    }
}
