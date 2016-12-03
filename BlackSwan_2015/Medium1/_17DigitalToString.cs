using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _17DigitalToString : ILeetcode
    {
        public void DoIt()
        {
            string s = "203";

            foreach (string t in LetterCombinations(s))
            {
                Console.WriteLine(t + ",");
            }
        }

        private Dictionary<char, string> mDashboard = new Dictionary<char, string>()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();

            List<string> result = new List<string>();

            char digit = digits[0];
            if (mDashboard.ContainsKey(digit))
            {
                foreach (char c in mDashboard[digit])
                {
                    if (digits.Length > 1)
                    {
                        foreach (string s in LetterCombinations(digits.Substring(1)))
                        {
                            result.Add(c + s);
                        }
                    }
                    else
                    {
                        result.Add(c.ToString());
                    }
                }
            }
            else // in case 0 and 1
            {
                if (digits.Length > 1)
                    return LetterCombinations(digits.Substring(1));
            }

            return result;
        }
    }
}
