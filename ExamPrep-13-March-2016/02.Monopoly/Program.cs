using System;
using System.Linq;

namespace _02.Monopoly
{
    class Program
    {
        private static char[][] matrix;
        private static int money = 50;
        private static bool ownHotel = false;
        private static int totalTurns = 0;
        private static int countOfHotels = 0;

        static void Main()
        {
            GetMatrix();

            bool goRight = true;
            for (int r = 0; r < matrix.Length; r++)
            {
                if (goRight)
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        PlayGame(r, c);
                    }
                }
                else
                {
                    for (int c = matrix[r].Length - 1; c >= 0; c--)
                    {
                        PlayGame(r, c);
                    }
                }
                goRight = !goRight;
            }
            Console.WriteLine($"Turns {totalTurns}\nMoney {money}");
        }

        static void PlayGame(int row, int col)
        {
            if (matrix[row][col] == 'H')
            {
                BuyHotel();
            }
            else if (matrix[row][col] == 'J')
            {
                TimeInJail();
            }
            else if (matrix[row][col] == 'S')
            {
                SpendMoneyAtShop(row, col);
            }
            GetMoneyFromHotels();
            totalTurns++;
        }

        static void SpendMoneyAtShop(int row, int col)
        {
            var productCost = (row + 1) * (col + 1);
            var spendMoney = productCost > money ? money : productCost;
            Console.WriteLine($"Spent {spendMoney} money at the shop.");
            money -= spendMoney;
        }

        static void TimeInJail()
        {
            Console.WriteLine($"Gone to jail at turn {totalTurns}.");
            for (int i = 0; i < 2; i++)
            {
                totalTurns++;
                GetMoneyFromHotels();
            }
        }

        static void BuyHotel()
        {
            countOfHotels++;
            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {countOfHotels}.");
            money = 0;
            ownHotel = true;
        }

        static void GetMoneyFromHotels()
        {
            if (ownHotel)
            {
                money += 10 * countOfHotels;
            }
        }

        static void GetMatrix()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            matrix = new char[sizes[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Trim().ToCharArray();
            }
        }
    }
}