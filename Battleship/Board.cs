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

        private List<Point> shotsTaken;

        private Random random;
        public Board(int width, int height, params int[] shipLengths)
        {
            random = new Random();
            Width = width;
            Height = height;
            shotsTaken = new List<Point>();
            InitShips(shipLengths);
        }

        // will have some collection of ships
        private void InitShips(int[] shipLengths)
        {
            ships = new List<Ship>();
           
            for (int i = 0; i < shipLengths.Count(); i++)
            {
                Ship ship = new Ship(shipLengths[i]);

                PlaceShip(ship);
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

            // CH - To all of the above: yes, at some point
            // TODO:
            // 1. Test Ship.InBounds(Board) ♥♦♣♠ // CH - Try to use more robust tests. The only position you're testing is (0,0)
            // 2. Draw board to console (for debugging include an option to draw ships) ♥♦
            // 3. Allow user to take shots
        }

        public bool ContainsAllShips()
        {
            return !ships.Any(x => !x.InBounds(this));
        }

        private Point RandomPoint()
        {
            return new Point(random.Next(0, Width), random.Next(0, Height));
        }

        // bug from before:
        // we were breaking out of the inner loop used to check for overlap against other ships
        // but not out of the outer loop that was running the placing logic for x attempts
        // which was causing the ship to be moved once it had been placed, dodging our in bounds check
        // lesson learned: the overlaps against any other ship check should have been contained in a different function
        // (or use a more concise method to check overlaps)
        private void PlaceShip(Ship ship)
        {
            int limit = 1000000;

            for (int i = 0; i < limit; i++)
            {
                ship.SetPosition(RandomPoint(), Ship.RandomOrientation(random));

                bool inBounds = ship.InBounds(this);
                bool overlapsOther = ships.Any(x => x.Overlaps(ship));

                if (inBounds && !overlapsOther)
                {
                    ships.Add(ship);
                    break;
                }
            }
        }

        public void PrintBoard(bool showShips)//pass in bool showships and display only playerboard ships "showShips"
        {
            Console.WriteLine();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Point point = new Point(x, y);
                    bool shipAtPoint = ships.Any(ship => ship.CoordOverlap(point));
                    bool shotTakenAtPoint = shotsTaken.Any(shot => shot.Equals(new Point(x, y)));

                    if (shotTakenAtPoint)
                    {
                        if (shipAtPoint) Console.Write("[X]");
                        else Console.Write("[-]");
                    }
                    else
                    {
                        Console.Write((shipAtPoint && showShips) ? "[O]" : "[ ]") ;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void TakeShot(Point shot, out string shipStatus)
        {
            shipStatus = "Miss.";
            if (!shotsTaken.Contains(shot))
            {
                shotsTaken.Add(shot);
                Ship shipHit = ships.Find(x => x.CoordOverlap(shot));

                if (shipHit != null)
                {
                    shipStatus = "Hit";
                    if (shipHit.IsSunk(shotsTaken))
                    {
                        shipStatus += " and ship sunk";
                    }
                }
            }


            // check if shot hits ship
            // if ship is hit, check if ship sinks and/or all ships have sunk
                //-for each ship in ships, check if shotsTaken contains every point making up ship


            // will need to store data for the shot 
        }

        //private Ship ShipSunkByShot(Point shot)
        //{
        //    List<Ship> sunkenShipsAfterShot = ships.Where(x => x.IsSunk(shotsTaken)).ToList();
        //    List<Point> shotsBeforeShot = shotsTaken.Where(x => !x.Equals(shot)).ToList();
        //    List<Ship> alreadySunkenShips = ships.Where(x => x.IsSunk(shotsTaken)).ToList();
        //    Ship sunkenShip = sunkenShipsAfterShot.Except(alreadySunkenShips).FirstOrDefault();
        //    return sunkenShip;
        //}

        public bool IsGameOver()
        {
            return ships.All(x => x.IsSunk(shotsTaken));
        }
    }
}
