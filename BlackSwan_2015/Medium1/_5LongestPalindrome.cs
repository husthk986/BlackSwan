using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium1
{
    class _5LongestPalindrome : ILeetcode
    {
        public void DoIt()
        {
            string s = "ACGAEGABCDCBAATETA";
            Console.WriteLine("Should be ABCDCBA: " + LongestPalindrome(s));

            s = "ACGAEGABCCBAATETA";
            Console.WriteLine("Should be ABCCBA: " + LongestPalindrome(s));

            s = "esbtzjaaijqkgmtaajpsdfiqtvxsgfvijpxrvxgfumsuprzlyvhclgkhccmcnquukivlpnjlfteljvykbddtrpmxzcrdqinsnlsteonhcegtkoszzonkwjevlasgjlcquzuhdmmkhfniozhuphcfkeobturbuoefhmtgcvhlsezvkpgfebbdbhiuwdcftenihseorykdguoqotqyscwymtjejpdzqepjkadtftzwebxwyuqwyeegwxhroaaymusddwnjkvsvrwwsmolmidoybsotaqufhepinkkxicvzrgbgsarmizugbvtzfxghkhthzpuetufqvigmyhmlsgfaaqmmlblxbqxpluhaawqkdluwfirfngbhdkjjyfsxglsnakskcbsyafqpwmwmoxjwlhjduayqyzmpkmrjhbqyhongfdxmuwaqgjkcpatgbrqdllbzodnrifvhcfvgbixbwywanivsdjnbrgskyifgvksadvgzzzuogzcukskjxbohofdimkmyqypyuexypwnjlrfpbtkqyngvxjcwvngmilgwbpcsseoywetatfjijsbcekaixvqreelnlmdonknmxerjjhvmqiztsgjkijjtcyetuygqgsikxctvpxrqtuhxreidhwcklkkjayvqdzqqapgdqaapefzjfngdvjsiiivnkfimqkkucltgavwlakcfyhnpgmqxgfyjziliyqhugphhjtlllgtlcsibfdktzhcfuallqlonbsgyyvvyarvaxmchtyrtkgekkmhejwvsuumhcfcyncgeqtltfmhtlsfswaqpmwpjwgvksvazhwyrzwhyjjdbphhjcmurdcgtbvpkhbkpirhysrpcrntetacyfvgjivhaxgpqhbjahruuejdmaghoaquhiafjqaionbrjbjksxaezosxqmncejjptcksnoq";
            Console.WriteLine("Should be yvvy: " + LongestPalindrome(s));

            s = "bb";
            Console.WriteLine("Should be bb: " + LongestPalindrome(s));

            s = "bcb";
            Console.WriteLine("Should be bcb: " + LongestPalindrome(s));
        }

        public string LongestPalindrome(string s) //
        {
            if (s.Length == 1) return s;

            int iMax = 0, subMax = 0;
            int len = s.Length;

            for (int i = 0; i < len - 1; i++)
            {
                int max = 0;
                for (int m = 0; m <= i && m < len - i - 1; m++)
                {
                    if (s[i - m] == s[i + m + 1])
                    {
                        max++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (subMax < max * 2)
                {
                    subMax = max * 2;
                    iMax = i - max + 1;
                }

                max = 0;
                for (int m = 0; m < i && m < len - i - 1; m++)
                {
                    if (s[i - m - 1] == s[i + m + 1])
                    {
                        max++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (subMax < max * 2 + 1)
                {
                    subMax = max * 2 + 1;
                    iMax = i - max;
                }
            }

            return s.Substring(iMax, subMax);

        }

        public string LongestPalindrome1(string s) //LCS method is wrong, like cltg, there happen has gtlc in the string.
        {
            string t = new string(s.Reverse().ToArray());

            //Longest common substring problem
            int iMax = 0, jMax = 0, subMax = 0;
            int[,] matrix = new int[s.Length, t.Length];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            matrix[i, j] = 1;
                        }
                        else
                        {
                            matrix[i, j] = matrix[i - 1, j - 1] + 1;
                        }

                        if (matrix[i, j] > subMax)
                        {
                            subMax = matrix[i, j];
                            iMax = i;
                            jMax = j;
                        }

                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            char[] result = new char[subMax];
            for (int k = subMax - 1; k >= 0; k--)
            {
                result[k] = s[iMax--];
            }

            return new string(result);
        }
    }
}
