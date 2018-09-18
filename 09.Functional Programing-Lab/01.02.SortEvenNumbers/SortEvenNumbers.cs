using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._02.SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var evenNums = EvenNumbers(numbers, n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evenNums));
        }

        private static List<int> EvenNumbers(List<int> numbers, Func<int, bool> evens)
        {
            var list = new List<int>();
            foreach (var n in numbers)
            {
                if (evens(n))
                {
                    list.Add(n);
                }
            }
            return list.OrderBy(x => x).ToList();
        }
    }
}
