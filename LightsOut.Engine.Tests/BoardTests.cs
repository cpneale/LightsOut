using LightsOut.Engine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class Given_A_LightsOutBoard
{
    private const int Size = 5;
    private Board _board;
    private IList<bool[]> _grid;

    [SetUp]
    public void Setup()
    {
        _board = new Board(Size);
        _grid = _board.Grid;
    }

    [Test]
    public void When_Constructed_Then_The_Grid_Has_Some_Cells_Populated()
    {
        var anySelected = _grid.Any(e => e.Cast<bool>().Any(b => b));
        Assert.IsTrue(anySelected);
    }

    [TestCase(2,2,"5x5_x2y2")]//middle click
    [TestCase(2,0, "5x5_x2y0")]//top edge click
    [TestCase(4,4, "5x5_x4y4")]//bottom right corner
    public void When_Click_Is_Called_Then_The_Grid_Has_The_Correct_Cells_Populated(int x, int y, string gridName)
    {
        var testGrid = TestGrids.GetGridList(gridName);

        foreach (var cell in _board.PreSelectedCells)
        {
            _grid[cell.X][cell.Y] = false;
        }

        _board.Click(x, y);

        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < testGrid[row].Length; col++)
            {
                Assert.IsTrue(testGrid[row][col] == _grid[row][col], "Failed on square x{0}:y{1}", x, y);
            }
        }
    }
}