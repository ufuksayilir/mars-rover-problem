namespace MarsRoverProblem.Models
{
    public class Plateau
    {
        public int xLastCoor { get; private set; }
        public int yLastCoor { get; private set; }

        public Plateau(int xCoor, int yCoor)
        {
            this.xLastCoor = xCoor;
            this.yLastCoor = yCoor;
        }
    }
}
