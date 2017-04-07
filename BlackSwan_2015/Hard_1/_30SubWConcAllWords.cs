using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    internal class _30SubWConcAllWords : ILeetCode
    {
        public void DoIt()
        {
            string s = "wordgoodgoodgoodbestword";
            string[] words = {"word", "good", "best", "good"};
            foreach (var i in FindSubstring(s, words))
            {
                Console.WriteLine(i);
            }
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> ans = new List<int>();
            if (words == null || words.Count() == 0) return ans;

            Dictionary<string, int> found;
            Dictionary<string, int> toFind = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!toFind.ContainsKey(word))
                {
                    toFind.Add(word, 0);
                }
                toFind[word]++;
            }

            int wordsCount = words.Count(), singleLen = words[0].Length;
            int totalLen = wordsCount * singleLen;
            for (int i = 0; i <= s.Length - totalLen; i++)
            {
                found = new Dictionary<string, int>();

                int j = i;
                for (; j < i + totalLen; j += singleLen)
                {
                    string sub = s.Substring(j, singleLen);
                    if (!toFind.ContainsKey(sub))
                    {
                        break;
                    }

                    if (!found.ContainsKey(sub))
                    {
                        found.Add(sub, 0);
                    }
                    found[sub]++;

                    if (found[sub] > toFind[sub])
                    {
                        break;
                    }
                }
                if (j == i + totalLen)
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

        public IList<int> FindSubstring1(string s, string[] words)
        {

            IList<int> ans = new List<int>();
            for (int i = 0; i <= s.Length - words[0].Length * words.Count(); i++)
            {
                AddWordsToTrie(words);
                if (FindWord(s.Substring(i), words[0].Length, words.Count()))
                {
                    ans.Add(i);
                }
            }

            return ans;
        }

        private TrieNode root;
        private void AddWordsToTrie(string[] words)
        {
            root = new TrieNode();
            foreach (string word in words)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (node.Children[c] == null)
                    {
                        node.Children[c] = new TrieNode();
                    }

                    node = node.Children[c];
                }
                node.IsEndWord = true;
                node.WordCount++;
            }
        }
        private bool FindWord(string s, int singleWordLength, int wordsCount)
        {
            int index = 0;
            int count = 0;

            for (int i = 0; i < wordsCount; i++)
            {
                TrieNode node = root;
                for (int j = 0; j < singleWordLength; j++)
                {
                    if (node.Children[s[index]] == null)
                    {
                        return false;
                    }
                    else
                    {
                        node = node.Children[s[index]];
                    }
                    index++;
                }
                if (!node.IsEndWord || node.WordCount == 0)
                {
                    return false;
                }
                else
                {
                    count++;
                    node.WordCount--;
                }
            }

            if (count != wordsCount)
            {
                return false;
            }

            return true;
        }
    }
    public class TrieNode
    {
        public bool IsEndWord { get; set; }
        public int WordCount { get; set; }
        public TrieNode[] Children;
        public TrieNode()
        {
            Children = new TrieNode[256];
            IsEndWord = false;
            WordCount = 0;
        }
    }
}
