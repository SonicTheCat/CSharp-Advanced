namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nums = new Stack<int>();
            var maxNum = new Stack<int>();
            maxNum.Push(int.MinValue); 

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (query[0] == 1)
                {
                    int newEl = query[1];
                    nums.Push(newEl);
                    if (newEl >= maxNum.Peek())
                    {
                        maxNum.Push(newEl);
                    }
                }
                else if (query[0] == 2)
                {
                    int removeEl = nums.Pop();
                    if (maxNum.Peek() == removeEl)
                    {
                        maxNum.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(maxNum.Peek());
                }
            }
        }
    }
}
