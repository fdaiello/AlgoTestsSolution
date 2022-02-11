using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public class Dp
    {
		/*
		 *  https://www.algoexpert.io/questions/Max%20Subset%20Sum%20No%20Adjacent
		 */
		public static int MaxSubsetSumNoAdjacent(int[] array)
		{

			if (array.Length == 0)
				return 0;
			else if (array.Length == 1)
				return array[0];


			int[] m = new int[array.Length];
			m[0] = array[0];
			m[1] = Math.Max(array[0],array[1]);

			for ( int i=2; i<array.Length; i++)
            {
				m[i] = Math.Max(m[i-1],m[i-2]+array[i]);
            }

			return m[array.Length-1];
		}
		public static void TestMaxSubsetSumNoAdjacent()
        {
			int[] arr = new int[] { 75, 105, 120, 75, 90, 135 };

			Console.WriteLine(MaxSubsetSumNoAdjacent(arr));
			Console.WriteLine("Expected: 330");


			arr = new int[] { 4, 3, 5, 200, 5, 3 };
			Console.WriteLine(MaxSubsetSumNoAdjacent(arr));
			Console.WriteLine("Expected: 207");

			arr = new int[] { 30, 25, 50, 55, 100, 120 };
			Console.WriteLine(MaxSubsetSumNoAdjacent(arr));
			Console.WriteLine("Expected: 205");

		}
	}
}
