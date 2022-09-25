using FluentAssertions;
using System.Drawing;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Tests
{
    public class PositionTests
    {
        private Position position;

        [SetUp]
        public void Setup()
        {
            position = new Position(new Point(3, 3), CardinalDirection.North);
        }

        [TestCase(CardinalDirection.North, CardinalDirection.East)]
        [TestCase(CardinalDirection.East, CardinalDirection.South)]
        [TestCase(CardinalDirection.South, CardinalDirection.West)]
        [TestCase(CardinalDirection.West, CardinalDirection.North)]
        public void IncrementDirection_Shoud_Work(CardinalDirection before, CardinalDirection after)
        {
            position.Orientation = before;
            position.IncrementDirection();
            position.Orientation.Should().Be(after);
        }


        [TestCase(CardinalDirection.North, CardinalDirection.West)]
        [TestCase(CardinalDirection.West, CardinalDirection.South)]
        [TestCase(CardinalDirection.South, CardinalDirection.East)]
        [TestCase(CardinalDirection.East, CardinalDirection.North)]
        public void DecrementDirection_Shoud_Work(CardinalDirection before, CardinalDirection after)
        {
            position.Orientation = before;
            position.DecrementDirection();
            position.Orientation.Should().Be(after);
        }

        [TestCase(CardinalDirection.North, 3, 4)]
        [TestCase(CardinalDirection.West, 2, 3)]
        [TestCase(CardinalDirection.South, 3, 2)]
        [TestCase(CardinalDirection.East, 4, 3)]
        public void GetNextCoordinates_Shoud_Work(CardinalDirection direction, int nextX, int nextY) 
        {
            position.Orientation = direction;
            position.GetNextCoordinates().Should().Be(new Point(nextX, nextY));
        }
    }
}
