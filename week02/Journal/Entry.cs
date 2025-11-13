public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string prompt, string text, string date)
    {
        _promptText = prompt;
        _entryText = text;
        _date = date;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string GetEntryAsCsv()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromCsv(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[1], parts[2], parts[0]);
    }
}
