using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class ReverseStrings
    {
        internal void DoIt()
        {
            string s = "leetcode";
            //s = " ";
            //Console.WriteLine(ReverseVowels(s));
            Console.WriteLine(ReverseString(s));
        }

        public string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            char[] ss = s.ToCharArray();

            int i = 0, j = ss.Count() - 1;

            while (i <= j)
            {
                char temp = ss[j];
                ss[j] = ss[i];
                ss[i] = temp;

                i++;
                j--;
            }

            return new string(ss);
        }

        public string ReverseVowels(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            char[] vowels = { 'a', 'e', 'i', 'u', 'o', 'A', 'E', 'I', 'O', 'U' };

            char[] ss = s.ToCharArray();

            int i = 0, j = ss.Count() - 1;

            while (i <= j)
            {
                while (j > 0 && !vowels.Contains(ss[j])) j--;
                while (i < ss.Count() - 1 && !vowels.Contains(ss[i])) i++;

                if (i > j) break;

                char temp = ss[j];
                ss[j] = ss[i];
                ss[i] = temp;

                i++;
                j--;
            }

            return new string(ss);
        }

        public string ReverseVowels1(string s)
        {
            char[] vowels = { 'a', 'e', 'i', 'u', 'o', 'A', 'E', 'I', 'O', 'U' };
            Stack<char> vowStack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    vowStack.Push(s[i]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!vowels.Contains(s[i]))
                {
                    sb.Append(s[i]);
                }
                else
                {
                    sb.Append(vowStack.Pop());
                }
            }

            return sb.ToString();
        }
    }
}
