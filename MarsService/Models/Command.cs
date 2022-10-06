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

        public Command(RoverInstruction[] instructions)
        {
            this.Instructions = instructions;
            this.Status = CommandStatus.Non;
        }
    }
}
