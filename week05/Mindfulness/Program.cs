using System;

// Enhancements beyond core requirements:
// 1. The base Activity class centralizes the starting message, ending message,
//    countdown animation, and spinner animation so no code is duplicated across
//    the activity subclasses (Breathing, Reflection, Listing, Gratitude).
// 2. Added a fourth activity, Gratitude, which combines listing items with a
//    closing moment of reflection, distinct from the core three activities.
// 3. The menu loop lets the user run multiple activities in one session and
//    exit cleanly, rather than running once and closing.
class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Activity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                Activity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                Activity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Activity activity = new GratitudeActivity();
                activity.Run();
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
