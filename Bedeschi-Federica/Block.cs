using System;
using System.Collections.Generic;
using System.Linq;

namespace Bedeschi_Federica
{
    /// <summary>
    /// Class that represents a block that can be linked to another block.
    /// </summary>
    public class Block : IBlock
    {
        private const int DEFAULT_LINKS_PER_SIDE = 0;
        private const int MAX_LINKS_PER_SIDE = 2;

        private IDictionary<Direction, int> _linksPerSide;

        /// <inheritdoc/>
        public int LinksToHave { get; }

        /// <inheritdoc/>
        public int CurrentLinks { get => _linksPerSide.Values.Sum(); }

        /// <summary>
        /// Builds a new Block.
        /// <param name="linksToHave"> the total number of links that the block will have to have </param>
        /// </summary>
        public Block(int linksToHave)
        {
            LinksToHave = linksToHave;
            _linksPerSide = new Dictionary<Direction, int>();
            foreach (Direction d in Enum.GetValues(typeof(Direction)))
            {
                _linksPerSide[d] = DEFAULT_LINKS_PER_SIDE;
            }
        }

        /// <inheritdoc/>
        public int GetLinks(Direction direction) => _linksPerSide[direction];

        /// <inheritdoc/>
        public bool CanLink(Direction direction) => GetLinks(direction) < MAX_LINKS_PER_SIDE;

        /// <inheritdoc/>
        public void AddLink(Direction direction)
        {
            if (!CanLink(direction))
            {
                throw new InvalidOperationException("Can't link");
            }
            _linksPerSide[direction]++;
        }

        private void ResetLinks(Direction direction) => _linksPerSide[direction] = 0;

        /// <inheritdoc/>
        public void Link(Direction direction)
        {
            if (!CanLink(direction))
            {
                ResetLinks(direction);
            }
            else
            {
                AddLink(direction);
            }
        }

        /// <inheritdoc/>
        public override string ToString() =>
            "Block [LinksToHave=" + LinksToHave+ ", LinksPerSide=" + _linksPerSide + "]";

    }
}
