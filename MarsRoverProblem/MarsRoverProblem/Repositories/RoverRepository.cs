using MarsRoverProblem.Enums;
using MarsRoverProblem.Models;
using MarsRoverProblem.Responses;
using System;

namespace MarsRoverProblem.Repositories
{
    public class RoverRepository : IRepository<Rover>
    {
        public ResponseBase CanIDo(Rover item, Plateau plateau)
        {
            var response = new ResponseBase();
            switch (item.Direction)
            {
                case Directions.N:
                    if(item.yCoor < plateau.yLastCoor) {
                        response.IsOk = true;
                    }
                    else
                    {
                        response.Message = Messages.UnableToNorth;
                    }
                    break;
                case Directions.E:
                    if (item.xCoor < plateau.xLastCoor)
                    {
                        response.IsOk = true;
                    }
                    else
                    {
                        response.Message = Messages.UnableToEast;
                    }
                    break;
                case Directions.S:
                    if (item.yCoor > 0)
                    {
                        response.IsOk = true;
                    }
                    else
                    {
                        response.Message = Messages.UnableToSouth;
                    }
                    break;
                case Directions.W:
                    if (item.xCoor > 0)
                    {
                        response.IsOk = true;
                    }
                    else
                    {
                        response.Message = Messages.UnableToWest;
                    }
                    break;
                default:
                    break;
            }
            return response;
        }

        public ResponseBase Move(Rover item, Plateau plateau)
        {
            var response = CanIDo(item, plateau);
            if (response.IsOk)
            {
                switch (item.Direction)
                {
                    case Directions.N:
                        item.yCoor += 1;
                        break;
                    case Directions.E:
                        item.xCoor += 1;
                        break;
                    case Directions.S:
                        item.yCoor -= 1;
                        break;
                    case Directions.W:
                        item.xCoor -= 1;
                        break;
                    default:
                        break;
                }
            }
            return response;
        }

        public void Rotate(Rover item, char key)
        {
            var currentDirection = (int)item.Direction;
            switch (key)
            {
                case 'R':
                    currentDirection += 1;
                    break;
                case 'L':
                    currentDirection += 3;
                    break;
                default:
                    break;
            }
            currentDirection %= 4;
            item.Direction = (Directions)currentDirection;
        }
    }
}
