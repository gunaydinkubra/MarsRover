using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class PositonModel
    {
        public DirectionEnum Direction { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
