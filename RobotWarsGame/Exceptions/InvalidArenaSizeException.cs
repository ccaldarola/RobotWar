using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsGame.Exceptions
{
    public class InvalidArenaSizeException  : Exception
    {
        public InvalidArenaSizeException(string message) : base(message)
        {

        }
    }
}
