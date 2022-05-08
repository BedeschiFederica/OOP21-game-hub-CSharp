using System;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Class that represents a position specified by its coordinates x and y.
    /// </summary>
    public class Position : IPosition
    {
        /// <inheritdoc/>
        public int X { get; }

        /// <inheritdoc/>
        public int Y { get; }

        /// <summary>
        /// Builds a new Position.
        /// </summary>
        /// <param name="x"> its x coordinate </param>
        /// <param name="y"> its y coordinate </param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj is IPosition position && X == position.X && Y == position.Y;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <inheritdoc/>
        public override string ToString() => "Position [x=" + X + ", y=" + Y + "]";

    }
}
