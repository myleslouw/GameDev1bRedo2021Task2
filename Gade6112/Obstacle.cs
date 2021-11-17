using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class Obstacle : Tile
    {
        public Obstacle(int y, int x, string symbol) : base(y,x,symbol)
        {
            X = x;
            Y = y;
            Symbol = "X";
        }
        public override string ToString()  //vision array will return this when player gets next to it
        {
            return "Map Limit";
        }
    }
}
