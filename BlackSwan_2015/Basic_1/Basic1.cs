using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class Basic1
    {
        static void Main(string[] args)
        {
            BullsAndCows bac = new BullsAndCows();
            //bac.DoIt();

            ValidNumber vn = new ValidNumber();
            //vn.DoIt();

            RangeNum rn = new RangeNum();
            //rn.DoIt();

            MatrixIncreasingPath mip = new MatrixIncreasingPath();
            //mip.DoIt();

            CountSmallerNumbers csn = new CountSmallerNumbers();
            //csn.DoIt();

            ArrayIntersection ai=new ArrayIntersection();
            //ai.DoIt();

            ToKFrequency toK=new ToKFrequency();
            //toK.DoIt();

            ReverseStrings rs=new ReverseStrings();
            //rs.DoIt();

            AboutIntegers aint=new AboutIntegers();
            aint.DoIt();

            Console.Read();
        }
    }
}
