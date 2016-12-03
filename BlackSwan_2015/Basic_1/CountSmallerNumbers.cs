using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class CountSmallerNumbers
    {
        public void DoIt()
        {
            int[] nums = { 5, 2, 6, 1 };
            IList<int> result = CountSmaller(nums);

            Console.WriteLine("Result should be 2,1,1,0");
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }

        public IList<int> CountSmaller(int[] nums)
        {
            if (nums == null || nums.Count() <= 1)
            {
                return new[] { 0 };
            }

            Tuple[] tuples = new Tuple[nums.Count()];
            for (int i = 0; i < nums.Count(); i++)
            {
                tuples[i] = new Tuple() { Index = i, Value = nums[i] };
            }

            int[] ans = new int[nums.Count()];

            MergeAndCount(tuples, ans, 0, nums.Count() - 1);

            return ans;
        }

        private Tuple[] MergeAndCount(Tuple[] tuples, int[] ans, int start, int end)
        {
            if (start >= end)
            {
                return new Tuple[] { tuples[start] };
            }

            Tuple[] subTuple = new Tuple[end - start + 1];

            int m = start + (end - start) / 2;

            Tuple[] lefTuples = MergeAndCount(tuples, ans, start, m);
            Tuple[] rightTuples = MergeAndCount(tuples, ans, m + 1, end);

            int l = 0, r = 0;
            for (int i = 0; i <= end - start; i++)
            {
                if (r >= rightTuples.Count())
                {
                    subTuple[i] = lefTuples[l++];
                    continue;
                }

                if (l >= lefTuples.Count())
                {
                    subTuple[i] = rightTuples[r++];
                    continue;
                }

                if (r < rightTuples.Count() && lefTuples[l].Value > rightTuples[r].Value)
                {
                    subTuple[i] = rightTuples[r];
                    int t = l;
                    while (t < lefTuples.Count())
                    {
                        ans[lefTuples[t++].Index]++;
                    }
                    r++;
                }
                else if (l < lefTuples.Count())
                {
                    subTuple[i] = lefTuples[l++];
                }
            }

            for (int i = 0; i < subTuple.Count(); i++)
            {
                tuples[start++] = subTuple[i];
            }

            return subTuple;
        }

        private class Tuple
        {
            public int Index { get; set; }
            public int Value { get; set; }
        }
    }
}
