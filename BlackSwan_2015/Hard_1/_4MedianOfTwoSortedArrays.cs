using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _4MedianOfTwoSortedArrays : ILeetCode
    {
        public void DoIt()
        {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };
            Console.WriteLine("The result should be 2.0: " + FindMedianSortedArrays(nums1, nums2));

            nums1 = new[] { 1, 2 };
            nums2 = new[] { 3, 4 };
            Console.WriteLine("The result should be 2.5: " + FindMedianSortedArrays(nums1, nums2));

            nums1 = new[] { 1, 2, 3 };
            nums2 = new[] { 4 };
            Console.WriteLine("The result should be 2.5: " + FindMedianSortedArrays(nums1, nums2));

            nums1 = new[] { 1001 };
            nums2 = new[] { 1000 };
            Console.WriteLine("The result should be 1000.5000: " + FindMedianSortedArrays(nums1, nums2));

        }

        /// <summary>
        /// The overall run time complexity should be O(log (m+n)).
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            if (m > n)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int aStart = 0, aEnd = m;
            int aMiddle = 0, bMiddle = 0;
            int max_left = 0, min_right = 0;

            while (aStart <= aEnd)
            {
                aMiddle = (aStart + aEnd) / 2;
                bMiddle = (m + n + 1) / 2 - aMiddle;

                if (aMiddle < m && bMiddle > 0 && nums2[bMiddle - 1] > nums1[aMiddle])
                {
                    aStart = aMiddle + 1;
                }
                else if (aMiddle > 0 && bMiddle < n && nums1[aMiddle - 1] > nums2[bMiddle])
                {
                    aEnd = aMiddle - 1;
                }
                else
                {
                    if (aMiddle == 0)
                        max_left = nums2[bMiddle - 1];
                    else if (bMiddle == 0)
                        max_left = nums1[aMiddle - 1];
                    else
                        max_left = Math.Max(nums1[aMiddle - 1], nums2[bMiddle - 1]);

                    break;
                    
                }
            }

            if ((m + n) % 2 != 0)
                return max_left;

            if (aMiddle == m) min_right = nums2[bMiddle];
            else if (bMiddle == n) min_right = nums1[aMiddle];
            else min_right = Math.Min(nums1[aMiddle], nums2[bMiddle]);

            return (max_left + min_right) / 2.0;
        }
    }
}
