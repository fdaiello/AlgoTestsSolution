using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class RecursionSolutions
    {
        #region powerset
        /*
         * https://www.algoexpert.io/questions/Powerset
         */
        public static List<List<int>> Powerset(List<int> array)
        {
            if ( array.Count == 0)
            {
                return new List<List<int>>() { new List<int>() };
            }
            else if ( array.Count == 1)
            {
                return new List<List<int>>() { new List<int>(), array };
            }
            else
            {
                List<List<int>> ret = new List<List<int>>();

                int e = array[array.Count-1];
                List<int> arrayLess = new List<int>(array);
                arrayLess.RemoveAt(array.Count-1);

                List<List<int>> powersetLess = Powerset(arrayLess);

                foreach (List<int> subarray in powersetLess)
                {
                    ret.Add(new List<int>(subarray));

                    subarray.Add(e);
                    ret.Add(new List<int>(subarray));
                }

                return ret;
            }
        }
        public static void TestPowerset()
        {
            List<int> a = new List<int>() { };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1, 2 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1, 2, 3 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");
        }
        #endregion
        #region Permutations
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
        #endregion
    }

}
