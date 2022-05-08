using System;
using System.Collections.Generic;
using System.Linq;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Class that represents a (square) grid of blocks.
    /// </summary>
    public class Grid : IGrid
    {
        private const int MAX_LINKS_PER_BLOCK = 99;

        /// <inheritdoc/>
        public int Size { get; }

        /// <inheritdoc/>
        public Dictionary<IPosition, IBlock> Blocks { get; }

        /// <summary>
        /// Builds a new Grid.
        /// </summary>
        /// <param name="size"> the size of the square grid </param>
        public Grid(int size)
        {
            Size = size;
            Blocks = new Dictionary<IPosition, IBlock>();
            Enumerable.Range(0, Size).ToList()
                .ForEach(i => Enumerable.Range(0, Size).ToList()
                    .ForEach(j => Blocks[new Position(i, j)] = new Block(MAX_LINKS_PER_BLOCK)));
        }

        /// <summary>
        /// Builds a new Grid.
        /// </summary>
        /// <param name="size"> the size of the square grid </param>
        /// <param name="blocks"> the dictionary of the blocks that the grid will have </param>
        public Grid(int size, Dictionary<IPosition, IBlock> blocks)
        {
            if (blocks == null)
            {
                throw new ArgumentNullException(nameof(blocks));
            }
            Size = size;
            Blocks = blocks;
        }

        /// <inheritdoc/>
        public bool IsLegal(IPosition position) =>
            position != null && position.X >= 0 && position.X < Size && position.Y >= 0 && position.Y < Size;

        private void RequireLegalPosition(IPosition position)
        {
            if (!IsLegal(position))
            {
                throw new ArgumentException("Illegal position");
            }
        }

        /// <inheritdoc/>
        public IBlock GetBlockAt(IPosition position)
        {
            RequireLegalPosition(position);
            return Blocks[position];
        }

        /// <inheritdoc/>
        public IPosition GetNearbyPosition(IPosition position, Direction direction)
        {
            RequireLegalPosition(position);
            IPosition nearbyPosition = DirectionUtility.GetPosition(position, direction);
            if (!IsLegal(nearbyPosition))
            {
                throw new InvalidOperationException("Illegal position");
            }
            return nearbyPosition;
        }

        /// <inheritdoc/>
        public Direction GetDirection(IPosition pos1, IPosition pos2)
        {
            RequireLegalPosition(pos1);
            RequireLegalPosition(pos2);
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
               if (DirectionUtility.GetPosition(pos1, d).Equals(pos2))
                {
                    return d;
                }
            }
            throw new InvalidOperationException("Positions aren't adjacent");
        }

        /// <inheritdoc/>
        public bool CanLink(IPosition pos1, IPosition pos2)
        {
            try
            {
                GetDirection(pos1, pos2);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }

        /// <inheritdoc/>
        public void Link(IPosition pos1, IPosition pos2)
        {
            Direction directionFrom1To2 = GetDirection(pos1, pos2);
            Blocks[pos1].Link(directionFrom1To2);
            Blocks[pos2].Link(DirectionUtility.Opposite(directionFrom1To2));
        }

        /// <inheritdoc/>
        public int GetLinks(IPosition pos1, IPosition pos2)
        {
            Direction directionFrom1To2 = GetDirection(pos1, pos2);
            return Blocks[pos1].GetLinks(directionFrom1To2);
        }

        /// <inheritdoc/>
        public bool IsComplete()
        {
            foreach (Block b in Blocks.Values)
            {
                if (b.CurrentLinks != b.LinksToHave)
                {
                    return false;
                }
            }
            return true;
        }

        /// <inheritdoc/>
        public override string ToString() => "Grid [size=" + Size + ", blocks=" + Blocks + "]";

    }
}
