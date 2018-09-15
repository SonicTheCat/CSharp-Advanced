namespace _04.EvenTimes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num]++;
            }

            foreach (var kvp in numbers)
            {
                int num = kvp.Key;
                int times = kvp.Value;
                if (times % 2 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
