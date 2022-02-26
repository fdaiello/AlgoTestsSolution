using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    public class DpSolutions
    {
		#region MaximumSubSubMatrix
		/*
		 * https://www.algoexpert.io/questions/Maximum%20Sum%20Submatrix
		 */
		public static int MaximumSumSubmatrix(int[,] matrix, int size)
		{
			// Create a prefix sum matrix
			int[,] prefixSum = new int[matrix.GetLength(0), matrix.GetLength(1)];

			// Init first row and col
			prefixSum[0, 0] = matrix[0, 0];
			for ( int i = 1; i < matrix.GetLength(0); i++)
            {
				prefixSum[i, 0] = matrix[i, 0] + prefixSum[i - 1, 0];
            }
			for ( int i = 1; i < matrix.GetLength(1); i++)
            {
				prefixSum[0, i] = matrix[0, i] + prefixSum[0, i - 1];
            }
			// Now fill all other cells
			for ( int i = 1; i<matrix.GetLength(0); i++)
            {
				for ( int j = 1; j<matrix.GetLength(1); j++)
                {
					prefixSum[i, j] = prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1] + matrix[i,j];
                }
            }

			// Now get the max sum for given size
			int maxSum = int.MinValue;

			for ( int i=size-1; i<matrix.GetLength(0); i++)
            {
				for ( int j=size-1; j < matrix.GetLength(1); j++)
                {
					int thisSum = prefixSum[i, j];
					if (i - size >= 0)
						thisSum -= prefixSum[i - size,j];
					if (j - size >= 0)
						thisSum -= prefixSum[i, j - size];
					if (i - size >= 0 && j - size >= 0)
						thisSum += prefixSum[i - size, j - size];

					if (thisSum > maxSum)
						maxSum = thisSum;
                }
            }

			return maxSum;
		}
		public static void TestMaxSumSubMastrix()
        {
			int[,] matrix = new int[,] { { 2, 4 }, { 5, 6 }, { -3, 2 } };
			int size = 2;

			Console.WriteLine(MaximumSumSubmatrix(matrix, size));
			Console.WriteLine("Expected: 17");
        }
		#endregion
		#region NumbersInPi
		/*
		 * https://www.algoexpert.io/questions/Numbers%20In%20Pi
		 */
		public static int NumbersInPi(string pi, string[] numbers)
		{
			// Create a hash with numbers
			HashSet<String> favoriteNumbers = new HashSet<string>();
			foreach ( string number in numbers)
				favoriteNumbers.Add(number);

			// Create map with prefixes and minimum number of spaces found for each prefix
			Dictionary<string, int> prefixMap = new Dictionary<string, int>();

			// Call the method that will check the prefix
			CheckMinSpacePrefix(pi, favoriteNumbers, prefixMap);

			// Return what was computed to pi
			return prefixMap[pi]>short.MaxValue ? -1 : prefixMap[pi];

		}
		public static void CheckMinSpacePrefix(string prefix, HashSet<string> favoriteNumbers, Dictionary<string,int> prefixMap)
        {
			bool found = false;

			// Iterate thru prefix
			for ( int i =1; i<=prefix.Length; i++)
            {
				// Check if prefix is found at favorite numbers
				string subPrefix = prefix.Substring(0, i);
				if (favoriteNumbers.Contains(subPrefix))
                {
					found = true;
					int minSpaces;

					// found whole prefix?
					if (subPrefix.Length==prefix.Length)
                    {
						minSpaces=0;
                    }
					else
                    {
						string sufix = prefix.Substring(i);
						CheckMinSpacePrefix(sufix, favoriteNumbers, prefixMap);
						minSpaces = 1 + prefixMap[sufix];
					}

					// Save 
					if (prefixMap.ContainsKey(prefix))
						prefixMap[prefix] = Math.Min(prefixMap[prefix], minSpaces);
                    else
						prefixMap.Add(prefix, minSpaces);
                }
            }

			if (!found)
				prefixMap.Add(prefix, short.MaxValue);

        }
		public static void TestNumbersInPi()
        {
			string pi = "3141592653589793238462643383279";
			string[] numbers = new string[] { "314159265358979323846", "26433", "8", "3279", "314159265", "35897932384626433832", "79" };
			Console.WriteLine(NumbersInPi(pi, numbers));
			Console.WriteLine("Expected: 2");


			numbers = new string[] { "3141", "1512", "159", "793", "12412451", "8462643383279" };
			pi = "3141592653589793238462643383279";
			Console.WriteLine(NumbersInPi(pi, numbers));
			Console.WriteLine("Expected: -1");

		}
		#endregion
		#region DiskStacking
		/*
		 * https://www.algoexpert.io/questions/Disk%20Stacking
		 * 
		 *  int[] disk: [width, depth, height]
		 */
		public static List<int[]> DiskStacking(List<int[]> disks)
		{
			// Sort list by disks width - firt array dimension
			disks.Sort((x,y)=>x[0].CompareTo(y[0]));

			// Store max height and maxStack achieved
			int maxHeight = int.MinValue;
			List<int[]> maxStack = new List<int[]>();

			// Test starting with each disk - from smaller to greater
			for ( int i=0; i<disks.Count; i++)
            {
				int thisHeight = 0;
				List<int[]> thisStack = new List<int[]>();

				thisHeight += disks[i][2];
				thisStack.Add(disks[i]);

				// Tests all other disks that can stack
				for ( int j = i+1; j<disks.Count; j++)
                {
					if (disks[j][0] > thisStack[thisStack.Count-1][0] && disks[j][1] > thisStack[thisStack.Count - 1][1] && disks[j][2] > thisStack[thisStack.Count - 1][2])
					{
						thisHeight += disks[j][2];
						thisStack.Add(disks[j]);
					}
				}

				// Have we found a higher stack?
				if ( thisHeight > maxHeight)
                {
					maxHeight = thisHeight;
					maxStack = thisStack;
                }
            }

			return maxStack;
		}
		public static void TestDiskStacking()
        {
			List<int[]> disks = new List<int[]>() {
				new int[]{ 2, 1, 2 },
				new int[]{ 3, 2, 3 },
				new int[]{ 2, 2, 8 },
				new int[]{ 2, 3, 4 },
				new int[]{ 1, 3, 1 },
				new int[]{ 4, 4, 5 }
			};

			Console.WriteLine("[" + String.Join(",", DiskStacking(disks).Select(p => "[" + string.Join(", ", p) + "]")) + "]");
			Console.WriteLine("Expected: [[2, 1, 2], [3, 2, 3], [4, 4, 5]]");
        }
		#endregion
		#region KnapSackProblem
		/*
		 *  https://www.algoexpert.io/questions/Knapsack%20Problem
		 */
		public static List<List<int>> KnapsackProblem(int[,] items, int capacity)
		{
			int[,] values = new int[items.GetLength(0)+1, capacity + 1];

			for ( int i=1; i < values.GetLength(0); i++)
            {
				for ( int j=1;j<=capacity; j++)
                {
					// i = capacity of knapsack - up to this point
					// items[i,0] value of iTh item
					// items[i,1] weight of iTh item
					// values [i,j] max amount of value we can store of all itens up to the iTh item

					// Can we store this item ?
					if (items[i-1, 1] <= j)
					{
						// value if we put this Item = Value of this item plus the MaxValue we can store on the weight that rests
						int max1 = items[i-1, 0] + values[i - 1, j - items[i-1, 1]];
						values[i, j] = Math.Max(max1, values[i - 1, j]);
					}
					else 
					{
						values[i, j] = values[i - 1, j];
					}

                }
            }

			List<int> totalValue = new List<int> { values[values.GetLength(0) - 1, values.GetLength(1) - 1] };


			// Check wich items were used
			List<int> finalItems = new List<int>();

			int k = capacity;
			int i1 = values.GetLength(0) - 1;
			while ( k > 0 && i1>0)
            {
				while (values[i1, k] == values[i1 - 1, k] && i1 > 1)
					i1--;

				if (values[i1, k] > values[i1 - 1, k])
					finalItems.Add(i1 - 1);

				i1--;
				k -= items[i1, 1];

			}


			var result = new List<List<int>>();
			result.Add(totalValue);
			result.Add(finalItems);
			return result;
		}
		/*
		 *  This is a Tryal I did, getting the items that have the greater value/weight ration first.
		 *  But it wont solve all cases ....
		 */
		public static List<List<int>> KnapsackProblem0(int[,] items, int capacity)
		{

			int[][] items2 = new int[items.GetLength(0)][];
			Dictionary<string, int> indexes = new Dictionary<string, int>();
			for (int i = 0; i < items.GetLength(0); i++)
            {
				items2[i] = new int[] { items[i, 0], items[i, 1] };
				indexes.Add( items[i, 0].ToString() + "x" + items[i, 1].ToString() , i);
			}

			Array.Sort(items2, (x, y) => ((decimal)x[0] / x[1]).CompareTo((decimal)y[0] / y[1]));
			
			List<int> finalItems = new List<int>();

			int value = 0;
			int weight = 0;
			for ( int j=items2.Length-1; j>=0 && weight + items2[j][1] <= capacity; j--)
            {
				weight += items2[j][1];
				value += items2[j][0];

				finalItems.Add(indexes[items2[j][0].ToString() + "x" + items2[j][1].ToString()]);
            }

			// Replace the code below.
			List<int> totalValue = new List<int> { value };

			var result = new List<List<int>>();
			result.Add(totalValue);
			result.Add(finalItems);
			return result;
		}
		public static void TestKnapSack()
		{
			int[,] items = new int[,] { { 1, 2 }, { 4, 3 }, { 5, 6 }, { 6, 7 } };
			int capacity = 10;
			Console.WriteLine(String.Join(",", KnapsackProblem(items, capacity).Select(p => "[" + String.Join(",", p) + "]")));
			Console.WriteLine("Expected: 10, [1,3]");


			items = new int[,] { { 465, 100 }, { 400, 85 }, { 255, 55 }, { 350, 45 }, { 650, 130 }, { 1000, 190 }, { 455, 100 }, { 100, 25 }, { 1200, 190 }, { 320, 65 }, { 750, 100 }, { 50, 45 }, { 550, 65 }, { 100, 50 }, { 600, 70 }, { 240, 40 } };
			capacity = 200;
			Console.WriteLine(String.Join(",", KnapsackProblem(items, capacity).Select(p => "[" + String.Join(",", p) + "]")));
			Console.WriteLine("Expected: 1500, [3, 12, 14]");


		}
		#endregion
		#region WaterArea
		/*
		 * https://www.algoexpert.io/questions/Water%20Area
		 */
		public static int WaterArea(int[] heights)
		{
			int[] maxLeft = new int[heights.Length];
			int[] maxRight = new int[heights.Length];
			int max = 0;
			int area = 0;
			
			for ( int i =0; i<heights.Length; i++)
            {
				maxLeft[i] = max;
				if (heights[i] > max)
					max = heights[i];
            }
			max = 0;
			for ( int i = heights.Length-1; i>=0; i--)
            {
				maxRight[i] = max;
				if (heights[i] > max)
					max = heights[i];
				if (Math.Min(maxLeft[i], maxRight[i]) - heights[i] > 0)
					area += Math.Min(maxLeft[i], maxRight[i]) - heights[i];
            }

			return area;
		}
		public static void TestWaterArea()
        {
			int[] heights = new int[] { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 };

			Console.WriteLine(WaterArea(heights));
			Console.WriteLine("Expected: 48");

        }
		#endregion
		#region MinNumberOfJumps
		/*
		 * https://www.algoexpert.io/questions/Min%20Number%20Of%20Jumps
		 * 
		 */

		/*
		 *   Optimal O(n) time complexity version
		 *   
		 *   MaxReach = 0 ->
		 *   MaxReach = Max ( MaxReach, array[i] + i )
		 *   
		 *   Steps = array[0] ->
		 *   Steps = Steps - 1
		 *   
		 *   If ( steps = 0 )
		 *       jumps++
		 *       steps = MaxReach - i
		 *   
		 */
		public static int MinNumberOfJumps(int[] array)
		{
			if (array.Length == 1)
				return 0;

			int maxReach = array[0];
			int steps = array[0];
			int jumps = 1;

			for ( int i=1; i<array.Length-1; i++)
            {
				maxReach = Math.Max(maxReach, i + array[i]);
				steps--;
				if (steps == 0)
                {
					jumps++;
					steps = maxReach - i;
                }
            }

			return jumps;
		}
		// O (n2) time complexity version
		public static int MinNumberOfJumps0(int[] array)
		{
			int[] jumps = new int[array.Length];
			for (int i = 1; i < array.Length; i++)
				jumps[i] = int.MaxValue;

			for (int i = 1; i < array.Length; i++)
            {
				for (int j=0; j<i; j++)
                {
					if ( j + array[j] >= i)
                    {
						jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                    }
                }
			}

			return jumps[jumps.Length - 1];

		}
		public static void TestMinNumberOfJumps()
        {
			int[] a = new int[] { 3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3 };
			Console.WriteLine(MinNumberOfJumps(a));
			Console.WriteLine("Expected: 4");

			a = new int[] { 1, 1, 1 };
			Console.WriteLine(MinNumberOfJumps(a));
			Console.WriteLine("Expected: 2");

		}
		#endregion
		#region LongestCommonSubSequence
		/*
		 * https://www.algoexpert.io/questions/Longest%20Common%20Subsequence
		 * Given 2 strings, find the longest common subsequence
		 * 
		 */
		public static List<char> LongestCommonSubsequence(string str1, string str2)
		{
			string[,] f = new string[str1.Length+1, str2.Length+1];
			for (int r = 0; r <= str1.Length; r++)
				for (int c = 0; c <= str2.Length; c++)
					f[r, c] = string.Empty;

			for ( int r =1; r<=str1.Length; r++)
            {
				for ( int c=1; c<=str2.Length; c++)
                {
					if ( str1[r-1] == str2[c-1])
                    {
						f[r, c] = f[r - 1, c - 1] + str1[r-1];
                    }
					else
                    {
						if ( f[r-1,c].Length > f[r, c - 1].Length)
                        {
							f[r, c] = f[r - 1, c];
                        }
						else
                        {
							f[r, c] = f[r, c - 1];
                        }
                    }
                }
            }

			// Write your code here.
			return f[str1.Length,str2.Length].ToCharArray().ToList();
		}
		public static void TestLongestCommonSubsequence()
        {
			string str1 = "ZXVVYZW";
			string str2 = "XKYKZPW";
			Console.WriteLine(String.Join(",",LongestCommonSubsequence(str1, str2)));
			Console.WriteLine("Expected: X, Y, Z, W");

			str1 = "ABCDEFG";
			str2 = "APPLES";
			Console.WriteLine(String.Join(",", LongestCommonSubsequence(str1, str2)));
			Console.WriteLine("Expected: A, E");


		}
		#endregion
		#region MaxSumIncreasingSubsequence

		/*
		 *   https://www.algoexpert.io/questions/Max%20Sum%20Increasing%20Subsequence
		 */
		public static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
		{

			int?[] m = new int?[array.Length];
			int?[] p = new int?[array.Length];

			m[0] = array[0];
			p[0] = null;
			int? max = array[0];
			int maxP = 0;

			for ( int i=1; i<array.Length; i++)
            {
				m[i] = array[i];
				for (int j = 0; j < i; j++)
                {
					if (array[i] > array[j])
                    {
						if (array[i] + m[j] > m[i])
                        {
							m[i] = array[i] + m[j];
							p[i] = j;
						}
					}
				}

				if (m[i] > max)
				{
					max = m[i];
					maxP = i;
				}
			}

			List<int> list = new List<int>();
			for ( int i = maxP; i>=0;)
            {
				list.Add(array[i]);
				if (p[i] != null)
					i = p[i] ?? -1;
				else
					i = -1;
            }
			list.Reverse();

			return new List<List<int>> { new List<int> { max ?? -1 }, list };

		}
		public static void TestMaxSumIncreasingSubsequence()
        {
			int[] array = new int[] { 10, 70, 20, 30, 50, 11, 30 };
			var result = MaxSumIncreasingSubsequence(array);
			Console.WriteLine(result[0][0]);
			Console.WriteLine(String.Join(",", result[1]));
			Console.WriteLine("Expected: 110 -> 10,20,30,50");


			array = new int[] { 550, 10, 5, 3, 11, 2, 1 };
			result = MaxSumIncreasingSubsequence(array);
			Console.WriteLine(result[0][0]);
			Console.WriteLine(String.Join(",", result[1]));
			Console.WriteLine("Expected: 550 -> 550");

			array = new int[] { 8, 12, 2, 3, 15, 5, 7 };
			result = MaxSumIncreasingSubsequence(array);
			Console.WriteLine(result[0][0]);
			Console.WriteLine(String.Join(",", result[1]));
			Console.WriteLine("Expected: 35 -> 8, 12, 15");


		}
		#endregion
		#region NumberOfWaysToTraverseGraph
		/*
		 * Number of Ways to Traverse Graph
		 * https://www.algoexpert.io/questions/Number%20Of%20Ways%20To%20Traverse%20Graph
		 * 
		 *    Consider a Square Graph with width x height nodes;
		 *    Return all different possible ways to go from upper left corner to bottom right corner.
		 *    Only moves allowed: right, down.
		 *    
		 *    The possible ways to reach the bottom right corner equals number of ways to reach its upper node plus n.w. to reach its left node
		 *    
		 *    f (x,y) = f ( x-1, y ) + f ( x, y-1)
		 *    
		 */
		public static int NumberOfWaysToTraverseGraph(int width, int height)
		{
			int[,] m = new int[height + 1, width + 1];
			for (int r = 1; r <= height; r++)
				m[r, 1] = 1;
			for (int c = 1; c <= width; c++)
				m[1, c] = 1;

			for (int r = 2; r <= height; r++)
            {
				for (int c = 2; c <= width; c++) 
				{
					m[r, c] = m[r, c - 1] + m[r - 1, c];
				}
			}

			return m[height, width];

		}
		public static void TestNumberOfWaysToTraverseGraph()
		{

			int w = 4;
			int h = 3;
			Console.WriteLine(NumberOfWaysToTraverseGraph(w, h));
			Console.WriteLine("Expected: 10");
		}
		#endregion
		#region Levenshtein_Distance
		/*
		 * https://www.algoexpert.io/questions/Levenshtein%20Distance
		 * 
		 *  Return the minimum number of operations that needs to be perfomed on string 1 so it equals string 2
		 *  Operations:
		 *     - insert
		 *     - delete
		 *     - change character
		 */
		public static int LevenshteinDistance(string str1, string str2)
		{
			// Build Memo square Matrix
			int[,] m = new int[str2.Length + 1, str1.Length + 1];
			for (int c = 1; c <= str1.Length; c++)
				m[0, c] = c;
			for (int r = 1; r <= str2.Length; r++)
				m[r, 0] = r;

			// Loop  rows - sub strings of str2
			for ( int r=1; r<= str2.Length; r++)
            {
				// Loop columns
				for ( int c=1; c<= str1.Length; c++) 
				{
					// Check minimum to equal substrings
					if (str1[c-1] == str2[r-1])
						m[r, c] = m[r - 1, c - 1];
					else
						m[r, c] = Math.Min(m[r,c-1],Math.Min(m[r - 1, c], m[r - 1, c - 1])) + 1;
				}
            }

			return m[str2.Length, str1.Length];
		}
		public static void TestLevenshteinDistance()
        {
			string s1 = "abc";
			string s2 = "yabd";
			Console.WriteLine(LevenshteinDistance(s1, s2));
			Console.WriteLine("Expected: 2");

			s1 = "abc";
			s2 = "ybc";
			Console.WriteLine(LevenshteinDistance(s1, s2));
			Console.WriteLine("Expected: 1");

			s1 = "abc";
			s2 = "abdy";
			Console.WriteLine(LevenshteinDistance(s1, s2));
			Console.WriteLine("Expected: 2");


		}
        #endregion
        #region CoinChangeProblem
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
			Console.WriteLine("Expected: -1");

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
		#endregion
		#region MaxSubSetNoAdjacent
		/*
		 *  https://www.algoexpert.io/questions/Max%20Subset%20Sum%20No%20Adjacent
		 *  
		 *  f[i] = Max( f[i-1], f[i-2] + array[i] )
		 *  
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
        #endregion
    }
}
