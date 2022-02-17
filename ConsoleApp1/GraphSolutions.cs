using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class GraphSolutions
    {
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
