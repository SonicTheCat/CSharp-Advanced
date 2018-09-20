namespace _03._02.CustomMinFunction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Func<int[], int> smallest = x => x.Min();

            var numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            Console.WriteLine(smallest(numbers));
        }
    }
}
