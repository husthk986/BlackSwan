using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Medium1
{
    class _388LongestFilePath : ILeetcode
    {
        private const int mInf = int.MaxValue;
        public void DoIt()
        {
            string s = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
            Console.WriteLine("Should be 20: " + LengthLongestPath(s));
        }

        public int LengthLongestPath(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            string[] inputs = input.Split('\n');

            Dictionary<int, int> levels = new Dictionary<int, int>();
            int ans = 0;
            levels.Add(0, 0);
            foreach (string line in inputs)
            {
                int level = line.LastIndexOf('\t') + 1;
                int len = line.Substring(level).Length;
                if (line.Contains("."))
                {
                    ans = Math.Max(ans, levels[level] + len);
                }
                else
                {
                    if (!levels.ContainsKey(level + 1))
                    {
                        levels.Add(level + 1, 0);
                    }

                    levels[level + 1] = levels[level] + len + 1;
                }
            }

            return ans;
        }
    }
}
