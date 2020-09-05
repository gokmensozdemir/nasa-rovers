using NUnit.Framework;
using Rovers;
using System;
using System.Collections.Generic;

namespace RoversTest
{
    public class RoversTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Example1()
        {
            var plateau = new Plateau("5 5");

            var rovers = new List<IRover>()
            {
                new Rover("1 2 N", "LMLMLMLMM")
            };

            plateau.Explore(rovers);

            Assert.AreEqual("1 3 N", rovers[0].ToString());
        }

        [Test]
        public void Example2()
        {
            var plateau = new Plateau("5 5");

            var rovers = new List<IRover>()
            {
                new Rover("3 3 E", "MMRMMRMRRM")
            };

            plateau.Explore(rovers);

            Assert.AreEqual("5 1 E", rovers[0].ToString());
        }

        [Test]
        public void Example3()
        {
            var plateau = new Plateau("3 3");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 E", "MLMRMLMRMLM")
            };

            plateau.Explore(rovers);

            Assert.AreEqual("3 3 N", rovers[0].ToString());
        }

        [Test]
        public void InvalidInstructionCharDetected()
        {
            var plateau = new Plateau("5 5");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 N", "ABC")
            };

            var ex = Assert.Throws<Exception>(() => plateau.Explore(rovers));
            Assert.That(ex.Message, Is.EqualTo("Invalid instruction character detected"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveNorth()
        {
            var plateau = new Plateau("1 1");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 N", "MM")
            };

            var ex = Assert.Throws<Exception>(() => plateau.Explore(rovers));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move north"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveWest()
        {
            var plateau = new Plateau("1 1");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 W", "MM")
            };

            var ex = Assert.Throws<Exception>(() => plateau.Explore(rovers));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move west"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveSouth()
        {
            var plateau = new Plateau("1 1");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 S", "MM")
            };

            var ex = Assert.Throws<Exception>(() => plateau.Explore(rovers));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move south"));
        }

        [Test]
        public void PlateauBoundriesNotBigEnoughToMoveEast()
        {
            var plateau = new Plateau("1 1");

            var rovers = new List<IRover>()
            {
                new Rover("0 0 E", "MM")
            };

            var ex = Assert.Throws<Exception>(() => plateau.Explore(rovers));
            Assert.That(ex.Message, Is.EqualTo("The boundaries of the plateau are not big enough to move east"));
        }
    }
}