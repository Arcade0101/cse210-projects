// EXCEEDING REQUIREMENTS NOTE:
// 1. Each entry also stores a mood, which is saved and loaded with the entry.
// 2. The program warns before quitting when entries have not been saved.
// 3. File errors are handled instead of crashing the program.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please choose one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            // No more input, so stop
            if (choice == null)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            switch (choice)
            {
                case "1":
                    // Get random prompt
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine() ?? "";

                    // Exceeding Requirements: Record mood
                    Console.Write("How would you rate your mood today (e.g., Happy, Stressed, Calm)? ");
                    string mood = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(mood))
                    {
                        mood = "Not Specified";
                    }

                    // Create new entry
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    Console.WriteLine("Entry recorded!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFileName = Console.ReadLine() ?? "";
                    journal.LoadFromFile(loadFileName);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFileName = Console.ReadLine() ?? "";
                    journal.SaveToFile(saveFileName);
                    break;

                case "5":
                    // Exceeding Requirements: warn about unsaved entries
                    if (journal.HasUnsavedChanges())
                    {
                        Console.Write($"You have {journal.GetEntryCount()} entry(s) that have not been saved. Quit anyway? (y/n) ");
                        string confirmation = Console.ReadLine();

                        if (confirmation != null && confirmation.Trim().ToLower() != "y")
                        {
                            Console.WriteLine("Returning to the menu.\n");
                            break;
                        }
                    }

                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }
}
