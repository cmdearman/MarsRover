namespace MarsRover_CarsonDearman.Models
{
    public class Range 
    {
        public int rangeXCoord { get; set; }
        public int rangeYCoord { get; set; } 
    }

    public class Origin 
    {
        public int originXCoord { get; set; }
        public int originYCoord { get; set; }
    }
    public struct RoverCoord
    {
        public string roverXCoord { get; set; }
        public string roverYCoord { get; set; }
        public RoverCoord(string RoverXCoord, string RoverYCoord)
        {
            roverXCoord = RoverXCoord;
            roverYCoord = RoverYCoord;
        }
    }
    public struct RoverData
    {
        public List<string> roverHeadings;
        public List<RoverCoord> roverCoords;
        public List<string> roverInstructions;
        public RoverData(List<string> RoverHeadings, List<RoverCoord> RoverCoords, List<string> RoverInstructions)
        {
            roverHeadings = RoverHeadings;
            roverCoords = RoverCoords;
            roverInstructions = RoverInstructions;
        }
    }
}
