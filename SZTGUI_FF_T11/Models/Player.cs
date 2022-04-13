using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Core.Models
{
    public class Player : GameItem
    {
        public double DX { get; set; }

        public double DY { get; set; }
        public Player(double x, double y, double dX) : base(x, y)
        {
            DX = dX;
            DY = 0;
        }

        public ConsoleColor Color { get; set; }
    }
}
