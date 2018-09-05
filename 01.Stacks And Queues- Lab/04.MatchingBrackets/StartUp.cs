namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string expr = Console.ReadLine();
            var brackets = new Stack<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    brackets.Push(i); 
                }
                if (expr[i] == ')')
                {
                    int start = brackets.Pop();
                    int length = i - start + 1;

                    Console.WriteLine(expr.Substring(start, length));
                }
            }
            
        }
    }
}
