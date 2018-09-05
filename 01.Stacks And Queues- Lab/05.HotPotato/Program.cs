namespace _05.HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var players = Console.ReadLine().Split(' ');
            int count = int.Parse(Console.ReadLine());
            Queue<string> collection = new Queue<string>(players);

            while (collection.Count != 1)
            {
                for (int i = 1; i <= count; i++)
                {
                    if (i == count)
                    {
                        Console.WriteLine("Removed " + collection.Dequeue());
                    }
                    else
                    {
                        collection.Enqueue(collection.Dequeue());
                    }
                }
            }
            Console.WriteLine("Last is " + collection.Dequeue());
        }
    }
}
