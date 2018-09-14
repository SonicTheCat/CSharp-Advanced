namespace _11.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static Dictionary<int, List<int>> parking = new Dictionary<int, List<int>>();
      
        static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            while (command != "stop")
            {
                var commands = command.Split(' ').Select(int.Parse).ToArray();
                int entry = commands[0];
                int parkRow = commands[1];
                int parkCol = commands[2];

                if (!parking.ContainsKey(parkRow))
                {
                    parking.Add(parkRow, new List<int>());
                }

                bool taken = parking[parkRow].Contains(parkCol);
                if (taken)
                {
                    if (parking[parkRow].Count + 1 == sizes[1])
                    {
                        Console.WriteLine("Row " + parkRow + " full");
                    }
                    else
                    {
                        var freeCol = NearestEmptySpace(parking[parkRow], parkCol, sizes[1]);
                        parking[parkRow].Add(freeCol);
                        Console.WriteLine(CountMoves(entry, parkRow, freeCol));
                    }
                }
                else
                {
                    parking[parkRow].Add(parkCol);
                    Console.WriteLine(CountMoves(entry, parkRow, parkCol));
                }
                command = Console.ReadLine();
            }
        }
        private static int NearestEmptySpace(List<int> parkingRow, int parkCol, int cols)
        {
            var foundCol = 0;
            int minDistance = int.MaxValue;

            for (int col = 1; col < cols; col++)
            {
                var currentDistance = Math.Abs(parkCol - col);
                if (!parkingRow.Contains(col) && currentDistance < minDistance)
                {
                    foundCol = col;
                    minDistance = currentDistance;
                }
            }
            return foundCol;
        }
        static int CountMoves(int entry, int row, int col)
        {
            return Math.Abs(entry - row) + col + 1;
        }
    }
}