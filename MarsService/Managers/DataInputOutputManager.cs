using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MarsService.Models;

namespace MarsService.Managers
{
    public class DataInputOutputManager
    {
        private Point _sizeOfPlateau;
        public Position[] RoversPositions;
        public string[] Commands;

        public DataInputOutputManager(string[] input) 
        {

        }

        private Point GetSizeOfPlateauFromTheInput(string sizeOfPlateauString)
        {
            string[] plateauArr = sizeOfPlateauString.Split();
            int x, y;
            if (Int32.TryParse(plateauArr[0], out x) && Int32.TryParse(plateauArr[1], out y))
            {
                _sizeOfPlateau = new Point(x, y);
            }
            return new Point(0,0);
        }

    }
}
