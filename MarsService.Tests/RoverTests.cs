using FluentAssertions;
using System.Drawing;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Tests
{
    public class RoverTests
    {
        private Rover _rover;
        Plateau _plateau;

        [SetUp]
        public void Setup()
        {
            _plateau = new Plateau(new Point(10, 10));
            Position position = new Position(new(1,1), CardinalDirection.North);
            _rover = new Rover(position, _plateau);
        }

        [Test]
        public void Move_Shoud_Work()
        {
            _rover.Move();
            _rover.GetPosition().Coordinate.X.Should().Be(1);
            _rover.GetPosition().Coordinate.Y.Should().Be(2);
            _rover.GetPosition().Orientation.Should().Be(CardinalDirection.North);
            _plateau.IsAvailiable(new(1, 2)).Should().BeFalse();
        }

        [TestCase(RoverInstruction.L, "1 1 West")]
        [TestCase(RoverInstruction.R, "1 1 East")]
        [TestCase(RoverInstruction.M, "1 2 North")]
        public void ExecuteMovingInstruction_Should_Work(RoverInstruction instruction, string resultString) 
        {
            _rover.ExecuteMovingInstruction(instruction);
            string positionString = $"{_rover.GetPosition().Coordinate.X} {_rover.GetPosition().Coordinate.Y} {_rover.GetPosition().Orientation}";
            positionString.Should().Be(resultString); 
        }

        //[Test]
        //public void ExecuteCommand_Should_Work(){}
    }
}
