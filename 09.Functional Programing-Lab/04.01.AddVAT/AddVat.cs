namespace _04.AddVAT
{
    using System;
    using System.Linq;

    public class AddVat
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n * 1.20:F2}"));
        }
    }
}
