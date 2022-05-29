using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Positions.Base
{
    public abstract class Position
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Direction Direction { get; set; }        
        public Position(Direction direction, int x, int y)
        {
            Direction = direction;
            X = x;
            Y = y;
        }

        public abstract void Move(Plateau plateau);
        public abstract Position RotateLeft90Degree();
        public abstract Position RotateRight90Degree();
        public override string ToString() => $"{X} {Y} {(char)(byte)Direction}";
    }
}
