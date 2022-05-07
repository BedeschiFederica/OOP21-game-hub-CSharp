using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
     /**
     * Describes the table of the game, contains cells.
     */
    class Table
    {
        private readonly int _numOfColors;
        private int BoardSize { get; }
        private readonly List<Colors> _selectedColors;
        private List<Cell> Board { get; }

        public Table(int tSize, int colorsNumber, List<Colors> selectedColors)
        {
            _numOfColors = colorsNumber;
            BoardSize = tSize;
            _selectedColors = selectedColors;
            _board = new List<Cell>();
        }

        /**
            * Generates the table.
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
                    chosenColor = rand.nextInt(_numOfColors);
                    _board.Add(new Cell(_selectedColors.get(chosenColor), new Pair<>(i, j)));
                    colorMap.Add(_selectedColors.get(chosenColor));
                }
            }

            // checks if the table contains all the requested colors
            int pos;
            int color;
            while (!colorMap.containsAll(selectedColors))
            {
                pos = rand.nextInt(board.size());
                color = rand.nextInt(_numOfColors);
                _board.get(pos).setColor(selectedColors.get(color));
                colorMap.Remove(pos);
                colorMap.Add(pos, _selectedColors.get(color));
            }

            // Sets the adjacencies for all of the cells
            for (int k = 0; k < _board.size(); k++)
            {
                SetAdjacencies(k);
            }

        }

        /**
            * Finds and sets the adjacent cells.
            * 
            * @param cellPosition The position of the cell.
            */
        private void SetAdjacencies(int cellPosition)
        {
            Cell top = null;
            Cell bottom = null;
            Cell right = null;
            Cell left = null;

            if ((cellPosition - BoardSize) >= 0)
            {
                top = _board.get(cellPosition - BoardSize);
            }

            if ((cellPosition + BoardSize) < _board.size())
            {
                bottom = _board.get(cellPosition + BoardSize);
            }

            if ((cellPosition + 1) < _board.size() && _board.get(cellPosition + 1).getPosition().getY() != 0)
            {
                right = _board.get(cellPosition + 1);
            }

            if ((cellPosition - 1) >= 0 && _board.get(cellPosition - 1).getPosition().getY() != BoardSize - 1)
            {
                left = _board.get(cellPosition - 1);
            }

            _board.get(cellPosition).setAdjacentCells(top, bottom, right, left);
        }

        /**
            * Gets the cell at the specified position.
            * 
            * @param x X position of the cell.
            * @param y Y position of the cell.
            * @return the cell at position (x,y).
            */
        public Cell GetCell(int x, int y)
        {
            List<Cell> requestedCell = _board.stream()
                    .filter(cell->cell.getPosition().equals(new Pair<Integer, Integer>(x, y)))
                    .collect(Collectors.toList());
            if (requestedCell.isEmpty())
            {
                return null;
            }
            return requestedCell.get(0);
        }

        /**
            * @return All of the cells contained in the table.
            */
        public List<Cell> GetAllCells() => _board;  
    }
}
