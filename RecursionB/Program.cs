namespace RecursionB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input number and exponent (n e): ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    return;
                }

                string[] values = input.Split(" ");
                if (values.Length != 2)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (!double.TryParse(values[0], out double number))
                {
                    Console.WriteLine("Invalid number");
                    continue;
                }

                if (!int.TryParse(values[1], out int exponent))
                {
                    Console.WriteLine("Invalid exponent");
                    continue;
                }

                double result = Power(number, exponent);
                Console.WriteLine($"Result: {result}");
                Console.WriteLine();
            }
        }

        public static double Power(double number, int exponent)
        {
            if (number == 0)
            {
                return 0;
            }

            if (exponent == 0)
            {
                return 1;
            }

            if (exponent < 0)
            {
                return 1 / Power(number, -exponent);
            }

            return number * Power(number, exponent - 1);
        }
    }
}