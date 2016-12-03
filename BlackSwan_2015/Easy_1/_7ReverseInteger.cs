using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _7ReverseInteger : ILeetcode
    {
        public void DoIt()
        {
            int i = 1;
            Console.WriteLine("Shoulde 1: " + Reverse(i));

            i = -1563847412;
            Console.WriteLine("Shoulde 0: " + Reverse(i));

            i = 563847412;
            Console.WriteLine("Shoulde 214748365: " + Reverse(i));

            i = -2147483412;
            Console.WriteLine("Shoulde -2143847412: " + Reverse(i));

            i = 123;
            Console.WriteLine("Shoulde 321: " + Reverse(i));

            i = -123;
            Console.WriteLine("Shoulde -321: " + Reverse(i));

            i = -2147483648;
            Console.WriteLine("Shoulde 0: " + Reverse(i));

            i = 1534236469;
            Console.WriteLine("Shoulde 0: " + Reverse(i));

        }

        public int Reverse(int x)
        {
            if (x < 0 && 0 - x < 0)
                return 0;

            Queue<int> iStack = new Queue<int>();

            bool minus = x < 0;
            x = minus ? 0 - x : x;
            while (x > 0)
            {
                iStack.Enqueue(x % 10);
                x = x / 10;
            }

            int result = 0;
            while (iStack.Count() > 0)
            {
                if (result > int.MaxValue / 10)
                    return 0;

                result = result * 10 + iStack.Dequeue();
            }

            if (minus)
                return 0 - result;

            return result;
        }

        public int Reverse1(int x)
        {
            if (x < 0 && 0 - x < 0)
                return 0;

            if (x < 0)
            {
                return 0 - Reverse(0 - x);
            }

            int result = 0;
            while (x > 0)
            {
                result = result * 10 + x % 10;
                x = x / 10;

                if (result > int.MaxValue / 10)
                    return 0;

            }

            return result;
        }
    }
}
