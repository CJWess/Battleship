using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship;

namespace BattleshipTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ship mainShip = new Ship(4);
            Ship otherShip = new Ship(3);


            mainShip.SetPosition(new Point(1, 4), Ship.Orientation.Vertical);
            otherShip.SetPosition(new Point(0, 2), Ship.Orientation.Horizontal);

            Assert.IsTrue(!mainShip.Overlaps(otherShip));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Ship mainShip = new Ship(4);
            Ship otherShip = new Ship(3);


            mainShip.SetPosition(new Point(0, 2), Ship.Orientation.Vertical);
            otherShip.SetPosition(new Point(0, 2), Ship.Orientation.Horizontal);

            Assert.IsTrue(mainShip.Overlaps(otherShip));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Ship mainShip = new Ship(4);
            Ship otherShip = new Ship(3);


            mainShip.SetPosition(new Point(1, 1), Ship.Orientation.Vertical);
            otherShip.SetPosition(new Point(0, 2), Ship.Orientation.Horizontal);

            Assert.IsTrue(mainShip.Overlaps(otherShip));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Ship ship = new Ship(4);

            // You don't need the 4 for the ship lengths portion of the constructor
            // the ship that will generate for the board is not the same as the one initialized above
            Board board = new Board(4, 4, 4);

            ship.SetPosition(new Point(0, 0), Ship.Orientation.Vertical);

            Assert.IsTrue(ship.InBounds(board));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Ship ship = new Ship(6);
            Board board = new Board(4, 4, 6);

            ship.SetPosition(new Point(0, 0), Ship.Orientation.Vertical);

            Assert.IsFalse(ship.InBounds(board));
        }

        [TestMethod]
        public void TestMethod6()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Board board = new Board(5, 5, 3, 4, 1);
                Assert.IsTrue(board.ContainsAllShips());
            }
        }
    }
}
