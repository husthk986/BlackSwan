using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _56MergeInterval : ILeetCode
    {
        public void DoIt()
        {
            List<Interval> intervals = new List<Interval>();
            
            intervals.Add(new Interval(5, 7));
            
            intervals.Add(new Interval(4, 5));
            intervals.Add(new Interval(3, 5));
            
            intervals.Add(new Interval(4, 4));
            

            intervals.Add(new Interval(2, 2));
            intervals.Add(new Interval(5, 6));
            intervals.Add(new Interval(2, 4));
            intervals.Add(new Interval(5, 6));
            intervals.Add(new Interval(2, 4));
            intervals.Add(new Interval(1, 1));
            intervals.Add(new Interval(0, 1));
            
            foreach (Interval inter in Merge(intervals))
            {
                Console.WriteLine("[{0},{1}]", inter.start, inter.end);
            }
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> result = new List<Interval>();
            if (intervals == null || intervals.Count == 0) return result;

            intervals = intervals.OrderBy(t => t, new IntervalComparator()).ToList();

            Interval current = intervals[0];
            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i].start <= current.end)
                {
                    current.end = Math.Max(current.end, intervals[i].end);
                }
                else
                {
                    result.Add(current);
                    current = intervals[i];
                }
            }

            result.Add(current);
            return result;
        }

        class IntervalComparator : IComparer<Interval>
        {
            public int Compare(Interval i1, Interval i2)
            {
                return i1.start - i2.start;
            }
        }

        public IList<Interval> Merge1(IList<Interval> intervals)
        {
            List<Interval> result = new List<Interval>();
            if (intervals == null) return result;

            List<NumAndState> numStateList = new List<NumAndState>();
            foreach (Interval inter in intervals)
            {
                numStateList.Add(new NumAndState(true, inter.start));
                numStateList.Add(new NumAndState(false, inter.end));
            }

            numStateList.Sort();

            int startCount = 0;
            int? start = null, end = null;
            foreach (NumAndState item in numStateList)
            {
                if (item.IsStart)
                {
                    startCount++;
                    if (start == null)
                    {
                        start = item.Num;
                    }
                }
                else
                {
                    startCount--;
                }

                if (startCount == 0)
                {
                    end = item.Num;
                    result.Add(new Interval((int)start, (int)end));
                    start = null;
                }
            }

            return result;
        }

        class NumAndState : IComparable<NumAndState>
        {
            public bool IsStart;
            public int Num;

            public NumAndState(bool isStart, int num)
            {
                this.IsStart = isStart;
                this.Num = num;
            }
            public int CompareTo(NumAndState other)
            {
                if (this.Num == other.Num)
                {
                    if (this.IsStart)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return this.Num - other.Num;
                }
            }
        }

        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }
    }
}
