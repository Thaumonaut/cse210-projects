using System.Text.RegularExpressions;

public class Word
{
    private string _word;
    private bool _isVisible;

    public Word(string word)
    {
        _word = word;
        _isVisible = true;
    }

    public void Hide()
    {
        _isVisible = false;
    }

    public void Show()
    {
        _isVisible = true;
    }

    public bool GetVisibility()
    {
        return _isVisible;
    }

    public string Display()
    {
        if (_isVisible)
        {
            return _word;
        }

        return Regex.Replace(_word, @"\w", "_");
    }

}