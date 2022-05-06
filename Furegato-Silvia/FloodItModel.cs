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
        private MovesCounter MCounter { get; set; }
        private final List<Cell> mainPuddle;
        private final List<Colors> selectedColors;

        public FloodItModel()
        {
            NumOfColors = 0;
            RowSize = 0;
            _moves = 0;
            _maxMoves = 0;
            MCounter = null;
            CurrentColor = null;
            _table = null;
            this.mainPuddle = new LinkedList<>();
            this.selectedColors = new LinkedList<>();
        }

        /**
            * Creates an instance of the table.
            */
        public void setTable()
        {
            _table = new Table(rowSize, numOfColors, selectedColors);
            _table.generateTable();
        }

        /**
            * Set the maximum of moves the player can make.
            */
        public void setMaxMoves() => _maxMoves = MCounter.count();

        /**
            * Set the list of colors of the table.
            * 
            * @param newColors The list of colors.
            */
        public void setSelectedColors(final List<Colors> newColors)
        {
            this.selectedColors.clear();
            this.selectedColors.addAll(newColors);
        }

        /**
            * Increments the moves counter.
            */
        public void incrementMoves() => _moves++;

        /**
            * @return The table.
            */
        public Table getTable() => _table;

        /**
            * @return The number of moves made by the player.
            */
        public int getMoves() => _moves;

        /**
            * @return The maximum number of moves.
            */
        public int getMaxMoves() => _maxMoves;

        /**
            * @return The main puddle of color.
            */
        public List<Cell> getMainPuddle() => this.mainPuddle;

        /**
            * @return A list with all the colors of the table.
            */
        public List<Colors> getSelectedColors() => this.selectedColors;

        /**
            * Reset the game model.
            */
        public void clear()
        {
            NumOfColors = 0;
            RowSize = 0;
            _moves = 0;
            _maxMoves = 0;
            MCounter = null;
            CurrentColor = null;
            _table = null;
            this.mainPuddle.clear();
            this.selectedColors.clear();
        }  
    }
}
