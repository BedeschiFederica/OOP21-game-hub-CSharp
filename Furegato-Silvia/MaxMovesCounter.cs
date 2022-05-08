
namespace Furegato_Silvia
{
    /**
     * <summary>Class <c>MaxMovesCounter</c> counts the maximum moves allowed to flood the entire table.</summary>
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
         * <returns>Method <c>Count</c> returns the maximum moves.</returns>
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
         * <summary>Method <c>SetSize</c> sets the size for the maximum moves count.</summary>
         * 
         * <param name="newSize">The size for the moves count.</param>
         */
        public void SetSize(int newSize) => _size = newSize;
    }
}
