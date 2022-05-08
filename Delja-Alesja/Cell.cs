using System;

namespace Delja_Alesja
{
    /// <summary>
    /// Class used to create the cells of the field.
    /// </summary>
    class Cell
    {
        private readonly int type;
        private readonly int position;
        private bool discovered;
        private bool flagged;

        /// <summary>
        /// Builds a new cell.
        /// <param name="type"> type of the cell </param>
        /// <param name="position"> position of the cell </param>
        /// <param name="discovered"> tells if the cell is discovered or not </param>
        /// <param name="flagged"> true if the cell is a flag </param>
        /// </summary>
        public Cell(int type, int position, bool discovered, bool flagged) {
            this.type = type;
            this.position = position;
            this.discovered = discovered;
            this.flagged = flagged;
        }

        /// <summary>
        /// - 0 if the cell is empty
        ///- 1 if there is a mine
        /// - 2 of there is a number
        /// <returns> the type of the cell</returns>
        /// </summary>
        public int Type => type;
        /// <summary>
        /// <returns> gets the position of the cell </returns>
        /// </summary>
        public int Position => position;
        /// <summary>
        /// <returns> gets if the cell is discoverd </returns>
        /// </summary>
        public bool IsDiscovered => discovered;
        /// <summary>
        /// sets if the cell is discovered
        /// <param name="discover">true if the cell is discovered </param>
        /// </summary>
        public void SetDiscovered(bool discover) => this.discovered = discover;
        /// <summary>
        /// <returns> gets if the cell is flagged </returns>
        /// </summary>
        public bool Flagged => flagged;
        /// <summary>
        /// <param name="flag">true if the cell is flagged </param>
        /// </summary>
        public void SetFlagged(bool flag) => this.flagged = flag;
    }
}
