using LightsOut.Engine;
using NUnit.Framework;
using System.Linq;

public class Given_A_LightsOutBoard
{
    [Test]
    public void When_Constructed_Then_The_Grid_Has_Some_Cells_Populated()
    {
        var board = new Board(5);
        var grid = board.Grid;

        var anySelected = grid.Any(e => e.Cast<bool>().Any(b => b));
        Assert.IsTrue(anySelected);
    }

    [TestCase(5, 2, 2, "5x5_x2y2")]//middle click
    [TestCase(5, 2, 0, "5x5_x2y0")]//top edge click
    [TestCase(5, 4, 4, "5x5_x4y4")]//bottom right corner
    [TestCase(10, 4, 4, "10x10_x4y4")]//middle on 10 x 10
    public void When_Click_Is_Called_Then_The_Grid_Has_The_Correct_Cells_Populated(int size, int x, int y, string gridName)
    {
        var board = new Board(size);
        var grid = board.Grid;

        var testGrid = TestGrids.GetGridList(gridName);

        var preselected = grid
            .SelectMany((cells,i) => cells
                .Select(c => new { x = i, selected = c })
            )
            .Select((c, i) => new { y = i % size, c.x, c.selected })
            .Where(o => o.selected);

        foreach (var cell in preselected)
        {
            grid[cell.x][cell.y] = false;
        }

        board.Click(x, y);

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < testGrid[row].Length; col++)
            {
                Assert.IsTrue(testGrid[row][col] == grid[row][col], "Failed on square x{0}:y{1}", x, y);
            }
        }
    }
}