using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarsRover_CarsonDearman.Classes;
using MarsRover_CarsonDearman.Models;

namespace MarsRover_CarsonDearman.Controllers
{
    
    [Route("api/[controller]")]
    public class RoverController : ControllerBase 
    {
        [HttpPost]
        public string JsonStringBody([FromBody] string directions)
        {
            DirectionsParser dParse = new DirectionsParser();
            RoverData roverData = dParse.getRoverData(directions);//remove spaces and newLines, returns list of headings, coordinates, and instructions
            
            RoverFactory rFactory = new RoverFactory();
            List<Rover> roverList = rFactory.makeRovers(roverData);//groups those three lists into objects
            
            DoInstructions doInstructions = new DoInstructions();
            List<Rover> postMoveList = doInstructions.DoMoves(roverList, dParse.getRangeCoords(directions));//iterates over the moves for each object
            
            CreateOutput createOutput = new CreateOutput();
            string output = createOutput.makeOutput(postMoveList);//send some output back to the client
          
            return output;
        }

    }

}
