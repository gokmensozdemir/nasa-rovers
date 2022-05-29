using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers
{
    public class Plateau
    {
        public int MinX { get { return 0; } }
        public int MinY { get { return 0; } }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public Plateau(int upperX, int upperY)
        {
            MaxX = upperX;
            MaxY = upperY;
        }
    }
}
