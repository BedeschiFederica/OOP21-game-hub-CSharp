using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Web.UI;

namespace Furegato_Silvia
{
    [TestFixture]
    class TestModel
    {
        [Test]
        public void TestCell() 
        {
            
        }

        [Test]
        public void TestMaxMovesCounter()
        {
            int min = 5;
            int none = 22;
            int minResult = 16;
            IMovesCounter counter = new MaxMovesCounter(min);
            Assert.AreEqual(minResult, counter.Count());
            counter = new MaxMovesCounter(none);
            Assert.AreNotEqual(minResult, counter.Count());
            Assert.AreEqual(0, counter.Count());
        }

        [Test]
        public void TestColors()
        {

        }

        [Test]
        public void TestTable()
        {

        }

        [Test]
        public void TestFloodItModel()
        {

        }
    }
}
