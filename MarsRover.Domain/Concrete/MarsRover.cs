using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class MarsRover : Rover
    {
        public MarsRover(string RoverName, int XCoordinate, int YCoordinate, char CompassDirection) 
            : base(RoverName, XCoordinate, YCoordinate, CompassDirection)
        {
        }
    }
}
