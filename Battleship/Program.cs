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
            Board boardTest = new Board(5, 5, 3, 4, 1);
            
            //char[,] gameBoard = new char[5, 5]
            //{
            //    {' ', 'O', 'O', ' ', 'O'},
            //    {' ', ' ', ' ', ' ', 'O'},
            //    {' ', ' ', ' ', 'O', 'O'},
            //    {' ', ' ', ' ', 'O', 'O'},
            //    {' ', ' ', ' ', 'O', ' '}
            //};

            //char[,] firstShip = new char[5, 5]
            //{
            //    {' ', 'O', 'O', ' ', ' '},
            //    {' ', ' ', ' ', ' ', ' '},
            //    {' ', ' ', ' ', ' ', ' '},
            //    {' ', ' ', ' ', ' ', ' '},
            //    {' ', ' ', ' ', ' ', ' '}
            //};

            GameStart(boardTest);
            
            
         
        }
        static void GameStart(Board boardTest)
        {
            
            Board.PrintBoard(boardTest);
            Point point = new Point(1, 2);
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Take the shot, Captain. " +
                    "(Enter an X coordinate 1-5)");
                int xInput = Int32.Parse(Console.ReadLine());
                Console.WriteLine("(Enter a Y coordinate 1-5)");
                int yInput = Int32.Parse(Console.ReadLine());

                if (boardTest[xInput - 1, yInput - 1] == 'O')
                {
                    Console.WriteLine("Hit!");
                    board[xInput - 1, yInput - 1] = 'X';
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

        static bool IsGameOver(Board board)
        {
            return board.ships


        //    int hitsLeft = 0;
        //    for (int j = 0; j < board.GetLength(0); j++)
        //    {
        //        for (int k = 0; k < board.GetLength(1); k++)
        //        {
        //            if (board[j, k] == 'O')
        //            {
        //                hitsLeft += 1;
        //            }
        //        }

        //    }
        //    if (hitsLeft == 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
