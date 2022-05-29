using Rovers.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Instructions
{
    public class RightInstruction : Instruction
    {
        public override void Apply(Plateau plateau, Rover rover)
        {
            rover.RotateRight();
        }
    }
}
