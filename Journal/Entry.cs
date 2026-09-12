using System;

public class Entry
{
    private const string Separator = "~|~";

    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood; // Exceeds requirements: tracks user mood/rating

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string GetSaveString()
    {
        // Response goes last
        return $"{Clean(_date)}{Separator}{Clean(_promptText)}{Separator}{Clean(_mood)}{Separator}{_entryText}";
    }

    public static Entry FromSaveString(string line)
    {
        string[] parts = line.Split(Separator, 4);

        if (parts.Length == 4)
        {
            return new Entry(parts[0], parts[1], parts[3], parts[2]);
        }

        if (parts.Length == 3)
        {
            // Old file with no mood
            return new Entry(parts[0], parts[1], parts[2], "Not Specified");
        }

        return null;
    }

    private static string Clean(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }

        return text.Replace(Separator, "/");
    }
}
