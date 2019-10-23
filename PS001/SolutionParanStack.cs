using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS001
{
    class SolutionParanStack
    {
        public static bool IsValid(string text)
        {
            bool response = true;
            Stack ParaStack = new Stack();
            Dictionary<char, char> setParanteze = new Dictionary<char, char>()
            {
                { '(',')' },
                { '[',']' },
                { '{','}' }
            };
            if (text.Length % 2 == 1) response = false;
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (setParanteze.ContainsValue(ch))
                {
                    if (ParaStack.Count == 0) return false;
                    char UltimapDeschisa = (char)ParaStack.Peek();
                    if (UltimapDeschisa == setParanteze.FirstOrDefault(x => x.Value == ch).Key)
                        ParaStack.Pop();
                    else return false;
                }
                else
                {
                    ParaStack.Push(ch);
                }
            }
            if (ParaStack.Count > 0) response = false;

            return response;
        }
        static internal void ScreenMe()
        {
            //string txt = "(()()))(()";//false
            //string txt = "([)]";// false
            //string txt = "(([]){[]})";//true
            //string txt = "()";//true
            //string txt = "()()(()";//false
            //string txt = "";//false
            string txt = " ))(([]){[]})";//fasle

            bool a = IsValid(txt);
            Console.WriteLine("Your text is : {0}", a);
        }
    }
}
