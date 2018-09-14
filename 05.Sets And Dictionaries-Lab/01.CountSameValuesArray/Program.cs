namespace _01.CountSameValuesArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var collection = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!collection.ContainsKey(num))
                {
                    collection.Add(num, 0);
                }
                collection[num]++;
            }

            foreach (var kvp in collection)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
