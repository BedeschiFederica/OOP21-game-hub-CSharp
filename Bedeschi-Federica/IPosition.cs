namespace Bedeschi_Federica
{
    /// <summary>
    /// Interface that represents a position specified by its coordinates x and y.
    /// It's like a data type, it's made to be used everywhere you need it.
    /// </summary>
    public interface IPosition
    {

        /// <summary>
        /// The x coordinate.
        /// </summary>
        int X { get; }

        /// <summary>
        /// The y coordinate.
        /// </summary>
        int Y { get; }

    }
}
