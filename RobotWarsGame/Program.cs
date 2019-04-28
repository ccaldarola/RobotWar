using System;
using System.Collections.Generic;
using RobotWarsGame.Entities;

namespace RobotWarsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Arena arena;
                List<Robot> robots = new List<Robot>();
                Console.WriteLine("Welcome to Robots War game!! Please type the size of the Arena, and all the information about the Robots");
                string arenaConfiguration;
                string robotConfiguration;
                string robotDirections;

                arenaConfiguration = Console.ReadLine();
                arena = new Arena(arenaConfiguration);

                while ((!String.IsNullOrEmpty(robotConfiguration = Console.ReadLine())))
                {
                    robotDirections = Console.ReadLine();
                    Robot robot = new Robot(robotConfiguration, arena);
                    robots.Add(robot);
                    robot.Play(robotDirections);
                }

                foreach (var robot in robots)
                {
                    var finalPosition = robot.GetFinalPosition();
                    Console.WriteLine(finalPosition.XPosition.ToString() + " " + finalPosition.YPosition + " " + finalPosition.FacingCardinalCompassPoint.ToString().Substring(0, 1));
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The following error has ocurred with the configuration: {ex.Message}");
            }
        }
    }
}
