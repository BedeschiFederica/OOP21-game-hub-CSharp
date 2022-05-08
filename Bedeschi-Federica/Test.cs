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
    }
}