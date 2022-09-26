using System.Drawing;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Managers
{
    public class DataIOManager
    {
        const int NUMBER_OF_WORDS_IN_SIZE_INPUT = 2;
        const int NUMBER_OF_WORDS_IN_POSITION_INPUT = 3;
        const int MIN_NUMBER_OF_STRING_IN_INPUT = 3;

        public DataIOManager()
        {
        }

        public bool ProcessData(string[] inputs)
        {
            //if (inputs == null || inputs.Length < 3)
            //    return false;
            return true;
        }


        internal bool TryParsePlateauSizeString(string plateauSizeString, out Point point) 
        {
            point = new Point(0, 0);
            if (string.IsNullOrWhiteSpace(plateauSizeString))
                return false;

            string[] plateauArr = plateauSizeString.Split();
            if (plateauArr.Length != NUMBER_OF_WORDS_IN_SIZE_INPUT)
                return false;

            int x, y;
            if (!Int32.TryParse(plateauArr[0], out x) || !Int32.TryParse(plateauArr[1], out y))
                return false;

            if (x <= 0 || y <= 0) 
                return false;

            point = new Point(x, y);
            return true;
        }

        internal bool TryGetDirectionFromSubString(string directionString, out CardinalDirection direction)
        {
            direction = CardinalDirection.North;
            if (string.IsNullOrWhiteSpace(directionString))
                return false;

            CardinalDirection? dir = directionString switch
            {
                "N" => CardinalDirection.North,
                "E" => CardinalDirection.East,
                "S" => CardinalDirection.South,
                "W" => CardinalDirection.West,
                _ => null
            };

            direction = dir.GetValueOrDefault();
            return dir.HasValue;
        }

        internal bool TryParseRoverPositionString(string positionString, out Position position)
        {
            position = new Position();

            if (string.IsNullOrWhiteSpace(positionString))
                return false;

            string[] roverPosition = positionString.Split();
            if (roverPosition.Length != NUMBER_OF_WORDS_IN_POSITION_INPUT)
                return false;

            int x, y;
            if (!Int32.TryParse(roverPosition[0], out x) || !Int32.TryParse(roverPosition[1], out y))
                return false;

            if (x <= 0 || y <= 0)
                return false;

            if (!TryGetDirectionFromSubString(roverPosition[2], out CardinalDirection direction))
                return false;

            position = new Position(new Point(x, y), direction);
            return true;
        }

        internal bool TryParseRoverInstructionsString(string instructionsString, out RoverInstruction[] roverInstructions)
        {
            if (string.IsNullOrWhiteSpace(instructionsString))
            {
                roverInstructions = new RoverInstruction[0];
                return false;
            }

            roverInstructions = new RoverInstruction[instructionsString.Length];
            char[] instructionsArray = instructionsString.ToCharArray();
            RoverInstruction? instruction;

            for (int i = 0; i < instructionsArray.Length; i++)
            {
                instruction = instructionsArray[i] switch
                {
                    'L' => RoverInstruction.L,
                    'R' => RoverInstruction.R,
                    'M' => RoverInstruction.M,
                    _ => null
                };
                if (instruction == null)
                    return false;
                
                roverInstructions[i] = instruction.GetValueOrDefault();
            }
            return true;
        }

    }
}
