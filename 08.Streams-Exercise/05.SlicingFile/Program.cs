using System;
using System.Collections.Generic;
using System.IO;

namespace _05SlicingFile
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main()
        {
            var filePath = @"../../sliceMe.mp4";
            var destination = "";
            Slice(filePath, destination, 5);

            var list = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(list, destination);
        }
        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);

                var partsSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == "")
                    {
                        destinationDirectory = "./";
                    }

                    var currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;

                            if (currentPieceSize >= partsSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf(".") + 1);
            if (destinationDirectory == "")
            {
                destinationDirectory = "./";
            }
            string wholeFile = $"{destinationDirectory}Assembled.{extension}";

            using (var writer = new FileStream(wholeFile, FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (var reader = new FileStream(file, FileMode.Open))
                    {
                        byte[] bytes = new byte[bufferSize];

                        while (reader.Read(bytes, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(bytes, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}
