namespace test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();
            int maxEl = int.MinValue;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                switch (query[0])
                {
                    case 1:
                        {
                            if (maxEl < query[1])
                            {
                                maxEl = query[1];
                            }

                            stack.Push(query[1]);
                        }
                        break;

                    case 2:
                        {
                            stack.Pop();
                            if (stack.Count > 0)
                            {
                                maxEl = stack.ToArray().OrderBy(x => x).Last();
                            }
                            else
                            {
                                maxEl = int.MinValue;
                            }
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine(maxEl);
                        }
                        break;
                }
            }
        }
    }
}
