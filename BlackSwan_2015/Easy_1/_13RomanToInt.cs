using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _13RomanToInt : ILeetcode
    {
        public void DoIt()
        {
            string num = "V";
            Console.WriteLine("Should be 5: " + RomanToInt(num));

            num = "CCCLIII";
            Console.WriteLine("Should be 353: " + RomanToInt(num));

            num = "CMXXVII";
            Console.WriteLine("Should be 927: " + RomanToInt(num));

            num = "MMCDXX";
            Console.WriteLine("Should be 2420: " + RomanToInt(num));

            num = "MDCCCLXXXIV";
            Console.WriteLine("Should be 1884: " + RomanToInt(num));

        }
        
        public int RomanToInt(string s)
        {
            Dictionary<string, int> romanDictionary = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000}
            };

            int num = 0;
            while (!string.IsNullOrEmpty(s))
            {
                if (s.Length >= 2 && romanDictionary.ContainsKey(s.Substring(0, 2)))
                {
                    num += romanDictionary[s.Substring(0, 2)];
                    s = s.Substring(2);
                }
                else
                {
                    num += romanDictionary[s.Substring(0, 1)];
                    s = s.Substring(1);
                }
            }

            return num;

        }
    }
}
