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
        private Random random;
        public Board(int width, int height, params int[] shipLengths)
        {
            random = new Random();
            Width = width;
            Height = height;
            InitShips(shipLengths);
        }

        // will have some collection of ships
        private void InitShips(int[] shipLengths)
        {
            ships = new List<Ship>();
            var orientationList = new List<Ship.Orientation> { Ship.Orientation.Horizontal, Ship.Orientation.Vertical };
           
            for (int i = 0; i > shipLengths.Count(); i++)
            {
                Ship ship = new Ship(shipLengths[i]);
                // try to place ship
                int countDown = 3000;
                ship.SetPosition(RandomPoint(), Ship.RandomOrientation(random));

                foreach (Ship shipInList in ships)
                {
                    while (ship.Overlaps(shipInList) || countDown != 0 || ship.InBounds(this))
                    {
                        ship.SetPosition(RandomPoint(), Ship.RandomOrientation(random));
                        countDown--;
                    }
                }
                if (countDown != 0)
                {
                    ships.Add(ship);
                }
            }

            //generate random start point ♥♦♣♠
            //ship has to be within board bounds ♥♦♣♠
            //ship can't overlap any other ships already existing (run Overlaps against every previous ship) ♥♦♣♠
            //(maybe set a number of tries ~a few thousand or so) if they all fail, move on ♥♦♣♠

            //------------------draw board------------------
            //empty spaces [ ]
            //ship spaces [O]
            //hit ships [X]

            //does the player get a board?
            //do they get to manually place pieces?

            //do we set up an ai opponent?
                //shoots randomly without repeating
                //if it hits, shoots in a random direction from that point until it hits again or sinks ship then resets


        }

        private Point RandomPoint()
        {
            return new Point(random.Next(0, Width), random.Next(0, Height));
        }
    }
}
