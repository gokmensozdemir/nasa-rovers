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
        public Plateau(string upperRightCoordinates)
        {
            string[] coords = upperRightCoordinates.Split(" ");

            this.MaxX = Convert.ToInt32(coords[0]);
            this.MaxY = Convert.ToInt32(coords[1]);
        }

        public void Explore(List<IRover> rovers)
        {
            foreach (IRover rover in rovers)
            {
                foreach (char instruction in rover.Instructions)
                {
                    switch (instruction)
                    {
                        case 'L':
                            rover.RotateLeft();
                            break;
                        case 'R':
                            rover.RotateRight();
                            break;
                        case 'M':
                            rover.MoveForward(this);
                            break;
                        default:
                            throw new Exception("Invalid instruction character detected");
                    }
                }
            }
        }
    }
}
