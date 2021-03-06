using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class LinkedListSolutions
    {
		#region ClassLinkedList
		public class LinkedList
		{
			public int Value;
			public LinkedList Next = null;

			public LinkedList(int value)
			{
				this.Value = value;
			}
		}
		#endregion
		#region FindTheLoop
		/*
		 * https://www.algoexpert.io/questions/Find%20Loop
		 */
		public static LinkedList FindLoop(LinkedList head)
		{
			if (head == null || head.Next == null)
				return head;

			LinkedList p1 = head.Next;
			LinkedList p2 = head.Next.Next;

			while (p1 != p2)
			{
				p1 = p1.Next;
				p2 = p2.Next.Next;
			}

			p1 = head;

			while (p1 != p2)
			{
				p1 = p1.Next;
				p2 = p2.Next;
			}

			return p1;
		}

		// The following solution does NOT respect the Space Complexity stated of O(1)
		public static LinkedList FindLoop0(LinkedList head)
		{
			if (head == null)
				return head;

			HashSet<LinkedList> visited = new HashSet<LinkedList>();

			while (head != null)
			{
				if (visited.Contains(head))
					return head;

				visited.Add(head);
				head = head.Next;
			}

			return head;
		}
		public static void TestFindTheLoop()
		{
			LinkedList p1 = new LinkedList(0);
			LinkedList head = p1;
			LinkedList pLoop = null;
			for (int i = 1; i < 10; i++)
			{
				LinkedList p2 = new LinkedList(i);
				p1.Next = p2;
				p1 = p2;
				if (i == 4)
					pLoop = p2;
			}
			p1.Next = pLoop;

			Console.WriteLine(FindLoop(head).Value);
			Console.WriteLine("Expected: 4");
		}
		#endregion
		#region ReverseLinkedList
		public static LinkedList ReverseLinkedList(LinkedList head)
		{
			if (head == null && head.Next == null)
				return head;

			var p1 = head;
			var p2 = head.Next;
			LinkedList p3;

			while ( p2 != null)
            {
				p3 = p2.Next;
				p2.Next = p1;
				p1 = p2;
				p2 = p3;
            }

			head.Next = null;
			return p1;

		}
		public static void TestReverseLikedList()
        {
			var head = new LinkedList(1);
			head.Next = new LinkedList(2);
			head.Next.Next = new LinkedList(3);
			head.Next.Next.Next = new LinkedList(4);

			var head2 = ReverseLinkedList(head);
            while (head2 != null)
            {
				Console.Write(head2.Value + "->");
				head2 = head2.Next;
            }
        }
		#endregion
		#region SumOfLinkedList
		/*
		 * https://www.algoexpert.io/questions/Sum%20of%20Linked%20Lists
		 */
		public static LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
		{

			int n1 = 0;
			int c1 = 1;
			while ( linkedListOne != null)
            {
				n1 = n1 + linkedListOne.Value * c1;
				c1*=10;
				linkedListOne = linkedListOne.Next;
            }

			int n2 = 0;
			int c2 = 1;
			while (linkedListTwo != null)
			{
				n2 = n2 + linkedListTwo.Value * c2;
				c2 *= 10;
				linkedListTwo = linkedListTwo.Next;
			}

			int n3 = n1 + n2;

			LinkedList digit;
			LinkedList digitAnt = null;
			LinkedList digitFirst = null;

			if (n3 == 0)
				return new LinkedList(0);

			while ( n3 > 0)
            {
				digit = new LinkedList(n3 % 10);
				if (digitAnt != null)
					digitAnt.Next = digit;
				if (digitFirst == null)
					digitFirst = digit;
				digitAnt = digit;

				n3 /= 10;

			}

			return digitFirst;
		}
		public static void TestSumOfLinkedList()
        {
			LinkedList l2 = new LinkedList(0);
			LinkedList l4 = new LinkedList(0);
			LinkedList l7 = new LinkedList(0);
			LinkedList l1 = new LinkedList(5);
			l2.Next = l4;
			l4.Next = l7;
			l7.Next = l1;

			LinkedList l9 = new LinkedList(9);
			//LinkedList l4b = new LinkedList(4);
			//LinkedList l5 = new LinkedList(5);
			//l9.Next = l4b;
			//l4b.Next = l5;

			LinkedList Result = SumOfLinkedLists(l2, l9);

			while ( Result != null)
            {
				Console.Write(Result.Value);
				Result = Result.Next;
            }


			
		}
		#endregion
		#region RemoveKthNodeFromEnd
		/*
		 * https://www.algoexpert.io/questions/Remove%20Kth%20Node%20From%20End
		 */
		public static void RemoveKthNodeFromEnd(LinkedList head, int k)
		{

			LinkedList p = head;
			LinkedList kTh = null;
			LinkedList kThPrev = null;

			while (p != null)
            {
				p = p.Next;
				if (kTh != null)
				{
					kTh = kTh.Next;
				}
				else if (k == 1)
                {
					kTh = head;
                }
				if (kThPrev != null)
				{
					kThPrev = kThPrev.Next;
				}
				else if (k == 0)
				{
					kThPrev = head;
				}
				k--;
			}

			if (kThPrev != null)
            {
				kThPrev.Next = kTh.Next;
			}
			else
            {
				head.Value = head.Next.Value;
				head.Next = head.Next.Next;
			}

		}
		public static void TestRemoveKthNodeFromEnd()
        {
			LinkedList node = new LinkedList(0)
            {
				Next = new LinkedList(1)
				{
					Next = new LinkedList(2)
					{
						Next = new LinkedList(3)
						{
							Next = new LinkedList(4)
							{
								Next = new LinkedList(5)
								{
									Next = new LinkedList(6)
									{
										Next = new LinkedList(7)
										{
											Next = new LinkedList(8)
											{
												Next = new LinkedList(9)
											}
										}
									}

								}
							}
						}
					}
				}
			};

			RemoveKthNodeFromEnd(node, 10);
			while (node != null)
            {
				Console.Write(node.Value + "->");
				node = node.Next;
			}

		}
		#endregion
		#region DoubleLinkedList
		public static void TestDoubleLinkedList()
        {
			DoublyLinkedList dbList = new DoublyLinkedList();


			Node N1 = new Node(1);
			Node N2 = new Node(2);
			Node N3 = new Node(3);
			Node N4 = new Node(4);
			Node N5 = new Node(5);
			Node N6 = new Node(6);
			Node N7 = new Node(7);


			dbList.SetHead(N1);
			dbList.InsertAfter(N1, N2);
			dbList.InsertAfter(N2, N3);
			dbList.InsertAfter(N3, N4);
			dbList.InsertAfter(N4, N5);
			dbList.InsertAfter(N5, N6);
			dbList.InsertAfter(N6, N7);

			dbList.InsertAtPosition(2, N1);

			// Print list
			Node p = dbList.Head;
			while (p != null)
			{
				Console.Write(p.Value + "->");
				p = p.Next;
			}
			Console.WriteLine();

			p = dbList.Tail;
			while (p != null)
			{
				Console.Write(p.Value + "<-");
				p = p.Prev;
			}
			Console.WriteLine();
			Console.WriteLine($"Head: {dbList.Head.Value}, Tail: {dbList.Tail.Value}");


		}
		public static void TestDoubleLinkedList0()
        {
			DoublyLinkedList dbList = new DoublyLinkedList();

			dbList.SetHead(new Node(0));

			Node N1 = new Node(1);
			Node N7 = new Node(7);
			Node N8 = new Node(8);
			Node N2 = new Node(2);
			Node N4 = new Node(4);

			Node N22 = new Node(22);
			Node N11 = new Node(11);

			dbList.InsertAtPosition(1, N7);
			dbList.InsertAtPosition(1, N2);
			dbList.InsertAtPosition(1, N1);
			dbList.InsertAtPosition(3, new Node(3));
			dbList.InsertAtPosition(4, N4);


			dbList.InsertBefore(N7, new Node(6));
			dbList.InsertAfter(N7, N8);
			dbList.InsertAfter(N2, N22);
			dbList.InsertAfter(N4, new Node(5));
			dbList.InsertBefore(N2, N11);


            dbList.RemoveNodesWithValue(11);
            dbList.RemoveNodesWithValue(22);

            //dbList.Remove(N1);
            //dbList.Remove(N8);

            //dbList.SetHead(N4);
            dbList.SetTail(N4);

			Node N100 = new Node(100);
			dbList.SetTail(N100);

			dbList.InsertAfter(N100, N1);
			dbList.InsertBefore(N2, N1);

            // Print list
            Node p = dbList.Head;
			while (p != null)
            {
				Console.Write(p.Value + "->");
				p = p.Next;
			}
			Console.WriteLine();

			p = dbList.Tail;
			while (p != null)
			{
				Console.Write(p.Value + "<-");
				p = p.Prev;
			}
			Console.WriteLine();
			Console.WriteLine($"Head: {dbList.Head.Value}, Tail: {dbList.Tail.Value}");
			Console.WriteLine($"Contains Node with value 1: {dbList.ContainsNodeWithValue(1)}; Contains Node with value 2: {dbList.ContainsNodeWithValue(2)} ");

		}

        public class DoublyLinkedList
		{
			public Node Head;
			public Node Tail;

			public void SetHead(Node node)
			{
				if (Head==null)
                {
					Head = Tail = node;
                }
				else if (node != Head)
                {
					InsertBefore(Head, node);
				}
			}

			public void SetTail(Node node)
			{
				if ( Head == null )
				{
					Head = Tail = node;
				}
				else if (node != Tail)
                {

					InsertAfter(Tail, node);
				}
			}

			public void InsertBefore(Node node, Node nodeToInsert)
			{

				if (nodeToInsert.Next == node)
					return;

				Node p = Head;
				while (p != node && p != null)
                {
					p = p.Next;
                }
				if (p != null)
                {

					if (nodeToInsert == Head)
						Head = nodeToInsert.Next;
					if (nodeToInsert == Tail)
						Tail = nodeToInsert.Prev;

					if (p.Prev != null)
						p.Prev.Next = nodeToInsert;

					if (nodeToInsert.Prev != null)
						nodeToInsert.Prev.Next = nodeToInsert.Next;
					if (nodeToInsert.Next != null)
						nodeToInsert.Next.Prev = nodeToInsert.Prev;

					nodeToInsert.Next = p;
					nodeToInsert.Prev = p.Prev;

					p.Prev = nodeToInsert;

					if (node == Head)
						Head = nodeToInsert;
				}
                else
                {
					throw new ArgumentException("Node not found");
                }
			}

			public void InsertAfter(Node node, Node nodeToInsert)
			{
				Node p = Head;
				while (p != node && p != null)
				{
					p = p.Next;
				}
				if (p != null)
				{
					if (nodeToInsert == Head)
						Head = nodeToInsert.Next;
					if (nodeToInsert == Tail)
						Tail = nodeToInsert.Prev;

					if (p.Next != null)
						p.Next.Prev = nodeToInsert;

					if (nodeToInsert.Prev != null)
						nodeToInsert.Prev.Next = nodeToInsert.Next;
					if (nodeToInsert.Next != null)
						nodeToInsert.Next.Prev = nodeToInsert.Prev;

					nodeToInsert.Prev = p;
					nodeToInsert.Next = p.Next;

					p.Next = nodeToInsert;

					if (node == Tail)
						Tail = nodeToInsert;
				}
				else
				{
					throw new ArgumentException("Node not found");
				}

			}

			public void InsertAtPosition(int position, Node nodeToInsert)
			{
				if (position < 1)
					throw new ArgumentOutOfRangeException("Postion must be greater than 1");

				if (position==1 && Head == null)
                {
					Head = nodeToInsert;
					Tail = nodeToInsert;
					return;
                }

				Node p = Head;
				int c = 1;
				while (c<position && p !=null)
				{
					p = p.Next;
					c++;
				}
				if (p != null)
				{
					InsertBefore(p, nodeToInsert);
				}
				else
				{
					throw new ArgumentException("Position out of range");
				}

				if (position == 1)
					Head = nodeToInsert;
			}

			public void RemoveNodesWithValue(int value)
			{
				Node p = Head;
				while ( p!= null)
                {
					if (p.Value == value)
                    {
						Remove(p);
						if (p == Head)
							Head = p.Next;
						if (p == Tail)
							Tail = p.Prev;
					}
					p = p.Next;
                }
			}

			public void Remove(Node node)
			{
				Node p = Head;
				while ( p != node && p!=null)
                {
					p = p.Next;
                }
				if (p == null)
                {
					throw new ArgumentException("Node not found");
                }
				else
                {
					if (p.Next !=null)
						p.Next.Prev = p.Prev;

					if (p.Prev != null)
						p.Prev.Next = p.Next;
                }

				if (node == Head)
					Head = node.Next;
				if (node == Tail)
					Tail = node.Prev;
			}

			public bool ContainsNodeWithValue(int value)
			{
				Node p = Head;
				while (p != null)
				{
					if (p.Value == value)
					{
						return true;
					}
					p = p.Next;
				}

				return false;
			}
		}

		// Do not edit the class below.
		public class Node
		{
			public int Value;
			public Node Prev;
			public Node Next;

			public Node(int value)
			{
				this.Value = value;
			}
		}
		#endregion
		#region RemoveDuplicate
		public static LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
		{
			LinkedList node = linkedList;

			do
			{
				if (node.Value == node.Next?.Value)
					node.Next = node.Next?.Next;
				else
					node = node.Next;

			} while (node != null);

			return linkedList;
		}
		public static void TestRemoveDuplicatesFromLinkedList()
		{
			LinkedList linkedList = new LinkedList(1)
			{
				Next = new LinkedList(1)
				{
					Next = new LinkedList(3)
					{
						Next = new LinkedList(4)
						{
							Next = new LinkedList(4)
							{
								Next = new LinkedList(4)
								{
									Next = new LinkedList(5)
									{
										Next = new LinkedList(6)
										{
											Next = new LinkedList(6)
										}
									}
								}
							}
						}
					}
				}
			};

			LinkedList linkedList1 = RemoveDuplicatesFromLinkedList(linkedList);

			do
			{
				Console.Write(linkedList1.Value + ",");
				linkedList1 = linkedList1.Next;
			} while (linkedList1 != null);

		}
		#endregion
	}
}
