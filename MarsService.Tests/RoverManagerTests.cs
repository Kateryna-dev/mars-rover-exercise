using FluentAssertions;
using System.Drawing;
using MarsService.Managers;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Tests
{
    public class RoverManagerTests
    {
        RoverManager roverManager;
        List<Position> roversPositionsList;
        List<RoverInstruction[]> roverInstructionsSetList;
        IPlateau plateau;

        [SetUp]
        public void Setup()
        {
            roverManager = new RoverManager();
            plateau = new Plateau(new Point(10, 10));
            roversPositionsList = new List<Position>() { new Position(new Point(1, 1), CardinalDirection.North), 
                new Position(new Point(2, 2), CardinalDirection.South) };
            roverInstructionsSetList = new List<RoverInstruction[]>() { new RoverInstruction[] { RoverInstruction.L }, 
                new RoverInstruction[] { RoverInstruction.L } };

            roverManager.GetReadyForMission(roversPositionsList, roverInstructionsSetList, plateau);
        }

        [Test]
        public void GetRoversPositionsOutput_Shoud_Work()
        {
            roverManager.GetRoversPositionsOutput().Should().BeEquivalentTo(new string[] { "1 1 N", "2 2 S" });
        }
    }
}
