using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CSE 210 C# PREP EXERCISES ===");
            Console.WriteLine("1. Prep 1 (Variables, Input, Output)");
            Console.WriteLine("2. Prep 2 (Conditionals)");
            Console.WriteLine("3. Prep 3 (Loops)");
            Console.WriteLine("4. Prep 4 (Lists)");
            Console.WriteLine("5. Prep 5 (Functions)");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an exercise to run (0-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunPrep1();
                    break;
                case "2":
                    RunPrep2();
                    break;
                case "3":
                    RunPrep3();
                    break;
                case "4":
                    RunPrep4();
                    break;
                case "5":
                    RunPrep5();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }

    // --- PREP 1: Variables, Input, Output ---
    static void RunPrep1()
    {
        Console.WriteLine("--- Prep 1: Name Formatter ---");
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }

    // --- PREP 2: Conditionals ---
    static void RunPrep2()
    {
        Console.WriteLine("--- Prep 2: Grade Calculator ---");
        Console.Write("What is your grade percentage? ");
        int percent = int.Parse(Console.ReadLine());

        string letter = "";
        if (percent >= 90) letter = "A";
        else if (percent >= 80) letter = "B";
        else if (percent >= 70) letter = "C";
        else if (percent >= 60) letter = "D";
        else letter = "F";

        string sign = "";
        int lastDigit = percent % 10;
        if (letter != "F")
        {
            if (lastDigit >= 7 && letter != "A") sign = "+";
            else if (lastDigit < 3) sign = "-";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        if (percent >= 70)
            Console.WriteLine("Congratulations! You passed the course.");
        else
            Console.WriteLine("Keep trying! You'll get it next time.");
    }

    // --- PREP 3: Loops ---
    static void RunPrep3()
    {
        Console.WriteLine("--- Prep 3: Guess My Number ---");
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int targetNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("\nI'm thinking of a number between 1 and 100.");

            while (guess != targetNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < targetNumber) Console.WriteLine("Higher");
                else if (guess > targetNumber) Console.WriteLine("Lower");
                else Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
            }

            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine();
        }
    }

    // --- PREP 4: Lists ---
    static void RunPrep4()
    {
        Console.WriteLine("--- Prep 4: Number List Operations ---");
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0) numbers.Add(userNumber);
        }

        if (numbers.Count == 0) return;

        int sum = 0;
        int max = numbers[0];
        int smallestPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max) max = number;
            if (number > 0 && number < smallestPositive) smallestPositive = number;
        }

        double average = ((double)sum) / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        if (smallestPositive != int.MaxValue)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers) Console.WriteLine(number);
    }

    // --- PREP 5: Functions ---
    static void RunPrep5()
    {
        Console.WriteLine("--- Prep 5: Functions ---");
        DisplayWelcome();
        string name = PromptUserName();
        int favNumber = PromptUserNumber();
        int square = SquareNumber(favNumber);
        DisplayResult(name, square);
    }

    static void DisplayWelcome() => Console.WriteLine("Welcome to the Program!");
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number) => number * number;
    static void DisplayResult(string name, int square) => Console.WriteLine($"{name}, the square of your number is {square}");
}
