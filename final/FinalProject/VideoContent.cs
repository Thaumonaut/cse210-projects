using System.Text.Json;
using System.Text.Json.Serialization;

public class VideoContent : Content
{
    private bool _isShort;
    private string _description;

    public VideoContent (
        string title,
        string description,
        ePlatforms platform,
        string date,
        bool isShort = false
    ) :base (title, platform, date) {
        _description = description;
        _isShort = isShort;
    }

    public override string GetDetailsString()
    {
        return $"[ Video ] ~ {_title} ~ '{_description}' will release {_date.ToLongDateString()} on {_platform} and is {(_isShort ? "" : "not ")}a short?";
    }
}