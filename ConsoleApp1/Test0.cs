/*

CODILITY DEMO TEST

This is a demo task.

Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000..1,000,000].
using System;

*/
using System;
class Solution
{
    public int solution(int[] A)
    {
       int min = 1;

        if (A.Length == 0)
            return min;

        Array.Sort(A);

        if (A[0] > 1)
            return min;

        if (A[A.Length-1] <= 0)
            return min;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == min)
            {
                min++;
            }
        }

        return min;
    }
}
