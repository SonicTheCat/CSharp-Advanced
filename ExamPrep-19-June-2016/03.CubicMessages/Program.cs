using System;
using System.Text.RegularExpressions;

namespace _03.CubicMessages
{
    class Program
    {
        static void Main()
        {
            var pattern = @"(?<start>^[0-9]+)(?<message>[A-Za-z]+)(?<end>[^A-Za-z]*)$";
            Regex regex = new Regex(pattern);

            string input;
            while ((input = Console.ReadLine()) != "Over!")
            {
                Match match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }

                var startNums = match.Groups["start"].Value;
                var end = match.Groups["end"].Value;
                var message = match.Groups["message"].Value;

                if (message.Length != int.Parse(Console.ReadLine()))
                {
                    continue;
                }

                var result = string.Empty;
                result += FindOutMessage(startNums, message);
                result += FindOutMessage(end, message);

                Console.WriteLine(message + " == " + result);
            }
        }
        static string FindOutMessage(string collection, string message)
        {
            var result = string.Empty;
            foreach (var symbol in collection)
            {
                if (char.IsDigit(symbol))
                {
                    var index = int.Parse(symbol.ToString());
                    if (index < message.Length)
                    {
                        result += message[index];
                    }
                    else
                    {
                        result += " ";
                    }
                }
            }
            return result;
        }
    }
}