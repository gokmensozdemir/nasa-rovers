using Rovers.Positions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Positions
{
    public class EastPosition : Position
    {
        public EastPosition(int x, int y) : base(Direction.East, x, y)
        {

        }

        public override void Move(Plateau plateau)
        {
            if (X + 1 > plateau.MaxX)
            {
                throw new Exception("The boundaries of the plateau are not big enough to move east");
            }
            X = X + 1;
        }

        public override Position RotateLeft90Degree()
        {
            return new NorthPosition(X, Y);
        }

        public override Position RotateRight90Degree()
        {
            return new SouthPosition(X, Y);
        }
    }
}
