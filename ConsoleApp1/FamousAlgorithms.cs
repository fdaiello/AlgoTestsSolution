using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class FamousAlgorithms
    {
        #region DijkstraAlgorithm
        /*
         * https://www.algoexpert.io/questions/Dijkstra's%20Algorithm
         */
        public static int[] DijkstrasAlgorithm(int start, int[][][] edges)
        {
            // Empty edges case
            if (edges.Length == 0)
                return new int[0];

            // Array to save distannces from start to each node
            int[] distances = new int[edges.Length];
            for ( int i =0; i<edges.Length; i++)
            {
                distances[i] = -1;
            }
            distances[start] = 0;

            // Queue to traverse the graph ( bradth first search ). Two elements in queue: node number, distance from start
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { start, 0 });

            // Traverse the graph
            while (queue.Count > 0)
            {
                int[] nodeInQueue = queue.Dequeue();

                int nodeNumber = nodeInQueue[0];
                int distanceToThisNode = nodeInQueue[1];

                foreach (int[] edge in edges[nodeNumber]) 
                {
                    if ( distances[edge[0]] ==-1 || distances[edge[0]] > distanceToThisNode + edge[1])
                    {
                        distances[edge[0]] = distanceToThisNode + edge[1];
                        queue.Enqueue(new int[] { edge[0], distanceToThisNode + edge[1] });
                    }
                }
                
            }            

            return distances;
        }
        public static void TestDijkstrasAlgorithim()
        {
            int[][][] edges = new int[][][] {
                new int[][] { new int[] {1, 7}},
                new int[][] { new int[] {2, 6}, new int[] { 3, 20}, new int[] { 4, 3}},
                new int[][] { new int[] {3, 14}},
                new int[][] { new int[] {4, 2}},
                new int[][] {},
                new int[][] {},
            };

            int start = 0;
            Console.WriteLine(String.Join(",", DijkstrasAlgorithm(start, edges)));
            Console.WriteLine("Expected: 0, 7, 13, 27, 10, -1");

            edges = new int[][][]
            {
                new int[] [] { },
                new int[] [] { },
                new int[] [] { },
                new int[] [] { },
            };

            start = 1;
            Console.WriteLine(String.Join(",", DijkstrasAlgorithm(start, edges)));
            Console.WriteLine("Expected: -1, 0, -1, -1");

        }
        #endregion
        #region KadanesAlgorithm
        /*
         * https://www.algoexpert.io/questions/Kadane's%20Algorithm
         * 
         */
        public static int KadanesAlgorithm(int[] array)
        {
            int max1 = int.MinValue;
            int max2 = 0;

            for ( int i=0; i<array.Length; i++)
            {
                max2 += array[i];

                if (max2 > max1)
                    max1 = max2;

                if (max2 < 0)
                    max2 = 0;
            }

            return max1;
        }
        public static void TestKadanesAlgorithm()
        {
            int[] a = new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 };
            Console.WriteLine(KadanesAlgorithm(a));
            Console.WriteLine("Expected: 19");
        }
        #endregion
    }
}
