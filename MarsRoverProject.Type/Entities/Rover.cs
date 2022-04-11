using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Type.Entities
{
    public class Rover
    {
        public Border Border { get; set; }
        public Plateau Plateau { get; set; }

        public Rover(Border border)
        {
            Border = border;
        }

        public override string ToString()
        {
            return Border.X + " " + Border.Y + " " + Border.Direction.ToString();
        }
    }
}
