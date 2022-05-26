namespace MarsRover_CarsonDearman.Models
{
    public struct Rover
    {
        public RoverCoord roverCoordinates;
        public string roverHeading;
        public string roverInstructions;
        public Rover(RoverCoord RoverCoordinates, string RoverHeading, string RoverInstructions)
        {
            roverCoordinates = RoverCoordinates;
            roverHeading = RoverHeading;
            roverInstructions = RoverInstructions;
        }
        
    }
}
