namespace _11._02.ParkingSystem
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var parking = new int[sizes[0]][];

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int entry = int.Parse(command.Split()[0]);
                int parkRow = int.Parse(command.Split()[1]);
                int parkCol = int.Parse(command.Split()[2]);

                if (parking[parkRow] == null)
                {
                    parking[parkRow] = new int[sizes[1]];
                }

                if (parking[parkRow].Skip(1).All(x => x == 1))
                {
                    Console.WriteLine($"Row {parkRow} full");
                    continue;
                }

                if (parking[parkRow][parkCol] == 1)
                {
                    parkCol = NearestEmptySpace(parking[parkRow], parkCol);
                }

                parking[parkRow][parkCol] = 1;

                Console.WriteLine(Math.Abs(entry - parkRow) + parkCol + 1);
            }
        }
        private static int NearestEmptySpace(int[] parkingRow, int parkCol)
        {
            for (int i = 1; i < parkingRow.Length; i++)
            {
                if (parkCol > i && parkingRow[parkCol - i] != 1)
                {
                    return parkCol - i;
                }

                if (parkCol + i < parkingRow.Length && parkingRow[parkCol + i] != 1)
                {
                    return parkCol + i;
                }
            }
            return -1;
        }
    }
}
