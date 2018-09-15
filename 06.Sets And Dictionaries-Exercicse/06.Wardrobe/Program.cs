namespace _06.Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var clothesAndColors = new Dictionary<string, HashSet<string>>();
            var countDuplicates = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var color = input[0];
                var clothes = input[1].Split(',');

                if (!clothesAndColors.ContainsKey(color))
                {
                    clothesAndColors.Add(color, new HashSet<string>());
                    countDuplicates.Add(color, new Dictionary<string, int>());
                }
                foreach (var cl in clothes)
                {
                    clothesAndColors[color].Add(cl);
                    if (!countDuplicates[color].ContainsKey(cl))
                    {
                        countDuplicates[color].Add(cl, 0);
                    }
                    countDuplicates[color][cl]++;
                }
            }

            var lookFor = Console.ReadLine().Split();
            foreach (var kvp in clothesAndColors)
            {
                var color = kvp.Key;
                var set = kvp.Value;
                Console.WriteLine($"{color} clothes:");
                foreach (var item in set)
                {
                    var counter = countDuplicates[color][item];
                    if (color == lookFor[0] && item == lookFor[1])
                    {
                        Console.WriteLine($"* {item} - {counter} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item} - {counter}");
                }
            }
        }
    }
}
