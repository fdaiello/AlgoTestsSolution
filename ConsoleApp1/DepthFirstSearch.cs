using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    /*
     DEEP First Search

      You're given a <span>Node</span> class that has a <span>name</span> and an
    array of optional <span>children</span> nodes. When put together, nodes form
    an acyclic tree-like structure.

      Implement the depthFirstSearch method on the
    Node class, which takes in an empty array, traverses the tree
    using the Depth-first Search approach (specifically navigating the tree from
    left to right), stores all of the nodes' names in the input array, and returns
    it.

    Sample Input

        A
     /  |  \
    B   C   D
   / \     / \
  E   F   G   H
     / \   \
    I   J   K


    Sample Output
    ["A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"]

     */
    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public List<string> DepthFirstSearch(List<string> array)
        {
            DeepFirstSearchNode(array);
            return array;
        }
        public void DeepFirstSearchNode(List<string> stringList)
        {
            stringList.Add(this.name);

            foreach (Node childNode in children)
            {
                childNode.DeepFirstSearchNode(stringList);
            }

        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }
    }
}
