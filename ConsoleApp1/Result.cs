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

    }
}
