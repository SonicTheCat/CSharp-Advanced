using System;
using System.Collections.Generic;
using System.Linq;

namespace task4
{
    class Program
    {
        static void Main()
        {
            var lineCups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lineBottles = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var cups = new Queue<int>(lineCups);
            var bottles = new Stack<int>(lineBottles);

            var wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                var currentCup = cups.Peek();
                var currentBottle = bottles.Peek();

                if (currentBottle >= currentCup)
                {
                    cups.Dequeue();
                    bottles.Pop();
                    wastedWater += currentBottle - currentCup;
                }
                else if (currentCup > currentBottle)
                {
                    while (true)
                    {
                        currentCup -= currentBottle;
                        bottles.Pop();
                        if (currentCup <= 0)
                        {
                            wastedWater += Math.Abs(currentCup);
                            cups.Dequeue();
                            break;
                        }
                        if (bottles.Count <= 0)
                        {
                            break;
                        }
                        currentBottle = bottles.Peek(); 
                    }
                } 
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottles));
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine("Cups: " + string.Join(" ", cups));
            }
            
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
