using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        public enum Orientation
        {
            Vertical,
            Horizontal
        }

        // some point
        private Point startPoint;
        // some length
        private int length;
        // some orientation
        private Orientation orientation;

        public Ship(int length)
        {
            this.length = length;
        }

        public void SetPosition(Point startPoint, Orientation orientation)
        {
            this.startPoint = startPoint;
            this.orientation = orientation;
        }

        public bool Overlaps(Ship other)
        {
            if (this.startPoint == other.startPoint)
            return true;


        }

        private List<Point> ShipCoordinates()
        {
            if (orientation == Orientation.Vertical)
            {
                for (Point i = startPoint; i.Y < length; i.Y)
            }
        }
    }
}
