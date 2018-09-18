namespace _04._02.AddVAT
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double, string> calcVat = n => $"{n * 1.20:f2}";

            foreach (var n in nums)
            {
                Console.WriteLine(calcVat(n));
            }
        }
    }
}
