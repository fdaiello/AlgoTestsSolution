using System;

namespace AlgoTests
{
    public class BTSolutions
    {
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
