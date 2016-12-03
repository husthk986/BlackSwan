using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class Medium_1
    {
        static void Main(string[] args)
        {
            //DoIt(new _424LongestRepeatingReplacement());
            //DoIt(new _2AddTwoNumbers());
            //DoIt(new _3LongestUniqueSubString());
            //DoIt(new _5LongestPalindrome());
            //DoIt(new _11WaterContainer());
            //DoIt(new _12IntegerToRoman());
            //DoIt(new _15ThreeSum());
            //DoIt(new _16ThreeSumCloest());
            //DoIt(new _17DigitalToString());
            //DoIt(new _18FourSum());
            DoIt(new _22GenerateParentheses());

            Console.WriteLine("done");
            Console.Read();
        }

        private static void DoIt(ILeetcode il)
        {
            il.DoIt();
        }
    }
}
