public class Task
{
    private string _title;
    private string _description;
    private double _workTime;
    private Person _assignment;
    private DateTime _dueDate;
    private bool _isComplete;
    private List<Content> _linkedContent;
    private List<Task> _subTasks;
    private List<string> _workLog;

    private bool _isSubtask;

    public Task(string title, string description, Person person, DateTime dueDate, bool isSubtask)
    {
        _title = title;
        _description = description;
        _assignment = person;
        _dueDate = dueDate;
        _linkedContent = new List<Content>();
        _subTasks = new List<Task>();
        _workLog = new List<string>();
        _workTime = 0.0;
        _isSubtask = isSubtask;
    }

    // Add time worked based on start and end time.
    // Worklog entry to add notes about work done.
    public void AddLogEntry(string entry){_workLog.Add(entry);}
    public void DisplayWorkLog(){}
    public void DisplaySubTasks()
    {
        foreach (Task task in _subTasks)
        {
            Console.Write("     ");
            Console.WriteLine(task.TaskToString());
        }
    }
    public string TaskToString(){return $"[ ] [{GetSubTaskCompleteCount()}/{_subTasks.Count}] Due: {_dueDate.ToString()} | Assigned to: {_assignment.GetName()} | {_title} ({_description})";}
    public void ChangeAssignment(Person assignment){ _assignment = assignment;}
    public void AddLinkedContent(Content content){_linkedContent.Add(content);}
    public void RemoveLinkedContent(Content content){_linkedContent.Remove(content);}
    public void AddSubtask(Task subtask) {_subTasks.Add(subtask);}

    public void SetTaskComplete(){_isComplete = true;}
    public int GetSubTaskCompleteCount()
    {
        if(_subTasks.Count <= 0) {
            return 0;
        }
        
        int temp = 0;
        foreach (Task task in _subTasks)
        {
            if(task._isComplete)
            {
                temp++;
            }
        }
        return temp;
    }
    public bool IsAllComplete()
    {
        foreach (Task task in _subTasks)
        {
            if (!task._isComplete)
            {
                return false;
            }
        }

        return true;
    }
}