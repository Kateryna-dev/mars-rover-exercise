
using System.Drawing;
using FluentAssertions;
using MarsService.Managers;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Tests
{
    public class DataIOManagerTests
    {
        private DataIOManager _dataIOManager;

        [SetUp]
        public void Setup()
        {
            _dataIOManager = new DataIOManager();
        }


        [TestCase("2 2", true)]
        [TestCase("1 2", true)]
        [TestCase("-2 2", false)]
        [TestCase("232", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("two", false)]
        public void TryParsePlateauSizeString_Shoud_Work(string sizeString, bool result)
        {
            _dataIOManager.TryParsePlateauSizeString(sizeString, out Point point).Should().Be(result);
        }


        [TestCase("N", true, CardinalDirection.North)]
        [TestCase("E", true, CardinalDirection.East)]
        [TestCase("S", true, CardinalDirection.South)]
        [TestCase("W", true, CardinalDirection.West)]
        [TestCase("", false, CardinalDirection.North)]
        [TestCase(null, false, CardinalDirection.North)]
        [TestCase("HELLO", false, CardinalDirection.North)]
        public void TryGetDirectionFromSubString_Shoud_Work(string directionString, bool result, CardinalDirection directionResult)
        {
            
            _dataIOManager.TryGetDirectionFromSubString(directionString, out CardinalDirection direction)
                .Should().Be(result);
            if (result) 
                direction.Should().Be(directionResult); 

        }

        [TestCase("2 2 N", true)]
        [TestCase("1 2 W", true)]
        [TestCase("-1 2 W", false)]
        [TestCase("Wild Wild West", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("W W", false)]
        public void TryParseRoverPositionString_Shoud_Work(string positionString, bool result)
        {
            _dataIOManager.TryParseRoverPositionString(positionString, out Position position).Should().Be(result);
            if (result)
                positionString.Should().Be($"{position.Coordinate.X} {position.Coordinate.Y} {position.Orientation.ToString()[0]}");
        }

        [TestCase("LLRM", true, new RoverInstruction[] { RoverInstruction.L, RoverInstruction.L, RoverInstruction.R, RoverInstruction.M })]
        [TestCase("MLL", true, new RoverInstruction[] { RoverInstruction.M, RoverInstruction.L, RoverInstruction.L })]
        [TestCase("RM", true, new RoverInstruction[] { RoverInstruction.R, RoverInstruction.M })]
        [TestCase("HELLO", false, new RoverInstruction[] {})]
        [TestCase("1 3", false, new RoverInstruction[] {})]
        [TestCase(null, false, new RoverInstruction[] {})]
        [TestCase("", false, new RoverInstruction[] {})]
        public void TryParseRoverInstructionsString_Shoud_Work(string instructionsString, bool result, RoverInstruction[] roverInstructions)
        {
            _dataIOManager.TryParseRoverInstructionsString(instructionsString, out RoverInstruction[] instructions).Should().Be(result);
            if (result)
                Assert.True(roverInstructions.SequenceEqual(instructions));
        }
    }
}
