using MarsRover_CarsonDearman.Models;

namespace MarsRover_CarsonDearman.Classes
{
    public class RoverFactory
    {
        public List<Rover> makeRovers(RoverData inputData)
        {
            int rovercount = 0;
            List<Rover> rovers = new List<Rover>();
            while (rovercount < inputData.roverHeadings.Count)
            {
                Rover rover = new Rover(
                    inputData.roverCoords[rovercount],
                    inputData.roverHeadings[rovercount],
                    inputData.roverInstructions[rovercount]
                    );
                rovers.Add(rover);
                rovercount++;
            }

            return rovers;
        }
    }
}
