using MarsRoverProblem.Models;
using MarsRoverProblem.Responses;
using System;

namespace MarsRoverProblem.Validations
{
    public static class PlateauCreationControl
    {
        public static ResponseBase Do(string plateauData, out Plateau plateau)
        {
            var response = new ResponseBase();
            plateau = null;
            string[] plateauCoordinates = plateauData.Split(' ');
            if (plateauCoordinates.Length != 2)
            {
                response.Message = Messages.NotTwoPlateauData;
                return response;
            }
            try
            {
                var x = Int32.Parse(plateauCoordinates[0]);
                var y = Int32.Parse(plateauCoordinates[1]);
                if (x > 0 && y > 0)
                {
                    plateau = new Plateau(x, y);
                    response.IsOk = true;
                    return response;
                }
                response.Message = Messages.NotPositivePlateauData;
                return response;
            }
            catch (Exception)
            {
                response.Message = Messages.NonNumericData;
                return response;
            }
        }

    }
}
