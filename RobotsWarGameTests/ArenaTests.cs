using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWarsGame.Entities;
using RobotWarsGame.Exceptions;

namespace RobotsWarGameTests
{
    [TestClass]
    public class ArenaTests
    {
        [TestMethod]
        public void WhenEmptyStringShouldThrowAnError()
        {
            Assert.ThrowsException<InvalidArenaSizeException>(() => new Arena(String.Empty));
        }

        [TestMethod]
        public void WhenInvalidStringShouldThrowAnError()
        {
            Assert.ThrowsException<InvalidArenaSizeException>(() => new Arena("TEST!!"));
        }

        [TestMethod]
        public void WhenConfigOkShouldCreateArena()
        {
            var arena = new Arena("5 7");
            Assert.AreEqual(5,arena.MaxXPositions);
            Assert.AreEqual(7, arena.MaxYPositions);
        }
    }
}
