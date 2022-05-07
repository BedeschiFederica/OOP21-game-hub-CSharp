namespace Bedeschi_Federica
{
    /// <summary>
    /// Interface that represents a block that can be linked to another block.
    /// </summary>
    public interface IBlock
    {

        /// <summary>
        /// The total number of links that the block will have to have.
        /// </summary>
        int LinksToHave { get; }

        /// <summary>
        /// The current number of total links of the block
        /// </summary>
        int CurrentLinks { get; }

        /// <summary>
        /// Gets the number of links that the block has in the given direction.
        /// </summary>
        /// <param name="direction"> the direction of the links </param>
        /// <returns> the number of links in the given direction </returns>
        int GetLinks(Direction direction);

        /// <summary>
        /// Tells if the block can be linked in the given direction or not.
        /// It checks the number of links per side.
        /// </summary>
        /// <param name="direction"> the direction of the link </param>
        /// <returns> true if the block can be linked in the given direction </returns>
        bool CanLink(Direction direction);

        /// <summary>
        /// Adds a link in the given direction.
        /// Note: you should call the method canLink() before calling this one.
        /// </summary>
        /// <param name="direction"> the direction of the link </param>
        void AddLink(Direction direction);

        /// <summary>
        /// Links the block in the given direction.
        /// If the maximum number of links in the given direction is reached,
        /// the number of links will be reset to the default.
        /// </summary>
        /// <param name="direction"> the direction of the link </param>
        void Link(Direction direction);

    }
}
