using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Prompt user for grade percentage
        Console.Write("What is your grade percentage? ");
        string? input = Console.ReadLine();
        int percent = int.Parse(input ?? "0");

        // 2. Determine base letter grade
        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // 3. Stretch Challenge: Determine grade sign (+ or -)
        string sign = "";
        int lastDigit = percent % 10;

        // Sign logic applies unless it's an F
        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                // Edge case: No A+ grade
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // 4. Single print statement for the grade letter and sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // 5. Determine pass/fail status (70% or higher is passing)
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll get it next time.");
        }
    }
}
