using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Opponent
    {
        private enum ActionState
        {
            FindingShip,
            FindingOrientation,
            SinkingShip,
        }

        private enum Direction
        {
        Vertical,
        Horizontal
        }

        private Point nextShot;
        private Point initialHit;
        private Point secondHit;
        private ActionState actionState;
        private Direction direction;
        private readonly Random random;

        public Opponent()
        {
            actionState = ActionState.FindingShip;
            random = new Random();
        }

        public void TakeShot(Board board)
        {
            Point shot = null;

            switch (actionState)
            {
                case ActionState.FindingShip:
                    shot = GetShotForFindingShip(board);
                    break;

                case ActionState.FindingOrientation:
                    shot = GetShotForFindingOrientation(board, shot); //shot refers to last shot taken
                    break;

                case ActionState.SinkingShip:
                    break;
            }


            Board.ShotResult shotResult = board.TakeShot(shot);

            switch (actionState)
            {
                case ActionState.FindingShip:
                    AfterShotForFindingShip(shot, shotResult);
                    break;

                case ActionState.FindingOrientation:
                    AfterShotForFindingOrientation(shot, shotResult);
                    break;

                case ActionState.SinkingShip:
                    break;
            }
            //functions for each





            // if our last shot hit, do something

            // else do something else





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

        private void AfterShotForFindingShip(Point shot, Board.ShotResult shotResult)
        {
            if(shotResult == Board.ShotResult.HitWithoutSink)
            {
                //lastShot = shot;
                initialHit = shot;
                actionState = ActionState.FindingOrientation;
            }

        }

        private void AfterShotForFindingOrientation(Point shot, Board.ShotResult shotResult)
        {
            if(shotResult == Board.ShotResult.HitWithoutSink)
            {
                //lastShot = shot;
                secondHit = shot;
                actionState = ActionState.SinkingShip;

                if(initialHit.X == secondHit.X)
                {
                    direction = Direction.Vertical;
                }
                else if(initialHit.Y == secondHit.Y)
                {
                    direction = Direction.Horizontal;
                }
            }
            else if(shotResult == Board.ShotResult.HitAndSink)
            {
                actionState = ActionState.FindingShip;
            }
        }

        private void AfterShotForSinkingShip(Point shot, Board.ShotResult shotResult)
        {
            if (shotResult == Board.ShotResult.HitWithoutSink)
            {
                //lastShot = shot;
            }
            else if (shotResult == Board.ShotResult.Miss)
            {
                if(direction == Direction.Vertical)
                {
                    shot = new Point(initialHit.X, (initialHit.Y - secondHit.Y));
                }
            }
            else if (shotResult == Board.ShotResult.HitAndSink)
            {
                actionState = ActionState.FindingOrientation;
            }
        }


        private Point GetShotForFindingShip(Board board)
        {
            var shot = RandomShot(board);
            while(!NotPreviouslyShot(board, shot))
            {
                shot = RandomShot(board);
            }
            return shot;
        }

        private Point GetShotForFindingOrientation(Board board, Point lastShot)
        {
            Point right = new Point(lastShot.X + 1, lastShot.Y);
            Point left = new Point(lastShot.X - 1, lastShot.Y);
            Point down = new Point(lastShot.X, lastShot.Y + 1);
            Point up = new Point(lastShot.X, lastShot.Y - 1);

            List<Point> directionPoints = new List<Point>();

            if (IsValidShot(board, right))
            {
                directionPoints.Add(right);
            }
            if (IsValidShot(board, left))
            {
                directionPoints.Add(left);
            }
            if (IsValidShot(board, up))
            {
                directionPoints.Add(up);
            }
            if (IsValidShot(board, down))
            {
                directionPoints.Add(down);
            }

            int index = random.Next(directionPoints.Count);

            return directionPoints[index];
        }

        private Point GetShotForSinkingShip(Board board, Point originalHit, Point nextShot, Point secondHit)
        {
            //if(direction == Direction.Vertical)
            //{
            //    if(originalHit.X - secondHit.X < 0 )
            //    nextShot = new Point()
            //}
            //if secondHit was going up from originalHit, shoot up again until miss or ship is sunk
            //if miss and ship not sunk, go down from original point
            //repeat for each direction

            //stretch - prioritize empty spaces between stray hits on board
            
            return null;
        }

        private bool IsValidShot(Board board, Point shot)
        {
            return board.InBounds(shot) && NotPreviouslyShot(board, shot);
        }

        private bool NotPreviouslyShot(Board board, Point shot)
        {
            return !board.ShotAlreadyTakenAt(shot);
        }

        private Point RandomShot(Board board)
        {
            return new Point(random.Next(0, board.Width - 1), random.Next(0, board.Height - 1));
        }
    }
}
