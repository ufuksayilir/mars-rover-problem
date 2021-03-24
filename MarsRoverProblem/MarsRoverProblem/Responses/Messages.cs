namespace MarsRoverProblem.Responses
{
    public static class Messages
    {
        public static string SpaceBetweenInputs = " ***There is a space between all input parameters.";

        public static string UnableToNorth = "can not go further North.";
        public static string UnableToEast = "can not go further East.";
        public static string UnableToSouth = "can not go further South.";
        public static string UnableToWest = "can not go further West.";

        public static string NonNumericData = "Please enter \"integer\" values.";

        public static string NotPositivePlateauData = "Coordinates must be positive integer values.";
        public static string NotTwoPlateauData = "You should enter only two integers.";

        public static string NotThreeRoverData = "You should enter two integers first, then a direction letter (N, E, S, W).";
        public static string NotLocatedInPlateau = "Chosen deployment location is out of plateau.";
        public static string MultipleDirectionData = "Direction must be \"a\" letter (N, E, S, W).";
        public static string InvalidDirectionData = "Direction letter must be one of N, E, S or W.";

        public static string InvalidActionData = "Series of instructions should consist of the letters L, R or M.";

    }
}
