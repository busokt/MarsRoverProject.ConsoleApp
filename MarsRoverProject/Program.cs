using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverProject.Business;
using MarsRoverProject.Type;
using MarsRoverProject.Type.Entities;

namespace MarsRoverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionManager roverActionManager = new ActionManager();
            Console.Write("Plato sınırlarını giriniz : ");
            var plateauLimit = Console.ReadLine();
            var plateauLimitArr = plateauLimit.Split(' ');

            if (plateauLimitArr.Length == 2)
            {
                var pleteauXLimit = Convert.ToInt32(plateauLimitArr[0]);
                var pleteauYLimit = Convert.ToInt32(plateauLimitArr[1]);

                Plateau plateau = new Plateau(pleteauXLimit, pleteauYLimit);
                Console.Write("Lokasyon bilgisini giriniz : ");

                var borderLine = Console.ReadLine();
                var borderArray = borderLine.Split(' ');

                if (borderArray.Length == 3)
                {
                    int borderX = Convert.ToInt32(borderArray[0].ToString());
                    int borderY = Convert.ToInt32(borderArray[1].ToString());
                    var bDirection = (borderArray[2].ToString());

                    var pointDirectionEnum = Enum.Parse(typeof(DirectionEnum), bDirection);
                    Border border = new Border(borderX, borderY, (DirectionEnum)pointDirectionEnum);

                    Rover rover = new Rover(border);
                    rover.Plateau = plateau;

                    roverActionManager.InitialRoverPositionControl(rover);

                    Console.Write("Komutları giriniz : ");
                    var commands = Console.ReadLine();

                    List<char> commandList = commands.ToList();

                    foreach (var command in commandList)
                    {
                        roverActionManager.ManageCommand(command.ToString(), rover);
                    }

                    Console.WriteLine(rover.Border.X + " " + rover.Border.Y + " " + rover.Border.Direction.ToString());

                }
            }
            Console.ReadKey();
        }
    }
}
