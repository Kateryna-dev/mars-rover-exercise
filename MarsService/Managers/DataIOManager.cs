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

        public bool ProcessInputData(string[] inputs, out Point plateauSize, out List<Position> roversPositionsList, 
            out List<RoverInstruction[]> roverInstructionSetList)
        {

            plateauSize = new Point();
            roversPositionsList = new();
            roverInstructionSetList = new();

            if (inputs == null || inputs.Length % 2 == 0 || inputs.Length < MIN_NUMBER_OF_STRING_IN_INPUT)
                return false;

            if (!TryParsePlateauSizeString(inputs[0], out plateauSize))
                return false;

            for (int i = 1; i < inputs.Length - 1; i++)
            {
                if (!TryParseRoverPositionString(inputs[i], out Position position) ||
                    !TryParseRoverInstructionsString(inputs[i + 1], out RoverInstruction[] roverInstructions))
                    return false;

                roversPositionsList.Add(position);
                roverInstructionSetList.Add(roverInstructions);
                i++;
            }

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

            return TryParseCoordinates(plateauArr, out point);
        }


        internal bool TryParseCoordinates(string[] coordinateSubstrings, out Point point) 
        {
            point = new Point(0, 0);
            if (coordinateSubstrings == null)
                return false;

            int x, y;
            if (!Int32.TryParse(coordinateSubstrings[0], out x) || !Int32.TryParse(coordinateSubstrings[1], out y))
                return false;

            if (x <= 0 || y <= 0)
                return false;

            point = new Point(x, y);
            return true;
        }

        internal bool TryParseRoverPositionString(string positionString, out Position position)
        {
            Point point = new Point(0, 0);
            CardinalDirection direction = CardinalDirection.North;
            position = new Position();

            if (string.IsNullOrWhiteSpace(positionString))
                return false;

            string[] roverPosition = positionString.Split();
            if (roverPosition.Length != NUMBER_OF_WORDS_IN_POSITION_INPUT)
                return false;

            if (!TryParseCoordinates(roverPosition, out point)
                || !TryGetDirectionFromSubString(roverPosition[2], out direction))
                return false;

            position = new Position(point, direction);
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
