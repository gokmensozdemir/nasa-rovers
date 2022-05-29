using NUnit.Framework;
using Rovers;
using Rovers.Factories;
using System;
using System.Linq;

namespace RoversTest
{
    public class RoversTests
    {
        PositionFactory positionFactory;
        InstructionFactory instructorFactory;

        [SetUp]
        public void Setup()
        {
            positionFactory = new PositionFactory();
            instructorFactory = new InstructionFactory();
        }

        [Test]
        public void Example1()
        {
            var plateau = new Plateau(5, 5);

            var position = positionFactory.Create(Direction.North, 1, 2);

            var rover = new Rover(position);

            var instructions = "LMLMLMLMM".Select(x => instructorFactory.Create(x)).ToList();

            rover.Explore(plateau, instructions);

            Assert.AreEqual("1 3 N", rover.Position.ToString());
        }

        [Test]
        public void Example2()
        {
            var plateau = new Plateau(5, 5);

            var position = positionFactory.Create(Direction.East, 3, 3);

            var rover = new Rover(position);

            var instructions = "MMRMMRMRRM".Select(x => instructorFactory.Create(x)).ToList();

            rover.Explore(plateau, instructions);

            Assert.AreEqual("5 1 E", rover.Position.ToString());
        }

        [Test]
        public void Example3()
        {
            var plateau = new Plateau(3, 3);

            var position = positionFactory.Create(Direction.East, 0, 0);

            var rover = new Rover(position);

            var instructions = "MLMRMLMRMLM".Select(x => instructorFactory.Create(x)).ToList();

            rover.Explore(plateau, instructions);

            Assert.AreEqual("3 3 N", rover.Position.ToString());
        }

        [Test]
        public void InvalidInstructionCharDetected()
        {
            var ex = Assert.Throws<Exception>(() => instructorFactory.Create('A'));
            Assert.That(ex.Message, Is.EqualTo("Invalid instruction character detected: A"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveNorth()
        {
            var plateau = new Plateau(1, 1);

            var position = positionFactory.Create(Direction.North, 0, 0);

            var rover = new Rover(position);

            var instructions = "MM".Select(x => instructorFactory.Create(x)).ToList();

            var ex = Assert.Throws<Exception>(() => rover.Explore(plateau, instructions));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move north"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveWest()
        {
            var plateau = new Plateau(1, 1);

            var position = positionFactory.Create(Direction.West, 0, 0);

            var rover = new Rover(position);

            var instructions = "MM".Select(x => instructorFactory.Create(x)).ToList();

            var ex = Assert.Throws<Exception>(() => rover.Explore(plateau, instructions));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move west"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveSouth()
        {
            var plateau = new Plateau(1, 1);

            var position = positionFactory.Create(Direction.South, 0, 0);

            var rover = new Rover(position);

            var instructions = "MM".Select(x => instructorFactory.Create(x)).ToList();

            var ex = Assert.Throws<Exception>(() => rover.Explore(plateau, instructions));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move south"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveEast()
        {
            var plateau = new Plateau(1, 1);

            var position = positionFactory.Create(Direction.East, 0, 0);

            var rover = new Rover(position);

            var instructions = "MM".Select(x => instructorFactory.Create(x)).ToList();

            var ex = Assert.Throws<Exception>(() => rover.Explore(plateau, instructions));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move east"));
        }
    }
}