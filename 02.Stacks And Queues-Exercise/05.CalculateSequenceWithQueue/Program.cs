namespace _05.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var seqQue = new Queue<long>(new long[] { n });
            int counter = 0;

            while (counter < 50)
            {
                seqQue.Enqueue(n + 1);
                seqQue.Enqueue(2 * n + 1);
                seqQue.Enqueue(n + 2);

                Console.Write(seqQue.Dequeue() + " ");
                n = seqQue.Peek();
                counter++;
            }
        }
    }
}
