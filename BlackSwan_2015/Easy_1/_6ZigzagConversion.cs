using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    internal class _6ZigzagConversion : ILeetcode
    {
        public void DoIt()
        {
            string s = "PAYPALISHIRING";
            int rows = 3;
            Console.WriteLine("Should be PAHNAPLSIIGYIR: " + Convert(s, rows));

            s = "0123456789";
            rows = 4;
            Console.WriteLine("Should be 0615724839: " + Convert(s, rows));

            s = "AB";
            rows = 1;
            Console.WriteLine("Should be AB: " + Convert(s, rows));

            s = "ABC";
            rows = 2;
            Console.WriteLine("Should be ACB: " + Convert(s, rows));

            s = "ABCD";
            rows = 2;
            Console.WriteLine("Should be ACBD: " + Convert(s, rows));

            s = "ABCD";
            rows = 3;
            Console.WriteLine("Should be ABDC: " + Convert(s, rows));

            s = "ABCDE";
            rows = 4;
            Console.WriteLine("Should be ABCED: " + Convert(s, rows));

            s = "ABCDEF";
            rows = 2;
            Console.WriteLine("Should be ACEBDF: " + Convert(s, rows));

            s = "ABCDEF";
            rows = 4;
            Console.WriteLine("Should be ABFCED: " + Convert(s, rows));
        }

        public string Convert(string s, int numRows)
        {
            StringBuilder sb = new StringBuilder();

            if (numRows == 0) return string.Empty;
            if (numRows == 1) return s;

            for (int row = 0; row < numRows; row++)
            {
                for (int gap = 0; (row + gap) < s.Length; gap += 2*numRows - 2)
                {
                    sb.Append(s[row + gap]);

                    if (row != 0 && row != numRows - 1 && gap + 2*numRows - 2 - row < s.Length)
                    {
                        sb.Append(s[gap + 2*numRows - 2 - row]);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
