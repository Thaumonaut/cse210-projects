using System.IO;

public class Journal 
{
    public List<Entry> entries = new List<Entry>();
    
    public void Display()
    {
        if (entries.Count == 0) {
            Console.WriteLine("There are no entries to display.");
        }
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        // Save entries list to file.
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine(string.Join("|", entry._date, entry._prompt, entry._response));
            }
        }

        Console.WriteLine("File saved!");
        
    }

    public void LoadFromFile(string filename)
    {
        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (System.Exception)
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        entries.Clear();

        foreach (var line in lines)
        {
            string[] sections = line.Split("|");
            Entry entry = new Entry();

            entry._date = sections[0];
            entry._prompt = sections[1];
            entry._response = sections[2];

            entries.Add(entry);

        }

        Console.WriteLine("File loaded!");
    }
}