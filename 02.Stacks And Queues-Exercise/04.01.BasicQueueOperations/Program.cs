namespace _04._01.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numsIn = input[0];
            int numsOut = input[1];
            int findNum = input[2];
            var que = new Queue<int>();

            for (int i = 0; i < numsIn; i++)
            {
                que.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numsOut; i++)
            {
                que.Dequeue();
            }
            if (que.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < que.Count; i++)
            {
                if (que.Peek() == findNum)
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            Console.WriteLine(que.Min());
        }
    }
}
