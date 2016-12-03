using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _11WaterContainer : ILeetcode
    {
        public void DoIt()
        {
            int[] height = { 2, 1, 3 };
            Console.WriteLine("Should be 4: " + MaxArea(height));

            height = new[] { 1, 1 };
            Console.WriteLine("Should be 1: " + MaxArea(height));
        }
        
        public int MaxArea(int[] height)
        {
            int result = 0;

            int len = height.Length, low = 0, high = len - 1;
            while (low < high)
            {
                result = Math.Max(result, (high - low) * Math.Min(height[low], height[high]));
                if (height[low] < height[high])
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            return result;
        }


        public int MaxArea1(int[] height)
        {
            int result = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    result = Math.Max(result, (j - i) * Math.Min(height[j], height[i]));
                }
            }

            return result;
        }
    }
}
