using System.Text.RegularExpressions;
using System.Collections.Generic;
using MarsRover_CarsonDearman.Models;

namespace MarsRover_CarsonDearman.Classes
{
    public class DirectionsParser
    {
        public string reducedDirections(string directions)
        {
            string? rangeCoords = getRangeCoords(directions);
            //string flatLineDirections = removeWhiteSpace(directions);//really glad I didn't go this way
            int removeLen = rangeCoords.Length;
            string reducedDirections =  directions.Replace("\n", "").Replace("\r", "").Remove(0,removeLen); //removes newline and origin
            return reducedDirections;
        }  
        public string getRangeCoords(string directions)
        {
            string? createOriginCoords = directions is null ? "5 5" : new StringReader(directions).ReadLine(); //defaults range to 5,5
            string spaceDelimit = Regex.Replace(createOriginCoords, @"\s+", " ");//removes mutliple white spaces, replaces with single white spaces
            int countDelimit = spaceDelimit.Split(" ").Length;
            
            if (countDelimit == 2) //if this is more than 2, we got more than one set of coords on the first line
            {
                return createOriginCoords;
            } else
            {
                return "5 5";
            }
        }

        public RoverData getRoverData(string directions)
        {
            string reducedRoverData = reducedDirections(directions);
            string upperDirections = reducedRoverData.ToUpper();

            //get only coordinates/heading data
            List<string> roverData = new List<string>();
            List<char> moveChars = new List<char> { 'L','M','R' };
            string onlyRoverData = string.Concat(upperDirections.Split(moveChars.ToArray())); //returns only rover coords and heading like  1 2 N    3 3 E   

            //get only starting coordinates
            List<char> headingChars = new List<char> { 'N', 'S', 'E', 'W' };
            string onlyCoordinateInfo = string.Concat(onlyRoverData.Split(headingChars.ToArray())).Trim();//this is space delimited coordinates
            var coordList = onlyCoordinateInfo.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
            string spaceDelimitedCoordinateInfo = string.Join(" ", coordList);
            List<string> roverCoordListInfo = spaceDelimitedCoordinateInfo.Split(" ").ToList();
            List<RoverCoord> roverCoordList = new List<RoverCoord>();
            for (int i = 0; i < roverCoordListInfo.Count; i+=2)
            {
                roverCoordList.Add(new RoverCoord(roverCoordListInfo[i], roverCoordListInfo[i+1]));
            }

            //get only heading information
            List<char> coordinateChars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };//there's almost certainly a more elegant way than this
            string onlyHeadingInfo = removeWhiteSpace(string.Concat(onlyRoverData.Split(coordinateChars.ToArray())));
            List<string> roverHeadingList = new List<string>(onlyHeadingInfo.Select(c => c.ToString()));

            //get only move instructions
            string removedCoords = string.Concat(upperDirections.Split(headingChars.ToArray()));
            string onlyMoveInstructions = string.Concat(removedCoords.Split(coordinateChars.ToArray())).Trim();
            string singleSpaceInstructions = Regex.Replace(onlyMoveInstructions, @"\s+", " ").Trim();
            List<string> roverInstructions = singleSpaceInstructions.Split(" ").ToList();

            return new RoverData(roverHeadingList, roverCoordList, roverInstructions);
        }

        private string removeWhiteSpace(string input)
        {
          return  string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
        }
        //TODO:method for checking for bogus characters, migrate removeWhiteSpace to utilities class
    }
}
