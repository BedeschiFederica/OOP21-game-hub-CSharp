using System;
using System.Collections.Generic;
using System.Linq;

namespace Furegato_Silvia
{
    /**
    * <summary>Class <c>Table</c> describes the table of the game, contains cells.</summary>
    */
    class Table
    {
        public int BoardSize { get; }
        public List<Cell> Board { get; }
        private readonly int _numOfColors;
        private readonly List<Colors> _selectedColors;

        public Table(int tSize, int colorsNumber, List<Colors> selectedColors)
        {
            BoardSize = tSize;
            Board = new List<Cell>();
            _numOfColors = colorsNumber;
            _selectedColors = selectedColors;
        }

        /**
        * <summary>Method <c>GenerateTable</c> generates the table.</summary>
        */
        public void GenerateTable()
        {
            Random rand = new Random();
            List<Colors> colorMap = new List<Colors>();

            int chosenColor;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    chosenColor = rand.Next(_numOfColors);
                    Board.Add(new Cell(_selectedColors[chosenColor], new Tuple<int, int>(i, j)));
                    colorMap.Add(_selectedColors[chosenColor]);
                }
            }

            // checks if the table contains all the requested colors
            int pos;
            int color;
            while (!_selectedColors.All(selC => colorMap.Any(c => c == selC)))
            {
                pos = rand.Next(Board.Count());
                color = rand.Next(_numOfColors);
                Board[pos].Color = _selectedColors[color];
                colorMap.Remove(colorMap[pos]);
                colorMap.Insert(pos, _selectedColors[color]);
            }

            // Sets the adjacencies for all of the cells
            for (int k = 0; k < Board.Count; k++)
            {
                SetAdjacencies(k);
            }

        }

        /**
        * <summary>Method <c>SetAdjacencies</c> finds and sets the adjacent cells.</summary>
        * 
        * <param name="cellPosition">The position of the cell.</param>
        */
        private void SetAdjacencies(int cellPosition)
        {
            Cell top = null;
            Cell bottom = null;
            Cell right = null;
            Cell left = null;

            if ((cellPosition - BoardSize) >= 0)
            {
                top = Board[cellPosition - BoardSize];
            }

            if ((cellPosition + BoardSize) < Board.Count)
            {
                bottom = Board[cellPosition + BoardSize];
            }

            if ((cellPosition + 1) < Board.Count && Board[cellPosition + 1].Position.Item2 != 0)
            {
                right = Board[cellPosition + 1];
            }

            if ((cellPosition - 1) >= 0 && Board[cellPosition - 1].Position.Item2 != BoardSize - 1)
            {
                left = Board[cellPosition - 1];
            }

            Board[cellPosition].SetAdjacentCells(top, bottom, right, left);
        }

        /**
        * <summary>Method <c>GetCell</c> gets the cell at the specified position.</summary>
        * 
        * <param name="x">X position of the cell.</param>
        * <param name="y">Y position of the cell.</param>
        * <returns>The cell at position (x,y).</returns>
        */
        public Cell GetCell(int x, int y)
        {
            IEnumerable<Cell> requestedCell = Board
                                            .Where(cell => cell.Position.Equals(new Tuple<int, int>(x, y)))
                                            .Take(1);

            if (!requestedCell.Any())
            {
                return null;
            }
            return requestedCell.First();
        }
    }
}
