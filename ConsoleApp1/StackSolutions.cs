using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTests
{
    public class StackSolutions
    {
		#region SunsetViews
		/*
		 * https://www.algoexpert.io/questions/Sunset%20Views
		 */
		public static List<int> SunsetViews(int[] buildings, string direction)
		{
			List<int> ret = new List<int>();

			int maxHeight = int.MinValue;

			if (direction == "EAST")
            {
				for ( int i = buildings.Length-1; i>=0; i--)
                {
					if (buildings[i] > maxHeight)
                    {
						ret.Add(i);
						maxHeight = buildings[i];
					}
                }
            }
			else
            {
				for (int i = 0; i <buildings.Length; i++)
				{
					if (buildings[i] > maxHeight)
					{
						ret.Add(i);
						maxHeight = buildings[i];
					}
				}
			}

			ret.Sort();
			return ret;
		}

		public static void TestSunsetViews()
        {
			int[] buildings = new int[] { 3, 5, 4, 4, 3, 1, 3, 2 };
			string direction = "EAST";

			Console.WriteLine(String.Join(",",SunsetViews(buildings,direction)));
			Console.WriteLine("Expected: 1,3,6,7");

        }
		#endregion

		#region BalancedBrackets
		/*
		 * https://www.algoexpert.io/questions/Balanced%20Brackets
		 */
		public static bool BalancedBrackets(string str)
		{
			Stack<char> stack = new Stack<char>();
			char current;

			for ( int i =0; i<str.Length; i++)
            {
				current = str[i];
				if (current == '[' || current == '{' || current == '(')
                {
					stack.Push(current);
                }
				else if (current == ']' || current == '}' || current == ')')
                {
					if ( stack.Count == 0)
                    {
						return false;
                    }
					else
                    {
						char last = stack.Pop();
						if ( (current==']' && last!='[') || (current == '}' && last != '{') || (current == ')' && last != '('))
                        {
							return false;
                        }
                    }
                }
            }

			if (stack.Count == 0)
				return true;
			else
				return false;

		}
		public static void TestBalancedBrackets()
        {
			string s = "[[[{{{((()))}}}]]]";
			Console.WriteLine(BalancedBrackets(s));
			Console.WriteLine("Expected: True");

			s = "[[[{{{((())}})}]]]";
			Console.WriteLine(BalancedBrackets(s));
			Console.WriteLine("Expected: False");

			s = "[[[5{{4{(3(2(1)))}}}]]";
			Console.WriteLine(BalancedBrackets(s));
			Console.WriteLine("Expected: False");

			s = "[[[5{{4(3(2(1)))}}}]";
			Console.WriteLine(BalancedBrackets(s));
			Console.WriteLine("Expected: False");
		}
		#endregion BalancedBrackets

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
