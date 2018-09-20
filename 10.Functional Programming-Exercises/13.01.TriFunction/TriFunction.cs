namespace _13.TriFunction
{
    using System;
    using System.Linq;
    
    public class TriFunction
    {
        public static void Main()
        {
            int target = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<char[], bool> currentName = arr => arr.Select(x => (int)x).Sum() >= target;
            var winner = names.Where(p => currentName(p.ToCharArray())).ToArray();

            if (winner.Length > 0)
            {
                Console.WriteLine(winner[0]);
            }
        }
    }
}
