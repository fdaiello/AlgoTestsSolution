using System;
using System.Collections.Generic;

namespace AlgoTests
{
    public class BTSolutions
    {
		#region FindNodeDistanceK
		/*
		 * https://www.algoexpert.io/questions/Find%20Nodes%20Distance%20K
		 */

		public static List<int> FindNodesDistanceK(BinaryTree tree, int target, int k)
		{
			// List of returning nodes
			List<int> list = new List<int>();

			// Create a map with parents node
			Dictionary<int, BinaryTree> parentsMap = new Dictionary<int, BinaryTree>();
			MapParents(tree, null, ref parentsMap);

			// Find target Node
			BinaryTree targetNode = FindNode(tree, target);

			// Traverse Tree as a Graph, from target Node
			HashSet<int> visited = new HashSet<int>();
			Queue<Tuple<BinaryTree, int>> queue = new Queue<Tuple<BinaryTree, int>>();
			queue.Enqueue(new Tuple<BinaryTree, int>(targetNode, 0));

			while ( queue.Count > 0)
            {
				var node = queue.Dequeue();
				
				
				if (visited.Contains(node.Item1.value))
					continue;
				visited.Add(node.Item1.value);

				if (node.Item2 == k)
					list.Add(node.Item1.value);

				if ( node.Item1.left != null)
					queue.Enqueue(new Tuple<BinaryTree, int>(node.Item1.left, node.Item2 + 1));
				if (node.Item1.right != null)
					queue.Enqueue(new Tuple<BinaryTree, int>(node.Item1.right, node.Item2 + 1));
				if (parentsMap.ContainsKey(node.Item1.value))
					queue.Enqueue(new Tuple<BinaryTree, int>(parentsMap[node.Item1.value], node.Item2 + 1));
			}

			return list;
		}
		public static void MapParents(BinaryTree node, BinaryTree parent, ref Dictionary<int, BinaryTree> parentsMap)
        {
			if (node == null)
				return;

			if (parent != null)
				parentsMap.Add(node.value, parent);

			MapParents(node.left, node, ref parentsMap);
			MapParents(node.right, node, ref parentsMap);

        }
		public static BinaryTree FindNode(BinaryTree node, int value)
        {
			if (node == null)
				return null;

			else if (node.value == value)
				return node;

			BinaryTree node1 = FindNode(node.left, value);
			if (node1 != null)
				return node1;

			return FindNode(node.right, value);
        }
		public static void TestFindNodesDistanceK()
        {
			BinaryTree tree = new BinaryTree(1)
			{
				left = new BinaryTree(2)
				{
					left = new BinaryTree(4)
					{
						left = new BinaryTree(41)
					},
					right = new BinaryTree(5)
				},
				right = new BinaryTree(3)
				{
					right = new BinaryTree(6)
                    {
						left = new BinaryTree(7),
						right = new  BinaryTree(8)
                    }
				}
			};

			int target = 3;
			int k = 2;
			Console.WriteLine(String.Join(",",FindNodesDistanceK(tree,target,k)));
			Console.WriteLine("Expected: 2, 7, 8");

        }

		// This trial didn't work
		public static List<int> FindNodesDistanceK_bug(BinaryTree tree, int target, int k)
		{
			List<int> list = new List<int>();
			int? currentDistance = null;
			FindNodes_bug(tree, target, k, ref currentDistance, ref list);

			return list;
		}
		public static void FindNodes_bug(BinaryTree tree, int target, int k, ref int? distance, ref List<int> list)
		{
			int? oldDistance = distance;

			if (tree == null)
				return;

			if (tree.value == target)
				distance = 0;
			else if (distance != null)
				distance = Math.Abs(distance ?? 0) + 1;

			if (distance == k && !list.Contains(tree.value))
				list.Add(tree.value);

			FindNodes_bug(tree.left, target, k, ref distance, ref list);
			FindNodes_bug(tree.right, target, k, ref distance, ref list);

			if (oldDistance == null && distance != null)
			{
				FindNodes_bug(tree.left, target, k, ref distance, ref list);
				FindNodes_bug(tree.right, target, k, ref distance, ref list);
			}

			distance--;
		}


		#endregion
		#region HeightBalancedTree
		/*
		 * https://www.algoexpert.io/questions/Height%20Balanced%20Binary%20Tree
		 */
		public static bool HeightBalancedBinaryTree(BinaryTree tree)
		{
			if (tree.left != null && !HeightBalancedBinaryTree(tree.left))
				return false;

			if (tree.right != null && !HeightBalancedBinaryTree(tree.right))
				return false;

			int leftDeep = BtDepth(tree.left);
			int rightDeep = BtDepth(tree.right);

			return Math.Abs(leftDeep - rightDeep) <= 1;

		}
		public static int BtDepth(BinaryTree tree)
        {
			if (tree == null)
				return 0;

			int leftDeep = BtDepth(tree.left);

			int rightDeep = BtDepth(tree.right);

			return Math.Max(leftDeep, rightDeep)+1;
        }
		public static void TestHeightBalancedBinaryTree()
        {
			BinaryTree tree = new BinaryTree(1)
			{
				left = new BinaryTree(2)
				{
					left = new BinaryTree(4)
					{
						left = new BinaryTree(6)
					},
					right = new BinaryTree(5)
				},
				right = new BinaryTree(3)
			};

			Console.WriteLine(HeightBalancedBinaryTree(tree));
			Console.WriteLine("Expected: false");


			tree = new BinaryTree(1)
			{
				left = new BinaryTree(2)
				{
					left = new BinaryTree(4)
					{
						left = new BinaryTree(6),
						right = new BinaryTree(6)
					},
					right = new BinaryTree(5)
					{
						left = new BinaryTree(6),
						right = new BinaryTree(6)
					}
				},
				right = new BinaryTree(3)
				{
					left = new BinaryTree(4)
					{
						left = new BinaryTree(6),
						right = new BinaryTree(6)
					},
					right = new BinaryTree(5)
					{
						left = new BinaryTree(6),
						right = new BinaryTree(6)
					}
				}
			};

			Console.WriteLine(HeightBalancedBinaryTree(tree));
			Console.WriteLine("Expected: true");

		}
		#endregion
		#region FindSucessor

		/*
		 * https://www.algoexpert.io/questions/Find%20Successor
		 */
		public static BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
		{
			int predecessor=int.MinValue;

			return FindSuccessor(tree, node, ref predecessor);
		}
		public static BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node, ref int predecessor)
        {
			if (tree.left != null)
			{
				BinaryTree t1 = FindSuccessor(tree.left, node, ref predecessor);
				if (t1 != null)
					return t1;
			}

			if (predecessor == node.value)
				return tree;

			predecessor = tree.value;

			if (tree.right != null)
			{
				BinaryTree t2 = FindSuccessor(tree.right, node, ref predecessor);
				if (t2 != null)
					return t2;
			}

			// Write your code here.
			return null;
		}
		public static void TestFindSucessor()
        {
			BinaryTree tree = new BinaryTree(1)
			{
				left = new BinaryTree(2) 
				{
					left = new BinaryTree(4) 
					{
						left = new BinaryTree(6)
					},
					right = new BinaryTree(5)
				},
				right = new BinaryTree(3)
			};

			BinaryTree node = new BinaryTree(5);

			BinaryTree sucessor = FindSuccessor(tree, node);
			Console.WriteLine(sucessor.value);
			Console.WriteLine("Expected: 1");

        }
		#endregion
		#region BinaryTreeDiameter
		/*
		 *	https://www.algoexpert.io/questions/Binary%20Tree%20Diameter
		 *	
		 */
		public static int BinaryTreeDiameter(BinaryTree tree)
		{
			int deep = 0;
			int width = 0;
			BinaryTreeSize(tree, ref deep, ref width);

			return width;
		}
		public static void BinaryTreeSize(BinaryTree tree, ref int deep, ref int width)
        {
			if (tree == null)
            {
				return;
            }
			else
            {
				int deepL = 0;
				int deepR = 0;
				int widthL = 0;
				int widthR = 0;

				BinaryTreeSize(tree.left, ref deepL, ref widthL);
				BinaryTreeSize(tree.right, ref deepR, ref widthR);

				deep += 1 + Math.Max(deepL, deepR);
				width = Math.Max(Math.Max(deepL + deepR, widthL),widthR);
			}
		}
		public static void TestBinaryTreeDiameter()
        {
			BinaryTree tree = new BinaryTree(20)
			{
				left = new BinaryTree(10) { 
					left = new BinaryTree(5),
					right = new BinaryTree(11)
				},
				right = new BinaryTree(30)
                {
					right = new BinaryTree(40)
                    {
						left = new BinaryTree(60) {
							left = new BinaryTree(60)
							{
								left = new BinaryTree(60),
								right = new BinaryTree(80)
							},
							right = new BinaryTree(80)
						},
						right = new BinaryTree(80)
                        {
							left = new BinaryTree(60)
							{
								left = new BinaryTree(60),
								right = new BinaryTree(80)
							},
							right = new BinaryTree(80)
						}
					}
                }
			};

			Console.WriteLine(BinaryTreeDiameter(tree));
			Console.WriteLine("Expected: 5");

        }
		#endregion
		#region InvertBinaryTree
		/*
		 *    https://www.algoexpert.io/questions/Invert%20Binary%20Tree
		 */
		public static void InvertBinaryTree(BinaryTree tree)
		{
			if ( tree != null)
            {
				BinaryTree tmp = tree.right;
				tree.right = tree.left;
				tree.left = tmp;
				InvertBinaryTree(tree.left);
				InvertBinaryTree(tree.right);
			}
		}
        #endregion
        public class BinaryTree
		{
			public int value;
			public BinaryTree left;
			public BinaryTree right;
			public BinaryTree parent;

			public BinaryTree(int value)
			{
				this.value = value;
			}
		}
	}
}
