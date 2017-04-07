using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _207CourseSchedule : ILeetcode
    {
        public void DoIt()
        {
            int numCourses = 4;
            int[,] pre = {{1, 0}, {2, 1}, {3, 2}, {1, 3}};
            Console.WriteLine("Should be false: " + CanFinish(numCourses, pre));
        }

        public bool CanFinish(int numCourses, int[,] pre)
        {
            if (pre.GetLength(0) == 0) return true;

            int n = pre.GetLength(0);

            List<int>[] list = new List<int>[numCourses];
            int[] flag = new int[numCourses];// 0: Write set, unvisited set
                                             // 1: Gray set, DFS parent, visiting point
                                             // 2: Black set, visited point, means this point has no neighbor any more
            
            for (int i = 0; i < numCourses; i++)
            {
                flag[i] = 0;
                list[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                int a = pre[i, 1];
                int b = pre[i, 0];

                list[a].Add(b);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (flag[i] == 0)
                {
                    if (FindCycle(list, flag, i)) return false;
                }
            }

            return true;
        }

        private bool FindCycle(List<int>[] list, int[] flag, int current)
        {
            flag[current] = 1;
            foreach (int ls in list[current])
            {
                if (flag[ls] == 2) continue;
                if (flag[ls] == 1) return true;
                if (FindCycle(list, flag, ls)) return true;
            }
            flag[current] = 2;
            return false;
        }
    }
}
