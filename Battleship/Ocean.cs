using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ocean
    {
        public int Width { get; }
        public int Height { get; }

        private List<Ship> ships;
        public Ocean(int width, int height)
        {
            ships = new List<Ship>();
            Width = width;
            Height = height;
        }


        // will have some collection of ships

    }
}
