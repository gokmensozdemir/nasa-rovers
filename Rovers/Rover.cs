using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers
{
    public interface IRover
    {
        public string Instructions { get; set; }
        void RotateLeft();
        void RotateRight();
        void MoveForward(Plateau plateau);
    }
    public class Rover : IRover
    {
        public Rover(string position, string instructions)
        {
            string[] positions = position.Split(" ");
            X = Convert.ToInt32(positions[0]);
            Y = Convert.ToInt32(positions[1]);
            Direction = (CompassDirection)Convert.ToChar(positions[2]);
            Instructions = instructions;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public CompassDirection Direction { get; set; }
        public string Instructions { get; set; }

        public void RotateLeft()
        {
            this.Direction = Compass.RotateLeft90Degree(this.Direction);
        }
        public void RotateRight()
        {
            this.Direction = Compass.RotateRight90Degree(this.Direction);
        }
        public void MoveForward(Plateau plateau)
        {
            if (this.Direction == CompassDirection.North)
            {
                if (this.Y + 1 > plateau.MaxY)
                {
                    throw new Exception("The boundaries of the plateau are not big enough to move north");
                }
                this.Y = this.Y + 1;
            }
            else if (this.Direction == CompassDirection.West)
            {
                if (this.X - 1 < plateau.MinX)
                {
                    throw new Exception("The boundaries of the plateau are not big enough to move west");
                }
                this.X = this.X - 1;
            }
            else if (this.Direction == CompassDirection.South)
            {
                if (this.Y - 1 < plateau.MinY)
                {
                    throw new Exception("The boundaries of the plateau are not big enough to move south");
                }
                this.Y = this.Y - 1;
            }
            else if (this.Direction == CompassDirection.East)
            {
                if (this.X + 1 > plateau.MaxX)
                {
                    throw new Exception("The boundaries of the plateau are not big enough to move east");
                }
                this.X = this.X + 1;
            }
        }

        public override string ToString() => $"{X} {Y} {(char)(byte)Direction}";
    }
}