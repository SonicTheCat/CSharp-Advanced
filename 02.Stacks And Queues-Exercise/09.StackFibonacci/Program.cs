namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                long last = stack.Pop();
                long beforeLast = stack.Peek();
                stack.Push(last);
                stack.Push(last + beforeLast);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
