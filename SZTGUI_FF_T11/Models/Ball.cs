using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Core.Models
{
   public class Ball : GameItem
    {
        public double DX { get; set; }

        public double DY { get; set; }

        public Ball(double x, double y, double dX) : base(x, y)
        {
            DX = dX;
            DY = 0;
        }

        public bool IsHealing { get; set; }

        public bool IsDamaging { get; set; }

        public ConsoleColor Color { get; set; }
    }
}
