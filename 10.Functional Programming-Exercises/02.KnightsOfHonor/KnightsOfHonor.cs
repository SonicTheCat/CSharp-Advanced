namespace _02.KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> appendTitle = x => Console.WriteLine("Sir " + x);

            foreach (var name in names)
            {
                appendTitle(name);
            }
        }
    }
}
