using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }

        private List<Ship> ships;
        public Board(int width, int height, params int[] shipLengths)
        {
            Width = width;
            Height = height;
            InitShips(shipLengths);
        }

        // will have some collection of ships
        private void InitShips(int[] shipLengths)
        {
            ships = new List<Ship>();

            //generate random start point
            //ship has to be within board bounds
            //ship can't overlap any other ships already existing (run Overlaps against every previous ship)
            //(maybe set a number of tries ~a few thousand or so) if they all fail, move on

        }
    }
}
