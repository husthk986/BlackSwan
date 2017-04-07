using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _0GraphShotestPath : ILeetcode
    {
        private const int mInf = int.MaxValue;
        public void DoIt()
        {
            int[][] W = {  
                    new []{  0,   1,   4,  mInf,  mInf,  mInf }, 
                    new []{  1,   0,   2,   7,    5,  mInf }, 
                    new []{  4,   2,   0,  mInf,    1,  mInf },  
                    new []{ mInf,  7,  mInf,   0,    3,    2 }, 
                    new []{ mInf,  5,    1,   3,   0,    6 },  
                    new []{ mInf, mInf,  mInf,   2,   6,    0 } };

            int from = 1, to = 6;
            int[] dist = Dijkstra(W, to, from);

            to = 0;
            foreach (int i in dist)
            {
                Console.WriteLine("From: {0} To: {1}, shortest path is: {2}", from, to++, i);
            }
            Console.WriteLine();
        }

        public static int[] Dijkstra(int[][] graph, int n, int u)
        {
            int[] dist = new int[n];
            bool[] s = new bool[n];
            for (int i = 0; i < n; i++)
            {
                s[i] = false;
                dist[i] = mInf;
            }

            int min, v;
            for (int i = 0; i < n; i++)
            {
                dist[i] = graph[u][i];
            }

            s[u] = true;
            while (true)
            {
                min = mInf; v = -1;
                //Find shortest dist 
                for (int i = 0; i < n; i++)
                {
                    if (!s[i])
                    {
                        if (dist[i] < min) { min = dist[i]; v = i; }
                    }
                }//Only usage of min is to find out v
                if (v == -1) break;//No more shortest path found 

                //Renew shortest path
                s[v] = true;
                for (int i = 0; i < n; i++)
                {
                    if (!s[i] &&
                            graph[v][i] != mInf &&
                            dist[i] > dist[v] + graph[v][i])
                    {
                        dist[i] = dist[v] + graph[v][i];
                    }
                }
            }
            return dist;
        }
    }
}
