using System.Drawing;
using MarsService.Models;

namespace MarsService.Managers
{
    public class MapManager
    {
        private Dictionary<int, IPlateau> _plateausList { get; set; }
        public IPlateau currentPlateau { get; private set; }

        public MapManager()
        {
            _plateausList = new Dictionary<int, IPlateau>();
        }

        public IPlateau CreateNewPlateau(Point plateauSize)
        {
            IPlateau plateau = new Plateau(plateauSize);
            _plateausList.Add(plateau.Id, plateau);
            return currentPlateau = plateau;
        }
    }
}
