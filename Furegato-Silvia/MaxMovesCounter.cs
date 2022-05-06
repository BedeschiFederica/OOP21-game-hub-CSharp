using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
     * Counts the maximum moves allowed to flood the entire table.
     */
    class MaxMovesCounter
    {

        private static readonly int MAX_MOVES_EASY = 16;
        private static readonly int MAX_MOVES_MEDIUM = 28;
        private static readonly int MAX_MOVES_HARD = 40;
        private static readonly int SIZE_EASY = 5;
        private static readonly int SIZE_MEDIUM = 10;
        private static readonly int SIZE_HARD = 15;
        private int _size;

        public MaxMovesCounter(final int size)
        {
            _size = size;
        }

        /**
         * Counts the max moves.
         */
        @Override
        public int count()
        {
            switch (_size)
            {
                case SIZE_EASY:
                    return MAX_MOVES_EASY;
                case SIZE_MEDIUM:
                    return MAX_MOVES_MEDIUM;
                case SIZE_HARD:
                    return MAX_MOVES_HARD;
                default:
                    return 0;
            }
        }

        /**
         * Sets the size for the maximum moves count.
         * 
         * @param newSize The size for the count.
         */
        public void setSize(final int newSize) => _size = newSize;
    }
}
