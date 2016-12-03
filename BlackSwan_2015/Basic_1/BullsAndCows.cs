using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class BullsAndCows
    {
        public void DoIt()
        {
            string[] secrets = { "1234", "1807", "1123", "11", "1122" };
            string[] guess = { "0111", "7810", "0111", "10", "0001" };

            for (int i = 0; i < secrets.Length; i++)
            {
                Console.WriteLine("Secret: {0}, Guess: {1}, Result: {2}", secrets[i], guess[i], GetHint4(secrets[i], guess[i]));
            }

        }

        private string GetHint4(string secret, string guess)
        {
            int aCount = 0, bCount = 0;

            List<char> guessO = new List<char>();
            Dictionary<char, int> secretO = new Dictionary<char, int>();

            for (int i = 0; i < guess.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    aCount++;
                }
                else
                {
                    if (!secretO.ContainsKey(secret[i]))
                    {
                        secretO.Add(secret[i], 0);
                    }

                    secretO[secret[i]]++;
                    guessO.Add(guess[i]);
                }
            }

            foreach (char c in guessO)
            {
                if (secretO.ContainsKey(c) && secretO[c]-- > 0)
                {
                    bCount++;
                }
            }

            return aCount + "A" + bCount + "B";

        }
        private string GetHint3(string secret, string guess)
        {
            int aCount = 0, bCount = 0;

            Dictionary<int, char> secretDictionary = new Dictionary<int, char>();
            List<char> guessO = new List<char>();

            for (int i = 0; i < secret.Length; i++)
            {
                secretDictionary.Add(i, secret[i]);
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (secretDictionary[i] == guess[i])
                {
                    aCount++;
                    secretDictionary.Remove(i);
                }
                else
                {
                    guessO.Add(guess[i]);
                }
            }

            for (int i = 0; i < guessO.Count; i++)
            {
                if (secretDictionary.ContainsValue(guessO[i]))
                {
                    foreach (KeyValuePair<int, char> pair in secretDictionary)
                    {
                        if (pair.Value == guessO[i])
                        {
                            bCount++;
                            secretDictionary.Remove(pair.Key);
                            break;
                        }
                    }
                }
            }

            return aCount + "A" + bCount + "B";

        }

        private string GetHint2(string secret, string guess)
        {
            int aCount = 0, bCount = 0;
            List<string> secretList = new List<string>();
            List<string> guessList = new List<string>();

            for (int i = 0; i < secret.Length; i++)
            {
                secretList.Add(secret[i] + "," + i);
            }
            for (int i = 0; i < guess.Length; i++)
            {
                string temp = guess[i] + "," + i;
                if (secretList.Contains(temp))
                {
                    aCount++;
                    secretList.Remove(temp);
                }
                else
                {
                    guessList.Add(temp);
                }
            }

            foreach (string t in guessList)
            {
                foreach (string s in secretList)
                {
                    if (s.Split(',')[0] == t.Split(',')[0])
                    {
                        bCount++;
                        secretList.Remove(s);
                        break;
                    }
                }
            }


            return aCount + "A" + bCount + "B";
        }

        private string GetHint(string secret, string guess)
        {
            int guessLength = secret.Length;

            bool[] flagSecret = new bool[guessLength];
            bool[] flagGuess = new bool[guessLength];

            for (int i = 0; i < guessLength; i++)
            {
                flagSecret[i] = false;
                flagGuess[i] = false;
            }

            int aCount = 0, bCount = 0;

            for (int i = 0; i < guessLength; i++)
            {
                if (secret[i] == guess[i])
                {
                    aCount++;
                    flagSecret[i] = true;
                    flagGuess[i] = true;
                }
            }

            for (int i = 0; i < guessLength; i++)
            {
                if (flagGuess[i] == false)
                {
                    for (int j = 0; j < guessLength; j++)
                    {
                        if (flagSecret[j] == false)
                        {
                            if (guess[i] == secret[j])
                            {
                                bCount++;
                                flagSecret[j] = true;
                                break;
                            }
                        }
                    }
                }
            }

            return aCount + "A" + bCount + "B";
        }
    }
}
