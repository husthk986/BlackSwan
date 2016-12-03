using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _8StringToInteger : ILeetcode
    {
        public void DoIt()
        {
            string s = "123";
            Console.WriteLine("Should be 123: " + MyAtoi(s));

            s = "-123";
            Console.WriteLine("Should be -123: " + MyAtoi(s));

            s = "abc";
            Console.WriteLine("Should be 0: " + MyAtoi(s));

            s = "2147483648";
            Console.WriteLine("Should be 2147483647: " + MyAtoi(s));

            s = "-2147483648";
            Console.WriteLine("Should be -2147483648: " + MyAtoi(s));

        }

        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            str = str.Trim();
            Queue<int> iStack = new Queue<int>();

            bool minus = str[0] == '-';
            int i = minus || str[0] == '+' ? 1 : 0;

            if (minus && str.Length == 1)
            {
                return 0;
            }

            for (; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    iStack.Enqueue(str[i]);
                }
                else
                {
                    return 0;
                }
            }

            int result = 0;
            while (iStack.Count() > 0)
            {
                int currentNumber = iStack.Dequeue() - '0';

                if (result > int.MaxValue/10 || int.MaxValue - result*10 < currentNumber)
                {
                    return minus ? int.MinValue : int.MaxValue;
                }

                result = result * 10 + currentNumber;
            }

            if (minus)
                return 0 - result;

            return result;
        }
    }
}
