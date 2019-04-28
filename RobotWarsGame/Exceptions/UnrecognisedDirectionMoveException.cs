using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsGame.Exceptions
{
    public class UnrecognisedDirectionMoveException : Exception
    {
        public UnrecognisedDirectionMoveException(string message) : base(message)
        {
        }
    }
}
