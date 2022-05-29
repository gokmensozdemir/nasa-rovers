using Rovers.Instructions;
using Rovers.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Factories
{
    public class InstructionFactory
    {
        public Instruction Create(char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    return new LeftInstruction();
                case 'R':
                    return new RightInstruction();
                case 'M':
                    return new MoveInstruction();
                default:
                    throw new Exception($"Invalid instruction character detected: {instruction}");
            }
        }
    }
}
