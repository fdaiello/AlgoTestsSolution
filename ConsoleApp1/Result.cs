using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class Result
    {

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
        /*
         * Selection Sort
         */
        public static int[] SelectionSort(int[] array)
        {

            // testing position
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
    }
}
