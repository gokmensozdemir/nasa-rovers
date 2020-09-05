using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers
{
    public enum CompassDirection : byte
    {
        North = (byte)'N',
        West = (byte)'W',
        South = (byte)'S',
        East = (byte)'E'
    }
    public class Compass
    {
        static CompassDirection[] directions = new CompassDirection[4]
        {
            CompassDirection.North,
            CompassDirection.West,
            CompassDirection.South,
            CompassDirection.East
        };

        public static CompassDirection RotateLeft90Degree(CompassDirection direction)
        {
            int index = Array.IndexOf(directions, direction);
            return directions[mod(index + 1, 4)];
        }

        public static CompassDirection RotateRight90Degree(CompassDirection direction)
        {
            int index = Array.IndexOf(directions, direction);
            return directions[mod(index - 1, 4)];
        }

        private static int mod(int a, int n)
        {
            int result = a % n;
            if ((result < 0 && n > 0) || (result > 0 && n < 0))
            {
                result += n;
            }
            return result;
        }
    }
}
