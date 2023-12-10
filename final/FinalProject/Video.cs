public class Video : Content
{

    private bool _isShort;
    private string _description;
    private string _genre;

    public Video(
        string title,
        ePlatforms platform,
        DateTime date
    ):base(title, platform, date){}

    public override string GetDetailsString()
    {
        throw new NotImplementedException();
    }
}