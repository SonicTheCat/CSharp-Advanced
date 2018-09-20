namespace _08._02.CustomComparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Predicate<int> isEven = n => n % 2 == 0;

            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .GroupBy(x => isEven(x))
                .OrderByDescending(gr => gr.Key)
                .ToDictionary(gr => gr.Key, gr => gr.OrderBy(n => n).ToList());

            foreach (var group in nums)
            {
                Console.Write(string.Join(" ", group.Value) + " ");
            }
        }
    }
}
