namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] days = new int[plants.Length];
            Stack<int> stackIndexes = new Stack<int>();
            stackIndexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (stackIndexes.Count > 0 && plants[stackIndexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stackIndexes.Pop()]);
                }
                if (stackIndexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                stackIndexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}