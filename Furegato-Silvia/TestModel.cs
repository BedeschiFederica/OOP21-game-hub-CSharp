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
            Cell c = new Cell(Colors.GREEN, new Tuple<int, int>(3,6));
            Cell top = new Cell(Colors.ORANGE, new Tuple<int, int>(3, 5));
            Cell bottom = new Cell(Colors.MAGENTA, new Tuple<int, int>(3, 7));
            Cell right = new Cell(Colors.LIME, new Tuple<int, int>(4, 6));
            Cell left = new Cell(Colors.LIGHT_BLUE, new Tuple<int, int>(2, 6));

            Assert.False(c.Flooded);
            c.Flooded = true;
            Assert.True(c.Flooded);
            Assert.AreNotEqual(c.Position, new Tuple<int, int>(1, 1));
            Assert.AreEqual(c.Color, Colors.GREEN);
            c.SetAdjacentCells(top, bottom, right, left);
            Assert.AreEqual(top, c.GetAdjacentCells()[0]);
            Assert.AreEqual(bottom, c.GetAdjacentCells()[1]);
            Assert.AreEqual(right, c.GetAdjacentCells()[2]);
            Assert.AreEqual(left, c.GetAdjacentCells()[3]);
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
            int colorsNum = 4;
            int tooBig = 13;
            int tooLittle = -3;
            Assert.AreNotEqual(Colors.INDIGO, Colors.RED);
            Assert.AreEqual(colorsNum, Colors.BLUE.GetRandomColors(colorsNum).Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => Colors.BLUE.GetRandomColors(tooBig));
            Assert.Throws<ArgumentOutOfRangeException>(() => Colors.BLUE.GetRandomColors(tooLittle));
        }

        [Test]
        public void TestTable()
        {
            int size = 5;
            int colorsNum = 6;
            Table t = new Table(size, colorsNum, Colors.BLUE.GetRandomColors(6));
            t.GenerateTable();
            Assert.AreEqual(size*size, t.Board.Count);
            Cell top = t.GetCell(0,0).GetAdjacentCells()[0];
            Cell bottom = t.GetCell(0, 0).GetAdjacentCells()[1];
            Cell right = t.GetCell(0, 0).GetAdjacentCells()[2];
            Cell left = t.GetCell(0, 0).GetAdjacentCells()[3];
            Assert.Null(top);
            Assert.NotNull(bottom);
            Assert.NotNull(right);
            Assert.Null(left);

        }

        [Test]
        public void TestFloodItModel()
        {
            int size = 10;
            int colorsNum = 5;
            FloodItModel model = new FloodItModel();
            Assert.Null(model.GetTable());
            Assert.IsEmpty(model.GetSelectedColors());
            Assert.Null(model.MCounter);
            Assert.Zero(model.GetMoves());
            model.SetTable();
            model.SetSelectedColors(Colors.BLUE.GetRandomColors(colorsNum));
            model.IncrementMoves();
            model.MCounter = new MaxMovesCounter(size);
            model.SetMaxMoves();
            Assert.NotNull(model.GetTable());
            Assert.NotNull(model.GetSelectedColors());
            Assert.AreEqual(28, model.GetMaxMoves());
            Assert.AreEqual(1, model.GetMoves());
            model.IncrementMoves();
            model.IncrementMoves();
            Assert.AreEqual(3, model.GetMoves());
            model.Clear();
            Assert.Null(model.GetTable());
            Assert.IsEmpty(model.GetSelectedColors());
            Assert.Null(model.MCounter);
            Assert.Zero(model.GetMoves());
        }
    }
}
