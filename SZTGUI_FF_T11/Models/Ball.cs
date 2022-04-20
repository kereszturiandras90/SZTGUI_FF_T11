using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_FF_T11_CORE.Models
{
   public class Ball : GameItem
    {
        public double DX { get; set; }

        public double DY { get; set; }

        public Ball(double x, double y, double dX, ConsoleColor color, int value) : base(x, y)
        {
            DX = dX;
            DY = 0;
            Color = color;
            Value = value;
        }

        public bool IsHealing  => Color == ConsoleColor.Green ? true : false;

        public bool IsDamaging  => Color == ConsoleColor.Red ? true : false;
    }
}
