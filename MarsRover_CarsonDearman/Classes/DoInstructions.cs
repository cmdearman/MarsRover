using MarsRover_CarsonDearman.Models;

namespace MarsRover_CarsonDearman.Classes
{
    public class DoInstructions
    {
        public List<Rover> DoMoves(List<Rover> roverList, string rangeCoords)
        {
            List<Rover> RoverResults = new List<Rover>();
            foreach(Rover rover in roverList)
            {
                Rover addRover = executeInstruction(rover);
                if(isRoverValid(addRover, rangeCoords)==true)
                {
                    RoverResults.Add(addRover);
                }
            }
            return RoverResults;
        }
        private Rover executeInstruction(Rover rover)
        {
            int xCoord = int.Parse(rover.roverCoordinates.roverXCoord);
            int yCoord = int.Parse(rover.roverCoordinates.roverYCoord);
            string heading = rover.roverHeading;
            List<char> rotateList = new List<char> { 'L','R' };
            List<char> instructionList = new List<char>();
            instructionList.AddRange(rover.roverInstructions);
            foreach(char c in instructionList)
            {
                if(rotateList.Contains(c))
                {
                    heading = doRotate(heading, c).ToString();
                }
                else
                {
                    if(heading == "N"|| heading == "S")
                    {
                        int updateYCoord = doMove(heading, yCoord);
                        yCoord = updateYCoord;
                    } else if(heading == "E"|| heading == "W")
                    {
                        int updateXCoord = doMove(heading,xCoord);
                        xCoord = updateXCoord;
                    }
                }
            }
            RoverCoord returRoverCoord = new RoverCoord(xCoord.ToString(), yCoord.ToString());
            return new Rover(returRoverCoord, heading, rover.roverInstructions);
        }
        private bool isRoverValid(Rover rover, string rangeCoords)
        {
            bool roverValidity = true;
            List<string> rangeList = rangeCoords.Split(" ").ToList();
            int xRangeCoord = int.Parse(rangeList[0]);
            int yRangeCoord = int.Parse(rangeList[1]);
            if (xRangeCoord<int.Parse(rover.roverCoordinates.roverXCoord) || yRangeCoord<int.Parse(rover.roverCoordinates.roverYCoord))
            {
                roverValidity = false;
            }

            return roverValidity;

        }
        //almost certainly a better way to do the following two methods, but I'm really not sure. maybe an enum?
        private string doRotate(string curHead, char rotateDirection)
        {
   
            switch(curHead)
            {
                case "N":
                    if (rotateDirection == 'L')
                    {
                        return "W";
                    }
                    else
                    {
                        return "E";
                    }
                case "S":
                    if (rotateDirection == 'L')
                    {
                        return "E";
                    }
                    else
                    {
                        return "W";
                    }
                case "E":
                    if (rotateDirection == 'L')
                    {
                        return "N";
                    }
                    else
                    {
                        return "S";
                    }
                case "W":
                    if (rotateDirection == 'L')
                    {
                        return "S";
                    }
                    else
                    {
                        return "N";
                    }
                default: return "N";
            }
        }
        private int doMove(string head, int coord)
        {
            switch(head)
            {
                case "N":
                    {
                        coord++;
                        return coord;
                    }
                case "S":
                    {
                        coord--;
                        return coord;
                    }
                case "W":
                    {
                        coord--;
                        return coord;
                    }
                case "E":
                    {
                        coord++;
                        return coord;
                    }
                default: return coord;
            }
                
        }
    }
}
