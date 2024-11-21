namespace MatrixB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input array size (1-10): ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    return;
                }

                if (!int.TryParse(input, out int size) || (size < 1 || size > 10))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                int[] array = CreateFilledArray(size);
                OutputArray(array);

                int sum = array.Where(v => v % 3 == 0).Sum();
                Console.WriteLine($"Result: {sum}");

                Console.WriteLine();
            }
        }

        public static int[] CreateFilledArray(int size)
        {
            Random rand = new Random();

            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 100);
            }
            return array;
        }

        public static void OutputArray(int[] array)
        {
            Console.WriteLine("Array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}