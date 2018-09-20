namespace _01.ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(" ");
            Action<string> print = Print;

            foreach (var name in names)
            {
                print(name);
            }
        }
        static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
