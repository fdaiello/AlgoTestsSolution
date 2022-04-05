using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    public class ArraySolutions
    {
        #region ZigZag
        /*
         * https://www.algoexpert.io/questions/Zigzag%20Traverse
         */
        public static List<int> ZigzagTraverse(List<List<int>> array)
        {
            if (array.Count == 0)
                return new List<int>();
            else if (array.Count == 1)
                return array[0];

            List<int> output = new List<int>();
            int i = 0;
            int j = 0;
            bool down = true;
            int c = 0;

            while ( c < array.Count * array[0].Count )
            {
                c++;
                output.Add(array[i][j]);
                if ( down)
                {
                    if (i == array.Count - 1)
                    {
                        down = false;
                        j++;
                    }
                    else if ( j==0)
                    {
                        down = false;
                        i++;
                    }
                    else
                    {
                        i++;
                        j--;
                    }
                }
                else
                {
                    if (j == array[0].Count - 1)
                    {
                        down = true;
                        i++;
                    }
                    else if (i == 0)
                    {
                        down = true;
                        j++;
                    }
                    else
                    {
                        i--;
                        j++;
                    }
                }
            }

            return output;

        }
        public static void TestZigZagTraverse()
        {
            List<List<int>> array = new List<List<int>>()
            {
               new List<int>() {1,  3,  4, 10},
               new List<int>() {2,  5,  9, 11},
               new List<int>() {6,  8, 12, 15},
               new List<int>() {7, 13, 14, 16}
            };

            Console.WriteLine(String.Join(",", ZigzagTraverse(array)));

            array = new List<List<int>>() { new List<int> { 1, 2, 3, 4, 5 } };
            Console.WriteLine(String.Join(",", ZigzagTraverse(array)));

            array = new List<List<int>>() {
                 new List<int> { 1, 3 },
                 new List<int> { 2, 4 },
                 new List<int> { 5, 7 },
                 new List<int> { 6, 8 },
                 new List<int> { 9, 10 } };
            Console.WriteLine(String.Join(",", ZigzagTraverse(array)));

        }
        #endregion
        #region MinRewards
        /*
         * https://www.algoexpert.io/questions/Min%20Rewards
         */
        public static int MinRewards(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            rewards[0] = 1;

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > scores[i - 1])
                    rewards[i] = rewards[i - 1] + 1;
                else
                    rewards[i] = 1;
            }
            for ( int i=scores.Length-2; i>=0; i--)
            {
                if (scores[i] > scores[i + 1])
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1]+1);
            }

            return rewards.Sum();
        }
        public static int MinRewards1(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            rewards[0] = 1;

            List<int> localMins = new List<int>();
            for ( int i =0; i< scores.Length; i++)
            {
                if ( (i==0 || scores[i-1] > scores[i]) && ( i==scores.Length-1 || scores[i] < scores[i+1] ))
                {
                    localMins.Add(i);
                    rewards[i] = 1;
                }
            }

            foreach ( int i in localMins)
            {
                for ( int j=i-1; j>=0; j--)
                {
                    if (scores[j] > scores[j + 1])
                        rewards[j] = Math.Max(rewards[j], rewards[j + 1] + 1);
                    else
                        break;
                }
                for ( int j=i+1; j<scores.Length; j++)
                {
                    if (scores[j] > scores[j-1])
                        rewards[j] = Math.Max(rewards[j], rewards[j - 1] + 1);
                    else
                        break;
                }
            }

            return rewards.Sum();
        }

        public static int MinRewards0(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            rewards[0] = 1;

            for ( int i =1; i<scores.Length; i++)
            {
                if (scores[i] > scores[i - 1])
                    rewards[i] = rewards[i-1]+1;
                else if ( scores[i] < scores[i - 1])
                {
                    rewards[i] = 1;
                    for ( int j=i-1; j>=0; j--)
                    {
                        if (scores[j] > scores[j + 1])
                            rewards[j] = Math.Max(rewards[j], rewards[j + 1] + 1);
                        else
                            break;
                    }
                }
            }

            return rewards.Sum();
        }
        public static void TestMinRewards()
        {
            int[] scores = new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 };
            Console.WriteLine(MinRewards(scores));
            Console.WriteLine("Expected: 25");
        }
        #endregion
        #region LargestRange
        /*
         * https://www.algoexpert.io/questions/Largest%20Range
         */
        public static int[] LargestRange(int[] array)
        {
            if (array.Length < 2)
                return array;

            int MaxRangeStart = 0;
            int MaxRangeEnd = 0;
            int ThisRangeStart = 0;

            Array.Sort(array);

            for ( int i =1; i<array.Length; i++)
            {
                if ( array[i] - array[i-1] == 1 || array[i] == array[i-1] && array[MaxRangeStart] != array[i])
                {
                    if ( i-ThisRangeStart > MaxRangeEnd - MaxRangeStart)
                    {
                        MaxRangeStart = ThisRangeStart;
                        MaxRangeEnd = i;
                    }
                }
                else
                {
                    ThisRangeStart = i;
                }
            }

            return new int[] { array[MaxRangeStart], array[MaxRangeEnd] };
        }
        public static void TestLargestRange()
        {
            int[] array = new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 };
            Console.WriteLine(String.Join(",", LargestRange(array)));
            Console.WriteLine("Expected: 0,7");

            array = new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
            Console.WriteLine(String.Join(",", LargestRange(array)));
            Console.WriteLine("Expected: 28,28");

            array = new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6, 20, 21, 22, 23, 24, 25, 26, 27, 28, 30, 31, 32, 33, 34, 35, 36, 37 };
            Console.WriteLine(String.Join(",", LargestRange(array)));
            Console.WriteLine("Expected: 28,28");

            array = new int[] { 19, -1, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, 8, 7, 6, 15, 12, 12, 2, 1, 6, 13, 14 };
            Console.WriteLine(String.Join(",", LargestRange(array)));
            Console.WriteLine("Expected: 10,19");

            array = new int[] { 1, 1, 1, 3, 4 };
            Console.WriteLine(String.Join(",", LargestRange(array)));
            Console.WriteLine("Expected: 3, 4");

        }
        #endregion
        #region FourNumbersum
        /*
         * https://www.algoexpert.io/questions/Four%20Number%20Sum
         */
        public static List<int[]> FourNumberSum(int[] array, int targetSum)
        {
            // Output list
            List<int[]> result = new List<int[]>();

            // Create map with all possible pairs
            Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();

            for ( int i =0; i<array.Length-1; i++)
            {
                for ( int j=i+1; j<array.Length; j++)
                {
                    if (map.ContainsKey(array[i] + array[j]))
                    {
                        map[array[i] + array[j]].Add(new int[] { array[i], array[j] });
                    }
                    else
                    {
                        map.Add(array[i] + array[j], new List<int[]>() { new int[] { array[i], array[j] } });
                    }
                }
            }


            // Check all pairs, and look for a match
            int sum1;
            int sum2;

            foreach ( KeyValuePair<int,List<int[]>> kv in map)
            {
                sum1 = kv.Key;
                sum2 = targetSum - sum1;
                int[] quadruple;

                // Look for target pair. 
                if (map.ContainsKey(sum2))
                {
                    foreach ( int[] pair1 in kv.Value)
                    {
                        foreach ( int [] pair2 in map[sum2])
                        {
                            if ( pair1[0]!=pair2[0] && pair1[0] != pair2[1] && pair1[1]!=pair2[0] && pair1[1] != pair2[1])
                            {
                                quadruple = new int[] { pair1[0], pair1[1], pair2[0], pair2[1] };
                                Array.Sort(quadruple);
                                if (!result.Exists(p => p[0] == quadruple[0] && p[1] == quadruple[1] && p[2] == quadruple[2] && p[3] == quadruple[3]))
                                {
                                    result.Add(quadruple);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static void TestFourNumberSum()
        {
            int[] a = new int[] { 7, 6, 4, -1, 1, 2 };
            int target = 16;
            List<int[]> res = FourNumberSum(a, target);
            var tuples = res.Select(p => "[" + string.Join(",", p) + "]").ToList();
            Console.WriteLine("[" + String.Join(",", tuples) + "]");
            Console.WriteLine("Expected: [[7, 6, 4, -1], [7, 6, 1, 2]]");

        }
        #endregion
        #region SubArraySort
        /*
         * https://www.algoexpert.io/questions/Subarray%20Sort
         */
        public static int[] SubarraySort(int[] array)
        {
            int minUnsorted = int.MaxValue;
            int pminUnsorted=-1;

            int maxUnsorted = int.MinValue;
            int pmaxUnsorted=-1;

            // Find min and max out of position numbers
            for (int i=0; i<array.Length; i++)
            {
                if ( (i> 0 && array[i] < array[i - 1]) || ( i<array.Length-1 && array[i] > array[i+1]))
                {
                    if (array[i] < minUnsorted) 
                    {
                        minUnsorted = array[i];
                    }
                    if (array[i] > maxUnsorted) 
                    {
                        maxUnsorted = array[i];
                    }
                }
            }

            // Find correct position for min Unsorted
            for (int i = 0; i < array.Length; i++)
            {
                if (minUnsorted < array[i]) 
                {
                    pminUnsorted = i;
                    break;
                }
            }

            // Find correct position for max Unsorted
            for ( int i =array.Length-1; i>=0; i--)
            {
                if (maxUnsorted > array[i])
                {
                    pmaxUnsorted = i;
                    break;
                }
            }

            return new int[] { pminUnsorted, pmaxUnsorted};
        }
        public static void TestSubarraySort() 
        {
            int[] a = new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            Console.WriteLine(String.Join(",", SubarraySort(a)));
            Console.WriteLine("Expected: 3, 9");

            a = new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 7, 7, 16, 18, 19 };
            Console.WriteLine(String.Join(",", SubarraySort(a)));
            Console.WriteLine("Expected: 4, 9");

        }
        #endregion
        #region FirstDuplicateValue
        /*
         * https://www.algoexpert.io/questions/First%20Duplicate%20Value
         */
        public static int FirstDuplicateValue(int[] array)
        {
            HashSet<int> h = new HashSet<int>();

            for ( int i=0; i < array.Length; i++)
            {
                if (h.Contains(array[i]))
                    return array[i];
                else
                    h.Add(array[i]);
            }

            return -1;
        }
        public static void TestFirstDuplicatedValue() 
        {
            int[] a = new int[] { 2, 1, 3, 4, 5, 2, 7, 8, 9 };

            Console.WriteLine(FirstDuplicateValue(a));
            Console.WriteLine("Expected: 2");

        }
        #endregion
        #region MergeOverlappingInterval
        /*
         * https://www.algoexpert.io/questions/Merge%20Overlapping%20Intervals
         */
        public static int[][] MergeOverlappingIntervals(int[][] intervals)
        {
            //Array.Sort(intervals, new Comparison<int[]>((x,y) => x[0] > y[0] ? 1 : x[0]<y[0] ? -1 : 0));

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            int ps = intervals[0][0];
            int pe = intervals[0][1];
            List<int[]> iList = new List<int[]>();


            for ( int i=1; i<intervals.Length; i++)
            {
                if ( intervals[i][0] <= pe )
                {
                    if (  intervals[i][1] > pe )
                        pe = intervals[i][1];
                }
                else
                {
                    iList.Add(new int[] { ps, pe });
                    ps = intervals[i][0];
                    pe = intervals[i][1];
                }
            }

            iList.Add(new int[] { ps, pe });

            // Write your code here.
            return iList.ToArray();
        }
        public static void TestMergeOverlappingIntervals()
        {
            int[][] intervals = new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 4, 7 }, new int[] { 6, 8 }, new int[] { 9, 10 } };

            Console.WriteLine("[" + String.Join(",",MergeOverlappingIntervals(intervals).ToList().Select(p=>"["+p[0].ToString()+","+p[1].ToString()+"]")) + "]");
            Console.WriteLine("Expected: [1,2], [3,8], [9,10]");

        }
        #endregion
        #region ArrayOfProducts
        /*
         * https://www.algoexpert.io/questions/Array%20Of%20Products
         * 
         *       Array of products
         */
        // Otimal solution: O (n)
        public static int[] ArrayOfProducts(int[] array)
        {
            int[] l = new int[array.Length];
            int[] r = new int[array.Length];
            int[] o = new int[array.Length];

            int pl=1;
            int pr = 1;
            for (int i = 0; i < array.Length; i++)
            {
                l[i] = pl;
                pl *= array[i];

                r[array.Length - 1 - i] = pr;
                pr *= array[array.Length - 1 - i];
            }

            for (int i = 0; i < array.Length; i++) 
            {
                o[i] = l[i] * r[i];
            }
            return o;
        }
        // Brut Force O ( n2 )
        public static int[] ArrayOfProducts0(int[] array)
        {
            int[] r = new int[array.Length];
            int p;

            for ( int i=0; i < array.Length; i++)
            {
                p = 1;
                for ( int j=0; j<array.Length; j++)
                {
                    if (j != i)
                        p = p * array[j];
                }
                r[i] = p;
            }

            return r;
        }
        public static void TestArrayOfProduct()
        {
            int[] a = new int[] { 5, 1, 4, 2 };
            Console.WriteLine(String.Join(",", ArrayOfProducts(a)));
            Console.WriteLine("Expected: 8, 40, 10, 20");
        }
        #endregion
        #region SpiralTraverse
        /*
         * https://www.algoexpert.io/questions/Spiral%20Traverse
         * 
         */
        public static List<int> SpiralTraverse(int[,] array)
        {
            List<int> r = new List<int>();

            int lap = 0;
            int dir = 0;
            int col = 0;
            int row = 0;

            for ( int i =0; i < array.Length; i++)
            {
                r.Add(array[row, col]);
                if (dir==0)
                {
                    if (col < array.GetLength(1) - 1 - lap )
                        col++;
                    else
                        dir = 1;
                }
                if (dir == 1)
                {
                    if (row < array.GetLength(0) - 1 - lap)
                        row++;
                    else
                        dir = 2;
                }
                if (dir == 2)
                {
                    if (col > 0 + lap)
                        col--;
                    else
                        dir = 3;
                }
                if ( dir == 3)
                {
                    if (row > 0 + lap+1)
                        row--;
                    else
                    {
                        dir = 0;
                        lap++;
                        col++;
                    }
                }
            }


            return r;
        }
        public static void TestSpiralTraverse()
        {
            int[,] a = new int[,] { { 1, 2, 3, 4 }, { 12, 13, 14, 5 }, { 11, 16, 15, 6 }, { 10, 9, 8, 7 } };
            Console.WriteLine(String.Join(",", SpiralTraverse(a)));
            Console.WriteLine("Expected: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16");
        }
        #endregion
        #region TwoNumberSum
        /*
		 * Two Number Sum
		 * Return an array with 2 numbers that belogns to the input array, and that sum equals target sum
		 */
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            var map = new HashSet<int>();
            for ( int i=0; i<array.Length; i++) 
            {
                if (map.Contains(targetSum - array[i]))
                    return new int[2] { array[i], targetSum - array[i] };
                else
                    map.Add(array[i]);
            }

            return new int[0];
        }
        public static int[] TwoNumberSum0(int[] array, int targetSum)
        {
            for (int x = 0; x < array.Length; x++)
            {
                for (int y = 0; y < array.Length; y++)
                {
                    if (x != y && (array[x] + array[y] == targetSum))
                    {
                        return new int[] { array[x], array[y] };
                    }
                }
            }

            return new int[0];
        }
        // Test Two Number Sum
        public static void TestTwoNumberSum()
        {
            int[] array = { 3, 5, -4, 8, 11, 1, -1, 6 };
            int sum = 10;
            Console.WriteLine($"TwoNumberSum: [{String.Join(",", TwoNumberSum(array, sum))}]");
            Console.WriteLine("Expected: 11, -1");

        }
        #endregion
        #region IsValidSubSequence
        /*
		Is Valid Subsequence

        Given two non-empty arrays of integers, write a function that determines whether the second array is a subsequence of the first one.

        A subsequence of an array is a set of numbers that aren't necessarily adjacent
        in the array but that are in the same order as they appear in the array. For
        instance, the numbers [1, 3, 4] form a subsequence of the array
        [1, 2, 3, 4], and so do the numbers <span>[2, 4]</span>. Note
        that a single number in an array and the array itself are both valid
        subsequences of the array.

		 */
        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            if (array.Count == 0 || sequence.Count == 0)
                return false;

            int p = 0;

            for (int x = 0; x < array.Count; x++)
            {
                if (array[x] == sequence[p])
                    p++;
                if (p == sequence.Count)
                    return true;
            }

            return false;
        }
        public static void TestIsValidSubsequence()
        {
            List<int> sequence = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
            List<int> subSequence = new List<int> { 25, 8, 9 };

            Console.WriteLine($"Is Valid Subsequence: {IsValidSubsequence(sequence, subSequence)}");
        }
        #endregion
        #region SortedSquaredArray
        /*
        Sorted Squared Array
         
        Write a function that takes in a non-empty array of integers that are sorted
        in ascending order and returns a new array of the same length with the squares
        of the original integers also sorted in ascending order.         

        */
        public static int[] SortedSquaredArray(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            for (int x = 0; x < array.Length; x++)
            {
                sortedArray[x] = array[x] * array[x];
            }

            Array.Sort(sortedArray);

            return sortedArray;
        }
        public static void TestSortedSquaredArray()
        {
            int[] array = { -10, -2, -1, 2, 3, 5, 6, 8, 9 };
            Console.WriteLine($"Sorted Squared Array: [{string.Join(", ", SortedSquaredArray(array))}]");
        }
        #endregion
        #region ournament Winner
        // Tournament Winner
        /*
  There's an algorithms tournament taking place in which teams of programmers
  compete against each other to solve algorithmic problems as fast as possible.
  Teams compete in a round robin, where each team faces off against all other
  teams. Only two teams compete against each other at a time, and for each
  competition, one team is designated the home team, while the other team is the
  away team. In each competition there's always one winner and one loser; there
  are no ties. A team receives 3 points if it wins and 0 points if it loses. The
  winner of the tournament is the team that receives the most amount of points.

  Given an array of pairs representing the teams that have competed against each
  other and an array containing the results of each competition, write a
  function that returns the winner of the tournament. The input arrays are named
  <span>competitions</span> and <span>results</span>, respectively. The
  <span>competitions</span> array has elements in the form of
  <span>[homeTeam, awayTeam]</span>, where each team is a string of at most 30
  characters representing the name of the team. The <span>results</span> array
  contains information about the winner of each corresponding competition in the
  <span>competitions</span> array. Specifically, <span>results[i]</span> denotes
  the winner of <span>competitions[i]</span>, where a <span>1</span> in the
  <span>results</span> array means that the home team in the corresponding
  competition won and a <span>0</span> means that the away team won.

  It's guaranteed that exactly one team will win the tournament and that each
  team will compete against all other teams exactly once. It's also guaranteed
  that the tournament will always have at least two teams.

         */
        public static string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            string cWinner;
            int score;
            var competitors = new Dictionary<string, int>();

            // Varre a lista das competições
            for (int x = 0; x < competitions.Count; x++)
            {
                // Ve quem ganhou: 1 é o primeiro, 0 é o segundo
                if (results[x] == 1)
                {
                    // Home ganhou
                    cWinner = competitions[x][0];
                }
                else
                {
                    // Visitor ganhou
                    cWinner = competitions[x][1];
                }

                // Confere se o vencedor já está no dicionario
                if (competitors.TryGetValue(cWinner, out score))
                {
                    competitors[cWinner] = score + 3;
                }
                else
                {
                    competitors.Add(cWinner, 3);
                }
            }

            var winner = competitors.OrderByDescending(key => key.Value).FirstOrDefault();
            return winner.Key;

        }
        public static void TestTournamentWinner()
        {
            List<List<string>> competitions = new List<List<string>> { new List<string> { "HTML", "C#" }, new List<string> { "C#", "Python" }, new List<string> { "Python", "HTML" } };
            List<int> results = new List<int> { 0, 0, 1 };

            Console.WriteLine($"Tournament Winner: {TournamentWinner(competitions, results)}");

        }
        #endregion
        #region Non Constructible Change
        /*
        Non Constructible Change

        Given an array of positive integers representing the values of coins in your
        possession, write a function that returns the minimum amount of change (the
        minimum sum of money) that you <b>cannot</b> create. The given coins can have
        any positive integer value and aren't necessarily unique (i.e., you can have
        multiple coins of the same value).

        For example, if you're given <span>coins = [1, 2, 5]</span>, the minimum
        amount of change that you can't create is <span>4</span>. If you're given no
        coins, the minimum amount of change that you can't create is <span>1</span>.

        */
        public static int NonConstructibleChange(int[] coins)
        {
            if (coins.Length == 0)
                return 1;

            // sort array
            Array.Sort(coins);

            // if first element is greater than 1, return 1
            if (coins[0] > 1)
                return 1;

            // we know whe have 1 coin, so min change starts with 1
            int minChange = 1;

            // now lets check all coins sorted, and check what is the sum, starting from the second element
            for (int x = 1; x < coins.Length; x++)
            {

                if (minChange + coins[x] > minChange + 1 && coins[x] != minChange + 1 && coins[x] + 1 > minChange + 1)
                {
                    return minChange + 1;
                }
                else
                {
                    minChange += coins[x];
                }
            }

            // Write your code here.
            return minChange + 1;

        }
        public static void TestNonConstructibleChange()
        {
            int[] coins = { 1, 1, 1, 1, 5, 10 };

            Console.WriteLine($"Minimum non constructible change: {NonConstructibleChange(coins)}");
        }
        #endregion
        #region LongestPeak
        /*
          Write a function that takes in an array of integers and returns the length of
          the longest peak in the array.

          A peak is defined as adjacent integers in the array that are <b>strictly</b>
          increasing until they reach a tip (the highest value in the peak), at which
          point they become <b>strictly</b> decreasing. At least three integers are required to
          form a peak.

          For example, the integers <span>1, 4, 10, 2</span> form a peak, but the
          integers <span>4, 0, 10</span> don't and neither do the integers
          <span>1, 2, 2, 0</span>. Similarly, the integers <span>1, 2, 3</span> don't
          form a peak because there aren't any strictly decreasing integers after the
         */

        public static int LongestPeak(int[] array)
        {

            if (array.Length < 3)
                return 0;

            int pMax = 0;
            int pLast = 0;
            int flag = 0;

            for ( int i =1; i<array.Length; i++)
            {
                if ( array[i] > array[i - 1])
                {
                    if ( flag==0 || flag == -1 || i==1)
                    {
                        if (pLast > pMax && pLast > 2)
                            pMax = pLast;

                        pLast = 2;
                    }
                    else
                    {
                        pLast++;
                    }
                    flag = 1;
                }
                else if ( array[i] < array[i - 1])
                {
                    if ( flag==1 || ( flag == -1 && pLast > 0 ))
                    {
                        pLast++;

                        if (pLast > pMax && pLast > 2)
                            pMax = pLast;
                    }
                    flag = -1;
                }
                else
                {
                    pLast = 0;
                    flag = 0;
                }
            }

            return pMax;
        }
        #endregion
        #region ThreeNumberSum
        /*
         * https://www.algoexpert.io/questions/Three%20Number%20Sum
         */
        // Brute Force
        public static List<int[]> ThreeNumberSum1(int[] array, int targetSum)
        {
            List<int[]> result = new List<int[]>();

            Array.Sort(array);

            for (int x = 0; x < array.Length - 2; x++)
            {
                for (int y = x + 1; y < array.Length - 1; y++)
                {
                    for (int z = y + 1; z < array.Length; z++)
                    {
                        if (x != y && y != z && z != x && array[x] + array[y] + array[z] == targetSum)
                        {
                            int[] line = new int[] { array[x], array[y], array[z] };
                            result.Add(line);
                        }
                    }
                }
            }

            return result;
        }
        // Optimal
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < array.Length - 2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;

                while (left < right)
                {
                    if (array[i] + array[left] + array[right] == targetSum)
                    {
                        result.Add(new int[] { array[i], array[left], array[right] });
                        left++;
                    }
                    else if (array[i] + array[left] + array[right] < targetSum)
                    {
                        left++;
                    }
                    else if (array[i] + array[left] + array[right] > targetSum)
                    {
                        right--;
                    }
                }
            }

            return result;
        }
        #endregion
        #region ProductSum

        /*
         *  Product SUM of "special" arrays
         */
        public static int ProductSum(List<object> array)
        {
            return ProductSumSpecialArray(array, 1);
        }
        public static int ProductSumSpecialArray(List<object> array, int depth)
        {
            int sum = 0;

            foreach (object element in array)
            {
                if (element is int)
                {
                    sum += (int)element;
                }
                else
                {
                    sum += ProductSumSpecialArray((List<object>)element, depth + 1);
                }
            }

            return sum * depth;
        }
        public static void TestProductSum()
        {
            List<object> specialArray = new List<object> { 5, 2, new List<object> { 7, -1 }, 3, new List<object> { 6, new List<object> { -13, 8 }, 4 } };

            Console.WriteLine($"Product sum of special array: result = {ProductSum(specialArray)}");

        }
        #endregion
        #region MoveElementToEnd
        /*
         *
         * You're given an array of integers and an integer. Write a function that moves
         * all instances of that integer in the array to the end of the array and returns
         * the array.
         *
         * The function should perform this in place (i.e., it should mutate the input
         * array) and doesn't need to maintain the order of the other integers.
         *          * 
         */
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            int p1 = 0;
            int p2 = array.Count - 1;

            while (p1 < p2 - 1)
            {
                while (array[p2] == toMove && p1 < p2 - 1)
                    p2--;
                while (array[p1] != toMove && p1 < p2 - 1)
                    p1++;

                if (array[p1] == toMove && array[p2] != toMove)
                {
                    int tmp = array[p2];
                    array[p2] = array[p1];
                    array[p1] = tmp;
                }

            }

            // Write your code here.
            return array;
        }
        public static void TestMoveElementToEnd()
        {
            Console.WriteLine(String.Join(",", MoveElementToEnd2(new List<int> { 1, 2, 3, 4, 5, 3, 5, 6, 7, 3, 8, 7, 6, 3, 4, 5, 6 }, 3)));
        }
        public static List<int> MoveElementToEnd2(List<int> array, int toMove)
        {

            int moved = 0;

            for (int i = 0; i < array.Count - 1 - moved; i++)
            {
                if (array[i] == toMove)
                {
                    array.Add(array[i]);
                    array.RemoveAt(i);
                    i--;
                    moved++;
                }
            }

            return array;
        }
        #endregion
        #region Other
        /*
         *  Return True if array is Monotonic ( sorted )
         */
        public static bool IsMonotonic(int[] array)
        {
            if (array.Length < 3)
                return true;

            int flag = 0;

            for ( int i=1; i< array.Length; i++)
            {
                if ( array[i] < array[i-1] )
                {
                    if (flag == 1)
                        return false;
                    else
                        flag = -1;
                }
                else if (array[i] > array[i - 1])
                {
                    if (flag == -1)
                        return false;
                    else
                        flag = 1;
                }
            }

            return true;

        }
        /*
        Write a function that takes in two non-empty arrays of integers, finds the
        pair of numbers (one from each array) whose absolute difference is closest to
        zero, and returns an array containing these two numbers, with the number from
        the first array in the first position.

        Note that the absolute difference of two integers is the distance between
        them on the real number line. For example, the absolute difference of -5 and 5
        is 10, and the absolute difference of -5 and -4 is 1.

        You can assume that there will only be one pair of numbers with the smallest
        difference.
         */
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            // Sorth both arrays
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            // Min difference found up to now, pointers to store who we found with min diff
            int minDiff = int.MaxValue;
            int pm1=0;
            int pm2=0;

            // Pointers to traverse arrays
            int p1=0;
            int p2=0;
            int tDiff;

            // Traverse arrays
            while (true)
            {
                // Compare difference of current elements, and store if lower than what we found before
                tDiff = Math.Abs(arrayOne[p1] - arrayTwo[p2]);
                if (tDiff < minDiff)
                {
                    minDiff = tDiff;
                    pm1 = p1;
                    pm2 = p2;
                }

                // Now point to next pair
                if (arrayOne[p1] < arrayTwo[p2] && p1 < arrayOne.Length - 1)
                    p1++;
                else if (p2 < arrayTwo.Length - 1)
                    p2++;
                else
                    break;
            }

            // Write your code here.
            return new int[] { arrayOne[pm1], arrayTwo[pm2]};
        }
        #endregion
    }
}
