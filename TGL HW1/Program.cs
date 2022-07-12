namespace TGL_HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            input:
            Console.Write("Enter number or \"exit\" to stop the program: ");
            var numberString = Console.ReadLine();
            while (numberString.ToLowerInvariant() != "exit")
            {
                try
                {
                    if (!int.TryParse(numberString, out int number))
                    {
                        throw new ArgumentException($"{numberString} can't be converted to an integer");
                    }
                    if (number < 0)
                    {
                        throw new ArgumentException($"{number} is less than 0");
                    }

                    if (number == 0)
                    {
                        Console.WriteLine("0! = 1");
                        Console.WriteLine("Fibonacci sequence of zero size is empty");
                        goto input;
                    }

                    Console.WriteLine($"{number}! = " + Enumerable.Range(1, number)
                        .Aggregate((i, j) => i * j));

                    Console.WriteLine($"Fibonacci sequence of size {number}:");
                    var fibonacciSequence = new List<int> { 1 };
                    if (number == 1)
                    {
                        Console.WriteLine(fibonacciSequence.First());
                        goto input;
                    }
                    fibonacciSequence.Add(1);
                    if (number == 2)
                    {
                        Console.WriteLine(fibonacciSequence.First() + "\n" + fibonacciSequence.Last());
                    }
                    else
                    {
                        var ending = new { a = 1, b = 1 };
                        fibonacciSequence.AddRange(Enumerable.Repeat(1, number - 2)
                            .Select(element =>
                            {
                                var temporary = ending;
                                ending = new { a = ending.b, b = ending.a + ending.b };
                                return temporary.a + temporary.b;
                            }));
                        foreach (var element in fibonacciSequence)
                        {
                            Console.WriteLine(element);
                        }
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
                goto input;
            }
        }
    }
}