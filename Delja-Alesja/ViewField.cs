namespace Delja_Alesja
{
    /// <summary>
    /// Class used to create the viewField.
    /// </summary>
    class ViewField
    {

        private static int mines;
        private static int gridSize;
        /// <summary>
        /// <returns> gets the mines number</returns>
        /// </summary>
        public static int Mines => mines;
        /// <summary>
        /// <returns> gets the grid size of the field </returns>
        /// </summary>
        public static int GridSize => gridSize;
        /// <summary>
        /// Builds a new viewField.
        /// <param name="gridSize">size of the field </param>
        /// <param name="mines"> mines of the field </param>
        /// </summary>
        public ViewField(int gridSize, int mines)
        {
            ViewField.mines = mines;
            ViewField.gridSize = gridSize;
        }
    }
}