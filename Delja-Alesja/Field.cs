using System;
using System.Collections.Generic;

namespace Delja_Alesja {
    class Field
    {
        private readonly int grid = ViewField.GridSize * ViewField.GridSize;
        //variable needed to know if a cell is picked to have a mine or not
        private bool mine;
        //array that has the position of all the mines
        private readonly List<int> mines = new List<int>();
        //position of the cells
        private static List<Cell> cell = new List<Cell>();


        public void CreateCells()
        {
            for (int i = 1; i <= ViewField.Mines; i++)
            {
                while (!mine)
                {
                    Random rdm = new Random();
                    int minePosition = (int)(rdm.Next(1,grid));
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
                    GetCell().Add(new Cell(1, i, false, false));
                }
                else if (i % ViewField.GridSize == 0)
                {
                    if (mines.Contains(i - ViewField.GridSize)
                            || mines.Contains(i - ViewField.GridSize + 1)
                            || mines.Contains(i + 1)
                            || mines.Contains(i + ViewField.GridSize)
                            || mines.Contains(i + ViewField.GridSize + 1))
                    {
                        GetCell().Add(new Cell(2, i, false, false));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false));
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
                        GetCell().Add(new Cell(2, i, false, false));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false));
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
                        GetCell().Add(new Cell(2, i, false, false));
                    }
                    else
                    {
                        GetCell().Add(new Cell(0, i, false, false));
                    }
                }
            }
        }

        public static List<Cell> GetCell() => cell;

        public static void SetCell(List<Cell> cell) => Field.cell = cell;
    }
}