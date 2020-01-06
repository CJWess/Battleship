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
            Point shot = PromptShot();

            while (!IsValidShot(board, shot))
            {
                Console.WriteLine("Invalid shot! Please Fire Inbounds!");
                shot = PromptShot();
            }
            board.TakeShot(shot, out string aiShipStatus);
            Console.WriteLine(aiShipStatus);
        }
        public Point PromptShot()
        {
            Console.WriteLine("Take the shot, Captain. (x y)");
            string input = Console.ReadLine();

            int xInput = int.Parse(input.Split(' ')[0]);
            int yInput = int.Parse(input.Split(' ')[1]);

            return new Point(xInput, yInput);
        }

        public bool IsValidShot(Board board, Point shot)
        {
            return InBounds(board, shot) && NotPreviouslyShot(board, shot);
        }

        private bool InBounds(Board board, Point shot)
        {
            return shot.X < board.Width && shot.X >= 0 && shot.Y >= 0 && shot.Y < board.Height;
        }

        private bool NotPreviouslyShot(Board board, Point shot)
        {
            return !board.ShotAlreadyTakenAt(shot);
        }
    }
}
