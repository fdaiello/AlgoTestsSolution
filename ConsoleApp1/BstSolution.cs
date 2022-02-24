using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoTests
{
    public static class BstSolution
    {
        #region maxPathSum
        /*
         * https://www.algoexpert.io/questions/Max%20Path%20Sum%20In%20Binary%20Tree
         */
        public static int MaxPathSum(BinaryTree tree)
        {
            int suml1 = 0;
            int suml2 = 0;
            int sumr1 = 0;
            int sumr2 = 0;

            if (tree.left != null)
            {
                MaxPathSum2(tree.left, ref suml1, ref suml2);
            }
            if (tree.right != null)
            {
                MaxPathSum2(tree.left, ref sumr1, ref sumr2);
            }


            return Math.Max(sumr2,Math.Max(suml2,tree.value+suml1+sumr1));

        }
        public static void MaxPathSum2(BinaryTree tree, ref int sum1, ref int sum2)
        {
            int suml1 = 0;
            int suml2 = 0;
            int sumr1 = 0;
            int sumr2 = 0;

            if (tree.left != null )
            {
                MaxPathSum2(tree.left, ref suml1, ref suml2);
            }
            if (tree.right != null)
            {
                MaxPathSum2(tree.right, ref sumr1, ref sumr2);
            }

            sum1 = tree.value + Math.Max(suml1, sumr1);
            sum2 = Math.Max(suml2,sumr2);

        }
        public static void TestMaxPathSum()
        {
            BinaryTree tree = new BinaryTree(1)
            {
                value = 1,
                left = new BinaryTree(2)
                {
                    left = new BinaryTree(4)
                    {
                        left = new BinaryTree(8)
                        {
                            right = new BinaryTree(10)
                        },
                        right = new BinaryTree(9) 
                    },
                    right = new BinaryTree(5)
                },
                right = new BinaryTree(3)
                {
                    left = new BinaryTree(6),
                    right = new BinaryTree(7),
                }
            };

            Console.WriteLine(MaxPathSum(tree));
            Console.WriteLine("Expected: 25");

        }
        #endregion
        #region ValidateThreeNodes
        /*
         * https://www.algoexpert.io/questions/Validate%20Three%20Nodes
         */
        public static bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree)
        {
            bool foundOne = false;
            bool foundThree = false;

            // Traverse NodeTwo and check if eather one or three are descendants
            Queue<BST> queue = new Queue<BST>();
            queue.Enqueue(nodeTwo);
            while (queue.Count > 0)
            {
                BST node = queue.Dequeue();
                if (node.value == nodeOne.value)
                {
                    foundOne = true;
                    break;
                }
                else if ( node.value == nodeThree.value)
                {
                    foundThree = true;
                    break;
                }
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            if (foundOne)
            {
                // Traverse nodeThree and check if two is descendant
                Queue<BST> queue3 = new Queue<BST>();
                queue3.Enqueue(nodeThree);
                while (queue3.Count > 0)
                {
                    BST node = queue3.Dequeue();
                    if (node.value == nodeTwo.value)
                        return true;
                    if (node.left != null)
                        queue3.Enqueue(node.left);
                    if (node.right != null)
                        queue3.Enqueue(node.right);
                }
                return false;
            }
            else if (foundThree)
            {
                // Traverse nodeOne and check if two is descendant
                Queue<BST> queue1 = new Queue<BST>();
                queue1.Enqueue(nodeOne);
                while (queue1.Count > 0)
                {
                    BST node = queue1.Dequeue();
                    if (node.value == nodeTwo.value)
                        return true;
                    if (node.left != null)
                        queue1.Enqueue(node.left);
                    if (node.right != null)
                        queue1.Enqueue(node.right);
                }
                return false;

            }
            else
            {
                return false;
            }

        }
        public static void TestValidateThreeNodes()
        {
            BST N5 = new BST(5)
            { 
                left=new BST(2)
                { 
                    left=new BST(1)
                    { 
                        left = new BST(0)
                    },
                    right=new BST(4)
                    {
                        left=new BST(3)
                    }
                },
                right=new BST(7)
                { 
                    left = new BST(6),
                    right = new BST(8)
                },
            };

            Console.WriteLine(ValidateThreeNodes(N5, N5.left, N5.left.right.left));
        }
        #endregion
        #region SameBst
        /*
         * https://www.algoexpert.io/questions/Same%20BSTs
         */
        public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo)
        {
            if (arrayOne.Count == 0 && arrayTwo.Count == 0)
                return true;

            else if (arrayOne[0] != arrayTwo[0] || arrayOne.Count != arrayTwo.Count )
                return false;

            else
            {
                List<int> a1Lowers = new List<int>(arrayOne.GetRange(1, arrayOne.Count - 1).Where(p => p < arrayOne[0]));
                List<int> a2Lowers = new List<int>(arrayTwo.GetRange(1, arrayTwo.Count - 1).Where(p => p < arrayTwo[0]));

                List<int> a1Greaters = new List<int>(arrayOne.GetRange(1, arrayOne.Count - 1).Where(p => p >= arrayOne[0]));
                List<int> a2Greaters = new List<int>(arrayTwo.GetRange(1, arrayTwo.Count - 1).Where(p => p >= arrayTwo[0]));

                return SameBsts(a1Lowers, a2Lowers) && SameBsts(a1Greaters, a2Greaters);
            }
        }
        public static void TestSameBsts()
        {
            List<int> arrayOne = new List<int>() { 10, 15, 8, 12, 94, 81, 5, 2, 11 };
            List<int> arrayTwo = new List<int>() { 10, 8, 5, 15, 2, 12, 11, 94, 81 };

            Console.WriteLine(SameBsts(arrayOne, arrayTwo));
            Console.WriteLine("Expected: true");


            arrayOne = new List<int>() { 10, 15, 8, 12, 94, 81, 5, 2, 10 };
            arrayTwo = new List<int>() { 10, 8, 5, 15, 2, 10, 12, 94, 81 };

            Console.WriteLine(SameBsts(arrayOne, arrayTwo));
            Console.WriteLine("Expected: false");

        }
        #endregion
        #region ReconstructBst
        /*
         * https://www.algoexpert.io/questions/Reconstruct%20BST
         * 
         * Reconstruct BST
         */
        public static BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            if (preOrderTraversalValues.Count == 0)
                return null;

            int p = 0;
            BST root = ReconstructBst(preOrderTraversalValues, ref p, int.MaxValue, int.MinValue);

            return root;
        }
        public static BST ReconstructBst(List<int> preOrderTraversalValues, ref int p, int leftFather, int rightFather )
        {
            if (p < preOrderTraversalValues.Count)
            {
                BST node;
                node = new BST(preOrderTraversalValues[p]);
                p++;

                if (p < preOrderTraversalValues.Count)
                {
                    if ( preOrderTraversalValues[p] < node.value )
                    {
                        node.left = ReconstructBst(preOrderTraversalValues, ref p, node.value, rightFather);
                    }

                    if (p < preOrderTraversalValues.Count && preOrderTraversalValues[p] >= node.value && preOrderTraversalValues[p] < leftFather )
                    {
                        node.right = ReconstructBst(preOrderTraversalValues, ref p, leftFather, node.value);
                    }

                }

                return node;
            }
            else
            {
                return null;
            }
        }
        public static void TestReconstructBst()
        {
            List<int> list = new List<int>() { 10, 4, 2, 1, 5, 17, 19, 18 };
            BST bst = ReconstructBst(list);

            List<int> nList = new List<int>();
            nList = PreOrderTraverse(bst, nList);
            Console.WriteLine(String.Join(",", nList));
            Console.WriteLine("Expected: " + String.Join(",", list));
        }
        #endregion
        #region BranchSum
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
        #endregion
        #region NodeDepths
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
        #endregion
        public static void DEEPFirstSearch_Test1()
        {
            Node node = new Node("A")
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

            Console.WriteLine(String.Join(",", stringList));
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

            Console.WriteLine(String.Join(",", BstSolution.InOrderTraverse(tree, arr2)));

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
            Console.WriteLine(String.Join(",", BstSolution.InOrderTraverse(bst, arr)));

            arr = new List<int>();
            Console.WriteLine("Pre Order");
            Console.WriteLine(String.Join(",", BstSolution.PreOrderTraverse(bst, arr)));

            arr = new List<int>();
            Console.WriteLine("Pos Order");
            Console.WriteLine(String.Join(",", BstSolution.PostOrderTraverse(bst, arr)));

        }

        /*
         *  https://www.algoexpert.io/questions/Find%20Kth%20Largest%20Value%20In%20BST
         */
        public static int FindKthLargestValueInBst(BST tree, int k)
        {

            List<int> traverse = new List<int>();
            traverse = InOrderTraverse(tree, traverse);

            traverse.Reverse();
            return traverse[k - 1];

        }
        /*
         * BUGGED!!!
         */
        public static int FindKthLargestValueInBst1(BST tree, ref int k)
        {
            int p=0;

            if (tree.right != null)
                p = FindKthLargestValueInBst1(tree.right, ref k);

            if (k == 1)
                return p;

            k--;
            if ( k== 1)
                return tree.value;

            if (tree.left != null)
                return FindKthLargestValueInBst1(tree.left, ref k);

            return 0;
    
        }
        /*
         * https://www.algoexpert.io/questions/Min%20Height%20BST
         * 
         *    Build a balanced ( min possible height ) BST from given array
         */
        public static BST MinHeightBst(List<int> array)
        {

            if ( array.Count > 0)
            {
                int p = array.Count / 2;
                int m = array[p];

                BST node = new BST(m);

                List<int> arrayL = array.GetRange(0, p);
                List<int> arrayR = array.GetRange(p+1, array.Count-p-1);

                node.left = MinHeightBst(arrayL);
                node.right = MinHeightBst(arrayR);

                return node;
            }
            else
            {
                return null;
            }

        }
        public static bool ValidateBst(BST tree)
        {
            return ValidateBst(tree, int.MaxValue, int.MinValue);

        }
        public static bool ValidateBst(BST node, int min, int max)
        {

            if (node == null)
                return true;

            else if (node.value >= min || node.value < max)
                return false;

            else
                return ValidateBst(node.right, min, node.value) && ValidateBst(node.left, node.value, max);

        }
        #region In_Pre_Post_OrderTraverse
        public static List<int> InOrderTraverse(BST tree, List<int> array)
		{

			if (tree.left != null)
				InOrderTraverse(tree.left, array);

			array.Add(tree.value);

			if (tree.right != null)
				InOrderTraverse(tree.right, array);

			// Write your code here.
			return array;
		}

		public static List<int> PreOrderTraverse(BST tree, List<int> array)
		{
			array.Add(tree.value);

			if (tree.left != null)
				PreOrderTraverse(tree.left, array);

			if (tree.right != null)
				PreOrderTraverse(tree.right, array);

			return array;
		}

		public static List<int> PostOrderTraverse(BST tree, List<int> array)
		{
			if (tree.left != null)
				PostOrderTraverse(tree.left, array);

			if (tree.right != null)
				PostOrderTraverse(tree.right, array);

			array.Add(tree.value);

			return array;
		}
        #endregion
        #region FindClosestValueInBst
        /*
        Find Closest Value in BST

        Write a function that takes in a Binary Search Tree (BST) and a target integer
        value and returns the closest value to that target value contained in the BST.

        You can assume that there will only be one closest value.

        Each BST node has an integer value, a
        left child node, and a right child node. A node is
        said to be a valid <span>BST</span> node if and only if it satisfies the BST
        property: its <span>value</span> is strictly greater than the values of every
        node to its left; its <span>value</span> is less than or equal to the values
        of every node to its right; and its children nodes are either valid
        <span>BST</span> nodes themselves or <span>None</span>

        Sample Input

                  10
               /     \
              5      15
            /   \   /   \
           2     5 13   22
         /           \
        1            14

        target = 12
        
        Sample Output: 13

         */
        public static int FindClosestValueInBst(BST tree, int target)
        {
            return FindClosestValueInBstNode(tree, target, tree.value);

        }
        public static int FindClosestValueInBstNode(BST tree, int target, int lastValue)
        {
            if (tree.value == target)
                return tree.value;

            int closestValue;

            if (Math.Abs(tree.value - target) < Math.Abs(lastValue - target))
                closestValue = tree.value;
            else
                closestValue = lastValue;

            if (target < tree.value)
                if (tree.left != null)
                    return FindClosestValueInBstNode(tree.left, target, closestValue);
                else
                    return closestValue;

            else
                if (tree.right != null && tree.right.value > tree.value)
                return FindClosestValueInBstNode(tree.right, target, closestValue);
            else
                return closestValue;

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
        #endregion
    }
}
