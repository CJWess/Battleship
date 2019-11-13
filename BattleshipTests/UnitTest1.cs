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
    }
}
