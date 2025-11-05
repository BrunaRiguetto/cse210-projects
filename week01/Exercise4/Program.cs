using System;

class Program
{
    static void Main(string[] args)
    
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Validate integer input
            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            // Stop when user enters 0 (do not add 0 to the list)
            if (value == 0)
            {
                break;
            }

            numbers.Add(value);
        }

        // If no numbers were entered, inform the user and exit.
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Compute sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        // Compute average (as double)
        double average = (double)sum / numbers.Count;

        // Find largest number
        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max) max = n;
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
