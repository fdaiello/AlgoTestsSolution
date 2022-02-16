using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTests
{
    public class StackSolutions
    {
		public static void TestStack()
        {
			MinMaxStack stack = new MinMaxStack();

			stack.Push(1);
			stack.Push(5);
			stack.Push(10);
			Console.WriteLine(stack.GetMax());
			Console.WriteLine(stack.GetMin());
			Console.WriteLine(stack.Peek());
			stack.Pop();
			Console.WriteLine(stack.GetMax());
        }
    }

	public class MinMaxStack
	{
		private List<int> stack = new List<int>();
		private int min = int.MaxValue;
		private int max = int.MinValue;

		public int Peek()
		{
			if (! stack.Any())
				throw new IndexOutOfRangeException("Stack is empty");

			return stack[stack.Count - 1];
		}

		public int Pop()
		{
			if (!stack.Any())
				throw new IndexOutOfRangeException("Stack is empty");

			int pop = stack[stack.Count - 1];
			stack.RemoveAt(stack.Count - 1);
			return pop;
		}


		public void Push(int number)
		{
			stack.Add(number);
		}


		public int GetMin()
		{
			return stack.Min();
		}


		public int GetMax()
		{
			return stack.Max();
		}
	}
}
