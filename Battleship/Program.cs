using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        //set up game board 5x5 (list of lists or array of arrays?)
        //set up ships and sizes
        //set up placement randomizers with checks that ships won't be out of bounds
            //-put first character (var start) of ship on a random space [random(0-4)][random(0-4)]
            //check each space around it (start[x-1][y], start[x+1][y], start[x][y+1], [start[x][y-1])
            //shove all valid spaces into array, then pick one at random
            //continue check in that direction based on length of ship (2, 3, 4 spaces)
        //
        static void Main(string[] args)
        {
            Board playerBoard = new Board(5, 5, 3, 4, 1);
            Board aiBoard = new Board(5, 5, 3, 4, 1);

            GameStart(playerBoard, aiBoard);  

        }
        static void GameStart(Board playerBoard, Board aiBoard)
        {
            string lastShotStatus = "Miss.";
            Point lastShot;
            Random rnd = new Random();
            playerBoard.PrintBoard(true); //playerboard and aiboard
            aiBoard.PrintBoard(false);

            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine("Take the shot, Captain. (x y)");
                string input = Console.ReadLine();

                int xInput = int.Parse(input.Split(' ')[0]);
                int yInput = int.Parse(input.Split(' ')[1]);

                aiBoard.TakeShot(new Point(xInput, yInput), out string aiShipStatus); //takeshot on ai board
                Console.WriteLine(aiShipStatus);

                if (lastShotStatus == "Hit")
                {

                }
                else
                {
                    Point currentShot = new Point(rnd.Next(0, 5), rnd.Next(0, 5));
                    playerBoard.TakeShot(currentShot, out string playerShipStatus); //takeshot on playerboard logic
                    lastShotStatus = playerShipStatus;
                    lastShot = currentShot;
                    Console.WriteLine(playerShipStatus);
                }



                aiBoard.PrintBoard(false); // add argument that toggles display of ships
                if (aiBoard.IsGameOver() || playerBoard.IsGameOver())//update so that game ends when one board reaches end state
                {
                    Console.WriteLine("Game Over!");
                    break;
                }
            }

            Console.WriteLine("Press any key to exit. . .");

            Console.ReadKey();
        }
    }
}
