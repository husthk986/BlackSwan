using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _9PalindromeNumber : ILeetcode
    {
        public void DoIt()
        {
            int i = -1;
            //Console.WriteLine(i + " Should be true: " + IsPalindrome(i));

            i = -2147483648;
            //Console.WriteLine(i + " Should be false: " + IsPalindrome(i));

            i = -2147447412;
            Console.WriteLine(i + " Should be false: " + IsPalindrome(i));


            i = 123;
            Console.WriteLine(i + " Should be false: " + IsPalindrome(i));

            i = 12321;
            Console.WriteLine(i + " Should be true: " + IsPalindrome(i));

            i = 123321;
            Console.WriteLine(i + " Should be true: " + IsPalindrome(i));
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || x >= int.MaxValue) return false;
            int temp = x;
            int result = 0;

            while (x != 0)
            {
                result = result * 10 + x % 10;
                x /= 10;
            }

            return result == temp;
        }
    }
}
