using Rovers.Instructions.Base;
using Rovers.Positions.Base;
using System.Collections.Generic;

namespace Rovers
{
    public class Rover
    {
        public Rover(Position position)
        {
            Position = position;
        }

        public Position Position { get; set; }

        public void RotateLeft()
        {
            Position = Position.RotateLeft90Degree();
        }
        public void RotateRight()
        {
            Position = Position.RotateRight90Degree();
        }
        public void MoveForward(Plateau plateau)
        {
            Position.Move(plateau);
        }

        public void Explore(Plateau plateau, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                instruction.Apply(plateau, this);
            }
        }
    }
}