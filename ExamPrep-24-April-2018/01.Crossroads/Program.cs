using System;
using System.Collections.Generic;

namespace _01.Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenTime = int.Parse(Console.ReadLine());
            int freeWindon = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            var totalCars = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    GreenLightOn(cars, greenTime, freeWindon);
                }
                else
                {
                    cars.Enqueue(command);
                    totalCars++;
                }
            }

            Console.WriteLine($"Everyone is safe.\n" +
                $"{totalCars - cars.Count} total cars passed the crossroads.");
        }

        static void GreenLightOn(Queue<string> cars, int greenTime, int freeWindow)
        {
            var car = string.Empty;
           
            while (cars.Count > 0 && greenTime > 0)
            {
                car = cars.Dequeue();
                if (car.Length <= greenTime)
                {
                    greenTime -= car.Length;
                }
                else
                {
                    var partsInside = car.Substring(greenTime);
                    IsCrash(partsInside, freeWindow, car);
                    break;
                }
            }
        }

        static void IsCrash(string partsInside, int freeWindow, string car)
        {
            if (partsInside.Length > freeWindow)
            {
                Console.WriteLine($"A crash happened!\n{car} was hit at {partsInside[freeWindow]}.");
                Environment.Exit(0);
            }
        }
    }
}