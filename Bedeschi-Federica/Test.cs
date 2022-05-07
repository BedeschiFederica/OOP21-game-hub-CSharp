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
    }
}