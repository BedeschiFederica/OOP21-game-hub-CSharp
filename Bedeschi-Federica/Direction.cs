using System;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Enum that represents a direction.
    /// </summary>
    public enum Direction
    {
        Up = -1,
        Down = -Up,
        Right = 10,
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

        /// <summary>
        /// Gets the position next to the given one in the given direction.
        /// </summary>
        /// <param name="position"> the initial position </param>
        /// <param name="direction"> the direction of the new position </param>
        /// <returns> the new position </returns>
        public static IPosition GetPosition(IPosition position, Direction direction)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            int xOffset = (int)direction % 10 != 0 ? (int)direction : 0;
            int yOffset = (int)direction % 10 == 0 ? (int)direction / 10 : 0;
            return new Position(position.X + xOffset, position.Y + yOffset);
        }

    }
}
