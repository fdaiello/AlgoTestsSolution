using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class GreedySolutions2
    {
		public static int ValidStartingCity(int[] distances, int[] fuel, int mpg)
		{

			decimal availableFuel;
			int currentCity;

			for ( int i=0; i<distances.Length; i++)
            {
				currentCity = i;
				int cityCount = 0;
				availableFuel = 0;
				while ( cityCount < distances.Length)
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


			distances = new int[] { 30, 40, 10, 10, 17, 13, 50, 30, 10, 40};
			fuel = new int[] { 1, 2, 0, 1, 1, 0, 3, 1, 0, 1};
			mpg = 25;
			Console.WriteLine(ValidStartingCity(distances, fuel, mpg));
			Console.WriteLine("Expected: 1");
		}
	}
}
