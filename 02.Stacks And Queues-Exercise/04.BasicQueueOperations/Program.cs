namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Reverse().Take(input[0] - input[1]).ToArray();
            var que = new Queue<string>(numbers);

            Console.WriteLine(que.Contains(input[2] + "") ? "true" : que.Count == 0 ? "0" : que.Min());
        }
    }
}
