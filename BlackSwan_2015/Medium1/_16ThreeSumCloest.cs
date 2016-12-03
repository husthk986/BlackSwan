using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _16ThreeSumCloest : ILeetcode
    {
        public void DoIt()
        {
            int[] input = { 1, 2, -4, -1 };
            int target = 1;
            Console.WriteLine("Should be 2: " + ThreeSumClosest(input, target));

            input = new[] { 0, 1, 1, 1 };
            target = -100;
            Console.WriteLine("Should be 2: " + ThreeSumClosest(input, target));

            input = new[] { -3, 0, 1, 2 };
            target = 1;
            Console.WriteLine("Should be 0: " + ThreeSumClosest(input, target));
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length < 3) return -1;
            Array.Sort(nums);

            int ans = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int lo = i + 1, hi = nums.Length - 1;

                while (lo < hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];

                    if (Math.Abs(ans - target) > Math.Abs(sum - target))
                    {
                        ans = sum;
                        if (ans == target) return ans;
                    }

                    if (sum > target)
                        hi--;
                    else 
                        lo++;
                }
            }

            return ans;
        }

        public int ThreeSumClosest1(int[] nums, int target)
        {
            if (nums.Length < 3) return -1;
            Array.Sort(nums);

            int result = Math.Abs(nums[0] + nums[1] + nums[2] - target);
            int preSum = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int lo = i + 1, hi = nums.Length - 1;

                while (lo < hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];

                    if (result > Math.Abs(sum - target))
                    {
                        result = Math.Abs(sum - target);

                        if (sum > preSum)
                            lo++;
                        else
                            hi--;

                        preSum = sum;

                    }
                    else if (Math.Abs(sum - target) >= result && sum >= preSum)
                    {
                        hi--;
                    }
                    else if (Math.Abs(sum - target) >= result && sum < preSum)
                    {
                        lo++;
                    }
                }
            }

            return preSum;
        }
    }
}
