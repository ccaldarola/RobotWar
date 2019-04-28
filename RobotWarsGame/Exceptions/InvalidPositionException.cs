using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsGame.Exceptions
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(string message) : base(message)
        {
        }
    }
}
