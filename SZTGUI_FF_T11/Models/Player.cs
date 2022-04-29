using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_FF_T11_CORE.Models
{
    public class Player : GameItem
    {

        public string Name { get; set; }
        
        public double DX { get; set; }

        public double DY { get; set; }
        public Player(double x, double y, double dX) : base(x, y)
        {
            DX = dX;
            DY = 0;
            Value = 5;
            Color = ConsoleColor.Magenta;
        }
    }
}
