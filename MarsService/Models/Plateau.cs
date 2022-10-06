using System.Drawing;

namespace MarsService.Models
{
    public class Plateau : IPlateau
    {
        private readonly int _id;
        private readonly Point _topRightCoordinate;
        private readonly Point _bottomLeftCoordinate = new (0,0);

        private bool[,] _mapMatrix;
        private static int count;

        public Plateau(Point point)
        {
            _topRightCoordinate = point;
            _mapMatrix = new bool[point.X+1, point.Y+1];
            for (int i = 0; i <= _topRightCoordinate.X ; i++)
                for (int j = 0; j <= _topRightCoordinate.Y; j++)
                    _mapMatrix[i,j] = true;
            _id = count++;
        }

        public int Id { get { return _id; }}

        public bool IsAvailiable(Point point) => !OutOfPlateau(point) && _mapMatrix[point.X, point.Y];

        public void MarkAsAvailiable(Point point)
        { 
            if (!OutOfPlateau(point))
            {
                _mapMatrix[point.X, point.Y] = true;
            }
        }

        public void MarkAsNotAvailiable(Point point)
        {
            if (!OutOfPlateau(point))
            {
                _mapMatrix[point.X, point.Y] = false;
            }
        }

        public bool OutOfPlateau(Point point) => point.X > _topRightCoordinate.X || point.Y > _topRightCoordinate.Y
            || point.X < _bottomLeftCoordinate.X || point.Y < _bottomLeftCoordinate.Y;
    }
}
