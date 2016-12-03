using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_1
{
    class _20ValidParentheses:ILeetcode
    {
        public void DoIt()
        {
            string s = "(){}{}{}[]({})";
            Console.WriteLine("Should be true: "+ IsValid(s));
        }

        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            
            Stack<char> charStack = new Stack<char>();

            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        charStack.Push(c);
                        break;
                    case ')':
                        if (charStack.Count == 0 || charStack.Pop() !='(')
                            return false;
                        break;
                    case ']':
                        if (charStack.Count == 0 || charStack.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (charStack.Count == 0 || charStack.Pop() != '{')
                            return false;
                        break;
                        
                    default:
                        break;

                }
            }

            return charStack.Count == 0;

        }
    }
}
