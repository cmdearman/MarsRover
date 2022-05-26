using MarsRover_CarsonDearman.Models;

namespace MarsRover_CarsonDearman.Classes
{
    public class CreateOutput
    {
        public string makeOutput(List<Rover> roverList)
        {
            string returnOutput = String.Empty;
            foreach(Rover rover in roverList)
            {
                string addString = string.Concat(rover.roverCoordinates.roverXCoord," ",rover.roverCoordinates.roverYCoord," ",rover.roverHeading,Environment.NewLine);
                returnOutput+=addString;
            }
            return returnOutput;

        }
    }
}
