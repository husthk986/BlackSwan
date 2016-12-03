using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class Hard_1
    {
        static void Main(string[] args)
        {
            //DoIt(new _4MedianOfTwoSortedArrays());
            //DoIt(new _10RegularExpression());
            DoIt(new _23MergedKSortedList());

            Console.WriteLine("done");
            Console.Read();
        }

        private static void DoIt(ILeetCode il)
        {
            il.DoIt();
        }

    }
}
