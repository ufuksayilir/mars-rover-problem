using MarsRoverProblem.Enums;

namespace MarsRoverProblem.Models
{
    public class Rover
    {
        private static int counter = 0;

        public int Id { get; private set; }
        public int? xCoor { get; set; }
        public int? yCoor { get; set; }
        public Directions? Direction { get; set; }
        public string Instructions { get; set; }

        public bool isReadyForAction {
            get {
                if (xCoor != null && yCoor != null && Direction !=null)
                {
                    return true;
                }
                return false;
            } 
        }

        public Rover()
        {
            counter++;
            this.Id = counter;
        }

        public string GetCoordinates()
        {
            return $"({xCoor},{yCoor})";
        }

        public string GetName()
        {
            return $"{Id}. Rover";
        }
    }
}
