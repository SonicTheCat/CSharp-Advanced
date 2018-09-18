namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var pair = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (!people.ContainsKey(pair[0]))
                {
                    people[pair[0]] = int.Parse(pair[1]);
                }
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> filter;
            if (condition == "younger")
            {
                filter = a => a < age;
            }
            else
            {
                filter = a => a >= age;
            }

            if (format == "age")
            {
                Print(people, filter, (k, v) => v.ToString());
            }
            else if (format == "name")
            {
                Print(people, filter, (k, v) => k);
            }
            else
            {
                Print(people, filter, (k, v) => k + " - " + v);
            }
        }
        static void Print(Dictionary<string, int> people, Func<int, bool> filter, Func<string, int, string> print)
        {
            foreach (var kvp in people)
            {
                var name = kvp.Key;
                var age = kvp.Value;

                if (filter(age))
                {
                    Console.WriteLine(print(name, age));
                }
            }
        }
    }
}