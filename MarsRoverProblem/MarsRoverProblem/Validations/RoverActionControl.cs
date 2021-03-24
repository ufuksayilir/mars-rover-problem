using MarsRoverProblem.Responses;

namespace MarsRoverProblem.Validations
{
    public static class RoverActionControl
    {
        public static void Do(string actionData, ref ResponseBase response)
        {
            foreach (var c in actionData)
            {
                if (!(c == 'L' || c == 'R' || c == 'M'))
                {
                    response.Message = Messages.InvalidActionData;
                    return;
                }
            }
            response.IsOk = true;
            return;
        }
    }
}
