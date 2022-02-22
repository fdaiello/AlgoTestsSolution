using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class GreedySolutions
    {
        #region ValidStartingCity
        public static int ValidStartingCity(int[] distances, int[] fuel, int mpg)
        {

            decimal availableFuel;
            int currentCity;

            for (int i = 0; i < distances.Length; i++)
            {
                currentCity = i;
                int cityCount = 0;
                availableFuel = 0;
                while (cityCount < distances.Length)
                {
                    cityCount++;

                    availableFuel = availableFuel + fuel[currentCity] - (decimal)distances[currentCity] / mpg;
                    if (availableFuel < 0)
                        break;

                    // Next city
                    currentCity++;
                    if (currentCity == distances.Length)
                        currentCity = 0;
                }

                if (cityCount == distances.Length)
                    return i;
            }

            return -1;
        }
        public static void TestValidStartingCity()
        {
            int[] distances = { 5, 25, 15, 10, 15 };
            int[] fuel = { 1, 2, 1, 0, 3 };
            int mpg = 10;

            Console.WriteLine(ValidStartingCity(distances, fuel, mpg));
            Console.WriteLine("Expected: 4");


            distances = new int[] { 30, 40, 10, 10, 17, 13, 50, 30, 10, 40 };
            fuel = new int[] { 1, 2, 0, 1, 1, 0, 3, 1, 0, 1 };
            mpg = 25;
            Console.WriteLine(ValidStartingCity(distances, fuel, mpg));
            Console.WriteLine("Expected: 1");
        }

        #endregion
        #region TaskAssignment
        /*
         * https://www.algoexpert.io/questions/Task%20Assignment
         */
        public static List<List<int>> TaskAssignment(int k, List<int> tasks)
        {
            List<List<int>> ret = new List<List<int>>();

            int[][] map = new int[tasks.Count][];
            for (int i =0; i<tasks.Count; i++)
            {
                map[i] = new int[2] { tasks[i], i };
            }

            Array.Sort(map, (x, y) => x[0].CompareTo(y[0]));

            for (int i=0; i<tasks.Count/2; i++)
            {
                ret.Add(new List<int>() { map[i][1], map[tasks.Count - i-1][1] });
            }

            return ret;
        }
        public static void TestTaskAssignment()
        {
            List<int> tasks = new List<int>() { 1, 3, 5, 3, 1, 4 };
            int k = 3;
            Console.WriteLine(String.Join("", TaskAssignment(k, tasks).Select(p => "{" + String.Join(",", p) + "}") ) );
        }
        #endregion
        #region MinimumWaitingTime
        public static int MinimumWaitingTime(int[] queries)
        {
            Array.Sort(queries);

            int sum = 0;
            int waitingTime = queries[0];

            for (int x = 1; x < queries.Length; x++)
            {
                sum += waitingTime;
                waitingTime += queries[x];
            }

            // Write your code here.
            return sum;
        }
        public static void TestMinimumWaitingTime()
        {
            int[] input = { 3, 2, 1, 2, 6 };

            Console.WriteLine($"Minimum waiting time: {MinimumWaitingTime(input)}");

        }
        #endregion
        #region ClassPhotos
        public static bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {

            redShirtHeights.Sort();
            blueShirtHeights.Sort();

            if (redShirtHeights[0] == blueShirtHeights[0])
            {
                return false;
            }
            else if (redShirtHeights[0] < blueShirtHeights[0])
            {
                for (int x = 1; x < redShirtHeights.Count; x++)
                {
                    if (redShirtHeights[x] >= blueShirtHeights[x])
                        return false;
                }
            }
            else

            {
                for (int x = 1; x < redShirtHeights.Count; x++)
                {
                    if (redShirtHeights[x] <= blueShirtHeights[x])
                        return false;
                }
            }

            return true;
        }
        public static void TestClassPhotos()
        {
            List<int> row1 = new List<int> { 1, 2, 3, 4, 5, 7 };
            List<int> row2 = new List<int> { 2, 3, 4, 5, 6, 7 };

            Console.WriteLine($"Test Class Photos: {ClassPhotos(row1, row2)}");
        }
        #endregion
        #region TandemBike
        public static int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
        {
            int sum = 0;
            Array.Sort(redShirtSpeeds);
            Array.Sort(blueShirtSpeeds);

            if (fastest)
            {
                Array.Reverse(blueShirtSpeeds);
            }

            for (int x = 0; x < redShirtSpeeds.Length; x++)
            {
                if (redShirtSpeeds[x] > blueShirtSpeeds[x])
                    sum += redShirtSpeeds[x];
                else
                    sum += blueShirtSpeeds[x];
            }

            return sum;
        }
        public static void TestTandemBicyle()
        {
            int[] redShirtSpeeds = { 5, 5, 3, 9, 2 };
            int[] blueShirtSpeeds = { 3, 6, 7, 2, 1 };

            Console.WriteLine($"Test Tandem Bicycle: {TandemBicycle(redShirtSpeeds, blueShirtSpeeds, false)}");
        }
        #endregion

    }
}
