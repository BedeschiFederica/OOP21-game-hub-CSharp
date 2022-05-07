using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Furegato_Silvia
{
    [TestFixture]
    class TestModel
    {
        [Test]
        void TestCell() 
        { 
            int num1 = 4;
            int num2 = 4;
            Assert.True(num1.Equals(num2));

        }
    }
}
