using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
    * Model of the game Flood It.
    */
    class FloodItModel
    {
        private int NumOfColors { get; set; }
        private int RowSize { get; set; }
        private Colors CurrentColor { get; set; }
        private Table _table;
        private int _moves;
        private int _maxMoves;
        private IMovesCounter MCounter { get; set; }
        private List<Cell> MainPuddle { get; }
        private List<Colors> SelectedColors { get; }

        public FloodItModel()
        {
            NumOfColors = 0;
            RowSize = 0;
            _moves = 0;
            _maxMoves = 0;
            MCounter = null;
            _table = null;
            MainPuddle = new List<Cell>();
            SelectedColors = new List<Colors>();
        }

        /**
            * Creates an instance of the table.
            */
        public void SetTable()
        {
            _table = new Table(RowSize, NumOfColors, SelectedColors);
            _table.GenerateTable();
        }

        /**
            * Set the maximum of moves the player can make.
            */
        public void SetMaxMoves() => _maxMoves = MCounter.count();

        /**
            * Set the list of colors of the table.
            * 
            * @param newColors The list of colors.
            */
        public void SetSelectedColors(List<Colors> newColors)
        {
            SelectedColors.Clear();
            SelectedColors.AddRange(newColors);
        }

        /**
            * Increments the moves counter.
            */
        public void IncrementMoves() => _moves++;

        /**
            * @return The table.
            */
        public Table GetTable() => _table;

        /**
            * @return The number of moves made by the player.
            */
        public int GetMoves() => _moves;

        /**
            * @return The maximum number of moves.
            */
        public int GetMaxMoves() => _maxMoves;

        /**
            * @return A list with all the colors of the table.
            */
        public List<Colors> GetSelectedColors() => SelectedColors;

        /**
            * Reset the game model.
            */
        public void Clear()
        {
            NumOfColors = 0;
            RowSize = 0;
            _moves = 0;
            _maxMoves = 0;
            MCounter = null;
            _table = null;
            MainPuddle.Clear();
            SelectedColors.Clear();
        }  
    }
}
