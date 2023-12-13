using System.Text.Json.Serialization;

public class StreamContent : Content
{
    private double _duration;
    private string _game;
    private List<Person> _collaborators = new List<Person>();


    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">What will I call the stream</param>
    /// <param name="platform">Which platform will I stream to</param>
    /// <param name="date">When will I stream</param>
    /// <param name="duration"> In housrs</param>
    /// <param name="collabs">People who will be streaming with me</param>
    public StreamContent (
        string title,
        ePlatforms platform,
        string date,
        double duration,
        string game,
        List<Person> collabs = null
    ):base(title, platform, date) 
    {
        _duration = duration;
        _game = game;
        if (collabs != null)
            _collaborators = collabs;
    }

    public void UpdateGame(string game) {_game = game;}
    public void UpdateDuration(double length) {_duration = length;}

    public void AddCollaborator(Person person){_collaborators.Add(person);}
    public void RemoveCollaborator(Person person){_collaborators.Remove(person);}

    private List<string> CollaboratorsNames()
    {
        List<String> collabs = new List<string>();
        _collaborators.ForEach(p => collabs.Add(p.GetName()));
        return collabs;
    }

    public override string GetDetailsString()
    {
        return $"[ Stream ] Playing '{_game}' for {_duration} hours on {_platform}. The stream will be called {_title} {(_collaborators.Count > 0 ? $"and joined by {String.Join(", ", CollaboratorsNames().ToArray())}" : "")}";
    }
}