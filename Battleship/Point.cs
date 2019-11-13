using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Point other = obj as Point;

            if (obj == null) return false;

            return X == other.X && Y == other.Y;
        }
    }
}
