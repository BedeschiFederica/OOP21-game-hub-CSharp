using System.Collections.Generic;
using System;

namespace Furegato_Silvia
{
    /**
    * <summary>Class <c>Cell</c> represents a single cell and contains information about color, position, 
    * adjacent cells and whether the cell is flooded or not.</summary>
    */
    class Cell
    {
        public Colors Color { get; set; }
        public Tuple<int, int> Position { get; }
        public bool Flooded { get; set; }

        private Cell _topCell;
        private Cell _bottomCell;
        private Cell _rightCell;
        private Cell _leftCell;

        public Cell(Colors color, Tuple<int, int> position)
        {
            Color = color;
            Position = position;
            Flooded = false;
            _topCell = null;
            _bottomCell = null;
            _rightCell = null;
            _leftCell = null;
        }

        /**
        * <summary>Method <c>SetAdjacentCells</c> sets the adjacent cells.</summary>
        * 
        * <param name="top">The cell on top of the current one.</param>
        * <param name="bottom">The cell at the bottom of the current one.</param>
        * <param name="right">The cell on the right of the current one.</param>
        * <param name="left">The cell on the left of the current one.</param>
        */
        public void SetAdjacentCells(Cell top, Cell bottom, Cell right, Cell left)
        {
            _topCell = top;
            _bottomCell = bottom;
            _rightCell = right;
            _leftCell = left;
        }

        /**
        * <summary>Method <c>GetAdjacentCells</c> gets the adjacent cells.</summary>
        * <return>A list of the adjacent cells.</return>
        */
        public List<Cell> GetAdjacentCells() => new List<Cell>() { _topCell, _bottomCell, _rightCell, _leftCell };
    }
}
