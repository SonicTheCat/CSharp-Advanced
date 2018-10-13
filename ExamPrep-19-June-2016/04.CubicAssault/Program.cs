using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.CubicAssault
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, long>> dict;
        private const int million = 1_000_000;

        static void Main()
        {
            dict = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "Count em all")
            {
                var tokens = Regex.Split(input, @"\s+\-\>\s+");
                var region = tokens[0];
                var color = tokens[1];
                var count = long.Parse(tokens[2]);

                if (!dict.ContainsKey(region))
                {
                    dict[region] = new Dictionary<string, long>();
                    dict[region]["Black"] = 0;
                    dict[region]["Red"] = 0;
                    dict[region]["Green"] = 0;
                }
                dict[region][color] += count;
                FixValues();
            }
            SortAndPrint();
        }

        static void FixValues()
        {
            foreach (var kvp in dict)
            {
                var nested = kvp.Value;

                if (nested["Green"] >= million)
                {
                    nested["Red"] += nested["Green"] / million;
                    nested["Green"] = nested["Green"] % million;
                }
                if (nested["Red"] >= million)
                {
                    nested["Black"] += nested["Red"] / million;
                    nested["Red"] = nested["Red"] % million;
                }
            }
        }

        static void SortAndPrint()
        {
            foreach (var kvp in dict
               .OrderByDescending(x => x.Value["Black"])
               .ThenBy(x => x.Key.Length)
               .ThenBy(x => x.Key))
            {
                var region = kvp.Key;
                var nestedDict = kvp.Value;
                Console.WriteLine(region);

                foreach (var pair in nestedDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {pair.Key} : {pair.Value}");
                }
            }
        }
    }
}