using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class GraphSolutions
    {
        #region SingleCycleCheck
        /*
         * https://www.algoexpert.io/questions/Single%20Cycle%20Check
         */
        public static bool HasSingleCycle(int[] array)
        {
            int p = 0;
            int c = 0;

            HashSet<int> map = new HashSet<int>();

            while (c < array.Length)
            {
                c++;

                p += array[p];
                if (p > array.Length - 1)
                    p = p%array.Length;

                if (p < 0)
                    p = array.Length + p % array.Length;

                if (map.Contains(p))
                    return false;
                else
                    map.Add(p);

            };

            if (map.Count == array.Length)
                return true;
            else 
                return false;


        }
        public static void TestHasSingleCycle()
        {
            int[] a = new int[] { 2, 3, 1, -4, -4, 2 };
            Console.WriteLine(HasSingleCycle(a));
            Console.WriteLine("Expected: true");


            a = new int[] { 1, 1, 1, 1, 2 };
            Console.WriteLine(HasSingleCycle(a));
            Console.WriteLine("Expected: false");

        }
        #endregion
    }
}
