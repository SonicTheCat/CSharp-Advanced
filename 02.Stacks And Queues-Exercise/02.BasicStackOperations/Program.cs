namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var nums = Console.ReadLine().Split(' ');

            int numsIn = int.Parse(input[0]);
            int numsOut = int.Parse(input[1]);
            string x = input[2];
            var stack = new Stack<string>(nums.Take(numsIn).ToArray());

            for (int i = 0; i < numsOut; i++)
            {
                stack.Pop();
            }
            Console.WriteLine(stack.Contains(x) ?
                "true" : stack.Count == 0 ?
                "0" : stack.Min());
        }
    }
}
