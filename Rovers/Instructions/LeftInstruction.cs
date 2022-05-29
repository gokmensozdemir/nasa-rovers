using Rovers.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Instructions
{
    public class LeftInstruction : Instruction
    {
        public override void Apply(Plateau plateau, Rover rover)
        {
            rover.RotateLeft();
        }
    }
}
