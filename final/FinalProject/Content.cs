public enum ePlatforms {
    Twitch,
    YouTube,
    xSocial,
    TikTok,
    Instagram,
    Threads,
    Discord
}

public abstract class Content
{
    private string _title;
    private ePlatforms _platform;
    private DateTime _date;
    private bool _isReleaseReady;

    public Content(string title, ePlatforms platform, DateTime date)
    {
        _title = title;
        _date = date;
        _platform = platform;
    }
    
    public string GetTimeTillDue()
    {
        return $"This is due in {DateTime.Now.Day - _date.Day} days.";
    }

    public abstract string GetDetailsString();
    // TODO: Create a class to handle this. Similar to madlib but with different content verbs and nouns.
    // public abstract string GenerateContentIdeas();
}