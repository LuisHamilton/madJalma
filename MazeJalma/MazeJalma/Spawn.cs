using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeJalma
{
    public class Spawn
    {
        private Random rand = new Random();

        public int coordenada(int player)
        {
            if (player <= 1000)
                return rand.Next(1000, 7000);
            else if (player <= 2000)
                return rand.Next(-500, 6000);
            else if (player <= 3000)
                return rand.Next(-1500, 5000);
            else if (player <= 4000)
                return rand.Next(-2500, 4000);
            else if (player <= 5000)
                return rand.Next(-3500, 3000);
            else if (player <= 6000)
                return rand.Next(-4500, 2000);
            else if (player <= 7000)
                return rand.Next(-5500, 1000);
            else if (player <= 8000)
                return rand.Next(-6500, -1000);
            else
                return rand.Next(-7000, -1000);
        }
    }
}
