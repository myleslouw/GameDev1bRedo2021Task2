using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    abstract class Item : Tile
    {
        public Item(int y, int x, string symbol) : base(y, x, symbol)
        {
            X = x;
            Y = y;
            Symbol = " ! ";
        }
        public override string ToString()
        {
            return "item!";
        }
    }
}
