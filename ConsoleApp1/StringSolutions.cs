using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgoTests
{
    class StringSolutions
    {
        #region LongestSubstring
        public static string LongestSubstringWithoutDuplication(string str)
        {
            // pointer to longest string found
            int longestStart = 0;
            int longestLenght = 0;

            // pointer to current string beeing searched
            int thisStart = 0;
            int thisLenght = 0;

            // Traverse input string
            int i = 0;
            while ( i < str.Length) 
            {
                // Map with last position each char was found
                var map = new Dictionary<char, int>();

                // Loop substring
                while (i < str.Length)
                {
                    // Check if we found a duplicated char
                    if (map.ContainsKey(str[i]))
                    {
                        // Check if current substring beeing searched is greater than what we have seen before
                        if (thisLenght > longestLenght)
                        {
                            // Save its start and lenght
                            longestLenght = thisLenght;
                            longestStart = thisStart;
                        }

                        // Now we need to setup a new search from the next character after the first position of the duplicated one
                        thisStart = map[str[i]] + 1;
                        thisLenght = 0;
                        i = thisStart;
                        break;

                    }
                    // No duplicates up to here
                    else
                    {
                        // Add char to map, increase substring lenght
                        map.Add(str[i], i);
                        thisLenght++;
                    }

                    i++;

                }
            }

            // Check if current substring beeing searched is greater than what we have seen before
            if (thisLenght > longestLenght)
            {
                // Save its start and lenght
                longestLenght = thisLenght;
                longestStart = thisStart;
            }

            return str.Substring(longestStart, longestLenght);

        }
        public static void TestLongestSubstring() 
        {
            Console.WriteLine(LongestSubstringWithoutDuplication("abc"));
            Console.WriteLine("Expected: abc");

            Console.WriteLine(LongestSubstringWithoutDuplication("clementisacap"));
            Console.WriteLine("Expected: mentisac");

            Console.WriteLine(LongestSubstringWithoutDuplication("qwertyuiop"));
            Console.WriteLine("Expected: qwertyuiop");

            Console.WriteLine(LongestSubstringWithoutDuplication("qwertyuiopqwertyuiopasdqwertyuiopasdfghjqwertyuiopasdfghjkl"));
            Console.WriteLine("Expected: qwertyuiopasdfghjkl");

        }
        #endregion
        #region MinimumCharactersForWords
        /*
         * https://www.algoexpert.io/questions/Minimum%20Characters%20For%20Words
         */
        public static string[] MinimumCharactersForWords(string[] words)
        {
            Dictionary<char, int> allMap = new Dictionary<char, int>();

            foreach( string word in words)
            {
                Dictionary<char, int> thisMap = new Dictionary<char, int>();
                foreach ( char c in word)
                {
                    if (thisMap.ContainsKey(c))
                    {
                        thisMap[c]++;
                        if (allMap[c] < thisMap[c])
                            allMap[c] = thisMap[c];
                    }
                    else
                    {
                        thisMap.Add(c, 1);
                        if (!allMap.ContainsKey(c))
                        {
                            allMap.Add(c, 1);
                        }
                    }
                }
            }

            List<string> stringList = new List<string>();
            foreach ( KeyValuePair<char,int> kv in allMap)
            {
                for (int i = 0; i < kv.Value; i++)
                    stringList.Add(kv.Key.ToString());
            }

            return stringList.ToArray();
        }
        public static void TestMinimumCharactersForWords()
        {
            string[] words = new string[] { "this", "that", "did", "deed", "them!", "a" };

            Console.WriteLine(String.Join(",", MinimumCharactersForWords(words)));
            Console.WriteLine("Expected: \n't', 't', 'h', 'i', 's', 'a', 'd', 'd', 'e', 'e', 'm', '!'");

        }
        #endregion
        #region ReverseWordsInSTring
        /*
         *  https://www.algoexpert.io/questions/Reverse%20Words%20In%20String
         */
        public static string ReverseWordsInString(string str)
        {

            return String.Join(" ",str.Split(" ").Reverse());

        }
        public static void TestReverseWordsInString()
        {
            string s1 = "AlgoExpert is the Best!";
            Console.WriteLine(ReverseWordsInString(s1));
            Console.WriteLine("Expected: Best! the is AlgoExpert");
        }
        #endregion
        #region ValidIpAdress
        /*
         *  https://www.algoexpert.io/questions/Valid%20IP%20Addresses
         */
        public static List<string> ValidIPAddresses(string str, int level=0)
        {
            if (level == 3 && str.Length < 4 && Int32.Parse(str) < 256 && (str.Length == 1 || str[0] != '0'))
                return new List<string> { str };

            List<string> list = new List<string>();

            for (int i = 1; i < 4 && i < str.Length; i++)
            {
                if (int.Parse(str.Substring(0, i)) < 256 && (i == 1 || str[0] != '0'))
                {
                    var byteLists = ValidIPAddresses(str.Substring(i, str.Length - i), level + 1);
                    if (byteLists.Any())
                    {
                        foreach (string tByte in byteLists)
                        {
                            list.Add(str.Substring(0, i) + "." + tByte);
                        }
                    }
                }
            }

            return list;

        }
        public static void TestValidIpAdress()
        {
            string str = "1401221240";
            Console.WriteLine(String.Join("\n", ValidIPAddresses(str)));
        }
        #endregion
        #region GroupAnagrams
        /*
         * https://www.algoexpert.io/questions/Group%20Anagrams
         */
        public static List<List<string>> groupAnagrams(List<string> words)
        {
            List<List<string>> groups = new List<List<string>>();

            foreach ( string s in words)
            {
                bool found = false;
                foreach ( List<string> group in groups)
                {
                    if (IsAnagram(s, group[0]))
                    {
                        group.Add(s);
                        found = true;
                        break;
                    }
                }
                
                if (!found)
                {
                    groups.Add(new List<string>() { s });
                }

            }

            return groups;
        }
        public static void TestGroupAnagrams()
        {
            
            List<string> words = new List<string>() { "yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp" };

            Console.WriteLine("[" + String.Join(", ",  groupAnagrams(words).Select(p => "{" + string.Join(", ", p) + "}" )) + ']');

            Console.WriteLine("Expected: [[yo, oy], [flop, olfp], [act, tac, cat], [foo]]");

        }
        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var l2 = s2.ToList();
            foreach ( char c in s1)
            {
                if (l2.Contains(c))
                    l2.Remove(c);
                else
                    return false;
            }

            return true;
        }
        #endregion
        #region LongestPalindromicSubString
        /*
         * https://www.algoexpert.io/questions/Longest%20Palindromic%20Substring
         */

        public static string LongestPalindromicSubstring(string str)
        {
            if (str.Length < 2)
                return str;

            string longest = str[0].ToString() ;
            int c = 0;

            for ( int i=0; i<str.Length-1; i++)
            {
                if (str[i] == str[i + 1]) 
                {
                    // Treat even palindrome
                    c = 0;
                    while ( i-c >= 0 && i + c +1 < str.Length && str[i - c] == str[i + c + 1])
                    {
                       c++;
                    }
                    if ( longest.Length < c * 2)
                    {
                        longest = str.Substring(i - c + 1, c * 2);
                    }
                }
                if ( i<str.Length-2 && str[i] == str[i + 2])
                {
                    // Treat odd palindrome
                    c = 0;
                    while (i - c >= 0 && i + c + 2 < str.Length && str[i - c] == str[i + c + 2])
                    {
                        c++;
                    }
                    if (longest.Length < c * 2 + 1)
                    {
                        longest = str.Substring(i - c + 1, c * 2 + 1);
                    }
                }
            }

            return longest;
        }
        // Brute Force
        public static string LongestPalindromicSubstring1(string str)
        {
            // Shortcut
            if (str.Length < 2)
                return str;

            string largest=string.Empty;
            string sub;

            // Get all substrings
            for ( int i =0; i< str.Length; i++)
            {
                for ( int len=1; len<=str.Length-i; len++)
                {
                    sub = str.Substring(i, len);
                    if (IsPalindrome(sub) && sub.Length > largest.Length)
                        largest = sub;
                }
            }

            return largest;
        }
        // This version has a bug, i cannot lead with 'bbb' like palindromes
        public static string LongestPalindromicSubstring0(string str)
        {
            if (str.Length < 2)
                return str;

            string longestPalindrome = string.Empty;
            int lpstart = 0;
            int lpcount = 0;
            int delta = 0;
            bool inPalindrome  = false;

            for ( int i =1; i<str.Length; i++)
            {
                if (!inPalindrome)
                {
                    if (str[i] == str[i - 1])
                    {
                        delta = 0;
                        lpstart = i - 1;
                        lpcount = 1;
                        inPalindrome = true;
                        if (string.IsNullOrEmpty(longestPalindrome))
                            longestPalindrome = str.Substring(i - 1, 2);
                    }
                    else if ( i<str.Length-1 && str[i+1] == str[i - 1])
                    {
                        delta = 1;
                        lpstart = i - 1;
                        lpcount = 1;
                        inPalindrome = true;
                        if (longestPalindrome.Length<3)
                            longestPalindrome = str.Substring(i - 1, 3);
                        i++;
                    }
                }
                else
                {
                    if (lpstart - lpcount >= 0 && str[i] == str[lpstart - lpcount])
                    {
                        if ( longestPalindrome.Length < (lpcount + 1) * 2)
                        {
                            longestPalindrome = str.Substring(lpstart - lpcount, (lpcount+1) * 2 + delta);
                        }
                        lpcount++;
                    }
                    else
                    {
                        i = lpstart + 1 ;

                        inPalindrome = false;
                        lpstart = 0;
                        lpcount = 0;
                    }
                }
            }

            return longestPalindrome;
        }
        public static void TestLongestPalindromicSubstring()
        {
            string str;

            str = "bbb";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: bbb");

            str = "z234a5abbba54a32z";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: 5abbba5");

            str = "fabaf";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: fabaf");

            str = "abcdefgfedcba";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: abcdefgfedcba");

            str = "abcdefgfedcbaxxxxxxxxxxxx";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: \nxxxxxx");

            str = "abaxyzzyxf";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: xyzzyx");

            str = "noon";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: noon");

            str = "noon high it is";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: noon");

            str = "abcdefgfedcbazzzzzzzzzzzzzzzzzzzz";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: \nzzzzzzzzzzzzzzzzzzzz");

            str = "abcucba";
            Console.WriteLine(LongestPalindromicSubstring(str));
            Console.WriteLine("Expected: abcucba");

        }
        #endregion
        #region PalindromeCheck
        /*
         * Palindrome Check
         */
        public static bool IsPalindrome(string str)
        {

            // empty and 1 char lenght test
            if (str.Length == 0)
                return false;
            else if (str.Length == 1)
                return true;

            // Interate thru string to its middle, comparing com simetric position
            for (int x = 0; x < str.Length / 2; x++)
            {
                // Compare current position with simetric
                if (str.Substring(x, 1) != str.Substring(str.Length - 1 - x, 1))
                    return false;
            }

            return true;
        }
        public static void TestIsPalindrome()
        {
            string input = "arararas";

            Console.WriteLine($"String {input} palindrome check: {IsPalindrome(input)}");
        }
        #endregion
        #region CeaserCypher
        /*
         * Ceasar Cypher Encryption
         */
        public static string CaesarCypherEncryptor(string str, int key)
        {

            char[] chars = str.ToCharArray();

            // Iterate thru string
            for (int x = 0; x < str.Length; x++)
            {
                // Increment letter by key positions
                int p = (int)chars[x] + key;

                // If we got beyond z char
                while (p > (int)'z')
                {
                    p = (int)'a' + (p - (int)'z' - 1);
                }

                // Replace char from input string with shifted char
                str = str.Remove(x, 1);
                str = str.Insert(x, ((char)p).ToString());
            }

            return str;
        }
        public static void TestCeaserCypherEncryptor()
        {
            string input = "abcdefgtuvwzyz";
            int key = 30;

            Console.WriteLine($"The string {input} coded with Ceasar Encryptor is: {CaesarCypherEncryptor(input, key)}");
        }
        #endregion
        #region RunLengthEncoding
        /*
         *   Run Lenght encoding
         */
        public static string RunLengthEncoding(string str)
        {
            // initial lenght test
            if (str.Length == 0)
                return str;
            else if (str.Length == 1)
                return "1" + str;

            // store last char - initialize with first character from string
            string lastChar = null;

            // store continuous char count - number of instances of same char in string
            int charRepeat = 0;

            // sb will store our output - string builder is used for better performace as we are going to manipulate output string
            StringBuilder sb = new StringBuilder();

            // Iterate thru string, starting at the second position 
            for (int x = 0; x < str.Length; x++)
            {
                // Check if its the same char as the last one
                if (lastChar == null || lastChar == str.Substring(x, 1))
                {
                    // increment repeated char count
                    charRepeat++;

                    // if we reached 9 repeated chars
                    if (charRepeat == 9)
                    {
                        sb.Append("9" + lastChar);
                        charRepeat = 0;
                        lastChar = null;
                    }
                    else
                    {
                        // update last char
                        lastChar = str.Substring(x, 1);
                    }

                }
                else
                {

                    // Write repetition counter and last char to output stringbuilder
                    sb.Append(charRepeat.ToString() + lastChar);
                    charRepeat = 1;

                    // update last char
                    lastChar = str.Substring(x, 1);

                }

                // at the last element
                if (x == str.Length - 1)
                {
                    sb.Append(charRepeat.ToString() + lastChar);
                }

            }

            // returns string from sb
            return sb.ToString();
        }
        public static void TestRunLengthEncoding()
        {
            string input = "aaaaaaaaaaaaaaaaaaaabbbbbfghu";

            Console.WriteLine($"The string {input} Run Length encoded is : {RunLengthEncoding(input)}");
        }
        #endregion
        #region GenerateDocument
        /*
         * Generate Document
         */
        public static bool GenerateDocument(string characters, string document)
        {
            char[] array = characters.ToCharArray();

            for (int x = 0; x < document.Length; x++)
            {
                // Check if array contens document character
                int p = Array.IndexOf(array, document.Substring(x, 1).ToCharArray()[0]);

                // If it contains
                if (p >= 0)
                {
                    // Remove it from array - mark position with char null;
                    array[p] = (char)0;
                }
                // if it does not contains
                else
                {
                    return false;
                }
            }

            return true;
        }
        public static void TestGenerateDocument()
        {
            string availableChars = "Bste!hetsi ogEAxpelrt x ";
            string document = "AlgoExpert is the Best!!";

            Console.Write($"Generate Docoument: {GenerateDocument(availableChars, document)}");
        }
        #endregion
        #region FirstNonRepeatingCharacter
        public static int FirstNonRepeatingCharacter(string str)
        {
            // Dictionary to store characters and the quantity they appeared
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            // Iterate thru input string
            for (int x = 0; x < str.Length; x++)
            {
                // Gets character of x position
                string thisChar = str.Substring(x, 1);

                // Check if it is in the dictionary
                if (keyValuePairs.ContainsKey(thisChar))
                {
                    // if found, increment its counter
                    keyValuePairs[thisChar]++;
                }
                else
                {
                    // if not found, insert with 1 as counter
                    keyValuePairs.Add(thisChar, 1);
                }
            }

            // Iterante thru dictionary
            foreach (var item in keyValuePairs)
            {
                if (item.Value == 1)
                {
                    string firstChar = item.Key;
                    // Search position of firstChar at the input String
                    return str.IndexOf(firstChar);
                }
            }

            return -1;
        }
        public static void TestFirstNonRepeatingCharacter()
        {
            string input = "ax1xddffeebcdcafasdfasdfasdfghjdgfhdfghertwertwertç098765432";

            Console.WriteLine($"First NonRepeating Character of string {input} was found at position {FirstNonRepeatingCharacter(input)}");

        }
        #endregion

    }
}
