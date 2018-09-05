namespace _06.TrafficLight
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int carsPerGreen = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            var allCars = new Queue<string>();
            int counter = 0; 
            while (command != "end")
            {   
                if (command == "green")
                {
                    for (int i = 0; i < carsPerGreen; i++)
                    {
                        if (allCars.Count > 0)
                        {
                            counter++; 
                            Console.WriteLine($"{allCars.Dequeue()} passed!");
                        }
                    }
                }
                else
                {
                    allCars.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
