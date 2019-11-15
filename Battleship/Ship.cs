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
            Vertical = 0,
            Horizontal = 1
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

        public bool InBounds(Board board)
        {
            bool inBounds = true;
            foreach (Point point in ShipCoordinates())
            {
                if (point.X < 0 || point.X >= board.Width || point.Y < 0 || point.Y >= board.Height)
                {
                    inBounds = false;
                    break;
                }
            }
            return inBounds;
        }

        private List<Point> TestCoordinates
        {
            get
            {
                return ShipCoordinates();
            }
        }

        private List<Point> ShipCoordinates()
        {
            List<Point> shipCoords = new List<Point>();

            if (orientation == Orientation.Vertical)
            {
                for (int i = startPoint.Y; i < startPoint.Y + length; i++)
                {
                    Point point = new Point(startPoint.X, i);
                    shipCoords.Add(point);
                }
            }

            else if (orientation == Orientation.Horizontal)
            {
                for (int i = startPoint.X; i < startPoint.X + length; i++)
                {
                    Point point = new Point(i, startPoint.Y);
                    shipCoords.Add(point);
                }
            }

            return shipCoords;
        }

        public bool CoordOverlap(Point point)
        {
            return ShipCoordinates().Contains(point);
        }

        public static Orientation RandomOrientation(Random random)
        {
            return (Orientation)random.Next(0, 2);
        }
    }
}
