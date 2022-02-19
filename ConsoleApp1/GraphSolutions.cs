using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class GraphSolutions
    {
        #region CycleInGraph
        /*
         * https://www.algoexpert.io/questions/Cycle%20In%20Graph
         */
        public static bool CycleInGraph(int[][] edges)
        {
            int numberOfNodes = edges.Length;

            bool[] visited = new bool[numberOfNodes];
            bool[] inStack = new bool[numberOfNodes];

            for ( int node =0; node<numberOfNodes; node++ )
            {
                if (visited[node])
                    continue;

                if (HasCycle(node, edges, visited, inStack))
                    return true;

            }

            return false;
        }
        public static bool HasCycle(int node, int[][] edges, bool[] visited, bool[] inStack)
        {
            visited[node] = true;
            inStack[node] = true;

            foreach ( int adjacent in edges[node])
            {
                if (!visited[adjacent])
                {
                    if (HasCycle(adjacent, edges, visited, inStack))
                        return true;
                }
                else if (inStack[adjacent])
                {
                    return true;
                }
            }

            inStack[node] = false;
            return false;
        }

        /*
         * The following code would only work if the graph was undirecional
         */
        public static bool CycleInGraph_2(int[][] edges)
        {
            HashSet<int> visited = new HashSet<int>();

            int i = 0;
            foreach( int[] vertice in edges)
            {
                if (!visited.Contains(i))
                {
                    //Traverse graph starting at this vertice
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);

                    while (queue.Count > 0) 
                    {
                        int visiting = queue.Dequeue();
                        if (visited.Contains(visiting))
                            return true;

                        visited.Add(visiting);

                        foreach ( int adjacent in edges[visiting]) 
                        {
                            queue.Enqueue(adjacent);
                        }
                    }
                }
                i++;
            }

            return false;
        }
        public static void TestCycleInGraph()
        {
            // Graph represented as an Adjacent List
            int[][] edges = new int[][]
            {
                new int[] { 1, 3},
                new int[] { 2, 3, 4},
                new int[] { 0},
                new int[] { },
                new int[] { 2, 5},
                new int[] { },
            };

            Console.WriteLine(CycleInGraph(edges));
            Console.WriteLine("Expected: true");

            edges = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2 },
                new int[] { }
            };

            Console.WriteLine(CycleInGraph(edges));
            Console.WriteLine("Expected: false");

        }
        #endregion
        #region RemoveIsland
        /*
         * https://www.algoexpert.io/questions/Remove%20Islands
         */
        public static int[][] RemoveIslands(int[][] matrix)
        {
            // visited map
            bool[,] visited = new bool[matrix.Length, matrix[0].Length];

            // valid island head positions
            List<int[]> validIslandHeads = new List<int[]>();

            // dictionary with islands heads and nodes list
            Dictionary<int[], List<int[]>> islands = new Dictionary<int[], List<int[]>>();

            // traverse matrix - except borders - lets look for possible islands
            for ( int i = 1; i<matrix.Length-1; i++) 
            {
                for ( int j =1; j<matrix[0].Length-1; j++)
                {
                    // Check for not visited nodes, with 1
                    if ( matrix[i][j] == 1 && !visited[i,j])
                    {
                        // Flat indicating its a valid island
                        bool islandIsValid = true;

                        // Insert in all islands map
                        int[] head = new int[] { i, j };
                        islands.Add(head, new List<int[]>());

                        // From node i, j - lets look for all neighbors iqual 1, using Graph Deep First Search
                        Stack<int[]> stack = new Stack<int[]>();
                        stack.Push(new int[] { i, j });

                        while (stack.Count > 0)
                        {
                            // Pop next node and mark as visited
                            int[] node = stack.Pop();
                            visited[node[0], node[1]] = true;

                            // Insert node into all islands list
                            islands[head].Add(new int[] { node[0], node[1] });

                            // Check if this node touches border and invalidate this island
                            if (node[0] == 0 || node[0] == matrix.Length - 1 || node[1] == 0 || node[1] == matrix[0].Length - 1)
                                islandIsValid = false;

                            // Check all not visited neighbors, with one, and push to visit them
                            // UP
                            if (node[0] > 0 && !visited[node[0] - 1, node[1]] & matrix[node[0]-1][node[1]]==1)
                                stack.Push(new int[] { node[0] - 1, node[1] });
                            // Right
                            if (node[1] < matrix[0].Length-1 && !visited[node[0], node[1]+1] & matrix[node[0]][node[1]+1] == 1)
                                stack.Push(new int[] { node[0], node[1] + 1});
                            // Down
                            if (node[0] < matrix.Length - 1 && !visited[node[0]+1, node[1]] & matrix[node[0] + 1][node[1]] == 1)
                                stack.Push(new int[] { node[0] + 1, node[1] });
                            // Left
                            if (node[1] > 0 && !visited[node[0], node[1]-1] & matrix[node[0]][node[1]-1] == 1)
                                stack.Push(new int[] { node[0], node[1] - 1 });
                        }

                        // After visited all island, if its valid, save its head
                        if (islandIsValid)
                            validIslandHeads.Add(head);
                    }
                }
            }

            // Now lets erase all valid islands
            foreach ( int[] head in validIslandHeads)
            {
                foreach ( int[] node in islands[head])
                {
                    matrix[node[0]][node[1]] = 0;
                }
            }

            return matrix;
        }
        public static void TestRemoveIslands()
        {
            int[][] input = new int[][]
            { 
                new int[] { 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 1, 0, 1, 1, 1 },
                new int[] { 0, 0, 1, 0, 1, 0 },
                new int[] { 1, 1, 0, 0, 1, 0 },
                new int[] { 1, 0, 1, 1, 0, 0 },
                new int[] { 1, 0, 0, 0, 0, 1 }
            };
            int[][] expectedOutput = new int[][]
            {
                new int[]{ 1, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 1, 1, 1 },
                new int[]{ 0, 0, 0, 0, 1, 0 },
                new int[]{ 1, 1, 0, 0, 1, 0 },
                new int[]{ 1, 0, 0, 0, 0, 0 },
                new int[]{ 1, 0, 0, 0, 0, 1 }
            };

            int[][] output = RemoveIslands(input);

            Console.WriteLine(String.Join("\n", output.ToList().Select(p => String.Join(",", p.ToList()))));
            Console.WriteLine("Expected:");
            Console.WriteLine(String.Join("\n",expectedOutput.ToList().Select(p=>String.Join(",",p.ToList()))));

        }
        #endregion
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
