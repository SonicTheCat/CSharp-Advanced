using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                var split = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var store = split[0];
                var product = split[1];
                var price = double.Parse(split[2]);


                if (!shops.ContainsKey(store))
                {
                    shops.Add(store, new Dictionary<string, double>());
                }
                shops[store].Add(product, price);
            }
            foreach (var kvp in shops)
            {
                Console.WriteLine(kvp.Key + "->");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
