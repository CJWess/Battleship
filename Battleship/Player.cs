using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public void TakeShot(Board board)
        {
            Console.WriteLine("Take the shot, Captain. (x y)");
            string input = Console.ReadLine();

            int xInput = int.Parse(input.Split(' ')[0]);
            int yInput = int.Parse(input.Split(' ')[1]);

            while (xInput >= board.Width && xInput <= 0 && yInput <= 0 && yInput >= board.Height) //need to add contingency for overlapping shot
            {
                Console.WriteLine("Invalid shot! Please Fire Inbounds!");
            }
                board.TakeShot(new Point(xInput, yInput), out string aiShipStatus); //takeshot on ai board
                Console.WriteLine(aiShipStatus);
        }

        public void InvalidShot(Board board, Point shot)
        {
            //
        }
    }
}
