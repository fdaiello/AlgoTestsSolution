using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
    class TrieSolutions
    {
		#region SuffixTrieConstructions
		/*
         *  https://www.algoexpert.io/questions/Suffix%20Trie%20Construction
         */
		// Do not edit the class below except for the
		// PopulateSuffixTrieFrom and Contains methods.
		// Feel free to add new properties and methods
		// to the class.
		public class TrieNode
		{
			public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
		}

		public class SuffixTrie
		{
			public TrieNode root = new TrieNode();
			public char endSymbol = '*';

			public SuffixTrie(string str)
			{
				PopulateSuffixTrieFrom(str);
			}

			public void PopulateSuffixTrieFrom(string str)
			{
				// for all suffixes of str
				for ( int i =0; i<str.Length; i++)
                {
					TrieNode p = root;

					// for all chars of suffix
					for ( int j=i; j<str.Length; j++)
                    {
						if (p.Children.ContainsKey(str[j]))
						{
							p = p.Children[str[j]];
						}
						else
                        {
							p.Children.Add(str[j], new TrieNode());
							p = p.Children[str[j]];
                        }
					}

					p.Children.Add(endSymbol, null);
				}
			}

			public bool Contains(string str)
			{
				TrieNode p = root;
				foreach ( char c in str)
                {
					if (p.Children.ContainsKey(c))
                    {
						p = p.Children[c];
                    }
					else
                    {
						return false;
                    }
                }
				if (p.Children.ContainsKey(endSymbol))
                {
					return true;
                }
				else
                {
					return false;
				}
			}
		}
		public static void TestSuffixTrie()
        {
			string str = "babc";
			SuffixTrie trie = new SuffixTrie(str);

			Console.WriteLine(trie.Contains("bfc"));
        }
		#endregion
	}
}
