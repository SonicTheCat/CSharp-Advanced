using System;
using System.Text.RegularExpressions;

namespace _03.BasicMarkupLanguage
{
    class Program
    {
        private static int lineCounter = 0;

        static void Main()
        {
            var firstPattern = "([A-Za-z]+)\\s+content\\s*=\\s*\"(\\s*\\s*.+?\\s*\\s*)\"";
            var reapeatPattern =  "([A-Za-z]+)\\s+value\\s*=\\s*\"(\\s*[0-9]+\\s*)\"\\s+content\\s*=\\s*\"(\\s*.+?\\s*)\"";

            string input;
            while ((input = Console.ReadLine()) != "<stop/>")
            {
                Match match = Regex.Match(input, firstPattern);
                if (match.Success == false)
                {
                    match = Regex.Match(input, reapeatPattern);
                }

                if (match.Groups.Count == 3)
                {
                    var command = match.Groups[1].Value;
                    var word = match.Groups[2].Value;

                    if (command == "inverse")
                    {
                        InverseWord(word);
                    }
                    else if (command == "reverse")
                    {
                        ReverseWord(word);
                    }
                }
                else if (match.Groups.Count == 4)
                {
                    var command = match.Groups[1].Value;
                    var value = match.Groups[2].Value;
                    var word = match.Groups[3].Value;

                    if (command == "repeat")
                    {
                        RepeatWord(value, word);
                    }
                }
            }
        }

        static void RepeatWord(string value, string word)
        {
            for (int i = 0; i < int.Parse(value); i++)
            {
                Print(word);
            }
        }

        static void ReverseWord(string word)
        {
            var reversed = string.Empty;
            word = word.Trim('"');
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversed += word[i];
            }
            Print(reversed);
        }

        static void InverseWord(string word)
        {
            var inversed = string.Empty;
            word = word.Trim('"');
            foreach (var w in word)
            {
                if (Char.IsUpper(w))
                {
                    inversed += w.ToString().ToLower();
                }
                else
                {
                    inversed += w.ToString().ToUpper();
                }
            }
            Print(inversed);
        }

        static void Print(string result)
        {
            Console.WriteLine($"{++lineCounter}. {result}");
        }
    }
}