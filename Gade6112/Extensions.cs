using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade6112
{
    public static class Extensions
    {
        public static void Fill<T>(this T[,] originalArray, T with)  //takes a value from the original array 
        {
            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                for (int j = 0; j < originalArray.GetLength(1); j++)
                {
                    originalArray[i, j] = with; //fills it with the the value
                }
            }
        }
    }
}
