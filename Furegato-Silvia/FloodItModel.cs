using System.Collections.Generic;

namespace Furegato_Silvia
{
    /**
    * <summary>Class <c>FloodItModel</c> represents the Flood It game's model.</summary>
    */
    class FloodItModel
    {
        public int NumOfColors { get; set; }
        public int RowSize { get; set; }
        public Colors CurrentColor { get; set; }
        public IMovesCounter MCounter { get; set; }
        public List<Cell> MainPuddle { get; }
        public List<Colors> SelectedColors { get; }
        private Table _table;
        private int _moves;
        private int _maxMoves;

        public FloodItModel()
        {
            NumOfColors = 0;
            RowSize = 0;
            MCounter = null;
            MainPuddle = new List<Cell>();
            SelectedColors = new List<Colors>();
            _table = null;
            _moves = 0;
            _maxMoves = 0;
        }

        /**
        * <summary>Method <c>SetTable</c> creates an instance of the table.</summary>
        */
        public void SetTable()
        {
            _table = new Table(RowSize, NumOfColors, SelectedColors);
            _table.GenerateTable();
        }

        /**
        * <summary>Method <c>SetMaxMoves</c> sets the maximum moves the player can make.</summary>
        */
        public void SetMaxMoves() => _maxMoves = MCounter.Count();

        /**
        * <summary>Method <c>SetSelectedColors</c> sets the list of colors of the table.</summary>
        * 
        * <param name="newColors">The list of colors.</param>
        */
        public void SetSelectedColors(List<Colors> newColors)
        {
            SelectedColors.Clear();
            SelectedColors.AddRange(newColors);
        }

        /**
        * <summary>Method <c>IncrementMoves</c> increments the moves counter.</summary>
        */
        public void IncrementMoves() => _moves++;

        /**
        * <returns>The table.</returns>
        */
        public Table GetTable() => _table;

        /**
        * <returns>The number of moves made by the player.</returns>
        */
        public int GetMoves() => _moves;

        /**
        * <returns>The maximum number of moves.</returns>
        */
        public int GetMaxMoves() => _maxMoves;

        /**
        * <returns>A list with all the colors of the table.</returns>
        */
        public List<Colors> GetSelectedColors() => SelectedColors;

        /**
        * <summary>Method <c>Clear</c> resets the game model.</summary>
        */
        public void Clear()
        {
            NumOfColors = 0;
            RowSize = 0;
            MCounter = null;
            MainPuddle.Clear();
            SelectedColors.Clear();
            _table = null;
            _moves = 0;
            _maxMoves = 0;
        }  
    }
}
