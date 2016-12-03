using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _12IntegerToRoman : ILeetcode
    {
        public void DoIt()
        {
            int num = 5;
            Console.WriteLine("Should be V: " + IntToRoman(num));

            num = 353;
            Console.WriteLine("Should be CCCLIII: " + IntToRoman(num));

            num = 927;
            Console.WriteLine("Should be CMXXVII: " + IntToRoman(num));

            num = 2420;
            Console.WriteLine("Should be MMCDXX: " + IntToRoman(num));
        }

        public string IntToRoman(int num)
        {
            string[] M = { "", "M", "MM", "MMM" };
            string[] C = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] X = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] I = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        public string IntToRoman1(int num)
        {
            //
            string thousand = GetStringForSuchNumber(num / 1000, "M", "", "");
            num = num - num / 1000 * 1000;

            string hundred = GetStringForSuchNumber(num / 100, "C", "D", "M");
            num = num - num / 100 * 100;

            string ten = GetStringForSuchNumber(num / 10, "X", "L", "C");
            num = num - num / 10 * 10;

            string digital = GetStringForSuchNumber(num, "I", "V", "X");

            return thousand + hundred + ten + digital;

        }

        private string GetStringForSuchNumber(int num, string symbolOne, string symbolFive, string symbolTen)
        {
            StringBuilder sb = new StringBuilder();
            if (num <= 3)
            {
                for (int i = 0; i < num; i++)
                {
                    sb.Append(symbolOne);
                }
            }
            else if (num == 4)
            {
                sb.Append(symbolOne);
                sb.Append(symbolFive);
            }
            else if (num > 4 && num < 9)
            {
                sb.Append(symbolFive);
                for (int i = 0; i < num - 5; i++)
                {
                    sb.Append(symbolOne);
                }
            }
            else
            {
                sb.Append(symbolOne);
                sb.Append(symbolTen);
            }


            return sb.ToString();

        }
    }
}
