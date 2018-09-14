namespace _06.TargetPractice
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var word = Console.ReadLine().ToCharArray();

            var matrix = new char[sizes[0]][];
            int col = 0;
            int counter = 0;
            bool goLeft = true;

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                col = goLeft == true ? sizes[1] - 1 : 0;
                var arr = new char[sizes[1]];

                for (int j = 0; j < sizes[1]; j++)
                {
                    int indx = counter++ % word.Length;
                    if (goLeft)
                    {
                        arr[col--] = word[indx];
                    }
                    else
                    {
                        arr[col++] = word[indx];
                    }
                }
                goLeft = goLeft == true ? false : true;
                matrix[i] = arr;
            }

            MakeShot(matrix);
            FixFallingCharacters(matrix);

            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join("", arr));
            }
        }
        static void FixFallingCharacters(char[][] matrix)
        {
            for (int r = matrix.Length - 1; r >= 1; r--)
            {
                for (int c = matrix[r].Length - 1; c >= 0; c--)
                {
                    if (matrix[r][c] == ' ')
                    {
                        int index = r - 1;
                        while (matrix[index][c] == ' ' && index > 0)
                        {
                            index--;
                        }
                        matrix[r][c] = matrix[index][c];
                        matrix[index][c] = ' ';
                    }
                }
            }
        }
        static void MakeShot(char[][] matrix)
        {
            var shotData = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int shotRow = shotData[0];
            int shotCol = shotData[1];
            int shotRad = shotData[2];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    bool isInside = CalculateIfPointIsIn(shotRow, shotCol, r, c, shotRad);
                    if (isInside)
                    {
                        matrix[r][c] = ' ';
                    }
                }
            }
        }
        static bool CalculateIfPointIsIn(int centerY, int centerX, int y, int x, int radius)
        {
            double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
            if (distance <= radius)
            {
                return true;
            }
            return false;
        }
    }
}
