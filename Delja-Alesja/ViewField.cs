using System;
using System.Collections.Generic;
using System.Text;

public class ViewField
{
    
    private static int mines;
    private static int gridSize;
    public static int Mines => mines;
    public static int GridSize => gridSize;

    public ViewField(int gridSize, int mines)
    {
        ViewField.mines = mines;
        ViewField.gridSize = gridSize;
    }
}
