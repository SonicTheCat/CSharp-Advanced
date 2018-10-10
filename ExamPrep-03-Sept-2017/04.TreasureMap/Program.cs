using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class Program
    {
        static void Main()
        {
            var countOfLines = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"((?<start>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<street>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<number>[0-9]{3})-(?<pass>[0-9]{4}|[0-9]{6})(?!\d)[^#!]*(?(start)!|#)");
           
            for (int i = 0; i < countOfLines; i++)
            {
                var line = Console.ReadLine();

                MatchCollection matches = pattern.Matches(line);
                var takeIndex = matches.Count / 2;
                Match match = matches[takeIndex];

                Console.WriteLine($"Go to str. {match.Groups["street"]} {match.Groups["number"]}. " +
                    $"Secret pass: {match.Groups["pass"]}.");
            }
        }
    }
}
