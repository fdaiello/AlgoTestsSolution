using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class FamousAlgorithms
    {
        #region KadanesAlgorithm
        /*
         * https://www.algoexpert.io/questions/Kadane's%20Algorithm
         * 
         */
        public static int KadanesAlgorithm(int[] array)
        {
            int max1 = int.MinValue;
            int max2 = 0;

            for ( int i=0; i<array.Length; i++)
            {
                max2 += array[i];

                if (max2 > max1)
                    max1 = max2;

                if (max2 < 0)
                    max2 = 0;
            }

            return max1;
        }
        public static void TestKadanesAlgorithm()
        {
            int[] a = new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 };
            Console.WriteLine(KadanesAlgorithm(a));
            Console.WriteLine("Expected: 19");
        }
        #endregion
    }
}
