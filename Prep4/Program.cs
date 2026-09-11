using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        // Collect numbers until the user types 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string? input = Console.ReadLine();
            userNumber = int.Parse(input ?? "0");

            // Only add non-zero numbers to the list
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Core Requirement 1: Calculate Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Core Requirement 2: Calculate Average
        double average = ((double)sum) / numbers.Count;

        // Core Requirement 3: Find Maximum
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Stretch Challenge 1: Find Smallest Positive Number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge 2: Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}