using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public static class BstSolution
    {

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

    }
}
