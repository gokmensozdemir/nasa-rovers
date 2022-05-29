using Rovers.Factories;
using Rovers.Instructions.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rovers
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau pleatue = CreatePleatue();

            do
            {
                Rover rover = CreateRover();
                List<Instruction> instructions = CreateInstructions();

                rover.Explore(pleatue, instructions);

                Console.WriteLine("Output: ");
                Console.WriteLine(rover.Position);
            }
            while (true);
        }
        private static List<Instruction> CreateInstructions()
        {
            Console.WriteLine("Enter Rover Instructions: ");
            var instructionInputs = Console.ReadLine();
            var instructionFactory = new InstructionFactory();
            var instructions = new List<Instruction>();

            foreach (char item in instructionInputs)
            {
                var instruction = instructionFactory.Create(item);
                instructions.Add(instruction);
            }

            return instructions;
        }
        private static Rover CreateRover()
        {
            Console.WriteLine("Enter Rover Position: ");
            var positionInputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(positionInputs[0]);
            var y = Convert.ToInt32(positionInputs[1]);
            var direction = (Direction)Convert.ToChar(positionInputs[2]);
            var positionFactory = new PositionFactory();
            var position = positionFactory.Create(direction, x, y);
            var rover = new Rover(position);
            return rover;
        }
        private static Plateau CreatePleatue()
        {
            Console.WriteLine("Enter upper-right coordinates of plateau: ");
            var pleatueInputs = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var pleatue = new Plateau(pleatueInputs[0], pleatueInputs[1]);
            return pleatue;
        }        
    }
}
