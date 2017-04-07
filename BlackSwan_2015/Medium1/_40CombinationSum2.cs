using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _40CombinationSum2:ILeetcode
    {
        public void DoIt()
        {
            int[] nums = {10, 1, 2, 7, 6, 1, 5};
            int num = 8;

            foreach (var list in CombinationSum2(nums, num))
            {
                foreach (int i in list)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);
            FindCombination(candidates, 0, target, ans, null);
            return ans;
        }

        private void FindCombination(int[] candidates, int startIndex, int target, IList<IList<int>> ans, IList<int> currentList)
        {
            if (target == 0)
            {
                if (currentList != null)
                {
                    ans.Add(new List<int>(currentList));
                }
                return;
            }
            if (target < 0 || startIndex >= candidates.Length)
            {
                return;
            }

            int pre = -1;
            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] != pre)
                {
                    List<int> ls = new List<int>();
                    if (currentList != null)
                    {
                        ls.AddRange(currentList);
                    }
                    ls.Add(candidates[i]);
                    FindCombination(candidates, i + 1, target - candidates[i], ans, ls);
                    ls.RemoveAt(ls.Count() - 1);
                    pre = candidates[i];
                }
            }
        }
    }
}
