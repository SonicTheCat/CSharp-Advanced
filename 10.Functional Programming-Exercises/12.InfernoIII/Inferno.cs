namespace _12.InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inferno
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Insert(0, 0);
            numbers.Insert(numbers.Count, 0);
            var filters = new Dictionary<string, List<int>>();

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                var tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                CollectAllFilters(filters, tokens);
            }

            var result = string.Empty;
            foreach (var kvp in filters)
            {
                var type = kvp.Key;
                var list = kvp.Value;

                foreach (var val in list)
                {
                    Func<int, bool> currentFilter = n => n == val;
                    result += ManipulateNumbers(numbers, currentFilter, type);
                }
            }
            Print(result, numbers);
        }
        static void Print(string result, List<int> numbers)
        {
            var removedEls = result
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            numbers.RemoveAt(0);
            numbers.RemoveAt(numbers.Count - 1);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!removedEls.Contains(numbers[i]))
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
        static string ManipulateNumbers(List<int> numbers, Func<int, bool> currentFilter, string type)
        {
            string result = string.Empty;
            for (int i = 1; i < numbers.Count - 1; i++)
            {
                var num = 0;
                switch (type)
                {
                    case "Sum Left": num = numbers[i] + numbers[i - 1]; break;
                    case "Sum Right": num = numbers[i] + numbers[i + 1]; break;
                    default: num = numbers[i] + numbers[i - 1] + numbers[i + 1]; break;
                }

                if (currentFilter(num))
                {
                    result += numbers[i] + " ";
                }
            }
            return result;
        }
        static void CollectAllFilters(Dictionary<string, List<int>> filters, string[] tokens)
        {
            var command = tokens[0];
            var filterType = tokens[1];
            var filterParam = tokens[2];

            if (command == "Exclude")
            {
                if (!filters.ContainsKey(filterType))
                {
                    filters[filterType] = new List<int>();
                }
                filters[filterType].Add(int.Parse(filterParam));
                return;
            }
            filters[filterType].Remove(int.Parse(filterParam));
        }
    }
}
