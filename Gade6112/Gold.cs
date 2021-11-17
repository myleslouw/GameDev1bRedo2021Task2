using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    [Serializable]
    class Gold : Item
    {
        private int goldAmount;

        public int GoldAmount
        {
            get { return goldAmount; }
            set { goldAmount = value; }
        }

        private Random rndm = new Random();


        public Gold(int y, int x, string symbol) : base(y, x, symbol)
        {
            X = x;
            Y = y;
            Symbol = "$";
            goldAmount = rndm.Next(1,6);  //randoms amount between 1 and 5
        }
        public override string ToString()
        {
            return goldAmount + " Gold! at (" + X + ", " + Y + ")";
        }
    }
}
