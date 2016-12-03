using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class Easy1
    {
        static void Main(string[] args)
        {
            //DoIt(new _1TwoSum());
            //DoIt(new _6ZigzagConversion());
            //DoIt(new _7ReverseInteger());
            //DoIt(new _8StringToInteger());
            //DoIt(new _9PalindromeNumber());
            //DoIt(new _13RomanToInt());
            //DoIt(new _14LongestCommonPrefix());
            //DoIt(new _19RemoveNthNode());
            //DoIt(new _20ValidParentheses());
            //DoIt(new _21MergeSortedLinkedList());
            DoIt(new _24SwapNodesInPairs());

            Console.WriteLine("done");
            Console.Read();
        }

        private static void DoIt(ILeetcode il)
        {
            il.DoIt();
        }
    }
}
