using System.IO; 

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new FileStream("../../jsLogo.png", FileMode.Open))
            {
                byte[] bytes = new byte[4096];
                using (var destination = new FileStream("../../newLogo.png",FileMode.Create))
                {
                    while (true)
                    {
                        int read = stream.Read(bytes, 0, bytes.Length);
                        if (read == 0)
                        {
                            break;
                        }
                        destination.Write(bytes, 0, read); 
                    }
                }
            }
        }
    }
}
