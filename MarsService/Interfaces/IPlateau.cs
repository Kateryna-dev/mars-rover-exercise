using System.Drawing;

namespace MarsService
{
    public interface IPlateau
    {
        int Id { get; }
        bool IsAvailiable(Point point);
        void MarkAsAvailiable(Point point);
        void MarkAsNotAvailiable(Point point);
        bool OutOfPlateau(Point point);
    }
}
