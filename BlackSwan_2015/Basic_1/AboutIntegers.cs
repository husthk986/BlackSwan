using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class AboutIntegers
    {
        internal void DoIt()
        {
            int n = 10;
            Console.WriteLine(IntegerBreak(n));
        }

        public int IntegerBreak(int n)
        {
            int threes = n/3;
            int remain = n - threes;
            return threes*3 + remain;

        }
    }
}
