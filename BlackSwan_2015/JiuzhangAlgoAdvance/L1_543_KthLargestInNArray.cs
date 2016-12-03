using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuzhangAlgoAdvance
{
    class L1_543_KthLargestInNArray : ILadder1
    {
        public void DoIt()
        {
            int[][] arrays =
            {
                new[] {2, 4, 5, 7, 1, 8, 2},
                new[] {1, 2},
                new[] {7, 8, 3, 1, 9, 10},
                new[] {17, 3, 5, 7, 9, 1}
            };
            int k = 5;
            Console.WriteLine("Should be 7: " + KthInArrays(arrays, k));
        }

        public int KthInArrays(int[][] arrays, int k)
        {
            // Write your code here
            if (!arrays.Any() || k <= 0)
                return 0;

            int numAmount = 0;
            foreach (int[] array in arrays)
            {
                Array.Sort(array);
                numAmount += array.Count();
            }

            if (numAmount < k)
                return 0;




            return 0;
        }
    }
}
