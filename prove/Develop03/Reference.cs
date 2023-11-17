public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _lastVerse = 0;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int verse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _lastVerse = lastVerse;
    }

    public string Display()
    {
        string verses = _verse.ToString();
        if (_lastVerse != 0)
        {
            verses = $"{_verse}-{_lastVerse}";
        }
        return $"{_book} {_chapter}:{verses}";
    }
}