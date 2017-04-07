using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _174DungeonGame : ILeetCode
    {
        public void DoIt()
        {
            int[,] dungeon =
            {
                {-2, -3, 3}, 
                {-5, -10, 1}, 
                {10, 30, -5}
            };

            Console.WriteLine(CalculateMinimumHP(dungeon));
        }

        /// <summary>
        /// The overall run time complexity should be O(log (m+n)).
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int CalculateMinimumHP(int[,] dungeon)
        {
            int m = dungeon.GetLength(0);
            int n = dungeon.GetLength(1);

            int[,] dp = new int[m + 1, n + 1];
            for (int i = m; i >= 0; i--)
            {
                for (int j = n; j >= 0; j--)
                {
                    dp[i, j] = int.MaxValue;
                }
            }
            dp[m, n - 1] = 1;
            dp[m - 1, n] = 1;

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    int need = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i, j];
                    dp[i, j] = need <= 0 ? 1 : need;
                }
            }

            return dp[0, 0];
        }
    }
}
