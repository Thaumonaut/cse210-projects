public class Scripture 
{
    private Reference _ref;
    private List<Word> _verse;

    private List<int> _visibleWords = new List<int>();
    private List<int> _lastHidden;

    public Scripture(string text, Reference reference)
    {
        _ref = reference;
        _verse = StringToVerse(text);
        for (int i = 0; i < _verse.Count; i++)
        {
            _visibleWords.Add(i);
        }
    }

    public List<Word> StringToVerse(string verse) {
        List<Word> tempList = new List<Word>();
        string[] splitVerse = verse.Split(" ");
        foreach (var word in splitVerse)
        {
            tempList.Add(new Word(word.Trim()));
        }

        return tempList;
    }

    public void HideRandomWords(int numberToHide) {

        _lastHidden = new List<int>();
        if (_visibleWords.Count < numberToHide)
        {
            numberToHide = _visibleWords.Count;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int rng = new Random().Next(_visibleWords.Count);
            int randomIndex = _visibleWords[rng];
            _lastHidden.Add(_visibleWords[rng]);
            _visibleWords.RemoveAt(rng);
            _verse[randomIndex].Hide();
        }
    }

    public void RestoreLastHidden() {
        if (_lastHidden == null || _lastHidden.Count == 0) {
            return;
        }
        foreach (var index in _lastHidden)
        {
            _visibleWords.Add(index);
            _verse[index].Show();
        }
    }

    public string Display() {
        string displayVerse = $"{_ref.Display()}\n";
        foreach (var word in _verse)
        {
            displayVerse += word.Display() + " ";
        }
        return displayVerse;
    }

    public bool IsAllHidden() {
        return _visibleWords.Count == 0;
    }


}