using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main()
        {
            using (var wordsReader = new StreamReader("../../words.txt"))
            {
                var words = wordsReader.ReadToEnd().Split('\n').Select(x => x.Trim()).ToArray();
                var countWords = new Dictionary<string, int>();

                using (var textReader = new StreamReader("../../text.txt"))
                {
                    var str = textReader.ReadToEnd().ToLower(); 

                    using (var writer = new StreamWriter("../../result.txt"))
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            var currentWord = words[i].ToLower();
                            var index = 0;
                            while (true)
                            {
                                index = str.IndexOf(currentWord, index);
                                if (index == -1)
                                {
                                    break; 
                                }
                                
                                char before = str[index - 1];
                                char after = str[index + currentWord.Length];
                                index++;
                                if (Char.IsLetter(before) || Char.IsLetter(after))
                                {
                                    continue; 
                                }
                                if (!countWords.ContainsKey(currentWord))
                                {
                                    countWords[currentWord] = 0;
                                }
                                countWords[currentWord]++;     
                            }
                        }
                        foreach (var kvp in countWords.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine(kvp.Key + " - " + kvp.Value); 
                        }
                    }
                }
            }
        }
    }
}
