using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Objects
{
    public class GetMarsRoverPositionRequestObject
    {
        public string CurrentPosition { get; set; }
        public string Command { get; set; }
    }
}
