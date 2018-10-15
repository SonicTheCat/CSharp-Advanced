namespace task1
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var pattern = "s:([^;]+?);r:([^;]+?);m--\"([A-Za-z\\s]+)\"";

            Regex regex = new Regex(pattern);
            var totalData = 0;
            var line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                var input = Console.ReadLine();

                var currentMessage = regex.Match(input);

                if (!currentMessage.Success)
                {
                    continue;
                }
                var sender = currentMessage.Groups[1].Value;
                var receiver = currentMessage.Groups[2].Value;
                var message = currentMessage.Groups[3].Value;

                totalData += FindTransferData(sender);
                totalData += FindTransferData(receiver);
                var finalSender = FindName(sender);
                var finalReceiver = FindName(receiver);

                Console.WriteLine($"{finalSender} says \"{message}\" to {finalReceiver}");
            }
            Console.WriteLine($"Total data transferred: {totalData}MB");
        }

        static string FindName(string name)
        {
            string result = "";
            foreach (var symbol in name)
            {
                if (char.IsLetter(symbol) || symbol == ' ')
                {
                    result += symbol;
                }
            }
            return result;
        }
        static int FindTransferData(string text)
        {
            var data = 0;
            foreach (var symbol in text)
            {
                if (char.IsDigit(symbol))
                {
                    data += int.Parse(symbol.ToString());
                }
            }
            return data;
        }
    }
}
