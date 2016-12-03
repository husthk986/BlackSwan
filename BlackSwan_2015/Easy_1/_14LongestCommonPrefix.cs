using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _14LongestCommonPrefix : ILeetcode
    {
        public void DoIt()
        {
            string[] strs = { "abcde", "abcef", "abtefede" };
            Console.WriteLine("Should be ab: " + LongestCommonPrefix(strs));

            strs = new[] {"a"};
            Console.WriteLine("a: " + LongestCommonPrefix(strs));

            strs = new []{""};
            Console.WriteLine("Should be empty: " + LongestCommonPrefix(strs));
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Count() < 1) return string.Empty;
            if (strs.Count() == 1) return strs[0];

            int i = 0, j = strs.Count() - 1;
            int m = i + (j - i) / 2;

            string left = GetMergedString(strs, i, m);
            string right = GetMergedString(strs, m + 1, j);

            return MergeStringPrefix(left, right);
        }

        private string MergeStringPrefix(string left, string right)
        {
            int len = 0;
            while (len < left.Length && len < right.Length)
            {
                if (left[len] == right[len])
                {
                    len++;
                }
                else
                {
                    break;
                }
            }

            return left.Substring(0, len);
        }

        private string GetMergedString(string[] strs, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return strs[startIndex];
            }

            int m = startIndex + (endIndex - startIndex) / 2;

            string left = GetMergedString(strs, startIndex, m);
            string right = GetMergedString(strs, m + 1, endIndex);

            return MergeStringPrefix(left, right);
        }
    }
}
