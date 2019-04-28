using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWarsGame.Entities;
using RobotWarsGame.Exceptions;

namespace RobotsWarGameTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void WhenInvalidConfigShouldRaiseAnException()
        {
            Assert.ThrowsException<InvalidPositionException>(() => new Robot("Test!!", new Arena("5 5")));
        }

        [TestMethod]
        public void WhenInitialPositionOutOfArenaShouldRaiseAnException()
        {
            Assert.ThrowsException<InvalidPositionException>(() => new Robot("25 25 W", new Arena("5 5")));
        }

        [TestMethod]
        public void WhenMovingOutOfArenaShouldRaiseAnException()
        {
            var robot = new Robot("4 4 N", new Arena("5 5"));
            Assert.ThrowsException<InvalidPositionException>(() => robot.Play("MMMMMMMMMM"));

        }

        [TestMethod]
        public void WhenInitialInstructionsAreInvalidShouldRaiseAnException()
        {
            var robot = new Robot("4 4 N", new Arena("5 5"));
            Assert.ThrowsException<UnrecognisedDirectionMoveException>(() => robot.Play("TEST!!"));
        }

        [TestMethod]
        public void WhenCorrectInstructionsShouldPlay()
        {
            var robot = new Robot("1 2 N", new Arena("5 5"));
            robot.Play("LMLMLMLMM");

            var finalPosition = robot.GetFinalPosition();

            Assert.AreEqual(1, finalPosition.XPosition);
            Assert.AreEqual(3, finalPosition.YPosition);
            Assert.AreEqual(CardinalCompassPoint.North, finalPosition.FacingCardinalCompassPoint);
        }
    }
}
