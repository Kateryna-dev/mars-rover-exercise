using FluentAssertions;
using System.Drawing;
using MarsService.Models;
using MarsService.Enums;

namespace MarsService.Tests
{
    public class CommandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("LLRM", new RoverInstruction[]{ RoverInstruction.L, RoverInstruction.L, RoverInstruction.R, RoverInstruction.M})]
        [TestCase("MLL", new RoverInstruction[] { RoverInstruction.M, RoverInstruction.L, RoverInstruction.L})]
        [TestCase("RM", new RoverInstruction[] { RoverInstruction.R, RoverInstruction.M })]
        [TestCase("R", new RoverInstruction[] { RoverInstruction.R})]
        public void GenerateInstructionsFromString_Shoud_Work(string input, RoverInstruction[] result)
        {
            Command cmd = new Command(input);
            cmd.GenerateInstructionsFromString(input);
            cmd.Instructions.Should().BeEquivalentTo(result);
        }
    }
}
