namespace _02.SumNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                  .Split(", ")
                  .Select(int.Parse)
                  .ToArray();
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Sum());
        }
    }
}
