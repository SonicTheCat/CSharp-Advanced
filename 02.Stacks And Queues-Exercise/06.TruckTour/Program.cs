namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pumps = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int petrol = input[0];
                int distance = input[1];
                pumps.Enqueue(petrol - distance);
            }

            for (int i = 0; i < n; i++)
            {
                int fuelLeft = 0;
                foreach (var fuel in pumps)
                {
                    fuelLeft += fuel;
                    if (fuelLeft < 0)
                    {
                        break; 
                    }
                }       
              
                if (fuelLeft >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }
                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}