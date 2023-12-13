using System.Text.Json.Serialization;

public class SocialContent : Content
{
    private string _postText;

    public SocialContent(string title, ePlatforms platform, string date, string postText):base(title, platform, date)
    {
        _postText = postText;
    }

    public override string GetDetailsString()
    {
        return $"[ Social ] Post {_title} to ({_platform}) by {_date.ToString()} with the following text: {_postText}";
    }
}