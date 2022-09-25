using System.Drawing;
using MarsService.Enums;

namespace MarsService.Models
{
    public class Rover : IRover
    {
        private int _id;
        private Position _currentPosition;
        private IPlateau _iplateau;
        private static int count;

        public int Id { get { return _id; } }
        public Position GetPosition() => this._currentPosition;

        public Rover(Position roverPosition, IPlateau iplateau)
        {
            _id = count++; 
            _currentPosition = roverPosition;
            _iplateau = iplateau;
        }

        public bool ExecuteCommand(Command cmd) 
        {
            if (cmd == null) return false;
            cmd.Status = CommandStatus.InProcess;

            foreach (RoverInstruction instruction in cmd.Instructions)
            {
                if (!ExecuteMovingInstruction(instruction))
                {
                    cmd.Status = CommandStatus.Failed;
                    return false;
                }
            }
            cmd.Status = CommandStatus.Success;
            return true;
        }

        internal bool ExecuteMovingInstruction(RoverInstruction instruction) => instruction switch
        {
            RoverInstruction.L => SpinLeft(),
            RoverInstruction.R => SpinRight(),
            RoverInstruction.M => Move()
        };

        internal bool Move() 
        {
            Point nextPoint = this._currentPosition.GetNextCoordinates();
            if (_iplateau.IsAvailiable(nextPoint))
            {
                _iplateau.MarkAsNotAvailiable(nextPoint);
                _iplateau.MarkAsAvailiable(_currentPosition.Coordinate);
                _currentPosition.Coordinate = nextPoint;
                return true;
            }
            return false;    
        }

        private bool SpinLeft()
        {
            this._currentPosition.DecrementDirection();
            return true;
        }

        private bool SpinRight() 
        {
            this._currentPosition.IncrementDirection();
            return true;
        }
    }
}
