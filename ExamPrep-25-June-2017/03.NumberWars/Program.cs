using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        private static List<string> result;

        static void Main()
        {
            var firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var firstPlayaCards = new Queue<string>(firstInput);
            var secondPlayaCards = new Queue<string>(secondInput);
            var round = 0;

            while (round < 1000000)
            {
                round++;
                var cardOne = string.Empty;
                var cardTwo = string.Empty;

                cardOne = firstPlayaCards.Dequeue();
                cardTwo = secondPlayaCards.Dequeue();

                var cardOneNumber = long.Parse(cardOne.Substring(0, cardOne.Length - 1));
                var cardTwoNumber = long.Parse(cardTwo.Substring(0, cardTwo.Length - 1));

                if (cardOneNumber > cardTwoNumber)
                {
                    firstPlayaCards.Enqueue(cardOne);
                    firstPlayaCards.Enqueue(cardTwo);
                }
                else if (cardOneNumber < cardTwoNumber)
                {
                    secondPlayaCards.Enqueue(cardTwo);
                    secondPlayaCards.Enqueue(cardOne);
                }
                else
                {
                    result = new List<string>();

                    result.Add(cardOne);
                    result.Add(cardTwo);

                    War(firstPlayaCards, secondPlayaCards, round);
                }
                IsCountMoreThanZero(firstPlayaCards, secondPlayaCards, round);
            }
            var winner = firstPlayaCards.Count > secondPlayaCards.Count ? "First" : "Second";
            GameOver(winner, round);
        }

        static void War(Queue<string> firstPlayer, Queue<string> secondPlayer, int round)
        {
            IsCountMoreThanZero(firstPlayer, secondPlayer, round);

            if (firstPlayer.Count < 3)
            {
                GameOver("Second", round);
            }
            else if (secondPlayer.Count < 3)
            {
                GameOver("First", round);
            }
            else
            {
                var sumPlayerOne = SumLastChars(firstPlayer);
                var sumPlayerTwo = SumLastChars(secondPlayer);

                if (sumPlayerOne == sumPlayerTwo)
                {
                    War(firstPlayer, secondPlayer, round);
                }
                else if (sumPlayerOne > sumPlayerTwo)
                {
                    AddRange(firstPlayer);
                }
                else if (sumPlayerTwo > sumPlayerOne)
                {
                    AddRange(secondPlayer);
                }
            }
        }

        static void AddRange(Queue<string> que)
        {
            OrderElementsInList();
            foreach (var item in result)
            {
                que.Enqueue(item);
            }
        }

        static void OrderElementsInList()
        {
            result = result
                .OrderByDescending(x => long.Parse(x.Substring(0, x.Length - 1)))
                .ThenByDescending(x => x[x.Length - 1] - 96)
                .ToList();
        }

        static int SumLastChars(Queue<string> que)
        {
            var first = que.Dequeue();
            var second = que.Dequeue();
            var third = que.Dequeue();
            result.AddRange(new List<string> { first, second, third });

            return 
                first[first.Length - 1] +
                second[second.Length - 1] +
                third[third.Length - 1];
        }

        static void IsCountMoreThanZero(Queue<string> firstPlayer, Queue<string> secondPlayer, int round)
        {
            if (firstPlayer.Count == 0 && secondPlayer.Count == 0)
            {
                Console.WriteLine($"Draw after {round} turns");
                Environment.Exit(0);
            }
            else if (firstPlayer.Count <= 0)
            {
                GameOver("Second", round);
            }
            else if (secondPlayer.Count <= 0)
            {
                GameOver("First", round);
            }
        }

        static void GameOver(string playa, int round)
        {
            Console.WriteLine($"{playa} player wins after {round} turns");
            Environment.Exit(0);
        }
    }
}
