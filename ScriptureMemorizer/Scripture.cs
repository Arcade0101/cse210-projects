namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text by spaces into Word objects
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // Stretch Goal implementation: Exclude already hidden words
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0) return;

        int wordsToHideCount = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Ensure no duplicate selection in same pass
        }
    }

    public string GetDisplayText()
    {
        List<string> wordTexts = new List<string>();
        foreach (Word word in _words)
        {
            wordTexts.Add(word.GetDisplayText());
        }

        string scriptureText = string.Join(" ", wordTexts);
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}