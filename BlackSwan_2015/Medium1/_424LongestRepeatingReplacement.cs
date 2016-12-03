using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _424LongestRepeatingReplacement : ILeetcode
    {
        public void DoIt()
        {
            Console.WriteLine("Should be 2: {0}", CharacterReplacement("ABAA", 0));
            Console.WriteLine("Should be 4: {0}", CharacterReplacement("ABAB", 2));
            Console.WriteLine("Should be 4: {0}", CharacterReplacement("AABABBA", 1));
            Console.WriteLine("Should be 7: {0}", CharacterReplacement("AABAACDEFGAGIKAKKBKKOPQ", 2));
        }

        public int CharacterReplacement(string s, int k)
        {
            //If there's no constrain, like k, the problem is find the minimum changes which convert the string to another string with unique character.
            //then the problem is (length of string - length of maximum occurring unique character).

            //With constrain, the problem is find longest (length of substring - length of maximum occuring unqiue character) < k

            //AABCAADEFGKAKKBKKYX: k=2. In this case, both A and K are 5, but convert A and B between Ks is better than convert B and C between As.
            if (string.IsNullOrEmpty(s)) return 0;
            if (s.Length <= 2) return Math.Min(s.Length, k + 1);

            char[] array = s.ToCharArray();
            int maxSub = 0;
            int frontPointer = 0;
            int backPointer = 0;
            int result = 0;

            Dictionary<char, int> dictCharacter = new Dictionary<char, int>();
            while (frontPointer < array.Length)
            {
                if (!dictCharacter.ContainsKey(array[frontPointer]))
                {
                    dictCharacter.Add(array[frontPointer], 0);
                }

                if (++dictCharacter[array[frontPointer]] > maxSub)
                {
                    maxSub = dictCharacter[array[frontPointer]];
                }

                while (frontPointer - backPointer + 1 - maxSub > k)
                {
                    dictCharacter[array[backPointer]]--;
                    backPointer++;

                    maxSub = FindMaxSub(dictCharacter);
                }

                result = Math.Max(result, frontPointer - backPointer + 1);
                frontPointer++;
            }

            return result;
        }

        private int FindMaxSub(Dictionary<char, int> dictCharacter)
        {
            int result = 0;
            foreach (KeyValuePair<char, int> pair in dictCharacter)
            {
                if (result < pair.Value)
                {
                    result = pair.Value;
                }
            }

            return result;
        }
    }
}
