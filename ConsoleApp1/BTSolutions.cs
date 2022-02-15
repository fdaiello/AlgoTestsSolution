using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public class BTSolutions
    {
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
