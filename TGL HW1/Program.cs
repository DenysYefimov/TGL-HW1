namespace TGL_HW1
{
    internal class Program
    {
        private static int GetFactorialOfANumber(int number)
        {
            return number == 0 ? 1 : Enumerable.Range(1, number).Aggregate((i, j) => i * j);
        }

        private static IEnumerable<int> GetFibonacciSequenceOfSize(int size)
        {
            var fibonacciSequence = new List<int>();

            if (size == 0)
            {
                return fibonacciSequence;
            }

            fibonacciSequence.Add(1);
            if (size == 1)
            {
                return fibonacciSequence;
            }

            fibonacciSequence.Add(1);
            if (size == 2)
            {
                return fibonacciSequence;
            }
            else
            {
                var ending = new { a = 1, b = 1 };
                fibonacciSequence.AddRange(Enumerable.Repeat(1, size - 2)
                    .Select(element =>
                    {
                        var temporary = ending;
                        ending = new { a = ending.b, b = ending.a + ending.b };
                        return temporary.a + temporary.b;
                    }));
                return fibonacciSequence;
            }
        }

        private static int ValidateAndConvertToInt(string input)
        {
            if (!int.TryParse(input, out int number))
            {
                throw new ArgumentException($"{input} can't be converted to an integer");
            }

            if (number < 0)
            {
                throw new ArgumentException($"{number} is less than 0");
            }

            return number;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter number or \"exit\" to stop the program: ");
                var numberString = Console.ReadLine();
                if (numberString.ToLowerInvariant() == "exit")
                {
                    break;
                }
                try
                {
                    var number = ValidateAndConvertToInt(numberString);

                    Console.WriteLine($"{number}! = " + GetFactorialOfANumber(number));

                    Console.WriteLine($"Fibonacci sequence of size {number}:");

                    foreach (var element in GetFibonacciSequenceOfSize(number))
                    {
                        Console.WriteLine(element);
                    }
                }
                catch(ArgumentException argumentException)
                {
                    Console.WriteLine(
                        $"Argument exception with message \"{argumentException.Message}\" was handled");
                }
                catch(Exception exception)
                {
                    Console.WriteLine($"Exception with message \"{exception.Message}\" was handled");
                }
                finally
                {
                    Console.WriteLine("Please enter again!");
                }
            }
        }
    }
}