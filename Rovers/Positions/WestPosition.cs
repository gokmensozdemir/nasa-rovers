using Rovers.Positions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Positions
{
    public class WestPosition : Position
    {
        public WestPosition(int x, int y) : base(Direction.West, x, y)
        {

        }

        public override void Move(Plateau plateau)
        {
            if (X - 1 < plateau.MinX)
            {
                throw new Exception("The boundaries of the plateau are not big enough to move west");
            }
            X = X - 1;
        }

        public override Position RotateLeft90Degree()
        {
            return new SouthPosition(X, Y);
        }

        public override Position RotateRight90Degree()
        {
            return new NorthPosition(X, Y);
        }
    }
}
