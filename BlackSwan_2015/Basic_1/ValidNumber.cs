using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class ValidNumber
    {
        public void DoIt()
        {
            string[] testString = { "0", " 0.1 ", "abc", "1 a", "2e10", "2.e5", "-5.8e10", "8.e" }; //true, true, false, false, true
            foreach (string s in testString)
            {
                Console.WriteLine("string \"{0}\" is {1}", s, IsValidNumber(s));
            }
        }

        private object IsValidNumber(string s)
        {
            return false;
        }
    }
}
