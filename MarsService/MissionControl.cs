using System.Drawing;
using MarsService.Models;
using MarsService.Managers;
using MarsService.Enums;

namespace MarsService
{
    public class MissionControl
    {
        private MapManager _mapManager;
        private RoverManager _roverManager;
        private DataIOManager _dataInputOutputManager;
        private bool MissionIsPossible;

        public MissionControl(string[] inputs) 
        {
            _dataInputOutputManager = new DataIOManager();
            _mapManager = new MapManager();
            _roverManager = new RoverManager();

            MissionIsPossible = _dataInputOutputManager.ProcessInputData(inputs, out Point plateauSize,
                out List<Position> roversPositionsList, out List<RoverInstruction[]> roverInstructionSetList);

            if (MissionIsPossible)
            {
                _mapManager.CreateNewPlateau(plateauSize);
                _roverManager.GetReadyForMission(roversPositionsList, roverInstructionSetList, _mapManager.currentPlateau);
            }
        }

        //public bool StartMission() => MissionIsPossible && _roverManager.ExecuteAllCommands();
        public void StartMission()
        {
            if (MissionIsPossible)
            { 
                _roverManager.ExecuteAllCommands();
                string[] result = _roverManager.GetRoversPositionsOutput();
                foreach(string s in result)
                    Console.WriteLine(s);
                Console.ReadKey();
            }

        }
    }
}