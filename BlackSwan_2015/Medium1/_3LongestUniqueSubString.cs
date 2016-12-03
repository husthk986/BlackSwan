using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _3LongestUniqueSubString : ILeetcode
    {
        public void DoIt()
        {
            Console.WriteLine("c: should be 1, actual " + LengthOfLongestSubstring("c"));
            Console.WriteLine("au: should be 2, actual " + LengthOfLongestSubstring("au"));
            Console.WriteLine("abcabcbb: should be 3, actual " + LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine("bbbbb: should be 1, actual " + LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine("pwwkew: should be 3, actual " + LengthOfLongestSubstring("pwwkew"));
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            char[] sArrays = s.ToCharArray();

            int backPointer = 0;
            int result = 0;
            HashSet<char> hs = new HashSet<char>();

            for (int frontPointer = 0; frontPointer < s.Length; )
            {
                while (frontPointer < s.Length && !hs.Contains(sArrays[frontPointer]))
                {
                    hs.Add(sArrays[frontPointer++]);
                }

                result = Math.Max(result, frontPointer - backPointer);
                while (frontPointer < s.Length && sArrays[backPointer] != sArrays[frontPointer])
                {
                    hs.Remove(sArrays[backPointer++]);
                }

                if (backPointer <= frontPointer && backPointer < s.Length)
                {
                    hs.Remove(sArrays[backPointer++]);
                }
            }

            return result;
        }
    }
}
