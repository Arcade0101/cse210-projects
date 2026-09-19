// Exceeding Requirements Description:
// 1. Library Feature: Added a list/library of scriptures and randomly selects one when starting.
// 2. Smart Word Selection : HideRandomWords selects ONLY from words that are 
//    not yet hidden, ensuring efficient progression until complete hiding.

namespace ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirement: Scripture Library
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16), 
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6), 
                "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
            ),
            new Scripture(
                new Reference("Ether", 12, 27), 
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble."
            )
        };

        // Pick a random scripture from the library
        Random random = new Random();
        Scripture currentScripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();

            if (currentScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 words at a time
            currentScripture.HideRandomWords(3);
        }
    }
}
