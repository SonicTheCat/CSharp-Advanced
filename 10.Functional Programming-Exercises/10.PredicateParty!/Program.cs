namespace _10.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var tokens = input.Split();
                var direction = tokens[1];
                var keyword = tokens[2];

                Func<string, bool> filter = GetFilter(direction, keyword);

                guests = ManipulateGuestList(guests, filter, tokens[0]);
            }

            Print(guests);
        }
        static void Print(List<string> guests)
        {
            if (guests.Count < 1)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }
        static Func<string, bool> GetFilter(string direction, string keyword)
        {
            var length = keyword.Length;

            if (direction == "StartsWith")
            {
                return x => x.StartsWith(keyword);
            }
            else if (direction == "EndsWith")
            {
                return x => x.EndsWith(keyword);
            }
            return x => x.Length == int.Parse(keyword);
        }
        static List<string> ManipulateGuestList(List<string> guests, Func<string, bool> filter, string action)
        {
            var list = new List<string>();
            foreach (var guest in guests)
            {
                if (filter(guest) && action == "Double")
                {
                    list.Add(guest);
                    list.Add(guest);
                }
                else if (!filter(guest))
                {
                    list.Add(guest);
                }
            }
            return list;
        }
    }
}
