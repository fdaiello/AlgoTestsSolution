using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class SortingSolutions
    {
        #region ThreeNumberSort
        /*
         * https://www.algoexpert.io/questions/Three%20Number%20Sort
         */
        public static int[] ThreeNumberSort(int[] array, int[] order)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int i in order)
                map.Add(i, 0);

            foreach (int i in array)
                map[i]++;

            return Enumerable.Repeat(order[0], map[order[0]]).Concat(Enumerable.Repeat(order[1], map[order[1]])).Concat(Enumerable.Repeat(order[2], map[order[2]])).ToArray();

        }
        public static void TestThreeNumberSort()
        {
            int[] a = new int[] { -1, 0, 1, 1, 0, -1, 1, 0, 0 - 1, -1, 0, 1 };
            int[] order = new int[] { 1, -1, 0 };

            Console.WriteLine(String.Join(",", ThreeNumberSort(a, order)));
        }
        #endregion
        #region BubbleSort
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
                for (int x = 0; x < array.Length - 1; x++)
                {
                    if (array[x + 1] < array[x])
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
        #endregion
        #region InsertionSort
        public static int[] InsertionSort(int[] array)
        {
            // Check if array has at least 2 elements, otherwise, return same array
            if (array.Length < 2)
                return array;

            // Iterate array elements, from 1 to n
            for (int x = 1; x < array.Length; x++)
            {
                int y = x - 1;

                if (array[x] < array[y])
                {
                    while (y > 0 && array[x] < array[y - 1])
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
            for (int x = p2; x > p1; x--)
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
        #endregion
        #region SelectionSort
        /*
         * Selection Sort
         */
        public static int[] SelectionSort(int[] array)
        {

            // min saved position
            int p = 0;
            // min saved value
            int v;

            // Loop all array ( steps )
            for (int x = 0; x < array.Length; x++)
            {
                // resset min saved value
                v = Int32.MaxValue;

                // Inner step - interate thru the rest of the array
                for (int y = x; y < array.Length; y++)
                {
                    // Compare value of current position with saved one
                    if (array[y] < v)
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
        #endregion
    }
}
