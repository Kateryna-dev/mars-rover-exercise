using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsService.Enums;

namespace MarsService.Models
{
    public class Command
    {
        public RoverInstruction[] Instructions { get; private set; }
        public CommandStatus Status { get; set; }

        public Command(string sequence) 
        {
            this.Instructions = GenerateInstructionsFromString(sequence);
            this.Status = CommandStatus.Non;
        }

        internal RoverInstruction[] GenerateInstructionsFromString(string sequence)
        {
            //Add sequence check
            char[] sequenceArray = sequence.ToCharArray();
            RoverInstruction[] roverInstructions = new RoverInstruction[sequenceArray.Length];
            RoverInstruction instruction;

            for (int i = 0; i < sequenceArray.Length; i++)
            {
                instruction = sequenceArray[i] switch
                {
                    'L' => RoverInstruction.L,
                    'R' => RoverInstruction.R,
                    'M' => RoverInstruction.M
                };
                roverInstructions[i] = instruction;
            }
            return roverInstructions;
        }
    }
}
