using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hard_1
{
    class _425WordSquare : ILeetCode
    {
        public void DoIt()
        {
            string[] words = { "area", "lead", "wall", "lady", "ball" };
            Printers.PrintListList(WordSquares(words));
        }

        public IList<IList<string>> WordSquares(string[] words)
        {
            IList<IList<string>> ans = new List<IList<string>>();

            mTrieRoot = new Trie(words);

            Helper("", 0, words, new List<string>(), ans);

            return ans;
        }
        private Trie mTrieRoot;

        private void Helper(string pre, int level, string[] words, List<string> ls, IList<IList<string>> ans)
        {
            if (level == words[0].Length)
            {
                GenerateResult(ans, ls);
                //ans.Add(new List<string>(ls));
                return;
            }

            foreach (string s in mTrieRoot.FindStartsWith(pre))
            {
                ls.Add(s);
                string nextPre = "";
                for (int j = 0; j < ls.Count() && level < words[0].Length - 1; j++)
                {
                    nextPre += ls[j][level + 1].ToString();
                }
                Helper(nextPre, level + 1, words, ls, ans);
                ls.RemoveAt(ls.Count() - 1);
            }
        }

        private void GenerateResult(IList<IList<string>> ans, List<string> ls)
        {
            List<string> list = new List<string>();
            foreach (string s in ls)
            {
                list.Add(s);
            }
            ans.Add(list);
        }

        class TrieNode
        {
            public List<string> Words { get; set; }
            public TrieNode[] Children { get; set; }
            public TrieNode()
            {
                Words = new List<string>();
                Children = new TrieNode[26];
            }
        }

        class Trie
        {
            private TrieNode mRoot;
            public Trie(string[] words)
            {
                mRoot = new TrieNode();
                foreach (string word in words)
                {
                    TrieNode node = mRoot;
                    foreach (char c in word)
                    {
                        int index = c - 'a';
                        if (node.Children[index] == null)
                        {
                            node.Children[index] = new TrieNode();
                        }
                        node.Words.Add(word);
                        node = node.Children[index];
                    }
                }
            }

            public List<string> FindStartsWith(string pre)
            {
                TrieNode node = mRoot;
                foreach (char c in pre)
                {
                    int index = c - 'a';
                    if (node.Children[index] != null)
                    {
                        node = node.Children[index];
                    }
                    else
                    {
                        return new List<string>();
                    }
                }
                return node.Words;
            }
        }
    }
}
