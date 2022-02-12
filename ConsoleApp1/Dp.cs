using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public class Dp
    {
		/*
		 * Minimum coins to make a change
		 * https://www.algoexpert.io/questions/Min%20Number%20Of%20Coins%20For%20Change
		 *
 		 *  Input:
		 *         n- the amout to make change
		 *         denoms - collection of coins denomination ( infinite set of each denomination )
		 *         
		 *  Output
         *         minimum number of coins to make that change
		 */
		public static int MinNumberOfCoinsForChange(int n, int[] denoms)
		{

			// Memo array f, from 0 to n.
			int[] f = new int[n + 1];
			// Init f[0] with 0 ( zero coins to make change for zero ).
			f[0] = 0;
			// All other should be set to infinite ( infinite zero coins - will be resseted as the algo runs )
			// BE CAREFULL with MaxValue. Int32.MaxValue + 1 result negative integer!!!!!
			for (int i = 1; i <= n; i++)
				f[i] = short.MaxValue;

			// Test all subamounts from 1 to n
			for ( int a=1; a<=n; a++)
            {
				// Test all available coin denominations
				foreach( int coin in denoms)
                {
					// Check if this coin is lower or equal amount
					if ( coin <= a)
                    {
						// Update minimum possible coins to make change for this amount - f[a] - with 1 ( this coin ) plus: amount beeing testeed, removing less this coin value, or previus computed value
						// This sould only be done if f[a - coin] has value lower than MaxValue - 
						f[a] = Math.Min(f[a], 1 + f[a - coin]);
                    }
                }
            }

			// Need to check if it was possible to make change for this amount
			if (f[n] < short.MaxValue)
				return f[n];
			else
				return -1;

		}
		public static void TestMinNumberOfCoinsForChange()
		{
			int[] denomn = new int[] { 1, 5 };
			int n = 6;
			Console.WriteLine(MinNumberOfCoinsForChange(n, denomn));
			Console.WriteLine("Expected: 2");

			denomn = new int[] { 1, 3, 4 };
			n = 6;
			Console.WriteLine(MinNumberOfCoinsForChange(n, denomn));
			Console.WriteLine("Expected: 2");

			denomn = new int[] { 1, 3, 5, 10 };
			n = 13;
			Console.WriteLine(MinNumberOfCoinsForChange(n, denomn));
			Console.WriteLine("Expected: 2");

			denomn = new int[] { 2, 4 };
			n = 7;
			Console.WriteLine(MinNumberOfCoinsForChange(n, denomn));
			Console.WriteLine("Expected: 1");

		}
		/* 
		 * Number of different ways to make change
		 * https://www.algoexpert.io/questions/Number%20Of%20Ways%20To%20Make%20Change
		 * 
		 *  Input:
		 *         n- the amout to make change
		 *         denoms - collection of coins denomination ( infinite set of each denomination )
		 *         
		 *  Output
		 *         the number of different ( unordered ) possibilites to make the change
		 */
		public static int NumberOfWaysToMakeChange(int n, int[] denoms)
		{

			// Memo array f - starting from zero - f[0] inits with 1 ( one possibility to make change for 0 with zero coins )
			int[] f = new int[n + 1];
			f[0] = 1;

			// Test each coin
			foreach ( int coin in denoms)
            {
				// Test all subamounts 
				for ( int a = 1; a<=n; a++)
                {
					// Check if coin is lower or equal denomination
					if ( coin <= a )
                    {
						// Add this possibility to memo array - one possibility ( with this coin ) plus all possibilities already computed for this amount subtractin this coin
						f[a] += f[a - coin];
					}
                }
            }

			// Return f for largest amount - n
			return f[n];

		}
		public static void TestNumberOfWaysToMakeChange()
        {
			int[] denomn = new int[] { 1, 5 };
			int n = 6;

			Console.WriteLine(NumberOfWaysToMakeChange(n, denomn));
			Console.WriteLine("Expected: 2");


			denomn = new int[] { 1, 3, 4 };
			n = 6;
			Console.WriteLine(NumberOfWaysToMakeChange(n, denomn));
			Console.WriteLine("Expected: 4");

		}
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
