using System;
using System.IO;
using System.Text;

namespace _02.test
{
    class Program
    {
        static void Main()
        {
            using (var source = new FileStream("../../csharp.jpg",FileMode.Open))
            {
                using (var destination = new FileStream("../../copiedPhoto.jpg", FileMode.Create))
                {
                    var buffer = new byte[4096]; 
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break; 
                        }
                        destination.Write(buffer, 0, readBytes); 
                    }
                }
            }
        }
    }
}
