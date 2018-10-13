using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CubicArtillery
{
    class Program
    {
        private static Queue<string> bunkers = new Queue<string>();
        private static Queue<int> weapons = new Queue<int>();
        private static int capacity;
        private static int freeCapacity;

        static void Main()
        {
            capacity = int.Parse(Console.ReadLine());
            freeCapacity = capacity;

            string input;
            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                CollectCurrentLineTokens(tokens);
            }
        }

        static void CollectCurrentLineTokens(string[] tokens)
        {
            foreach (var token in tokens)
            {
                if (char.IsLetter(token[0]))
                {
                    bunkers.Enqueue(token);
                }
                else
                {
                    StartFillBunkers(int.Parse(token));
                }
            }
        }

        static void StartFillBunkers(int weapon)
        {
            while (true)
            {
                var bunker = bunkers.Peek();

                if (bunkers.Count == 1 && weapon <= capacity)
                {
                    while (freeCapacity < weapon)
                    {
                        freeCapacity += weapons.Dequeue();
                    }
                    weapons.Enqueue(weapon);
                    freeCapacity -= weapon; 
                }
                else if (freeCapacity - weapon < 0 && bunkers.Count == 1)
                {
                    return;
                }
                else if (freeCapacity - weapon < 0)
                {
                    Print(bunker);
                    bunkers.Dequeue();
                    weapons.Clear();
                    freeCapacity = capacity;
                    if (bunkers.Count > 0) continue;
                }
                else if (freeCapacity - weapon >= 0)
                {
                    weapons.Enqueue(weapon);
                    freeCapacity -= weapon;
                }
                return;
            }
        }

        static void Print(string bunker)
        {
            Console.WriteLine(weapons.Count == 0 ?
                     bunker + " -> " + "Empty" : $"{bunker} -> {string.Join(", ", weapons)}");
        }
    }
}
