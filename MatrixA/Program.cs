namespace MatrixA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input matrix size (1-10): ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    return;
                }

                if (!int.TryParse(input, out int matrixSize) || (matrixSize < 1 || matrixSize > 10))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                int[,] matrix = CreateFilledMatrix(matrixSize);
                OutputMatrix(matrix);

                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, i];
                }
                Console.WriteLine($"Result: {sum}");

                Console.WriteLine();
            }
        }

        public static int[,] CreateFilledMatrix(int size)
        {
            Random rand = new Random();

            int[,] matrix = new int[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(1, 100);
                }
            }
            return matrix;
        }

        public static void OutputMatrix(int[,] matrix)
        {
            Console.WriteLine("Matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}