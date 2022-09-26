using MarsService.Managers;

namespace MarsService
{
    public class MissionControl
    {
        private MapManager _mapManager;
        private RoverManager _roverManager;
        private DataIOManager _dataInputOutputManager;
        public MissionControl()
        {
            string[] inputs = new string[0];
            _dataInputOutputManager = new DataIOManager();
            _dataInputOutputManager.ProcessData(inputs);
            _mapManager = new MapManager();
        }
    }
}
