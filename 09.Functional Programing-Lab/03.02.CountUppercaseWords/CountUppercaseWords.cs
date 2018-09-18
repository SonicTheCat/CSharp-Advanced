namespace _03._02.CountUppercaseWords
{
    using System;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> func = w => char.IsUpper(w[0]);

            UpperCaseWords(text, func); 
           
        }
        static void UpperCaseWords(string[] text, Func<string, bool> isUpper)
        {
            foreach (var word in text)
            {
                if (isUpper(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
