using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private bool _hasUnsavedChanges = false;

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        _hasUnsavedChanges = true;
    }

    public bool HasUnsavedChanges()
    {
        return _hasUnsavedChanges;
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("Error: The filename cannot be empty.\n");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.GetSaveString());
                }
            }

            _hasUnsavedChanges = false;
            Console.WriteLine($"Journal successfully saved to '{file}'.\n");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Error: The journal could not be saved. {error.Message}\n");
        }
    }

    public void LoadFromFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("Error: The filename cannot be empty.\n");
            return;
        }

        if (!File.Exists(file))
        {
            Console.WriteLine($"Error: The file '{file}' does not exist.\n");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(file);
            List<Entry> loadedEntries = new List<Entry>();
            int skippedLines = 0;

            foreach (string line in lines)
            {
                Entry entry = Entry.FromSaveString(line);

                if (entry != null)
                {
                    loadedEntries.Add(entry);
                }
                else if (line.Trim().Length > 0)
                {
                    skippedLines++;
                }
            }

            _entries = loadedEntries; // Clears current entries as required by specifications
            _hasUnsavedChanges = false;

            Console.WriteLine($"Journal successfully loaded from '{file}'.");

            if (skippedLines > 0)
            {
                Console.WriteLine($"Note: {skippedLines} unreadable line(s) were skipped.");
            }

            Console.WriteLine();
        }
        catch (Exception error)
        {
            Console.WriteLine($"Error: The journal could not be loaded. {error.Message}\n");
        }
    }
}
