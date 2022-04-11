using System;
using System.Collections.Generic;
using MarsRoverProject.Business;
using MarsRoverProject.Type;
using MarsRoverProject.Type.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverProject.UTest
{
    [TestClass]
    public class MarsRoverProjectTest
    {
        [TestMethod]
        public void FirstRoverCheck()
        {
            Plateau plateau = new Plateau(5, 5);
            Border border = new Border(1, 2, DirectionEnum.N);
            Rover rover = new Rover(border);
            rover.Plateau = plateau;
            List<string> commands = new List<string> { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            ActionManager actionManager = new ActionManager();

            foreach (var command in commands)
            {
                actionManager.ManageCommand(command, rover);
            }

            Assert.AreEqual(rover.ToString(), "1 3 N");
        }

        [TestMethod]
        public void SecondRoverCheck()
        {
            Plateau plateau = new Plateau(5, 5);
            Border border = new Border(3, 3, DirectionEnum.E);
            Rover rover = new Rover(border);
            rover.Plateau = plateau;
            List<string> commands = new List<string> { "L", "M", "L", "M", "R", "M", "M", "L", "R", "M" };
            ActionManager actionManager = new ActionManager();

            foreach (var command in commands)
            {
                actionManager.ManageCommand(command, rover);
            }

            Assert.AreEqual(rover.ToString(), "5 1 E");
        }
    }
}
