using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class SearchingSolutions
    {
        #region SearchInSortedMatrix
        /*
         *  https://www.algoexpert.io/questions/Search%20In%20Sorted%20Matrix
         */
        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {

            for ( int i =0; i<matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] > target)
                    break;

                for ( int j=0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == target)
                        return new int[2] { i, j };
                    if (matrix[i, j] > target)
                        break;
                }
            }

            return new int[] { -1, -1 };
        }
        public static void TestSearchInSortedMatrix()
        {
            int[,] matrix = new int[,] {
                {1, 4, 7, 12, 15, 1000},
                {2, 5, 19, 31, 32, 1001},
                {3, 8, 24, 33, 35, 1002},
                {40, 41, 42, 44, 45, 1003},
                {99, 100, 103, 106, 128, 1004},
            };

            int target = 44;

            Console.WriteLine(String.Join(",", SearchInSortedMatrix(matrix, target)));
            Console.WriteLine("Expected: 3,3 ");

        }
        #endregion
        #region FindThreeLargestNumbers
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
                for (int y = 2; y >= 0; y--)
                {
                    if (array[x] > result[y])
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
        #endregion
        #region BinarySearch
        public static int BinarySearch(int[] array, int target)
        {
            return BinarySearchWithPointers(array, target, 0, array.Length - 1);
        }
        public static int BinarySearchWithPointers(int[] array, int target, int lowerPointer, int upperPointer)
        {

            if (array[lowerPointer] == target)
                return lowerPointer;
            else if (array[upperPointer] == target)
                return upperPointer;

            int middlePointer = (upperPointer - lowerPointer) / 2 + lowerPointer;

            if (middlePointer == upperPointer | middlePointer == lowerPointer)
                return -1;

            if (array[middlePointer] == target)
            {
                return middlePointer;
            }
            else if (target < array[middlePointer])
            {
                upperPointer = middlePointer;
            }
            else
            {
                lowerPointer = middlePointer;
            }

            return BinarySearchWithPointers(array, target, lowerPointer, upperPointer);

        }
        #endregion
    }
}
