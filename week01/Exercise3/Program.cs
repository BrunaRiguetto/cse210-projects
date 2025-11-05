using System;

class Program
{
    static void Main(string[] args)
    {
        string play = "yes";
        Random randomGenerator = new Random();

        while (play.ToLower() == "yes")
        {
            // Generate random magic number between 1–100
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int count = 0;

            // Loop until guessed correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {count} guesses.");
            Console.WriteLine();

            Console.Write("Would you like to play again (yes/no)? ");
            play = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thank you for playing. Goodbye!");
    }
}
