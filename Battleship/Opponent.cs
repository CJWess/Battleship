using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Opponent
    {
        private Point lastShot;
        private bool lastShotStatus;

        public void TakeShot(Board board)
        {
            // if our last shot hit, do something
            
            // else do something else




            //Random rnd = new Random();
            //Point shot = new Point(rnd.Next(0, 5), rnd.Next(0, 5));
            //if (!board.ShotAlreadyTakenAt(shot))
            //{
            //    lastShotStatus = board.TakeShot(shot, out string shipStatus);
            //    lastShot = shot;
            //}

            //if (lastShotStatus)
            //{
            //    //hit and ship not sunk logic
            //}

            //else
            //{

            //}

        }
    }
}
