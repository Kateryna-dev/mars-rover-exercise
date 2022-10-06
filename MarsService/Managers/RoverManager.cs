using System;
using System.Collections.Generic;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Managers
{
    public class RoverManager
    {

        private Dictionary<int, IRover>  _allRovers { get; set; }
        private Dictionary<int, Command> _allComands{ get; set; }
        private IPlateau singlePlateau;

        public RoverManager()
        {
            _allRovers = new Dictionary<int, IRover>();
            _allComands = new Dictionary<int, Command>();
        }


        public bool GetReadyForMission(List<Position> roversPositionsList, List<RoverInstruction[]> roverInstructionsSetList, IPlateau plateau)
        {
            if (roversPositionsList != null && roverInstructionsSetList != null && plateau != null)
            {
                singlePlateau = plateau;
                IRover rover;
                Command command;

                for (int i = 0; i < roversPositionsList.Count; i++)
                {
                    rover = new Rover(roversPositionsList[i], singlePlateau);
                    _allRovers.Add(rover.Id, rover);
                    command = new Command(roverInstructionsSetList[i]);
                    _allComands.Add(rover.Id, command);
                }
                return true;
            }
            return false;
        }

        public bool ExecuteAllCommands() 
        {
            if (_allRovers == null || _allComands == null)
                return false;

            foreach (KeyValuePair<int, Command> roverIdCommandPair in _allComands)
                _allRovers[roverIdCommandPair.Key].ExecuteCommand(roverIdCommandPair.Value);

            return true;
        }

        public string[] GetRoversPositionsOutput() 
        {
            return (_allRovers != null && _allRovers.Count > 0) ?
                _allRovers.Select(keyValuePair => keyValuePair.Value.GetPosition().ToString()).ToArray() : new string[] {};
        }
    }
}
