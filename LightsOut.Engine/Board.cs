using System;
using System.Collections.Generic;
using System.Linq;

namespace LightsOut.Engine
{
    public class Board
    {
        private int _size;
        private Random _random;

        private List<bool[]> _grid;
        public IList<bool[]> Grid => _grid.AsReadOnly();

        public List<Cell> PreSelectedCells { get; private set; }

        public Board(int size)
        {
            _size = size;
            _random = new Random();
            Setup();
            ApplyRandomClick();
        }

        public void Click(int x, int y)
        {
            var affectedCells = CalculateAffectedCells(x, y);

            affectedCells
                .Where(cell => cell.X > -1 && cell.X < _size && cell.Y > -1 && cell.Y < _size).ToList()
                .ForEach(row => _grid[row.Y][row.X] = !_grid[row.Y][row.X]);
        }

        private void Setup()
        {
            _grid = new List<bool[]>(_size);
            for (int i = 0; i < _size; i++)
            {
                _grid.Add(new bool[_size]);
            }
        }

        private void ApplyRandomClick()
        {
            //TODO - think about adding more than 1 selected cell at start up
            var x = _random.Next(0, _size);
            var y = _random.Next(0, _size);

            PreSelectedCells = new List<Cell>() { new Cell(x, y) };
            Grid[x][y] = true;
        }

        private List<Cell> CalculateAffectedCells(int x, int y)
        {
            //it will always be a maxium of 5 cells affected by the click
            //using a tuple so that it's clear that there are only 2 values in each element in the list
            return new List<Cell>()
            {
                new Cell(x, y),
                new Cell(x -1, y),
                new Cell(x +1, y),
                new Cell(x, y -1),
                new Cell(x, y +1)
            };
        }
    }
}
