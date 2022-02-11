using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    public class Arrays
    {
        /*
          Write a function that takes in an array of integers and returns the length of
          the longest peak in the array.

          A peak is defined as adjacent integers in the array that are <b>strictly</b>
          increasing until they reach a tip (the highest value in the peak), at which
          point they become <b>strictly</b> decreasing. At least three integers are required to
          form a peak.

          For example, the integers <span>1, 4, 10, 2</span> form a peak, but the
          integers <span>4, 0, 10</span> don't and neither do the integers
          <span>1, 2, 2, 0</span>. Similarly, the integers <span>1, 2, 3</span> don't
          form a peak because there aren't any strictly decreasing integers after the
         */

        public static int LongestPeak(int[] array)
        {

            if (array.Length < 3)
                return 0;

            int pMax = 0;
            int pLast = 0;
            int flag = 0;

            for ( int i =1; i<array.Length; i++)
            {
                if ( array[i] > array[i - 1])
                {
                    if ( flag==0 || flag == -1 || i==1)
                    {
                        if (pLast > pMax && pLast > 2)
                            pMax = pLast;

                        pLast = 2;
                    }
                    else
                    {
                        pLast++;
                    }
                    flag = 1;
                }
                else if ( array[i] < array[i - 1])
                {
                    if ( flag==1 || ( flag == -1 && pLast > 0 ))
                    {
                        pLast++;

                        if (pLast > pMax && pLast > 2)
                            pMax = pLast;
                    }
                    flag = -1;
                }
                else
                {
                    pLast = 0;
                    flag = 0;
                }
            }

            return pMax;
        }
        /*
         *  Return True if array is Monotonic ( sorted )
         */
        public static bool IsMonotonic(int[] array)
        {
            if (array.Length < 3)
                return true;

            int flag = 0;

            for ( int i=1; i< array.Length; i++)
            {
                if ( array[i] < array[i-1] )
                {
                    if (flag == 1)
                        return false;
                    else
                        flag = -1;
                }
                else if (array[i] > array[i - 1])
                {
                    if (flag == -1)
                        return false;
                    else
                        flag = 1;
                }
            }

            return true;

        }
        /*
        Write a function that takes in two non-empty arrays of integers, finds the
        pair of numbers (one from each array) whose absolute difference is closest to
        zero, and returns an array containing these two numbers, with the number from
        the first array in the first position.

        Note that the absolute difference of two integers is the distance between
        them on the real number line. For example, the absolute difference of -5 and 5
        is 10, and the absolute difference of -5 and -4 is 1.

        You can assume that there will only be one pair of numbers with the smallest
        difference.
         */
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            // Sorth both arrays
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            // Min difference found up to now, pointers to store who we found with min diff
            int minDiff = int.MaxValue;
            int pm1=0;
            int pm2=0;

            // Pointers to traverse arrays
            int p1=0;
            int p2=0;
            int tDiff;

            // Traverse arrays
            while (true)
            {
                // Compare difference of current elements, and store if lower than what we found before
                tDiff = Math.Abs(arrayOne[p1] - arrayTwo[p2]);
                if (tDiff < minDiff)
                {
                    minDiff = tDiff;
                    pm1 = p1;
                    pm2 = p2;
                }

                // Now point to next pair
                if (arrayOne[p1] < arrayTwo[p2] && p1 < arrayOne.Length - 1)
                    p1++;
                else if (p2 < arrayTwo.Length - 1)
                    p2++;
                else
                    break;
            }

            // Write your code here.
            return new int[] { arrayOne[pm1], arrayTwo[pm2]};
        }
        /*
         *
         * You're given an array of integers and an integer. Write a function that moves
         * all instances of that integer in the array to the end of the array and returns
         * the array.
         *
         * The function should perform this in place (i.e., it should mutate the input
         * array) and doesn't need to maintain the order of the other integers.
         *          * 
         */
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            int p1 = 0;
            int p2 = array.Count-1;

            while ( p1 < p2-1)
            {
                while (array[p2] == toMove && p1 < p2 -1)
                    p2--;
                while (array[p1] != toMove && p1 < p2 - 1)
                    p1++;

                if ( array[p1] == toMove && array[p2] != toMove)
                {
                    int tmp = array[p2];
                    array[p2] = array[p1];
                    array[p1] = tmp;
                }

            }

            // Write your code here.
            return array;
        }
    }
}
