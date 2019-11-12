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
            char[,] gameBoard = new char[5, 5]
            {
                {' ', 'O', 'O', ' ', 'O'},
                {' ', ' ', ' ', ' ', 'O'},
                {' ', ' ', ' ', 'O', 'O'},
                {' ', ' ', ' ', 'O', 'O'},
                {' ', ' ', ' ', 'O', ' '}
            };

            char[,] firstShip = new char[5, 5]
            {
                {' ', 'O', 'O', ' ', ' '},
                {' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' '}
            };

            GameStart(gameBoard);
            
            
         
        }
        static void GameStart(char[,] board)
        {
            Point point = new Point(1, 2);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Take the shot, Captain. " +
                    "(Enter an X coordinate 1-5)");
                int xInit = Int32.Parse(Console.ReadLine());
                Console.WriteLine("(Enter a Y coordinate 1-5)");
                int yInit = Int32.Parse(Console.ReadLine());

                if (board[xInit - 1, yInit - 1] == 'O')
                {
                    Console.WriteLine("Hit!");
                    board[xInit - 1, yInit - 1] = 'X';
                }

                else
                {
                    Console.WriteLine("Miss");
                }

                Console.WriteLine("Number of shots left" + i);

                if (IsGameOver(board))
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }


            Console.WriteLine("Press any key to exit. . .");

            Console.ReadKey();



        }

        static bool IsGameOver(char[,] board)
        {
            int hitsLeft = 0;
            for (int j = 0; j < board.GetLength(0); j++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    if (board[j, k] == 'O')
                    {
                        hitsLeft += 1;
                    }
                }

            }
            if (hitsLeft == 0)
            {
                return true;
            }
            return false;
        }
    }
}
