using System.Collections.Generic;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Interface that represents a (square) grid of blocks.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// The size of the grid.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// The dictionary of the blocks.
        /// </summary>
        Dictionary<IPosition, IBlock> Blocks { get; }

        /// <summary>
        /// Tells if the grid is complete.
        /// Every block needs to have the number of currents links equal to their maximum one.
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        /// Tells if the given position is legal or not.
        /// To be legal it has to be in range 0 - Size.
        /// </summary>
        /// <param name="position"> the position to check </param>
        /// <returns> true if the given position is legal </returns>
        bool IsLegal(IPosition position);

        /// <summary>
        /// Gets the block in the given position.
        /// </summary>
        /// <param name="position"> the position of the block </param>
        /// <returns> the block in the given position </returns>
        IBlock GetBlockAt(IPosition position);

        /// <summary>
        /// Gets the position next to the given one in the given direction.
        /// </summary>
        /// <param name="position"> the initial position </param>
        /// <param name="direction"> the direction of the nearby position </param>
        /// <returns> the nearby position </returns>
        IPosition GetNearbyPosition(IPosition position, Direction direction);

        /// <summary>
        /// Gets the direction from the first given position to the second given position.
        /// Note: the positions must be adjacent.
        /// </summary>
        /// <param name="pos1"> the first position </param>
        /// <param name="pos2"> the second position </param>
        /// <returns> the direction from pos1 to pos2 </returns>
        Direction GetDirection(IPosition pos1, IPosition pos2);

        /// <summary>
        /// Tells if the two blocks in the given positions can link or not.
        /// It checks adjacency.
        /// </summary>
        /// <param name="pos1"> the position of the first block </param>
        /// <param name="pos2"> the position of the second block </param>
        /// <returns> true if the two blocks specified by pos1 and pos2 can link </returns>
        bool CanLink(IPosition pos1, IPosition pos2);

        /// <summary>
        /// Links the two blocks specified by the given positions.
        /// Note: you should call the method CanLink() before calling this one.
        /// </summary>
        /// <param name="pos1"> the position of the first block </param>
        /// <param name="pos2"> the position of the second block </param>
        void Link(IPosition pos1, IPosition pos2);

        /// <summary>
        /// Gets the number of links between the two blocks specified by the given positions.
        /// Note: the given positions must be legal and adjacent.
        /// </summary>
        /// <param name="pos1"> the position of the first block </param>
        /// <param name="pos2"> the position of the second block </param>
        /// <returns> the number of links between the two blocks </returns>
        int GetLinks(IPosition pos1, IPosition pos2);

    }
}
