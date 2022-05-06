using System;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Enum that represents a direction.
    /// </summary>
    public enum Direction
    {
        Up = 1,
        Down = -Up,
        Right = 2,
        Left = -Right
    }

    /// <summary>
    /// Utility class for the enum Direction.
    /// </summary>
    public static class DirectionUtility
    {
        /// <summary>
        /// Gets the opposite direction of the given one.
        /// </summary>
        /// <param name="direction"> the direction of which you want to know the opposite </param>
        /// <returns> the opposite direction </returns>
        public static Direction Opposite(Direction direction) => (Direction)(-(int)direction);

        /// <summary>
        /// Gets a random direction.
        /// </summary>
        /// <returns> a random direction </returns>
        public static Direction GetRandomDirection()
        {
            int randomNum = new Random().Next(Enum.GetValues(typeof(Direction)).Length);
            return (Direction)Enum.GetValues(typeof(Direction)).GetValue(randomNum);
        }

        ///// <summary>
        ///// Gets the position next to the given one, in that direction.
        ///// </summary>
        ///// <param name="pos"> the initial position </param>
        ///// <returns> the position next to pos in that direction </returns>
        //public Position GetPosition(final Position pos)
        //{
        //    Objects.requireNonNull(pos);
        //    return this.calculatePositionFunc.apply(pos);
        //}
    }
}
