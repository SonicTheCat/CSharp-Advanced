namespace _01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        static Stack<int> bullets = new Stack<int>();
        static Queue<int> locks = new Queue<int>();

        public static void Main()
        {
            int bulletCost = int.Parse(Console.ReadLine());
            int gunBarelSize = int.Parse(Console.ReadLine());
            var inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            bullets = new Stack<int>(inputBullets);
            locks = new Queue<int>(inputLocks);
            int wastedBull = 0;

            while (true)
            {
                for (int i = 1; i <= gunBarelSize; i++)
                {
                    var currentBullet = bullets.Pop();
                    var currentLock = locks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (bullets.Count > 0 && i == gunBarelSize)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    isGameOver(++wastedBull * bulletCost, value);
                }
            }
        }
        static void isGameOver(int deduction, int value)
        {
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - deduction}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                return;
            }
            Environment.Exit(0);
        }
    }
}
