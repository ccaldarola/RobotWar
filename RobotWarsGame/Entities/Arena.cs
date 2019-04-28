using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using RobotWarsGame.Exceptions;

namespace RobotWarsGame.Entities
{
    public class Arena
    {
        private readonly int xPositionInConfig = 0;
        private readonly int yPositionInConfig = 1;
        private int TotalXPositions { get; set; }
        private int TotalYPositions { get; set; }

        public int MaxXPositions
        {
            get { return TotalXPositions; }
        }

        public int MaxYPositions
        {
            get { return TotalYPositions; }
        }

        public Arena(string size)
        {
            int totalXPosition;
            int totalYPosition;

            if (!size.Contains(' '))
            {
                throw new InvalidArenaSizeException($"{size} is an invalid Arena size. Should be [maxXPositions] [maxYPositions] being both numbers");
            }

            if(!int.TryParse(size.Split(' ')[xPositionInConfig],out totalXPosition))
            {
                throw new InvalidArenaSizeException($"{size} is an invalid Arena size. Should be [maxXPositions] [maxYPositions] being both numbers");

            }
            if (!int.TryParse(size.Split(' ')[yPositionInConfig], out totalYPosition))
            {
                throw new InvalidArenaSizeException($"{size} is an invalid Arena size. Should be [maxXPositions] [maxYPositions] being both numbers");

            }
            TotalXPositions = totalXPosition;
            TotalYPositions = totalYPosition;
        }

    }
}
