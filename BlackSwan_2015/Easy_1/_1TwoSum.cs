using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _1TwoSum : ILeetcode
    {
        public void DoIt()
        {
            //int[] nums = {2,7,11,15};
            int[] nums = { 3, 2, 4 };

            int target = 6;

            foreach (var i in TwoSum(nums, target))
            {
                Console.WriteLine(i);
            }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new[] { dict[target - nums[i]], i };
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }


            }

            return new int[] { };
        }
    }
}
