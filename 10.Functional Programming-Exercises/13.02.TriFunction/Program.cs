using System;
using System.Linq;

namespace _13._02.TriFunction
{
    class Program
    {
        public static void Main()
        {
            int target = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int> sumLetters = p => p.ToCharArray().Sum(c => c);
            Func<string, int, bool> isTargetHit = (s, n) => sumLetters(s) >= n;

            var winner = names.FirstOrDefault(n => isTargetHit(n, target));
            Console.WriteLine(winner);
        }      
    }
}
