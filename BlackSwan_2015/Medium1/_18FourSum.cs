using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _18FourSum : ILeetcode
    {
        public void DoIt()
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            foreach (IList<int> ints in FourSum(nums, target))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

            nums = new[] { -1, 0, -5, -2, -2, -4, 0, 1, -2 };
            target = -9;
            foreach (IList<int> ints in FourSum(nums, target))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

            nums = new[] { -3, -2, -1, 0, 0, 1, 2, 3 };
            target = 0;
            foreach (IList<int> ints in FourSum(nums, target))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

            nums = new[] { 0, 0, 0, 0 };
            target = 0;
            foreach (IList<int> ints in FourSum(nums, target))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

            nums = new[] { -1, -5, -5, -3, 2, 5, 0, 4 };
            target = -7;
            foreach (IList<int> ints in FourSum(nums, target))
            {
                foreach (int i in ints)
                {
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }

            
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (nums.Length < 4) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;

                    int lo = j + 1, hi = nums.Length - 1;
                    while (lo < hi)
                    {
                        if (nums[i] + nums[j] + nums[lo] + nums[hi] == target)
                        {
                            List<int> subResult = new List<int>();
                            subResult.Add(nums[i]);
                            subResult.Add(nums[j]);
                            subResult.Add(nums[lo]);
                            subResult.Add(nums[hi]);
                            result.Add(subResult);
                            lo++;
                            hi--;
                            while (lo < hi && nums[lo - 1] == nums[lo])
                            {
                                lo++;
                            }
                            while (lo < hi && nums[hi] == nums[hi + 1])
                            {
                                hi--;
                            }
                        }
                        if (lo < hi && nums[i] + nums[j] + nums[lo] + nums[hi] < target)
                        {
                            lo++;
                        }
                        if (lo < hi && nums[i] + nums[j] + nums[lo] + nums[hi] > target)
                        {
                            hi--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
