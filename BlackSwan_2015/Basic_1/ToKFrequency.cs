using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class ToKFrequency
    {
        internal void DoIt()
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int k = 2;
            Console.WriteLine(string.Join(",", TopKFrequent(nums, k)));
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }

                dict[num]++;
            }

            List<int>[] lls = new List<int>[nums.Count() + 1];
            foreach (var pair in dict)
            {
                if (lls[pair.Value] == null)
                {
                    lls[pair.Value] = new List<int>();
                }
                lls[pair.Value].Add(pair.Key);
            }

            List<int> ls = new List<int>();
            int j = lls.Count();
            for (int i = 0; i < k && j > 0; )
            {
                while (lls[--j] == null) ;

                foreach (int m in lls[j])
                {
                    ls.Add(m);
                    i++;
                }
            }

            return ls;
        }

        public IList<int> TopKFrequent1(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }

                dict[num]++;
            }

            var dic = dict.OrderByDescending(o => o.Value).ToList();

            List<int> ls = new List<int>();

            for (int i = 0; i < k; i++)
            {
                ls.Add(dic[i].Key);
            }

            return ls;
        }
    }
}
