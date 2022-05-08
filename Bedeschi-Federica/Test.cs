using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Bedeschi_Federica
{
    [TestFixture]
    public class Test
    {
        private const int LINKS_PER_BLOCK = 5;
        private const int GRID_SIZE = 3;

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test if the block returns the correct number of current links.
        /// </summary>
        [Test]
        public void TestBlockCurrentLinks()
        {
            IBlock block = new Block(LINKS_PER_BLOCK);
            block.Link(Direction.Up);
            Assert.AreEqual(1, block.CurrentLinks);
            block.Link(Direction.Down);
            Assert.AreEqual(2, block.CurrentLinks);
            block.Link(Direction.Up);
            Assert.AreEqual(3, block.CurrentLinks);
        }

        /// <summary>
        /// Test if the block works correctly when the number of links per side exceeds the maximum value.
        /// It should reset the number of links of that side.
        /// Note: I'm assuming that the maximum value is 2 because this is a characteristic of the game that
        ///       shouldn't be changed.
        /// </summary>
        [Test]
        public void TestBlockTooMuchLinksPerSide()
        {
            IBlock block = new Block(LINKS_PER_BLOCK);
            block.Link(Direction.Up);
            block.Link(Direction.Up);
            Assert.AreEqual(2, block.CurrentLinks);
            block.Link(Direction.Up);
            Assert.AreEqual(0, block.CurrentLinks);
        }

        /// <summary>
        /// Test if the block throws an InvalidOperationException when you call addLink() with the number of
        /// links per side that is equal to the maximum value.
        /// Note: I'm assuming that the maximum value is 2 because this is a characteristic of the game that
        ///       shouldn't be changed.
        /// </summary>
        [Test]
        public void TestIllegalLinkAddition()
        {
            IBlock block = new Block(LINKS_PER_BLOCK);
            block.AddLink(Direction.Right);
            block.AddLink(Direction.Right);
            Assert.AreEqual(2, block.CurrentLinks);
            Assert.Throws<InvalidOperationException>(() => block.AddLink(Direction.Right));
        }

        /// <summary>
        /// Test if the grid recognizes legal or illegal positions.
        /// </summary>
        [Test]
        public void TestGridPositions()
        {
            IGrid grid = new Grid(GRID_SIZE);
            Assert.True(grid.IsLegal(new Position(0, 0)));
            Assert.True(grid.IsLegal(new Position(2, 2)));
            Assert.True(grid.IsLegal(new Position(1, 0)));
            Assert.True(grid.IsLegal(new Position(2, 1)));
            Assert.False(grid.IsLegal(new Position(-1, 0)));
            Assert.False(grid.IsLegal(new Position(1, -1)));
            Assert.False(grid.IsLegal(new Position(2, 3)));
            Assert.False(grid.IsLegal(new Position(4, 2)));
            Assert.False(grid.IsLegal(null));
        }

        /// <summary>
        /// Test if the grid returns the correct nearby positions.
        /// </summary>
        [Test]
        public void TestGridNearbyPositions()
        {
            IGrid grid = new Grid(GRID_SIZE);
            Assert.AreEqual(new Position(0, 1), grid.GetNearbyPosition(new Position(0, 0), Direction.Right));
            Assert.AreEqual(new Position(1, 1), grid.GetNearbyPosition(new Position(1, 2), Direction.Left));
            Assert.AreEqual(new Position(1, 2), grid.GetNearbyPosition(new Position(2, 2), Direction.Up));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetNearbyPosition(new Position(0, 0), Direction.Up));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetNearbyPosition(new Position(1, 0), Direction.Left));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetNearbyPosition(new Position(2, 1), Direction.Down));
        }

        /// <summary>
        /// Test if the grid returns the correct direction from one position to another.
        /// </summary>
        [Test]
        public void TestGridDirections()
        {
            IGrid grid = new Grid(GRID_SIZE);
            Assert.AreEqual(Direction.Right, grid.GetDirection(new Position(0, 0), new Position(0, 1)));
            Assert.AreEqual(Direction.Left, grid.GetDirection(new Position(0, 1), new Position(0, 0)));
            Assert.AreEqual(Direction.Down, grid.GetDirection(new Position(1, 2), new Position(2, 2)));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetDirection(new Position(0, 0), new Position(1, 1)));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetDirection(new Position(2, 0), new Position(0, 2)));
            Assert.Throws<InvalidOperationException>(
                () => grid.GetDirection(new Position(1, 0), new Position(1, 2)));
        }

        /// <summary>
        /// Test if the grid returns the correct number of links between two blocks.
        /// </summary>
        [Test]
        public void TestGridLinks()
        {
            IGrid grid = new Grid(GRID_SIZE);
            grid.Link(new Position(0, 0), new Position(0, 1));
            Assert.AreEqual(1, grid.GetLinks(new Position(0, 0), new Position(0, 1)));
            grid.Link(new Position(0, 0), new Position(0, 1));
            Assert.AreEqual(2, grid.GetLinks(new Position(0, 0), new Position(0, 1)));
            grid.Link(new Position(0, 0), new Position(0, 1));
            Assert.AreEqual(0, grid.GetLinks(new Position(0, 0), new Position(0, 1)));
            grid.Link(new Position(1, 1), new Position(2, 1));
            grid.Link(new Position(1, 1), new Position(2, 1));
            Assert.AreEqual(2, grid.GetLinks(new Position(1, 1), new Position(2, 1)));
        }

        /// <summary>
        /// Test if the grid works correctly if it receives illegal inputs (null objects or illegal positions).
        /// </summary>
        [Test]
        public void TestGridIllegalInputs()
        {
            Assert.Throws<ArgumentNullException>(() => new Grid(3, null));
            IGrid grid = new Grid(GRID_SIZE);
            Assert.Throws<ArgumentException>(() => grid.GetBlockAt(null));
            Assert.Throws<ArgumentException>(() => grid.GetBlockAt(new Position(3, 0)));
            Assert.Throws<ArgumentException>(() => grid.GetNearbyPosition(new Position(0, -1), Direction.Up));
            Assert.Throws<ArgumentException>(() => grid.GetNearbyPosition(new Position(4, 1), Direction.Up));
            Assert.Throws<ArgumentException>(() => grid.GetDirection(new Position(1, 4), new Position(0, 0)));
            Assert.Throws<ArgumentException>(() => grid.GetDirection(new Position(0, 0), null));
            Assert.Throws<ArgumentException>(() => grid.CanLink(null, new Position(0, 0)));
            Assert.Throws<ArgumentException>(() => grid.CanLink(new Position(0, 0), new Position(-1, 1)));
            Assert.Throws<ArgumentException>(() => grid.Link(new Position(0, 0), null));
            Assert.Throws<ArgumentException>(() => grid.Link(new Position(2, -1), new Position(0, 0)));
            Assert.Throws<ArgumentException>(() => grid.GetLinks(null, new Position(0, 0)));
            Assert.Throws<ArgumentException>(() => grid.GetLinks(new Position(0, 0), new Position(3, 1)));
        }

    }
}