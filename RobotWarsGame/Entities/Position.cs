using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsGame.Entities
{
    public class Position
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public CardinalCompassPoint FacingCardinalCompassPoint { get; set; }
    }
}
