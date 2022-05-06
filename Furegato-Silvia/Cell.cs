using System;

namespace Furegato_Silvia
{
    class Cell
    {
        package main.games.floodit.model;

        import java.util.Arrays;
        import java.util.LinkedList;
        import java.util.List;

        /**
         * This class represents a single cell and contains information about color, position,
         * adjacent cells and whether the cell is flooded or not.
         */
        public class Cell
        {

            private Colors Color { get; set; }
            private Pair<Integer, Integer> Position { get; }
            private bool Flooded { get; set; }

            private Cell _topCell;
            private Cell _bottomCell;
            private Cell _rightCell;
            private Cell _leftCell;

            public Cell(Colors color, Pair<Integer, Integer> position)
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
             * Sets the adjacent cells.
             * 
             * @param top The cell on top of the current one.
             * @param bottom The cell at the bottom of the current one.
             * @param right The cell on the right of the current one.
             * @param left The cell on the left of the current one.
             */
            public void SetAdjacentCells(final Cell top, final Cell bottom, final Cell right, final Cell left)
            {
                _topCell = top;
                _bottomCell = bottom;
                _rightCell = right;
                _leftCell = left;
            }

            /**
             * Gets the adjacent cells.
             * @return A list of the adjacent cells.
             */
            public List<Cell> GetAdjacentCells() => new LinkedList<>(Arrays.asList(topCell, bottomCell, rightCell, leftCell));

        }
    }
}
