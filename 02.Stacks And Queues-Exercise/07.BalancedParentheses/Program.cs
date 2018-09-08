namespace _07.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var brackets = Console.ReadLine();
            if (brackets.Length % 2 != 0)
            {
                Console.WriteLine("NO"); return;
            }
            var pairs = new Dictionary<char, char>();
            pairs.Add('(', ')');
            pairs.Add('[', ']');
            pairs.Add('{', '}');

            var openBrackets = new Stack<char>();
            foreach (var br in brackets)
            {
                if (pairs.ContainsKey(br))
                {
                    openBrackets.Push(br); continue;
                }
                var last = openBrackets.Pop();
                if (pairs[last] != br)
                {
                    Console.WriteLine("NO"); return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
