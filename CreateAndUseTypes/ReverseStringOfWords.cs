using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    class ReverseStringOfWords
    {
        //P11: Reverse Words in a String II
        //Source: https://leetcode.com

        public static void ReverseWords(char[] s)
        {
            if (s == null || s.Length == 0)
            {
                return;
            }

            Stack<char[]> stack = new Stack<char[]>();
            List<char> word = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {

                if (!char.IsWhiteSpace(s[i]))
                {
                    word.Add(s[i]);
                }
                else
                {
                    stack.Push(word.ToArray());
                    word.Clear();
                }
            }
            stack.Push(word.ToArray());

            int startIndex = 0;
            while (stack.Count > 0)
            {
                var lastWord = stack.Pop();
                addWordToString(lastWord, s, startIndex);
                startIndex += lastWord.Length;

                if (stack.Count >= 1)
                {
                    s[startIndex++] = ' ';
                }
            }

        }

        public static void addWordToString(char[] word, char[] s, int startIndex)
        {
            for (int i = 0; i < word.Length; i++)
            {
                s[startIndex++] = word[i];
            }

        }
    }
}
