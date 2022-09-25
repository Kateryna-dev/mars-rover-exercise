using System.Drawing;
using MarsService.Enums;

namespace MarsService.Models
{

    public class Position
    {
        public Point Coordinate { get; set; }
        public CardinalDirection Orientation { get; set; }
        //public int PlateauId;

        public Position(Point point, CardinalDirection orientation)
        {
            Coordinate = point;
            Orientation = orientation;
        }

        public void DecrementDirection()
        {
            this.Orientation = this.Orientation != CardinalDirection.North ?
                --this.Orientation : CardinalDirection.West;
        }

        public void IncrementDirection()
        {
            this.Orientation = this.Orientation != CardinalDirection.West ?
                ++this.Orientation : CardinalDirection.North;
        }

        public Point GetNextCoordinates() => this.Orientation switch
        {
            CardinalDirection.North => new Point(Coordinate.X, Coordinate.Y+1),
            CardinalDirection.East => new Point(Coordinate.X+1, Coordinate.Y),
            CardinalDirection.South => new Point(Coordinate.X, Coordinate.Y-1),
            CardinalDirection.West => new Point(Coordinate.X-1, Coordinate.Y)
        };
    }
}
