using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Type.Entities
{
   public class Border
    {
        public Border(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Border(int x, int y, DirectionEnum direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum Direction { get; set; }


        public void SetX(int x)
        {
            if (x > -1)
                X = x;
        }

        public void SetY(int y)
        {
            if (y > -1)
                Y = y;
        }
    }
}
