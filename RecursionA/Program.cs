namespace RecursionA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input number (>0): ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    return;
                }

                if (!int.TryParse(input, out int sequenceNumber) || sequenceNumber <= 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                int result = Fibonacci(sequenceNumber);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine();
            }
        }

        public static int Fibonacci(int sequenceNumber)
        {
            if (sequenceNumber == 1 || sequenceNumber == 2)
            {
                return 1;
            }
            
            return Fibonacci(sequenceNumber - 1) + Fibonacci(sequenceNumber - 2);
        }
    }
}