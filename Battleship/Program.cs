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
            Board gameBoard = new Board(5, 5, 3, 4, 1);

            GameStart(gameBoard);  

        }
        static void GameStart(Board gameBoard)
        {
            
            gameBoard.PrintBoard();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Take the shot, Captain. " + "(Enter an X coordinate)");
                string input = Console.ReadLine();
                int xInput = int.Parse(Console.ReadLine());

                Console.WriteLine("(Enter a Y coordinate)");
                int yInput = int.Parse(Console.ReadLine());

                gameBoard.TakeShot(new Point(xInput, yInput), out string shipStatus);
                Console.WriteLine(shipStatus);
                gameBoard.PrintBoard();
                if (gameBoard.IsGameOver())
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
