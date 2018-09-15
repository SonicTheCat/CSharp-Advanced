namespace _07.TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var vlogers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Statistics")
                {
                    break;
                }
                if (input.Length == 4)
                {
                    var username = input[0];
                    if (!vlogers.ContainsKey(username))
                    {
                        vlogers.Add(username, new Dictionary<string, HashSet<string>>());
                        vlogers[username].Add("Followers", new HashSet<string>());
                        vlogers[username].Add("Following", new HashSet<string>());
                    }

                }
                else
                {
                    var firstVloger = input[0];
                    var secondVloger = input[2];

                    if (firstVloger == secondVloger)
                    {
                        continue;
                    }
                    if (!vlogers.ContainsKey(firstVloger) || !vlogers.ContainsKey(secondVloger))
                    {
                        continue;
                    }
                    vlogers[secondVloger]["Followers"].Add(firstVloger);
                    vlogers[firstVloger]["Following"].Add(secondVloger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            int numeration = 1;
            foreach (var kvp in vlogers
                .OrderByDescending(x => x.Value["Followers"].Count)
                .ThenBy(x => x.Value["Following"].Count))
            {
                var username = kvp.Key;
                var nestedDict = kvp.Value;
                var followers = vlogers[username]["Followers"].Count;
                var following = vlogers[username]["Following"].Count;

                Console
                .WriteLine($"{numeration}. {username} : {followers} followers, {following} following");

                if (numeration == 1)
                {
                    foreach (var name in nestedDict["Followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                numeration++;
            }
        }
    }
}
