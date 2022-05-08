using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Delja_Alesja
{
    [TestFixture]
    public class Test
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test if the cell is created normally.
        /// </summary>
        [Test]
        public void TestCell()
        {
            Cell cell = new Cell(3, 1, false, false);
            Assert.AreEqual(3, cell.Type);
            Assert.AreEqual(1, cell.Position);
            Assert.AreEqual(false, cell.IsDiscovered);
            Assert.AreEqual(false, cell.Flagged);


        }
        /// <summary>
        /// Test of the class Field.
        /// </summary>
        [Test]
        public void TestField()
        {
            List<Cell> cell = new List<Cell>
            {
                new Cell(3, 1, false, false),
                new Cell(1, 2, true, true)
            };
            Field.SetCell(cell);
            Assert.AreEqual(cell, Field.GetCell());
        }

        static void Main()
        {
            Console.WriteLine("Classe di test");
        }
    }
}
