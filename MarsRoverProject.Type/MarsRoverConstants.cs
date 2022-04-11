using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Type
{
    public class MarsRoverConstants
    {
        public class Directions
        {
            public const string North = "N";
            public const string South = "S";
            public const string East = "E";
            public const string West = "W";
        }

        public class Commands
        {
            public const string MoveForward = "M";
            public const string TurnLeft = "L";
            public const string TurnRight = "R";

        }
    }

    public enum DirectionEnum
    {
        N,
        S,
        W,
        E
    }
}
