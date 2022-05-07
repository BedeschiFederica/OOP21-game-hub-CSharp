using System;
using System.Collections.Generic;
using System.Text;

namespace Delja_Alesja
{
    class Handler
    {
        //array to know where is the player.
        private readonly List<Cell> now = new List<Cell>();
        private readonly List<Cell> queue = new List<Cell>();
        private static int putFlag;
        /**
         * method that discovers the cells.
         * Remider: 0-empty, 1-mine, 2-flag
         * @param cell to know what cell is used
         */
        public void Click(Cell cell)
        {
            int discovered = 0;
            if (!cell.Flagged)
            {
                cell.SetDiscovered(true);

                int position = cell.Position;
                if (cell.Type == 0)
                {
                    if (position < ViewField.GridSize)
                    {
                        if (position % ViewField.GridSize == 0)
                        {
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize + 1));
                            queue.Add(Field.GetCell().get(position + 1));
                        }
                        else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                        {
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize - 1));
                            queue.Add(Field.GetCell().get(position - 1));
                        }
                        else
                        {
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize + 1));
                            queue.Add(Field.GetCell().get(position + ViewField.GridSize - 1));
                            queue.Add(Field.GetCell().get(position + 1));
                            queue.Add(Field.GetCell().get(position - 1));
                        }
                    }
                    else if (position >= (ViewField.GridSize * (ViewField.GridSize - 1)))
                    {
                        if (position % ViewField.GridSize == 0)
                        {
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize + 1));
                            queue.Add(Field.GetCell().get(position + 1));
                        }
                        else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                        {
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize - 1));
                            queue.Add(Field.GetCell().get(position - 1));
                        }
                        else
                        {
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize + 1));
                            queue.Add(Field.GetCell().get(position - ViewField.GridSize - 1));
                            queue.Add(Field.GetCell().get(position + 1));
                            queue.Add(Field.GetCell().get(position - 1));
                        }
                    }
                    else if (position % ViewField.GridSize == 0)
                    {
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize + 1));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize + 1));
                        queue.Add(Field.GetCell().get(position + 1));
                    }
                    else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                    {
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize - 1));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize - 1));
                        queue.Add(Field.GetCell().get(position - 1));
                    }
                    else
                    {
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize));
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize - 1));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize - 1));
                        queue.Add(Field.GetCell().get(position - ViewField.GridSize + 1));
                        queue.Add(Field.GetCell().get(position + ViewField.GridSize + 1));
                        queue.Add(Field.GetCell().get(position - 1));
                        queue.Add(Field.GetCell().get(position + 1));
                    }
                }
                else if (cell.Type == 2)
                {
                    //i see if there is a mine near the cell
                    int dangerCount = 0;
                    if (position < ViewField.GridSize)
                    {
                        if (position % ViewField.GridSize == 0)
                        {
                            if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + ViewField.GridSize + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                        else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                        {
                            if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + ViewField.GridSize - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                        else
                        {
                            if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + ViewField.GridSize + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + ViewField.GridSize - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                    }
                    else if (position >= (ViewField.GridSize * (ViewField.GridSize - 1)))
                    {
                        if (position % ViewField.GridSize == 0)
                        {
                            if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - ViewField.GridSize + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                        else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                        {
                            if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - ViewField.GridSize - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                        else
                        {
                            if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - ViewField.GridSize + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - ViewField.GridSize - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position + 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                            if (Field.GetCell().get(position - 1).getType() == 1)
                            {
                                dangerCount++;
                            }
                        }
                    }
                    else if (position % ViewField.GridSize == 0)
                    {
                        if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - ViewField.GridSize + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                    }
                    else if (position % ViewField.GridSize == ViewField.GridSize - 1)
                    {
                        if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - ViewField.GridSize - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                    }
                    else
                    {
                        if (Field.GetCell().get(position - ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - ViewField.GridSize - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - ViewField.GridSize + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + ViewField.GridSize + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position - 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                        if (Field.GetCell().get(position + 1).getType() == 1)
                        {
                            dangerCount++;
                        }
                    }
                }
                //forse fino a qui
                for (int x = 0; x < queue.size(); x++)
                {
                    if (!queue.get(x).isDiscovered())
                    {
                        now.Add(queue.get(x));
                        queue.get(x).setDiscovered(true);
                    }
                }
                queue.Clear();
                // while (!now.isEmpty())
                //{
                //  Cell temp = now.get(0);
                //  now.remove(0);
                //  temp.clickButton();
                // }

                for (int x = 0; x < Field.GetCell().size(); x++)
                {
                    if (Field.GetCell().get(x).isDiscovered())
                    {
                        discovered++;
                    }
                }
            }
        }

        /**
         * method that puts the flag in the cell.
         * @param cell sets which cell is flagged.
         */
        public void RightClick(Cell cell)
        {
            if (!cell.IsDiscovered)
            {
                if (!cell.Flagged)
                {
                    cell.SetFlagged(true);
                    putFlag++;
                }
                else
                {
                    cell.SetFlagged(false);
                    putFlag--;
                }
            }

        }
    }
}
