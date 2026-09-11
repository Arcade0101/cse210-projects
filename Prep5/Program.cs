using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Display welcome message
        DisplayWelcome();

        // 2. Prompt for user name and favorite number
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        // 3. Square the number
        int squaredNumber = SquareNumber(userNumber);

        // 4. Display result
        DisplayResult(userName, squaredNumber);
    }

    // Displays the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string? name = Console.ReadLine();
        return name ?? "";
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string? input = Console.ReadLine();
        int number = int.Parse(input ?? "0");
        return number;
    }

    // Accepts an integer and returns that number squared
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Accepts the user's name and squared number and displays them
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}