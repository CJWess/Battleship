using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
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
            return ShipCoordinates().Any(x => other.ShipCoordinates().Contains(x));
        }

    private List<Point> ShipCoordinates()
        {
            List<Point> shipCoords = new List<Point>();
            shipCoords.Add(startPoint);
            if (orientation == Orientation.Vertical)
            {

                for (int i = startPoint.Y; i < length; i++)
                {
                    Point point = new Point(startPoint.X, i);
                    shipCoords.Add(point);
                }
            }

            else if (orientation == Orientation.Horizontal)
            {
                for (int i = startPoint.X; i < length; i++)
                {
                    Point point = new Point(i, startPoint.Y);
                    shipCoords.Add(point);
                }

            }
            return shipCoords;
        }
    }
}
