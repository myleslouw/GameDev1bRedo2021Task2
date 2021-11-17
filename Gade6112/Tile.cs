using System;

namespace Gade6112
{
    [Serializable]
    abstract class Tile
    {
        protected int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        protected int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        protected string symbol;

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        public enum TileType { Hero, Enemy, Gold, Weapon}


        public Tile(int y, int x, string symbol)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "Tile: " + X + " " +  Y;
        }

    }
}
