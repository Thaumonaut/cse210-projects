using System.Text.Json.Serialization;

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
    protected string _title;
    protected ePlatforms _platform;
    protected DateTime _date;
    private List<Task> _tasks;

    public Content(string title, ePlatforms platform, string date)
    {
        _title = title;
        _date = DateTime.Parse(date);
        _platform = platform;
        _tasks = new List<Task>();
    }
    
    public string GetTimeTillDue()
    {
        int daysTillDue = (_date - DateTime.Now).Days;

        return $"This is due in {daysTillDue} days.";
    }

    public bool IsReadyForRelease()
    {
        foreach (Task task in _tasks)
        {
            if(!task.IsAllComplete()) return false;
        }

        return true;
    }

    public void AddTask(Task task){_tasks.Add(task);}
    public void RemoveTask(Task task){_tasks.Remove(task);}
    public void CompleteTask(int index){_tasks[index].SetTaskComplete();}
    public Task GetTask(int index) {return _tasks[index];}
    public List<String> ShowTasks()
    {
        List<string> tempList = new List<string>();
        foreach (Task task in _tasks)
        {
            tempList.Add(task.TaskToString());
        }

        return tempList;
    }

    public abstract string GetDetailsString();

    // TODO: Create a class to handle this. Similar to madlib but with different content verbs and nouns.
    // public abstract string GenerateContentIdeas();
}