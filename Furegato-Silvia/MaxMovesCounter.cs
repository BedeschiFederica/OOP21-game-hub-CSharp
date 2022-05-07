using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
     * Counts the maximum moves allowed to flood the entire table.
     */
    class MaxMovesCounter : IMovesCounter
    {

        private const int MAX_MOVES_EASY = 16;
        private const int MAX_MOVES_MEDIUM = 28;
        private const int MAX_MOVES_HARD = 40;
        private const int SIZE_EASY = 5;
        private const int SIZE_MEDIUM = 10;
        private const int SIZE_HARD = 15;
        private int _size;

        public MaxMovesCounter(int size)
        {
            _size = size;
        }

        /**
         * Counts the max moves.
         */
        public int Count()
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
        public void SetSize(int newSize) => _size = newSize;
    }
}
