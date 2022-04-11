using MarsRoverProject.Type;
using MarsRoverProject.Type.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Business
{
    public class ActionManager
    {
        public void ManageCommand(string command, Rover rover)
        {
            switch (command)
            {
                case "M":
                    MoveForward(rover);
                    break;
                case "L":
                    TurnLeft(rover);
                    break;
                case "R":
                    TurnRight(rover);
                    break;
                default:
                    throw new InvalidOperationException("Yanlış Talimat");
            }
        }

        public void MoveForward(Rover rover)
        {
            Border border = rover.Border;

            if (border.X <= rover.Plateau.X && border.Y <= rover.Plateau.Y)
            {
                switch (border.Direction)
                {
                    case DirectionEnum.N:
                        if (border.Y + 1 > rover.Plateau.Y)
                        {
                            throw new ArgumentOutOfRangeException("Y koordinatı sınırları dışında.");
                        }
                        border.SetY(border.Y + 1);
                        break;
                    case DirectionEnum.S:
                        if (border.Y - 1 < 0)
                        {
                            throw new ArgumentOutOfRangeException("Y koordinatı sınırları dışında.");
                        }
                        border.SetY(border.Y - 1);
                        break;
                    case DirectionEnum.W:
                        if (border.X - 1 < 0)
                        {
                            throw new ArgumentOutOfRangeException("X koordinatı sınırları dışında.");
                        }
                        border.SetX(border.X - 1);
                        break;
                    case DirectionEnum.E:
                        if (border.X + 1 > rover.Plateau.X)
                        {
                            throw new ArgumentOutOfRangeException("X koordinatı sınırları dışında.");
                        }
                        border.SetX(border.X + 1);
                        break;
                    default:
                        throw new InvalidOperationException("Yanlış Talimat");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("X / Y koordinatları sınırları dışında.");
            }
        }

        public void TurnLeft(Rover rover)
        {
            Border border = rover.Border;

            switch (border.Direction)
            {
                case DirectionEnum.N:
                    border.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.S:
                    border.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.W:
                    border.Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.E:
                    border.Direction = DirectionEnum.N;
                    break;
                default:
                    throw new InvalidOperationException("Yanlış Talimat");
            }
        }

        public void TurnRight(Rover rover)
        {
            Border border = rover.Border;

            switch (border.Direction)
            {
                case DirectionEnum.N:
                    border.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.S:
                    border.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    border.Direction = DirectionEnum.N;
                    break;
                case DirectionEnum.E:
                    border.Direction = DirectionEnum.S;
                    break;
                default:
                    throw new InvalidOperationException("Yanlış Talimat");
            }
        }

        public string InitialRoverPositionControl(Rover rover)
        {
            string msgAction = String.Empty;
            if (rover.Border.X > rover.Plateau.X)
                msgAction = "X başlangıç konumu plato limitleri dışında";
            if (rover.Border.Y > rover.Plateau.Y)
                msgAction = "Y başlangıç konumu plato limitleri dışında";

            return msgAction;
        }
    }
}
