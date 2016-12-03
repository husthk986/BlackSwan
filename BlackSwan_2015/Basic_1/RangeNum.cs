using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    internal class RangeNum
    {
        public void DoIt()
        {
            int[] nums = { -2, 5, -1, 2, 1 };

            Console.WriteLine("Should be 7, actual: " + CountRangeSum3(nums, -2, 2));
        }

        public int CountRangeSum3(int[] nums, int lower, int upper)
        {
            if (nums == null || nums.Count() == 0 || lower > upper)
            {
                return 0;
            }

            long[] sums = new long[nums.Count()];
            sums[0] = nums[0];
            for (int i = 1; i < sums.Count(); i++)
            {
                sums[i] = sums[i - 1] + nums[i];
            }

            return CountRangeWithMergeSort(sums, 0, sums.Count() - 1, lower, upper);
        }

        private int CountRangeWithMergeSort(long[] sums, int start, int end, int lower, int upper)
        {
            if (start >= end) // base case
            {
                return sums[start] >= lower && sums[start] <= upper ? 1 : 0;
            }

            int m = start + (end - start) / 2;
            int count = CountRangeWithMergeSort(sums, start, m, lower, upper) +
                        CountRangeWithMergeSort(sums, m + 1, end, lower, upper);

            long[] tempArray = new long[end - start + 1];

            int a = m + 1, b = m + 1, c = m + 1;
            int r = 0;
            for (int i = start; i <= m; i++)
            {
                while (a <= end && sums[a] - sums[i] < lower)
                {
                    a++;
                }

                while (b <= end && sums[b] - sums[i] <= upper)
                {
                    b++;
                }

                count += b - a;

                while (c <= end && sums[c] <= sums[i])
                {
                    tempArray[r++] = sums[c++];
                }
                tempArray[r++] = sums[i];
            }

            for (int x = 0; x < r;x++)
            {
                sums[start++] = tempArray[x];
            }

            return count;
        }

        public int CountRangeSum2(int[] nums, int lower, int upper)
        {
            if (nums == null || nums.Count() == 0 || lower > upper)
            {
                return 0;
            }

            return DivideAndConqueSolutuion(nums, 0, nums.Count() - 1, lower, upper);
        }

        private int DivideAndConqueSolutuion(int[] nums, int leftIndex, int rightIndex, int lower, int upper)
        {
            if (leftIndex >= rightIndex) // basic case
            {
                return nums[leftIndex] >= lower && nums[leftIndex] <= upper ? 1 : 0;
            }

            int m = leftIndex + (rightIndex - leftIndex) / 2; //middle index
            int sum = 0;
            int[] arr = new int[rightIndex - m];
            for (int i = 0; i < rightIndex - m; i++)
            {
                sum += nums[m + 1 + i];
                arr[i] = sum;
            }

            Array.Sort(arr);
            int count = 0;
            for (int i = leftIndex; i <= m; i++)
            {
                count += FindIndexValue(arr, upper - nums[i]) - FindIndexValue(arr, lower - nums[i]);
            }

            return DivideAndConqueSolutuion(nums, leftIndex, m, lower, upper) +
                   DivideAndConqueSolutuion(nums, m + 1, rightIndex, lower, upper) + count;
        }

        private int FindIndexValue(int[] arr, int value)
        {
            int l = 0, r = arr.Count() - 1, m = 0;
            while (l <= r)
            {
                m = l + (r - l) / 2;

                if (arr[m] == value)
                {
                    return m;
                }

                if (arr[l] < value) l++;
                if (arr[r] > value) r--;
            }

            return l;
        }


        public int CountRangeSum1(int[] nums, int lower, int upper)
        {
            int n = nums.Count();
            long[] sums = new long[n + 1];
            for (int i = 0; i < n; ++i)
                sums[i + 1] = sums[i] + nums[i];

            int ans = 0;

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j <= n; ++j)
                {
                    if (sums[j] - sums[i] >= lower && sums[j] - sums[i] <= upper)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            if (nums.Count() < 1) return 0;

            BST aBst = CreateBstFromArray(nums, 0);

            int rangeNum = CalculateRangeNum(aBst, 0, lower, upper);

            return rangeNum;
        }



        private int CalculateRangeNum(BST aBst, int pre, int lower, int upper)
        {
            int coun = 0;

            if (aBst == null)
            {
                return coun;
            }

            if (aBst.Value < lower)
            {
                coun += CalculateRangeNum(aBst.Right, aBst.Value, lower, upper);
            }
            else if (aBst.Value > upper)
            {
                coun += CalculateRangeNum(aBst.Left, aBst.Value, lower, upper);
            }
            else if (aBst.Value >= lower && aBst.Value <= upper)
            {
                coun++;
                coun += CalculateRangeNum(aBst.Right, aBst.Value, lower, upper);
                coun += CalculateRangeNum(aBst.Left, aBst.Value, lower, upper);
            }

            if (pre != 0)
            {
                if (pre + aBst.Value < lower)
                {
                    coun += CalculateRangeNum(aBst.Right, aBst.Value, lower, upper);
                }
                else if (pre + aBst.Value > upper)
                {
                    coun += CalculateRangeNum(aBst.Left, aBst.Value, lower, upper);
                }
                else if (pre + aBst.Value >= lower && pre + aBst.Value <= upper)
                {
                    coun++;
                    coun += CalculateRangeNum(aBst.Right, aBst.Value, lower, upper);
                    coun += CalculateRangeNum(aBst.Left, aBst.Value, lower, upper);
                }
            }

            return coun;
        }



        private BST CreateBstFromArray(int[] nums, int startIndex)
        {
            BST bst = new BST();
            bst.Value = nums[startIndex];

            if (startIndex >= nums.Count() - 1)
            {
                return bst;
            }

            if (bst.Value < nums[startIndex + 1])
            {
                bst.Right = CreateBstFromArray(nums, startIndex + 1);
            }
            else
            {
                bst.Left = CreateBstFromArray(nums, startIndex + 1);
            }

            return bst;
        }

        private class BST
        {
            public int Value { get; set; }
            public BST Left { get; set; }
            public BST Right { get; set; }

        }
    }
}
