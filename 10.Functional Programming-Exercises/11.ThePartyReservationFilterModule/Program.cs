namespace _11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split();
            var filters = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                GetFilters(filters, tokens);
            }

            foreach (var kvp in filters)
            {
                var command = kvp.Key;
                var list = kvp.Value;

                foreach (var keyword in list)
                {
                    Func<string, bool> filter = CurrentFilter(command, keyword);
                    guests = ManipulateGuestList(guests, filter);
                }   
            }

            Console.WriteLine(string.Join(" ", guests));
        }
        static string[] ManipulateGuestList(string[] guests, Func<string, bool> filter)
        {
            var list = new List<string>();
            foreach (var guest in guests)
            {
                if (!filter(guest))
                {
                    list.Add(guest);
                }
            }

            return list.ToArray();
        }
        static Func<string, bool> CurrentFilter(string command, string keyword)
        {
            switch (command)
            {
                case "Starts with": return x => x.StartsWith(keyword);
                case "Ends with": return x => x.EndsWith(keyword);
                case "Length": return x => x.Length == int.Parse(keyword);
                default: return x => x.Contains(keyword);
            }
        }
        static void GetFilters(Dictionary<string, List<string>> filters, string[] tokens)
        {
            var action = tokens[0];
            var command = tokens[1];
            var keyword = tokens[2];

            if (action == "Remove filter")
            {
                filters[command].Remove(keyword);
                return;
            }

            if (!filters.ContainsKey(command))
            {
                filters[command] = new List<string>();
            }
            filters[command].Add(keyword);
        }
    }
}
