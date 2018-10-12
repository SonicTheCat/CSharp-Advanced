namespace _01_ArrangeNumbers
{
    using System;
    using System.Linq;

    public class ArrangeNumbers
    {
        public static void Main()
        {
            var names = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => new
                {
                    Number = n,
                    DigitsNames = n.Select(ch => names[ch - '0'])
                })
                .OrderBy(n => string.Join("", n.DigitsNames))
                .Select(n => n.Number);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}