using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GreedyTimes
{
    class Program
    {
        static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());

            var currentCapacity = 0L;
            var totalGold = 0L;
            var totalGem = 0L;
            var totalCash = 0L;

            var items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bag = new Dictionary<string, Dictionary<string, long>>
            {
                {"Gold", new Dictionary<string, long>() },
                {"Gem", new Dictionary<string, long>() },
                {"Cash", new Dictionary<string, long>() },
            };

            for (int i = 0; i < items.Length; i += 2)
            {
                var treasure = items[i];
                var value = long.Parse(items[i + 1]);

                if (!IsBelowBagCapacity(bagCapacity, currentCapacity + value))
                {
                    continue;
                }

                if (treasure == "Gold")
                {
                    SaveTreasure(bag["Gold"], treasure, value);
                    totalGold += value;
                    currentCapacity += value;
                }
                else if (treasure.Length == 3)
                {
                    bool balanced = IsBalanceKept(totalCash + value, totalGem);
                    if (balanced)
                    {
                        SaveTreasure(bag["Cash"], treasure, value);
                        totalCash += value;
                        currentCapacity += value;
                    }
                }
                else if (treasure.ToLower().EndsWith("gem"))
                {
                    bool balanced = IsBalanceKept(totalGem + value, totalGold);
                    if (balanced)
                    {
                        SaveTreasure(bag["Gem"], treasure, value);
                        totalGem += value;
                        currentCapacity += value;
                    }
                }
            }
            SortAndPrint(bag);
        }

        static void SortAndPrint(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var kvp in bag.OrderByDescending(x => x.Value.Values.Sum()))
            {
                var treasure = kvp.Key;
                var nestedDict = kvp.Value;

                if (nestedDict.Count > 0)
                {
                    var totalMoney = nestedDict.Values.Sum();
                    Console.WriteLine($"<{treasure}> ${totalMoney}");

                    foreach (var pair in nestedDict.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{pair.Key} - {pair.Value}");
                    }
                }
            }
        }

        static bool IsBelowBagCapacity(long bagCapacity, long currentCapacity)
        {
            return currentCapacity <= bagCapacity;
        }

        static bool IsBalanceKept(long smaller, long bigger)
        {
            return smaller <= bigger;
        }

        static void SaveTreasure(Dictionary<string, long> dict, string treasure, long value)
        {
            if (!dict.ContainsKey(treasure))
            {
                dict[treasure] = 0;
            }
            dict[treasure] += value;
        }
    }
}
