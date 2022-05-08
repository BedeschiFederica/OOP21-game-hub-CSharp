using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Delja_Alesja
{
    class Test
    {
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
        public void TestViewField()
        {
            ViewField view = new ViewField(6,4);
            Assert.AreEqual(6 , 6);
        }
    }
}
