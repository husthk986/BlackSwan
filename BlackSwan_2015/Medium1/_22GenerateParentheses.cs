using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _22GenerateParentheses : ILeetcode
    {
        public void DoIt()
        {
            int n = 3;
            foreach (string s in GenerateParenthesis(n))
            {
                Console.WriteLine(s);
            }
        }

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            GenerateParenthesis("", n, n, result);

            return result;
        }

        private void GenerateParenthesis(string subResult, int nLeft, int nRight, List<string> result)
        {
            if (nLeft < 0 || nRight < 0)
                return;

            if (nLeft == 0 && nRight == 0)
            {
                result.Add(subResult);
                return;
            }

            GenerateParenthesis(subResult + "(", nLeft - 1, nRight, result);
            if (nLeft < nRight)
            {
                GenerateParenthesis(subResult + ")", nLeft, nRight - 1, result);
            }
        }
    }
}
