using System.Text.Json.Serialization;

public class Person
{
    
    private string _preferredName;
    private string _email;
    private Dictionary<ePlatforms, string> _usernames;

    public Person(string name, string email)
    {
        _preferredName = name;
        _email = email;
        _usernames = new Dictionary<ePlatforms, string>();
        foreach (var platform in Enum.GetNames<ePlatforms>())
        {
            _usernames.Add(Enum.Parse<ePlatforms>(platform), "");
        }
    }

    public void UpdateName(string name){_preferredName = name;}
    public string GetName(){return _preferredName;}
    public void AddUsername(ePlatforms platform, string username){_usernames[platform] = username;}
    public string GetUsername(ePlatforms platform){return _usernames[platform];}
}