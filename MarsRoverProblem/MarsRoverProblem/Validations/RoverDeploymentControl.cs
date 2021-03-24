using MarsRoverProblem.Enums;
using MarsRoverProblem.Models;
using MarsRoverProblem.Responses;
using System;

namespace MarsRoverProblem.Validations
{
    public static class RoverDeploymentControl
    {
        public static ResponseBase Do(string roverData, Plateau plateau, ref Rover rover)
        {
            var response = new ResponseBase();
            string[] roverPosition = roverData.Split(' ');
            if (roverPosition.Length != 3)
            {
                response.Message = Messages.NotThreeRoverData;
                return response;
            }

            try
            {
                var x = Int32.Parse(roverPosition[0]);
                var y = Int32.Parse(roverPosition[1]);
                if (!(x >= 0 && x <= plateau.xLastCoor && y >= 0 && y <= plateau.yLastCoor))
                {
                    response.Message = Messages.NotLocatedInPlateau;
                    return response;
                }
                rover.xCoor = x;
                rover.yCoor = y;
            }
            catch (Exception)
            {
                response.Message = Messages.NonNumericData;
                return response;
            }

            if (roverPosition[2].Length != 1)
            {
                response.Message = Messages.MultipleDirectionData;
                return response;
            }

            foreach (string direction in Enum.GetNames(typeof(Directions)))
            {
                if (direction.Contains(roverPosition[2]))
                {
                    rover.Direction = (Directions)Enum.Parse(typeof(Directions), roverPosition[2]);
                    response.IsOk = true;
                    return response;
                }
            }
            response.Message = Messages.InvalidDirectionData;
            return response;
        }
    }
}
