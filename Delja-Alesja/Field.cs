using System;
using System.Collections.Generic;

namespace Delja_Alesja {
    class Field
    {
        private readonly int grid = ViewField.GridSize * ViewField.GridSize;
        //variable needed to know if a cell is picked to have a mine or not
        private bool mine;
        //array that has the position of all the mines
        private List<int> mines = new ArrayList<>();
        /**
         * array that has the position of all the cells.
        */
        private static List<Cell> cell = new ArrayList<>();

        /* public Field(final GridLayout grid, final Handler handler)
         {
             super(grid);
             cell.clear();
             createCells(handler);
             newCells();
         }*/

        public void createCells( Handler handler)
        {
            for (int i = 1; i <= ViewField.Mines; i++)
            {
                while (!mine)
                {
                    int minePosition = (int)(Math.random() * grid);
                    if (!mines.Contains(minePosition))
                    {
                        mines.Add(minePosition);
                        mine = true;
                    }
                }
                mine = false;
            }

            for (int i = 0; i < grid; i++)
            {
                if (mines.Contains(i))
                {
                    GetCell().Add(new Cell(1, i, false, false, handler));
                }
                else if (i % ViewField.GridSize == 0)
                {
                    if (mines.Contains(i - ViewField.GridSize)
                            || mines.Contains(i - ViewField.GridSize + 1)
                            || mines.Contains(i + 1)
                            || mines.Contains(i + ViewField.GridSize)
                            || mines.Contains(i + ViewField.GridSize + 1))
                    {
                        GetCell().Add(new Cell(2, i, false, false, handler));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false, handler));
                    }
                }
                else if (i % ViewField.GridSize == ViewField.GridSize - 1)
                {
                    if (mines.Contains(i - ViewField.GridSize - 1)
                            || mines.Contains(i - ViewField.GridSize)
                            || mines.Contains(i - 1)
                            || mines.Contains(i + ViewField.GridSize - 1)
                            || mines.Contains(i + ViewField.GridSize))
                    {
                        GetCell().Add(new Cell(2, i, false, false, handler));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false, handler));
                    }
                }
                else
                {
                    if (mines.Contains(i - ViewField.GridSize - 1)
                            || mines.Contains(i - ViewField.GridSize)
                            || mines.Contains(i - ViewField.GridSize + 1)
                            || mines.Contains(i - 1)
                            || mines.Contains(i + 1)
                            || mines.Contains(i + ViewField.GridSize - 1)
                            || mines.Contains(i + ViewField.GridSize)
                            || mines.Contains(i + ViewField.GridSize + 1))
                    {
                        GetCell().Add(new Cell(2, i, false, false, handler));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false, handler));
                    }
                }
            }
        }

        /**
         * adding the cells to the field.
         */
        private void newCells()
        {
            for (int i = 0; i < GetCell().size(); i++)
            {
                add(GetCell().get(i));
            }
        }

        public static List<Cell> GetCell() => cell;

        public static void SetCell(final List<Cell> cell) => Field.cell = cell;
    }
}