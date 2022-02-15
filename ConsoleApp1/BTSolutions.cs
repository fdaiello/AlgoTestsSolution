using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public class BTSolutions
    {
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

			public BinaryTree(int value)
			{
				this.value = value;
			}
		}
	}
}
