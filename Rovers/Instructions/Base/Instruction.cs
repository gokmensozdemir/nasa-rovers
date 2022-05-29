using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Instructions.Base
{
    public abstract class Instruction
    {
        public abstract void Apply(Plateau plateau, Rover rover);
    }
}
