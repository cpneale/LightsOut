using LightsOut.Engine;
using LightsOut.Engine.Enums;
using NUnit.Framework;
using System.Collections.Generic;
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

        DeselectAllCells(size, grid);

        board.Click(x, y);

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < testGrid[row].Length; col++)
            {
                Assert.IsTrue(testGrid[row][col] == grid[row][col], "Failed on square x{0}:y{1}", x, y);
            }
        }
    }

    [Test]
    public void When_The_State_Changes_Then_The_Event_Is_Fired()
    {
        var board = new Board(5);

        bool eventFired = false;
        board.StateChange += (o,e) => eventFired = true;

        board.Click(1, 1);

        Assert.IsTrue(eventFired);
    }

    [Test]
    public void When_Some_Cells_Are_Turned_On_Then_Status_Equals_InProgress()
    {
        var board = new Board(5);
        board.Click(1, 1);
        //there is another test to confirm cells are selected after we initialize

        Assert.AreEqual(GameStatus.InProgress, board.GameStatus);
    }

    [Test]
    public void When_All_Cells_Are_Turned_Off_Then_Status_Equals_PlayerOneWins()
    {
        var board = new Board(5);
        board.Click(1, 1);
        DeselectAllCells(5, board.Grid);

        Assert.AreEqual(GameStatus.PlayerOneWins, board.GameStatus);
    }

    private static void DeselectAllCells(int size, IList<bool[]> grid)
    {
        var preselected = grid
            .SelectMany((cells, i) => cells
                .Select(c => new { x = i, selected = c })
            )
            .Select((c, i) => new { y = i % size, c.x, c.selected })
            .Where(o => o.selected);

        foreach (var cell in preselected)
        {
            grid[cell.x][cell.y] = false;
        }
    }
}