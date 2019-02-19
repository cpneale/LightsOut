using LightsOut.Engine;
using System.Collections.Generic;

public class TestGrids
{
    private static Dictionary<string, List<bool[]>> GridList = new Dictionary<string, List<bool[]>>()
    {
        {
            "5x5_x2y2",
            new List<bool[]>()
            {
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, true, false, false} },
                { new bool[] { false, true, true, true, false} },
                { new bool[] { false, false, true, false, false} },
                { new bool[] { false, false, false, false, false} }
            }
        },
        {
            "5x5_x2y0",
            new List<bool[]>()
            {
                { new bool[] { false, true, true, true, false} },
                { new bool[] { false, false, true, false, false} },
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, false, false, false} }
            }
        },
        {
            "5x5_x4y4",
            new List<bool[]>()
            {
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, false, false, false} },
                { new bool[] { false, false, false, false, true} },
                { new bool[] { false, false, false, true, true} }
            }
        }
    };

    internal static List<bool[]> GetGridList(string gridName)
    {
        var grid = GridList[gridName]; 
        return grid;
    }
}