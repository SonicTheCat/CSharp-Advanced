namespace _01.MatrixOfPalindromes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rowCol = Console.ReadLine().Split(' ');
            int rows = int.Parse(rowCol[0]);
            int cols = int.Parse(rowCol[1]);
            string[][] matrix = new string[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new string[cols];
                isPalindrom(row, matrix);
            }

            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        static void isPalindrom(int row, string[][] matrix)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int counter = 0;

            for (int i = row; i < alphabet.Length; i++)
            {
                for (int j = row; j < alphabet.Length; j++)
                {
                    for (int z = row; z < alphabet.Length; z++)
                    {
                        if (alphabet[i] == alphabet[z])
                        {
                            if (counter != matrix[row].Length)
                            {
                                matrix[row][counter++] = "" + alphabet[i] + alphabet[j] + alphabet[z];
                                continue;
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}
