using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _10RegularExpression : ILeetCode
    {
        public void DoIt()
        {
            string s = "abcd", p = "d*";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aa";
            p = "a";
            Console.WriteLine("Should be False: " + IsMatch(s, p));

            s = "a";
            p = "ab*a";
            Console.WriteLine("Should be False: " + IsMatch(s, p));

            s = "ab";
            p = ".*c";
            Console.WriteLine("Should be False: " + IsMatch(s, p));

            s = "aaa";
            p = "aaaa";
            Console.WriteLine("Should be False: " + IsMatch(s, p));

            s = "aaa";
            p = "aa";
            Console.WriteLine("Should be False: " + IsMatch(s, p));

            s = "aaa";
            p = "a*a";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aa";
            p = "a*";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aa";
            p = "aa";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aa";
            p = "aa";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aa";
            p = ".*";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "ab";
            p = ".*";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aab";
            p = "c*a*b";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "acb";
            p = "a.b";
            Console.WriteLine("Should be True: " + IsMatch(s, p));

            s = "aaaaab";
            p = "a*b";
            Console.WriteLine("Should be True: " + IsMatch(s, p));
        }

        public bool IsMatch(string s, string p)
        {
            int m = s.Length + 1, n = p.Length + 1;

            bool[,] f = new bool[m, n]; //

            f[0, 0] = true; //Empyt string vs empty pattern
            for (int i = 1; i < m; i++)
            {
                f[i, 0] = false;//Non-empty string vs empty pattern
            }

            for (int i = 1; i < n; i++) //Empty string vs non-empty patter, like a*b*c*
            {
                if (i > 1 && p[i - 1] == '*')
                {
                    f[0, i] = f[0, i - 2];
                }
                else
                {
                    f[0, i] = false;
                }
            }

            for (int i = 1; i < m; i++) //Each row: c in string
            {
                for (int j = 1; j < n; j++) //Each column: c in pattern
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        f[i, j] = f[i - 1, j - 1]; //Same character, see diag
                    }
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        f[i, j] = f[i, j - 2] || //*, two cases, 0 matches like ac vs ab*c or 
                                  (f[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.')); //more matches abc vs ab*c
                    }
                    else
                    {
                        f[i, j] = false;
                    }
                }
            }

            return f[m - 1, n - 1];
        }


        public bool IsMatch_Recursive(string s, string p)
        {
            //Support "." and "*", "." means match any single size character, "*" means matching 0 or more of preceding character
            if (string.IsNullOrEmpty(p)) return string.IsNullOrEmpty(s);

            if (p.Length > 1 && p[1] == '*')
            {
                return (IsMatch(s, p.Substring(2))) ||
                       (!string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.') && IsMatch(s.Substring(1), p)) ||
                       (!string.IsNullOrEmpty(s) && (s[0] != p[0] && p[0] != '.') && IsMatch(s, p.Substring(2)));
            }
            else
            {
                return (!string.IsNullOrEmpty(s)) &&
                    ((s[0] == p[0]) || (p[0] == '.')) &&
                    IsMatch(s.Substring(1), p.Substring(1));
            }
        }
    }
}
