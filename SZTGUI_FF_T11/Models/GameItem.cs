using System;

namespace SZTGUI_FF_T11_CORE.Models
{
    public abstract class GameItem
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Angle { get; private set; }

        public int Value { get; set; }

        public ConsoleColor Color { get; set; }

        public double AngleInRad
        {
            get { return Angle * Math.PI / 180; }
            set { Angle = value * 180 / Math.PI; }
        }

        protected GameItem(double x, double y)
        {
            X = x;
            Y = y;
            Angle = 0;
        }
    }
}
