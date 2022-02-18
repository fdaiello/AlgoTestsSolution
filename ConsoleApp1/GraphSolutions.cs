using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class GraphSolutions
    {
        #region YoungestCommonAncestor
        /*
         * https://www.algoexpert.io/questions/Youngest%20Common%20Ancestor
         */
        public static AncestralTree GetYoungestCommonAncestor(AncestralTree topAncestor, AncestralTree descendantOne, AncestralTree descendantTwo )
        {
            HashSet<AncestralTree> visited = new HashSet<AncestralTree>();

            // Map descendantOne ancestors
            AncestralTree node = descendantOne;
            while ( node != null)
            {
                visited.Add(node);
                node = node.ancestor;
            }

            // Check descendantTwo ancestors
            node = descendantTwo;
            while ( node != null)
            {
                if (visited.Contains(node))
                {
                    return node;
                }
                node = node.ancestor;
            }

            // Write your code here.
            return topAncestor;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }
        public static void TestYoungestAncestor()
        {
            AncestralTree E = new AncestralTree('E');
            AncestralTree B = new AncestralTree('B');
            AncestralTree A = new AncestralTree('A');
            AncestralTree D = new AncestralTree('D');
            AncestralTree I = new AncestralTree('I');

            I.ancestor = D;
            D.ancestor = B;
            B.ancestor = A;
            E.ancestor = B;

            Console.WriteLine(GetYoungestCommonAncestor(A, E, I).name);
            Console.WriteLine("Expected: B");

            Console.WriteLine(GetYoungestCommonAncestor(A, A, B).name);
            Console.WriteLine("Expected: A");

            Console.WriteLine(GetYoungestCommonAncestor(A, E, B).name);
            Console.WriteLine("Expected: B");
        }
        #endregion
        #region RiverSides
        /*
         * https://www.algoexpert.io/questions/River%20Sizes
         */
        public static List<int> RiverSizes(int[,] matrix)
        {

            // Rivers lengh list
            List<int> rivers = new List<int>();

            // Save visited nodes
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();

            // Traverse Matrix
            for ( int i=0; i< matrix.GetLength(0); i++)
            {
                for (int j=0; j< matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        // Check if node was already visited
                        if ( !visited.Contains(new Tuple<int, int>(i, j)))
                        {
                            // Add node to map
                            visited.Add(new Tuple<int, int>(i, j));

                            // Traverse the river
                            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
                            q.Enqueue(new Tuple<int, int>(i, j));
                            int rl = 0;

                            while (q.Count > 0)
                            {
                                rl++;
                                Tuple<int, int> node = q.Dequeue();
                                
                                // Check all neighbors - not already visited
                                // Top
                                if ( node.Item1 > 0 && matrix[node.Item1 - 1,node.Item2]==1 && !visited.Contains(new Tuple<int, int>(node.Item1 - 1, node.Item2)))
                                {
                                    visited.Add(new Tuple<int, int>(node.Item1 - 1, node.Item2));
                                    q.Enqueue(new Tuple<int, int>(node.Item1 - 1, node.Item2));
                                }
                                // Right
                                if (node.Item2 < matrix.GetLength(1)-1 && matrix[node.Item1, node.Item2 + 1] == 1 && !visited.Contains(new Tuple<int, int>(node.Item1, node.Item2 + 1)))
                                {
                                    visited.Add(new Tuple<int, int>(node.Item1, node.Item2 + 1));
                                    q.Enqueue(new Tuple<int, int>(node.Item1, node.Item2 + 1));
                                }
                                // Down
                                if (node.Item1 < matrix.GetLength(0) - 1 && matrix[node.Item1 + 1, node.Item2] == 1 && !visited.Contains(new Tuple<int, int>(node.Item1 + 1, node.Item2)))
                                {
                                    visited.Add((new Tuple<int, int>(node.Item1 + 1, node.Item2)));
                                    q.Enqueue(new Tuple<int, int>(node.Item1 + 1, node.Item2));
                                }
                                // Left
                                if (node.Item2 > 0 && matrix[node.Item1, node.Item2 - 1] == 1 && !visited.Contains(new Tuple<int, int>(node.Item1, node.Item2 - 1)))
                                {
                                    visited.Add((new Tuple<int, int>(node.Item1, node.Item2 - 1)));
                                    q.Enqueue(new Tuple<int, int>(node.Item1, node.Item2 - 1));
                                }
                            }

                            rivers.Add(rl);
                        }
                    }
                }
            }

            
            return rivers;
        }
        public static void TestRiverSizes()
        {
            int[,] m = new int[,] { { 1, 0, 0, 1, 0 }, { 1, 0, 1, 0, 0 }, { 0, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 0 } };
            Console.WriteLine(String.Join(",",RiverSizes(m)));
            Console.WriteLine("Expected: 1,2,2,2,5");
        }
        #endregion
        #region BreadthFirstSearch
        /*
         * https://www.algoexpert.io/questions/Breadth-first%20Search
         */
        public class Node
        {
            public string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public List<string> BreadthFirstSearch(List<string> array)
            {
                Queue<Node> q = new Queue<Node>();

                q.Enqueue(this);

                while (q.Count>0)
                {
                    Node node = q.Dequeue();
                    array.Add(node.name);
                    foreach(Node child in node.children)
                    {
                        q.Enqueue(child);
                    }
                }

                return array;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return child;
            }
        }
        public static void TestBreadthFirstSearch()
        {
            Node nodeA = new Node("A");
            var nodeB = nodeA.AddChild("B");
            var nodeC = nodeA.AddChild("C");
            var nodeD = nodeA.AddChild("D");

            var nodeE = nodeB.AddChild("E");
            var nodeF = nodeB.AddChild("F");

            var nodeI = nodeF.AddChild("I");
            var nodeJ = nodeF.AddChild("J");

            var nodeG = nodeD.AddChild("G");
            var nodeH = nodeD.AddChild("H");

            nodeG.AddChild("K");

            List<string> list = new List<string>();
            Console.WriteLine(String.Join(",",nodeA.BreadthFirstSearch(list)));
        }
        #endregion
        #region SingleCycleCheck
        /*
         * https://www.algoexpert.io/questions/Single%20Cycle%20Check
         */
        public static bool HasSingleCycle(int[] array)
        {
            int p = 0;
            int c = 0;

            HashSet<int> map = new HashSet<int>();

            while (c < array.Length)
            {
                c++;

                p += array[p];
                if (p > array.Length - 1)
                    p = p%array.Length;

                if (p < 0)
                    p = array.Length + p % array.Length;

                if (map.Contains(p))
                    return false;
                else
                    map.Add(p);

            };

            if (map.Count == array.Length)
                return true;
            else 
                return false;


        }
        public static void TestHasSingleCycle()
        {
            int[] a = new int[] { 2, 3, 1, -4, -4, 2 };
            Console.WriteLine(HasSingleCycle(a));
            Console.WriteLine("Expected: true");


            a = new int[] { 1, 1, 1, 1, 2 };
            Console.WriteLine(HasSingleCycle(a));
            Console.WriteLine("Expected: false");

        }
        #endregion
    }
}
