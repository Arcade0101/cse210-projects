using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Stretch Challenge 2: Loop to play the entire game again
        while (playAgain.ToLower() == "yes")
        {
            // Core Requirement 3: Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0; // Stretch Challenge 1: Track guess count

            // Core Requirement 2: Loop until the guess matches the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string? input = Console.ReadLine();
                guess = int.Parse(input ?? "0");
                guessCount++;

                // Core Requirement 1: Higher/Lower logic
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
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask user if they want to play again
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine() ?? "no";
            Console.WriteLine();
        }
    }
}
