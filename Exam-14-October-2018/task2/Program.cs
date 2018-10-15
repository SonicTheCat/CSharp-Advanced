using System;
using System.Collections.Generic;
using System.Linq; 

namespace task2
{
    class Program
    {
        static void Main()
        {
            var dataBase = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 1)
                {
                    var banTokens = tokens[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var username = banTokens[1]; 

                    if (dataBase.ContainsKey(username))
                    {
                        dataBase.Remove(username); 
                    }
                }
                else if (tokens.Length == 3)
                {
                    var username = tokens[0];
                    var tag = tokens[1];
                    var likes = long.Parse(tokens[2]);

                    if (!dataBase.ContainsKey(username))
                    {
                        dataBase[username] = new Dictionary<string, long>();
                    }

                    if (!dataBase[username].ContainsKey(tag))
                    {
                        dataBase[username][tag] = 0;
                    }
                    dataBase[username][tag] += likes;
                }
            }

            foreach (var kvp in dataBase
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Value.Count))
            {
                var name = kvp.Key;
                var nested = kvp.Value;
                Console.WriteLine(name);

                foreach (var pair in nested)
                {
                    Console.WriteLine($"- {pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
