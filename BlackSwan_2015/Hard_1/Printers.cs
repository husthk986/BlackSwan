using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    public class Printers
    {
        public static void PrintListList(IList<IList<string>> result)
        {
            foreach (IList<string> list in result)
            {
                foreach (string s in list)
                {
                    Console.Write(s + ",");
                }
                Console.WriteLine();
            }
        }
    }
}
