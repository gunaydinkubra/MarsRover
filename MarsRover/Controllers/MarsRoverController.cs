using MarsRover.Enum;
using MarsRover.Models;
using MarsRover.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MarsRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsRoverController : ControllerBase
    {
        [Route("GetRoverPosition")]
        [HttpPost]
        public ActionResult<string> GetRoverPosition([FromBody]  GetMarsRoverPositionRequestObject requestObject)
        {
            var currentPosition = requestObject.CurrentPosition.Split(" ");
            var commadList = requestObject.Command.ToList();

            if (currentPosition.Count() != 3)
                return "CurrentPosition value is invalid! CurrentPosition:" + currentPosition;


            if (Enum.DirectionEnum.IsDefined(typeof(DirectionEnum), currentPosition[2]) == false)
                return "Direction is invalid! Direction:" + currentPosition[2];

            PositonModel positonModel = new PositonModel();
            positonModel.XCoordinate = Convert.ToInt32(currentPosition[0]);
            positonModel.YCoordinate = Convert.ToInt32(currentPosition[1]);
            positonModel.Direction = (DirectionEnum)Enum.DirectionEnum.Parse(typeof(DirectionEnum), currentPosition[2]);

            foreach (var command in commadList)
            {
                if (Enum.CommandEnum.IsDefined(typeof(CommandEnum), command.ToString()) == false)
                    return "Command is invalid! CommandCode:" + command;

                if (command == (char)CommandEnum.L)
                {
                    positonModel.Direction = (positonModel.Direction - 1) < DirectionEnum.N ? DirectionEnum.W : (positonModel.Direction - 1);
                }
                else if (command == (char)CommandEnum.R)
                {
                    positonModel.Direction = (positonModel.Direction + 1) > DirectionEnum.W ? DirectionEnum.N : (positonModel.Direction + 1);

                }
                else if (command == (char)CommandEnum.M)
                {
                    if (positonModel.Direction == DirectionEnum.N)
                    {
                        positonModel.YCoordinate++;
                    }
                    else if (positonModel.Direction == DirectionEnum.E)
                    {
                        positonModel.XCoordinate++;
                    }
                    else if (positonModel.Direction == DirectionEnum.S)
                    {
                        positonModel.YCoordinate--;
                    }
                    else if (positonModel.Direction == DirectionEnum.W)
                    {
                        positonModel.XCoordinate--;
                    }
                }
            }
            return positonModel.XCoordinate + " " + positonModel.YCoordinate + " " + positonModel.Direction;
        }


        [HttpGet]
        public ActionResult<string> Index()
        {

            return "";
        }



    }
}
