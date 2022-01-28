using System.Collections.Generic;

namespace AlgoTests
{
	public class MinHeap
	{
		public List<int> heap = new List<int>();

		public MinHeap(List<int> array)
		{
			heap = buildHeap(array);
		}

		public List<int> buildHeap(List<int> array)
		{
			List<int> tmpArray = new List<int>();
			for ( int x=0; x< array.Count; x++)
            {
				tmpArray.Add(array[x]);
				if (x > 0)
                {
					siftUp(x, tmpArray);
                }
            }
			return tmpArray;
		}

		public void siftDown(int currentIdx, int endIdx, List<int> heap)
		{
			int child1 = Child1(currentIdx);
			int child2 = Child2(currentIdx);

			if ( child1 < heap.Count && ( child2 >= heap.Count || heap[child1] < heap[child2]))
            {
				if ( heap[child1] < heap[currentIdx])
                {
					int temp = heap[child1];
					heap[child1] = heap[currentIdx];
					heap[currentIdx] = temp;
					siftDown(child1, 0, heap);
                }
            }
			else if ( child2 < heap.Count)
            {
				if (heap[child2] < heap[currentIdx])
				{
					int temp = heap[child2];
					heap[child2] = heap[currentIdx];
					heap[currentIdx] = temp;
					siftDown(child2, 0, heap);
				}
			}

		}

		public void siftUp(int currentIdx, List<int> heap)
		{
			if (currentIdx > 0)
            {
				int parent = Parent(currentIdx);
				if (heap[parent] > heap[currentIdx])
                {
					int temp = heap[parent];
					heap[parent] = heap[currentIdx];
					heap[currentIdx] = temp;
					siftUp(parent, heap);
                }
            }
		}

		public int Peek()
		{
			return heap[0];
		}

		public int Remove()
		{
			int temp = Peek();
			int farthest = heap[heap.Count - 1];
			heap[0] = farthest;
			heap.RemoveAt(heap.Count - 1);
			siftDown(0,0,heap);
			return temp;
		}

		public void Insert(int value)
		{
			heap.Add(value);
			siftUp(heap.Count - 1, heap);
		}
		private static int Parent(int index)
        {
			return (index - 1) / 2;
        }
		private static int Child1(int index)
        {
			return 2 * index + 1;
        }
		private static int Child2(int index)
        {
			return 2 * index + 2;
        }
	}
}
