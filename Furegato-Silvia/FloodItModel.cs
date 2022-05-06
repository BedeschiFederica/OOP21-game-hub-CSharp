﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
    * Model of the game Flood It.
    */
    class FloodItModel
    {
        private int numOfColors;
        private int rowSize;
        private Colors currentColor;
        private Table table;
        private int moves;
        private int maxMoves;
        private MovesCounter mCounter;
        private final List<Cell> mainPuddle;
        private final List<Colors> selectedColors;

        public FloodItModel()
        {
            this.numOfColors = 0;
            this.rowSize = 0;
            this.moves = 0;
            this.maxMoves = 0;
            this.mCounter = null;
            this.currentColor = null;
            this.table = null;
            this.mainPuddle = new LinkedList<>();
            this.selectedColors = new LinkedList<>();
        }

        /**
            * Sets the current color.
            * 
            * @param newColor The new color.
            */
        public void setCurrentColor(final Colors newColor)
        {
            this.currentColor = newColor;
        }

        /**
            * Sets the number of rows of the table.
            * 
            * @param size The number of rows.
            */
        public void setTSize(final int size)
        {
            this.rowSize = size;
        }

        /**
            * Sets the number of colors.
            * 
            * @param colorsNum The number of colors.
            */
        public void setNumofColors(final int colorsNum)
        {
            this.numOfColors = colorsNum;
        }

        /**
            * Creates an instance of the table.
            */
        public void setTable()
        {
            this.table = new Table(rowSize, numOfColors, selectedColors);
            table.generateTable();
        }

        /**
            * Set the maximum of moves the player can make.
            */
        public void setMaxMoves()
        {
            this.maxMoves = this.mCounter.count();
        }

        /**
            * Sets the maximum moves counter.
            * 
            * @param newCounter The moves counter.
            */
        public void setMCounter(final MovesCounter newCounter)
        {
            this.mCounter = newCounter;
        }

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
        public void incrementMoves()
        {
            this.moves++;
        }

        /**
            * @return The number of colors used in the table.
            */
        public int getNumOfColors()
        {
            return this.numOfColors;
        }

        /**
            * @return The number of rows.
            */
        public int getRowSize()
        {
            return this.rowSize;
        }

        /**
            * @return The current color.
            */
        public Colors getCurrentColor()
        {
            return this.currentColor;
        }

        /**
            * @return The table.
            */
        public Table getTable()
        {
            return this.table;
        }

        /**
            * @return The number of moves made by the player.
            */
        public int getMoves()
        {
            return this.moves;
        }

        /**
            * @return The maximum number of moves.
            */
        public int getMaxMoves()
        {
            return this.maxMoves;
        }

        /**
            * @return The moves counter.
            */
        public MovesCounter getMCounter()
        {
            return this.mCounter;
        }

        /**
            * @return The main puddle of color.
            */
        public List<Cell> getMainPuddle()
        {
            return this.mainPuddle;
        }

        /**
            * @return A list with all the colors of the table.
            */
        public List<Colors> getSelectedColors()
        {
            return this.selectedColors;
        }

        /**
            * Reset the game model.
            */
        public void clear()
        {
            this.numOfColors = 0;
            this.rowSize = 0;
            this.moves = 0;
            this.maxMoves = 0;
            this.mCounter = null;
            this.currentColor = null;
            this.table = null;
            this.mainPuddle.clear();
            this.selectedColors.clear();
        }
        
    }
}
