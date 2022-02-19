using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class RecursionSolutions
    {
        /*
         * https://www.algoexpert.io/questions/Permutations
         */
        public static List<List<int>> GetPermutations(List<int> array)
        {

            List<List<int>> r = new List<List<int>>();

            if (array.Count == 0)
                return r;

            if ( array.Count < 2)
            {
                r.Add(array);
            }
            else
            {
                int p0 = array[0];
                List<int> r2 = array.GetRange(1, array.Count - 1);
                List<List<int>> r3 = GetPermutations(r2);
                foreach ( List<int> r4 in r3)
                {
                    for (int i =0; i<r4.Count; i++)
                    {
                        var r5 = r4.GetRange(0, r4.Count);
                        r5.Insert(i, p0);
                        r.Add(r5);
                    };
                    var r6 = r4.GetRange(0, r4.Count);
                    r6.Add(p0);
                    r.Add(r6);
                }
            }

            return r;
        }
        public static void TestGetPermutations()
        {
            List<int> a = new List<int>() { 1, 2, 3 };
            Console.Write(String.Join(" - ",GetPermutations(a).Select(p=>String.Join(",",p))));

            a = new List<int>() {  };
            Console.Write(String.Join(" - ", GetPermutations(a).Select(p => String.Join(",", p))));
        }
    }
}
