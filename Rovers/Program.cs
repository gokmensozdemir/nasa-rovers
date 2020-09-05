using System;
using System.Collections.Generic;

namespace Rovers
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex}");
                }                
                Console.WriteLine("To explore new plateau press P..");
            } while (Console.ReadKey(true).Key == ConsoleKey.P);
        }

        static void Run()
        {
            Console.WriteLine("Enter upper-right coordinates of plateau: ");
            Plateau plateau = new Plateau(Console.ReadLine());

            List<IRover> rovers = new List<IRover>();

            do
            {
                Console.WriteLine("Enter rover position: ");
                string roverPosition = Console.ReadLine();
                Console.WriteLine("Enter rover instructions: ");
                string roverInstructions = Console.ReadLine();

                rovers.Add(new Rover(roverPosition, roverInstructions));

                Console.WriteLine("To create new rover press R, to continue press any key..");
            }
            while (Console.ReadKey(true).Key == ConsoleKey.R);

            plateau.Explore(rovers);

            Console.WriteLine("Plateau explored, output: ");
            foreach (IRover item in rovers)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
