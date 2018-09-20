namespace _04._02.FindEvensOdds
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var range = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var condition = Console.ReadLine();
            Predicate<int> isEven = x => x % 2 == 0;

            Console.WriteLine(string.Join(" ", Enumerable
                .Range(range[0], range[1] - range[0] + 1)
                 .Where(n => condition == "even" ? isEven(n) : !isEven(n))
                .ToArray()));
        }
    }
}
