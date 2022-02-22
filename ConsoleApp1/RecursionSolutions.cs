using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTests
{
    class RecursionSolutions
    {
        #region StaircaseTraversal
        /*
         *  https://www.algoexpert.io/questions/Staircase%20Traversal
         */
        public static int StaircaseTraversal(int height, int maxSteps)
        {
            int ways = 0;

            if (height < 2)
                return 1;

            else
            {
                for ( int i=1; i <= maxSteps && i <= height; i++)
                {
                    ways += StaircaseTraversal(height - i, maxSteps);
                }
            }

            return ways;
        }
        public static void TestStairCaseTraversal()
        {
            int height = 0;
            int steps = 2;
            Console.WriteLine(StaircaseTraversal(height, steps));
            Console.WriteLine("Expected: 1");

            height = 1;
            steps = 2;
            Console.WriteLine(StaircaseTraversal(height, steps));
            Console.WriteLine("Expected: 1");

            height = 2;
            steps = 2;
            Console.WriteLine(StaircaseTraversal(height, steps));
            Console.WriteLine("Expected: 2");

            height = 3;
            steps = 3;
            Console.WriteLine(StaircaseTraversal(height, steps));
            Console.WriteLine("Expected: 4");


            height = 4;
            steps = 2;

            Console.WriteLine(StaircaseTraversal(height, steps));
            Console.WriteLine("Expected: 5");

        }
        #endregion
        #region PhoneNumberMnemonics
        /*
         * https://www.algoexpert.io/questions/Phone%20Number%20Mnemonics
         */
        public static List<string> PhoneNumberMnemonics(string phoneNumber)
        {
            List<string> ret = new List<string>();

            if (phoneNumber.Length == 1)
            {
                ret = GetPattern(phoneNumber);
            }
            else
            {
                string firstChar = phoneNumber[0].ToString();
                string subStr = phoneNumber.Substring(1, phoneNumber.Length - 1);
                
                List<string> subList = PhoneNumberMnemonics(subStr);
                List<string> firstList = GetPattern(firstChar);

                foreach( string s in subList)
                {
                    foreach ( string f in firstList)
                    {
                        ret.Add(f+s);
                    }
                }
            }

            return ret;
        }
        public static List<string> GetPattern(string phoneNumber)
        {
            List<string> ret = new List<string>();

            switch (phoneNumber)
            {
                case "0":
                    ret.Add("0");
                    break;
                case "1":
                    ret.Add("1");
                    break;
                case "2":
                    ret.Add("a");
                    ret.Add("b");
                    ret.Add("c");
                    break;
                case "3":
                    ret.Add("d");
                    ret.Add("e");
                    ret.Add("f");
                    break;
                case "4":
                    ret.Add("g");
                    ret.Add("h");
                    ret.Add("i");
                    break;
                case "5":
                    ret.Add("j");
                    ret.Add("k");
                    ret.Add("l");
                    break;
                case "6":
                    ret.Add("m");
                    ret.Add("n");
                    ret.Add("o");
                    break;
                case "7":
                    ret.Add("p");
                    ret.Add("q");
                    ret.Add("r");
                    ret.Add("s");
                    break;
                case "8":
                    ret.Add("t");
                    ret.Add("u");
                    ret.Add("v");
                    break;
                case "9":
                    ret.Add("w");
                    ret.Add("x");
                    ret.Add("y");
                    ret.Add("z");
                    break;
            }

            return ret;
        }
        public static void TestPhoneNumberMenmonics()
        {
            string phoneNumber = "1905";
            Console.WriteLine(String.Join("\n", PhoneNumberMnemonics(phoneNumber)));
        }
        #endregion
        #region powerset
        /*
         * https://www.algoexpert.io/questions/Powerset
         */
        public static List<List<int>> Powerset(List<int> array)
        {
            if ( array.Count == 0)
            {
                return new List<List<int>>() { new List<int>() };
            }
            else if ( array.Count == 1)
            {
                return new List<List<int>>() { new List<int>(), array };
            }
            else
            {
                List<List<int>> ret = new List<List<int>>();

                int e = array[array.Count-1];
                List<int> arrayLess = new List<int>(array);
                arrayLess.RemoveAt(array.Count-1);

                List<List<int>> powersetLess = Powerset(arrayLess);

                foreach (List<int> subarray in powersetLess)
                {
                    ret.Add(new List<int>(subarray));

                    subarray.Add(e);
                    ret.Add(new List<int>(subarray));
                }

                return ret;
            }
        }
        public static void TestPowerset()
        {
            List<int> a = new List<int>() { };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1, 2 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");

            a = new List<int>() { 1, 2, 3 };
            Console.WriteLine("[" + String.Join("],[", Powerset(a).Select(p => "{" + String.Join("},{", p) + "}")) + "]");
        }
        #endregion
        #region Permutations
        /*
         * https://www.algoexpert.io/questions/Permutations
         */
        public static List<List<int>> GetPermutations(List<int> array)
        {

            List<List<int>> r = new List<List<int>>();

            if (array.Count == 0)
                return r;

            if ( array.Count < 2)
            {
                r.Add(array);
            }
            else
            {
                int p0 = array[0];
                List<int> r2 = array.GetRange(1, array.Count - 1);
                List<List<int>> r3 = GetPermutations(r2);
                foreach ( List<int> r4 in r3)
                {
                    for (int i =0; i<r4.Count; i++)
                    {
                        var r5 = r4.GetRange(0, r4.Count);
                        r5.Insert(i, p0);
                        r.Add(r5);
                    };
                    var r6 = r4.GetRange(0, r4.Count);
                    r6.Add(p0);
                    r.Add(r6);
                }
            }

            return r;
        }
        public static void TestGetPermutations()
        {
            List<int> a = new List<int>() { 1, 2, 3 };
            Console.Write(String.Join(" - ",GetPermutations(a).Select(p=>String.Join(",",p))));

            a = new List<int>() {  };
            Console.Write(String.Join(" - ", GetPermutations(a).Select(p => String.Join(",", p))));
        }
        #endregion
        #region Fibonacci
        /*
         * Fibonaci sequence
         */
        public static int GetNthFib(int n)
        {
            if (FibonaciCache is null)
                FibonaciCache = new Dictionary<int, int>();

            if (FibonaciCache.ContainsKey(n))
                return FibonaciCache[n];

            else
            {
                int result;

                if (n <= 0)
                    result = -1;
                else if (n == 1)
                    result = 0;
                else if (n == 2)
                    result = 1;
                else
                    result = GetNthFib(n - 1) + GetNthFib(n - 2);

                FibonaciCache.Add(n, result);
                return result;
            }

        }
        public static Dictionary<int, int> FibonaciCache { get; set; }

        public static void TestFibonaciSequence()
        {

            int n = 6;
            Console.WriteLine($"Fibonaci Sequence. Position {n} result is {GetNthFib(n)}");

        }
        #endregion
    }

}
