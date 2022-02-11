using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dp.TestMaxSubsetSumNoAdjacent();
        }
        static void TestFindKthLargestValueInBst1()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            BST tree = BstSolution.MinHeightBst(arr);

            int k = 5;
            Console.WriteLine(BstSolution.FindKthLargestValueInBst1(tree, ref k));

        }
        static void TestMinHeightBST()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            BST tree = BstSolution.MinHeightBst(arr);

            List<int> arr2 = new List<int>();

            Console.WriteLine(String.Join(",",BstSolution.InOrderTraverse(tree, arr2)));

        }
        static void TestValidateBST()
        {
            BST bst = new BST(10)
            {
                left = new BST(5)
                {
                    left = new BST(2)
                    {
                        left = new BST(1)
                    },
                    right = new BST(9)
                },
                right = new BST(15)
                {
                    right = new BST(22),
                    left = new BST(9)
                }
            };

            Console.WriteLine(BstSolution.ValidateBst(bst));
            Console.WriteLine("Expected: False");

        }
        static void TestBSTTraversal()
        {
            BST bst = new BST(10)
            {
                left = new BST(5)
                {
                    left = new BST(2)
                    {
                        left = new BST(1)
                    },
                    right = new BST(5)
                },
                right = new BST(15)
                {
                    right = new BST(22)
                }
            };

            List<int> arr;

            arr = new List<int>();
            Console.WriteLine("In Order");
            Console.WriteLine(String.Join(",",BstSolution.InOrderTraverse(bst,arr)));

            arr = new List<int>();
            Console.WriteLine("Pre Order");
            Console.WriteLine(String.Join(",", BstSolution.PreOrderTraverse(bst, arr)));

            arr = new List<int>();
            Console.WriteLine("Pos Order");
            Console.WriteLine(String.Join(",", BstSolution.PostOrderTraverse(bst, arr)));

        }
        /*
		 * Two Number Sum
		 * Return an array with 2 numbers that belogns to the input array, and that sum equals target sum
		 */
        public static int[] TwoNumberSum(int[] array, int targetSum)
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

        }
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

        public static void TestFindClosestValueInBst()
        {
            BST tree = new BST(10)
            {
                left = new BST(5)
                {
                    left = new BST(2)
                    {
                        left = new BST(1)
                    },
                    right = new BST(5)
                },
                right = new BST(15)
                {
                    left = new BST(13)
                    {
                        right = new BST(14)
                    },
                    right = new BST(22)
                }
            };

            int target = 3;

            Console.WriteLine($"Find Closes Value in BST: {BstSolution.FindClosestValueInBst(tree, target)}");

        }

        /*
         Branch sum

  Write a function that takes in a Binary Tree and returns a list of its branch
  sums ordered from leftmost branch sum to rightmost branch sum.

  A branch sum is the sum of all values in a Binary Tree branch. A Binary Tree
  branch is a path of nodes in a tree that starts at the root node and ends at
  any leaf node.

  Each <span>BinaryTree</span> node has an integer <span>value</span>, a
  <span>left</span> child node, and a <span>right</span> child node. Children
  nodes can either be <span>BinaryTree</span> nodes themselves or
  <span>None</span> / <span>null</span>.

    Sample Input
           1
        /     \
       2       3
     /   \    /  \
    4     5  6    7
  /   \  /
 8    9 10

    Sample Output

[15, 16, 18, 10, 11]

// 15 == 1 + 2 + 4 + 8
// 16 == 1 + 2 + 4 + 9
// 18 == 1 + 2 + 5 + 10
// 10 == 1 + 3 + 6
// 11 == 1 + 3 + 7

         */

        public static List<int> BranchSums(BinaryTree root)
        {
            List<int> listSum = new List<int>();
            int sum = 0;

            BranchSumsNode(root, listSum, sum);

            return listSum;
        }
        public static void BranchSumsNode(BinaryTree node, List<int> listSum, int sum)
        {

            sum += node.value;

            if (node.left != null)
            {
                BranchSumsNode(node.left, listSum, sum);
            }

            if (node.right != null)
            {
                BranchSumsNode(node.right, listSum, sum);
            }

            if (node.left == null && node.right == null)
            {
                listSum.Add(sum);
            }

        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
        public static void TestBranchsums()
        {
            BinaryTree tree = new BinaryTree(1)
            {
                value = 1,
                left = new BinaryTree(2)
                {
                    left = new BinaryTree(4)
                    {
                        left = new BinaryTree(8),
                        right = new BinaryTree(9),
                    },
                    right = new BinaryTree(5)
                    {
                        left = new BinaryTree(10)
                    },
                },
                right = new BinaryTree(3)
                {
                    left = new BinaryTree(6),
                    right = new BinaryTree(7),
                }
            };

            Console.WriteLine($"Test Branch sums: [{String.Join(",", BranchSums(tree))}]");
        }

        /* NODE DEPTHS
         
          The distance between a node in a Binary Tree and the tree's root is called the
        node's depth.

          Write a function that takes in a Binary Tree and returns the sum of its nodes'
        depths.

          Each <span>BinaryTree</span> node has an integer <span>value</span>, a
        <span>left</span> child node, and a <span>right</span> child node. Children
        nodes can either be <span>BinaryTree</span> nodes themselves or
        None.

        Sample Input

           1
       /     \
      2       3
    /   \   /   \
   4     5 6     7
 /   \
8     9

        Sample Output
        16

            The depth of the node with value 2 is 1.
            The depth of the node with value 3 is 1.
            The depth of the node with value 4 is 2.
            The depth of the node with value 5 is 2.
            Etc..
            Summing all of these depths yields 16.
         */

        public static int NodeDepths(BinaryTree root)
        {
            int sum = 0;
            int depth = 0;
            NodeDepthsSum(root, ref sum, depth);

            return sum;
        }
        public static void NodeDepthsSum(BinaryTree tree, ref int sum, int depth)
        {
            // Increment dept
            depth++;

            // Check if we have left branch
            if (tree.left != null)
            {
                sum += depth;
                NodeDepthsSum(tree.left, ref sum, depth);
            }
            if (tree.right != null)
            {
                sum += depth;
                NodeDepthsSum(tree.right, ref sum, depth);
            }

        }
        public static void TestNodeDepths()
        {
            BinaryTree tree = new BinaryTree(1)
            {
                value = 1,
                left = new BinaryTree(2)
                {
                    left = new BinaryTree(4)
                    {
                        left = new BinaryTree(8),
                        right = new BinaryTree(9),
                    },
                    right = new BinaryTree(5)
                },
                right = new BinaryTree(3)
                {
                    left = new BinaryTree(6),
                    right = new BinaryTree(7),
                }
            };

            Console.WriteLine($"Node Depths sum: {NodeDepths(tree)}");
        }

        public static void DEEPFirstSearch_Test1()
        {
            Node node = new Node ("A")
            {
                children = {
                    new Node ("B")
                {
                        children =
                        {
                            new Node ("E"),
                            new Node ("F")
                            {
                                children =
                                {
                                    new Node ("I"),
                                    new Node ("J")
                                }
                            }
                        }
                },
                    new Node ("C"),
                    new Node ("D")
                    {
                        children =
                        {
                            new Node ("G")
                            {
                                children = { new Node("K") }
                            },
                            new Node ("H")
                        }
                    }
                }
            };

            List<string> stringList = new List<string>();
            stringList = node.DepthFirstSearch(stringList);

            Console.WriteLine(String.Join(",",stringList));
        }

        public static int MinimumWaitingTime(int[] queries)
        {
            Array.Sort(queries);

            int sum = 0;
            int waitingTime = queries[0];

            for ( int x=1; x<queries.Length; x++)
			{
                sum += waitingTime;
                waitingTime += queries[x];
            }

            // Write your code here.
            return sum;
        }
        public static void TestMinimumWaitingTime()
		{
            int[] input = { 3, 2, 1, 2, 6 };

            Console.WriteLine($"Minimum waiting time: {MinimumWaitingTime(input)}");

		}
        public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {

            redShirtHeights.Sort();
            blueShirtHeights.Sort();

            if (redShirtHeights[0] == blueShirtHeights[0])
			{
                return false;
			}
            else if ( redShirtHeights[0] < blueShirtHeights[0])
			{
                for ( int x=1; x<redShirtHeights.Count; x++)
				{
                    if (redShirtHeights[x] >= blueShirtHeights[x])
                        return false;
				}
			}
            else

            {
                for (int x = 1; x < redShirtHeights.Count; x++)
                {
                    if (redShirtHeights[x] <= blueShirtHeights[x])
                        return false;
                }
            }

            return true;
        }
        public static void TestClassPhotos()
        {
            List<int> row1 = new List<int> { 1, 2, 3, 4, 5, 7 };
            List<int> row2 = new List<int> { 2, 3, 4, 5, 6, 7 };

            Console.WriteLine($"Test Class Photos: {ClassPhotos(row1, row2)}");
		}

        public static int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
        {
            int sum = 0;
            Array.Sort(redShirtSpeeds);
            Array.Sort(blueShirtSpeeds);

            if (fastest)
			{
                Array.Reverse(blueShirtSpeeds);
			}

            for (int x = 0; x < redShirtSpeeds.Length; x++)
            {
                if (redShirtSpeeds[x] > blueShirtSpeeds[x])
                    sum += redShirtSpeeds[x];
                else
                    sum += blueShirtSpeeds[x];
            }

            return sum;
        }
        public static void TestTandemBicyle()
		{
            int[] redShirtSpeeds = { 5, 5, 3, 9, 2 };
            int[] blueShirtSpeeds = { 3, 6, 7, 2, 1 };

            Console.WriteLine($"Test Tandem Bicycle: {TandemBicycle(redShirtSpeeds, blueShirtSpeeds, false)}");
		}

        // This is an input class. Do not edit.
        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public static LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
        {
            LinkedList node = linkedList;

            do
            {
                if (node.value == node.next?.value)
                    node.next = node.next?.next;
                else
                    node = node.next;

            } while (node != null);
            
            return linkedList;
        }
        public static void TestRemoveDuplicatesFromLinkedList()
		{
            LinkedList linkedList = new LinkedList(1)
            {
                next = new LinkedList(1)
                {
                    next = new LinkedList(3)
                    {
                        next = new LinkedList(4)
                        {
                            next = new LinkedList(4)
                            {
                                next = new LinkedList(4)
                                {
                                    next = new LinkedList(5)
                                    {
                                        next = new LinkedList(6)
                                        {
                                            next = new LinkedList(6)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            LinkedList linkedList1 = RemoveDuplicatesFromLinkedList(linkedList);

            do
            {
                Console.Write(linkedList1.value + ",");
                linkedList1 = linkedList1.next;
            } while (linkedList1 != null);

		}

        /*
         * Fibonaci sequence
         */
        public static int GetNthFib(int n)
        {
            if (FibonaciCache is null)
                FibonaciCache = new Dictionary<int, int>();

            if (FibonaciCache.ContainsKey(n))
                return FibonaciCache[n];

            else
			{
                int result;

                if (n <= 0)
                    result = -1;
                else if (n == 1)
                    result =  0;
                else if (n == 2)
                    result = 1;
                else
                    result =GetNthFib(n - 1) + GetNthFib(n - 2);

                FibonaciCache.Add(n, result);
                return result;
            }

        }
        public static Dictionary<int, int> FibonaciCache { get; set; }

        public static void TestFibonaciSequence() 
        {

            int n = 6;
            Console.WriteLine($"Fibonaci Sequence. Position {n} result is {GetNthFib(n)}");

        }
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
            
            foreach ( object element in array)
			{
                if ( element is int)
				{
                    sum += (int) element;
				}
                else
				{
                    sum += ProductSumSpecialArray((List<object> )element, depth + 1);
				}
			}

            return sum * depth;
        }
        public static void TestProductSum() 
        {
            List<object> specialArray = new List<object> { 5, 2, new List<object> { 7, -1 }, 3, new List<object> { 6, new List<object> { -13, 8 }, 4 } };

            Console.WriteLine($"Product sum of special array: result = {ProductSum(specialArray)}");

        }
        /*
         * Find the three larges numbers in the array, without sorting it
         */
        public static int[] FindThreeLargestNumbers(int[] array)
        {

            // Check input array
            if (array.Length < 3)
                return new int[3];

            // We will have to save values to a new array - lets initialize with first 3 values
            int[] result = new int[] { Int32.MinValue, Int32.MinValue, Int32.MinValue };

            // Loop input array 
            for (int x = 0; x < array.Length; x++)
            {
                // Loop result array, right to left ( higher to lower )
                for (int y = 2; y >=0; y--)
                {
                    if ( array[x] > result[y])
                    {
                        if (y == 2)
                        {
                            result[0] = result[1];
                            result[1] = result[2];
                            result[2] = array[x];
                        }
                        else if (y == 1)
						{
                            result[0] = result[1];
                            result[1] = array[x];
						}
                        else
						{
                            result[0] = array[x];
						}
                        break;
                    }
                }
            }

            // return the array with vaues
            return result;
        }
        public static void TestFindThreeLargestNumbers()
		{
            int[] input = { 55, 7, 8 };

            Console.WriteLine($"Three largest numbers from array: {String.Join(",", FindThreeLargestNumbers(input))}");
		}
        /*
         * Bubble sort
         */
        public static int[] BubbleSort(int[] array)
        {
            // Check if array has at leat 2 elements
            if (array.Length <= 1)
			{
                // Otherwise return same array
                return array;
			}

            // Flag to controle if we did one pass without changes
            bool changed = true;

            while (changed)
			{
                changed = false;

                // Run thru all array
                for (int x = 0; x < array.Length-1; x++)
				{
                    if ( array[x+1] < array[x])
					{
                        int temp = array[x];
                        array[x] = array[x + 1];
                        array[x + 1] = temp;
                        changed = true;
					}
				}
			}

            return array;
        }
        public static void TestBubleSort()
		{

            int[] input = { -1, -2, -3 };

            Console.WriteLine($"Bubble sort result of input {String.Join(",", input)}:\n{String.Join(",", BubbleSort(input))} ");
		}
        public static int[] InsertionSort(int[] array)
        {
            // Check if array has at least 2 elements, otherwise, return same array
            if (array.Length < 2)
                return array;

            // Iterate array elements, from 1 to n
            for ( int x=1; x<array.Length; x++)
			{
                int y = x-1;

                if ( array[x] < array[y])
				{
                    while (y > 0 && array[x] < array[y-1] )
                    {
                        y--;
                    }
                    
                    int temp = array[x];
                    ArrayPartShiftLeft(array, y, x);
                    array[y] = temp;
				}
			}

            return array;
        }
        public static int[] ArrayPartShiftLeft(int[] array, int p1, int p2)
		{
            for ( int x=p2; x>p1; x--)
			{
                array[x] = array[x - 1];
			}
            return array;
		}
        public static void TestInsertionSort()
        {
            int[] input = { 8, 5, -2, 9, 5, 6, 3 };

            Console.WriteLine($"Insertion sort result of input {String.Join(",", input)}:\n{String.Join(",", InsertionSort(input))} ");
        }
        /*
         * Selection Sort
         */
        public static int[] SelectionSort(int[] array)
        {

            // testing position
            int p=0;
            // min saved value
            int v;

            // Loop all array ( steps )
            for ( int x=0; x<array.Length; x++)
			{
                // resset min saved value
                v = Int32.MaxValue;
                
                // Inner step - interate thru the rest of the array
                for ( int y=x; y<array.Length; y++)
				{
                    // Compare value of current position with saved one
                    if ( array[y] < v)
					{
                        v = array[y];
                        p = y;
					}
				}

                // Now exchange minimun saved value with first position of this step
                int temp = array[x];
                array[x] = array[p];
                array[p] = temp;

            }

            return array;
        }
        public static void TestSelectionSort()
        {
            int[] input = { 3, 1, 2 };

            Console.WriteLine($"Selection sort result of input {String.Join(",", input)}:\n{String.Join(",", SelectionSort(input))} ");
        }
        /*
         * Palindrome Check
         */
        public static bool IsPalindrome(string str) {

            // empty and 1 char lenght test
            if (str.Length == 0)
                return false;
            else if (str.Length == 1)
                return true;
		
            // Interate thru string to its middle, comparing com simetric position
            for ( int x=0; x < str.Length/2; x++)
			{
                // Compare current position with simetric
                if (str.Substring(x, 1) != str.Substring(str.Length - 1 - x,1))
                    return false;
			}

            // Write your code here.
		    return true;
	    }
        public static void TestIsPalindrome()
        {
            string input = "arararas";

            Console.WriteLine($"String {input} palindrome check: {IsPalindrome(input)}");
        }
        /*
         * Ceasar Cypher Encryption
         */
        public static string CaesarCypherEncryptor(string str, int key)
        {

            char[] chars = str.ToCharArray();

            // Iterate thru string
            for ( int x=0; x< str.Length; x++)
			{
                // Increment letter by key positions
                int p = (int)chars[x] +key;

                // If we got beyond z char
                while (p > (int)'z')
				{
                    p = (int)'a' + ( p - (int)'z' -1 );
				}

                // Replace char from input string with shifted char
                str = str.Remove(x,1);
                str = str.Insert(x, ((char) p).ToString());
			}

            return str;
        }
        public static void TestCeaserCypherEncryptor()
		{
            string input = "abcdefgtuvwzyz";
            int key = 30;

            Console.WriteLine($"The string {input} coded with Ceasar Encryptor is: {CaesarCypherEncryptor(input, key)}");
		}
        /*
         *   Run Lenght encoding
         */
        public static string RunLengthEncoding(string str)
        {
            // initial lenght test
            if (str.Length == 0)
                return str;
            else if (str.Length == 1)
                return "1" + str;

            // store last char - initialize with first character from string
            string lastChar = null;

            // store continuous char count - number of instances of same char in string
            int charRepeat = 0;

            // sb will store our output - string builder is used for better performace as we are going to manipulate output string
            StringBuilder sb = new StringBuilder();

            // Iterate thru string, starting at the second position 
            for ( int x=0; x<str.Length; x++)
			{
                // Check if its the same char as the last one
                if (lastChar == null || lastChar == str.Substring(x, 1))
				{
                    // increment repeated char count
                    charRepeat++;

                    // if we reached 9 repeated chars
                    if ( charRepeat == 9)
					{
                        sb.Append("9" + lastChar);
                        charRepeat = 0;
                        lastChar = null;
					}
                    else
                    {
                        // update last char
                        lastChar = str.Substring(x, 1);
                    }

                }
                else
				{

                    // Write repetition counter and last char to output stringbuilder
                    sb.Append(charRepeat.ToString() + lastChar);
                    charRepeat = 1;

                    // update last char
                    lastChar = str.Substring(x, 1);

                }

                // at the last element
                if (x == str.Length - 1)
                {
                    sb.Append(charRepeat.ToString() + lastChar);
                }

            }

            // returns string from sb
            return sb.ToString();
        }
        public static void TestRunLengthEncoding()
        {
            string input = "aaaaaaaaaaaaaaaaaaaabbbbbfghu";

            Console.WriteLine($"The string {input} Run Length encoded is : {RunLengthEncoding(input)}");
        }
        /*
         * Generate Document
         */
        public static bool GenerateDocument(string characters, string document)
        {
            char[] array = characters.ToCharArray();

            for ( int x=0; x< document.Length; x++)
            {
                // Check if array contens document character
                int p = Array.IndexOf(array, document.Substring(x, 1).ToCharArray()[0]);

                // If it contains
                if ( p >= 0){
                    // Remove it from array - mark position with char null;
                    array[p] = (char) 0;
                }
                // if it does not contains
                else
                {
                    return false;
                }
            }

            return true;
        }
        public static void TestGenerateDocument()
        {
            string availableChars = "Bste!hetsi ogEAxpelrt x ";
            string document = "AlgoExpert is the Best!!";

            Console.Write($"Generate Docoument: {GenerateDocument(availableChars, document)}");
        }
        public static int FirstNonRepeatingCharacter(string str)
        {
            // Dictionary to store characters and the quantity they appeared
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            // Iterate thru input string
            for ( int x =0; x<str.Length; x++)
            {
                // Gets character of x position
                string thisChar = str.Substring(x, 1);

                // Check if it is in the dictionary
                if (keyValuePairs.ContainsKey(thisChar)) 
                {
                    // if found, increment its counter
                    keyValuePairs[thisChar] ++;
                }
                else
                {
                    // if not found, insert with 1 as counter
                    keyValuePairs.Add(thisChar, 1);
                }
            }

            // Iterante thru dictionary
            foreach ( var item in keyValuePairs)
            {
                if ( item.Value == 1)
                {
                    string firstChar = item.Key;
                    // Search position of firstChar at the input String
                    return str.IndexOf(firstChar);
                }
            }

            return -1;
        }
        public static void TestFirstNonRepeatingCharacter()
        {
            string input = "ax1xddffeebcdcafasdfasdfasdfghjdgfhdfghertwertwertç098765432";

            Console.WriteLine($"First NonRepeating Character of string {input} was found at position {FirstNonRepeatingCharacter(input)}");

        }
        class ArrayComparer : EqualityComparer<int[]>
        {
            public override bool Equals(int[] x, int[] y)
            {
                if (x[0] == y[0] && x[1] == y[1] && x[2] == y[2])
                    return true;
                else
                    return false;
            }

            public override int GetHashCode(int[] obj)
            {
                throw new NotImplementedException();
            }
        }
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
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
        public static List<int[]> ThreeNumberSum0(int[] array, int targetSum)
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
    }
}