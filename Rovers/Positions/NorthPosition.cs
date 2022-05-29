﻿using Rovers.Positions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Positions
{
    public class NorthPosition : Position
    {
        public NorthPosition(int x, int y) : base(Direction.North, x, y)
        {

        }

        public override void Move(Plateau plateau)
        {
            if (Y + 1 > plateau.MaxY)
            {
                throw new Exception("The boundaries of the plateau are not big enough to move north");
            }
            Y = Y + 1;
        }

        public override Position RotateLeft90Degree()
        {
            return new WestPosition(X, Y);
        }

        public override Position RotateRight90Degree()
        {
            return new EastPosition(X, Y);
        }
    }
}
