using System;
using System.Collections.Generic;
using MarsService.Models;

namespace MarsService.Managers
{
    public class RoverManager
    {
        private Dictionary<int, IRover>  AllRovers { get; set; }

        public RoverManager(Position[] roversPositions) 
        {
            if (roversPositions != null) 
            {
                AllRovers = new Dictionary<int, IRover>();
                foreach (var roverPosition in roversPositions)
                    CreateRover(roverPosition);

            }

        }

        private void CreateRover(Position roverPosition) 
        {

        }


        public bool SendCommandTo(Rover rover, Command command) 
        {
            return false;
        }
    }
}
