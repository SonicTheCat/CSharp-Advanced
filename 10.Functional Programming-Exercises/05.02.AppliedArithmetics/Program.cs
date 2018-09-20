namespace _05._02.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = x => x.Select(n => n + 1).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(n => n - 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(n => n * 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", nums));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add": nums = add(nums); break;
                    case "subtract": nums = subtract(nums); break;
                    case "multiply": nums = multiply(nums); break;
                    default: print(nums); break;
                }
            }
        }
    }
}
