using Rovers.Positions;
using Rovers.Positions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Factories
{
    public class PositionFactory
    {
        public Position Create(Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.North:
                    return new NorthPosition(x, y);
                case Direction.West:
                    return new WestPosition(x, y);
                case Direction.South:
                    return new SouthPosition(x, y);
                case Direction.East:
                    return new EastPosition(x, y);
                default:
                    throw new Exception($"Invalid direction character detected: {direction}");
            }
        }
    }
}
