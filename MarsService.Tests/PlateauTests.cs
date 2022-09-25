using FluentAssertions;
using System.Drawing;
using MarsService.Models;

namespace MarsService.Tests;

public class PlateauTests
{
    private Plateau _plateau;

    [SetUp]
    public void Setup()
    {
        Point point = new (4, 4);
        _plateau = new Plateau(point);
    }

    [TestCase(1, 1, false)]
    [TestCase(2, 2, false)]
    [TestCase(3, 3, false)]
    [TestCase(4, 4, false)]
    [TestCase(6, 5, true)]
    [TestCase(5, 8, true)]
    [TestCase(10, 1, true)]
    [TestCase(111, 1, true)]
    public void OutOfPlateau_Shoud_Work(int x, int y, bool result)
    {
        _plateau.OutOfPlateau(new Point(x, y)).Should().Be(result);
    }

    [TestCase(0, 0, true)]
    [TestCase(1, 1, true)]
    [TestCase(7, 7, false)]
    [TestCase(100, 1, false)]
    public void IsAvailiable_Shoud_Return_Correct_Value(int x, int y, bool result)
    {
        _plateau.IsAvailiable(new(x, y)).Should().Be(result);
    }

    [TestCase(3, 7, false)]
    [TestCase(300, 300, false)]
    public void MarkAsNotAvailiable_Shoud_Work(int x, int y, bool result)
    {
        Point point = new(x, y);
        _plateau.MarkAsNotAvailiable(point);
        _plateau.IsAvailiable(point).Should().Be(result);
    }

    [TestCase(2, 2, true)]
    [TestCase(300, 300, false)]
    public void MarkAsAvailiable_Shoud_Work(int x, int y, bool result)
    {
        Point point = new(x, y);
        _plateau.MarkAsAvailiable(point);
        _plateau.IsAvailiable(point).Should().Be(result);
    }
}