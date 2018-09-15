namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
