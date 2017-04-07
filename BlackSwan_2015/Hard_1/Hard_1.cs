using System;
using System.CodeDom.Compiler;
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
            //DoIt(new _23MergedKSortedList());
            //DoIt(new _25ReverseNodesInKGroup());
            //DoIt(new _30SubWConcAllWords());
            //DoIt(new _56MergeInterval());
            //DoIt(new _174DungeonGame());
            DoIt(new _425WordSquare());

            Temp();
            Console.WriteLine("done");
            Console.Read();
        }

        private static void DoIt(ILeetCode il)
        {
            il.DoIt();
        }

        private static void Temp()
        {

        }
    }
}
