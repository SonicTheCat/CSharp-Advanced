namespace _04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            var wantedIndex = int.Parse(Console.ReadLine());
            var storeData = new Dictionary<string, Dictionary<string, string>>();

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var readLine = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var person = readLine[0].Trim();
                var data = readLine[1].Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in data)
                {
                    var splitPair = pair.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    var key = splitPair[0];
                    var value = splitPair[1];

                    if (!storeData.ContainsKey(person))
                    {
                        storeData[person] = new Dictionary<string, string>(); 
                    }
                    storeData[person][key] = value;
                }
            }
            var target = Console.ReadLine().Trim().Split("Kill ", StringSplitOptions.RemoveEmptyEntries)[0];
            var targetsData = storeData[target];

            int infoIndex = 0;
            Console.WriteLine($"Info on {target}:");
            foreach (var kvp in targetsData.OrderBy(x => x.Key))
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Console.WriteLine($"---{key}: {value}");

                infoIndex += key.Length + value.Length; 
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= wantedIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {wantedIndex - infoIndex} more info.");
            }
        }
    }
}
