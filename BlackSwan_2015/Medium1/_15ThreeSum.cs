using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    internal class _15ThreeSum : ILeetcode
    {
        public void DoIt()
        {
            int[] input = { -1, 0, 1, 2, -1, -4 };
            foreach (IList<int> ints in ThreeSum(input))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");

                }
                Console.WriteLine();
            }

            input = new[] { 0, 0, 0, 0 };
            foreach (IList<int> ints in ThreeSum(input))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");

                }
                Console.WriteLine();
            }

            input = new[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            foreach (IList<int> ints in ThreeSum(input))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");

                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (nums.Length < 3) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int sum = 0 - nums[i];

                int lo = i + 1, hi = nums.Length - 1;

                while (lo < hi)
                {
                    if (nums[lo] + nums[hi] == sum)
                    {
                        IList<int> subResult = new List<int>();
                        subResult.Add(nums[i]);
                        subResult.Add(nums[lo]);
                        subResult.Add(nums[hi]);
                        result.Add(subResult);
                        lo++;
                        hi--;
                        while (nums[lo] == nums[lo - 1] && lo < hi)
                        {
                            lo++;
                        }
                        while (nums[hi] == nums[hi + 1] && lo < hi)
                        {
                            hi--;
                        }
                    }
                    else if (nums[lo] + nums[hi] < sum)
                    {
                        lo++;
                    }
                    else if (nums[lo] + nums[hi] > sum)
                    {
                        hi--;
                    }
                }
            }

            return result;
        }
    }
}
