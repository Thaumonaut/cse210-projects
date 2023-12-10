public class Stream : Content
{

    private double _duration;
    private DateTime _startTime;
    private string _game;
    private List<Person> _collaborators;

    public Stream (
        string title,
        ePlatforms platform,
        DateTime date
    ):base(title, platform, date){}

    public override string GetDetailsString()
    {
        throw new NotImplementedException();
    }
}