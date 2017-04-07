using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _395LongestSubLeastKRepeating : ILeetcode
    {
        public void DoIt()
        {
            string s = "ababbc";
            int k = 2;
            Console.WriteLine("Should be 1: " + LongestSubstring(s, k));
        }

        public int LongestSubstring(string s, int k)
        {
            if (string.IsNullOrEmpty(s) || k > s.Length) return 0;

            int left = 0, ans = 0;
            for (; left <= s.Length - k; left++)
            {
                int[] letters = new int[26];
                int right = left, maxRight = left;
                int mask = 0;
                while (right < s.Length)
                {
                    int index = s[right] - 'a';
                    letters[index]++;
                    if (letters[index] >= k)
                    {
                        mask &= ~(1 << index);
                    }
                    else
                    {
                        mask |= (1 << index);
                    }

                    if (mask == 0)
                    {
                        ans = Math.Max(ans, right - left + 1);
                        maxRight = right;
                    }
                    right++;
                }
                left = maxRight;
            }


            return ans;
        }
    }
}
