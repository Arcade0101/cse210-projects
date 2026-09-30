using System;
using System.Collections.Generic;

class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Name something small that made you smile recently.",
        "Name a person who has made your life better.",
        "Name an ability or skill you're grateful to have.",
        "Name a place that brings you peace or comfort.",
        "Name a challenge that ended up teaching you something valuable."
    };

    private Random _random = new Random();

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity will help you cultivate gratitude by having you name things you are thankful for and then reflect on why they matter to you.")
    {
    }

    public override void Run()
    {
        ShowStartingMessage();

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.Write($"> {prompt} ");
            string response = Console.ReadLine();
            items.Add(response);
        }

        Console.WriteLine();
        Console.WriteLine($"You named {items.Count} things you are grateful for.");
        Console.WriteLine("Take a moment to hold onto that feeling of gratitude.");
        ShowSpinner(3);

        ShowEndingMessage();
    }
}
