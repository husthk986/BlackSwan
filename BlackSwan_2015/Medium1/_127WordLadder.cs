using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    internal class _127WordLadder : ILeetcode
    {
        public void DoIt()
        {
            string beginWord = "leet";
            string endWord = "code";
            HashSet<string> hs = new HashSet<string>() {"lest", "leet", "lose", "code", "lode", "robe", "lost"};

            Console.WriteLine("Should be 6: " + LadderLength(beginWord, endWord, hs));

        }

        public int LadderLength(string beginWord, string endWord, ISet<string> wordList)
        {
            if (wordList == null)
            {
                return 0;
            }
            if (beginWord.Equals(endWord))
            {
                return 1;
            }

            Queue<string> queue = new Queue<string>();
            HashSet<string> hs = new HashSet<string>();
            queue.Enqueue(beginWord);
            hs.Add(beginWord);

            wordList.Add(endWord);
            int len = 1;
            while (queue.Any())
            {
                len++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    string now = queue.Dequeue();
                    foreach (string nextWord in GetNextWord(now, wordList))
                    {
                        if (hs.Contains(nextWord))
                        {
                            continue;
                        }

                        if (nextWord.Equals(endWord))
                        {
                            return len;
                        }

                        hs.Add(nextWord);
                        queue.Enqueue(nextWord);
                    }
                }
            }

            return 0;
        }

        private List<string> GetNextWord(string word, ISet<string> wordList)
        {
            List<string> ls = new List<string>();
            foreach (string w in wordList)
            {
                if (OneLetterDiff(w, word))
                {
                    ls.Add(w);
                }
            }

            return ls;
        }

        private bool OneLetterDiff(string s1, string s2)
        {
            int[] strChars = new int[256];
            foreach (char c in s1)
            {
                strChars[c]++;
            }

            foreach (char c in s2)
            {
                strChars[c]--;
            }

            int posOneCount = 0, negOneCount = 0;
            foreach (int i in strChars)
            {
                if (i == 1)
                {
                    posOneCount++;
                }
                else if (i == -1)
                {
                    negOneCount++;
                }
            }

            return posOneCount == 1 && negOneCount == 1;
        }
    }
}
