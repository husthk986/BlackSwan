using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    internal class ArrayIntersection
    {
        internal void DoIt()
        {
            int[] nums1 = {1, 2, 2, 1};
            int[] nums2 = {2, 2};
            //int[] nums1 = { 1, 2, 2, 1 };
            //int[] nums2 = { 2 };
            //int[] nums1 = { 2, 1 };
            //int[] nums2 = { 1, 2 };

            int[] inter = Intersect2(nums1, nums2);

            Console.WriteLine(string.Join(",", inter));

        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1.Count() < nums2.Count())
            {
                return Intersection(nums2, nums1);
            }

            HashSet<int> hs = new HashSet<int>();
            foreach (var i in nums2)
            {
                hs.Add(i);
            }

            List<int> ls = new List<int>();
            foreach (var j in nums1)
            {
                if (hs.Contains(j))
                {
                    ls.Add(j);
                    hs.Remove(j);
                }
            }

            return ls.ToArray();
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            //Solution can be:(this one is slower than below)
            //var map1 = nums1.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
            //return nums2.Where(n => map1.ContainsKey(n) && map1[n]-- > 0).ToArray();
            //Or:


            Dictionary<int, int> numbCount=new Dictionary<int, int>();
            foreach (int i in nums1)
            {
                if (!numbCount.ContainsKey(i))
                {
                    numbCount.Add(i,0);
                }
                numbCount[i]++;
            }

            List<int> ls = new List<int>();
            foreach (int j in nums2)
            {
                if (numbCount.ContainsKey(j) && numbCount[j] > 0)
                {
                    ls.Add(j);
                    numbCount[j]--;
                }
            }

            return ls.ToArray();
        }

        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int index1 = 0, index2 = 0;

            List<int> ls = new List<int>();
            while (index1<nums1.Count() && index2<nums2.Count())
            {
                if (nums1[index1] == nums2[index2])
                {
                    ls.Add(nums1[index1]);
                    index1++;
                    index2++;
                }
                else if (nums1[index1] < nums2[index2])
                {
                    index1++;
                }
                else if (nums1[index1] > nums2[index2])
                {
                    index2++;
                }
            }

            return ls.ToArray();
        }
    }
}
