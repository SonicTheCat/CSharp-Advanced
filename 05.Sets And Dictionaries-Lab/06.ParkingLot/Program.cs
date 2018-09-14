using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>(); 
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var split = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var goes = split[0];
                var number = split[1];
                if (goes == "IN")
                {
                    set.Add(number); 
                }
                else
                {
                    set.Remove(number); 
                }
            }
            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var num in set)
            {
                Console.WriteLine(num);
            }

        }
    }
}
