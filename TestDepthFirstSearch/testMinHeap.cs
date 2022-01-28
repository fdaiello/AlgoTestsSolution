using System;
using System.Collections.Generic;
using NUnit.Framework;
using AlgoTests;

namespace TestUnits
{
    class testMinHeap
    {
        [Test]
        public void MinHeapTest1()
        {
            List<int> array = new List<int> { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 };

            MinHeap heap = new MinHeap(array);

            Console.WriteLine($"Heap: {heap}");

            Assert.True(heap.Peek() == -5);


        }
        [Test]
        public void MinHeapTest2()
        {
            List<int> array = new List<int> {48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41};

            MinHeap heap = new MinHeap(array);

            heap.Insert(76);

            Console.WriteLine($"Heap: {heap.ToString()}");

            heap.Remove();

            Console.WriteLine($"Heap: {heap.ToString()}");

            heap.Remove();

            Console.WriteLine($"Heap: {heap.ToString()}");

            heap.Insert(87);

            Console.WriteLine($"Heap: {heap.ToString()}");
        }
    }
}
